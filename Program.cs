using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main()
        {
            Player player = new Player();
            Player dealer = new Player("Dealer");
            CardDeck deck = new CardDeck();
            Game game = new Game(player, dealer, deck);
            Round round = new Round(game);
            IO inputoutput = new IO(round);
            inputoutput.InputName();
            inputoutput.StartGame();
            Console.Read();
        }
    }
}
