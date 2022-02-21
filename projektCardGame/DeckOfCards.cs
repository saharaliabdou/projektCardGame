using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class DeckOfCards //: IDeckOfCards
    {
        #region cards List related
        protected const int MaxNrOfCards = 52;
        public List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);
        //public PlayingCard[] cards = new PlayingCard[MaxNrOfCards];

        public PlayingCard this[int idx] => cards[idx];
        public int Count => cards.Count;
        //public int Count
        //{

        //    get
        //   {
        //        int count = 0;
        //        for (int i = 0; i < cards.Length; i++)
        //        {

        //           if (cards[i] != null)
        //            {
        //               count++;
        //            }
        //        }


        //        return count;
        //    }
        //}
        #endregion

        #region ToString() related
        public override string ToString()
        { //Spacer for the string
            int spacer = 0;
            //// the returning string
            string sRet = "";

            ////Go through the deck
            for (int i = 0; i < Count; i++)
            {
                //If the card is not null
                if (cards[i] != null)
                {
                    //Add the card to the string that is going to be returned
                    sRet += String.Format("{0,-10}", cards[i].ToString());
                    spacer++;

                    // if spacer is 13 insert /n to the string
                    if (spacer == 13)
                    {
                        sRet += "\n";
                        //Reset spacer
                        spacer = 0;

                    }


                }

            }

            return sRet;



            //string sRet = "";
            //for (int i = 0; i < cards.Count; i++)
            //{
            //    sRet += $"{cards[i]}";
            //    if ((i + 1) % 13 == 0)
            //    {
            //        sRet = sRet + "\n";
            //    }
            //}
            //return sRet;
        }
        #endregion
        /// <summary>
        /// /Shuffles the deck of the cards
        /// </summary>
        #region Shuffle and Sorting
        public void Shuffle()
        {
            var rnd = new Random(); //rnd is now a random generator
            int card1;
            int card2;
            PlayingCard card;
            for (int i = 0; i < 1000; i++)
            {
                card1 = rnd.Next(0, 52);
                card2 = rnd.Next(0, 52);
                card = cards[card1];
                cards[card1] = cards[card2];
                cards[card2] = card;


            }
        }
        public void Sort()
        {
            //cards.Sort();
            cards.Sort((x, y) => x.Value.CompareTo(y.Value));
        }
        #endregion

        #region Creating a fresh Deck
        public virtual void Clear()
        {
            CreateFreshDeck();
        }
        public void CreateFreshDeck()
        {
            //int cardNr = 0;

            //Code to initiliaze fresh deck of cards

            //for (int i = 0; i < 4; i++) 
            //{
            //    for (int j = 2; j < 15; j++) 
            //    {
            //        cards[cardNr] = new PlayingCard((PlayingCardColor)i,(PlayingCardValue)j);
            //        cardNr++;
            //    }
            //}

            for (PlayingCardColor color = PlayingCardColor.Clubs; color <= PlayingCardColor.Spades; color++)

            {

                for (PlayingCardValue value = PlayingCardValue.Two; value <= PlayingCardValue.Ace; value++)

                {

                    cards.Add(new PlayingCard(color, value));

                }

            }

        }



        #endregion

        #region Dealing
        public PlayingCard RemoveTopCard() //returns the top of the deck and reduces the nr of cards in the deck
        {

            PlayingCard temp1 = cards[^1];
            cards = cards.Take(cards.Count() - 1).ToList();
            return temp1;



        }

        #endregion
    }
}

