using UnityEngine;

[CreateAssetMenu(fileName = "SteamAchievement_completeLevel_default", menuName = "Tower Factory/Steam Achievements/Complete Level")]
public class SteamAchievement_completeLevel : SteamAchievement
{
	[Header("Complete Level")]
	[SerializeField]
	private LevelData levelData;

	public override void StartAchievement()
	{
		base.StartAchievement();
		if (!CheckLevelCompleted())
		{
			LTFunctionLibrary.GetLevelsProgressionManager().OnCompleteLevel += OnCompleteLevel;
			LevelsProgressionManager.instance.OnDataLoaded += OnLevelProgressionManagerLoaded;
		}
	}

	private bool CheckLevelCompleted()
	{
		LevelsProgressionManager.FLevelProgressionInfo[] levelProgressionInfos = LTFunctionLibrary.GetLevelsProgressionManager().LevelProgressionInfos;
		foreach (LevelsProgressionManager.FLevelProgressionInfo fLevelProgressionInfo in levelProgressionInfos)
		{
			if (fLevelProgressionInfo.LevelData.Id == levelData.Id && fLevelProgressionInfo.Completed)
			{
				UnlockAchievement();
				return true;
			}
		}
		return false;
	}

	private void OnLevelProgressionManagerLoaded()
	{
		CheckLevelCompleted();
	}

	private void OnCompleteLevel(LevelsProgressionManager.FLevelProgressionInfo info)
	{
		if (info.LevelData.Id == levelData.Id)
		{
			UnlockAchievement();
		}
	}
}
