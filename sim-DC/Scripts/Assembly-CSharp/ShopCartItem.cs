using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopCartItem : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI txtItemName;

	[SerializeField]
	private TextMeshProUGUI txtAmount;

	[SerializeField]
	private TextMeshProUGUI txtPrice;

	[SerializeField]
	private ButtonExtended btnAdd;

	[SerializeField]
	private ButtonExtended btnRemove;

	private ComputerShop shop;

	private int itemID;

	private int price;

	private PlayerManager.ObjectInHand itemType;

	private string itemName;

	public Color itemColor;

	public bool hasCustomColor;

	private List<int> spawnedItemUIDs;

	public int ItemID => 0;

	public PlayerManager.ObjectInHand ItemType => default(PlayerManager.ObjectInHand);

	public int Quantity => 0;

	public int TotalPrice => 0;

	public ButtonExtended RemoveButton => null;

	public void Initialize(ComputerShop shop, string itemName, int itemID, int price, PlayerManager.ObjectInHand itemType, int firstSpawnUID, Color? customColor = null)
	{
	}

	public void AddSpawnedItem(int uid)
	{
	}

	public int RemoveLastSpawnedItem()
	{
		return 0;
	}

	public void ClearAllUIDs()
	{
	}

	private void OnAddClicked()
	{
	}

	private void OnRemoveClicked()
	{
	}

	private void UpdateDisplay()
	{
	}

	private void OnDestroy()
	{
	}
}
