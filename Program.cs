using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static Animal;

namespace exercitiu2
{
    class Program
    {
        static void Main(string[] args)
        {
            Carnivor lup = new Carnivor(Animal.TipAnimal.Lup, "lup", 60.5m, 75.0m, new Animal.Dimensiune(2m, 0.5m, 1m));
            Ierbivor oaie = new Ierbivor(Animal.TipAnimal.Oaie, "oaie", 30m, 15.0m, new Animal.Dimensiune(1.2m, 0.3m, 0.7m));
            Omnivor urs = new Omnivor(Animal.TipAnimal.Urs, "urs", 80m, 70.0m, new Animal.Dimensiune(1.9m, 0.7m, 2.5m));

            Animal pisica = CreeazaAnimal(TipAnimal.Pisica, "pisica", 3m, new Animal.Dimensiune( 0.3m, 0.1m, 0.2m), 40);
            Animal veverita = CreeazaAnimal(TipAnimal.Veverita, "veverita", 3m, new Animal.Dimensiune(0.2m, 0.1m, 0.1m), 10);
            Animal vaca = CreeazaAnimal(TipAnimal.Vaca, "vaca", 3m, new Animal.Dimensiune(2m, 0.6m, 1.3m), 20);

            Carne sunca = new Carne(9m, 0.04m);
            Planta salata = new Planta(1m, 0.02m);
            decimal distanta = 200;
            int count1 = 0;
            int count2 = 0;
            bool continua = true;

             
                List<Animal> listAnimale = new List<Animal>();

                for (int i = 0; i < 10; i++)
                {
                    Random random = new Random();
                    int TipAnimal = random.Next(0, 6);

                switch ((Animal.TipAnimal)TipAnimal)
                {
                    case Animal.TipAnimal.Lup:
                        listAnimale.Add(lup);
                        break;
                    case Animal.TipAnimal.Oaie:
                        listAnimale.Add(oaie);
                        break;
                    case Animal.TipAnimal.Urs:
                        listAnimale.Add(urs);
                        break;
                    case Animal.TipAnimal.Veverita:
                        listAnimale.Add(veverita);
                        break;
                    case Animal.TipAnimal.Pisica:
                        listAnimale.Add(pisica);
                        break;
                    case Animal.TipAnimal.Vaca:
                        listAnimale.Add(vaca);
                        break;
                }
            }


            while (continua)
            {
                Console.WriteLine("\nMeniu:");
                Console.WriteLine("1. Hraneste lupul");
                Console.WriteLine("2. Hraneste oaia");
                Console.WriteLine("3. Hraneste ursul");
                Console.WriteLine("4. Afiseaza detaliile animalelor");
                Console.WriteLine("5. Genereaza o lista random");
                Console.WriteLine("6. Afiseaza numarul de animale care mananca");
                Console.WriteLine("7. Iesire");

                int optiune = Convert.ToInt32(Console.ReadLine());

                switch (optiune)
                {
                    case 1:
                        Console.WriteLine("Hraneste lupul! Alege hrana:");
                        Console.WriteLine("1. Salata");
                        Console.WriteLine("2. Sunca");
                        int hranaLup = Convert.ToInt32(Console.ReadLine());
                        if (hranaLup == 1)
                        {
                            lup.Mananca(salata);
                            continue;
                        }
                        else if (hranaLup == 2)
                        {
                            Console.WriteLine("Cate bucati de sunca mananca lupul?");

                            int input = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < input; i++)
                            {
                                lup.Mananca(sunca);
                            }
                            double masa = (double)sunca.greutate * input;
                            if (masa >= (1.0 / 8.0) * (double)lup.greutate)
                            {
                                Console.WriteLine("Lupul mananca");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Optiune invalida.");
                        }
                        lup.Alearga(distanta);
                        break;
                    case 2:
                        Console.WriteLine("Hraneste oaia! Alege hrana:");
                        Console.WriteLine("1. Salata");
                        Console.WriteLine("2. Sunca");
                        int hranaOaie = Convert.ToInt32(Console.ReadLine());
                        if (hranaOaie == 1)
                        {
                            Console.WriteLine("Cate bucati de salata mananca oaia?");
                            int input2 = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < input2; i++)
                            {
                                oaie.Mananca(salata);
                            }
                            double masa = (double)salata.greutate * input2;
                            if (masa >= (1.0 / 8.0) * (double)oaie.greutate)
                            {
                                Console.WriteLine("Oaia mananca");
                            }

                        }
                        else if (hranaOaie == 2)
                        {
                            oaie.Mananca(sunca);
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Optiune invalida.");
                        }
                        oaie.Alearga(distanta);
                        break;
                    case 3:
                        Console.WriteLine("Hraneste ursul! Alege hrana:");
                        Console.WriteLine("1. Salata");
                        Console.WriteLine("2. Sunca");
                        int hranaUrs = Convert.ToInt32(Console.ReadLine());
                        if (hranaUrs == 1)
                        {
                            Console.WriteLine("Cate bucati de salata mananca oaia?");
                            int input3 = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < input3; i++)
                            {
                                urs.Mananca(salata);

                            }
                            double masa = (double)salata.greutate * input3;
                            if (masa >= (1.0 / 8.0) * (double)urs.greutate)
                            {
                                Console.WriteLine("Ursul mananca");
                            }
                        }
                        else if (hranaUrs == 2)
                        {
                            Console.WriteLine("Cate bucati de salata mananca oaia?");
                            int input4 = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < input4; i++)
                            {
                                urs.Mananca(sunca);

                            }
                            double masa = (double)sunca.greutate * input4;
                            if (masa >= (1 / 8) * (double)urs.greutate)
                            {
                                Console.WriteLine("Ursul mananca");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Optiune invalida.");
                        }
                        urs.Alearga(distanta);
                        break;
                    case 4:
                        Console.WriteLine("Selectati animalul despre care doriti sa vedeti detaliile:");
                        Console.WriteLine("1.Lup");
                        Console.WriteLine("2.Oaie");
                        Console.WriteLine("3.Urs");

                        int alegere = Convert.ToInt32(Console.ReadLine());
                        if (alegere == 1)
                        {
                            Console.WriteLine(lup);
                        }
                        else if (alegere == 2)
                        {
                            Console.WriteLine(oaie);
                        }
                        else if ( alegere == 3) {
                            Console.WriteLine(urs);
                        }
                        else
                        {
                            Console.WriteLine("Alegere invalida");
                        }
                        break;
                    case 5:
                        foreach (var animal in listAnimale)
                        {
                            Console.WriteLine($"\n{animal}");
                            if (animal is Carnivor)
                            {
                                Console.WriteLine($"{animal.nume} mananca carne.");
                                ((Carnivor)animal).Mananca(sunca);
                                count1++;
                            }
                            else if (animal is Ierbivor)
                            {
                                Console.WriteLine($"{animal.nume} mananca plante.");
                                ((Ierbivor)animal).Mananca(salata);
                                count2++;
                            }
                            else if (animal is Omnivor)
                            {
                                Console.WriteLine($" {animal.nume} mananca carne si plante.");
                                ((Omnivor)animal).Mananca(sunca); 
                                ((Omnivor)animal).Mananca(salata);
                                count1++;
                                count2++;
                            }
                        }
                        break;
                    case 6:
                        Console.WriteLine("Animale care mananca:" + listAnimale.Count);
                        Console.WriteLine("Animale care mananca carne:" + count1);
                        Console.WriteLine("Animale care mananca plante:" +count2);
                        break;
                    case 7:
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }
            }
        }
    }

}


