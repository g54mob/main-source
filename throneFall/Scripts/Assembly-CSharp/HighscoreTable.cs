using System.Collections.Generic;
using Steamworks;
using TMPro;
using UnityEngine;

public class HighscoreTable : MonoBehaviour
{
	public static bool ETERNAL_TRIALS;

	private ScoreTag[] scoreTags = new ScoreTag[0];

	private string currentHighscoreTableToCall = "";

	public Transform scoreTagParent;

	public GameObject loading;

	public GameObject notConnectedToSteam;

	public GameObject noScore;

	public GameObject noFriends;

	public TextMeshProUGUI levelTitle;

	private bool subscribedToSteamManager;

	public void UpdateLevelTitle()
	{
		if (ETERNAL_TRIALS)
		{
			levelTitle.text = TextTranslator.Translate("Menu/Eternal Trials");
			return;
		}
		LevelInfo levelInfo = null;
		levelInfo = ((!(LevelInteractor.lastActiveLevelInfo != null)) ? LevelProgressManager.instance.GetLevelInfoFromCurrentSceneName() : LevelInteractor.lastActiveLevelInfo);
		if (!(levelInfo == null))
		{
			levelTitle.text = levelInfo.LocalizedDisplayName;
			if (levelInfo.displaySubtitle.Length > 0)
			{
				TextMeshProUGUI textMeshProUGUI = levelTitle;
				textMeshProUGUI.text = textMeshProUGUI.text + "\n<size=" + 20 + "><style=Subheader>" + levelInfo.displaySubtitle + "</size></style>";
			}
		}
	}

	public void SetAndDownloadHighscoreTable(string _highscoreTableName)
	{
		noScore.SetActive(value: false);
		noFriends.SetActive(value: false);
		currentHighscoreTableToCall = _highscoreTableName;
		scoreTags = new ScoreTag[scoreTagParent.childCount];
		for (int i = 0; i < scoreTagParent.childCount; i++)
		{
			scoreTags[i] = scoreTagParent.GetChild(i).GetComponent<ScoreTag>();
			scoreTagParent.GetChild(i).gameObject.SetActive(value: false);
		}
		if (SteamManager.Initialized)
		{
			SubscribeToSteamManger();
			SteamManager.Instance.DownloadFriendsHighscores(currentHighscoreTableToCall);
			loading.SetActive(value: true);
			notConnectedToSteam.SetActive(value: false);
		}
		else
		{
			loading.SetActive(value: false);
			notConnectedToSteam.SetActive(value: true);
		}
	}

	private void OnEnable()
	{
		UpdateLevelTitle();
		if (ETERNAL_TRIALS)
		{
			SetAndDownloadHighscoreTable("Eternal Trials Season 4");
		}
		else
		{
			SetAndDownloadHighscoreTable(LevelInteractor.lastActiveLevelInfo.sceneName);
		}
	}

	private void SubscribeToSteamManger()
	{
		if (!subscribedToSteamManager)
		{
			SteamManager.Instance.OnLeaderboardDownloadCallbackComplete.AddListener(RefreshUI);
			subscribedToSteamManager = true;
		}
	}

	private void RefreshUI()
	{
		for (int i = 0; i < scoreTags.Length; i++)
		{
			scoreTags[i].gameObject.SetActive(value: false);
		}
		List<SteamManager.LeaderboardEntry> lastDownloadedLeaderboardEntires = SteamManager.Instance.lastDownloadedLeaderboardEntires;
		if (lastDownloadedLeaderboardEntires.Count > 0)
		{
			loading.SetActive(value: false);
			notConnectedToSteam.SetActive(value: false);
			bool flag = false;
			foreach (SteamManager.LeaderboardEntry item in lastDownloadedLeaderboardEntires)
			{
				if (item.username == SteamFriends.GetPersonaName())
				{
					flag = true;
					break;
				}
			}
			noScore.SetActive(!flag);
			noFriends.SetActive(lastDownloadedLeaderboardEntires.Count == 1 && flag);
		}
		else
		{
			loading.SetActive(value: false);
			notConnectedToSteam.SetActive(value: false);
			noScore.SetActive(value: true);
			noFriends.SetActive(value: true);
		}
		for (int j = 0; j < lastDownloadedLeaderboardEntires.Count && j <= scoreTags.Length - 1; j++)
		{
			bool isPlayer = lastDownloadedLeaderboardEntires[j].username == SteamFriends.GetPersonaName();
			scoreTags[j].gameObject.SetActive(value: true);
			scoreTags[j].SetNameAndScore(lastDownloadedLeaderboardEntires[j].username, lastDownloadedLeaderboardEntires[j].score, j + 1, isPlayer);
		}
	}
}
