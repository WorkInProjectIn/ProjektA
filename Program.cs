using System;
using System.Collections.Generic;

namespace SimpleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //stworzenie świata (gry)
            Game game = new Game();
            game.Start();

            Console.WriteLine("dzięki za zagranie 🙂");
            Console.ReadKey();
        }
    }

    class Game
    {
        private int playerScore;
        private int computerScore;
        private List<string> choices;
        private Random rand;

        public Game()
        {
            playerScore = 0;
            computerScore = 0;
            choices = new List<string> { "kamień", "papier", "nożyce" };
            rand = new Random();
        }

        public void Start()
        {
            Console.WriteLine("Gramy do trzech");

            while (true)
            {
                PlayRound();

                // ktoś wygrał?
                if (playerScore == 3)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("wygrywasz cały pojedynek");

                    //jeszcze raz?
                    Console.WriteLine("jeszcze raz? (t/n)");
                    string playAgain = Console.ReadLine().ToLower();
                    if (playAgain == "t")
                    {
                        // szybki resecik
                        playerScore = 0;
                        computerScore = 0;
                        PlayRound();

                    }
                    else
                    {
                        

                        break;
                    }
                }
                else if (computerScore == 3)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("przegrywasz sieroto");



                    // jeszcze raz?
                    Console.WriteLine("jeszcze raz? (t/n)");
                    string playAgain = Console.ReadLine().ToLower();
                    if (playAgain == "t")
                    {
                        // szybki resecik
                        playerScore = 0;
                        computerScore = 0;
                        PlayRound();
                    }
                    else
                    {
                        
                        break;
                    }

                }
            }
        }


        private void PlayRound()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Wybierz (kamień, papier, albo nożyce):");
            string playerChoice = Console.ReadLine().ToLower();

            // czy odpowiedź nie jest upośledzona
            if (!choices.Contains(playerChoice))
            {

                Console.WriteLine("nie ma takiej opcji");
                PlayRound();
                return;

            }


            // przypadkowa odpowiedź
            string computerChoice = choices[rand.Next(choices.Count)];
            Console.WriteLine($"Wybór komputera: {computerChoice}.");

            // kto wygrał?
            if (playerChoice == "kamień" && computerChoice == "nożyce" ||
                playerChoice == "papier" && computerChoice == "kamień" ||
                playerChoice == "nożyce" && computerChoice == "piaper")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Wygrywasz!");
                playerScore++;
                Console.ResetColor();
            }
            else if (playerChoice == computerChoice)
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("remis!");
                Console.ResetColor();
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("komputer wygrywa!");
                computerScore++;
                Console.ResetColor();
            }


            // wynik:
            Console.WriteLine($"twój wynik: {playerScore} | wynik komputera: {computerScore}");


        }
    }
}


