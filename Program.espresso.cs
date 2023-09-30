using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Espressor
{
    class Espressor
    {
       
        static void Main(string[] args)
        {
            int volumApa = 0;
            int espressoShot = 30;
            int apaAmericano = 60;
            bool continua = true;
            bool senzorCana = false;
            bool senzorApa = false;
            bool americanoMade = false;
            bool cappuccinoMade = false;
            bool latteMade = false;
            Boiler boiler = new Boiler();
            Start start = new Start();
            Americano Americano = new Americano();
            Cappuccino cappuccino = new Cappuccino();
            Latte latte = new Latte();
            


            while (continua)
            {
                Console.WriteLine("------------------ESPRESSOR---------------------");
                Console.WriteLine("\n");
                Console.WriteLine("              1. Adaugati cana");
                Console.WriteLine("              2. Adaugati apa");
                Console.WriteLine("              3. Afisati Meniu");
                Console.WriteLine("              4. Scoateti cana");
                Console.WriteLine("              5. Opriti espressorul");
                Console.WriteLine("\n");

                int optiune = Convert.ToInt32(Console.ReadLine());

                switch(optiune)
                {
                    case 1:
                        
                        Console.WriteLine("Cana a fost introdusa in espressor");
                        senzorCana = true; 
                        break;
                    case 2:

                        if (!senzorCana)
                        {
                            Console.WriteLine("Nu ati introdus cana. Va rog introduceti cana");
                        }
                        else if (senzorCana)
                        {
                            Console.WriteLine("Capacitatea boilerului este de 300ml");
                            boiler.adaugaApa( ref volumApa );
                            senzorApa = true;

                        }                        
                        break;
                    case 3:
                        bool continua1 = true;
                        Console.WriteLine("Alegeti bautura dorita");

                        while (continua1)
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("                   |1| ~Americano~");
                            Console.WriteLine("                   |2| ~Cappucciono~");
                            Console.WriteLine("                   |3| ~Latte~");
                            Console.WriteLine("\n");

                            int optiune1 = Convert.ToInt32(Console.ReadLine());

                            switch (optiune1)
                            {
                                case 1:
                                    if (!senzorApa)
                                    {
                                        Console.WriteLine("Nu ati introdus apa, va rog introduceti apa");
                                    }
                                    else if (senzorApa && volumApa >= espressoShot)
                                    {

                                        start.ResetVariables();
                                        start.bec();
                                        while (Start.temperatura < Start.temperaturaMaxima)
                                        {
                                            start.heater();
                                        }
                                        
                                        Americano.mixAmericano(ref apaAmericano, ref espressoShot, ref volumApa);
                                        Americano.bec2();
                                        americanoMade = true;
                                        continua1 = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Nu este sufucienta apa. Introduceti mai multa apa");
                                        continua1 = false;
                                    }
                                    break;
                                case 2:
                                    if (!senzorApa)
                                    {
                                        Console.WriteLine("Nu ati introdus apa, va rog introduceti apa");
                                    }
                                    else if (senzorApa && volumApa >= espressoShot)
                                    {
                                        boiler.adaugaLapte();
                                        start.ResetVariables();
                                        start.ResetVariables2();
                                        start.bec();
                                        while(Start.temperatura < Start.temperaturaMaxima)
                                        {
                                            start.heater();
                                            
                                        }
                                        while(Start.temperatura2 < Start.temperaturaMaxima2)
                                        {
                                            start.heaterLapte();
                                        }
                                        cappuccino.mixCappuccino(ref espressoShot, ref volumApa);
                                        cappuccino.bec2();
                                        cappuccinoMade = true;
                                        continua1 = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Nu este sufucienta apa. Introduceti mai multa apa");
                                        continua1 = false;
                                    }
                                    break;
                                case 3:
                                    if (!senzorApa)
                                    {
                                        Console.WriteLine("Nu ati introdus apa, va rog introduceti apa");
                                    }
                                    else if (senzorApa && volumApa >= espressoShot)
                                    {
                                        boiler.adaugaLapte();
                                        latte.adaugaSirop();
                                        start.ResetVariables();
                                        start.ResetVariables2();
                                        start.bec();
                                        while(Start.temperatura < Start.temperaturaMaxima)
                                        {
                                            start.heater();
                                        }
                                        while(Start.temperatura2 < Start.temperaturaMaxima2)
                                        {
                                            start.heaterLapte();
                                        }
                                        latte.mixLatte( ref espressoShot, ref volumApa);
                                        latte.bec2();
                                        latteMade = true;
                                        continua1 = false;

                                    }
                                    else
                                    {
                                        Console.WriteLine("Nu este sufucienta apa. Introduceti mai multa apa");
                                        continua1 = false;
                                    }
                                    break;
                            }
                           
                        }
                        break;                        
                    case 4:
                        if(americanoMade || cappuccinoMade || latteMade ) 
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Ati scsos cana din Espressor.");
                            Console.WriteLine("\n");
                            Console.WriteLine("~~Enjoy your cofee!~~");
                            Console.WriteLine("\n");

                            senzorCana = false;
                        }
                        else
                        {
                            Console.WriteLine("Nu ati selectat cafeaua dorita");
                        }
                       

                        break;
                    case 5:
                        continua = false;
                        break;
                }
                Console.WriteLine("Volumul apei este acum : " + volumApa);
                Console.WriteLine("\n");
            }

        }

        class Boiler
        {
            int capacitate = 300;
            public void adaugaApa( ref int volumApa )
            {
                Console.WriteLine("\n");
                Console.WriteLine("Cata ml de apa doriti sa introduceti?");
                volumApa = Convert.ToInt32(Console.ReadLine()) + volumApa;
                if(volumApa > capacitate)
                {
                    Console.WriteLine("Acest volum depaseste capacitatea posibila a boilerului");

                }
                else if (volumApa <= 250 && volumApa > 40)
                {
                    Console.WriteLine("Apa a fost introdusa");
                }
                else if (volumApa < 40)
                {
                    Console.WriteLine("Prea putina apa. Va rog introduceti mai multa apa");
                }
            }

            public void adaugaLapte()
            {

                Console.WriteLine("Introduceti lapte pentru Cappuccino sau Late?");
                bool continua3 = true;

                while (continua3)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("1. 30 ml lapte pentru Cappuccino");
                    Console.WriteLine("2. 50 ml lapte pentru Latte");
                    int optiune3 = Convert.ToInt32(Console.ReadLine());

                    switch(optiune3)
                    {
                        case 1:
                            Console.WriteLine("\n");
                            Console.WriteLine("Ati introdus 30 ml lapte");
                            continua3 = false;
                            break;
                        case 2:
                            Console.WriteLine("\n");
                            Console.WriteLine("Ati introdus 50 ml lapte");
                            continua3 = false;
                            break;

                    }

                }
            }

          
        }

        class Start
        {

            public static int temperatura = 0;
            public static int temperaturaMaxima = 10;
            public static int temperatura2 = 0;
            public static int temperaturaMaxima2 = 10;
            public static TimeSpan timeLimit = TimeSpan.FromSeconds(10);
            public void bec()
            {
                Console.WriteLine("\n");
                Console.WriteLine("Ati pornit espressorul, beculetul este acum:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Rosu");
                Console.ResetColor();
            }

            public void heater()
            {
                temperatura++;
                if ( temperatura == temperaturaMaxima)
                {
                    Console.WriteLine("Apa a atins 100 de grade. Apa a fiert");
                }
                else
                {
                    Console.WriteLine(".");
                    Thread.Sleep(1000);
                }
            }

            public void ResetVariables()
            {
                temperatura = 0;
            }

            public void ResetVariables2()
            {
                temperatura2 = 0;
            }
            public void heaterLapte()
            {
                temperatura2++;
                if ( temperatura2 == temperaturaMaxima2)
                {
                    Console.WriteLine("Laptele a fiert");
                }
                else
                {
                    Console.WriteLine(".");
                    Thread.Sleep(1000);
                }
            }
        }

        abstract class Cafea
        {
            
            public void bec2()
            {
                Console.WriteLine("Bautura este gata, beculetul este acum:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Verde");
                Console.ResetColor();
                Console.WriteLine("\n");
                Console.WriteLine("Va rog scoateti cana");
            }


        }

        
        class Americano : Cafea
        {
            public int americano;
            public int mixAmericano( ref int apaAmericano, ref int espressoShot, ref int volumApa)
            {
                americano = apaAmericano + espressoShot;
                volumApa -= americano;

                return volumApa;
            }
        }

        class Cappuccino : Cafea
        {
           
            public int mixCappuccino(ref int espressoShot, ref int volumApa)
            {
                
                volumApa -= espressoShot;

                return volumApa;
            }
        }

        class Latte : Cafea
        {

            public int mixLatte(ref int espressoShot, ref int volumApa)
            {

                volumApa -= espressoShot;

                return volumApa;
            }

            public void adaugaSirop()
            {
                bool continua4 = true;
                Console.WriteLine("\n");
                Console.WriteLine("De care sirop preferati pentru Latte?");
                Console.WriteLine("\n");

                while (continua4)
                {

                    Console.WriteLine("1. Sirop de vanilie");
                    Console.WriteLine("2. Sirop de caramel");
                    Console.WriteLine("3. Sirop de ciocolata");
                    int optiune4 = Convert.ToInt32(Console.ReadLine());

                    switch (optiune4)
                    {
                        case 1:
                            Console.WriteLine("\n");
                            Console.WriteLine("A fost adaugat sirop de vanilie");
                            continua4 = false;
                            break;
                        case 2:
                            Console.WriteLine("\n");
                            Console.WriteLine("A fost adaugat sirop de caramel. Buna alegere");
                            continua4 = false;
                            break;
                        case 3:
                            Console.WriteLine("\n");
                            Console.WriteLine("A fost adaugat sirop de ciocolata");
                            continua4 = false;
                            break;
                    }
                }
            }
        }



    }
}
