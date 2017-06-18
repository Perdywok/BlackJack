using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BlackJack
{
    class CardDeck
    {
        public List<Card> Deck = new List<Card>(52);
      /*  internal List<Card> Deck
        {
            get { return new List<Card>(MagicNumbers.numberOfCard); }
            private set { Deck = value; }
        } */
        public CardDeck()
        {
            CreateDeck();
            ShuffleDeck();
        }
        private void CreateDeck()
        {
            for (int i = 0; i < MagicNumbers.numberOfRank; i++)
            {
                for (int j = 0; j < MagicNumbers.numberOfSuit; j++)
                {
                    Deck.Add(new Card(i, j));
                }
            }
        }
        private void ShuffleDeck()
        {
            Random rand = new Random();
            for (int i = 0; i < MagicNumbers.numberOfCard; i++)
            {
                Card tmp = Deck[i];
                Deck.RemoveAt(i);
                Deck.Insert(rand.Next(0, Deck.Count), tmp);
            }
        }
        public List<Card> GetStartHand()
        {
            List<Card> tmp = new List<Card>();
            tmp.Add(Deck.Last());
            Deck.RemoveAt(Deck.Count - 1);
            tmp.Add(Deck.Last());
            Deck.RemoveAt(Deck.Count - 2);
            return tmp;
        }
        public Card GetCard()
        {
            Card tmp = Deck.Last();
            Deck.RemoveAt(Deck.Count - 1);
            return tmp;
        }
        public void Reset()
        {
            CardDeck temp = new CardDeck();
            Deck = temp.Deck;
        }
    }
}
