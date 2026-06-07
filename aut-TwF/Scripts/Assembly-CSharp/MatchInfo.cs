using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchInfo : MonoBehaviour, ISavable
{
	public static MatchInfo instance;

	[SerializeField]
	private GameMode[] availableGameModes;

	[SerializeField]
	private GameMode defaultGameMode;

	[SerializeField]
	private GameMode tutorialGameMode;

	private GameMode currentGameMode;

	[Savable("currentMatchSettings", true, false)]
	private MatchSettings currentMatchSettings;

	[Savable("savedGameModeId", true, false)]
	private string savedGameModeId;

	private LevelData currentLevelData;

	[Savable("currentMatchMode", true, false)]
	private EMatchMode currentMatchMode;

	public LevelData CurrentLevelData
	{
		get
		{
			return currentLevelData;
		}
		set
		{
			currentLevelData = value;
		}
	}

	public EMatchMode CurrentMatchMode
	{
		get
		{
			return currentMatchMode;
		}
		set
		{
			currentMatchMode = value;
		}
	}

	public GameMode CurrentGameMode
	{
		get
		{
			return currentGameMode ?? defaultGameMode;
		}
		set
		{
			currentGameMode = value;
			savedGameModeId = currentGameMode.Id;
			if (currentMatchSettings == null)
			{
				currentMatchSettings = new MatchSettings();
			}
			currentMatchSettings.ApplyGameMode(currentGameMode);
			SaveSystem.instance.SaveData();
		}
	}

	public MatchSettings CurrentMatchSettings => currentMatchSettings;

	public GameMode SavedGameMode
	{
		get
		{
			if (savedGameModeId != string.Empty)
			{
				GameMode[] array = availableGameModes;
				foreach (GameMode gameMode in array)
				{
					if (gameMode.Id == savedGameModeId)
					{
						return gameMode;
					}
				}
			}
			return defaultGameMode;
		}
	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			Object.DontDestroyOnLoad(base.gameObject);
			SceneManager.sceneLoaded += OnSceneLoaded;
			CurrentGameMode = defaultGameMode;
			OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	public void SetGameModeById(string gameModeId)
	{
		GameMode[] array = availableGameModes;
		int num = 0;
		if (num < array.Length)
		{
			GameMode gameMode = array[num];
			if (gameMode.Id == gameModeId)
			{
				CurrentGameMode = gameMode;
			}
		}
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		if (scene.buildIndex == 2)
		{
			CurrentGameMode = tutorialGameMode;
		}
		else
		{
			CurrentGameMode = SavedGameMode;
		}
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (hasLoadedSomething)
		{
			CurrentGameMode = SavedGameMode;
		}
	}

	public void OnPreLoad()
	{
	}

	public void OnSave()
	{
	}
}
