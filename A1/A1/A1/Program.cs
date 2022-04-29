using System;

namespace A1
{
    class Program
    {
        static void Main(string[] args)
        {
            Administration administration = new Administration();
            while (true)
            {
                administration.displayMenu();
            }
        }
    }
}
