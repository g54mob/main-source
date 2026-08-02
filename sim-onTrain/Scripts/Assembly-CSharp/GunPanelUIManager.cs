using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GunPanelUIManager : UIPanelBase
{
	[Header("UI Prefabs")]
	public GameObject craftUIPrefab;

	public Transform craftUIPrefabContainer;

	public ScrollRect craftScrollRect;

	[Header("Panel Texts")]
	public GameObject craftText;

	[Header("Category Parents")]
	public Transform mainCraftCategoriesParent;

	private InventoryManagerUI inventoryManager;

	private List<InventorySlot> inventorySlots = new List<InventorySlot>();

	private List<CraftItemUI> craftItems = new List<CraftItemUI>();

	[HideInInspector]
	public List<CraftSystemCategorizer> mainCraftCategories = new List<CraftSystemCategorizer>();

	[HideInInspector]
	public CraftSystemCategorizer lastCagegorizer;

	public Color selectedButtonColor;

	public Color buttonNormalColor;

	private void Start()
	{
		craftItems = GetComponentsInChildren<CraftItemUI>().ToList();
		mainCraftCategories = mainCraftCategoriesParent.GetComponentsInChildren<CraftSystemCategorizer>().ToList();
		inventoryManager = Object.FindObjectOfType<InventoryManagerUI>(includeInactive: true);
		inventorySlots = GetComponentsInChildren<InventorySlot>().ToList();
		if (craftScrollRect == null)
		{
			craftScrollRect = craftUIPrefabContainer.GetComponentInParent<ScrollRect>();
		}
	}

	public void SetCategoryItems(List<CollectableItemData> craftingObjects)
	{
		List<CollectableItemData> list = ((!(TrainGameManager.Instance != null) || TrainGameManager.Instance.currentGameMode != GameMode.Creative) ? craftingObjects.Where((CollectableItemData x) => x.isLearned).ToList() : craftingObjects);
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
		for (int num = 0; num < craftItems.Count; num++)
		{
			craftItems[num].gameObject.SetActive(value: false);
		}
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			craftItems[num2].gameObject.SetActive(value: true);
			craftItems[num2].SetNeededsPart(list[num2]);
			craftItems[num2].collectableItemData = list[num2];
		}
		if (craftScrollRect != null)
		{
			craftScrollRect.verticalNormalizedPosition = 1f;
			craftScrollRect.horizontalNormalizedPosition = 0f;
		}
	}

	public void ChangePanelActive()
	{
		if (!isPanelOpen)
		{
			craftText.SetActive(value: true);
			mainCraftCategoriesParent.gameObject.SetActive(value: true);
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
			Singleton<MainUIManager>.Instance.OnInGamePanelOpened.Invoke(this);
			Cursor.lockState = CursorLockMode.Confined;
			ShowPanel();
			foreach (InventorySlot inventorySlot in inventorySlots)
			{
				inventorySlot.isShowing = true;
			}
			inventoryManager.isOpenedExternal = true;
			inventoryManager.ShowPanel();
			return;
		}
		Cursor.lockState = CursorLockMode.Locked;
		Singleton<MainUIManager>.Instance.OnInGamePanelClosed.Invoke(this);
		foreach (InventorySlot inventorySlot2 in inventorySlots)
		{
			inventorySlot2.isShowing = false;
		}
		base.HidePanel();
		inventoryManager.isOpenedExternal = false;
		inventoryManager.HidePanel();
	}

	public void OnCategoryChanged(CraftSystemCategorizer newCategory)
	{
		lastCagegorizer = newCategory;
		SetCategoryItems(newCategory.itemDatas);
	}
}
