using System;
using System.Collections.Generic;
using System.Linq;

namespace TopPlayersOfTheServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();

            server.Work();

            Console.ReadLine();
        }
    }

    class Server
    {
        private static IEnumerable<Player> _players = new List<Player>();

        public Server()
        {
            _players = new List<Player>
            {
                new Player("Безумный_автобус", 80, 1100),
                new Player("SkyDeaD", 76, 900),
                new Player("W1zarD", 78, 990),
                new Player("Канеки кен", 65, 1000),
                new Player("CaMyPau", 62, 890),
                new Player("4eJIoBeK", 56, 800),
                new Player("Shizy", 53, 790),
                new Player("АОАОАООАОА", 49, 660),
                new Player("ひと、人", 48, 700),
                new Player("Kuki", 45, 500)
            };
        }

        public void Work()
        {
            int topPLayers = 3;
            Console.WriteLine("Все игроки: ");
            Show(_players);

            Console.WriteLine("________");
            Console.WriteLine("Топ по силе: ");
            Show(GetTopStrengthPlayer(_players, topPLayers));

            Console.WriteLine("________");
            Console.WriteLine("Топ по уровню:");
            Show(GetTopLevelPlayers(_players, topPLayers));
        }

        private static IEnumerable<Player> GetTopStrengthPlayer(IEnumerable<Player> player, int topPLayers) =>
            player.OrderByDescending(players => players.Power).Take(topPLayers);

        private static IEnumerable<Player> GetTopLevelPlayers(IEnumerable<Player> player, int topPLayers) =>
            player.OrderByDescending(players => players.Level).Take(topPLayers);

        private void Show(IEnumerable<Player> players)
        {
            if (players.Any())
            {
                foreach (var player in players)
                {
                    player.ShowInfo();
                }
            }
        }
    }
}

class Player
{
    public Player(string nickName, int level, int power)
    {
        NickName = nickName;
        Level = level;
        Power = power;
    }

    public string NickName { get; private set; }
    public int Level { get; private set; }
    public int Power { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine($"{NickName}, {Level}, {Power}");
    }
}
