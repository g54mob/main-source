public class QuickInventoryController : QuickInventoryControllerBase<CreationView, CreationModel>
{
	public QuickInventoryController(QuickInventoryView view, QuickInventoryModel model)
		: base((QuickInventoryViewBase<CreationView, CreationModel>)view, (QuickInventoryModelBase<CreationModel>)model)
	{
	}

	protected override CreationModel GetInventorySelectedItemModel()
	{
		return GameManager.Instance.CategoriesModel.GetSelectedItem();
	}

	protected override void IsBeingDragHandler(bool isBeingDrag)
	{
		InventoryState.Instance.IsExitStateLocked = isBeingDrag;
	}

	protected override void DefaultButtonHandler()
	{
		RestoreQuickInventoryToDefault();
		view.SetEditable(isEditable: true);
	}

	public void RestoreQuickInventoryToDefault()
	{
		QuickInventoryModel mainQuickInventoryModel;
		if (GameManager.Instance.LevelType == GameManager.LevelTypeState.Tutorial)
		{
			string id = GameManager.Instance.LevelController.model.GetId();
			mainQuickInventoryModel = GameManager.Instance.TutorialManager.GetClonedQuickInventoryModel(id);
		}
		else
		{
			mainQuickInventoryModel = GameManager.Instance.DefaultQuickInventoryModel.Clone<QuickInventoryModel>();
			GameManager.Instance.MainQuickInventoryModel = mainQuickInventoryModel;
		}
		SetModel(mainQuickInventoryModel);
	}
}
