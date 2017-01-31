using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSystem : MonoBehaviour {

	public GameObject CardPrefab;

	private int deckSize; // temporary measure for generating deck
	private int handSize;

	private Stack<CardData> userDeck;
	private Stack<CardData> opponentDeck;

	private List<CardData> userHandData;
	private List<CardData> opponentHandData;

	private List<Card> userHand;

	// Use this for initialization
	void Start () {
		// Initialize deck and hands
		deckSize = 50;
		handSize = 5;
		userDeck = GenerateDeck (deckSize);
		userHandData = GenerateHand (userDeck, handSize);
		opponentDeck = GenerateDeck (deckSize);
		opponentHandData = GenerateHand (userDeck, handSize);

		// Instatitate cardprefabs side by side on the bottom left of the screen 
		userHand = new List<Card>();
		for (int i = 0; i < userHandData.Count; i++) {
			CardData cardData = userHandData [i];
			Card card = ((GameObject)Instantiate( CardPrefab, new Vector3(i*1.1f - 5, 1, -5), Quaternion.Euler(new Vector3()))).GetComponent<Card>();
			userHand.Add (card);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	Stack<CardData> GenerateDeck(int size) {
		// TODO: Randomize deck
		Stack<CardData> deck = new Stack<CardData> ();
		for (int i = 0; i < size; i++) {
			CardData card = new CardData ("Title " + i, "Description " + i);
			deck.Push (card);
		}
		return deck;
	}

	List<CardData> GenerateHand(Stack<CardData> deck, int size) {
		List<CardData> hand = new List<CardData> ();
		for (int i = 0; i < size; i++) {
			CardData card = deck.Pop ();
			hand.Add (card);
		}
		return hand;
	}
}
