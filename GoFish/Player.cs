using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoFish
{
    class Player
    {
        private string name;
        public string Name { get { return name; } }
        private Random random;
        private Deck cards;
        private TextBox textBoxOnForm;

        public Player()
        {

        }

        public IEnumerable<Values> PullOutBooks()
        {

        }

        public Values GetRandomValue()
        {

        }

        public Deck DoYouHaveAny(Values value)
        {

        }
        
        public void AskForACard(List<Player> players, int myIndex, Deck stock)
        {

        }

        public void AskForACard(List<Player> players, int myIndex, Deck stock, Values value)
        {

        }

        public int CardCount { get { return cards.Count; } }
        public void TakeCard(Card card) { cards.Add(card); }
        public IEnumerable<string> GetCardNames() { return cards.GetCardNames(); }
        public Card Peek(int cardNumber) { return cards.Peek(cardNumber); }
        public void SortHand() { cards.SortByValue(); }
    }
}
