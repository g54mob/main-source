using System;
using System.Collections.Generic;
using M4.Encoding;
using M4.Session;
using PajamaLlama.Fltsm;
using UnityEngine;
using UnityEngine.Events;

public class PlayerProfile
{
	private const string STATISTICS_FILE_NAME = "statistics.fst";

	private const long STATISTICS_FILE_SIZE = 262144L;

	private IUser user;

	private UnityAction loadCallback;

	private UnityAction resumeCallback;

	private List<string> _availableCommunityNames;

	public int UserId
	{
		get
		{
			if (user != null)
			{
				return user.Id;
			}
			return -1;
		}
	}

	public PlayerStatistics Statistics { get; private set; }

	public List<PlayerRun> Runs { get; private set; } = new List<PlayerRun>();

	public bool HasRuns => !Runs.IsNullOrEmpty();

	public PlayerRun ActiveRun { get; private set; }

	public Settings Data { get; private set; }

	public PlayerProfile(IUser user)
	{
		this.user = user;
	}

	public void UnlockAchievement(AchievementBase achievement)
	{
		if (Statistics.Achievements.UnlockAchievement(achievement))
		{
			user.UnlockAchievement(achievement);
			Save();
		}
	}

	public void StartRun(GameSetup gameSetup)
	{
		WorldManager.SetTileProperties(gameSetup.TileProperties);
		PlayerRun playerRun = new PlayerRun(this, gameSetup);
		Runs.Add(playerRun);
		LoadRun(playerRun);
	}

	public void StartDebugRun(bool loadGameScene = true)
	{
		foreach (PlayerRun run in Runs)
		{
			if (run.IsDebugRun)
			{
				LoadRun(run, loadGameScene);
				return;
			}
		}
		PlayerRun playerRun = new PlayerRun(this, "Editor Town", null, SaveInfo.EDITOR_SAVES_DIRECTORY);
		Runs.Add(playerRun);
		LoadRun(playerRun, loadGameScene);
	}

	public void LoadRun(PlayerRun run, bool loadGameScene = true)
	{
		ActiveRun?.End();
		ActiveRun = run;
		if (loadGameScene)
		{
			LoadingScreen.LoadScene("_02_GameWorld");
		}
	}

	public void BeginRun()
	{
		ActiveRun?.Begin();
	}

	public bool EndRun()
	{
		if (ActiveRun == null)
		{
			return false;
		}
		ActiveRun.End();
		ActiveRun = null;
		Save();
		LoadingScreen.LoadScene("_01_MainMenu");
		return true;
	}

	public void Load(UnityAction callback)
	{
		loadCallback = callback;
		user.LoadPlayerRuns(this, OnLoadPlayerRuns);
		user.LoadFile("statistics.fst", OnLoadJSONResult);
	}

	public void OnPlayerRunLoaded(string communityName, List<SaveMetaInfo> saveMetaInfos, string saveRoot)
	{
		Runs.Add(new PlayerRun(this, communityName, saveMetaInfos, saveRoot));
	}

	public void OnSaveMetaInfoLoaded(SaveMetaInfo saveMetaInfo)
	{
		if (!TryGetPlayerRun(out var run, saveMetaInfo.CommunityName))
		{
			run = new PlayerRun(this, saveMetaInfo);
			Runs.Add(run);
		}
		run.Saves.Add(new SaveInfo(saveMetaInfo));
	}

	public void RemoveRun(PlayerRun run)
	{
		Runs.Remove(run);
	}

	public void Resume(UnityAction callback)
	{
		resumeCallback = callback;
		if (user is DefaultUser)
		{
			user.LoadFile("statistics.fst", OnLoadJSONResult);
		}
	}

	public void Save()
	{
		if (user is DefaultUser)
		{
			user.SaveFile("statistics.fst", NoEncoding.GetBytes(JsonUtility.ToJson(Statistics)), OnSaveJSONResult);
		}
	}

