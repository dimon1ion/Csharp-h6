using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_hw6
{
    class Karta
    {
        public Karta()
        {

        }
        public string Name(int num)
        {
            switch (num)
            {
                case 16:
                case 17:
                case 18:
                case 19:
                    return $"Hearts {num - 10}";
                case 110:
                    return $"Hearts {num - 100}";
                case 111:
                    return "Hearts Jack";
                case 112:
                    return "Hearts Queen";
                case 113:
                    return "Hearts King";
                case 114:
                    return "Hearts Ace";
                case 26:
                case 27:
                case 28:
                case 29:
                    return $"Spades {num - 20}";
                case 210:
                    return $"Spades {num - 200}";
                case 211:
                    return "Spades  Jack";
                case 212:
                    return "Spades  Queen";
                case 213:
                    return "Spades  King";
                case 214:
                    return "Spades  Ace";
                case 36:
                case 37:
                case 38:
                case 39:
                    return $"Diamonds {num - 30}";
                case 310:
                    return $"Diamonds {num - 300}";
                case 311:
                    return "Diamonds  Jack";
                case 312:
                    return "Diamonds  Queen";
                case 313:
                    return "Diamonds  King";
                case 314:
                    return "Diamonds  Ace";
                case 46:
                case 47:
                case 48:
                case 49:
                    return $"Clubs {num - 40}";
                case 410:
                    return $"Clubs {num - 400}";
                case 411:
                    return "Clubs  Jack";
                case 412:
                    return "Clubs  Queen";
                case 413:
                    return "Clubs  King";
                case 414:
                    return "Clubs  Ace";
                default:
                    return "";
            }
        }
    }
    class Player
    {
        public List<int> CardsPlayer { get; set; }
        public Player()
        {
            CardsPlayer = new List<int>();
        }
        public bool CheckCards()
        {
            if (CardsPlayer.Count == 36)
            {
                return true;
            }
            return false;
        }
    }
    public delegate bool Del();
    class Game
    {
        private List<int> allCards;
        public List<Player> players = new List<Player>();
        private bool play = false;
        public List<int> table = new List<int>();
        private Karta karta = new Karta();
        Random random = new Random();
        public Del end = null;
        public Game(int playersNum)
        {
            for (int i = 0; i < playersNum; i++)
            {
                players.Add(new Player());
            }
            allCards = new List<int> { 16, 26, 36, 46, 17, 27, 37, 47, 18, 28, 38, 48, 19, 29, 39, 49, 110, 210, 310, 410, 111, 211, 311, 411, 112, 212, 312, 412, 113, 213, 313, 413, 114, 214, 314, 414 };
        }
        public void AddPlayer()
        {
            if (!play)
            {
                players.Add(new Player());
            }
        }
        public void RemovePlayer()
        {
            if (!play)
            {
                players.RemoveAt(players.Count - 1);
            }
        }
        public void StartGame()
        {
            if (players.Count > 0 && 36 % players.Count == 0 && !play)
            {
                Console.WriteLine("Shuffling and dealing cards..");
                play = true;
                int cardsForPlayers = 36 / players.Count;
                int numOfCard;
                foreach (Player player in players)
                {
                    for (int i = 0; i < cardsForPlayers; i++)
                    {
                        numOfCard = allCards.ToArray()[random.Next(0, allCards.Count - 1)];
                        player.CardsPlayer.Add(numOfCard);
                        allCards.Remove(numOfCard);
                    }
                    end += player.CheckCards;
                    Thread.Sleep(500);
                }
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Error, there are not enough players, or the cards cannot be divided equally..");
            }
        }
        public void Move()
        {
            if (play)
            {
                int i = 1;
                int numOfCard;
                foreach (var player in players)
                {
                    if (player.CardsPlayer.Count > 0)
                    {
                        numOfCard = player.CardsPlayer.ToArray()[random.Next(0, player.CardsPlayer.Count - 1)];
                        table.Add(numOfCard);
                        player.CardsPlayer.Remove(numOfCard);
                        Console.WriteLine($"Player {i} put {karta.Name(numOfCard)}");
                    }
                    else
                    {
                        Console.WriteLine($"Player {i} skipped");
                        table.Add(0);
                    }
                    i++;
                }
                int index = -1;
                int index1 = 0;
                int max = 0;
                int tmp;
                foreach (var item in table)
                {
                    index++;
                    if (item > 100) { tmp = item % 100; }
                    else { tmp = item % 10; }
                    if (max < tmp)
                    {
                        max = tmp;
                        index1 = index;
                    }
                }
                int find = 0;
                foreach (var player in players)
                {
                    if (find == index1)
                    {
                        foreach (var card in table)
                        {
                            if (card != 0)
                            {
                                player.CardsPlayer.Add(card);
                            }
                        }
                        table.RemoveRange(0, table.Count);
                        break;
                    }
                    find++;
                }
                //Thread.Sleep(1000);
            }
        }
    }
}
