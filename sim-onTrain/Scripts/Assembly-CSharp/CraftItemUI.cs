using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftItemUI : MonoBehaviour
{
	public CollectableItemData collectableItemData;

	public int craftingCount = 1;

	public Button craftButton;

	public List<CraftNeededPartUI> craftNeededPartUIs = new List<CraftNeededPartUI>();

	private PlayerInventory inventory;

	public Image itemSprite;

	public TextMeshProUGUI itemNameText;

	public TextMeshProUGUI itemDescriptionText;

	public List<CostData> neededItemsData = new List<CostData>();

	private bool isSet;

	public GameObject neededLearnTextContainer;

	public GameObject neededPartsContainer;

	private ItemInfoHover itemInfoHover;

	private bool isDirty = true;

	private static Dictionary<CollectableItemData, int> inventoryCache = new Dictionary<CollectableItemData, int>();

	private static bool isCacheDirty = true;

	private static PlayerInventory cachedInventory;

	private static int cacheRebuiltFrame = -1;

	private int lastUpdatedFrame = -1;

	private void Awake()
	{
		if (itemSprite != null)
		{
			itemInfoHover = itemSprite.GetComponent<ItemInfoHover>();
			if (itemInfoHover == null)
			{
				itemInfoHover = itemSprite.gameObject.AddComponent<ItemInfoHover>();
			}
			itemInfoHover.UseImagePanel = true;
		}
	}

	private void Start()
	{
		craftButton.onClick.AddListener(Craft);
	}

	private void OnEnable()
	{
		isDirty = true;
	}

	private static void EnsureInventoryCached()
	{
		if (cachedInventory == null && !(TrainGameManager.Instance == null) && !(TrainGameManager.Instance.mainPlayer == null))
		{
			cachedInventory = TrainGameManager.Instance.mainPlayer.GetComponent<PlayerInventory>();
			if (cachedInventory != null)
			{
				cachedInventory.OnInventoryUpdated.AddListener(OnInventoryChanged);
				cachedInventory.OnCollectableCollected.AddListener(OnCollectableChanged);
				isCacheDirty = true;
			}
		}
	}

	private static void OnCollectableChanged(CollectableItemData item, int count, float durability)
	{
		isCacheDirty = true;
	}

	private static void OnInventoryChanged()
	{
		isCacheDirty = true;
	}

	private static void RebuildCacheIfNeeded()
	{
		if (!isCacheDirty || cachedInventory == null)
		{
			return;
		}
		isCacheDirty = false;
		cacheRebuiltFrame = Time.frameCount;
		inventoryCache.Clear();
		List<PlayerInventoryData> inventoryData = cachedInventory.inventoryData;
		for (int i = 0; i < inventoryData.Count; i++)
		{
			PlayerInventoryData playerInventoryData = inventoryData[i];
			if (playerInventoryData.item != null)
			{
				inventoryCache[playerInventoryData.item] = playerInventoryData.itemCollectedCount;
			}
		}
	}

	private static int GetItemCount(CollectableItemData item)
	{
		if (item == null)
		{
			return 0;
		}
		if (!inventoryCache.TryGetValue(item, out var value))
		{
			return 0;
		}
		return value;
	}

	public static void RefreshInventoryCache()
	{
		EnsureInventoryCached();
		isCacheDirty = true;
		RebuildCacheIfNeeded();
	}

	public void SetNeededsPart(CollectableItemData collectableItem)
	{
		EnsureInventoryCached();
		inventory = cachedInventory;
		collectableItemData = collectableItem;
		neededItemsData.Clear();
		int num = 0;
		List<CostData> costData = collectableItem.costData;
		itemSprite.sprite = collectableItem.itemImage;
		SetTextWithFontSwitcher(itemNameText, collectableItem.GetLocalizedDisplayName());
		SetTextWithFontSwitcher(itemDescriptionText, collectableItem.GetLocalizedDescription());
		if (itemInfoHover != null)
		{
			itemInfoHover.SetItemData(collectableItem);
		}
		craftingCount = collectableItem.craftingCount;
		bool flag = TrainGameManager.Instance != null && TrainGameManager.Instance.currentGameMode == GameMode.Creative;
		if (collectableItem.isLearned || flag)
		{
			neededPartsContainer.SetActive(value: true);
			neededLearnTextContainer.SetActive(value: false);
		}
		else
		{
			neededPartsContainer.SetActive(value: false);
			neededLearnTextContainer.SetActive(value: true);
		}
		RebuildCacheIfNeeded();
		foreach (CraftNeededPartUI craftNeededPartUI in craftNeededPartUIs)
		{
			if (num >= costData.Count)
			{
				craftNeededPartUI.gameObject.SetActive(value: true);
				craftNeededPartUI.SetNull();
			}
			else
			{
				craftNeededPartUI.gameObject.SetActive(value: true);
				CostData costData2 = costData[num];
				neededItemsData.Add(costData2);
				int itemCount = GetItemCount(costData2.item);
				craftNeededPartUI.SetPanel(costData2, itemCount);
			}
			num++;
		}
		isSet = true;
		isDirty = false;
		UpdateCraftState();
	}

	private void Update()
	{
		if (isSet)
		{
			if (isCacheDirty)
			{
				RebuildCacheIfNeeded();
			}
			if (cacheRebuiltFrame > lastUpdatedFrame)
			{
				isDirty = true;
			}
			if (isDirty)
			{
				isDirty = false;
				lastUpdatedFrame = Time.frameCount;
				UpdateCraftState();
			}
		}
	}

	private void UpdateCraftState()
	{
		if (inventory == null || neededItemsData.Count == 0)
		{
			craftButton.interactable = false;
			return;
		}
		bool flag = TrainGameManager.Instance != null && TrainGameManager.Instance.currentGameMode == GameMode.Creative;
		if (!flag && collectableItemData != null && !collectableItemData.isLearned)
		{
			craftButton.interactable = false;
			return;
		}
		bool flag2 = true;
		for (int i = 0; i < neededItemsData.Count && i < craftNeededPartUIs.Count; i++)
		{
			CostData costData = neededItemsData[i];
			int itemCount = GetItemCount(costData.item);
			if (craftNeededPartUIs[i].gameObject.activeInHierarchy)
			{
				craftNeededPartUIs[i].SetPanel(costData, itemCount);
			}
			if (!flag && itemCount < costData.cost)
			{
				flag2 = false;
			}
		}
		craftButton.interactable = flag || flag2;
	}

	public void CheckCraft()
	{
		isDirty = true;
	}

	public void Craft()
	{
		if (TrainGameManager.Instance == null || TrainGameManager.Instance.currentGameMode != GameMode.Creative)
		{
			foreach (CostData neededItemsDatum in neededItemsData)
			{
				inventory.AddItemInventory(neededItemsDatum.item, -neededItemsDatum.cost);
			}
		}
		CollectableItemData item = ((collectableItemData.mainItem != null) ? collectableItemData.mainItem : collectableItemData);
		int num = CountItemInSlots(inventory, item);
		inventory.AddItemInventory(collectableItemData, craftingCount, collectableItemData.startDurability);
		int num2 = CountItemInSlots(inventory, item);
		int num3 = craftingCount - (num2 - num);
		if (num3 > 0)
		{
			DropCraftedItem(num3);
			if (Singleton<UserMessagePanel>.Instance != null)
			{
				Singleton<UserMessagePanel>.Instance.ShowInventoryFullMessage();
			}
		}
		if (NetworkSoundPlayer.Instance != null)
		{
			NetworkSoundPlayer.Instance.PlaySound2DLocal(GameAudios.GeneralCraftSound);
		}
		TaskEventManager.OnCraftTaskCompleted.Invoke(collectableItemData, craftingCount);
		isCacheDirty = true;
		RebuildCacheIfNeeded();
	}

	private int CountItemInSlots(PlayerInventory player, CollectableItemData item)
	{
		int num = 0;
		foreach (InventorySlotsData inventorySlotsDatum in player.inventorySlotsData)
		{
			if (inventorySlotsDatum.item == item && inventorySlotsDatum.itemCountInSlot > 0)
			{
				num += inventorySlotsDatum.itemCountInSlot;
			}
		}
		return num;
	}

	private void DropCraftedItem(int amount)
	{
		Transform transform = inventory.GetComponent<TSPlayerController>().activeCamera.transform;
		Vector3 spawnPoint = transform.position + transform.forward;
		Vector3 spawnForward = transform.position + transform.forward * 2f;
		if (collectableItemData.hasDurability)
		{
			NetworkSceneObjectSpawner.Instance.SpawnDropItemClientWithDurability(collectableItemData.itemName, amount, spawnPoint, spawnForward, collectableItemData.startDurability);
		}
		else
		{
			NetworkSceneObjectSpawner.Instance.SpawnDropItemClient(collectableItemData.itemName, amount, spawnPoint, spawnForward);
		}
	}

	private void SetTextWithFontSwitcher(TMP_Text tmpText, string text)
	{
		DynamicFontSwitcher component = tmpText.GetComponent<DynamicFontSwitcher>();
		if (component != null)
		{
			component.SetText(text);
		}
		else
		{
			tmpText.SetText(text);
		}
	}
}
