using System;

namespace ProjectPartB_B1
{
    class Program
    {
        static void Main(string[] args)
        {
            DeckOfCards myDeck = new DeckOfCards();

            myDeck.CreateFreshDeck();
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            myDeck.Sort();
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            myDeck.Shuffle();
            Console.WriteLine(myDeck);

            HandOfCards player1 = new HandOfCards();

            HandOfCards player2 = new HandOfCards();

            //Your code to play the game comes here:



            string playerName = null;
            myDeck.Shuffle();

            int nrRounds = 0;
            bool PlayGame = TryReadNrOfRounds(out nrRounds);
            PlayGame = TryReadNrOfCards(out int NrOfCards);
            if (PlayGame)
            {
                Console.WriteLine($"Hello, lets play a game of highest card with two players");
            }

            int round = 0;
            while (PlayGame && round < nrRounds)
            {
                Console.WriteLine($"\nPlaying round nr {round + 1}");
                Console.WriteLine($"------------------");

                Deal(myDeck, NrOfCards, player1, player2);
                Console.WriteLine($"Gave {NrOfCards} card(s) each to the players from the top of the deck. Deck has now {myDeck.Count} card(s).\n");
                Console.WriteLine($"Player1 hand with {NrOfCards} cards.");
                Console.WriteLine(player1);
                Console.WriteLine($"Lowest card in player 1 hand is {player1.Lowest} and highest card is {player1.Highest}");
                Console.WriteLine();
                Console.WriteLine($"Player2 hand with {NrOfCards} cards.");
                Console.WriteLine(player2);
                Console.WriteLine($"Lowest card in player 2 hand is {player2.Lowest} and highest card is {player2.Highest}");
                Console.WriteLine();
                DetermineWinner(player1, player2);

                Console.WriteLine();



                if (!PlayGame)

                    break;





                round++;

            }

            if (nrRounds > 0)
            {
                Console.WriteLine($"\n Great game!");
            }
        }





        /////// <summary>
        /////// Asking a user to give how many cards should be given to players.
        /////// User enters an integer value between 1 and 5. 
        /////// </summary>
        /////// <param name="NrOfCards">Number of cards given by user</param>
        /////// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfCards(out int NrOfCards)
        {

            NrOfCards = 0;

            string sInput;
            do
            {
                Console.WriteLine("How many cards to deal to each player (1-5 or Q to quit)?");
                sInput = Console.ReadLine();
                if (int.TryParse(sInput, out NrOfCards) && NrOfCards >= 1 && NrOfCards <= 5)
                {
                    return true;
                }
                else if (sInput != "Q" && sInput != "q")
                {
                    Console.WriteLine("Wrong input, please try again.");
                }
            }
            while ((sInput != "Q" && sInput != "q"));
            return false;

        }





        /////// <summary>
        /////// Asking a user to give how many round should be played.
        /////// User enters an integer value between 1 and 5. 
        /////// </summary>
        /////// <param name="NrOfRounds">Number of rounds given by user</param>
        /////// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfRounds(out int NrOfRounds)
        {

            NrOfRounds = 0;
            string sInput;
            do
            {
                Console.WriteLine("How many rounds should we play (1-5 or Q to quit)?");
                sInput = Console.ReadLine();
                if (int.TryParse(sInput, out NrOfRounds) && NrOfRounds >= 1 && NrOfRounds <= 5)
                {
                    return true;
                }
                else if (sInput != "Q" && sInput != "q")
                {
                    Console.WriteLine("Wrong input, please try again.");
                }
            }
            while ((sInput != "Q" && sInput != "q"));
            return false;
        }




        ///// <summary>
        ///// Removes from myDeck one card at the time and gives it to player1 and player2. 
        ///// Repeated until players have recieved nrCardsToPlayer 
        ///// </summary>
        ///// <param name="myDeck">Deck to remove cards from</param>
        ///// <param name="nrCardsToPlayer">Number of cards each player should recieve</param>
        ///// <param name="player1">Player 1</param>
        ///// <param name="player2">Player 2</param>
        private static void Deal(DeckOfCards myDeck, int nrCardsToPlayer, HandOfCards player1, HandOfCards player2)
        {

            for (int i = 0; i < nrCardsToPlayer; i++)// så länge i är större än numberof cards
            {
                player1.Add(myDeck.RemoveTopCard());// fyller på player 1 kortlek

                player2.Add(myDeck.RemoveTopCard());// fyller på player 1 kortlek



            }



        }

        ///// <summary>
        ///// Determines and writes to Console the winner of player1 and player2. 
        //// Player with higest card wins. If both cards have equal value it is a tie.
        ///// </summary>
        ///// <param name="player1">Player 1</param>
        ///// <param name="player2">Player 2</param>
        private static void DetermineWinner(HandOfCards player1, HandOfCards player2)
        {// skriver ut player 1 kort i en loop och player 2.

            {
                var p1 = player1.Highest.Value;
                var p2 = player2.Highest.Value;


                int cmpVal = p1.CompareTo(p2);


                if (cmpVal == 0)
                {
                    Console.WriteLine("It's a tie");

                }
                else if (cmpVal < 0)
                {
                    Console.WriteLine("Player2 has the highest cards");
                }
                else
                {
                    Console.WriteLine("player1 has the highest card");
                }
                player1.Clear();
                player2.Clear();










            }


        }

    }
}
