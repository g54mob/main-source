using Aggro.Core;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Inventory", fileName = "shopinventory-NAME")]
public class ShopInventoryObject : ScriptableObject
{
	[Min(1f)]
	public int inventoryDeckSize = 20;

	public DeckCard<ShopItemObject>[] cards;

	public Deck<ShopItemObject> CreateRandomDeck(int seed)
	{
		Deck<ShopItemObject> deck = new Deck<ShopItemObject>(seed);
		deck.AddCards(cards);
		deck.Shuffle();
		return deck;
	}
}
