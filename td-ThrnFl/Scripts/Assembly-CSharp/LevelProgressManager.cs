using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgressManager : MonoBehaviour
{
	public static LevelProgressManager instance;

	public LevelInfo[] levelInfos;

	[Header("Generated Data:")]
	[SerializeField]
	private SceneNameToLevelData sceneNameToLevelData = new SceneNameToLevelData();

	[Header("Tips Shown:")]
	public List<string> tipsShown;

	private static Dictionary<string, bool> sceneExistsCache = new Dictionary<string, bool>();

	public int EternalTrialsHighscore { get; set; }

	public SceneNameToLevelData SceneNameToLevelData => sceneNameToLevelData;

	public LevelInfo GetLevelInfoFromSceneName(string _sceneName)
	{
		for (int i = 0; i < levelInfos.Length; i++)
		{
			if (levelInfos[i].sceneName == _sceneName)
			{
				return levelInfos[i];
			}
		}
		return null;
	}

	public LevelInfo GetLevelInfoFromCurrentSceneName()
	{
		for (int i = 0; i < SceneManager.sceneCount; i++)
		{
			Scene sceneAt = SceneManager.GetSceneAt(i);
			if (sceneAt.isLoaded)
			{
				LevelInfo levelInfoFromSceneName = GetLevelInfoFromSceneName(sceneAt.name);
				if (levelInfoFromSceneName != null)
				{
					return levelInfoFromSceneName;
				}
			}
		}
		return null;
	}

	public bool StartsWithUnderscore(string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return false;
		}
		return input[0] == '_';
	}

	public bool AreAllBuildOptionsUnlockedInThisLevel()
	{
		LevelInfo levelInfoFromCurrentSceneName = GetLevelInfoFromCurrentSceneName();
		if (LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.EternalTrial)
		{
			return true;
		}
		if (levelInfoFromCurrentSceneName == null)
		{
			return false;
		}
		return levelInfoFromCurrentSceneName.allBuildingChoicesUnlocked;
	}

	private void Awake()
	{
		if ((bool)instance)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.transform.root.gameObject);
	}

	public LevelData GetLevelDataForScene(string _sceneName)
	{
		if (_sceneName == SceneTransitionManager.instance.levelSelectScene)
		{
			return null;
		}
		if (StartsWithUnderscore(_sceneName))
		{
			return null;
		}
		if (sceneNameToLevelData.ContainsKey(_sceneName))
		{
			return sceneNameToLevelData[_sceneName];
		}
		LevelData levelData = new LevelData();
		sceneNameToLevelData.Add(_sceneName, levelData);
		return levelData;
	}

	public LevelData GetLevelDataForActiveScene()
	{
		string sceneName = SceneManager.GetActiveScene().name;
		return GetLevelDataForScene(sceneName);
	}

	public static bool SceneExists(string sceneName)
	{
		if (sceneExistsCache.TryGetValue(sceneName, out var value))
		{
			return value;
		}
		value = false;
		int sceneCountInBuildSettings = SceneManager.sceneCountInBuildSettings;
		for (int i = 0; i < sceneCountInBuildSettings; i++)
		{
			if (Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i)).Equals(sceneName, StringComparison.OrdinalIgnoreCase))
			{
				value = true;
				break;
			}
		}
		sceneExistsCache[sceneName] = value;
		return value;
	}

	public int CrownsAvailabe()
	{
		int num = 0;
		if (levelInfos == null)
		{
			return -1;
		}
		LevelInfo[] array = levelInfos;
		foreach (LevelInfo levelInfo in array)
		{
			if (!(levelInfo == null) && SceneExists(levelInfo.sceneName) && levelInfo.contribution == LevelInfo.ProgressionContribution.Crowns)
			{
				num += levelInfo.QuestsTotal();
			}
		}
		return num;
	}

	public int CrownsAchieved()
	{
		int num = 0;
		if (levelInfos == null)
		{
			return -1;
		}
		LevelInfo[] array = levelInfos;
		foreach (LevelInfo levelInfo in array)
		{
			if (!(levelInfo == null) && SceneExists(levelInfo.sceneName) && levelInfo.contribution == LevelInfo.ProgressionContribution.Crowns)
			{
				num += levelInfo.QuestsComplete();
			}
		}
		return num;
	}
}
