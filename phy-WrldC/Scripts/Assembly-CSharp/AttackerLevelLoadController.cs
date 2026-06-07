public class AttackerLevelLoadController : BaseController<AttackerLevelLoadView, GenericCollectionModel<LevelModel>>
{
	private MainMenuView mainMenuView;

	public AttackerLevelLoadController(MainMenuView mainMenuView, AttackerLevelLoadView view, GenericCollectionModel<LevelModel> model)
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
		foreach (LevelModel allItem in model.GetAllItems())
		{
			view.AddLevelLoadSlot(allItem);
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
		case "GenericCollectionModel.RemoveItemEvent":
		{
			string levelModelId = (string)data[0];
			view.RemoveLevelLoadSlot(levelModelId);
			if (model.Count == 0)
			{
				view.AddEmptyLevelSlot();
			}
			break;
		}
		case "GenericCollectionModel.OverrideItemEvent":
			break;
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (!(eventName == "AtackerLevelLoadView.LoadLevelEvent"))
		{
			if (eventName == "AtackerLevelLoadView.BackEvent")
			{
				mainMenuView.GoBackToRootMenu();
			}
		}
		else
		{
			LevelModel levelModel = (LevelModel)data[0];
			mainMenuView.LoadAttackerLevel(levelModel);
		}
	}
}
