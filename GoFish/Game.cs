using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoFish
{
    class Game
    {
        private string text;
        private List<string> list;
        private TextBox textProgress;
        private List<Player> players;
        private Dictionary<Values, Player> books;
        private Deck stock;
        private TextBox textBoxOnForm;

        public Game(string playerName, IEnumerable<string> opponentNames, TextBox textBoxOnForm)
        {
            Random random = new Random();
            this.textBoxOnForm = textBoxOnForm;
            players = new List<Player>();
            players.Add(new Player(playerName, random, textBoxOnForm));
            foreach (string player in opponentNames)
            {
                players.Add(new Player(player, random, textBoxOnForm));
            }
            books = new Dictionary<Values, Player>();
            stock = new Deck();
            Deal();
            players[0].SortHand();
        }

        private void Deal()
        {
            stock.Shuffle();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < players.Count; j++)
                {
                    players[j].TakeCard(stock.Deal());
                }
            }
        }

        public bool PlayOneRound(int selectedPlayerCard)
        {
            throw new NotImplementedException();
        }

        internal string DescribeBooks()
        {
            throw new NotImplementedException();
        }

        public bool PullOutBooks(Player player)
        {
            throw new NotImplementedException();
        }

        internal object GetWinnerName()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetPlayerCardNames()
        {
            return players[0].GetCardNames();
        }

        internal string DescribePlayerHands()
        {
            string description = "";
            for (int i = 0; i < players.Count; i++) {
                description += $"{players[i].Name} has {players[i].CardCount}";
                if (players[i].CardCount == 1)
                {
                    description += $" card.{Environment.NewLine}";
                }
                else
                {
                    description += $" cards.{Environment.NewLine}";
                }
            }
            description += $"The stock has {stock.Count} cards left.";
            return description;
        }
    }
}
