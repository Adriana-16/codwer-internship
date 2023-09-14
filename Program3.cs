/*3) Scrie un program care:
a) citește de la tastatura 3 nume de persoane (ex. George Ion Maria)
b) afișează pe cate o linie ce caracter a apărut în fiecare nume și de cate ori indiferent ca-i cu litera mica sau mare*/

using System;

public class sarcina3
{
    public static void Main()
    {
        int i;
        string[] arr = new string[3];
        Console.WriteLine("Introduceti 3 nume:\n");

        for (i = 0; i < 3; i++)
        {
            arr[i] = Console.ReadLine();

        }

        Console.Write("\nElementele arrayului sunt: ");
        for (i = 0; i < 3; i++)
        {
            Console.Write("{0}  ", arr[i]);
        }
        Console.Write("\n");

        for (i = 0; i < 3; i++)
        {
            char[] array = arr[i].ToCharArray();
            int[] letterCounts = new int[26];

            foreach (char letter in array)
            {
                char lowercaseLetter = char.ToLower(letter);
                int index = lowercaseLetter - 'a';
                letterCounts[index]++;
            }
            Console.WriteLine("Numele \"{0}\" contine urmatoarele litere:", arr[i]);
            for (int k = 0; k < 26; k++)
            {
                char letter = (char)('a' + k);
                if (letterCounts[k] > 0)
                {
                    Console.WriteLine("Litera {0} apare de {1} ori", letter, letterCounts[k]);
                }
            }

            Console.WriteLine();
        }

    }
}

