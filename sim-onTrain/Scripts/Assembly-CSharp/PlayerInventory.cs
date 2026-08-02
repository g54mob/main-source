using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
	public int inventorySlotMaxCapacity = 32;

	public List<PlayerInventoryData> inventoryData = new List<PlayerInventoryData>();

	public List<CollectableItemData> buildData = new List<CollectableItemData>();

	public List<CollectableItemData> placeableData = new List<CollectableItemData>();

	public List<InventorySlotsData> inventorySlotsData = new List<InventorySlotsData>();

	public UnityEvent<CollectableItemData, int, float> OnCollectableCollected = new UnityEvent<CollectableItemData, int, float>();

	public UnityEvent OnInventoryUpdated = new UnityEvent();

	[HideInInspector]
	public List<InventorySlot> mainInventorySlots = new List<InventorySlot>();

	public InventoryController bottomPanelInventory;

	public InventoryController mainInventory;

	private bool isInitialized;

	public GameObject defaultDropPrefab;

	private CraftInfoPanel craftPanel;

	private ResearchUIManager researchUIManager;

	private void Start()
	{
		craftPanel = Object.FindObjectOfType<CraftInfoPanel>(includeInactive: true);
		researchUIManager = ResearchUIManager.Instance;
	}

	private void Initialize(TSPlayerController player)
	{
		if (isInitialized)
		{
			return;
		}
		LoadCollectableItems();
		int num = 0;
		InventorySlot[] componentsInChildren = bottomPanelInventory.GetComponentsInChildren<InventorySlot>();
		foreach (InventorySlot inventorySlot in componentsInChildren)
		{
			num++;
			inventorySlot.isShowing = true;
			inventorySlot.inventoryID = num;
			mainInventorySlots.Add(inventorySlot);
		}
		componentsInChildren = mainInventory.GetComponentsInChildren<InventorySlot>();
		foreach (InventorySlot inventorySlot2 in componentsInChildren)
		{
			num++;
			inventorySlot2.isShowing = false;
			inventorySlot2.inventoryID = num;
			mainInventorySlots.Add(inventorySlot2);
		}
		mainInventorySlots = mainInventorySlots.OrderBy((InventorySlot slot) => slot.inventoryID).ToList();
		foreach (InventorySlot mainInventorySlot in mainInventorySlots)
		{
			inventorySlotsData.Add(new InventorySlotsData
			{
				item = null,
				itemCountInSlot = 0,
				slotID = mainInventorySlot.inventoryID,
				maxCapacity = inventorySlotMaxCapacity,
				currentMagazineCount = 0,
				currentDurability = 0f
			});
		}
		isInitialized = true;
	}

	private void OnEnable()
	{
		OnCollectableCollected.AddListener(UpdateInventoryItems);
		Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.AddListener(Initialize);
	}

	private void OnDisable()
	{
		OnCollectableCollected.RemoveListener(UpdateInventoryItems);
		Singleton<TSNetworkObjetManager>.Instance?.OnServerInitialize.RemoveListener(Initialize);
	}

	public void AddItemInventory(CollectableItemData collectableItemData, int count, float durability = -1f, int preferredSlotID = -1)
	{
		Debug.Log($"[Inventory] AddItemInventory - item: '{collectableItemData?.itemName}' | count: {count} | durability: {durability}");
		if (collectableItemData.mainItem != null)
		{
			collectableItemData = collectableItemData.mainItem;
		}
		if (collectableItemData.hasDurability && durability < 0f)
		{
			durability = collectableItemData.maxDurabilityCapacity;
		}
		foreach (PlayerInventoryData inventoryDatum in inventoryData)
		{
			if (!(inventoryDatum.item == collectableItemData))
			{
				continue;
			}
			if (count < 0)
			{
				int countToRemove = Mathf.Abs(count);
				int num = RemoveItemFromSlots(collectableItemData, countToRemove, preferredSlotID);
				inventoryDatum.itemCollectedCount -= num;
				if (inventoryDatum.itemCollectedCount < 0)
				{
					inventoryDatum.itemCollectedCount = 0;
				}
				OnCollectableCollected.Invoke(collectableItemData, -num, durability);
			}
			else
			{
				inventoryDatum.itemCollectedCount += count;
				OnCollectableCollected.Invoke(collectableItemData, count, durability);
			}
			SyncInventoryToServer();
			break;
		}
	}

	private void SyncInventoryToServer()
	{
		if (InventorySaver.Instance == null)
		{
			Debug.LogWarning("[Inventory] SyncInventoryToServer - InventorySaver NULL!");
			return;
		}
		TsPlayerNetworkHelper component = GetComponent<TsPlayerNetworkHelper>();
		if (component == null || string.IsNullOrEmpty(component.steamID))
		{
			Debug.LogWarning($"[Inventory] SyncInventoryToServer FAIL - networkHelper: {component != null}, steamID: '{component?.steamID}'");
			return;
		}
		int num = 0;
		foreach (InventorySlotsData inventorySlotsDatum in inventorySlotsData)
		{
			if (inventorySlotsDatum.item != null && inventorySlotsDatum.itemCountInSlot > 0)
			{
				num++;
			}
		}
		Debug.Log($"[Inventory] SyncInventoryToServer - steamID: '{component.steamID}' | filledSlots: {num}/{inventorySlotsData.Count} | isServer: {InventorySaver.Instance.isServer}");
		InventorySaver.Instance.RequestInventoryUpdate(component.steamID);
	}

	public bool RemoveItemOnSlot(int slotIndex, int count)
	{
		InventorySlotsData inventorySlotsData = this.inventorySlotsData.FirstOrDefault((InventorySlotsData x) => x.slotID == slotIndex);
		if (inventorySlotsData != null && inventorySlotsData.item != null && inventorySlotsData.itemCountInSlot >= count)
		{
			inventorySlotsData.itemCountInSlot -= count;
			if (inventorySlotsData.itemCountInSlot <= 0)
			{
				inventorySlotsData.Clear();
			}
			UpdateSlotUI(inventorySlotsData);
			UpdateInventoryDataFromSlots();
			return true;
		}
		return false;
	}

	private int RemoveItemFromSlots(CollectableItemData collectableItemData, int countToRemove, int preferredSlotID = -1)
	{
		int num = 0;
		int num2 = countToRemove;
		foreach (InventorySlotsData item in (from x in inventorySlotsData
			where x.item == collectableItemData && x.itemCountInSlot > 0
			orderby (x.slotID != preferredSlotID) ? 1 : 0, x.slotID
			select x).ToList())
		{
			if (num2 <= 0)
			{
				break;
			}
			int num3 = Mathf.Min(item.itemCountInSlot, num2);
			if (num3 > 0)
			{
				item.itemCountInSlot -= num3;
				num += num3;
				num2 -= num3;
				if (item.itemCountInSlot <= 0)
				{
					item.Clear();
				}
				UpdateSlotUI(item);
			}
		}
		if (num2 > 0)
		{
			Debug.LogWarning($"Yetersiz {collectableItemData.itemName}! {num2} adet çıkarılamadı.");
		}
		return num;
	}

	private void UpdateSlotUI(InventorySlotsData slotData)
	{
		InventorySlot inventorySlot = mainInventorySlots.FirstOrDefault((InventorySlot x) => x.inventoryID == slotData.slotID);
		if (inventorySlot != null && inventorySlot.InventoryItem != null)
		{
			if (slotData.item == null || slotData.itemCountInSlot <= 0)
			{
				inventorySlot.Clear();
				inventorySlot.HasItem = false;
				inventorySlot.inventoryCount = 0;
				inventorySlot.InventoryItem.ClearInventoryData();
			}
			else
			{
				inventorySlot.InventoryItem.UpdateInventoryData(slotData);
				inventorySlot.HasItem = true;
				inventorySlot.inventoryCount = slotData.itemCountInSlot;
			}
		}
	}

	public int GetTotalItemCount(CollectableItemData item)
	{
		int num = 0;
		foreach (InventorySlotsData inventorySlotsDatum in inventorySlotsData)
		{
			if (inventorySlotsDatum.item == item)
			{
				num += inventorySlotsDatum.itemCountInSlot;
			}
		}
		return num;
	}

	public void SetMagazineInfo()
	{
	}

	public void UpdateInventoryDataFromSlots()
	{
		foreach (PlayerInventoryData inventoryDatum in inventoryData)
		{
			inventoryDatum.itemCollectedCount = 0;
		}
		foreach (InventorySlotsData slotData in inventorySlotsData)
		{
			if (slotData.item != null && slotData.itemCountInSlot > 0)
			{
				PlayerInventoryData playerInventoryData = inventoryData.FirstOrDefault((PlayerInventoryData x) => x.item == slotData.item);
				if (playerInventoryData != null)
				{
					playerInventoryData.itemCollectedCount += slotData.itemCountInSlot;
				}
			}
		}
		OnInventoryUpdated.Invoke();
		GetComponent<EastUpPlayerItemManager>().CheckItemSlots();
		if (craftPanel != null)
		{
			craftPanel.SetPanel();
		}
	}

	public void OnSlotContentChanged(int slotID)
	{
		UpdateInventoryDataFromSlots();
		TsPlayerNetworkHelper component = GetComponent<TsPlayerNetworkHelper>();
		if (component != null && InventorySaver.Instance != null)
		{
			Debug.Log($"[Inventory] OnSlotContentChanged - slotID: {slotID} | steamID: '{component.steamID}'");
			InventorySaver.Instance.RequestInventoryUpdate(component.steamID);
		}
	}

	public void AddItemInventoryWithoutNotify(CollectableItemData collectableItemData, int count)
	{
		foreach (PlayerInventoryData inventoryDatum in inventoryData)
		{
			if (inventoryDatum.item == collectableItemData)
			{
				inventoryDatum.itemCollectedCount += count;
			}
		}
	}

	public bool CanAddToInventory(CollectableItemData item, int count)
	{
		if (item == null || count <= 0)
		{
			return false;
		}
		int itemSizeMultiplier = item.GetItemSizeMultiplier();
		int num = ((Singleton<GameSettings>.Instance != null) ? Singleton<GameSettings>.Instance.inventorySlotSize : inventorySlotMaxCapacity) / itemSizeMultiplier;
		int num2 = count;
		foreach (InventorySlotsData inventorySlotsDatum in inventorySlotsData)
		{
			if (num2 <= 0)
			{
				break;
			}
			if (inventorySlotsDatum.item == null)
			{
				int num3 = Mathf.Min(num, num2);
				num2 -= num3;
			}
			else if (inventorySlotsDatum.item == item)
			{
				int num4 = Mathf.Min(num - inventorySlotsDatum.itemCountInSlot, num2);
				if (num4 > 0)
				{
					num2 -= num4;
				}
			}
		}
		return num2 <= 0;
	}

	private void LoadCollectableItems()
	{
		inventoryData.Clear();
		buildData.Clear();
		placeableData.Clear();
		CollectableItemData[] array = Resources.LoadAll<CollectableItemData>("");
		Debug.Log($"Toplam {array.Length} CollectableItemData yüklendi");
		if (!NetworkManager.singleton.isNetworkActive || NetworkServer.active)
		{
			CollectableItemData[] array2 = array;
			foreach (CollectableItemData collectableItemData in array2)
			{
				PlayerInventoryData playerInventoryData = new PlayerInventoryData();
				playerInventoryData.item = collectableItemData;
				playerInventoryData.itemCollectedCount = 0;
				inventoryData.Add(playerInventoryData);
				if (collectableItemData.itemType == ItemType.BuildItem)
				{
					buildData.Add(collectableItemData);
				}
				if (collectableItemData.itemType == ItemType.Placeable)
				{
					placeableData.Add(collectableItemData);
				}
			}
		}
		else
		{
			StartCoroutine(LoadCollectableItemsFromServer(array));
		}
	}

	private IEnumerator LoadCollectableItemsFromServer(CollectableItemData[] loadedItems)
	{
		yield return new WaitForSeconds(1f);
		while (CollectableDataSaver.Instance == null)
		{
			yield return new WaitForSeconds(0.5f);
		}
		foreach (CollectableItemData collectableItemData in loadedItems)
		{
			if (CollectableDataSaver.Instance != null)
			{
				if (collectableItemData.isOpenedInStart)
				{
					collectableItemData.isResearched = true;
					collectableItemData.isLearned = true;
				}
				else
				{
					collectableItemData.isResearched = CollectableDataSaver.Instance.IsItemResearched(collectableItemData.itemName);
					collectableItemData.isLearned = CollectableDataSaver.Instance.IsItemLearned(collectableItemData.itemName);
				}
			}
			PlayerInventoryData playerInventoryData = new PlayerInventoryData();
			playerInventoryData.item = collectableItemData;
			playerInventoryData.itemCollectedCount = 0;
			inventoryData.Add(playerInventoryData);
			if (collectableItemData.itemType == ItemType.BuildItem)
			{
				buildData.Add(collectableItemData);
			}
			if (collectableItemData.itemType == ItemType.Placeable)
			{
				placeableData.Add(collectableItemData);
			}
		}
		if (craftPanel != null)
		{
			craftPanel.SetPanel();
		}
		if (researchUIManager != null)
		{
			researchUIManager.UpdateReseachStatus();
		}
		Debug.Log("Client: CollectableItems server'dan güncellendi");
	}

	public void UpdateInventoryItems(CollectableItemData collectableItem, int count, float durability)
	{
		int num = count;
		if (durability < 0f && collectableItem.hasDurability)
		{
			durability = collectableItem.maxDurabilityCapacity;
		}
		int itemSizeMultiplier = collectableItem.GetItemSizeMultiplier();
		int num2 = ((Singleton<GameSettings>.Instance != null) ? Singleton<GameSettings>.Instance.inventorySlotSize : inventorySlotMaxCapacity) / itemSizeMultiplier;
		if (!collectableItem.hasDurability)
		{
			for (int i = 0; i < this.inventorySlotsData.Count; i++)
			{
				if (num <= 0)
				{
					break;
				}
				InventorySlotsData inventorySlotsData = this.inventorySlotsData[i];
				if (inventorySlotsData.item != collectableItem)
				{
					continue;
				}
				int num3 = Mathf.Min(num2 - inventorySlotsData.itemCountInSlot, num);
				if (num3 > 0)
				{
					inventorySlotsData.itemCountInSlot += num3;
					num -= num3;
					InventorySlot inventorySlot = FindSlotByID(inventorySlotsData.slotID);
					if (inventorySlot != null && inventorySlot.InventoryItem != null)
					{
						inventorySlot.InventoryItem.UpdateInventoryData(inventorySlotsData);
					}
				}
			}
		}
		while (num > 0)
		{
			InventorySlotsData inventorySlotsData2 = FindEmptySlot();
			if (inventorySlotsData2 != null)
			{
				int num4 = Mathf.Min(num2, num);
				inventorySlotsData2.item = collectableItem;
				inventorySlotsData2.itemCountInSlot = num4;
				num -= num4;
				if (collectableItem.hasDurability)
				{
					inventorySlotsData2.currentDurability = durability;
				}
				InventorySlot inventorySlot2 = FindSlotByID(inventorySlotsData2.slotID);
				if (inventorySlot2 != null && inventorySlot2.InventoryItem != null)
				{
					inventorySlot2.InventoryItem.UpdateInventoryData(inventorySlotsData2);
				}
				continue;
			}
			break;
		}
	}

	private InventorySlot FindSlotByID(int slotID)
	{
		for (int i = 0; i < mainInventorySlots.Count; i++)
		{
			if (mainInventorySlots[i].inventoryID == slotID)
			{
				return mainInventorySlots[i];
			}
		}
		return null;
	}

	private InventorySlotsData FindEmptySlot()
	{
		for (int i = 0; i < inventorySlotsData.Count; i++)
		{
			if (inventorySlotsData[i].item == null)
			{
				return inventorySlotsData[i];
			}
		}
		return null;
	}

	public int GetAvailableSpaceForItem(CollectableItemData item)
	{
		if (item.mainItem != null)
		{
			item = item.mainItem;
		}
		int itemSizeMultiplier = item.GetItemSizeMultiplier();
		int num = ((Singleton<GameSettings>.Instance != null) ? Singleton<GameSettings>.Instance.inventorySlotSize : inventorySlotMaxCapacity) / itemSizeMultiplier;
		int num2 = 0;
		for (int i = 0; i < this.inventorySlotsData.Count; i++)
		{
			InventorySlotsData inventorySlotsData = this.inventorySlotsData[i];
			if (inventorySlotsData.item == null || inventorySlotsData.itemCountInSlot <= 0)
			{
				num2 += num;
			}
			else if (!item.hasDurability && inventorySlotsData.item == item)
			{
				num2 += num - inventorySlotsData.itemCountInSlot;
			}
		}
		return num2;
	}

	public InventorySlotsData FindItemOnInventory(CollectableItemData data)
	{
		foreach (InventorySlotsData inventorySlotsDatum in inventorySlotsData)
		{
			if (inventorySlotsDatum.item == data)
			{
				MonoBehaviour.print(inventorySlotsDatum.item.itemName);
				return inventorySlotsDatum;
			}
		}
		return null;
	}

	public void DecreaseItemOnInventorySlot(InventorySlotsData slot, int count)
	{
		mainInventorySlots.Find((InventorySlot x) => x.inventoryID == slot.slotID).InventoryItem.DecreaseItemCount(count);
	}
}
