using System;
using System.Collections.Generic;
using EPOOutline;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ComputerShop : Interact
{
	private Outlinable outlineEffect;

	[SerializeField]
	private GameObject canvasComputerShop;

	[SerializeField]
	private Transform[] transformProductItemsSpawns;

	private int[] itemsSpawnsInUse;

	private Transform transformItemSpawn;

	private int currentSpawnIndex;

	[SerializeField]
	private GameObject shopCartItemPrefab;

	[SerializeField]
	private Transform parentForShopCartItems;

	[SerializeField]
	private ButtonExtended buttonCheckOut;

	private int uniqueID;

	private Dictionary<int, GameObject> spawnedItems;

	private Dictionary<int, int> spawnedItemPositions;

	private List<ShopCartItem> cartUIItems;

	[SerializeField]
	private TextMeshProUGUI text_totalPrice;

	private int currentPrice;

	[SerializeField]
	private GateLever gateLever;

	[SerializeField]
	private GameObject shopItemParent;

	public ShopItem[] shopItems;

	[SerializeField]
	private GameObject mainScreen;

	[SerializeField]
	private GameObject shopScreen;

	[SerializeField]
	private GameObject networkMapScreen;

	[SerializeField]
	private GameObject assetManagementScreen;

	[SerializeField]
	private GameObject balanceSheetScreen;

	[SerializeField]
	private GameObject hireScreen;

	[SerializeField]
	private TextMeshProUGUI textNetworkMap;

	[SerializeField]
	private Vector3 additionalSpawnPosForPatchpanel;

	[SerializeField]
	private Vector3 additionalSpawnPosForSFPBox;

	private Action<InputAction.CallbackContext> escapePerformed;

	public override void Awake()
	{
	}

	public override void InteractOnClick()
	{
	}

	public void ButtonShopScreen()
	{
	}

	public void ButtonNetworkMap()
	{
	}

	public void ButtonAssetManagementScreen()
	{
	}

	public void ButtonBalanceSheetScreen()
	{
	}

	public void ButtonHireScreen()
	{
	}

	public void ButtonReturnMainScreen()
	{
	}

	public override void InteractOnHover(RaycastHit hit)
	{
	}

	public override void OnHoverOver()
	{
	}

	private Dictionary<int, Transform> GetNextAvailableSpawnPoint()
	{
		return null;
	}

	public void FreeUpSpawnPoint(int spawnIndex)
	{
	}

	public void ButtonBuyShopItem(int itemID, int price, PlayerManager.ObjectInHand itemType, string displayName)
	{
	}

	private void BuyNewItem(int itemID, int price, PlayerManager.ObjectInHand itemType, string displayName)
	{
	}

	public void BuyAnotherItem(int itemID, int price, PlayerManager.ObjectInHand itemType, ShopCartItem cartItem)
	{
	}

	private int? SpawnPhysicalItem(GameObject prefab, int price, PlayerManager.ObjectInHand itemType)
	{
		return null;
	}

	private GameObject GetPrefabForItem(int itemID, PlayerManager.ObjectInHand itemType)
	{
		return null;
	}

	private void HandleObjectives(PlayerManager.ObjectInHand itemType)
	{
	}

	public void RemoveSpawnedItem(int uid)
	{
	}

	public void RemoveCartUIItem(ShopCartItem cartItem)
	{
	}

	private void SelectNextAvailable(int removedIndex)
	{
	}

	public void UpdateCartTotal()
	{
	}

	public void ButtonCheckOut()
	{
	}

	private void ClearTrackingWithoutDestroying()
	{
	}

	public void ButtonClear()
	{
	}

	public void ButtonCancel()
	{
	}

	private void DestroyAllSpawnedItems()
	{
	}

	private void CleanUpShop()
	{
	}

	private void CloseShop()
	{
	}

	public void UnlockFromSave(Dictionary<string, bool> savedStates)
	{
	}

	private void OnLoad()
	{
	}

	private void OnDestroy()
	{
	}
}
