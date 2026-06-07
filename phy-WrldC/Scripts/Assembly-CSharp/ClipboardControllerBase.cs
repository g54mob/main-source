using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class ClipboardControllerBase<TItemView, TItemModel> : BaseController<ClipboardViewBase<TItemView, TItemModel>, ClipboardModelBase<TItemModel>> where TItemView : Component where TItemModel : class
{
	private readonly ToggleGroup toggleGroup;

	public event Action OnSelectedSlotEvent;

	public ClipboardControllerBase(ClipboardViewBase<TItemView, TItemModel> view, ClipboardModelBase<TItemModel> model, ToggleGroup toggleGroup)
		: base(view, model, false)
	{
		this.toggleGroup = toggleGroup;
	}

	protected override void SyncViewWithModel()
	{
		TItemModel itemModel = model.GetItemModel();
		if (itemModel != null)
		{
			ModelChangeHandler("ClipboardModelBase.AddSlotEvent", itemModel);
		}
		else
		{
			view.SetVisibility(isVisible: false);
		}
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "ClipboardModelBase.AddSlotEvent":
		{
			TItemModel itemModel = data[0] as TItemModel;
			view.AddSlot(itemModel, toggleGroup);
			if (!view.IsVisible)
			{
				view.SetVisibility(isVisible: true);
			}
			break;
		}
		case "ClipboardModelBase.FocusSlotEvent":
			view.SetSlotToggleValue(isOn: true);
			this.OnSelectedSlotEvent?.Invoke();
			break;
		case "ClipboardModelBase.UnfocusSlotEvent":
			view.SetSlotToggleValue(isOn: false);
			break;
		case "ClipboardModelBase.SelectedSlotIndexEvent":
		{
			int itemIndex = (int)data[0];
			view.SelectItemIndex(itemIndex);
			view.SetSlotToggleValue(isOn: true);
			break;
		}
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "ClipboardViewBase.FocusSlotEvent":
			model.FocusSlot();
			break;
		case "ClipboardViewBase.SaveButtonEvent":
			SaveButtonHandler(model.GetItemModel());
			break;
		case "ClipboardViewBase.SelectSlotIndexEvent":
		{
			int selectedSlotIndex = (int)data[0];
			model.SelectedSlotIndex = selectedSlotIndex;
			model.FocusSlot();
			break;
		}
		}
	}

	protected abstract void SaveButtonHandler(TItemModel itemModel);

	public void SetAllTogglesOff()
	{
		toggleGroup.SetAllTogglesOff();
	}
}
