//Marek Šollar P2B

//Naplní list náhodnými hodnotami
static int[] naplnNahodne(int pocet, int odkud, int kam)
{
    int[] pole = new int[pocet];
    Random rnd = new Random();
    for ( int i = 0; i < pocet; i++ )
    { 
        pole[i] =(int)rnd.NextInt64(odkud, kam); 
    }
    return pole;
}

//Vypíše pole do konzole
static void vypisPole(int[] pole)
{
    Array.Sort(pole);
    foreach ( var i in pole )
    {
        Console.Write(i + ", ");
    }
    Console.WriteLine();
}

//Vypíše nejvyšší hodnotu v poli
int maximum(int[] pole_vstup)
{
    int max = pole_vstup[0];
    foreach (int cislo in pole_vstup)
    {
        if (max < cislo)
        {
            max = cislo;
        }
    }
    return max;
}

//Vypíše nejnižší hodnotu v poli
int minimum(int[] pole_vstup)
{
    int min = pole_vstup[0];
    foreach (int cislo in pole_vstup)
    {
        if (min > cislo)
        {
            min = cislo;
        }
    }
    return min;
}

//Vypíše aritmetický průmer
static double aritmetickyPrumer(int[] pole_vstup)
{
    int soucetPrvku = 0;
    foreach (int cislo in pole_vstup)
    {
        soucetPrvku = soucetPrvku + cislo;
    }
    return (double)soucetPrvku / (pole_vstup.Length);
}

//Vypíše aritmetický průmer
static double geometrickyPrumer(int[] pole_vstup)
{
    double soucinPrvku = 1;
    foreach (int cislo in pole_vstup)
    {
        soucinPrvku = soucinPrvku * cislo;
    }
    //Console.WriteLine(soucinPrvku);
    return Math.Pow(soucinPrvku, (double)1/pole_vstup.Length);
}

static double modus(int[] pole_vstup)
{
    Array.Sort(pole_vstup);

    int aktualniPrvek = pole_vstup[0];
    int pocetVyskytu = 1;
    int nejcastejsiPrvek = pole_vstup[0];
    int maxPocetVyskytu = 1;

    for (int i = 1; i < pole_vstup.Length; i++)
    {
        if (pole_vstup[i] == aktualniPrvek)
        {
            pocetVyskytu++;
        }
        else
        {
            if (pocetVyskytu > maxPocetVyskytu)
            {
                maxPocetVyskytu = pocetVyskytu;
                nejcastejsiPrvek = aktualniPrvek;
            }
            aktualniPrvek = pole_vstup[i];
            pocetVyskytu = 1;
        }
    }

    if (pocetVyskytu > maxPocetVyskytu)
    {
        nejcastejsiPrvek = aktualniPrvek;
    }

    return nejcastejsiPrvek;
}

static double median(int[] pole_vstup)
{
    Array.Sort(pole_vstup);
    int stred = pole_vstup.Length / 2;
    //pokud je lichý
    if (pole_vstup.Length % 2 == 1)
    {
        return pole_vstup[stred];
    }
    else
    {
        return (pole_vstup[stred - 1] + pole_vstup[stred]) / 2.0;
    }
}

static void odchylka(int[] pole_vstup)
{
    double aritPrumer = aritmetickyPrumer(pole_vstup);
    foreach (int cislo in pole_vstup)
    {
        Console.WriteLine("Odchylka: " + cislo + " = " + (cislo - aritPrumer));
    }
}

static double rozptyl(int[] pole_vstup)
{
    double prumer = aritmetickyPrumer(pole_vstup);
    double vysledek = 0;
    foreach (int cislo in pole_vstup)
    {
        vysledek = vysledek + ((cislo - prumer) * (cislo - prumer));
    }
    return vysledek / pole_vstup.Length;
}

static double smerodatnaOdchylka(int[] pole_vstup)
{
    return Math.Sqrt(rozptyl(pole_vstup));
}



//Použije podprogram a naplní ho
int[] pole = naplnNahodne(10, 0, 100);

//Vypíše pole na obrazovku
vypisPole(pole);

//1. Maximum 
Console.WriteLine("Maximum: " + maximum(pole));

//2. Minimum
Console.WriteLine("Minimum: " + minimum(pole));

//3. Aritmetický průměr
Console.WriteLine("Aritmetický průměr: " + aritmetickyPrumer(pole));

//4. Geometrický průměr
Console.WriteLine("Geometrický průměr: " + geometrickyPrumer(pole));

//5. Medián
Console.WriteLine("Medián: " + median(pole));

//6. Modus - DODĚLAT
Console.WriteLine("Modus: " + modus(pole));

//7. Odchylka
Console.WriteLine("Odchylka: ");
odchylka(pole);

//8. Rozptyl
Console.WriteLine("Rozptyl: " + rozptyl(pole));

//9. Směrodatná odchylka
Console.WriteLine("Směrodatná odchylka: " + smerodatnaOdchylka(pole));
