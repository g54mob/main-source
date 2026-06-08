using System;
using System.IO;
using Dorfromantik;
using UnityEngine;

public class GameMode : ScriptableObject
{
	public bool setupPreplacedTiles = true;

	public bool setupChallenges = true;

	public bool spawnsQuests = true;

	public bool doesTriggerGameOver = true;

	public bool usesCustomConfiguration;

	public CustomConfigType configType;

	public string configurationString;

	public bool showsConfigString;

	public bool canHaveTileLimit = true;

	public GameModeId id;

	public string sceneName;

	public string autosaveName = "AutoSave01";

	public string playerPrefsActiveGame = "AutoSaveName_Classic";

	public string saveFileName;

	public MainMenuScreenType screenType;

	public bool hasLeaderboard;

	[SerializeField]
	private LeaderboardType leaderboard;

	public string localizationKey;

	public string gameModeIconRichTextSuffix;

	[SerializeField]
	private bool hasSeparateFullVersionLeaderboard;

	[SerializeField]
	private LeaderboardType fullVersionLeaderboard;

	[SerializeField]
	private int firstFullVersionPatch = 9;

	[SerializeField]
	private SaveFileManager saveFileManager;

	public bool IsTutorial => id == GameModeId.Tutorial;

	public bool DoesAutoSave => !string.IsNullOrWhiteSpace(autosaveName);

	public string FullAutoSavePath => Path.Combine(Constants.persistentDataPath, "Saves", autosaveName + ".sav");

	private bool HasSeparateFullVersionLeaderboard
	{
		get
		{
			if (hasLeaderboard)
			{
				return hasSeparateFullVersionLeaderboard;
			}
			return false;
		}
	}

	public string FullSaveFileName => $"{saveFileName}_{DateTime.Now:yyyy-MM-dd-hh-mm-ss}";

	public LeaderboardType GetLeaderboard()
	{
		if (!hasLeaderboard)
		{
			Debug.Log($"{base.name} GetLeaderboard - has no leaderboard {hasLeaderboard}");
			return null;
		}
		if (HasSeparateFullVersionLeaderboard)
		{
			if (saveFileManager.ActiveSaveGame == null)
			{
				return leaderboard;
			}
			string initialVersion = saveFileManager.ActiveSaveGame.initialVersion;
			if (string.IsNullOrWhiteSpace(initialVersion))
			{
				Debug.LogError("checking if full version, but active savegame version is " + initialVersion);
				return leaderboard;
			}
			if (IsFullVersion(initialVersion))
			{
				return fullVersionLeaderboard;
			}
		}
		return leaderboard;
	}

	private bool IsFullVersion(string initialVersion)
	{
		string[] array = initialVersion.Split('.');
		if (array.Length == 0)
		{
			return false;
		}
		if (array[0] == "0")
		{
			return false;
		}
		if (array.Length < 2)
		{
			return false;
		}
		if (array[0] == "1" && array[1] != "0")
		{
			return true;
		}
		if (array.Length < 3 || !int.TryParse(array[2], out var result))
		{
			return false;
		}
		if (result < firstFullVersionPatch)
		{
			return false;
		}
		return true;
	}
}
