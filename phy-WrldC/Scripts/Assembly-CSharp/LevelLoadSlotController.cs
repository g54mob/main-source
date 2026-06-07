public class LevelLoadSlotController : BaseController<LevelLoadSlotView, LevelModel>
{
	public LevelLoadSlotController(LevelLoadSlotView view, LevelModel model)
		: base(view, model, false)
	{
	}

	protected override void SyncViewWithModel()
	{
		view.ConfigSlot(model, LevelLoadSlotView.LevelType.WithGoal);
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		if (!(eventName == "LevelModel.NameChangedEvent"))
		{
			if (eventName == "LevelModel.NewLevelRecordsEvent")
			{
				view.SetLevelBestTime(model.LevelStatus, model.BestTime);
				view.SetLevelCompleteness(model.IsLevelCompleted);
				view.SetLevelCollectables(model.IsThereCollectables, model.LevelStatus);
			}
		}
		else
		{
			view.SetLevelName(model.Name);
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
	}
}
