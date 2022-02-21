using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        //public PlayingCard card;

        #region Pick and Add related
        public List<PlayingCard> hand = new List<PlayingCard>();
        public void Add(PlayingCard card)
        {


            hand.Add(card);
            Sort();


        }
        #endregion

        #region Highest Card related
        public PlayingCard Highest
        {
            get
            {

                Sort();
                return hand[^1];

            }
        }
        public PlayingCard Lowest
        {
            get
            {

                Sort();
                return hand[0];

            }
        }
        #endregion

        public override string ToString()
        {

            string sRet = "";
            for (int i = 0; i < hand.Count; i++)
            {
                sRet += $"{hand[i]}";
            }
            return sRet;
        }
        public new void Sort()
        {
            hand.Sort((x, y) => x.Value.CompareTo(y.Value));             //hand.Sort();
        }
        public override void Clear()
        {
            hand.Clear();
        }


    }
}
