using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_hw6
{
    public delegate void CarDelegate();
    public delegate void EventDelegate(object c, int distance);
    class Finish
    {
        public event EventDelegate finish;
        public void CheckFinish(Car c, int d)
        {
            if (finish != null)
            {
                finish(c, d);
            }
        }
    }
    class Program
    {
        public static void CheckFinish(object c, int distance)
        {
            if ((c as Car).CorrentDistance * 100 / distance >= 100)
            {
                Console.WriteLine(((Car)c).Name + " finished!");
                ((Car)c).Winner = true;
            }
        }
        static void Main(string[] args)
        {
            #region Race

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter distance: ");
            int distance = int.Parse(Console.ReadLine());
            Console.Clear();
            List<Car> cars = new List<Car> { new SportCar(), new SimpleCar(), new Truck(), new Bus() };
            Finish finish = new Finish();
            finish.finish += CheckFinish;
            CarDelegate start = null;
            CarDelegate drive = null;
            int NameLength = 0;
            foreach (var item in cars)
            {
                start += item.ReadyToStart;
                drive += item.Drive;
                if (item.Name.Length > NameLength)
                {
                    NameLength = item.Name.Length;
                }
            }
            start.Invoke();
            Console.WriteLine();
            Console.WriteLine("Enter to start..");
            Console.ReadKey();
            Console.Clear();
            bool play = true;
            while (play)
            {
                foreach (var item in cars)
                {
                    item.Drive();
                    Console.Write($"{item.Name}");
                    Console.SetCursorPosition(NameLength + 5, Console.CursorTop);
                    Console.WriteLine($"{item.CorrentDistance * 100 / distance}%\tSpeed:{item.CorrentSpeed}m/s   ");
                }
                Thread.Sleep(1000);
                Console.WriteLine();
                Console.SetCursorPosition(0, 0);
                foreach (var item in cars)
                {
                    finish.CheckFinish(item, distance);
                    if (item.Winner)
                    {
                        play = false;
                    }
                }
            }

            #endregion

            Thread.Sleep(2000);
            Console.Clear();

            #region Card game

            Game game = new Game(4);
            game.StartGame();
            int player = 0;
            bool playGame = true;
            while (playGame)
            {
                player = 1;
                game.Move();
                Console.WriteLine();
                foreach (Del item in game.end.GetInvocationList())
                {
                    if (item())
                    {
                        playGame = false;
                        break;
                    }
                    player++;
                }
                Console.Clear();
            }
            Console.WriteLine();
            Console.WriteLine($"Player {player} is Winner!");

            #endregion

        }
    }
}