abstract class Mancare
{
    public decimal greutate { get; set; }
    private decimal energie;
    public decimal Energie
    {
        get { return energie; }
        set
        {
            if (value >= 0 && value <= 0.05m)
            {
                energie = value;
            }
            else
            {
                Console.WriteLine("Valoarea trebuie sa fie intre 0 si 0.05");

            }
        }
    }

    protected Mancare(decimal greutate, decimal energie)
    {
        this.greutate = greutate;
        this.energie = energie;
    }
}

class Carne : Mancare
{
    public Carne(decimal greutate, decimal energie) : base(greutate, energie)
    {

    }
}

class Planta : Mancare
{
    public Planta(decimal greutate, decimal energie) : base(greutate, energie)
    {

    }
}
abstract class Animal
{
   public enum TipAnimal
    {
        Lup,
        Urs,
        Oaie,
        Veverita,
        Pisica,
        Vaca
    }

    public TipAnimal tip { get; protected set; }
    public Dimensiune dimensiune { get; protected set; }
    public string nume;
    public decimal greutate { get; protected set; }
    public decimal viteza { get; protected set; }
    public double distanta = 100;
    private static int animalCount = 0;

    public struct Dimensiune
    {
        public decimal lungime { get; }
        public decimal latime { get; }
        public decimal inaltime { get; }

        public Dimensiune(decimal lungime, decimal latime, decimal inaltime)
        {
            this.lungime = lungime;
            this.latime = latime;
            this.inaltime = inaltime;
        }
    }


    public Animal(TipAnimal tip, string nume, decimal greutate, decimal viteza, Dimensiune dimensiune)
    {
        this.tip = tip;
        this.nume = nume;
        this.greutate = greutate;
        this.viteza = viteza;
        this.dimensiune = dimensiune;
        animalCount++;
    }
    public static int AnimalCount
    {
        get { return animalCount; }

    }
    public void numara()
    {
        Console.WriteLine("Numarul de animale este: " + animalCount);
    }

    protected List<Mancare> stomac = new List<Mancare>();

