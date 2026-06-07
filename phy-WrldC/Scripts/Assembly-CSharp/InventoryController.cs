using System.IO;

public class InventoryController : InventoryControllerBase<CreationView, CreationModel>
{
	public InventoryController(InventoryView view, CategoriesModel model)
		: base((InventoryViewBase<CreationView, CreationModel>)view, (CategoriesModelBase<CreationModel>)model)
	{
	}

	protected override void CloseHandler()
	{
		GameManager.Instance.ChangeState(ConstructionState.Instance);
	}

	protected override void DeleteSlotHandler(CreationModel itemModel)
	{
		GameManager.Instance.MainQuickInventoryModel.RemoveItem(itemModel);
		if (GameManager.Instance.QuickInventoryController.model != GameManager.Instance.MainQuickInventoryModel)
		{
			GameManager.Instance.QuickInventoryController.model.RemoveItem(itemModel);
		}
		File.Delete(itemModel.FilePath);
	}

	protected override void IsBeingDragHandler(bool isBeingDrag)
	{
		InventoryState.Instance.IsExitStateLocked = isBeingDrag;
	}
}
