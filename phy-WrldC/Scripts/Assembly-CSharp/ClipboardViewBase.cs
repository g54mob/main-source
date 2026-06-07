using UnityEngine;
using UnityEngine.UI;

public abstract class ClipboardViewBase<TItemView, TItemModel> : BaseGUIView where TItemView : Component where TItemModel : class
{
	public const string FocusSlotEvent = "ClipboardViewBase.FocusSlotEvent";

	public const string SaveButtonEvent = "ClipboardViewBase.SaveButtonEvent";

	public const string SelectSlotIndexEvent = "ClipboardViewBase.SelectSlotIndexEvent";

	private GameObject tabsPanel;

	private GameObject slotsPanel;

	private Toggle[] tabToggles;

	private ClipboardSlotBase<TItemView, TItemModel>[] clipboardSlots;

	private ClipboardSlotBase<TItemView, TItemModel> selectedClipboardSlot;

	private Button saveButton;

	public override void Initialize()
	{
		tabsPanel = mainPanel.transform.FindChildRecursively("TabsPanel").gameObject;
		slotsPanel = mainPanel.transform.FindChildRecursively("SlotsPanel").gameObject;
		saveButton = mainPanel.transform.FindComponent<Button>("SaveButton", isRecursively: true);
		tabToggles = tabsPanel.GetComponentsInChildren<Toggle>(includeInactive: true);
		clipboardSlots = slotsPanel.GetComponentsInChildren<ClipboardSlotBase<TItemView, TItemModel>>(includeInactive: true);
		saveButton.onClick.AddListener(delegate
		{
			NotifyChange("ClipboardViewBase.SaveButtonEvent");
		});
		ClipboardSlotBase<TItemView, TItemModel>[] array = clipboardSlots;
		foreach (ClipboardSlotBase<TItemView, TItemModel> obj in array)
		{
			obj.OnSlotSelectedEvent += delegate(bool isOn)
			{
				if (isOn)
				{
					NotifyChange("ClipboardViewBase.FocusSlotEvent");
				}
			};
			obj.gameObject.SetActive(value: false);
		}
		for (int num2 = 0; num2 < tabToggles.Length; num2++)
		{
			int index = num2;
			tabToggles[num2].onValueChanged.AddListener(delegate(bool isOn)
			{
				if (isOn)
				{
					NotifyChange("ClipboardViewBase.SelectSlotIndexEvent", index);
				}
			});
			tabToggles[num2].interactable = false;
		}
		Util.AddMouseOverUIEvents(mainPanel, base.OnMouseOverUIHandler);
	}

	public override void SetVisibility(bool isVisible)
	{
		if (selectedClipboardSlot == null)
		{
			base.SetVisibility(isVisible: false);
			return;
		}
		base.SetVisibility(isVisible);
		selectedClipboardSlot.ItemFolder.SetActive(isVisible);
	}

	public void AddSlot(TItemModel itemModel, ToggleGroup toggleGroup)
	{
		selectedClipboardSlot = clipboardSlots[clipboardSlots.Length - 1];
		selectedClipboardSlot.gameObject.SetActive(value: true);
		selectedClipboardSlot.ItemFolder.SetActive(value: true);
		selectedClipboardSlot.SetConfiguration(itemModel, toggleGroup);
		for (int num = clipboardSlots.Length - 1; num >= 1; num--)
		{
			clipboardSlots[num] = clipboardSlots[num - 1];
			if (clipboardSlots[num].ItemView != null)
			{
				clipboardSlots[num].gameObject.SetActive(value: false);
				tabToggles[num].interactable = true;
			}
		}
		clipboardSlots[0] = selectedClipboardSlot;
		tabToggles[0].interactable = true;
		tabToggles[0].SetValue(isOn: true);
	}

	public void SetSlotToggleValue(bool isOn)
	{
		selectedClipboardSlot?.SetSlotToggleValue(isOn);
	}

	public void SelectItemIndex(int itemIndex)
	{
		selectedClipboardSlot?.SetSlotToggleValue(isOn: false);
		selectedClipboardSlot?.gameObject.SetActive(value: false);
		selectedClipboardSlot = clipboardSlots[itemIndex];
		selectedClipboardSlot.gameObject.SetActive(value: true);
		selectedClipboardSlot.ItemFolder.SetActive(value: true);
	}
}
