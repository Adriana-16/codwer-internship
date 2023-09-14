/*2) Scrie un program care:
a) citește de la tastatura o lista de numere (pot fi si numere
reale) despărțite prin spațiu și le salvează într-un array
b) parcurge array-ul și le afișează pe cele care nu sunt
întregi
c) cauta si afiseaza cel mai mic numar fara sa folosesti
funcții din .NET (Math.Min)*/

using System;
public class sarcina2
{
    public static void Main()
    {

        double[] arr = new double[10];
        int i;
        double min;

        Console.Write("Introduceti 10 elemente :\n");
        for (i = 0; i < 10; i++)
        {
            arr[i] = Convert.ToDouble(Console.ReadLine());
        }

        Console.Write("\nElementele arrayului sunt: ");
        for (i = 0; i < 10; i++)
        {
            Console.Write("{0}  ", arr[i]);
        }
        Console.Write("\n");

        Console.Write("Numerele fractionale sunt: ");
        for (i = 0; i < 10; i++)
        {
            if (arr[i] % 1 != 0)
            {
                Console.Write("{0}  ", arr[i]);
            }
        }
        min = arr[0];
        for (i = 0; i < 10; i++)
        {
            if (arr[i] < min)
            {

                min = arr[i];

            }

        }
        Console.Write("\nCel mai mic numar este: {0} ", min);
    }
}


