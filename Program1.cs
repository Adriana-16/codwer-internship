
/*1) Scrie un program care:
   a) citește de la tastatura un număr cu minim de 3 cifre dacă numărul are mai puțin de 3 cifre, îi spune utilizatorului acest lucru și îi cere alt număr
   b) dacă numărul este corect, calculeaza valoarea in oglinda (ex 441 in oglinda este 144)
   c) verifica și îi spune userului dacă numărul dat în oglinda este pătrat perfect (ex 144 = 12 * 12 - ok)*/

using System;
public class sarcina1
{
    public static void Main()
    {

        string input;
        int number;
        int mirror = 0;

        do
        {
            Console.WriteLine("Introduceti un numar de 3 cifre sau mai mult");
            input = Console.ReadLine();
            number = Convert.ToInt32(input);

            if (number < 100)
            {
                Console.WriteLine("Numarul introdus are mai putin de 3 cifre. Va rugam reintroduceti.");
            }

            else
            {
                Console.WriteLine("Ati introdus: " + number);

                while (number > 0)
                {
                    mirror = mirror * 10 + number % 10;
                    number = number / 10;
                }

                Console.WriteLine("Numarul inversat este: " + mirror);

                break;
            }
        } while (true);
        double sqrt = Math.Sqrt(mirror);
        if (sqrt % 1 == 0)
        {
            Console.WriteLine("Numarul inversat este un patrat perfect");
        }
        else
        {
            Console.WriteLine("Numarul inversat nu este un patrat perfect");
        }
    }
}


