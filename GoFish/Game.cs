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

        public Game(string text, List<string> list, TextBox textProgress)
        {
            this.text = text;
            this.list = list;
            this.textProgress = textProgress;
        }

        internal bool PlayOneRound(int selectedIndex)
        {
            throw new NotImplementedException();
        }

        internal string DescribeBooks()
        {
            throw new NotImplementedException();
        }

        internal object GetWinnerName()
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<string> GetPlayerCardNames()
        {
            throw new NotImplementedException();
        }

        internal string DescribePlayerHands()
        {
            throw new NotImplementedException();
        }
    }
}
