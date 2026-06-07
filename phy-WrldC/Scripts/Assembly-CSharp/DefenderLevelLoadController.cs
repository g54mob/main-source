using System.IO;

public class DefenderLevelLoadController : BaseController<DefenderLevelLoadView, GenericCollectionModel<LevelModel>>
{
	private MainMenuView mainMenuView;

	public DefenderLevelLoadController(MainMenuView mainMenuView, DefenderLevelLoadView view, GenericCollectionModel<LevelModel> model)
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
		switch (eventName)
		{
		case "DefenderLevelLoadView.LoadLevelEvent":
		{
			LevelModel levelModel = (LevelModel)data[0];
			mainMenuView.LoadDefenderLevel(levelModel);
			break;
		}
		case "DefenderLevelLoadView.DeleteLevelEvent":
		{
			LevelModel levelModel = (LevelModel)data[0];
			model.RemoveItem(levelModel.GetId());
			File.Delete(levelModel.FilePath);
			break;
		}
		case "DefenderLevelLoadView.NewLevelEvent":
			mainMenuView.GoToNewLevel();
			break;
		case "DefenderLevelLoadView.BackEvent":
			mainMenuView.GoBackToRootMenu();
			break;
		}
	}
}