	public bool TryLoadSave(out SaveInfo saveInfo, UnityAction<StorageActionResult> result_callback)
	{
		saveInfo = null;
		if (ActiveRun != null)
		{
			return ActiveRun.TryLoadSave(out saveInfo, result_callback);
		}
		return false;
	}

	public void LoadFile(string path, UnityAction<StorageActionResult> result_callback)
	{
		user.LoadFile(path, result_callback);
	}

	public void SaveFile(string path, byte[] data, UnityAction<StorageActionResult> result_callback)
	{
		user.SaveFile(path, data, result_callback);
	}

	public void RemoveFile(string path, UnityAction<StorageActionResult> result_callback)
	{
		user.RemoveFile(path, result_callback);
	}

	public void Clear()
	{
	}

	public void OnSaveFilesMigrated()
	{
		Runs.Clear();
		user.LoadPlayerRuns(this, OnLoadPlayerRuns);
	}

	private void OnLoadPlayerRuns()
	{
		foreach (PlayerRun run in Runs)
		{
			run.UpdateMostRecentSave();
		}
		Sorting.SlowSort(Runs);
	}

	private void OnLoadJSONResult(StorageActionResult result)
	{
		if (result.Succes)
		{
			try
			{
				Statistics = JsonUtility.FromJson<PlayerStatistics>(result.GetDataAsNoneEncodedString());
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Statistics = new PlayerStatistics();
			}
		}
		else
		{
			Statistics = new PlayerStatistics();
		}
		Statistics.Initialize(user, OnStatisticsInitialized);
	}

	private void OnSaveJSONResult(StorageActionResult result)
	{
		if (!result.Succes)
		{
			Debug.LogWarning("Unable to save JSON file: " + result.Filename);
		}
	}

	private void OnStatisticsInitialized()
	{
		if (loadCallback != null)
		{
			loadCallback();
			loadCallback = null;
		}
	}

	public bool HasInactiveRunWithCommunityName(string communityName)
	{
		foreach (PlayerRun run in Runs)
		{
			if (run != ActiveRun && run.CommunityName.Equals(communityName))
			{
				return true;
			}
		}
		return false;
	}

	public bool IsAchievementUnlocked(AchievementBase achievement)
	{
		bool flag = Statistics.Achievements.IsAchievementUnlocked(achievement.Id);
		bool flag2 = user.IsAchievementUnlocked(achievement.Id);
		if (flag != flag2 && !flag)
		{
			Statistics.Achievements.UnlockAchievement(achievement.Id);
		}
		return flag || flag2;
	}

	public bool IsEarlyAccesOwner()
	{
		return user.IsEarlyAccesOwner();
	}

	public bool OwnsDLC(PlatformId platformId)
	{
		return user.OwnsDLC(platformId);
	}

	public bool TryGetPlayerRun(out PlayerRun run, string communityName)
	{
		for (int i = 0; i < Runs.Count; i++)
		{
			run = Runs[i];
			if (run.CommunityName.Equals(communityName))
			{
				return true;
			}
		}
		run = null;
		return false;
	}

	public bool TryGetMostRecentlySavedRun(out PlayerRun playerRun)
	{
		if (Runs.IsNullOrEmpty() || Runs[0].MostRecentSave == null)
		{
			playerRun = null;
			return false;
		}
		playerRun = Runs[0];
		return true;
	}

	public bool TryGetCommunityName(out string communityName)
	{
		if (_availableCommunityNames == null)
		{
			_availableCommunityNames = new List<string>();
		}
		if (_availableCommunityNames.Count == 0)
		{
			GameSettings.Instance.DataSettings.GenerateCommunityNames(_availableCommunityNames);
			foreach (PlayerRun run in Runs)
			{
				_availableCommunityNames.Remove(run.CommunityName);
			}
		}
		if (_availableCommunityNames.Count == 0)
		{
			Debug.LogException(new Exception("Ran out of generated community names"));
			communityName = null;
			return false;
		}
		int index = UnityEngine.Random.Range(0, _availableCommunityNames.Count);
		communityName = _availableCommunityNames[index];
		_availableCommunityNames.RemoveAt(index);
		return true;
	}
}
