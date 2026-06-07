using System.IO;
using UnityEngine;

public class LEInventoryController : InventoryControllerBase<Transform, CustomLevelObjectsModel>
{
	public LEInventoryController(LEInventoryView view, LECategoriesModel model)
		: base((InventoryViewBase<Transform, CustomLevelObjectsModel>)view, (CategoriesModelBase<CustomLevelObjectsModel>)model)
	{
	}

	protected override void CloseHandler()
	{
		GameManager.Instance.ExitSubState();
	}

	protected override void DeleteSlotHandler(CustomLevelObjectsModel itemModel)
	{
		GameManager.Instance.LEQuickInventoryModel.RemoveItem(itemModel);
		File.Delete(itemModel.FilePath);
	}

	protected override void IsBeingDragHandler(bool isBeingDrag)
	{
		LevelEditorInventoryState.Instance.IsExitStateLocked = isBeingDrag;
	}
}
