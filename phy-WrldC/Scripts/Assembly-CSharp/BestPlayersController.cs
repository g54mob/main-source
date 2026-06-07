using System.Collections.Generic;

public class BestPlayersController : BaseController<BestPlayersView>
{
	private List<SteamLeaderboardsManager.BestUserData> currentSortedBestUserDatas;

	public int CurrentPageSelected { get; set; }

	public BestPlayersController(BestPlayersView view)
		: base(view)
	{
		CurrentPageSelected = 1;
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "BestPlayersView.LeaderboardChangedEvent":
		{
			(LeaderboardType, LeaderboardDifficult) selectedLeaderboardInfos = view.GetSelectedLeaderboardInfos();
			LeaderboardType type = selectedLeaderboardInfos.Item1;
			LeaderboardDifficult difficult = selectedLeaderboardInfos.Item2;
			string[] levelIds = GameManager.Instance.mainCampaignLevels.GetAllLevelIds();
			CurrentPageSelected = 1;
			view.SetScoresPanelVisibility(isVisible: false);
			view.SetInfoPanelVisibility(isVisible: true);
			view.SetPagesComponentsVisibility(isVisible: false);
			string text = LanguagesManager.Instance.GetText("label.text.bestplayers.connecting", "Connecting...");
			view.SetInfoText(text);
			SteamLeaderboardsManager.Instance.AbortDownloadBestUsersScores(delegate
			{
				SteamLeaderboardsManager.Instance.DownloadBestUsersScores(levelIds, type, difficult);
			});
			break;
		}
		case "BestPlayersView.LeaderboardPagesChangedEvent":
		{
			int num = (int)data[0];
			CurrentPageSelected += num;
			UpdateBestUserDatas(currentSortedBestUserDatas);
			break;
		}
		case "BestPlayersView.CloseButtonEvent":
			GameManager.Instance.ExitSubState();
			break;
		}
	}

	public void UpdateBestUserDatas(List<SteamLeaderboardsManager.BestUserData> newSortedBestUserDatas)
	{
		currentSortedBestUserDatas = newSortedBestUserDatas;
		view.UpdateScoreList(newSortedBestUserDatas, CurrentPageSelected - 1);
		view.UpdatePagesSystem(newSortedBestUserDatas, CurrentPageSelected);
	}
}
