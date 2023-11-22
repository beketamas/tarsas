using System.Text.RegularExpressions;
namespace OraiErettsegi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Osvenyek> listaOsvenyek = File.ReadAllLines("osvenyek.txt").Select(x => new Osvenyek(x)).ToList();
            List<int> listaDobasok = File.ReadAllText("dobasok.txt").Split().Select(x => Convert.ToInt32(x)).ToList();

            Console.WriteLine("2. feladat:");
            Console.WriteLine($"Dobások száma: {listaDobasok.Count}\nAz ösvények száma: {listaOsvenyek.Count}");
            var leghosszabb = listaOsvenyek.MaxBy(x => x.Sorok.Length);

            Console.WriteLine($"3. feladat:\n Az egyik leghosszabb ösvény a(z) {listaOsvenyek.FindIndex(x => x.Sorok.Length == leghosszabb?.Sorok.Length)+1}." +
                $"ösvény, hossza: {leghosszabb?.Sorok.Length}");

            Console.WriteLine("4. feladat: ");
            Console.Write("Adja meg egy ösvény sorszámát! ");
            int osvenySorszam = Convert.ToInt32(Console.ReadLine());
            Console.Write("Adja meg a játékosok számát! ");
            int jatekosokSzama = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("5. feladat");
            listaOsvenyek[osvenySorszam-1].Sorok.GroupBy(x => x).ToList().ForEach(x => Console.WriteLine($"{x.Key}: {x.Count()} darab"));

            var fajlbaIras = listaOsvenyek[osvenySorszam - 1].Sorok.Select((x, i) => $"{x}\t{i + 1}").ToList();
            fajlbaIras.RemoveAll(x => x.Contains('M'));
            File.WriteAllLines("kulonleges.txt",fajlbaIras);

        }
    }
}