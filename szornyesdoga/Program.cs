namespace szornyesdoga
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Szornyelemzo szornyelemzo = new Szornyelemzo(new SzornyAdatbazis().Feltolt());

            Console.WriteLine($"Az összes szörny száma: {szornyelemzo.OsszesSzornySzama()}");
            Console.WriteLine();
            Console.Write("Veszélyes szörnyek: ");
            foreach(var szorny in szornyelemzo.VeszelyesSzornyekNevei())
            {
                Console.Write($"{szorny}, ");
            }
            Console.WriteLine("\n");
            Console.Write("Egyedi élőhelyek: ");
            foreach (var szorny in szornyelemzo.EgyediElohelyek())
            {
                Console.Write($"{szorny}, ");
            }
            Console.WriteLine("\n");
            Console.WriteLine($"Átlagos veszélyességi szint: {szornyelemzo.AtlagosVeszelyesseg()}");
            Console.WriteLine();
            Console.Write("Legveszélyesebb szörnyek: ");
            foreach (var szorny in szornyelemzo.LegveszelyesebbSzornyek())
            {
                Console.Write($"{szorny.Nev}, ");
            }
            Console.WriteLine("\n");
            Console.Write("Fekete Mocsárban élő veszélyes szörnyek: ");
            foreach (var szorny in szornyelemzo.MocsariVeszelyesSzornyek())
            {
                Console.Write($"{szorny.Nev}({szorny.VeszelyessegiSzint}), ");
            }
            Console.WriteLine("\n");
            Console.WriteLine(szornyelemzo.VenExtremTuzGyengeSzorny() ? "Van extrém tűzgyenge szörny." : "Nincs extrém tűzgyenge szörny.");
            Console.WriteLine();
            Console.Write("Szörnyek száma élőhelyenként: ");
            foreach (var szorny in szornyelemzo.SzornyekSzamaElohelyenkent())
            {
                Console.Write($"{szorny}, ");
            }
            Console.WriteLine("");
        }
    }
}
