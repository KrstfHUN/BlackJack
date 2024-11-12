using System.Formats.Tar;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int kezdo = 1000;
            int osszeg = BlackJack(ref kezdo);

        }

        static int BlackJack(ref int kezdo)
        {
            bool fut = true;
            int penz = kezdo;
            List<int> dealer = new List<int>();
            List<int> jatekos = new List<int>();

            while (fut)
            {
                
                Console.WriteLine($"Ennyi pénzed van: {kezdo}");
                Console.WriteLine("1. Játék\t2. Kilépés");
                int menupont = Convert.ToInt32(Console.ReadLine());

                if (menupont == 1)
                {
                    Console.WriteLine("A téted: ");
                    int tet = Convert.ToInt32(Console.ReadLine());
                    if (tet > penz)
                    {
                        Console.Clear();
                        Console.WriteLine("Nincs ennyi pénzed!");
                    }
                    else
                    {
                        penz -= tet;
                        Console.Clear();
                        Random rnd = new Random();
                        for (int i = 0; i < 2; i++)
                        {
                            dealer.Add(rnd.Next(2,11));
                            jatekos.Add(rnd.Next(2,11));
                        }
                        bool tovabb = true;
                        while (tovabb)
                        {
                            Console.WriteLine("Hit or stand (1 or 2): ");
                            int hitstand = Convert.ToInt32(Console.ReadLine());

                            int osszegecske = jatekos.Sum(x => Convert.ToInt32(x));
                            int dealerosszeg = dealer.Sum(x => Convert.ToInt32(x));
                            
                            if (hitstand == 1)
                            {
                                jatekos.Add(rnd.Next(2, 11));
                                if (osszegecske > 21)
                                {
                                    Console.WriteLine("Bust! Az osztó nyert!");
                                    tovabb = false;
                                }
                            }
                            else if (hitstand == 2)
                            {
                                if (dealerosszeg > 17)
                                {
                                    Console.WriteLine("A dealer megált!");
                                }
                                else
                                {

                                }
                            }

                        }

                    }
                }

            }
            return kezdo;
        }
    }
}
