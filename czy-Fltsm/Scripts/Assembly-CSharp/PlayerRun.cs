using System;
using System.Collections.Generic;
using M4.Session;
using PajamaLlama.Flotsam;
using PajamaLlama.Fltsm;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRun : IRun, IComparable<PlayerRun>
{
	private PlayerRunPersistentData _persistentData;

	private string _saveRoot = string.Empty;

	private string _savePath;

	private string _autosavePath;

	private SaveInfo _saveToLoad;

	private SaveInfo _saveToSave;

	private SaveInfo _saveToRemove;

	private SaveInfo _lastManualSave;

	private float duration;

	public PlayerProfile Profile { get; private set; }

	public Guid Id => _persistentData.Id;

	public string CommunityName => _persistentData.CommunityName;

	public List<SaveInfo> Saves => _persistentData.Saves;

	public SaveInfo LoadedSave => _saveToLoad;

	public bool Tutorial => _persistentData.Tutorial;

	public float Duration => duration;

	public SaveInfo MostRecentSave { get; private set; }

	public bool IsDebugRun
	{
		get
		{
			if (Application.isEditor)
			{
				return CommunityName.Equals("Editor Town");
			}
			return false;
		}
	}

	public bool IsTutorial => _persistentData.Tutorial;

	public BuildableProperties TownheartProperties { get; private set; }

	public PlayerRun(PlayerProfile profile, GameSetup gameSetup)
		: this(profile, profile.TryGetCommunityName(out var communityName) ? communityName : string.Empty, gameSetup.IsTutorial)
	{
		TownheartProperties = gameSetup.TownheartProperties;
		if (Session.Platform is PlatformDefault || Session.Platform is PlatformSteam)
		{
			SetSaveRoot(SaveInfo.PLAYER_SAVES_DIRECTORY);
		}
	}

	public PlayerRun(PlayerProfile profile, SaveMetaInfo saveMetaInfo)
		: this(profile, saveMetaInfo.CommunityName, tutorial: false)
	{
		if (Session.Platform is PlatformDefault || Session.Platform is PlatformSteam)
		{
			SetSaveRoot(SaveInfo.PLAYER_SAVES_DIRECTORY);
		}
	}

	public PlayerRun(PlayerProfile profile, string communityName, List<SaveMetaInfo> saves, string saveRoot)
		: this(profile, communityName, tutorial: false)
	{
		if (saves != null)
		{
			foreach (SaveMetaInfo safe in saves)
			{
				_persistentData.Saves.Add(new SaveInfo(safe));
			}
		}
		SetSaveRoot(saveRoot);
		UpdateMostRecentSave();
	}

	private PlayerRun(PlayerProfile profile, string communityName, bool tutorial)
	{
		Profile = profile;
		_persistentData = new PlayerRunPersistentData(communityName, tutorial);
		SetSavePaths(communityName);
	}

	public void Begin()
	{
		GameEventDispatcher.AddListener(GameEventType.GameStart, OnGameStart);
	}

	public bool SetCommunityName(string name)
	{
		if (_persistentData.SetCommunityName(name))
		{
			Community.PlayerCommunity.Name = name;
			SetSavePaths(name);
			if (!IsDebugRun)
			{
				Save(Community.PlayerCommunity.Name);
			}
			return true;
		}
		return false;
	}

	public void End()
	{
		GameEventDispatcher.Dispatch(GameEventType.GameEnd);
		GameManager.GameStatsManager?.Clear();
		ItemFilter.ResetCopyPaste();
	}

	private void SetSaveRoot(string saveRoot)
	{
		_saveRoot = saveRoot;
		SetSavePaths(CommunityName);
	}

	private void SetSavePaths(string communityName)
	{
		_savePath = _saveRoot + communityName + "/";
		_autosavePath = _savePath + "Autosaves/";
	}

	public void Continue(SaveInfo saveInfo = null)
	{
		_saveToLoad = ((saveInfo != null) ? saveInfo : MostRecentSave);
		if (_saveToLoad.Type == SaveType.Manual)
		{
			_lastManualSave = _saveToLoad;
		}
		else
		{
			TryGetMostRecentSave(out _lastManualSave, SaveType.Manual);
		}
		GameEventDispatcher.Dispatch(GameEventType.GameEnd);
		Profile.LoadRun(this);
	}

	public void UpdateMostRecentSave()
	{
		if (!_persistentData.Saves.IsNullOrEmpty())
		{
			Sorting.SlowSort(_persistentData.Saves);
			MostRecentSave = _persistentData.Saves[0];
		}
	}

	public void Update()
	{
		if (GameSpeedManager.GameSpeed != GameSpeed.Paused)
		{
			duration += Time.unscaledDeltaTime;
		}
	}

	public bool TryLoadSave(out SaveInfo saveInfo, UnityAction<StorageActionResult> result_callback)
	{
		saveInfo = _saveToLoad;
		if (saveInfo != null)
		{
			Profile.LoadFile(saveInfo.Path, result_callback);
			return true;
		}
		return false;
	}

	public void Save(string name, SaveType type = SaveType.Manual)
	{
		string path = ((type == SaveType.Autosave) ? _autosavePath : _savePath) + name + ".fs";
		Save(new SaveInfo(path, type));
	}

	public void Save(SaveInfo saveInfo)
	{
		if (FlotsamSaveTask.Queue(Profile, saveInfo))
		{
			_saveToSave = saveInfo;
			GameEventDispatcher.AddListener(GameEventType.AsyncSaveCompleted, OnSaveTaskCompleted);
		}
		else
		{
			Debug.LogException(new Exception("Unable to save '" + saveInfo.Path + "'"));
		}
	}

	public void RemoveSave(SaveInfo saveInfo)
	{
		if (Saves.Contains(saveInfo))
		{
			_saveToRemove = saveInfo;
			Profile.RemoveFile(saveInfo.Path, OnSaveRemoved);
		}
	}

	public int CompareTo(PlayerRun other)
	{
		if (MostRecentSave == null)
		{
			return 1;
		}
		if (other == null || other.MostRecentSave == null)
		{
			return -1;
		}
		return other.MostRecentSave.TimeStamp.CompareTo(MostRecentSave.TimeStamp);
	}

	private void OnGameStart(GameEvent gameEvent)
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, OnGameStart);
		GameEventDispatcher.AddListener(GameEventType.GameEnd, OnGameEnd);
		GameEventDispatcher.AddListener(GameEventType.DayStarted, OnAutosave);
	}

	private void OnGameEnd(GameEvent gameEvent)
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, OnGameStart);
		GameEventDispatcher.RemoveListener(GameEventType.GameEnd, OnGameEnd);
		GameEventDispatcher.RemoveListener(GameEventType.DayStarted, OnAutosave);
	}

	private void OnAutosave(GameEvent gameEvent)
	{
		string name = $"Autosave Day {GameManager.TimeManager.Days.Count}";
		if (_persistentData.TryGetSave(out var save, name, SaveType.Autosave))
		{
			Save(save);
			return;
		}
		int autosaveLimit = Settings.Instance.GameplayPlayerData.AutosaveLimit;
		using ListPool<SaveInfo>.List list = GetAutosaves();
		while (autosaveLimit > 0 && list.Count > autosaveLimit)
		{
			RemoveSave(list[list.Count - 1]);
			list.RemoveAt(list.Count - 1);
		}
		Save(name, SaveType.Autosave);
	}

	private void OnSaveTaskCompleted(GameEvent gameEvent)
	{
		if (!(gameEvent is AsyncSaveEvent asyncSaveEvent))
		{
			return;
		}
		GameEventDispatcher.RemoveListener(GameEventType.AsyncSaveCompleted, OnSaveTaskCompleted);
		if (asyncSaveEvent.SaveTask.Success)
		{
			MostRecentSave = asyncSaveEvent.SaveTask.SaveInfo;
			if (MostRecentSave.Type == SaveType.Manual)
			{
				_lastManualSave = MostRecentSave;
			}
			int eventType = (Saves.AddUnique(MostRecentSave) ? 1200 : 1202);
			Sorting.SlowSort(Saves);
			if (MostRecentSave.Type == SaveType.Autosave)
			{
				PruneAutoSaves();
			}
			SaveEvent.Dispatch((GameEventType)eventType, asyncSaveEvent.SaveTask.SaveInfo);
		}
		else
		{
			PopUpDialog.Instance.TryOpenPopUpDialog(GameSettings.Instance.UISettings.SaveFailedDialogProperties);
		}
	}

	private void PruneAutoSaves()
	{
		if (Application.isEditor && Session.Platform is PlatformDefault)
		{
			return;
		}
		int autosaveLimit = Settings.Instance.GameplayPlayerData.AutosaveLimit;
		int num = 0;
		int count = Saves.Count;
		int i;
		for (i = 0; i < count; i++)
		{
			if (Saves[i].Type == SaveType.Autosave)
			{
				num++;
				if (num > autosaveLimit)
				{
					break;
				}
			}
		}
		int index = count;
		while (i < index--)
		{
			SaveInfo saveInfo = Saves[index];
			if (saveInfo.Type == SaveType.Autosave)
			{
				RemoveSave(saveInfo);
			}
		}
	}

	private void OnSaveRemoved(StorageActionResult result)
	{
		if (result.Succes)
		{
			Saves.Remove(_saveToRemove);
			if (Saves.Count == 0)
			{
				Profile.RemoveRun(this);
			}
			SaveEvent.Dispatch(GameEventType.SaveRemoved, _saveToRemove);
		}
	}

	public bool TryGetSave(out SaveInfo save, string name)
	{
		return _persistentData.TryGetSave(out save, name);
	}

	public bool TryGetLastSave(out SaveInfo save)
	{
		save = _lastManualSave;
		return save != null;
	}

	public bool TryGetMostRecentSave(out SaveInfo save, SaveType type)
	{
		Sorting.SlowSort(Saves);
		for (int i = 0; i < Saves.Count; i++)
		{
			save = Saves[i];
			if (save.Type == type)
			{
				return true;
			}
		}
		save = null;
		return false;
	}

	public ListPool<SaveInfo>.List GetAutosaves()
	{
		ListPool<SaveInfo>.List list = ListPool<SaveInfo>.Get();
		foreach (SaveInfo safe in Saves)
		{
			if (safe.Type == SaveType.Autosave)
			{
				list.Add(safe);
			}
		}
		Sorting.SlowSort(list);
		return list;
	}
}
