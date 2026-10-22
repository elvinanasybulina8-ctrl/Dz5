using System;
using System.Collections.Generic;
using System.Text;

namespace Tumakov6
{
    public static class Helper
    {
        public static int ReadInt(string prompt)
        {
            bool isValid;
            int result;
            do
            {
                Console.Write(prompt);
                isValid = int.TryParse(Console.ReadLine(), out result);
                if (!isValid)
                    Console.WriteLine("Вы ввели не число");
            }
            while (!isValid);
            return result;
        }

    }
}
