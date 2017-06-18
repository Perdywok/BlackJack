using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class IO
    {
        internal Round Round { get; private set; }
        internal string Answer { get; set; }
        public IO(Round round)
        {
            Round = round;
        }
        public void ShowPlayerHand()
        {
            int temp = 0;
            string playerHand = "";
            List<string> listOfCard = new List<string>(9);
            foreach (var item in Round.Game.Player.Hand)
            {
                listOfCard.Add("");
                for (int i = 0; i < MagicNumbers.numberOfRank; i++)
                {
                    if (item.Rank == i)
                        listOfCard[temp] += Enum.GetName(typeof(CardRank), i);
                }
                for (int i = 0; i < MagicNumbers.numberOfSuit; i++)
                {
                    if (item.Suit == i)
                        listOfCard[temp] += " " + Enum.GetName(typeof(CardSuit), i) + ",";
                }
            }
            foreach (var item in listOfCard)
            {
                playerHand += item;
            }
            Console.WriteLine("{0} have {1} in hand", Round.Game.Player.Name, playerHand);
        }
        private void ShowDealerHand()
        {
            int temp = 0;
            string dealerHand = "";
            List<string> listOfCard = new List<string>(9);
            foreach (var item in Round.Game.Dealer.Hand)
            {
                listOfCard.Add("");
                for (int i = 0; i < MagicNumbers.numberOfRank; i++)
                {
                    if (item.Rank == i)
                        listOfCard[temp] += Enum.GetName(typeof(CardRank), i);
                }
                for (int i = 0; i < MagicNumbers.numberOfSuit; i++)
                {
                    if (item.Suit == i)
                        listOfCard[temp] += " " + Enum.GetName(typeof(CardSuit), i) + ",";
                }
            }
            foreach (var item in listOfCard)
            {
                dealerHand += item;
            }
            Console.WriteLine("{0} have {1} in hand", Round.Game.Dealer.Name, dealerHand);
        }
        public void ShowHands()
        {
            ShowPlayerHand();
            ShowDealerHand();
        }
        public void InputName()
        {
            Console.WriteLine("Input your name");
            Round.Game.Player.Name = Console.ReadLine();
        }
        private void InputAnswer()
        {
            do
            {
                Console.WriteLine("Do you want take a card?Write 'Yes' or 'No'");
                string input = Console.ReadLine().ToLower();
                if (input == "yes" || input == "no")
                {
                    Answer = input;
                    break;
                }
                else if (input != "yes" || input != "no")
                {
                    Console.WriteLine("Incorrect input.Try again please");
                    continue;
                }
            }
            while (true);
        }
        public void StartRound()
        {
            Round.PrepareToGame();
            do
            {
                ShowHands();
                InputAnswer();
                if (Answer.ToLower() == "yes")
                {
                    bool firstCheck = Round.AddCardToPlayer();
                    if (firstCheck == false)
                    {
                        ShowHands();
                        Console.WriteLine("Your points more than 21.You lost");
                        Round.IncreaseDealerWins();
                        break;
                    }
                    else if (firstCheck == true)
                    {
                        bool secondCheck = Round.AddCardToDealer();
                        if (secondCheck == false)
                        {
                            ShowHands();
                            Console.WriteLine("Dealer have more 21 points.You won!");
                            Round.IncreasePlayerWins();
                            break;
                        }
                        else if (secondCheck == true)
                            continue;
                    }
                }
                else if (Answer.ToLower() == "no")
                {
                    ShowHands();
                    Round.SelectWinner();
                    Console.WriteLine("{0} Won!{1} have {2}, Dealer have {3} ",
                        Round.Winner, Round.Game.Player.Name, Round.Game.Player.Points, Round.Game.Dealer.Points);
                    break;
                }
            } while (true);
        }
        public void StartGame()
        {
            bool check = true;
            do
            {
                if (check)
                    StartRound();
                if (!check)
                    break;
                do
                {
                    Console.WriteLine("Do you want to play again?Write Yes or No");
                    string input = Console.ReadLine().ToLower();
                    if (input == "yes")
                        break;
                    else if (input == "no")
                    {
                        check = false;
                        break; ;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input.Try again please");
                        continue;
                    }
                }
                while (true);
            } while (true);
            Console.WriteLine("Game is closing...");
        }
    }
}
