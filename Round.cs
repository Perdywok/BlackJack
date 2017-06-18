using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Round
    {
        internal Game Game { get; private set; }
        internal string Winner { get; private set; }
        public Round(Game game)
        {
            Game = game;
        }
        public void PrepareToGame()
        {
            Game.Dealer.ResetHand();
            Game.Player.ResetHand();
            Game.GameDeck.Reset();
            Game.Player.TakeStartHand(Game.GameDeck.GetStartHand());
            Game.Dealer.TakeStartHand(Game.GameDeck.GetStartHand());
            Game.Player.CalculateYourPoints();
            Game.Dealer.CalculateYourPoints();
        }
        public void IncreasePlayerWins()
        {
            Game.Player.IncreaseWins();
            Winner = Game.Player.Name;
        }
        public void IncreaseDealerWins()
        {
            Game.Dealer.IncreaseWins();
            Winner = Game.Dealer.Name;
        }
        public bool AddCardToPlayer()
        {
            Game.Player.TakeCard(Game.GameDeck.GetCard());
            if (Game.Player.Points > 21)
            {
                return false;
            }
            return true;
        }
        public bool AddCardToDealer()
        {
            Game.Dealer.TakeCard(Game.GameDeck.GetCard());
            if (Game.Dealer.Points > 21)
                return false;
            return true;
        }
        public void SelectWinner()
        {
            if (Game.Player.Points > Game.Dealer.Points)
                Winner = Game.Player.Name;
            else if (Game.Player.Points < Game.Dealer.Points)
                Winner = Game.Dealer.Name;
            else if (Game.Player.Points == Game.Dealer.Points)
                Winner = Game.Dealer.Name + " and " + Game.Player.Name;
        }
    }
}
