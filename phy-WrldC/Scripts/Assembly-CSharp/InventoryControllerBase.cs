using UnityEngine;

public abstract class InventoryControllerBase<TItemView, TItemModel> : BaseController<InventoryViewBase<TItemView, TItemModel>, CategoriesModelBase<TItemModel>> where TItemView : Component where TItemModel : class
{
	public InventoryControllerBase(InventoryViewBase<TItemView, TItemModel> view, CategoriesModelBase<TItemModel> model)
		: base(view, model, false)
	{
	}

	protected override void SyncViewWithModel()
	{
		view.ClearAllTabsAndSlots();
		for (int i = 0; i < model.CategoriesCount(); i++)
		{
			ModelChangeHandler("CategoriesModelBase.AddNewCategoryEvent", i, model.GetCategory(i).Name);
			for (int j = 0; j < model.GetCategory(i).ItemsCount(); j++)
			{
				ModelChangeHandler("CategoriesModelBase.AddNewItemEvent", i, j, model.GetCategory(i).GetItem(j));
			}
		}
		ModelChangeHandler("CategoriesModelBase.SelectedCategoryIndexEvent", model.SelectedCategoryIndex);
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "CategoriesModelBase.AddNewCategoryEvent":
		{
			int tabIndex = (int)data[0];
			string categoryName = (string)data[1];
			view.AddTab(tabIndex, categoryName);
			break;
		}
		case "CategoriesModelBase.AddNewItemEvent":
		{
			int tabIndex = (int)data[0];
			int slotIndex = (int)data[1];
			TItemModel itemModel = data[2] as TItemModel;
			view.AddSlot(itemModel, tabIndex, slotIndex);
			break;
		}
		case "CategoriesModelBase.RemoveItemEvent":
		{
			int tabIndex = (int)data[0];
			int slotIndex = (int)data[1];
			view.RemoveSlot(tabIndex, slotIndex);
			break;
		}
		case "CategoriesModelBase.RemoveSelectedItemEvent":
		{
			int tabIndex = (int)data[0];
			int slotIndex = (int)data[1];
			view.RemoveSlot(tabIndex, slotIndex);
			break;
		}
		case "CategoriesModelBase.SelectedCategoryIndexEvent":
		{
			int tabIndex = (int)data[0];
			view.SelectTab(tabIndex);
			model.SelectedItemIndex = 0;
			break;
		}
		case "CategoriesModelBase.SelectedItemIndexEvent":
		{
			int tabIndex = (int)data[0];
			int slotIndex = (int)data[1];
			view.SetSelectedItemModel(tabIndex, slotIndex, model.GetSelectedItem());
			break;
		}
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "InventoryViewBase.ChangeTabEvent":
		{
			int selectedCategoryIndex = (int)data[0];
			model.SelectedCategoryIndex = selectedCategoryIndex;
			break;
		}
		case "InventoryViewBase.ChangeSlotEvent":
		{
			int selectedItemIndex = (int)data[0];
			model.SelectedItemIndex = selectedItemIndex;
			break;
		}
		case "InventoryViewBase.CloseEvent":
			CloseHandler();
			break;
		case "InventoryViewBase.DeleteSlotEvent":
		{
			TItemModel selectedItem = model.GetSelectedItem();
			model.RemoveSelectedItem();
			DeleteSlotHandler(selectedItem);
			break;
		}
		case "InventoryViewBase.IsBeingDragEvent":
		{
			bool isBeingDrag = (bool)data[0];
			IsBeingDragHandler(isBeingDrag);
			break;
		}
		}
	}

	protected abstract void CloseHandler();

	protected abstract void DeleteSlotHandler(TItemModel itemModel);

	protected abstract void IsBeingDragHandler(bool isBeingDrag);
}
