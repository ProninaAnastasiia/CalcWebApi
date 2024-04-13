
class Program
{
    private static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5223");

        while (true)
        {
            Console.WriteLine("Введите выражение:");
            string input = Console.ReadLine();
            char operand;
            int operandIndex = -1;

            for (int i = 0; i < input.Length; i++)
            {
                if (IsOperand(input[i]))
                {
                    operandIndex = i;
                    break;
                }
            }

            if (operandIndex != -1)
            {
                operand = input[operandIndex];
                var a = input.Substring(0, operandIndex).Replace(",", ".");
                var b = input.Substring(operandIndex + 1).Replace(",", ".");

                HttpResponseMessage response = new HttpResponseMessage();
                switch (operand)
                {
                    case '+':
                        response = await client.GetAsync($"/api/Calculator/add?a={a}&b={b}");
                        break;
                    case '-':
                        response = await client.GetAsync($"/api/Calculator/subtract?a={a}&b={b}");
                        break;
                    case '*':
                        response = await client.GetAsync($"/api/Calculator/multiply?a={a}&b={b}");
                        break;
                    case '/':
                        response = await client.GetAsync($"/api/Calculator/divide?a={a}&b={b}");
                        break;
                    default:
                        Console.WriteLine("Неподдерживаемый операнд.");
                        break;
                }
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"Результат: {result}");
                }
                else
                {
                    Console.WriteLine("Ошибка при выполнении запроса: " + response.Content.ReadAsStringAsync().Result);
                }                
            }
            else
            {
                Console.WriteLine("Ошибка ввода выражения.");
            }

            bool IsOperand(char c)
            {
                return c == '+' || c == '-' || c == '*' || c == '/';
            }
        }

    }
}