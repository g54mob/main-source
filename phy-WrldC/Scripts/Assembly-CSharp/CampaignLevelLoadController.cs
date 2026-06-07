public class CampaignLevelLoadController : BaseController<CampaignLevelLoadView, LinearCampaignModel>
{
	private MainMenuView mainMenuView;

	public CampaignLevelLoadController(MainMenuView mainMenuView, CampaignLevelLoadView view, LinearCampaignModel model)
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
		view.RefreshPanelSize(model.GetAllCampaignLevelModels().Count);
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (!(eventName == "CampaignLevelLoadView.LoadLevelEvent"))
		{
			if (eventName == "CampaignLevelLoadView.BackEvent")
			{
				mainMenuView.GoBackToRootMenu();
			}
		}
		else
		{
			CampaignLevelModel campaignLevelModel = data[0] as CampaignLevelModel;
			mainMenuView.LoadCampaignLevel(campaignLevelModel.LevelModel);
		}
	}
}
