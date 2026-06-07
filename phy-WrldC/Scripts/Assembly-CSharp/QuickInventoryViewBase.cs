using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class QuickInventoryViewBase<TItemView, TItemModel> : BaseGUIView where TItemView : Component where TItemModel : class
{
	public const string ChangeTabEvent = "QuickInventoryViewBase.ChangeTabEvent";

	public const string ChangeSlotEvent = "QuickInventoryViewBase.ChangeSlotEvent";

	public const string NewTabEvent = "QuickInventoryViewBase.NewTabEvent";

	public const string RemoveTabEvent = "QuickInventoryViewBase.RemoveTabEvent";

	public const string RemoveSlotEvent = "QuickInventoryViewBase.RemoveSlotEvent";

	public const string DefaultButtonEvent = "QuickInventoryViewBase.DefaultButtonEvent";

	public const string IsBeingDragEvent = "QuickInventoryViewBase.IsBeingDragEvent";

	public GameObject slotPanelPrefab;

	private GameObject tabsPanel;

	private GameObject tabsContentPanel;

	private List<GameObject> slotsPanels;

	protected List<QuickInventoryTabBase> quickInventoryTabs;

	protected List<List<QuickInventorySlotBase<TItemView, TItemModel>>> quickInventorySlotsPanels;

	private Button defaultButton;

	private Button newTabButton;

	private ToggleGroup tabToggleGroup;

	private QuickInventoryAudioEffect audioEffect;

	public ToggleGroup SlotToggleGroup { get; private set; }

	public override void Initialize()
	{
		tabsPanel = mainPanel.transform.FindChildRecursively("TabsPanel").gameObject;
		tabsContentPanel = mainPanel.transform.FindChildRecursively("TabsContentPanel").gameObject;
		slotsPanels = new List<GameObject>();
		defaultButton = mainPanel.transform.FindComponent<Button>("DefaultButton", isRecursively: true);
		newTabButton = mainPanel.transform.FindComponent<Button>("NewQuickInventoryTab", isRecursively: true);
		tabToggleGroup = tabsPanel.GetComponent<ToggleGroup>();
		SlotToggleGroup = tabsContentPanel.GetComponent<ToggleGroup>();
		audioEffect = mainPanel.GetComponentInChildren<QuickInventoryAudioEffect>(includeInactive: true);
		quickInventoryTabs = new List<QuickInventoryTabBase>();
		quickInventorySlotsPanels = new List<List<QuickInventorySlotBase<TItemView, TItemModel>>>();
		defaultButton.onClick.AddListener(delegate
		{
			NotifyChange("QuickInventoryViewBase.DefaultButtonEvent");
		});
		newTabButton.onClick.AddListener(delegate
		{
			NotifyChange("QuickInventoryViewBase.NewTabEvent", quickInventoryTabs.Count);
		});
		Util.AddMouseOverUIEvents(mainPanel, base.OnMouseOverUIHandler);
		ClearAllTabsAndSlots();
	}

	public override void SetVisibility(bool isVisible)
	{
		base.SetVisibility(isVisible);
		quickInventorySlotsPanels.ForEach(delegate(List<QuickInventorySlotBase<TItemView, TItemModel>> quickInventorySlotsPanel)
		{
			quickInventorySlotsPanel.ForEach(delegate(QuickInventorySlotBase<TItemView, TItemModel> quickInventorySlot)
			{
				if (quickInventorySlot.gameObject.activeSelf != isVisible)
				{
					quickInventorySlot.gameObject.SetActive(isVisible);
				}
			});
		});
	}

	public void SetEditable(bool isEditable)
	{
		defaultButton.gameObject.SetActive(isEditable);
		newTabButton.gameObject.SetActive(isEditable);
		foreach (QuickInventoryTabBase quickInventoryTab in quickInventoryTabs)
		{
			quickInventoryTab.SetEditable(isEditable);
		}
		foreach (List<QuickInventorySlotBase<TItemView, TItemModel>> quickInventorySlotsPanel in quickInventorySlotsPanels)
		{
			foreach (QuickInventorySlotBase<TItemView, TItemModel> item in quickInventorySlotsPanel)
			{
				item.SetEditable(isEditable);
			}
		}
	}

	public void ClearAllTabsAndSlots()
	{
		ActionBeforeClearAllTabsAndSlots();
		RecycleAllTabsAndSlots();
		quickInventoryTabs.Clear();
		quickInventorySlotsPanels.Clear();
		slotsPanels.Clear();
		tabsPanel.transform.RemoveAllChildren();
		tabsContentPanel.transform.RemoveAllChildren();
	}

	private void RecycleAllTabsAndSlots()
	{
		foreach (QuickInventoryTabBase quickInventoryTab in quickInventoryTabs)
		{
			ObjectPools.Instance.ReturnInstance(quickInventoryTab.gameObject);
		}
		foreach (List<QuickInventorySlotBase<TItemView, TItemModel>> quickInventorySlotsPanel in quickInventorySlotsPanels)
		{
			foreach (QuickInventorySlotBase<TItemView, TItemModel> item in quickInventorySlotsPanel)
			{
				ObjectPools.Instance.ReturnInstance(item.gameObject);
			}
		}
	}

	protected abstract void ActionBeforeClearAllTabsAndSlots();

	protected abstract GameObject GetNewTabObject(Transform objectParent, int tabIndex, string objectName);

	public void AddTab(int tabIndex)
	{
		GameObject newTabObject = GetNewTabObject(tabsPanel.transform, tabIndex, "Tab" + tabIndex);
		QuickInventoryTabBase newTab = newTabObject.GetComponent<QuickInventoryTabBase>();
		newTab.SetToggleGroup(tabToggleGroup);
		newTab.OnTabSelectedEvent += delegate(bool isOn)
		{
			ChangeTabHandler(isOn, newTab);
		};
		newTab.SetHotkeyNumber((tabIndex + 1).ToString());
		newTab.OnDeleteButtonEvent += delegate
		{
			RemoveTabHandler(newTab);
		};
		newTab.SetEditable(isEditable: true);
		AddSlotPanel(tabIndex);
		quickInventoryTabs.Add(newTab);
		quickInventorySlotsPanels.Add(new List<QuickInventorySlotBase<TItemView, TItemModel>>());
		newTab.OnBeginDragEvent += delegate
		{
			NotifyChange("QuickInventoryViewBase.IsBeingDragEvent", true);
		};
		newTab.OnEndDragEvent += delegate
		{
			NotifyChange("QuickInventoryViewBase.IsBeingDragEvent", false);
		};
	}

	private void AddSlotPanel(int tabIndex)
	{
		GameObject gameObject = Util.InstantiateForGUI(slotPanelPrefab, tabsContentPanel.transform, "SlotPanel_" + tabIndex);
		gameObject.transform.RemoveAllChildren();
		slotsPanels.Add(gameObject);
	}

	public virtual void RemoveTab(int tabIndex)
	{
		GameObject oldInstance = quickInventoryTabs[tabIndex].gameObject;
		quickInventoryTabs.RemoveAt(tabIndex);
		ObjectPools.Instance.ReturnInstance(oldInstance);
		RemoveSlotPanel(tabIndex);
		FixTabsNumbers();
	}

	private void RemoveSlotPanel(int tabIndex)
	{
		foreach (QuickInventorySlotBase<TItemView, TItemModel> item in quickInventorySlotsPanels[tabIndex])
		{
			ObjectPools.Instance.ReturnInstance(item.gameObject);
		}
		quickInventorySlotsPanels.RemoveAt(tabIndex);
		GameObject obj = slotsPanels[tabIndex];
		slotsPanels.RemoveAt(tabIndex);
		Object.Destroy(obj);
	}

	public void SwapTab(int oldTabIndex, int newTabIndex)
	{
		QuickInventoryTabBase quickInventoryTabBase = quickInventoryTabs[oldTabIndex];
		List<QuickInventorySlotBase<TItemView, TItemModel>> item = quickInventorySlotsPanels[oldTabIndex];
		quickInventoryTabs.RemoveAt(oldTabIndex);
		quickInventoryTabs.Insert(newTabIndex, quickInventoryTabBase);
		quickInventorySlotsPanels.RemoveAt(oldTabIndex);
		quickInventorySlotsPanels.Insert(newTabIndex, item);
		quickInventoryTabBase.gameObject.transform.SetSiblingIndex(newTabIndex);
		SwapSlotPanel(oldTabIndex, newTabIndex);
		FixTabsNumbers();
	}

	private void SwapSlotPanel(int oldTabIndex, int newTabIndex)
	{
		GameObject item = slotsPanels[oldTabIndex];
		slotsPanels.RemoveAt(oldTabIndex);
		slotsPanels.Insert(newTabIndex, item);
	}

	private void FixTabsNumbers()
	{
		int num = 1;
		foreach (QuickInventoryTabBase quickInventoryTab in quickInventoryTabs)
		{
			quickInventoryTab.SetHotkeyNumber(num++.ToString());
		}
	}

	public void SelectTab(int tabIndex, bool shouldPlayAudio = true)
	{
		quickInventoryTabs[tabIndex].SetToggleValue(isSelected: true);
		if (shouldPlayAudio && audioEffect != null)
		{
			audioEffect.TabOrSlotChangedApplyAudio();
		}
		SelectSlotPanel(tabIndex);
	}

	private void SelectSlotPanel(int tabIndex)
	{
		slotsPanels.ForEach(delegate(GameObject slotPanel)
		{
			slotPanel.SetActive(value: false);
		});
		slotsPanels[tabIndex].SetActive(value: true);
	}

	protected abstract GameObject GetNewSlotObject(Transform objectParent, string objectName);

	public QuickInventorySlotBase<TItemView, TItemModel> AddSlot(TItemModel itemModel, int tabIndex, int slotIndex)
	{
		QuickInventoryTabBase tab = quickInventoryTabs[tabIndex];
		GameObject newSlotObject = GetNewSlotObject(slotsPanels[tabIndex].transform, "Slot" + slotIndex);
		QuickInventorySlotBase<TItemView, TItemModel> newSlot = newSlotObject.GetComponent<QuickInventorySlotBase<TItemView, TItemModel>>();
		newSlot.SetConfiguration(itemModel, tabIndex, slotIndex, SlotToggleGroup);
		newSlot.SetEditable(isEditable: true);
		newSlot.OnSlotSelectedEvent += delegate(bool isOn)
		{
			ChangeSlotHandler(isOn, tab, newSlot);
		};
		newSlot.OnDeleteButtonEvent += delegate
		{
			RemoveSlotHandler(tab, newSlot);
		};
		newSlot.OnBeginDragEvent += delegate
		{
			NotifyChange("QuickInventoryViewBase.IsBeingDragEvent", true);
		};
		newSlot.OnEndDragEvent += delegate
		{
			NotifyChange("QuickInventoryViewBase.IsBeingDragEvent", false);
		};
		quickInventorySlotsPanels[tabIndex].Add(newSlot);
		if (!base.IsVisible)
		{
			newSlotObject.SetActive(value: false);
		}
		return newSlot;
	}

	public void InsertSlot(TItemModel itemModel, int tabIndex, int slotIndex)
	{
		QuickInventorySlotBase<TItemView, TItemModel> quickInventorySlotBase = AddSlot(itemModel, tabIndex, slotIndex);
		quickInventorySlotsPanels[tabIndex].RemoveAt(quickInventorySlotsPanels[tabIndex].Count - 1);
		quickInventorySlotsPanels[tabIndex].Insert(slotIndex, quickInventorySlotBase);
		quickInventorySlotBase.gameObject.transform.SetSiblingIndex(slotIndex);
		FixSlotsNumbers(tabIndex);
	}

	public void RemoveSlot(int tabIndex, int slotIndex)
	{
		QuickInventorySlotBase<TItemView, TItemModel> quickInventorySlotBase = quickInventorySlotsPanels[tabIndex][slotIndex];
		quickInventorySlotsPanels[tabIndex].RemoveAt(slotIndex);
		ActionBeforeRemoveSlot(quickInventorySlotBase);
		ObjectPools.Instance.ReturnInstance(quickInventorySlotBase.gameObject);
		FixSlotsNumbers(tabIndex);
	}

	protected abstract void ActionBeforeRemoveSlot(QuickInventorySlotBase<TItemView, TItemModel> slot);

	public void SwapSlot(int tabIndex, int oldSlotIndex, int newSlotIndex)
	{
		QuickInventorySlotBase<TItemView, TItemModel> quickInventorySlotBase = quickInventorySlotsPanels[tabIndex][oldSlotIndex];
		quickInventorySlotsPanels[tabIndex].RemoveAt(oldSlotIndex);
		quickInventorySlotsPanels[tabIndex].Insert(newSlotIndex, quickInventorySlotBase);
		quickInventorySlotBase.gameObject.transform.SetSiblingIndex(newSlotIndex);
		FixSlotsNumbers(tabIndex);
	}

	private void FixSlotsNumbers(int tabIndex)
	{
		int num = 0;
		foreach (QuickInventorySlotBase<TItemView, TItemModel> item in quickInventorySlotsPanels[tabIndex])
		{
			if (num < 10)
			{
				item.SetHotkeyNumber((num == 9) ? "0" : (num + 1).ToString());
				num++;
			}
			else
			{
				item.SetHotkeyNumber("0", isVisible: false);
			}
		}
	}

	public void SelectSlot(int tabIndex, int slotIndex, bool shouldPlayAudio = true)
	{
		quickInventorySlotsPanels[tabIndex][slotIndex].SetToggleValue(isSelected: true);
		if (shouldPlayAudio && audioEffect != null)
		{
			audioEffect.TabOrSlotChangedApplyAudio();
		}
	}

	public void DeselectSlot(int tabIndex, int slotIndex)
	{
		quickInventorySlotsPanels[tabIndex][slotIndex].SetToggleValue(isSelected: false);
	}

	private void ChangeTabHandler(bool isOn, QuickInventoryTabBase tab)
	{
		if (isOn)
		{
			int num = quickInventoryTabs.IndexOf(tab);
			NotifyChange("QuickInventoryViewBase.ChangeTabEvent", num);
		}
	}

	private void RemoveTabHandler(QuickInventoryTabBase tab)
	{
		int num = quickInventoryTabs.IndexOf(tab);
		NotifyChange("QuickInventoryViewBase.RemoveTabEvent", num);
	}

	private void ChangeSlotHandler(bool isOn, QuickInventoryTabBase tab, QuickInventorySlotBase<TItemView, TItemModel> slot)
	{
		if (isOn)
		{
			int index = quickInventoryTabs.IndexOf(tab);
			int num = quickInventorySlotsPanels[index].IndexOf(slot);
			NotifyChange("QuickInventoryViewBase.ChangeSlotEvent", num);
		}
	}

	private void RemoveSlotHandler(QuickInventoryTabBase tab, QuickInventorySlotBase<TItemView, TItemModel> slot)
	{
		int num = quickInventoryTabs.IndexOf(tab);
		int num2 = quickInventorySlotsPanels[num].IndexOf(slot);
		NotifyChange("QuickInventoryViewBase.RemoveSlotEvent", num, num2);
	}
}
