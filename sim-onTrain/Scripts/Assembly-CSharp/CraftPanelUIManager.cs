using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CraftPanelUIManager : UIPanelBase
{
	[Header("UI Prefabs")]
	public GameObject craftUIPrefab;

	public Transform craftUIPrefabContainer;

	public ScrollRect craftScrollRect;

	[Header("Panel Texts")]
	public GameObject simpleCraftText;

	public GameObject craftText;

	public GameObject gunCraftText;

	[Header("Category Parents")]
	public Transform simpleCraftCategoriesParent;

	public Transform mainCraftCategoriesParent;

	public Transform gunCraftCategoriesParent;

	private InventoryManagerUI inventoryManager;

	private List<InventorySlot> inventorySlots = new List<InventorySlot>();

	private List<CraftItemUI> craftItems = new List<CraftItemUI>();

	[HideInInspector]
	public List<CraftSystemCategorizer> mainCraftCategories = new List<CraftSystemCategorizer>();

	[HideInInspector]
	public List<CraftSystemCategorizer> simpleCraftCategories = new List<CraftSystemCategorizer>();

	[HideInInspector]
	public List<CraftSystemCategorizer> gunCraftCategories = new List<CraftSystemCategorizer>();

	[HideInInspector]
	public CraftSystemCategorizer lastCagegorizer;

	private CraftMode currentCraftMode;

	public Color selectedButtonColor;

	public Color buttonNormalColor;

	private readonly List<CollectableItemData> sortedItemsBuffer = new List<CollectableItemData>();

	private void Start()
	{
		Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.AddListener(delegate(TSPlayerController player)
		{
			if (player.isLocalPlayer)
			{
				inventoryManager = TrainGameManager.instance.playerInventoryManagerUI;
			}
		});
		craftItems = GetComponentsInChildren<CraftItemUI>().ToList();
		simpleCraftCategories = simpleCraftCategoriesParent.GetComponentsInChildren<CraftSystemCategorizer>().ToList();
		mainCraftCategories = mainCraftCategoriesParent.GetComponentsInChildren<CraftSystemCategorizer>().ToList();
		gunCraftCategories = gunCraftCategoriesParent.GetComponentsInChildren<CraftSystemCategorizer>().ToList();
		inventorySlots = GetComponentsInChildren<InventorySlot>().ToList();
		if (craftScrollRect == null)
		{
			craftScrollRect = craftUIPrefabContainer.GetComponentInParent<ScrollRect>();
		}
	}

	private void Update()
	{
		if (ChatPanelController.isInputFocused)
		{
			return;
		}
		if (isPanelOpen && Input.GetKeyUp(Singleton<UserPrefencesManager>.Instance.keyData.SimpleCraftKey) && currentCraftMode == CraftMode.SimpleCraft)
		{
			ChangePanelActive(CraftMode.SimpleCraft);
			return;
		}
		KeyData keyData = Singleton<UserPrefencesManager>.Instance.keyData;
		if (!isPanelOpen && Singleton<MainUIManager>.Instance.isInGamePanelOpened && Input.GetKeyUp(keyData.SimpleCraftKey) && keyData.SimpleCraftKey != keyData.InventoryKey)
		{
			ChangePanelActive(CraftMode.SimpleCraft);
		}
		else if (TrainGameManager.isInputActive)
		{
			if (Input.GetKeyUp(keyData.SimpleCraftKey) && keyData.SimpleCraftKey != keyData.InventoryKey)
			{
				ChangePanelActive(CraftMode.SimpleCraft);
			}
			if (Input.GetKeyUp(keyData.InventoryKey) && Singleton<MainUIManager>.Instance.panelClosedFrame != Time.frameCount)
			{
				ChangePanelActive(CraftMode.SimpleCraft);
			}
		}
	}

	public void SetCategoryItems(List<CollectableItemData> craftingObjects)
	{
		CraftItemUI.RefreshInventoryCache();
		List<CollectableItemData> list;
		if (TrainGameManager.Instance != null && TrainGameManager.Instance.currentGameMode == GameMode.Creative)
		{
			list = craftingObjects;
		}
		else
		{
			sortedItemsBuffer.Clear();
			for (int i = 0; i < craftingObjects.Count; i++)
			{
				if (craftingObjects[i].isLearned)
				{
					sortedItemsBuffer.Add(craftingObjects[i]);
				}
			}
			for (int j = 0; j < craftingObjects.Count; j++)
			{
				if (!craftingObjects[j].isLearned)
				{
					sortedItemsBuffer.Add(craftingObjects[j]);
				}
			}
			list = sortedItemsBuffer;
		}
		while (craftItems.Count < list.Count)
		{
			CraftItemUI component = Object.Instantiate(craftUIPrefab, craftUIPrefabContainer).GetComponent<CraftItemUI>();
			if (component != null)
			{
				craftItems.Add(component);
				continue;
			}
			Debug.LogError("craftUIPrefab'da CraftItemUI component'i bulunamadı!");
			break;
		}
		for (int k = 0; k < craftItems.Count; k++)
		{
			craftItems[k].gameObject.SetActive(value: false);
		}
		for (int l = 0; l < list.Count; l++)
		{
			craftItems[l].gameObject.SetActive(value: true);
			craftItems[l].SetNeededsPart(list[l]);
			craftItems[l].collectableItemData = list[l];
		}
		if (craftScrollRect != null)
		{
			craftScrollRect.verticalNormalizedPosition = 1f;
			craftScrollRect.horizontalNormalizedPosition = 0f;
		}
	}

	private void SetLayoutForCraftMode(CraftMode craftMode)
	{
		currentCraftMode = craftMode;
		simpleCraftText.SetActive(craftMode == CraftMode.SimpleCraft);
		craftText.SetActive(craftMode == CraftMode.MainCraft);
		gunCraftText.SetActive(craftMode == CraftMode.GunCraft);
		simpleCraftCategoriesParent.gameObject.SetActive(craftMode == CraftMode.SimpleCraft);
		mainCraftCategoriesParent.gameObject.SetActive(craftMode == CraftMode.MainCraft);
		gunCraftCategoriesParent.gameObject.SetActive(craftMode == CraftMode.GunCraft);
		switch (craftMode)
		{
		case CraftMode.SimpleCraft:
			if (simpleCraftCategories.Count > 0)
			{
				foreach (CraftSystemCategorizer simpleCraftCategory in simpleCraftCategories)
				{
					if (simpleCraftCategory != null)
					{
						simpleCraftCategory.SetSelected(selected: false);
					}
				}
				SetCategoryItems(simpleCraftCategories[0].itemDatas);
				lastCagegorizer = simpleCraftCategories[0];
				simpleCraftCategories[0].SetSelected(selected: true);
			}
			else
			{
				Debug.LogWarning("Simple craft categories bulunamadı!");
				SetCategoryItems(new List<CollectableItemData>());
			}
			break;
		case CraftMode.MainCraft:
			if (mainCraftCategories.Count > 0)
			{
				foreach (CraftSystemCategorizer mainCraftCategory in mainCraftCategories)
				{
					if (mainCraftCategory != null)
					{
						mainCraftCategory.SetSelected(selected: false);
					}
				}
				SetCategoryItems(mainCraftCategories[0].itemDatas);
				lastCagegorizer = mainCraftCategories[0];
				mainCraftCategories[0].SetSelected(selected: true);
			}
			else
			{
				Debug.LogWarning("Main craft categories bulunamadı!");
				SetCategoryItems(new List<CollectableItemData>());
			}
			break;
		case CraftMode.GunCraft:
			if (gunCraftCategories.Count > 0)
			{
				foreach (CraftSystemCategorizer gunCraftCategory in gunCraftCategories)
				{
					if (gunCraftCategory != null)
					{
						gunCraftCategory.SetSelected(selected: false);
					}
				}
				SetCategoryItems(gunCraftCategories[0].itemDatas);
				lastCagegorizer = gunCraftCategories[0];
				gunCraftCategories[0].SetSelected(selected: true);
			}
			else
			{
				Debug.LogWarning("Gun craft categories bulunamadı!");
				SetCategoryItems(new List<CollectableItemData>());
			}
			break;
		}
	}

	public void ChangePanelActive(CraftMode craftMode = CraftMode.MainCraft)
	{
		if (!isPanelOpen)
		{
			SetLayoutForCraftMode(craftMode);
			Singleton<MainUIManager>.Instance.OnInGamePanelOpened.Invoke(this);
			Cursor.lockState = CursorLockMode.Confined;
			ShowPanel();
			foreach (InventorySlot inventorySlot in inventorySlots)
			{
				inventorySlot.isShowing = true;
			}
			if (inventoryManager != null)
			{
				inventoryManager.isOpenedExternal = true;
				inventoryManager.ShowPanel();
			}
			return;
		}
		Cursor.lockState = CursorLockMode.Locked;
		Singleton<MainUIManager>.Instance.OnInGamePanelClosed.Invoke(this);
		HidePanel();
		foreach (InventorySlot inventorySlot2 in inventorySlots)
		{
			inventorySlot2.isShowing = false;
		}
		if (inventoryManager != null)
		{
			inventoryManager.isOpenedExternal = false;
			inventoryManager.HidePanel();
		}
	}

	public void ChangePanelActive(bool simpleCraft)
	{
		ChangePanelActive(simpleCraft ? CraftMode.SimpleCraft : CraftMode.MainCraft);
	}

	public void OnCategoryChanged(CraftSystemCategorizer newCategory)
	{
		lastCagegorizer = newCategory;
		SetCategoryItems(newCategory.itemDatas);
	}

	public void SwitchCraftMode(CraftMode newCraftMode)
	{
		if (isPanelOpen && currentCraftMode != newCraftMode)
		{
			SetLayoutForCraftMode(newCraftMode);
		}
	}
}
