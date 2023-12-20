namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = File.ReadAllLines("melyseg.txt").Select(x => Convert.ToInt32(x)).ToList();
            Console.WriteLine($"1. feladat\r\nA fájl adatainak száma:{lista.Count}");
            Console.WriteLine($"2. feladat\r\nAdjon meg egy távolságértéket!");
            int ertek = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Ezen a helyen a felszín {lista[ertek]} méter mélyen van.");
            Console.WriteLine("3. feladat\r\nAz érintetlen terület aránya: " + $"{Math.Round(Convert.ToDouble(lista.Count(x => x == 0)) / lista.Count*100,2)}");
            List<string> godrok = new List<string>();
            string szoveg = "";
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] != 0)
                    szoveg += lista[i];
                if (lista[i] == 0)
                {
                    godrok.Add(szoveg);
                    szoveg = "";
                }
            }
            File.WriteAllLines("godrok.txt", godrok.Where(x => x != ""));
            Console.WriteLine($"5. feladat\r\nA gödrök száma:{godrok.Where(x => x != "").Count()}");
        }
    }
}