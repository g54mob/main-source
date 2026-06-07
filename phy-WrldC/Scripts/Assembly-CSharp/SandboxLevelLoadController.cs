public class SandboxLevelLoadController : BaseController<SandboxLevelLoadView, GenericCollectionModel<LevelModel>>
{
	private MainMenuView mainMenuView;

	public SandboxLevelLoadController(MainMenuView mainMenuView, SandboxLevelLoadView view, GenericCollectionModel<LevelModel> model)
		: base(view, model, false)
	{
		this.mainMenuView = mainMenuView;
	}

	protected override void SyncViewWithModel()
	{
		view.RemoveAllLevelLoadSlots();
		if (model.Count == 0)
		{
			view.AddEmptyLevelSlot();
			return;
		}
		int num = 1;
		foreach (LevelModel allItem in model.GetAllItems())
		{
			view.AddLevelLoadSlot(allItem, num++);
		}
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		default:
			_ = eventName == "GenericCollectionModel.WarningMessageEvent";
			break;
		case "GenericCollectionModel.AddItemEvent":
		{
			if (model.Count <= 1)
			{
				view.RemoveAllLevelLoadSlots();
			}
			LevelModel levelModel = (LevelModel)data[0];
			view.AddLevelLoadSlot(levelModel);
			break;
		}
		case "GenericCollectionModel.OverrideItemEvent":
			break;
		case "GenericCollectionModel.RemoveItemEvent":
			break;
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (!(eventName == "SandboxLevelLoadView.LoadLevelEvent"))
		{
			if (eventName == "SandboxLevelLoadView.BackEvent")
			{
				mainMenuView.GoBackToRootMenu();
			}
		}
		else
		{
			LevelModel levelModel = (LevelModel)data[0];
			mainMenuView.LoadSandboxLevel(levelModel);
		}
	}
}
