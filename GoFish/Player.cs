﻿using System;
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
        public int CardCount { get { return cards.Count; } }

        public void TakeCard(Card card) { cards.Add(card); }
        public IEnumerable<string> GetCardNames() { return cards.GetCardNames(); }
        public Card Peek(int cardNumber) { return cards.Peek(cardNumber); }
        public void SortHand() { cards.SortByValue(); }

        public Player(string name, Random random, TextBox textBoxOnForm)
        {
            this.name = name;
            this.random = random;
            this.textBoxOnForm = textBoxOnForm;
            cards = new Deck(new Card[] { });       // create empty deck ?  so why is the compiler complaining that 'cards' is never assigned
            textBoxOnForm.Text += $"{this.name} has joined the game.{Environment.NewLine}";
        }

        public IEnumerable<Values> PullOutBooks()
        {
            List<Values> books = new List<Values>();
            for (int i = 1; i <= 3; i++)
            {
                Values value = (Values)i;
                int howMany = 0;
                for (int card = 0; card < cards.Count; card++)
                {
                    if (cards.Peek(card).Value == value)
                    {
                        {
                            howMany++;
                        }
                    }
                    if (howMany == 4)
                    {
                        books.Add(value);
                        cards.PullOutValues(value);
                    }
                }
            }
            return books;
        }

        public Values GetRandomValue()
        {
            bool foundValue = false;
            int rand;
            do
            {
                rand = random.Next(1, 14);
                foundValue = cards.ContainsValue((Values)rand);
            }
            while (!foundValue);
            return (Values)rand;          
        }

        public Deck DoYouHaveAny(Values value)
        {
            // This is where an opponent asks if I have any cards of a certain value
            // Use Deck.PullOutValues() to pull out the values. Add a line to the TextBox
            // that says, "Joe has 3 sixes"—use the new Card.Plural() static method

            Deck resultingDeck = cards.PullOutValues(value);
            textBoxOnForm.Text += $"{Name} has {resultingDeck.Count} {Card.Plural(value)}{Environment.NewLine}";
            return resultingDeck;
        }

        public void AskForACard(List<Player> players, int myIndex, Deck stock)
        {
            // Here's an overloaded version of AskForACard()—choose a random value
            // from the deck using GetRandomValue() and ask for it using AskForACard()

            Values randomValue = (Values)random.Next(1, 14);
        }

        public void AskForACard(List<Player> players, int myIndex, Deck stock, Values value)
        {
            Deck resultingDeck;
            int numCards;
            textBoxOnForm.Text += $"{Name} asks if anyone has a {value}{Environment.NewLine}";
            foreach (Player player in players)
            {
                resultingDeck = DoYouHaveAny(value);
                numCards = resultingDeck.Count;
                if (numCards == 0)
                {
                    cards.Add(stock.Deal());
                    textBoxOnForm.Text += $"{Name} had to Go Fish{Environment.NewLine}";

                }
                // add the cards to this players?.. how?
                while (numCards > 0)
                {
                    cards.Add(resultingDeck.Deal());
                }
            }
            
            // Ask the other players for a value. First add a line to the TextBox: "Joe asks
            // if anyone has a Queen". Then go through the list of players that was passed in
            // as a parameter and ask each player if he has any of the value (using his
            // DoYouHaveAny() method). He'll pass you a deck of cards—add them to my deck.
            // Keep track of how many cards were added. If there weren't any, you'll need
            // to deal yourself a card from the stock (which was also passed as a parameter),
            // and you'll have to add a line to the TextBox: "Joe had to draw from the stock"
        }
    }
}
