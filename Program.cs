using System;
using System.Collections.Generic;
using System.Linq;

namespace WarGame11
{
    internal class Program
    {
        static void Main()
        {
            //Card Creation
            List<int> teste1 = new List<int>();
            for (int i = 2; i <= 14; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    int card = i * 10 + j;
                    teste1.Add(card);
                }
            }
            
            
            List<int> teste = new List<int>();
            
            // Card Shuffle
            for (int i = 0; i < 52; i++)
            {
                Random random = new Random();
                int k = random.Next(0, teste1.Count - 1);
                teste.Add(teste1[k]);
                teste1.Remove(teste1[k]);
            }

            //for (int i = 0; i < teste.Count - 1; i++) Console.WriteLine(teste[i]);
            //Console.WriteLine("cards in deck: " + teste.Count);
            
            //Card delivery
            var player1 = new List<int>();
            var player2 = new List<int>();
            for (int i = 0; i < 52; i += 2)
            {
                player1.Add(teste[i]);
            }
            for (int i = 1; i <= 52; i += 2)
            {
                player2.Add(teste[i]);
            }
            //Console.WriteLine(player1.Count);
            //Console.WriteLine(player2.Count);

            player1.Reverse();
            player2.Reverse();
            
            //Game start
            Console.WriteLine("Game start");

            while (player1.Count > 0 && player2.Count > 0)
            {
                Console.WriteLine("Player 1 cards: ");
                for (int i = 0; i < player1.Count; i++)
                { 
                    Console.Write(PrintCard(player1[i])+"  ");
                }
                Console.WriteLine();
                Console.WriteLine("Player 2 cards: ");
                for (int i = 0; i < player2.Count; i++)
                {
                    Console.Write(PrintCard(player2[i]) + "  ");
                }
                Console.WriteLine();
                Console.WriteLine("Push Enter to continue..."); 
                Console.ReadLine();

                int play1Card = player1[0];
                int play2Card = player2[0];
                Console.WriteLine("Player 1 cards number: " + player1.Count);
                Console.WriteLine("Player 2 cards number: " + player2.Count);
                Console.WriteLine("Play card 1: " + PrintCard(play1Card));
                Console.WriteLine("Play card 2: " + PrintCard(play2Card));
                player1.RemoveAt(0);
                player2.RemoveAt(0);

                if (play1Card > play2Card + 3)
                {
                    Console.WriteLine("Player 1 takes the pair");
                    player1.Add(play1Card);
                    player1.Add(play2Card);
                }
                else if (play1Card + 3 < play2Card)
                {
                    Console.WriteLine("Player 2 takes the pair");
                    player2.Add(play1Card);
                    player2.Add(play2Card);
                }
                else
                {
                War:
                    Console.WriteLine("WAR");
                    if (player1.Count < 5)
                    {
                        Console.WriteLine("Player 1 cards are not enough. Player 2 wins! Game over!");
                        for(int k=0; k<player1.Count; k++)
                        {
                            player2.Add(player1[k]);
                        }
                        break;
                    }
                    else if (player2.Count < 5)
                    {
                        Console.WriteLine("Player 2 cards are not enough. Player 1 wins! Game over!");
                        for (int k = 0; k < player2.Count; k++)
                        {
                            player1.Add(player2[k]);
                        }
                        break;
                    }
                    else
                    {
                    
                        int warCard1 = player1[3];
                        player1.RemoveAt(3);
                        int warCard2 = player2[3];
                        player2.RemoveAt(3);
                        Console.WriteLine("Player1 warcard : " + PrintCard(warCard1));
                        Console.WriteLine("Player2 warcard: " + PrintCard(warCard2));

                        List<int> poolCards = new List<int>();

                        if (warCard1 > warCard2 + 3)
                        {
                            Console.WriteLine("Player 1 wins the war");

                            poolCards.Add(play1Card);
                            poolCards.Add(play2Card);
                            
                            for (int j = 0; j < 3; j++)
                            {
                                player2.RemoveAt(j);
                                player1.RemoveAt(j);
                                poolCards.Add(player1[j]);
                                poolCards.Add(player2[j]);
                                
                            }
                            poolCards.Add(warCard1);
                            poolCards.Add(warCard2);
                            player1.AddRange(poolCards);
                        }
                        else if (warCard1 + 3 < warCard2)
                        {
                            Console.WriteLine("Player 2 wins the war");
                            poolCards.Add(play1Card);
                            poolCards.Add(play2Card);

                            for (int j = 0; j < 3; j++)
                            {
                                player1.RemoveAt(j);
                                player2.RemoveAt(j);
                                poolCards.Add(player1[j]);
                                poolCards.Add(player2[j]);
                                
                            }
                            
                            poolCards.Add(warCard1);
                            poolCards.Add(warCard2);
                            player2.AddRange(poolCards);
                        }
                        else
                        {
                            poolCards.AddRange(poolCards);
                            goto War;

                        }
                        

                    }

                }
                
            }
            Console.WriteLine("Game over!");
        }
        static string PrintCard(int a)
        {
            int value = a / 10;
            int suit = a % 10;
            string v;
            string su;
            string karta;
            if (value <= 10)
            {
                v = value.ToString();
            }
            else
            {
                switch (value)
                {
                    case 11: v = "J"; break;
                    case 12: v = "Q"; break;
                    case 13: v = "K"; break;
                    case 14: v = "A"; break;
                    default: v = value.ToString(); break;
                }
            }
                           
            switch (suit)
            {
                case 1: su = "H"; break;
                case 2: su = "S"; break;
                case 3: su = "D"; break;
                case 4: su = "C"; break;
                default: su=suit.ToString(); break;
            }
            
            karta= v+su;
            return karta;
        }
    }
    }






   