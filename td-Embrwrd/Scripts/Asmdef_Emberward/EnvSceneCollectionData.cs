using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnvSceneCollectionData", menuName = "設定檔/環境場景資料 (EnvSceneCollectionData)", order = 1)]
public class EnvSceneCollectionData : ScriptableObject
{
	[Serializable]
	public class EnvSceneDataEntry
	{
		public bool enableInRandomPick;

		public int index;

		public string name;

		public StageSettingData presetStageData;

		public eWorldType worldType;

		public eMusicType musicType;

		public bool isBossStage;

		public bool canHavePathLengthQuest;

		public eStageDifficulty stageLevel;

		public Sprite levelPhoto;

		public int weight;
	}

	public List<EnvSceneDataEntry> sceneEntries;

	public void ResetStageWeights()
	{
	}

	private bool IsAvailableForChaosRealm(eWorldType worldType, eWorldType excludeWorld)
	{
		return false;
	}

	public EnvSceneDataEntry GetRandomScene(eWorldType worldType, bool isBossStage, int difficulty)
	{
		return null;
	}

	private int GetScenePlayedCount(eWorldType worldType, int index)
	{
		return 0;
	}

	public bool IsSceneBossStage(string sceneName)
	{
		return false;
	}

	public eWorldType GetSceneWorldType(string sceneName)
	{
		return default(eWorldType);
	}

	public EnvSceneDataEntry GetSceneEntryByName(string name)
	{
		return null;
	}

	public EnvSceneDataEntry GetSceneEntryByType(eWorldType worldType, bool isBossStage, eStageDifficulty stageLevel)
	{
		return null;
	}

	public bool CanHavePathLengthQuest(string sceneName)
	{
		return false;
	}

	public static bool IsSceneInBuild(string sceneName)
	{
		return false;
	}

	private void SortSceneByName()
	{
	}
}
