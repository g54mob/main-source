using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BestUsersState : State<GameManager>
{
	private BestPlayersController bestPlayersController;

	public static BestUsersState Instance { get; }

	static BestUsersState()
	{
		Instance = new BestUsersState();
	}

	private BestUsersState()
	{
	}

	public override void Start(GameManager gameManager)
	{
		bestPlayersController = gameManager.GUIManager.BestPlayersController;
		SteamLeaderboardsManager.Instance.OnBestUsersScoresDownloadedEvent += BestUsersScoresDownloadedHandler;
		SteamLeaderboardsManager.Instance.OnBestUsersScoresDownloadingEvent += BestUsersScoresDownloadingHandler;
	}

	private void BestUsersScoresDownloadingHandler(int currentItem, int totalItem, List<SteamLeaderboardsManager.BestUserData> bestUserDatas)
	{
		string text = LanguagesManager.Instance.GetText("label.text.bestplayers.loading", "Loading...");
		text = text.ReplaceFirst("*", currentItem.ToString()).ReplaceFirst("*", totalItem.ToString());
		bestPlayersController.view.SetInfoText(text);
		List<SteamLeaderboardsManager.BestUserData> newSortedBestUserDatas = bestUserDatas.OrderByDescending((SteamLeaderboardsManager.BestUserData bestUserData) => bestUserData.score).ToList();
		bestPlayersController.UpdateBestUserDatas(newSortedBestUserDatas);
		bestPlayersController.view.SetScoresPanelVisibility(isVisible: true);
	}

	public override void Enter(GameManager gameManager)
	{
		bestPlayersController.CurrentPageSelected = 1;
		string[] allLevelIds = gameManager.mainCampaignLevels.GetAllLevelIds();
		var (leaderboardType, leaderboardDifficult) = bestPlayersController.view.GetSelectedLeaderboardInfos();
		SteamLeaderboardsManager.Instance.DownloadBestUsersScores(allLevelIds, leaderboardType, leaderboardDifficult);
		bestPlayersController.view.SetVisibility(isVisible: true);
		bestPlayersController.view.SetScoresPanelVisibility(isVisible: false);
		bestPlayersController.view.SetInfoPanelVisibility(isVisible: true);
		bestPlayersController.view.SetPagesComponentsVisibility(isVisible: false);
		string text = LanguagesManager.Instance.GetText("label.text.bestplayers.connecting", "Connecting...");
		bestPlayersController.view.SetInfoText(text);
	}

	public override void Execute(GameManager gameManager)
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			gameManager.ExitSubState();
		}
	}

	public override void Exit(GameManager gameManager)
	{
		SteamLeaderboardsManager.Instance.AbortDownloadBestUsersScores();
		bestPlayersController.view.SetVisibility(isVisible: false);
	}

	private void BestUsersScoresDownloadedHandler(List<SteamLeaderboardsManager.BestUserData> bestUserDatas)
	{
		List<SteamLeaderboardsManager.BestUserData> newSortedBestUserDatas = bestUserDatas.OrderByDescending((SteamLeaderboardsManager.BestUserData bestUserData) => bestUserData.score).ToList();
		bestPlayersController.UpdateBestUserDatas(newSortedBestUserDatas);
		bestPlayersController.view.SetInfoPanelVisibility(isVisible: false);
	}
}
