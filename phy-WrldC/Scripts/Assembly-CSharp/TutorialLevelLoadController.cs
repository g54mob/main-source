public class TutorialLevelLoadController : BaseController<TutorialLevelLoadView, LinearCampaignModel>
{
	private MainMenuView mainMenuView;

	public TutorialLevelLoadController(MainMenuView mainMenuView, TutorialLevelLoadView view, LinearCampaignModel model)
		: base(view, model, false)
	{
		this.mainMenuView = mainMenuView;
	}

	protected override void SyncViewWithModel()
	{
		view.RemoveAllLevelLoadSlots();
		foreach (CampaignLevelModel allCampaignLevelModel in model.GetAllCampaignLevelModels())
		{
			view.AddLevelLoadSlot(allCampaignLevelModel);
		}
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (!(eventName == "TutorialLevelLoadView.LoadLevelEvent"))
		{
			if (eventName == "TutorialLevelLoadView.BackEvent")
			{
				mainMenuView.GoBackToRootMenu();
			}
		}
		else
		{
			CampaignLevelModel campaignLevelModel = data[0] as CampaignLevelModel;
			mainMenuView.LoadTutorialLevel(campaignLevelModel.LevelModel);
		}
	}
}
