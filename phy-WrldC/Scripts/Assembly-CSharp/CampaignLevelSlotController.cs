public class CampaignLevelSlotController : BaseController<LevelLoadSlotView, CampaignLevelModel>
{
	public CampaignLevelSlotController(LevelLoadSlotView view, CampaignLevelModel model)
		: base(view, model, false)
	{
	}

	protected override void SyncViewWithModel()
	{
		LevelLoadSlotView.LevelType levelType = LevelLoadSlotView.LevelType.WithGoal;
		if (model.LevelModel.Place == LevelModel.LevelPlace.Tutorial)
		{
			levelType = LevelLoadSlotView.LevelType.WithoutGoal;
		}
		view.ConfigSlot(model.LevelModel, levelType, model.LevelIndex);
		view.SetInteractivity(model.IsLevelPlayable);
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		if (!(eventName == "CampaignLevelModel.LevelCompletedEvent"))
		{
			if (eventName == "CampaignLevelModel.PlayabilityChangedEvent")
			{
				view.SetInteractivity(model.IsLevelPlayable);
			}
		}
		else
		{
			view.SetLevelBestTime(model.LevelModel.LevelStatus, model.LevelModel.BestTime);
			view.SetLevelCompleteness(model.LevelModel.IsLevelCompleted);
			view.SetLevelCollectables(model.LevelModel.IsThereCollectables, model.LevelModel.LevelStatus);
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
	}
}
