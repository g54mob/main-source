using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class InventoryViewBase<TItemView, TItemModel> : BaseGUIView where TItemView : Component where TItemModel : class
{
	public const string ChangeTabEvent = "InventoryViewBase.ChangeTabEvent";

	public const string ChangeSlotEvent = "InventoryViewBase.ChangeSlotEvent";

	public const string CloseEvent = "InventoryViewBase.CloseEvent";

	public const string DeleteSlotEvent = "InventoryViewBase.DeleteSlotEvent";

	public const string IsBeingDragEvent = "InventoryViewBase.IsBeingDragEvent";

	public GameObject tabPrefab;

	public GameObject slotPanelPrefab;

	public GameObject pagePanelPrefab;

	public GameObject slotPrefab;

	[SerializeField]
	private int slotsPerPage = 24;

	private GameObject tabsPanel;

	private GameObject tabsContentPanel;

	private ToggleGroup tabToggleGroup;

	protected TextMeshProUGUI itemNameText;

	protected TextMeshProUGUI descriptionText;

	private Button closeButton;

	protected Button deleteItemButton;

	protected GameObject itemParentFolder;

	protected TItemView selectedSlotItemView;

	protected GameObject referenceBlockObject;

	private PagesSystemHandler pagesSystemHandler;

	private List<GameObject> slotsPanels;

	protected List<InventoryTabBase> inventoryTabs;

	protected List<List<InventorySlotBase<TItemView, TItemModel>>> inventorySlotsPanels;

	private InventorySlotBase<TItemView, TItemModel> lastInventorySlot;

	public override void Initialize()
	{
		tabsPanel = mainPanel.transform.FindChildRecursively("TabsPanel").gameObject;
		tabsContentPanel = mainPanel.transform.FindChildRecursively("TabsContentPanel").gameObject;
		tabToggleGroup = tabsPanel.GetComponent<ToggleGroup>();
		itemNameText = mainPanel.transform.FindComponent<TextMeshProUGUI>("ItemNameText", isRecursively: true);
		descriptionText = mainPanel.transform.FindComponent<TextMeshProUGUI>("DescriptionText", isRecursively: true);
		closeButton = mainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		deleteItemButton = mainPanel.transform.FindComponent<Button>("DeleteItemButton", isRecursively: true);
		itemParentFolder = mainPanel.transform.FindChildRecursively("Item3DFolder").gameObject;
		referenceBlockObject = mainPanel.transform.FindChildRecursively("ReferenceBigBlock").gameObject;
		pagesSystemHandler = new PagesSystemHandler(mainPanel, tabsContentPanel, slotsPerPage);
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("InventoryViewBase.CloseEvent");
		});
		deleteItemButton.onClick.AddListener(delegate
		{
			string text = LanguagesManager.Instance.GetText("message.header.inventory.delete", "Delete Item");
			string text2 = LanguagesManager.Instance.GetText("message.info.inventory.delete", "Are you sure you want to remove this item?");
			GUIManager.Instance.ShowMessageBox(text, text2, delegate
			{
				NotifyChange("InventoryViewBase.DeleteSlotEvent");
			});
		});
		referenceBlockObject.SetActive(value: false);
		slotsPanels = new List<GameObject>();
		inventoryTabs = new List<InventoryTabBase>();
		inventorySlotsPanels = new List<List<InventorySlotBase<TItemView, TItemModel>>>();
		ClearAllTabsAndSlots();
	}

	public override void SetVisibility(bool isVisible)
	{
		base.SetVisibility(isVisible);
		inventorySlotsPanels.ForEach(delegate(List<InventorySlotBase<TItemView, TItemModel>> inventorySlotsPanel)
		{
			inventorySlotsPanel.ForEach(delegate(InventorySlotBase<TItemView, TItemModel> inventorySlot)
			{
				if (inventorySlot.ItemView.gameObject.activeSelf != isVisible)
				{
					inventorySlot.ItemView.gameObject.SetActive(isVisible);
				}
			});
		});
		TItemView val = selectedSlotItemView;
		if ((object)val == null || val.gameObject.activeSelf != isVisible)
		{
			selectedSlotItemView?.gameObject.SetActive(isVisible);
		}
	}

	public void ClearAllTabsAndSlots()
	{
		ActionBeforeClearAllTabsAndSlots();
		inventoryTabs.Clear();
		inventorySlotsPanels.Clear();
		tabsPanel.transform.RemoveAllChildren();
		tabsContentPanel.transform.RemoveAllChildren();
	}

	protected abstract void ActionBeforeClearAllTabsAndSlots();

	public void RefreshPages(int tabIndex)
	{
		pagesSystemHandler.UpdatePagesSystem(slotsPanels[tabIndex]);
	}

	public void AddTab(int tabIndex, string categoryName)
	{
		InventoryTabBase component = Util.InstantiateForGUI(tabPrefab, tabsPanel.transform, tabIndex, "Tab" + tabIndex).GetComponent<InventoryTabBase>();
		component.SetConfiguration(categoryName, tabToggleGroup);
		component.OnTabSelectedEvent += delegate(bool isOn)
		{
			ChangeTabHandler(isOn, tabIndex);
		};
		GameObject gameObject = Util.InstantiateForGUI(slotPanelPrefab, tabsContentPanel.transform, "SlotPanel_" + tabIndex);
		gameObject.transform.RemoveAllChildren();
		gameObject.SetActive(value: false);
		slotsPanels.Add(gameObject);
		inventoryTabs.Add(component);
		inventorySlotsPanels.Add(new List<InventorySlotBase<TItemView, TItemModel>>());
	}

	public void SelectTab(int tabIndex)
	{
		inventoryTabs[tabIndex].SetToggleValue(isOn: true);
		slotsPanels.ForEach(delegate(GameObject thisSlotPanel)
		{
			thisSlotPanel.SetActive(value: false);
		});
		slotsPanels[tabIndex].SetActive(value: true);
		pagesSystemHandler.UpdateToFirstPage(slotsPanels[tabIndex]);
	}

	public void AddSlot(TItemModel itemModel, int tabIndex, int slotIndex)
	{
		Transform parent = pagesSystemHandler.GetParentPagePanel(slotsPanels[tabIndex], pagePanelPrefab, slotIndex).transform;
		GameObject gameObject = Util.InstantiateForGUI(slotPrefab, parent, "Slot" + slotIndex);
		InventorySlotBase<TItemView, TItemModel> slot = gameObject.GetComponent<InventorySlotBase<TItemView, TItemModel>>();
		slot.TabIndex = tabIndex;
		slot.SlotIndex = slotIndex;
		ToggleGroup component = slotsPanels[tabIndex].GetComponent<ToggleGroup>();
		slot.SetConfiguration(itemModel, component);
		slot.OnSlotSelectedEvent += delegate(bool isOn)
		{
			ChangeSlotHandler(isOn, tabIndex, slot);
		};
		slot.OnBeginDragEvent += delegate
		{
			NotifyChange("InventoryViewBase.IsBeingDragEvent", true);
		};
		slot.OnEndDragEvent += delegate
		{
			NotifyChange("InventoryViewBase.IsBeingDragEvent", false);
		};
		if (slot.ItemView.gameObject.activeSelf != base.IsVisible)
		{
			slot.ItemView.gameObject.SetActive(base.IsVisible);
		}
		inventorySlotsPanels[tabIndex].Add(slot);
		if (!inventoryTabs[tabIndex].gameObject.activeSelf)
		{
			inventoryTabs[tabIndex].gameObject.SetActive(value: true);
		}
	}

	public void RemoveSlot(int tabIndex, int slotIndex)
	{
		InventorySlotBase<TItemView, TItemModel> inventorySlotBase = inventorySlotsPanels[tabIndex][slotIndex];
		inventorySlotsPanels[tabIndex].RemoveAt(slotIndex);
		ActionBeforeRemoveSlot(inventorySlotBase);
		inventorySlotBase.transform.SetParent(null);
		Object.Destroy(inventorySlotBase.gameObject);
		pagesSystemHandler.ReorganizePages(slotsPanels[tabIndex]);
		if (inventorySlotsPanels[tabIndex].Count == 0)
		{
			inventoryTabs[tabIndex].gameObject.SetActive(value: false);
			inventoryTabs[tabIndex].SetToggleValue(isOn: false);
		}
	}

	protected abstract void ActionBeforeRemoveSlot(InventorySlotBase<TItemView, TItemModel> slot);

	public void SetSelectedItemModel(int tabIndex, int slotIndex, TItemModel selectedItemModel)
	{
		if (selectedSlotItemView != null)
		{
			ActionBeforeRemoveOldItemView();
			itemParentFolder.transform.RemoveAllChildren();
		}
		if (selectedItemModel == null)
		{
			itemNameText.text = "";
			descriptionText.text = "";
			itemParentFolder.transform.RemoveAllChildren();
			deleteItemButton.gameObject.SetActive(value: false);
			selectedSlotItemView = null;
			return;
		}
		lastInventorySlot?.SetToggleValue(isOn: false);
		inventorySlotsPanels[tabIndex][slotIndex].SetToggleValue(isOn: true);
		lastInventorySlot = inventorySlotsPanels[tabIndex][slotIndex];
		selectedSlotItemView = SetSelectedItemModelHandler(selectedItemModel);
		if (selectedSlotItemView.transform.parent != itemParentFolder.transform)
		{
			selectedSlotItemView.transform.SetParent(itemParentFolder.transform, worldPositionStays: true);
		}
		if (selectedSlotItemView.gameObject.activeSelf != base.IsVisible)
		{
			selectedSlotItemView.gameObject.SetActive(base.IsVisible);
		}
	}

	protected abstract void ActionBeforeRemoveOldItemView();

	protected abstract TItemView SetSelectedItemModelHandler(TItemModel selectedItemModel);

	private void ChangeTabHandler(bool isOn, int tabIndex)
	{
		if (isOn)
		{
			NotifyChange("InventoryViewBase.ChangeTabEvent", tabIndex);
		}
	}

	private void ChangeSlotHandler(bool isOn, int tabIndex, InventorySlotBase<TItemView, TItemModel> inventorySlot)
	{
		if (isOn)
		{
			NotifyChange("InventoryViewBase.ChangeSlotEvent", inventorySlotsPanels[tabIndex].IndexOf(inventorySlot));
		}
	}
}