    public abstract bool MancarePotrivita(Mancare mancare);
    public void Mananca(Mancare mancare)
    {
        if (MancarePotrivita(mancare))
        {
            stomac.Add(mancare);
        }
        else
        {
            Console.WriteLine("Acest animal nu accepta acest tip de mancare");
        }

    }
    public static Animal CreeazaAnimal(TipAnimal tip, string nume, decimal greutate, Dimensiune dimensiune, decimal viteza)
    {
        switch (tip)
        {
            case TipAnimal.Lup:
                return new Carnivor(TipAnimal.Lup, nume, greutate, viteza, dimensiune);
            case TipAnimal.Urs:
                return new Omnivor(TipAnimal.Urs, nume, greutate, viteza, dimensiune);
            case TipAnimal.Oaie:
                return new Ierbivor(TipAnimal.Oaie, nume, greutate, viteza, dimensiune);
            case TipAnimal.Pisica:
                return new Omnivor(TipAnimal.Pisica, nume, greutate, viteza, dimensiune);
            case TipAnimal.Veverita:
                return new Ierbivor(TipAnimal.Veverita, nume, greutate, viteza, dimensiune);
            case TipAnimal.Vaca:
                return new Ierbivor(TipAnimal.Vaca, nume, greutate, viteza, dimensiune);
            default:
                throw new ArgumentException("Tip de animal necunoscut.");
        }
    }




}



class Carnivor : Animal
{
    public Carnivor(TipAnimal tip, string nume, decimal greutate, decimal viteza, Dimensiune dimensiune)
    : base(tip, nume, greutate, viteza, dimensiune)
    {

    }

    public override bool MancarePotrivita(Mancare mancare)
    {
        return mancare is Carne;

    }
    public decimal Energie()
    {
        decimal sumaEnergieMancare = 0m;


        foreach (var mancare in stomac)
        {
            sumaEnergieMancare += mancare.Energie;
        }


        decimal nivelEnergie = 0.2m - (1m / 5m) * (sumaEnergieMancare / stomac.Count) + sumaEnergieMancare;
        Console.WriteLine("Nivelul de energie a lupului este: " + nivelEnergie + "%");

        return nivelEnergie;
    }

    public void Alearga(decimal distanta)
    {
        double timp = (double)distanta / ((double)viteza / (double)Energie());
        Console.WriteLine("Lupul va alerga distanta in: " + timp);
    }

    public override string ToString()
    {
        return $"Tip animal: Carnivor\nNume: {nume}\nGreutate: {greutate} kg\nDimensiuni: {dimensiune.lungime} x {dimensiune.latime} x {dimensiune.inaltime}\nViteza: {viteza} m/s";
    }







}

class Ierbivor : Animal
{
    public Ierbivor(TipAnimal tip, string nume, decimal greutate, decimal viteza, Dimensiune dimensiune)
    : base(tip, nume, greutate, viteza, dimensiune)
    {

    }

    public override bool MancarePotrivita(Mancare mancare)
    {
        return mancare is Planta;

    }
    public decimal Energie()
    {
        decimal sumaEnergieMancare = 0m;


        foreach (var mancare in stomac)
        {
            sumaEnergieMancare += mancare.Energie;
        }


        decimal nivelEnergie = 0.5m - (1m / 3m) * (sumaEnergieMancare / stomac.Count) + sumaEnergieMancare;
        Console.WriteLine("Nivelul de energie a oii este: " + nivelEnergie + "%");

        return nivelEnergie;
    }

    public void Alearga(decimal distanta)
    {
        double timp = (double)distanta / ((double)viteza / (double)Energie());
        Console.WriteLine("Oaia va alerga distanta in: " + timp);
    }

    public override string ToString()
    {
        return $"Tip animal: Ierbivor\nNume: {nume}\nGreutate: {greutate} kg\nDimensiuni: {dimensiune.lungime} x {dimensiune.latime} x {dimensiune.inaltime}\nViteza: {viteza} m/s";
    }


}

class Omnivor : Animal
{
    public Omnivor(TipAnimal tip, string nume, decimal greutate, decimal viteza, Dimensiune dimensiune)
    : base(tip, nume, greutate, viteza, dimensiune)
    {

    }

    public override bool MancarePotrivita(Mancare mancare)
    {
        return mancare is Carne || mancare is Planta;

    }
    public decimal Energie()
    {
        decimal sumaEnergieMancare = 0m;

        foreach (var mancare in stomac)
        {
            sumaEnergieMancare += mancare.Energie;
        }

        decimal coeficientGreutate = 1m;

        foreach (var mancare in stomac)
        {
            if (mancare is Planta)
            {
                coeficientGreutate = 1m / 2m;
                break;
            }
        }

        decimal nivelEnergie = 0.35m + coeficientGreutate * greutate * (sumaEnergieMancare / stomac.Count) + sumaEnergieMancare;
        Console.WriteLine("Nivelul de energie al ursului este: " + nivelEnergie + "%");

        return nivelEnergie;
    }

    public void Alearga(decimal distanta)
    {
        double timp = (double)distanta / ((double)viteza / (double)Energie());
        Console.WriteLine("Ursul va alerga distanta in: " + timp);
    }

    public override string ToString()
    {
        return $"Tip animal: Omnivor\nNume: {nume}\nGreutate: {greutate} kg\nDimensiuni: {dimensiune.lungime} x {dimensiune.latime} x {dimensiune.inaltime}\nViteza: {viteza} m/s";
    }

    
     
    

}



