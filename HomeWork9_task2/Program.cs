namespace HomeWork9_task2
{
    public class Man
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public Man(string _Name, string _FirstName)
        {
            Name = _Name;
            FirstName = _FirstName;
        }
        public int SortByNameAscending(string name1, string name2)
        {

            return name1.CompareTo(name2);
        }

        public int CompareTo(Man compareFirstName)
        {
            if (compareFirstName == null)
                return 1;
            else
                return this.FirstName.CompareTo(compareFirstName.FirstName);
        }

    }
    public class MyException : Exception
    {
        public MyException(string _exMessage) : base(_exMessage) { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Man> users = new List<Man>();
            int intValue;
            string stringValue;
            Console.WriteLine("Сколько пользователей хотите добавить?");
            int count = CheckIntValue(out intValue);
            int i = 0;
            while (i < count)
            {
                Console.WriteLine($"Введите имя {i + 1} пользователя");
                string _Name = CheckStringValue(out stringValue);
                Console.WriteLine($"Введите фамилию {i + 1} пользователя");
                string _FirstName = CheckStringValue(out stringValue);
                users.Add(new Man(_Name, _FirstName));
                i++;
            }
            Console.WriteLine("Какой метод сортировки А-Я(1) или Я-А(2)");
            int methodSort = CheckIntValue(out intValue);
            try
            {
                if (methodSort == 1)
                {
                    users.Sort(delegate (Man x, Man y)
                    {
                        if (x.FirstName == null && y.FirstName == null) return 0;
                        else if (x.FirstName == null) return -1;
                        else if (y.FirstName == null) return 1;
                        else return x.FirstName.CompareTo(y.FirstName);
                    }
                    );
                }
                else if (methodSort == 2)
                {
                    users.Sort(delegate (Man x, Man y)
                    {
                        if (x.FirstName == null && y.FirstName == null) return 0;
                        else if (x.FirstName == null) return -1;
                        else if (y.FirstName == null) return 1;
                        else return y.FirstName.CompareTo(x.FirstName);
                    }
                    );
                }
                else
                {
                    throw new MyException("Введено неверное значение");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }


            foreach (Man man in users)
            {
                Console.WriteLine($"Фамилия: {man.FirstName} Имя: {man.Name} ");
                i++;
            }
            Console.ReadLine();
        }

        static int CheckIntValue(out int CorrectValue)
        {
            var value = Console.ReadLine();
            int numValue;
            bool isNumber = int.TryParse(value, out numValue);
            while (!isNumber)
            {
                Console.WriteLine("Значение не число, попробуйте ввести еще раз");
                value = Console.ReadLine();
                isNumber = int.TryParse(value, out numValue);
            }
            return CorrectValue = Convert.ToInt32(value);
        }

        static string CheckStringValue(out string CorrectValue)
        {
            var value = Console.ReadLine();
            int numValue;
            bool isNumber = int.TryParse(value, out numValue);
            while (isNumber)
            {
                Console.WriteLine("В значении не должно быть чисел");
                value = Console.ReadLine();
                isNumber = int.TryParse(value, out numValue);
            }
            return CorrectValue = value;
        }
    }
}