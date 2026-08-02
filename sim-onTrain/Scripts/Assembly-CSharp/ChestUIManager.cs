using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChestUIManager : UIPanelBase, IInventorySlotContainer
{
	private InventoryManagerUI inventoryManager;

	private List<InventorySlot> inventorySlots = new List<InventorySlot>();

	public int inventorySlotMaxCapacity = 32;

	public ChestController openedChest;

	public PreArrangedChestController openedPreArrangedChest;

	public float closeCooldown;

	public bool HasOpenedChest
	{
		get
		{
			if (!(openedChest != null))
			{
				return openedPreArrangedChest != null;
			}
			return true;
		}
	}

	private void Start()
	{
		Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.AddListener(delegate(TSPlayerController player)
		{
			if (player.isLocalPlayer)
			{
				inventoryManager = TrainGameManager.instance.playerInventoryManagerUI;
			}
		});
		inventorySlots = GetComponentsInChildren<InventorySlot>().ToList();
		int num = 1000;
		foreach (InventorySlot inventorySlot in inventorySlots)
		{
			inventorySlot.inventoryID = num;
			num++;
		}
	}

	private void Update()
	{
		if (closeCooldown > 0f)
		{
			closeCooldown -= Time.deltaTime;
		}
		if (isPanelOpen && Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.ExitKey))
		{
			ChangePanelActive();
			closeCooldown = 0.2f;
		}
	}

	public void ChangePanelActive()
	{
		if (!isPanelOpen)
		{
			Singleton<MainUIManager>.Instance.OnInGamePanelOpened.Invoke(this);
			Cursor.lockState = CursorLockMode.Confined;
			ShowPanel();
		}
		else
		{
			Cursor.lockState = CursorLockMode.Locked;
			Singleton<MainUIManager>.Instance.OnInGamePanelClosed.Invoke(this);
			HidePanel();
		}
	}

	public override void ShowPanel()
	{
		base.ShowPanel();
		if (openedPreArrangedChest != null)
		{
			Debug.Log("Chest UI aciliyor. PreArranged chest: " + openedPreArrangedChest.name);
			SetActiveSlotCount(openedPreArrangedChest.slotCount);
		}
		else if (openedChest != null)
		{
			Debug.Log("Chest UI aciliyor. Yeni chest: " + openedChest.name);
			SetActiveSlotCount(openedChest.slotCount);
		}
		foreach (InventorySlot inventorySlot in inventorySlots)
		{
			inventorySlot.isShowing = true;
		}
		CompletelyResetChestSlots();
		LoadChestData();
		inventoryManager.isOpenedExternal = true;
		inventoryManager.ShowPanel();
	}

	private void SetActiveSlotCount(int activeSlotCount)
	{
		for (int i = 0; i < inventorySlots.Count; i++)
		{
			if (i < activeSlotCount)
			{
				inventorySlots[i].gameObject.SetActive(value: true);
			}
			else
			{
				inventorySlots[i].gameObject.SetActive(value: false);
			}
		}
		Debug.Log($"ChestUIManager: {activeSlotCount} slot aktif, toplam {inventorySlots.Count} slot");
	}

	private void CompletelyResetChestSlots()
	{
		foreach (InventorySlot inventorySlot in inventorySlots)
		{
			if (inventorySlot.gameObject.activeSelf)
			{
				inventorySlot.Clear(silent: true);
				if (inventorySlot.InventoryItem != null)
				{
					inventorySlot.InventoryItem.inventoryData = null;
					inventorySlot.InventoryItem.collectableItemData = null;
					inventorySlot.InventoryItem.collectedCount = 0;
					inventorySlot.InventoryItem.isEmpty = true;
				}
			}
		}
		Debug.Log($"{inventorySlots.Count} chest slot tamamen sifirlandı");
	}

	public void LoadChestData()
	{
		IList<InventorySlotsDataNetwork> list = null;
		if (openedPreArrangedChest != null)
		{
			list = openedPreArrangedChest.localInventoryData;
		}
		else if (openedChest != null)
		{
			list = openedChest.inventorySlotsData;
		}
		if (list == null || list.Count == 0)
		{
			Debug.LogWarning("ChestUIManager: Chest data source null veya bos!");
			return;
		}
		int num = 0;
		foreach (InventorySlotsDataNetwork item in list)
		{
			if (num >= inventorySlots.Count)
			{
				continue;
			}
			InventorySlot inventorySlot = inventorySlots[num];
			if (!inventorySlot.gameObject.activeSelf)
			{
				num++;
				continue;
			}
			InventorySlotsData inventorySlotsData = item.ToInventorySlot();
			if (inventorySlotsData.item != null && inventorySlotsData.itemCountInSlot > 0)
			{
				inventorySlot.InventoryItem.inventoryData = inventorySlotsData;
				inventorySlot.InventoryItem.collectableItemData = inventorySlotsData.item;
				inventorySlot.InventoryItem.collectedCount = inventorySlotsData.itemCountInSlot;
				inventorySlot.InventoryItem.isEmpty = false;
				inventorySlot.InventoryItem.UpdateInventoryData(inventorySlotsData, silent: true);
				inventorySlot.HasItem = true;
				inventorySlot.inventoryCount = inventorySlotsData.itemCountInSlot;
			}
			else
			{
				inventorySlot.InventoryItem.inventoryData = inventorySlotsData;
				inventorySlot.HasItem = false;
				inventorySlot.inventoryCount = 0;
			}
			num++;
		}
		Debug.Log($"ChestUIManager: {num} slot veri yuklendi");
	}

	public void UpdateSingleSlotUI(int index)
	{
		if (openedPreArrangedChest == null || index < 0 || index >= inventorySlots.Count || index >= openedPreArrangedChest.localInventoryData.Count)
		{
			return;
		}
		InventorySlot inventorySlot = inventorySlots[index];
		if (inventorySlot.gameObject.activeSelf)
		{
			InventorySlotsData inventorySlotsData = openedPreArrangedChest.localInventoryData[index].ToInventorySlot();
			if (inventorySlotsData.item != null && inventorySlotsData.itemCountInSlot > 0)
			{
				inventorySlot.InventoryItem.inventoryData = inventorySlotsData;
				inventorySlot.InventoryItem.collectableItemData = inventorySlotsData.item;
				inventorySlot.InventoryItem.collectedCount = inventorySlotsData.itemCountInSlot;
				inventorySlot.InventoryItem.isEmpty = false;
				inventorySlot.InventoryItem.UpdateInventoryData(inventorySlotsData, silent: true);
				inventorySlot.HasItem = true;
				inventorySlot.inventoryCount = inventorySlotsData.itemCountInSlot;
			}
			else
			{
				inventorySlot.Clear(silent: true);
				inventorySlot.InventoryItem.inventoryData = inventorySlotsData;
				inventorySlot.HasItem = false;
				inventorySlot.inventoryCount = 0;
			}
		}
	}

	public override void HidePanel()
	{
		if (!isPanelOpen && openedChest == null && openedPreArrangedChest == null)
		{
			return;
		}
		base.HidePanel();
		Debug.Log("Chest UI kapandi");
		SaveChestChanges();
		foreach (InventorySlot inventorySlot in inventorySlots)
		{
			inventorySlot.isShowing = false;
		}
		if (inventoryManager != null)
		{
			inventoryManager.isOpenedExternal = false;
			inventoryManager.HidePanel();
		}
		if (openedPreArrangedChest != null && PreArrangedChestNetworkManager.Instance != null)
		{
			PreArrangedChestNetworkManager.Instance.CmdCloseChest(openedPreArrangedChest.chunkID, openedPreArrangedChest.objectID);
			openedPreArrangedChest = null;
		}
		else if (openedChest != null)
		{
			openedChest.CmdCloseChest();
			openedChest = null;
		}
	}

	private void SaveChestChanges()
	{
		if (openedPreArrangedChest != null && PreArrangedChestNetworkManager.Instance != null)
		{
			SavePreArrangedChestChanges();
		}
		else
		{
			if (openedChest == null)
			{
				return;
			}
			Debug.Log("Chest degisiklikleri kaydediliyor...");
			for (int i = 0; i < inventorySlots.Count && i < openedChest.inventorySlotsData.Count; i++)
			{
				InventorySlot inventorySlot = inventorySlots[i];
				if (inventorySlot.gameObject.activeSelf)
				{
					if (inventorySlot.InventoryItem != null && inventorySlot.InventoryItem.collectableItemData != null && inventorySlot.InventoryItem.collectedCount > 0)
					{
						float durability = inventorySlot.InventoryItem.inventoryData?.currentDurability ?? 0f;
						int magazineCount = inventorySlot.InventoryItem.inventoryData?.currentMagazineCount ?? 0;
						openedChest.CmdUpdateSlot(i, inventorySlot.InventoryItem.collectableItemData.itemName, inventorySlot.InventoryItem.collectedCount, durability, magazineCount);
					}
					else
					{
						openedChest.CmdUpdateSlot(i, "", 0, 0f, 0);
					}
				}
			}
		}
	}

	private void SavePreArrangedChestChanges()
	{
		PreArrangedChestNetworkManager instance = PreArrangedChestNetworkManager.Instance;
		int chunkID = openedPreArrangedChest.chunkID;
		int objectID = openedPreArrangedChest.objectID;
		int count = openedPreArrangedChest.localInventoryData.Count;
		Debug.Log("PreArranged chest degisiklikleri kaydediliyor...");
		for (int i = 0; i < inventorySlots.Count && i < count; i++)
		{
			InventorySlot inventorySlot = inventorySlots[i];
			if (inventorySlot.gameObject.activeSelf)
			{
				if (inventorySlot.InventoryItem != null && inventorySlot.InventoryItem.collectableItemData != null && inventorySlot.InventoryItem.collectedCount > 0)
				{
					float durability = inventorySlot.InventoryItem.inventoryData?.currentDurability ?? 0f;
					int magazineCount = inventorySlot.InventoryItem.inventoryData?.currentMagazineCount ?? 0;
					instance.CmdUpdateSlot(chunkID, objectID, i, inventorySlot.InventoryItem.collectableItemData.itemName, inventorySlot.InventoryItem.collectedCount, durability, magazineCount);
				}
				else
				{
					instance.CmdUpdateSlot(chunkID, objectID, i, "", 0, 0f, 0);
				}
			}
		}
	}

	private void OnDisable()
	{
		if (openedChest != null)
		{
			openedChest.CmdCloseChest();
			openedChest = null;
		}
		if (openedPreArrangedChest != null && PreArrangedChestNetworkManager.Instance != null)
		{
			PreArrangedChestNetworkManager.Instance.CmdCloseChest(openedPreArrangedChest.chunkID, openedPreArrangedChest.objectID);
			openedPreArrangedChest = null;
		}
	}

	public void OnSlotsChanged()
	{
		if (HasOpenedChest && isPanelOpen)
		{
			StartCoroutine(SaveChestChangesDelayed());
		}
	}

	private IEnumerator SaveChestChangesDelayed()
	{
		yield return null;
		SaveChestChanges();
	}
}
