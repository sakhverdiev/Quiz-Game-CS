using System;
using System.Threading;

namespace QuizGame
{
    internal class Program
    {
        static public void Print(int index, int i, string[,] arr, ref int score, bool enter = false)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(arr[i, 0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nScore: {score}\n");
            Console.ForegroundColor = ConsoleColor.White;
            for (int j = 1; j < 4; j++)
            {
                if (j == index)
                {

                    if (enter && (arr[i, index] == arr[i, 4]))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        score += 10;
                    }
                    else if (enter && (arr[i, index] != arr[i, 4]))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (score != 0) score -= 10;
                    }
                    else Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(arr[i, j]);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Shuffle(ref string[,] array)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    int swap = random.Next(1, 4);
                    string temp = array[i, j];
                    array[i, j] = array[i, swap];
                    array[i, swap] = temp;
                }
            }
        }
        static void Main(string[] args)
        {
            string[,] Questions = new string[,] {
                {"Avropa qitesinde nece olke var?","37", "40", "44", "44" },
                {"Braziliyanin paytaxti hansidir?", "Braziliya", "Sao Paulo", "Rio de Janeiro", "Braziliya"},
                {"Ilk Oscar mukafati ne vaxt verilmisdir?", "1931", "1927", "1929", "1929" },
                {"En uzun cay hansidir?", "Missipi", "Amazon", "Nil", "Nil"},
                {"Hansi heyvanin nesli tukenib?", "Pinqvin", "Mamont", "Kergedan", "Mamont" },
                {"SpaceX-in qurucusu kimdir?", "Elon Musk", "Jeff Bezos", "Bill Gates", "Elon Musk" },
                {"Everest zirvesinde su nece derecede qaynayir?", "50C", "120C", "70C", "70C" },
                {"Gunes Sistemindeki en boyuk planet hansidir?", "Yupiter", "Mars", "Neptun", "Yupiter"},
                {"Dunya ehalisinin sayi ne qederdir?", "8.2Mr", "8.1Mr", "8.0Mr", "8.1Mr" },
                {"Yer kuresinde nece materik var?", "6", "5", "7","6"},
            };

            int index = 1, i = 0, score = 0;

            Shuffle(ref Questions);

            while (true)
            {
                if (i == 10)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nYour Score is: {score}");
                    Console.WriteLine("\nClick 'Enter' to Play Again");
                    Thread.Sleep(1000);
                    Console.WriteLine("\nClick 'Esc' to Quit the Game");
                    Console.ForegroundColor = ConsoleColor.White;
                    var info = Console.ReadKey(true);
                    if (info.Key == ConsoleKey.Enter)
                    {
                        i = 0; score = 0;
                        index = 1;
                        Shuffle(ref Questions);
                        continue;
                    }
                    else
                        break;
                }

                Print(index, i, Questions, ref score);

                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (index > 1)
                        index--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (index < 3)
                        index++;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Print(index, i, Questions, ref score, true);
                    Thread.Sleep(1000);
                    i++;
                    index = 1;
                }
            }
        }
    }
}