using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchInfo : MonoBehaviour, ISavable
{
	public static MatchInfo instance;

	[SerializeField]
	private MatchSettings[] availableMatchSettings;

	[SerializeField]
	private MatchSettings defaultMatchSettings;

	[SerializeField]
	private MatchSettings tutorialMatchSettings;

	private MatchSettings currentMatchSettings;

	[Savable("savedMatchSettingsId", true, false)]
	private string savedMatchSettingsId;

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

	public MatchSettings CurrentMatchSettings
	{
		get
		{
			return currentMatchSettings ?? defaultMatchSettings;
		}
		set
		{
			currentMatchSettings = value;
			savedMatchSettingsId = currentMatchSettings.Id;
			SaveSystem.instance.SaveData();
		}
	}

	public MatchSettings SavedMatchSettings
	{
		get
		{
			if (savedMatchSettingsId != string.Empty)
			{
				MatchSettings[] array = availableMatchSettings;
				foreach (MatchSettings matchSettings in array)
				{
					if (matchSettings.Id == savedMatchSettingsId)
					{
						return matchSettings;
					}
				}
			}
			return defaultMatchSettings;
		}
	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			Object.DontDestroyOnLoad(base.gameObject);
			SceneManager.sceneLoaded += OnSceneLoaded;
			currentMatchSettings = defaultMatchSettings;
			OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{
		if (scene.buildIndex == 2)
		{
			currentMatchSettings = tutorialMatchSettings;
		}
		else
		{
			currentMatchSettings = SavedMatchSettings;
		}
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (hasLoadedSomething)
		{
			currentMatchSettings = SavedMatchSettings;
		}
	}

	public void OnPreLoad()
	{
	}

	public void OnSave()
	{
	}
}
