using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class ResearchUIManager : UIPanelBase
{
	public Button researchButton;

	public InventorySlot researchSlot;

	[SerializeField]
	private GameObject researchedText;

	public GameObject objectLayoutGroup;

	public ScrollRect researchScrollRect;

	public GameObject objectToLearnedItem;

	[HideInInspector]
	public ResearchSystemCategorizer lastCategorizer;

	public List<ResearchSystemCategorizer> categorizers = new List<ResearchSystemCategorizer>();

	public List<ResearcheableUIItem> researchableUIItems = new List<ResearcheableUIItem>();

	public Color selectedButtonColor;

	public Color buttonNormalColor;

	[Header("Category Unlock Panel")]
	[SerializeField]
	private GameObject unlockPanel;

	[SerializeField]
	private TextMeshProUGUI unlockTitleText;

	[SerializeField]
	public List<CraftNeededPartUI> unlockCostPartUIs = new List<CraftNeededPartUI>();

	[SerializeField]
	private Button unlockButton;

	private DataManager dataManager;

	private InventoryManagerUI inventoryManager;

	private List<InventorySlot> inventorySlots = new List<InventorySlot>();

	private PlayerInventory playerInventory;

	private ResearchSystemCategorizer currentUnlockCategorizer;

	private List<CostData> currentUnlockCostData = new List<CostData>();

	private bool isUnlockPanelOpen;

	public static ResearchUIManager Instance { get; private set; }

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
	}

	private void Start()
	{
		inventoryManager = TrainGameManager.Instance.playerInventoryManagerUI;
		inventorySlots = GetComponentsInChildren<InventorySlot>().ToList();
		dataManager = Singleton<DataManager>.Instance;
		researchButton.onClick.AddListener(Research);
		LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
		if (unlockButton != null)
		{
			unlockButton.onClick.AddListener(UnlockCategory);
		}
		if (researchScrollRect == null)
		{
			researchScrollRect = objectLayoutGroup.GetComponentInParent<ScrollRect>();
		}
		if (categorizers.Count <= 0)
		{
			return;
		}
		foreach (ResearchSystemCategorizer categorizer in categorizers)
		{
			if (categorizer != null)
			{
				categorizer.SetSelected(selected: false);
			}
		}
		if (categorizers[0].isUnlocked || categorizers[0].isUnlockedByDefault)
		{
			SetCategoryItems(categorizers[0].researchObjects);
		}
		lastCategorizer = categorizers[0];
		categorizers[0].SetSelected(selected: true);
	}

	private void Update()
	{
		if (isPanelOpen)
		{
			CheckResearchSlotStatus();
			if (isUnlockPanelOpen)
			{
				CheckUnlockStatus();
			}
		}
	}

	private void CheckResearchSlotStatus()
	{
		if (researchSlot != null && researchSlot.InventoryItem != null)
		{
			SetResearchStatus();
		}
	}

	public void ChangePanelActive()
	{
		if (!isPanelOpen)
		{
			if (lastCategorizer == null && categorizers.Count > 0)
			{
				foreach (ResearchSystemCategorizer categorizer in categorizers)
				{
					if (categorizer != null)
					{
						categorizer.SetSelected(selected: false);
					}
				}
				lastCategorizer = categorizers[0];
				categorizers[0].SetSelected(selected: true);
				if (categorizers[0].isUnlocked || categorizers[0].isUnlockedByDefault)
				{
					SetCategoryItems(categorizers[0].researchObjects);
				}
			}
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

	public void SetCategoryItems(List<CollectableItemData> researchObjects)
	{
		List<CollectableItemData> list = (from item in researchObjects
			where item.costData != null && item.costData.Count > 0
			orderby item.isLearned ? 1 : 0
			select item).ToList();
		while (researchableUIItems.Count < list.Count)
		{
			ResearcheableUIItem component = Object.Instantiate(objectToLearnedItem, objectLayoutGroup.transform).GetComponent<ResearcheableUIItem>();
			if (component != null)
			{
				researchableUIItems.Add(component);
				continue;
			}
			Debug.LogError("objectToLearnedItem'da ResearcheableUIItem component'i bulunamadı!");
			break;
		}
		for (int num = 0; num < list.Count; num++)
		{
			researchableUIItems[num].gameObject.SetActive(value: true);
			researchableUIItems[num].collectableItemData = list[num];
			researchableUIItems[num].SetPanel();
		}
		for (int num2 = list.Count; num2 < researchableUIItems.Count; num2++)
		{
			researchableUIItems[num2].gameObject.SetActive(value: false);
		}
		if (researchScrollRect != null)
		{
			researchScrollRect.verticalNormalizedPosition = 1f;
			researchScrollRect.horizontalNormalizedPosition = 0f;
		}
	}

	private void HideAllCategoryItems()
	{
		for (int i = 0; i < researchableUIItems.Count; i++)
		{
			researchableUIItems[i].gameObject.SetActive(value: false);
		}
	}

	public void ShowUnlockPanel(ResearchSystemCategorizer categorizer)
	{
		if (unlockPanel == null)
		{
			return;
		}
		if (playerInventory == null && TrainGameManager.Instance != null && TrainGameManager.Instance.mainPlayer != null)
		{
			playerInventory = TrainGameManager.Instance.mainPlayer.GetComponent<PlayerInventory>();
		}
		currentUnlockCategorizer = categorizer;
		currentUnlockCostData.Clear();
		isUnlockPanelOpen = true;
		unlockButton.interactable = false;
		HideAllCategoryItems();
		unlockPanel.SetActive(value: true);
		if (unlockTitleText != null)
		{
			unlockTitleText.SetText(categorizer.categoryName);
		}
		int num = 0;
		List<CostData> unlockCostData = categorizer.unlockCostData;
		foreach (CraftNeededPartUI unlockCostPartUI in unlockCostPartUIs)
		{
			if (num >= unlockCostData.Count)
			{
				unlockCostPartUI.gameObject.SetActive(value: false);
			}
			else
			{
				unlockCostPartUI.gameObject.SetActive(value: true);
				CostData costData = unlockCostData[num];
				currentUnlockCostData.Add(costData);
				int inventoryCount = GetInventoryCount(costData.item);
				unlockCostPartUI.SetPanel(costData, inventoryCount);
			}
			num++;
		}
		CheckUnlockStatus();
	}

	public void HideUnlockPanel()
	{
		if (unlockPanel != null)
		{
			unlockPanel.SetActive(value: false);
		}
		isUnlockPanelOpen = false;
		currentUnlockCategorizer = null;
		currentUnlockCostData.Clear();
	}

	private void CheckUnlockStatus()
	{
		if (unlockButton == null || currentUnlockCategorizer == null)
		{
			return;
		}
		if (playerInventory == null && TrainGameManager.Instance != null && TrainGameManager.Instance.mainPlayer != null)
		{
			playerInventory = TrainGameManager.Instance.mainPlayer.GetComponent<PlayerInventory>();
		}
		bool interactable = true;
		for (int i = 0; i < currentUnlockCostData.Count && i < unlockCostPartUIs.Count; i++)
		{
			if (unlockCostPartUIs[i].gameObject.activeInHierarchy)
			{
				CostData costData = currentUnlockCostData[i];
				int inventoryCount = GetInventoryCount(costData.item);
				unlockCostPartUIs[i].SetPanel(costData, inventoryCount);
				if (inventoryCount < costData.cost)
				{
					interactable = false;
				}
			}
		}
		unlockButton.interactable = interactable;
	}

	private void UnlockCategory()
	{
		if (currentUnlockCategorizer == null)
		{
			return;
		}
		if (playerInventory == null && TrainGameManager.Instance != null && TrainGameManager.Instance.mainPlayer != null)
		{
			playerInventory = TrainGameManager.Instance.mainPlayer.GetComponent<PlayerInventory>();
		}
		if (playerInventory == null)
		{
			return;
		}
		if (!(TrainGameManager.Instance != null) || TrainGameManager.Instance.currentGameMode != GameMode.Creative)
		{
			foreach (CostData currentUnlockCostDatum in currentUnlockCostData)
			{
				if (GetInventoryCount(currentUnlockCostDatum.item) < currentUnlockCostDatum.cost)
				{
					return;
				}
			}
			foreach (CostData currentUnlockCostDatum2 in currentUnlockCostData)
			{
				playerInventory.AddItemInventory(currentUnlockCostDatum2.item, -currentUnlockCostDatum2.cost);
			}
		}
		ResearchSystemCategorizer researchSystemCategorizer = currentUnlockCategorizer;
		currentUnlockCategorizer.isUnlocked = true;
		if (CollectableDataSaver.Instance != null)
		{
			CollectableDataSaver.Instance.SetCategoryUnlocked(currentUnlockCategorizer.categoryName, unlocked: true);
		}
		HideUnlockPanel();
		SetCategoryItems(researchSystemCategorizer.researchObjects);
	}

	private int GetInventoryCount(CollectableItemData item)
	{
		if (playerInventory == null || item == null)
		{
			return 0;
		}
		return playerInventory.inventoryData.Find((PlayerInventoryData x) => x.item == item)?.itemCollectedCount ?? 0;
	}

	public new void ShowPanel()
	{
		if (inventoryManager == null)
		{
			inventoryManager = TrainGameManager.Instance.playerInventoryManagerUI;
		}
		base.ShowPanel();
		foreach (InventorySlot inventorySlot in inventorySlots)
		{
			inventorySlot.isShowing = true;
		}
		inventoryManager.isOpenedExternal = true;
		inventoryManager.ShowPanel();
		SetResearchStatus();
		UpdateReseachStatus();
		if (CollectableDataSaver.Instance != null)
		{
			CollectableDataSaver.Instance.ApplyStatesToItems();
		}
		RefreshCurrentCategory();
	}

	public new void HidePanel()
	{
		base.HidePanel();
		foreach (InventorySlot inventorySlot in inventorySlots)
		{
			inventorySlot.isShowing = false;
		}
		inventoryManager.isOpenedExternal = false;
		inventoryManager.HidePanel();
		HideUnlockPanel();
	}

	public void RefreshCurrentCategory()
	{
		if (lastCategorizer == null)
		{
			return;
		}
		if (lastCategorizer.isUnlocked)
		{
			if (isUnlockPanelOpen)
			{
				HideUnlockPanel();
				SetCategoryItems(lastCategorizer.researchObjects);
			}
		}
		else if (!isUnlockPanelOpen)
		{
			ShowUnlockPanel(lastCategorizer);
		}
	}

	private void OnDestroy()
	{
		LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
	}

	private void OnLocaleChanged(Locale locale)
	{
		foreach (ResearcheableUIItem researchableUIItem in researchableUIItems)
		{
			if (researchableUIItem.gameObject.activeInHierarchy)
			{
				researchableUIItem.SetItemInfo();
			}
		}
	}

	public void UpdateReseachStatus()
	{
		foreach (ResearcheableUIItem researchableUIItem in researchableUIItems)
		{
			if (researchableUIItem.gameObject.activeInHierarchy)
			{
				researchableUIItem.CheckResearchStatus();
			}
		}
	}

	public void SetResearchStatus()
	{
		if (researchSlot == null || researchSlot.InventoryItem == null)
		{
			researchedText.SetActive(value: false);
			researchButton.interactable = false;
			return;
		}
		CollectableItemData collectableItemData = researchSlot.InventoryItem.collectableItemData;
		if (collectableItemData != null)
		{
			Debug.Log(researchSlot.InventoryItem.collectableItemData.itemName);
		}
		if (collectableItemData == null)
		{
			researchedText.SetActive(value: false);
			researchButton.interactable = false;
		}
		else if (collectableItemData.isOpenedInStart)
		{
			researchedText.SetActive(value: true);
			researchButton.interactable = false;
		}
		else if (!collectableItemData.isResearched)
		{
			researchButton.interactable = true;
			researchedText.SetActive(value: false);
		}
		else if (collectableItemData.isResearched)
		{
			researchedText.SetActive(value: true);
			researchButton.interactable = false;
		}
	}

	private void Research()
	{
		if (!(researchSlot.InventoryItem.collectableItemData == null))
		{
			Debug.Log("Item Researched: " + researchSlot.InventoryItem.collectableItemData.itemName);
			CollectableDataSaver.Instance?.SetItemResearched(researchSlot.InventoryItem.collectableItemData.itemName, researched: true);
			researchSlot.InventoryItem.DecreaseItemCount(1);
			SetResearchStatus();
			UpdateReseachStatus();
		}
	}
}
