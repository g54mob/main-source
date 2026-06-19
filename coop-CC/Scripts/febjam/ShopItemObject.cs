using Aggro.Core.Networking;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Item", fileName = "shopitem-NAME")]
public class ShopItemObject : NetworkScriptableObject
{
	public string itemName;

	public string itemDescription;

	public Sprite icon;

	public ShopItemType type;

	[Min(0f)]
	public int cost;

	public bool uniqueInStock;

	public bool limitTotalPurchases;

	[Min(1f)]
	public int limitCount = 1;

	public bool hasRequiredNumberInShop;

	[Min(1f)]
	public int requiredNumberInShop = 1;

	[Min(0f)]
	public int onPurchaseAddCount;

	public GameObject shopItemPrefab;

	public GameObject worldItemPrefab;

	public PlayerUpgrade upgrade;
}
