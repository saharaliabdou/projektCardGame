using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1

{


	public class PlayingCard : IComparable<PlayingCard>, IPlayingCard
	{

		public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }

		#region IComparable Implementation
		//Need only to compare value in the project
		public int CompareTo(PlayingCard card1)
		{
			if (this.Value < card1.Value && this.Color < card1.Color) return 1;
			else if (this.Value > card1.Value && this.Color > card1.Color) return -1;
			else if (this.Value == card1.Value && this.Color == card1.Color) return 0;
			else return 0;




		}
		#endregion
		public PlayingCard()// Egen
		{
			Random rand = new Random();
			Color = (PlayingCardColor)rand.Next(0, 4);
			Value = (PlayingCardValue)rand.Next(2, 15);
		}

		public PlayingCard(PlayingCardColor color, PlayingCardValue value)
		{
			//YOUR CODE
			// write a constructor that generates a random card.
			// I.e., PlayingCard card1 = new PlayingCard(); generates a random card.
			Color = color;
			Value = value;
		}

		#region ToString() related
		string ShortDescription
		{
			//Use switch statment or switch expression
			//https://en.wikipedia.org/wiki/Playing_cards_in_Unicode
			get
			{
				char c = Color switch
				{

					PlayingCardColor.Clubs => '\u2663',
					PlayingCardColor.Diamonds => '\u2666',
					PlayingCardColor.Hearts => '\u2665',
					PlayingCardColor.Spades => '\u2660',
					_ => throw new NotImplementedException(),

					//=> throw new NotImplementedException()






				};



				return $"{c} {Value.ToString()}";

			}
		}

		public override string ToString() => ShortDescription;
		#endregion
	}
}
