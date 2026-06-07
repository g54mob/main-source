using UnityEngine;

public abstract class QuickInventoryControllerBase<TItemView, TItemModel> : BaseController<QuickInventoryViewBase<TItemView, TItemModel>, QuickInventoryModelBase<TItemModel>> where TItemView : Component where TItemModel : class
{
	private bool isFirstTimeSelectingSlot;

	private bool wasTabSelected;

	public QuickInventoryControllerBase(QuickInventoryViewBase<TItemView, TItemModel> view, QuickInventoryModelBase<TItemModel> model)
		: base(view, model, false)
	{
	}

	protected override void SyncViewWithModel()
	{
		isFirstTimeSelectingSlot = true;
		wasTabSelected = false;
		view.ClearAllTabsAndSlots();
		for (int i = 0; i < model.TabCount(); i++)
		{
			ModelChangeHandler("QuickInventoryModelBase.AddTabEvent", i);
			for (int j = 0; j < model.ItemCount(i); j++)
			{
				ModelChangeHandler("QuickInventoryModelBase.AddItemEvent", i, j, model.GetItem(i, j));
			}
		}
		ModelChangeHandler("QuickInventoryModelBase.SelectedTabIndexEvent", model.SelectedTabIndex);
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "QuickInventoryModelBase.AddTabEvent":
		{
			int tabIndex = (int)data[0];
			view.AddTab(tabIndex);
			break;
		}
		case "QuickInventoryModelBase.RemoveTabEvent":
		{
			int tabIndex = (int)data[0];
			view.RemoveTab(tabIndex);
			break;
		}
		case "QuickInventoryModelBase.SwapTabEvent":
		{
			int oldTabIndex = (int)data[0];
			int num = (int)data[1];
			view.SwapTab(oldTabIndex, num);
			model.SelectedTabIndex = num;
			break;
		}
		case "QuickInventoryModelBase.AddItemEvent":
		{
			int tabIndex = (int)data[0];
			int slotIndex = (int)data[1];
			TItemModel itemModel = data[2] as TItemModel;
			view.AddSlot(itemModel, tabIndex, slotIndex);
			break;
		}
		case "QuickInventoryModelBase.InsertItemEvent":
		{
			int tabIndex = (int)data[0];
			int slotIndex = (int)data[1];
			TItemModel itemModel = data[2] as TItemModel;
			view.InsertSlot(itemModel, tabIndex, slotIndex);
			break;
		}
		case "QuickInventoryModelBase.SwapItemEvent":
		{
			int tabIndex = (int)data[0];
			int oldSlotIndex = (int)data[1];
			int newSlotIndex = (int)data[2];
			view.SwapSlot(tabIndex, oldSlotIndex, newSlotIndex);
			break;
		}
		case "QuickInventoryModelBase.RemoveItemEvent":
		{
			int tabIndex = (int)data[0];
			int slotIndex = (int)data[1];
			view.RemoveSlot(tabIndex, slotIndex);
			break;
		}
		case "QuickInventoryModelBase.SelectedTabIndexEvent":
		{
			int tabIndex = (int)data[0];
			view.SelectTab(tabIndex, !isFirstTimeSelectingSlot);
			wasTabSelected = true;
			model.SelectedItemIndex = 0;
			break;
		}
		case "QuickInventoryModelBase.SelectedItemIndexEvent":
		{
			int tabIndex = (int)data[0];
			int slotIndex = (int)data[1];
			view.SelectSlot(tabIndex, slotIndex, !isFirstTimeSelectingSlot && !wasTabSelected);
			isFirstTimeSelectingSlot = false;
			wasTabSelected = false;
			break;
		}
		case "QuickInventoryModelBase.UnfocusSelectedItemEvent":
			view.DeselectSlot(model.SelectedTabIndex, model.SelectedItemIndex);
			break;
		case "QuickInventoryModelBase.MaxTabsLimitEvent":
		{
			string text = LanguagesManager.Instance.GetText("warning.text.tab.limit", "Can't add more tab!");
			GUIManager.Instance.WarningTooltipPanel.ShowWarningText(text, 40f, 0f);
			break;
		}
		case "QuickInventoryModelBase.MaxSlotsLimitEvent":
		{
			string text = LanguagesManager.Instance.GetText("warning.text.slot.limit", "Can't add more slot!");
			GUIManager.Instance.WarningTooltipPanel.ShowWarningText(text, 40f, 0f);
			break;
		}
		case "QuickInventoryModelBase.LastTabWarningEvent":
		{
			string text = LanguagesManager.Instance.GetText("warning.text.remove.lasttab", "Can't remove last tab with not-user slots!");
			GUIManager.Instance.WarningTooltipPanel.ShowWarningText(text, 40f, 0f);
			break;
		}
		case "QuickInventoryModelBase.LastItemWarningEvent":
		{
			string text = LanguagesManager.Instance.GetText("warning.text.remove.lastslot", "Can't remove last not-user slot!");
			GUIManager.Instance.WarningTooltipPanel.ShowWarningText(text, 40f, 0f);
			break;
		}
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "QuickInventoryViewBase.NewTabEvent":
		{
			int tabIndex = (int)data[0];
			if (model.AddTab())
			{
				TItemModel inventorySelectedItemModel = GetInventorySelectedItemModel();
				model.AddItem(tabIndex, inventorySelectedItemModel);
				model.SelectedTabIndex = tabIndex;
			}
			break;
		}
		case "QuickInventoryViewBase.ChangeTabEvent":
		{
			int tabIndex = (int)data[0];
			model.SelectedTabIndex = tabIndex;
			break;
		}
		case "QuickInventoryViewBase.ChangeSlotEvent":
		{
			int itemIndex = (int)data[0];
			model.SelectedItemIndex = itemIndex;
			break;
		}
		case "QuickInventoryViewBase.RemoveTabEvent":
		{
			int tabIndex = (int)data[0];
			model.RemoveTab(tabIndex);
			break;
		}
		case "QuickInventoryViewBase.RemoveSlotEvent":
		{
			int tabIndex = (int)data[0];
			int itemIndex = (int)data[1];
			model.RemoveItem(tabIndex, itemIndex);
			break;
		}
		case "QuickInventoryViewBase.DefaultButtonEvent":
		{
			string text = LanguagesManager.Instance.GetText("message.header.quickinventory.default", "Restore the Quick Inventory");
			string text2 = LanguagesManager.Instance.GetText("message.info.quickinventory.default", "Are you sure you want to restore the quick inventory?");
			GUIManager.Instance.ShowMessageBox(text, text2, delegate
			{
				DefaultButtonHandler();
			});
			break;
		}
		case "QuickInventoryViewBase.IsBeingDragEvent":
		{
			bool isBeingDrag = (bool)data[0];
			IsBeingDragHandler(isBeingDrag);
			break;
		}
		}
	}

	protected abstract TItemModel GetInventorySelectedItemModel();

	protected abstract void IsBeingDragHandler(bool isBeingDrag);

	protected abstract void DefaultButtonHandler();
}
