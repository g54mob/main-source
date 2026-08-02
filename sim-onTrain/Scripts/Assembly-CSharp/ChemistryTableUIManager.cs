using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ChemistryTableUIManager : UIPanelBase
{
	[Header("Chemistry Data")]
	public List<FuelData> fuelItems = new List<FuelData>();

	[Header("UI Elements")]
	public Slider fuelSlider;

	public Image mainProgressFill;

	[SerializeField]
	private List<CustomShapeFill> customShapeFills = new List<CustomShapeFill>();

	public Button cookButton;

	[Header("Slots")]
	public InventorySlot fuelSlot;

	public List<InventorySlot> inputSlots = new List<InventorySlot>();

	public InventorySlot outputSlot;

	[Header("UI References")]
	public CanvasGroup inputSlotsGroup;

	[Header("Panel System")]
	public CanvasGroup tablePanelCg;

	public CanvasGroup receiptPanelCg;

	public Button tablePanelButton;

	public Button receiptPanelButton;

	public Color selectedButtonColor = Color.white;

	public Color buttonNormalColor = Color.white;

	public Color disabledButtonColor = Color.gray;

	[Header("Craft System - Receipt Panel")]
	public GameObject craftUIPrefab;

	public Transform craftUIPrefabContainer;

	public ScrollRect craftScrollRect;

	public Transform receiptCategoriesParent;

	[HideInInspector]
	public List<CraftSystemCategorizer> receiptCategories = new List<CraftSystemCategorizer>();

	[HideInInspector]
	public CraftSystemCategorizer lastCategorizer;

	private ChemistryTableController currentTable;

	private PlayerInventory playerInventory;

	private InventoryManagerUI inventoryManager;

	private bool isOpen;

	private List<InventorySlot> inventorySlots = new List<InventorySlot>();

	private List<CraftItemUI> craftItems = new List<CraftItemUI>();

	[Header("Smooth Settings")]
	public float lerpSpeed = 10f;

	[Range(0f, 1f)]
	public float currentValue;

	public static ChemistryTableUIManager Instance { get; private set; }

	public new bool isPanelOpen => isOpen;

	public void UpdateFill()
	{
		if (mainProgressFill != null)
		{
			mainProgressFill.fillAmount = currentValue;
		}
		foreach (CustomShapeFill customShapeFill in customShapeFills)
		{
			if (customShapeFill != null)
			{
				customShapeFill.SetCurrentValue(currentValue);
			}
		}
	}

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		HidePanel();
	}

	private void Start()
	{
		inventorySlots = GetComponentsInChildren<InventorySlot>().ToList();
		inventoryManager = Object.FindObjectOfType<InventoryManagerUI>(includeInactive: true);
		if (cookButton != null)
		{
			cookButton.onClick.AddListener(OnCookButtonClicked);
		}
		if (tablePanelButton != null)
		{
			tablePanelButton.onClick.AddListener(delegate
			{
				SwitchToPanel(showTablePanel: true);
			});
		}
		if (receiptPanelButton != null)
		{
			receiptPanelButton.onClick.AddListener(delegate
			{
				SwitchToPanel(showTablePanel: false);
			});
		}
		craftItems = GetComponentsInChildren<CraftItemUI>().ToList();
		if (receiptCategoriesParent != null)
		{
			receiptCategories = receiptCategoriesParent.GetComponentsInChildren<CraftSystemCategorizer>().ToList();
		}
		if (craftScrollRect == null && craftUIPrefabContainer != null)
		{
			craftScrollRect = craftUIPrefabContainer.GetComponentInParent<ScrollRect>();
		}
		SetupSlotListeners();
		SwitchToPanel(showTablePanel: true);
	}

	private void SetupSlotListeners()
	{
		_ = fuelSlot != null;
		for (int i = 0; i < inputSlots.Count; i++)
		{
		}
		_ = outputSlot != null;
	}

	public void OpenChemistryTable(ChemistryTableController table)
	{
		currentTable = table;
		playerInventory = Object.FindObjectOfType<PlayerInventory>();
		if (currentTable == null || playerInventory == null)
		{
			Debug.LogWarning("Chemistry Table veya Player Inventory bulunamadı!");
			return;
		}
		isOpen = true;
		Singleton<MainUIManager>.Instance.OnInGamePanelOpened.Invoke(this);
		ShowPanel();
		foreach (InventorySlot inventorySlot in inventorySlots)
		{
			inventorySlot.isShowing = true;
		}
		RefreshUI();
		if (inventoryManager != null)
		{
			inventoryManager.isOpenedExternal = true;
			inventoryManager.ShowPanel();
		}
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
	}

	public void CloseChemistryTable()
	{
		isOpen = false;
		currentTable = null;
		currentValue = 0f;
		if (fuelSlider != null)
		{
			fuelSlider.value = 0f;
		}
		UpdateFill();
		Singleton<MainUIManager>.Instance.OnInGamePanelClosed.Invoke(this);
		HidePanel();
		foreach (InventorySlot inventorySlot in inventorySlots)
		{
			inventorySlot.isShowing = false;
		}
		if (inventoryManager != null)
		{
			inventoryManager.isOpenedExternal = false;
			inventoryManager.HidePanel();
		}
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void Update()
	{
		if (isOpen && !(currentTable == null))
		{
			UpdateSlotsFromTable();
			UpdateSliders();
			UpdateCookButton();
			UpdateSlotInteractability();
		}
	}

	private void UpdateSliders()
	{
		if (currentTable == null)
		{
			return;
		}
		if (fuelSlider != null)
		{
			if (currentTable.maxFuelTime > 0f)
			{
				float b = 1f - currentTable.remainingFuelTime / currentTable.maxFuelTime;
				fuelSlider.value = Mathf.Lerp(fuelSlider.value, b, Time.deltaTime * lerpSpeed);
			}
			else
			{
				fuelSlider.value = Mathf.Lerp(fuelSlider.value, 0f, Time.deltaTime * lerpSpeed);
			}
		}
		if (mainProgressFill != null)
		{
			if (currentTable.totalProductionDuration > 0f)
			{
				float b2 = currentTable.currentProductionProgress / currentTable.totalProductionDuration;
				currentValue = Mathf.Lerp(currentValue, b2, Time.deltaTime * lerpSpeed);
				UpdateFill();
			}
			else if (currentValue > 0.001f)
			{
				currentValue = Mathf.Lerp(currentValue, 0f, Time.deltaTime * lerpSpeed);
				UpdateFill();
			}
		}
	}

	private void UpdateCookButton()
	{
		if (!(cookButton == null) && !(currentTable == null))
		{
			bool flag = currentTable.CanStartCooking();
			cookButton.interactable = flag;
			Image component = cookButton.GetComponent<Image>();
			if (component != null)
			{
				component.color = (flag ? buttonNormalColor : disabledButtonColor);
			}
		}
	}

	private void UpdateSlotInteractability()
	{
		if (currentTable == null)
		{
			return;
		}
		bool isProcessing = currentTable.isProcessing;
		if (inputSlotsGroup != null)
		{
			inputSlotsGroup.interactable = !isProcessing;
			return;
		}
		foreach (InventorySlot inputSlot in inputSlots)
		{
			if (inputSlot != null)
			{
				CanvasGroup component = inputSlot.GetComponent<CanvasGroup>();
				if (component != null)
				{
					component.interactable = !isProcessing;
				}
			}
		}
	}

	private void OnCookButtonClicked()
	{
		if (currentTable == null)
		{
			return;
		}
		if (currentTable.CanStartCooking())
		{
			currentTable.TryStartCooking();
			if (NetworkSoundPlayer.Instance != null)
			{
				NetworkSoundPlayer.Instance.PlaySound2DLocal(GameAudios.GeneralCraftSound);
			}
			Debug.Log("Pişirme başlatıldı!");
		}
		else
		{
			Debug.LogWarning("Pişirme başlatılamıyor!");
		}
	}

	private void RefreshUI()
	{
		LoadTableDataToUI();
		UpdateSliders();
		UpdateCookButton();
		UpdateSlotInteractability();
	}

	private void LoadTableDataToUI()
	{
		if (currentTable == null)
		{
			return;
		}
		for (int i = 0; i < inputSlots.Count && i < currentTable.inputSlotCount; i++)
		{
			if (i >= currentTable.inputItems.Count)
			{
				continue;
			}
			string text = currentTable.inputItems[i];
			int num = currentTable.inputItemCounts[i];
			if (!string.IsNullOrEmpty(text) && num > 0)
			{
				CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(text);
				if (collectableItemFromName != null)
				{
					InventorySlotsData data = new InventorySlotsData
					{
						slotID = inputSlots[i].inventoryID,
						item = collectableItemFromName,
						itemCountInSlot = num,
						currentDurability = (collectableItemFromName.hasDurability ? collectableItemFromName.maxDurabilityCapacity : 0f),
						currentMagazineCount = 0
					};
					inputSlots[i].InventoryItem.UpdateInventoryData(data, silent: true);
					inputSlots[i].HasItem = true;
					inputSlots[i].inventoryCount = num;
				}
			}
			else
			{
				inputSlots[i].Clear(silent: true);
			}
		}
		if (fuelSlot != null && currentTable.fuelSlotItems.Count > 0)
		{
			string itemName = currentTable.fuelSlotItems[0];
			int count = currentTable.fuelSlotItems.Count;
			CollectableItemData collectableItemFromName2 = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(itemName);
			if (collectableItemFromName2 != null)
			{
				InventorySlotsData data2 = new InventorySlotsData
				{
					slotID = fuelSlot.inventoryID,
					item = collectableItemFromName2,
					itemCountInSlot = count,
					currentDurability = (collectableItemFromName2.hasDurability ? collectableItemFromName2.maxDurabilityCapacity : 0f),
					currentMagazineCount = 0
				};
				fuelSlot.InventoryItem.UpdateInventoryData(data2, silent: true);
				fuelSlot.HasItem = true;
				fuelSlot.inventoryCount = count;
			}
		}
		else if (fuelSlot != null)
		{
			fuelSlot.Clear(silent: true);
		}
		if (outputSlot != null && currentTable.HasOutput())
		{
			CollectableItemData outputItemData = currentTable.GetOutputItemData();
			if (outputItemData != null)
			{
				InventorySlotsData data3 = new InventorySlotsData
				{
					slotID = outputSlot.inventoryID,
					item = outputItemData,
					itemCountInSlot = currentTable.outputItemCount,
					currentDurability = (outputItemData.hasDurability ? outputItemData.maxDurabilityCapacity : 0f),
					currentMagazineCount = 0
				};
				outputSlot.InventoryItem.UpdateInventoryData(data3, silent: true);
				outputSlot.HasItem = true;
				outputSlot.inventoryCount = currentTable.outputItemCount;
			}
		}
		else if (outputSlot != null)
		{
			outputSlot.Clear(silent: true);
		}
	}

	private void UpdateSlotsFromTable()
	{
		if (currentTable == null)
		{
			return;
		}
		for (int i = 0; i < inputSlots.Count && i < currentTable.inputSlotCount; i++)
		{
			if (i >= currentTable.inputItems.Count)
			{
				continue;
			}
			InventorySlot inventorySlot = inputSlots[i];
			if (inventorySlot.InventoryItem != null && inventorySlot.InventoryItem.IsDragging)
			{
				continue;
			}
			string text = currentTable.inputItems[i];
			int num = currentTable.inputItemCounts[i];
			string text2 = ((inventorySlot.HasItem && inventorySlot.InventoryItem.collectableItemData != null) ? inventorySlot.InventoryItem.collectableItemData.itemName : "");
			int num2 = (inventorySlot.HasItem ? inventorySlot.InventoryItem.collectedCount : 0);
			if (!(text != text2) && num == num2)
			{
				continue;
			}
			if (!string.IsNullOrEmpty(text) && num > 0)
			{
				CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(text);
				if (collectableItemFromName != null)
				{
					InventorySlotsData data = new InventorySlotsData
					{
						slotID = inventorySlot.inventoryID,
						item = collectableItemFromName,
						itemCountInSlot = num,
						currentDurability = (collectableItemFromName.hasDurability ? collectableItemFromName.maxDurabilityCapacity : 0f),
						currentMagazineCount = 0
					};
					inventorySlot.InventoryItem.UpdateInventoryData(data, silent: true);
					inventorySlot.HasItem = true;
					inventorySlot.inventoryCount = num;
				}
			}
			else
			{
				inventorySlot.Clear(silent: true);
			}
		}
		if (fuelSlot != null && (fuelSlot.InventoryItem == null || !fuelSlot.InventoryItem.IsDragging))
		{
			int count = currentTable.fuelSlotItems.Count;
			int num3 = (fuelSlot.HasItem ? fuelSlot.InventoryItem.collectedCount : 0);
			if (count != num3)
			{
				if (count > 0)
				{
					string itemName = currentTable.fuelSlotItems[0];
					CollectableItemData collectableItemFromName2 = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(itemName);
					if (collectableItemFromName2 != null)
					{
						InventorySlotsData data2 = new InventorySlotsData
						{
							slotID = fuelSlot.inventoryID,
							item = collectableItemFromName2,
							itemCountInSlot = count,
							currentDurability = (collectableItemFromName2.hasDurability ? collectableItemFromName2.maxDurabilityCapacity : 0f),
							currentMagazineCount = 0
						};
						fuelSlot.InventoryItem.UpdateInventoryData(data2, silent: true);
						fuelSlot.HasItem = true;
						fuelSlot.inventoryCount = count;
					}
				}
				else
				{
					fuelSlot.Clear(silent: true);
				}
			}
		}
		if (!(outputSlot != null) || (!(outputSlot.InventoryItem == null) && outputSlot.InventoryItem.IsDragging))
		{
			return;
		}
		bool num4 = currentTable.HasOutput();
		bool hasItem = outputSlot.HasItem;
		if (num4)
		{
			string outputItemName = currentTable.outputItemName;
			int outputItemCount = currentTable.outputItemCount;
			string text3 = ((hasItem && outputSlot.InventoryItem.collectableItemData != null) ? outputSlot.InventoryItem.collectableItemData.itemName : "");
			int num5 = (hasItem ? outputSlot.InventoryItem.collectedCount : 0);
			if (outputItemName != text3 || outputItemCount != num5)
			{
				CollectableItemData outputItemData = currentTable.GetOutputItemData();
				if (outputItemData != null)
				{
					InventorySlotsData data3 = new InventorySlotsData
					{
						slotID = outputSlot.inventoryID,
						item = outputItemData,
						itemCountInSlot = outputItemCount,
						currentDurability = (outputItemData.hasDurability ? outputItemData.maxDurabilityCapacity : 0f),
						currentMagazineCount = 0
					};
					outputSlot.InventoryItem.UpdateInventoryData(data3, silent: true);
					outputSlot.HasItem = true;
					outputSlot.inventoryCount = outputItemCount;
				}
			}
		}
		else if (hasItem)
		{
			outputSlot.Clear(silent: true);
		}
	}

	public void OnFuelSlotItemAdded(CollectableItemData item, int count)
	{
		if (!(currentTable == null) && currentTable.IsFuelItem(item) && currentTable.CanAddFuel())
		{
			currentTable.TryAddFuel(item.itemName, count);
			if (playerInventory != null)
			{
				playerInventory.AddItemInventory(item, -count);
			}
		}
	}

	public void OnFuelSlotItemRemoved()
	{
		if (!(currentTable == null) && currentTable.HasFuel() && !currentTable.isProcessing)
		{
			CollectableItemData fuelItemData = currentTable.GetFuelItemData();
			if (fuelItemData != null && playerInventory != null)
			{
				playerInventory.AddItemInventory(fuelItemData, 1);
				currentTable.TryRemoveFuel();
			}
		}
	}

	public void OnInputSlotItemAdded(int slotIndex, CollectableItemData item, int count)
	{
		if (!(currentTable == null) && !currentTable.isProcessing)
		{
			currentTable.TryAddInputItem(slotIndex, item.itemName, count);
			if (playerInventory != null)
			{
				playerInventory.AddItemInventory(item, -count);
			}
		}
	}

	public void OnInputSlotItemRemoved(int slotIndex)
	{
		if (currentTable == null || currentTable.isProcessing || slotIndex < 0 || slotIndex >= currentTable.inputItems.Count)
		{
			return;
		}
		string text = currentTable.inputItems[slotIndex];
		int num = currentTable.inputItemCounts[slotIndex];
		if (!string.IsNullOrEmpty(text) && num > 0)
		{
			CollectableItemData collectableItemFromName = NetworkSceneObjectSpawner.Instance.GetCollectableItemFromName(text);
			if (playerInventory != null && collectableItemFromName != null)
			{
				playerInventory.AddItemInventory(collectableItemFromName, num);
			}
			currentTable.TryRemoveInputItem(slotIndex);
		}
	}

	public void OnOutputSlotItemTaken()
	{
		if (!(currentTable == null) && currentTable.HasOutput())
		{
			CollectableItemData outputItemData = currentTable.GetOutputItemData();
			int outputItemCount = currentTable.outputItemCount;
			if (outputItemData != null && playerInventory != null)
			{
				playerInventory.AddItemInventory(outputItemData, outputItemCount);
				currentTable.TryTakeOutput();
			}
		}
	}

	public override void HidePanel()
	{
		base.HidePanel();
		isOpen = false;
	}

	public ChemistryTableController GetCurrentTable()
	{
		return currentTable;
	}

	public void OnSlotsChanged()
	{
		if (!(currentTable == null) && isPanelOpen)
		{
			SaveChemistryChanges();
		}
	}

	private void SaveChemistryChanges()
	{
		if (currentTable == null)
		{
			return;
		}
		Debug.Log("Chemistry Table değişiklikleri kaydediliyor...");
		for (int i = 0; i < inputSlots.Count && i < currentTable.inputSlotCount; i++)
		{
			InventorySlot inventorySlot = inputSlots[i];
			if (inventorySlot.InventoryItem != null && inventorySlot.InventoryItem.collectableItemData != null && inventorySlot.InventoryItem.collectedCount > 0)
			{
				currentTable.TryAddInputItem(i, inventorySlot.InventoryItem.collectableItemData.itemName, inventorySlot.InventoryItem.collectedCount);
			}
			else
			{
				currentTable.TryRemoveInputItem(i);
			}
		}
		if (fuelSlot != null)
		{
			if (fuelSlot.InventoryItem != null && fuelSlot.InventoryItem.collectableItemData != null && fuelSlot.HasItem)
			{
				int collectedCount = fuelSlot.InventoryItem.collectedCount;
				int count = currentTable.fuelSlotItems.Count;
				if (collectedCount > count)
				{
					int count2 = collectedCount - count;
					currentTable.TryAddFuel(fuelSlot.InventoryItem.collectableItemData.itemName, count2);
				}
				else if (collectedCount < count)
				{
					int num = count - collectedCount;
					for (int j = 0; j < num; j++)
					{
						currentTable.TryRemoveFuel();
					}
				}
			}
			else if (!fuelSlot.HasItem && currentTable.fuelSlotItems.Count > 0)
			{
				int count3 = currentTable.fuelSlotItems.Count;
				for (int k = 0; k < count3; k++)
				{
					currentTable.TryRemoveFuel();
				}
			}
		}
		if (outputSlot != null && !outputSlot.HasItem && currentTable.HasOutput())
		{
			currentTable.TryTakeOutput();
		}
	}

	private void SwitchToPanel(bool showTablePanel)
	{
		if (tablePanelCg != null && receiptPanelCg != null)
		{
			tablePanelCg.alpha = (showTablePanel ? 1 : 0);
			tablePanelCg.interactable = showTablePanel;
			tablePanelCg.blocksRaycasts = showTablePanel;
			receiptPanelCg.alpha = ((!showTablePanel) ? 1 : 0);
			receiptPanelCg.interactable = !showTablePanel;
			receiptPanelCg.blocksRaycasts = !showTablePanel;
		}
		if (tablePanelButton != null)
		{
			Image component = tablePanelButton.GetComponent<Image>();
			if (component != null)
			{
				component.color = (showTablePanel ? selectedButtonColor : disabledButtonColor);
			}
		}
		if (receiptPanelButton != null)
		{
			Image component2 = receiptPanelButton.GetComponent<Image>();
			if (component2 != null)
			{
				component2.color = (showTablePanel ? disabledButtonColor : selectedButtonColor);
			}
		}
		if (showTablePanel || receiptCategories.Count <= 0)
		{
			return;
		}
		foreach (CraftSystemCategorizer receiptCategory in receiptCategories)
		{
			if (receiptCategory != null)
			{
				receiptCategory.SetSelected(selected: false);
			}
		}
		SetCategoryItems(receiptCategories[0].itemDatas);
		lastCategorizer = receiptCategories[0];
		receiptCategories[0].SetSelected(selected: true);
	}

	public void SetCategoryItems(List<CollectableItemData> craftingObjects)
	{
		List<CollectableItemData> list;
		if (TrainGameManager.Instance != null && TrainGameManager.Instance.currentGameMode == GameMode.Creative)
		{
			list = craftingObjects;
		}
		else
		{
			List<CollectableItemData> first = craftingObjects.Where((CollectableItemData x) => x.isLearned).ToList();
			List<CollectableItemData> second = craftingObjects.Where((CollectableItemData x) => !x.isLearned).ToList();
			list = first.Concat(second).ToList();
		}
		while (craftItems.Count < list.Count)
		{
			CraftItemUI component = Object.Instantiate(craftUIPrefab, craftUIPrefabContainer).GetComponent<CraftItemUI>();
			if (component != null)
			{
				craftItems.Add(component);
				if (component.craftButton != null)
				{
					component.craftButton.gameObject.SetActive(value: false);
				}
				continue;
			}
			Debug.LogError("craftUIPrefab'da CraftItemUI component'i bulunamadı!");
			break;
		}
		for (int num = 0; num < craftItems.Count; num++)
		{
			craftItems[num].gameObject.SetActive(value: false);
		}
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			craftItems[num2].gameObject.SetActive(value: true);
			craftItems[num2].SetNeededsPart(list[num2]);
			craftItems[num2].collectableItemData = list[num2];
			if (craftItems[num2].craftButton != null)
			{
				craftItems[num2].craftButton.gameObject.SetActive(value: false);
			}
		}
		if (craftScrollRect != null)
		{
			craftScrollRect.verticalNormalizedPosition = 1f;
			craftScrollRect.horizontalNormalizedPosition = 0f;
		}
	}

	public void OnCategoryChanged(CraftSystemCategorizer newCategory)
	{
		lastCategorizer = newCategory;
		SetCategoryItems(newCategory.itemDatas);
	}
}
