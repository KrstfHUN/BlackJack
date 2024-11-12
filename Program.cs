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
            Random rnd = new Random();

            while (fut)
            {
                if (penz == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Elfogyott a pénzed. Szerezz munkát és gyere vissza pénzel játszani hozzánk!");
                    fut = false;
                }
                Console.WriteLine($"Ennyi pénzed van: {penz}");
                Console.WriteLine("1. Játék\t2. Kilépés");
                int menupont = Convert.ToInt32(Console.ReadLine());

                if (menupont == 1)
                {
                    Console.Clear();
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

                        List<int> dealer = new List<int> { rnd.Next(2, 11), rnd.Next(2, 11) };
                        List<int> jatekos = new List<int> { rnd.Next(2, 11), rnd.Next(2, 11) };

                        bool tovabb = true;
                        while (tovabb)
                        {
                            int osszegecske = jatekos.Sum();
                            int dealerosszeg = dealer.Sum();

                            Console.Clear();
                            Console.WriteLine($"Lapjaid összege: {osszegecske}");
                            Console.WriteLine($"Dealer lapjainak összege: {dealer[0]} + X");

                            if (osszegecske == 21)
                            {
                                Console.WriteLine("BLACKJACK! Nyertél!");
                                penz += 2 * tet;
                                tovabb = false;
                                break;
                            }

                            Console.WriteLine("Hit or stand (1 vagy 2): ");
                            int hitstand = Convert.ToInt32(Console.ReadLine());

                            if (hitstand == 1)
                            {
                                jatekos.Add(rnd.Next(2, 11));
                                osszegecske = jatekos.Sum();

                                if (osszegecske > 21)
                                {
                                    Console.WriteLine("Bust! A dealer nyert!");
                                    tovabb = false;
                                }
                            }
                            else if (hitstand == 2)
                            {
                                while (dealerosszeg < 17)
                                {
                                    dealer.Add(rnd.Next(2, 11));
                                    dealerosszeg = dealer.Sum();
                                }

                                Console.WriteLine($"Dealer lapjainak összege: {dealerosszeg}");

                                if (dealerosszeg > 21 || osszegecske > dealerosszeg)
                                {
                                    Console.WriteLine("Nyertél!");
                                    penz += 2 * tet;
                                }
                                else if (dealerosszeg > osszegecske)
                                {
                                    Console.WriteLine("A dealer nyert!");
                                }
                                else
                                {
                                    Console.WriteLine("Döntetlen!");
                                    penz += tet;
                                }

                                tovabb = false;
                            }
                        }
                    }
                }
                else if (menupont == 2)
                {
                    fut = false;
                    Console.WriteLine("Kiléptél a játékból.");
                }
            }

            return penz;
        }
    }
}
