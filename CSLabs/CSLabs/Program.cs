using CSLabs.Labs;

namespace CSLabs
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите номер лабораторной.");
            int n = int.Parse(Console.ReadLine());

            switch (n) 
            {
                case 1:
                    var l = new Lab1();
                    l.Func1();
                    break;

            }
                

        }
    }
}
