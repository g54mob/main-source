using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

public class Shop : NetworkAggroManagerBase<Shop>
{
	private struct ShopCard
	{
		public ItemType type;

		public ShopItemObject obj;
	}

	private enum ItemType
	{
		Object = 0,
		Random = 1
	}

	public ShopInventoryObject inventory;

	private Dictionary<ShopItemObject, int> _purchased = new Dictionary<ShopItemObject, int>();

	private static Dictionary<ShopItemObject, int> _current = new Dictionary<ShopItemObject, int>();

	private static List<ShopHolder> _holders = new List<ShopHolder>();

	private static Queue<ShopItemObject> _required = new Queue<ShopItemObject>();

	private static List<ShopHolder> _saleCandidates = new List<ShopHolder>();

	private int _serverStockGenCount;

	private int _serverSeed;

	private HashSet<ShopItemObject> _extraAddedSet = new HashSet<ShopItemObject>();

	private Deck<ShopCard> _serverDeck;

	private Deck<ShopItemObject> _serverRandomDeck;

	protected override void OnEntityCreated()
	{
		if (base.isServer && !GameUtil.isTutorial)
		{
			Unity.Mathematics.Random random = MathUtil.GetRandom(Hash.Calculate(GameUtil.seed, Hash.Calculate(GetType())));
			_serverDeck = new Deck<ShopCard>(random.NextInt());
			for (int i = 0; i < GameUtil.contract.shopCards.Length; i++)
			{
				DeckCard<ShopItemObject> deckCard = GameUtil.contract.shopCards[i];
				ShopCard card = new ShopCard
				{
					type = ItemType.Object,
					obj = deckCard.item
				};
				_serverDeck.AddCard(card, deckCard.cardCount);
			}
			_serverRandomDeck = inventory.CreateRandomDeck(random.NextInt());
			if (_serverDeck.cardCount < inventory.inventoryDeckSize)
			{
				ShopCard card2 = new ShopCard
				{
					type = ItemType.Random
				};
				_serverDeck.AddCard(card2, inventory.inventoryDeckSize - _serverDeck.cardCount);
			}
			_serverDeck.Shuffle();
			_serverSeed = random.NextInt();
		}
	}

	[Server]
	public void ServerGenerateShopStock()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Shop::ServerGenerateShopStock()' called when server was not active");
			return;
		}
		_holders.Clear();
		base.entity.GetObjects(_holders);
		_serverStockGenCount++;
		Unity.Mathematics.Random random = MathUtil.GetRandom(Hash.Calculate(_serverSeed, _serverStockGenCount));
		_holders.Randomize(random.NextInt());
		_current.Clear();
		_required.Clear();
		_saleCandidates.Clear();
		for (int i = 0; i < _holders.Count; i++)
		{
			ShopItemObject shopItemObject = null;
			if (_required.Count == 0)
			{
				int shuffleGeneration = _serverDeck.shuffleGeneration;
				while (_serverDeck.cardCount > 0)
				{
					if (_serverDeck.shuffleGeneration >= shuffleGeneration + 2)
					{
						Debug.LogWarning("[SHOP] Could not find an item from inventory!", inventory);
						break;
					}
					ShopCard shopCard = _serverDeck.DrawCard();
					ShopItemObject shopItemObject2 = null;
					switch (shopCard.type)
					{
					case ItemType.Object:
						goto IL_00fb;
					case ItemType.Random:
					{
						int shuffleGeneration2 = _serverRandomDeck.shuffleGeneration;
						while (_serverRandomDeck.cardCount > 0)
						{
							if (_serverRandomDeck.shuffleGeneration >= shuffleGeneration2 + 2)
							{
								Debug.LogWarning("[SHOP] Could not find an item from random inventory!", inventory);
								break;
							}
							ShopItemObject shopItemObject3 = _serverRandomDeck.DrawCard();
							if (CanAddShopItem(shopItemObject3, i))
							{
								shopItemObject2 = shopItemObject3;
								break;
							}
						}
						break;
					}
					default:
						throw new InvalidEnumException();
					}
					goto IL_017f;
					IL_017f:
					if ((object)shopItemObject2 != null && shopItemObject2.hasRequiredNumberInShop)
					{
						for (int j = 0; j < shopItemObject2.requiredNumberInShop - 1; j++)
						{
							_required.Enqueue(shopItemObject2);
						}
					}
					shopItemObject = shopItemObject2;
					break;
					IL_00fb:
					if (!CanAddShopItem(shopCard.obj, i))
					{
						continue;
					}
					shopItemObject2 = shopCard.obj;
					goto IL_017f;
				}
			}
			else
			{
				shopItemObject = _required.Dequeue();
			}
			if ((object)shopItemObject == null)
			{
				return;
			}
			_current.TryGetValue(shopItemObject, out var value);
			_current[shopItemObject] = value + 1;
			_holders[i].ServerSetItem(shopItemObject, ServerItemPurchased);
			if (shopItemObject.type == ShopItemType.Station)
			{
				_saleCandidates.Add(_holders[i]);
			}
		}
		if (_saleCandidates.Count > 0)
		{
			_saleCandidates[random.NextInt(0, _saleCandidates.Count)].ServerSetOnSale();
		}
	}

	private bool CanAddShopItem(ShopItemObject candidate, int holderIndex)
	{
		if (candidate.uniqueInStock && _current.ContainsKey(candidate))
		{
			return false;
		}
		if (candidate.limitTotalPurchases)
		{
			_current.TryGetValue(candidate, out var value);
			_purchased.TryGetValue(candidate, out var value2);
			if (value + value2 >= candidate.limitCount)
			{
				return false;
			}
		}
		if (candidate.hasRequiredNumberInShop && _holders.Count - holderIndex < candidate.requiredNumberInShop)
		{
			return false;
		}
		return true;
	}

	private void ServerItemPurchased(ShopItemObject item)
	{
		_purchased.TryGetValue(item, out var value);
		_purchased[item] = value + 1;
		if (item.onPurchaseAddCount > 0 && !_extraAddedSet.Contains(item))
		{
			ShopCard card = new ShopCard
			{
				type = ItemType.Object,
				obj = item
			};
			_serverDeck.AddCard(card, item.onPurchaseAddCount);
			_serverDeck.Shuffle();
			_extraAddedSet.Add(item);
		}
	}

	[Server]
	public void ServerReroll()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Shop::ServerReroll()' called when server was not active");
		}
		else
		{
			ServerGenerateShopStock();
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
