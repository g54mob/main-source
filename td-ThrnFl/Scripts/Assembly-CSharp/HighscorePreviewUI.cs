using System.Collections.Generic;
using Steamworks;
using TMPro;
using UnityEngine;

public class HighscorePreviewUI : MonoBehaviour
{
	public TMP_Text highscore;

	public TMP_Text friendsRank;

	private bool subscribedToSteamManager;

	private readonly string lightTextCue = "<style=Body Light>";

	private void OnEnable()
	{
		HighscoreTable.ETERNAL_TRIALS = false;
		int highscoreBest = LevelProgressManager.instance.GetLevelDataForScene(LevelInteractor.lastActiveLevelInfo.sceneName).highscoreBest;
		string text = ((highscoreBest != 0) ? highscoreBest.ToString() : "-");
		highscore.text = TextTranslator.Translate("Menu/Highscore") + ": " + lightTextCue + text;
		friendsRank.text = TextTranslator.Translate("Menu/Friends Rank") + ": " + lightTextCue + "-";
		SubscribeToSteamManger();
		SteamManager.Instance.DownloadFriendsHighscores(LevelInteractor.lastActiveLevelInfo.sceneName);
	}

	private void SubscribeToSteamManger()
	{
		if (!subscribedToSteamManager)
		{
			SteamManager.Instance.OnLeaderboardDownloadCallbackComplete.AddListener(RefreshUI);
			subscribedToSteamManager = true;
		}
	}

	public void RefreshUI()
	{
		friendsRank.text = TextTranslator.Translate("Menu/Friends Rank") + ": " + lightTextCue;
		List<SteamManager.LeaderboardEntry> lastDownloadedLeaderboardEntires = SteamManager.Instance.lastDownloadedLeaderboardEntires;
		if (lastDownloadedLeaderboardEntires.Count > 0)
		{
			int num = 0;
			int num2 = 1;
			foreach (SteamManager.LeaderboardEntry item in lastDownloadedLeaderboardEntires)
			{
				if (item.username == SteamFriends.GetPersonaName())
				{
					num = num2;
					break;
				}
				num2++;
			}
			if (num == 0)
			{
				friendsRank.text += "-";
				return;
			}
			TMP_Text tMP_Text = friendsRank;
			tMP_Text.text = tMP_Text.text + "#" + num;
		}
		else
		{
			friendsRank.text += "-";
		}
	}
}
