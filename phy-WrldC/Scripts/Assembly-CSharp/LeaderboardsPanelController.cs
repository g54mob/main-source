using System.Collections.Generic;

public class LeaderboardsPanelController : BaseController<LeaderboardsPanelView, LevelModel>
{
	public LeaderboardsPanelController(LeaderboardsPanelView view, LevelModel model)
		: base(view, model, false)
	{
		SteamLeaderboardsManager.Instance.OnLeaderboardNotFoundEvent += LeaderboardNotFoundHandler;
		SteamLeaderboardsManager.Instance.OnLeaderboardFailedDownloadEvent += LeaderboardFailedDownloadHandler;
		SteamLeaderboardsManager.Instance.OnScoresDownloadedEvent += ScoresDownloadedHandler;
	}

	protected override void SyncViewWithModel()
	{
		UpdateSelectedLeaderboarder();
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		if (eventName == "LeaderboardsView.LeaderboardChangedEvent")
		{
			UpdateSelectedLeaderboarder();
		}
	}

	private void UpdateSelectedLeaderboarder()
	{
		var (type, difficult, list) = view.GetSelectedLeaderboardInfos();
		SteamLeaderboardsManager.Instance.DownloadScores(model.Id, type, difficult, list);
		view.SetScoresPanelVisibility(isVisible: false);
		string text = LanguagesManager.Instance.GetText("label.text.leaderboards.loading");
		view.SetInfoText(text);
		view.SetFiltersInteractivity(isInteractable: false);
	}

	private void ScoresDownloadedHandler(List<SteamLeaderboardsManager.UserScoreData> userScoreDatas)
	{
		if (userScoreDatas.Count > 0)
		{
			view.SetScoresPanelVisibility(isVisible: true);
			view.UpdateScoreList(userScoreDatas);
		}
		else
		{
			string text = LanguagesManager.Instance.GetText("label.text.leaderboards.empty");
			view.SetInfoText(text);
		}
		view.SetFiltersInteractivity(isInteractable: true);
	}

	private void LeaderboardNotFoundHandler()
	{
		string text = LanguagesManager.Instance.GetText("label.text.leaderboards.notfound");
		view.SetInfoText(text);
		view.SetFiltersInteractivity(isInteractable: true);
	}

	private void LeaderboardFailedDownloadHandler()
	{
		string text = LanguagesManager.Instance.GetText("label.text.leaderboards.failed");
		view.SetInfoText(text);
		view.SetFiltersInteractivity(isInteractable: true);
	}
}
