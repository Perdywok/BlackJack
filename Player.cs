using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Player
    {
        private List<Card> _hand = new List<Card>();
        internal List<Card> Hand
        { get => _hand; }
        internal int CountOfWins { get; private set; }
        internal int Points { get; private set; }

        internal string Name { get ; set; }

        public Player()
        {

        }
        public Player(string name)
        {
            Name = name;
        }
        public void TakeStartHand(List<Card> card)
        {
            _hand.AddRange(card);
        }
        public void TakeCard(Card card)
        {
            _hand.Add(card);
            CalculateYourPoints();
        }
        public void CalculateYourPoints()
        {
            foreach (var item in _hand)
            {
                Points += item.Rank;
            }
        }
        public void IncreaseWins()
        {
            CountOfWins++;
        }
        public void ResetHand()
        {
            List<Card> temp = new List<Card>();
            _hand = temp;
        }


    }
}
