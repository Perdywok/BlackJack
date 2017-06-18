using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    struct Card
    {
        internal int Rank { get; private set; }
        internal int Suit{ get; private set; }
        internal int Id { get; private set; }
        public Card(int rank, int suit)
        {
            Rank = rank;
            Suit = suit;
            Id = rank * MagicNumbers.numberOfSuit + (++suit);
        }
    }
}
