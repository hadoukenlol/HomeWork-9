namespace HomeWork9_task1
{
    public class MyException : Exception
    {
        public MyException() { }
        public MyException(string _exMessage) : base(_exMessage) { }
    }
    internal class Program
    {
        public static Exception[] exceptons = new Exception[] { new MyException("Собственное исключение"), new ArgumentNullException(), new DivideByZeroException(), new FormatException(), new FileNotFoundException() };
        static void Main(string[] args)
        {
            for (int i = 0; i < exceptons.Length; i++)
            {
                try
                {
                    Console.WriteLine($"Итерация исключений {i + 1}");
                    throw exceptons[i];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
    }
}

