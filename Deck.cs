using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Deck
{
    public Card[] deck;
    private int currentCard;
    private const int TOTAL_CARDS = 52;
    private Random randInt;
    IDictionary<int, string> numberNames = new Dictionary<int, string>();
    public Deck()
    {
        string[] faces = {"Ace","Two","Three","Four","Five","Six",
                            "Seven","Eight","Nine","Ten","Jack","Queen","King"};
        string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
        deck = new Card[TOTAL_CARDS];
        currentCard = 0;
        randInt = new Random();
        for (int i = 0; i < deck.Length; i++)
        {
            deck[i] = new Card(faces[i % 13], suits[i / 13]);
            numberNames[i] = Convert.ToString(deck[i]);
        }
    }

    /// <summary>
    /// Gives the card name at the index value in a ordered deck
    /// <param name="index1">The index to which the value you need</param>
    /// <returns>the value present in the index in the ordered deck</returns>
    public string indexedValue(int index1)
    {
        return numberNames[index1];
    }

    /// <summary>
    /// Shuffle the deck.
    /// </summary>
    public void Shuffle()
    {
        currentCard = 0;
        for( int i=0;i<deck.Length; i++)
        {
            int rand = randInt.Next(52);
            Card temp = deck[i];
            deck[i] = deck[rand];
            deck[rand] = temp;
        }
    }

    /// <summary>
    /// Draw a the top card from the deck.
    /// </summary>
    /// <returns>the top card in the deck</returns>
    public Card DealCard()
    {
        if (currentCard < deck.Length)
            return deck[currentCard++];
        else
            return null;
    }

    /// <summary>
    /// Draw a the top card from the deck.
    /// </summary>
    /// <returns>the top card in the deck</returns>
    public Card TopCard()
    {
        return deck[0];
    }

    /// <summary>
    /// Draw a the specified card from the deck.
    /// </summary>
    /// <param name="k">to get the Kth card</param>
    /// <returns>the Kth card in the deck</returns>
    public Card AllCard(int k)
    {
        return deck[k];
        
    }
    /// <summary>
    /// Draw a the specified number of cards from the deck.
    /// </summary>
    /// <param name="howMany">how many cards to draw.</param>
    /// <returns>the list of drawn cards</returns>

    public List<Card> CardSet;
    public List<Card> Draw(int howMany)
    {
        List<Card> userHand = new List<Card>();
        HashSet<int> odd = new HashSet<int>();
        for (int i = 0; i < howMany; i++)
        {
            int index = randInt.Next(52);
            if (odd.Contains(index))
            {
                i--;
                continue;
            }
            odd.Add(index);

            userHand.Add(deck[index]);
            //deck.RemoveAt(index);
        }

        return userHand;
    }

    /// <summary>
    /// Function asks user for value cards he wish to check and validates input
    /// </summary>
    /// <returns>finalIndex of the card given in original ordered deck</returns>
    public int indexOfCard()
    {
        int finalIndex;
        int faces1=0, faces2=0;
        bool validateInput = false;
        Console.WriteLine("\nInput the number of card you wish to check from 1 to 13: ");
        //faces1 = Convert.ToInt32(Console.ReadLine());
        
        while (validateInput == false)
        {
            validateInput = int.TryParse(Console.ReadLine(), out faces1);
            if (!validateInput)
            {
                Console.WriteLine("ERROR: Input not valid.Please provide an Integer value and Try Again.");
                Console.WriteLine("Input Number: ");
            }
            else
            {
                if (faces1 > 14 || faces1 < 1)
                {
                    validateInput = false;
                    Console.WriteLine("ERROR: Input not between 1 and 13. Try Again.");
                    Console.WriteLine("Input Number: ");
                }
                else
                    validateInput = true;
            }
        }

        bool validateInput1 = false;
        
        Console.WriteLine("Input the type of card you wish to check in{Clubs,Diamonds,Hearts,Spades}as {0,1,2,3}: ");
        while (validateInput1 == false)
        {
            validateInput1 = int.TryParse(Console.ReadLine(), out faces2);
            if (!validateInput1)
            {
                Console.WriteLine("ERROR: Input not valid.Please provide an Integer value and Try Again.");
                Console.WriteLine("Input Number: ");
            }
            else
            {
                if (faces2 > 3 || faces2 < 0)
                {
                    validateInput1 = false;
                    Console.WriteLine("ERROR: Input not between 0 and 3. Try Again.");
                    Console.WriteLine("Input Number: ");
                }
                else
                    validateInput1 = true;
            }
        }
        //faces2 = Convert.ToInt32(Console.ReadLine());
        finalIndex = (faces2 * 13) + faces1-1;
        return finalIndex;
    }
    /// <summary>
    /// Function asks user for howMany cards to draw and validates input
    /// </summary>
    /// <returns>valid value for howMany cards to draw</returns>
    public int sizeOfHand()
    {
        int numCards = 0;
        bool validateInput = false;

        Console.WriteLine("Input the number of cards you wish to draw: ");
        while (validateInput == false)
        {
            validateInput = int.TryParse(Console.ReadLine(), out numCards);
            if (!validateInput)
            {
                Console.WriteLine("ERROR: Input not valid. Try Again.");
                Console.WriteLine("Input Number: ");
            }
            else
            {
                if (numCards > 52 || numCards < 1)
                {
                    validateInput = false;
                    Console.WriteLine("ERROR: Input not between 1 and 52. Try Again.");
                    Console.WriteLine("Input Number: ");
                }
                else
                    validateInput = true;
            }
        }

        return numCards;
    }
}
