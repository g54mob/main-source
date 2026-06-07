public class LeaderboardsWindowController : BaseController<LeaderboardsWindowView, LevelModel>
{
	public LeaderboardsWindowController(LeaderboardsWindowView view, LevelModel model)
		: base(view, model, false)
	{
	}

	protected override void SyncViewWithModel()
	{
		var (text, levelName) = LevelUtil.GetLevelNames(model);
		view.SetLevelInfosValues(text + ":", levelName);
		view.SetLeaderboardsPanelLevelModel(model);
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (eventName == "LeaderboardsView.CloseButtonEvent")
		{
			GameManager.Instance.ExitSubState();
		}
	}
}
