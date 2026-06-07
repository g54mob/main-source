public class NewLevelController : BaseController<NewLevelView, GenericCollectionModel<LevelModel>>
{
	private MainMenuView mainMenuView;

	public NewLevelController(MainMenuView mainMenuView, NewLevelView view, GenericCollectionModel<LevelModel> model)
		: base(view, model, false)
	{
		this.mainMenuView = mainMenuView;
	}

	protected override void SyncViewWithModel()
	{
		view.RemoveAllLevelTemplatSlots();
		foreach (LevelModel allItem in model.GetAllItems())
		{
			view.AddLevelTemplateSlot(allItem);
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
			LevelModel templateLevelModel = (LevelModel)data[0];
			view.AddLevelTemplateSlot(templateLevelModel);
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
		if (!(eventName == "NewLevelView.CreateLevelEvent"))
		{
			if (eventName == "NewLevelView.BackEvent")
			{
				mainMenuView.GoBackToRootMenu();
			}
		}
		else
		{
			LevelModel levelModel = (LevelModel)data[0];
			LevelModelBuilder.SaveXml(levelModel, PathNames.UserLevels);
			GameManager.Instance.DefenderLevelModelCollection.AddItem(levelModel);
			GameManager.Instance.UserProfileModel.UserLevelStatusList.AddItem(new LevelStatus(levelModel));
			mainMenuView.LoadDefenderLevel(levelModel);
		}
	}
}
