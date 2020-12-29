using System;
using System.Collections.Generic;

namespace HelloWorld
{
    class main
    {
        static void Main(string[] args)
        {
            int index1 = 0;
            int choice;
            Console.WriteLine("1. Shuffle ");
            Console.WriteLine("2. Draw cards ");
            Console.WriteLine("3. Draw Top card ");
            Console.WriteLine("4. Find a card ");
            Console.WriteLine("5. Exit ");
            Deck deck1 = new Deck();
            do
            {
                Console.WriteLine("Select your choice (1-5): ");
                choice = int.Parse(Console.ReadLine());
            do
            {
                if (choice == 1)
                {
                    deck1.Shuffle();
                    Console.WriteLine("\nPrinting the shuffled cards\n");
                    for (int i = 0; i < 52; i++)
                    {
                        Console.Write("{0,-19}", deck1.DealCard());
                        if ((i + 1) % 4 == 0)
                            Console.WriteLine();
                    }
                    break;
                }

                if (choice == 2)
                {
                    int howMany = 0;
                    List<Card> hand1 = new List<Card>();
                    howMany = deck1.sizeOfHand();
                    hand1 = deck1.Draw(howMany);
                    for (int i = 0; i < hand1.Count; i++)
                    {
                        Console.WriteLine("{0}", hand1[i]);
                    }
                    break;
                }

                if (choice == 3)
                {
                    Console.WriteLine("\nPrinting the top card: {0}", deck1.TopCard());
                    break;
                }

                if (choice == 4)
                {
                    index1 = deck1.indexOfCard();
                    Console.WriteLine(deck1.indexedValue(index1));
                    HashSet<String> finalDeck = new HashSet<String>();
                    for (int i = 0; i < 52; i++)
                    {

                        String str = deck1.indexedValue(index1);
                        finalDeck.Add(str);
                        if (finalDeck.Contains(Convert.ToString(deck1.AllCard(i))))
                        {
                            Console.WriteLine("\nThe card you are looking is present at {0} position", i + 1);
                        }
                    }
                    break;
                }
                if (choice == 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid input");
                    break;
                }

            } while (choice > 0);
                if (choice == 5)
                {
                    Console.WriteLine("Exiting");
                    break;
                }
            } while (choice > 0);
            
        }
    }
}