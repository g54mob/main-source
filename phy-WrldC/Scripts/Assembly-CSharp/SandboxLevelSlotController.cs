public class SandboxLevelSlotController : BaseController<LevelLoadSlotView, LevelModel>
{
	public SandboxLevelSlotController(LevelLoadSlotView view, LevelModel model)
		: base(view, model, false)
	{
	}

	protected override void SyncViewWithModel()
	{
		LevelLoadSlotView.LevelType levelType = (model.IsSandboxWithGoal ? LevelLoadSlotView.LevelType.WithGoal : LevelLoadSlotView.LevelType.WithoutGoal);
		view.ConfigSlot(model, levelType);
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
		if (eventName == "LevelModel.NewLevelRecordsEvent")
		{
			view.SetLevelBestTime(model.LevelStatus, model.BestTime);
			view.SetLevelCompleteness(model.IsLevelCompleted);
			view.SetLevelCollectables(model.IsThereCollectables, model.LevelStatus);
		}
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
	}
}
