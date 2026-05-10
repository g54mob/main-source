using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SteamAchievement_defeatBoss_default", menuName = "Tower Factory/Steam Achievements/Defeat Boss")]
public class SteamAchievement_defeatBoss : SteamAchievement
{
	[Header("Defeat Boss")]
	[SerializeField]
	private EnemyData bossData;

	public override void StartAchievement()
	{
		base.StartAchievement();
		if (!CheckBossDefeated())
		{
			LTFunctionLibrary.GetLevelsProgressionManager().OnDefeatBoss += OnDefeatBoss;
			LevelsProgressionManager.instance.OnDataLoaded += OnLevelProgressionManagerLoaded;
		}
	}

	private bool CheckBossDefeated()
	{
		LevelsProgressionManager.FLevelProgressionInfo[] levelProgressionInfos = LTFunctionLibrary.GetLevelsProgressionManager().LevelProgressionInfos;
		foreach (LevelsProgressionManager.FLevelProgressionInfo fLevelProgressionInfo in levelProgressionInfos)
		{
			List<EnemyData> list = fLevelProgressionInfo.LevelData.LevelSpawners?.GetLevelBosses();
			if (list != null && fLevelProgressionInfo.BossDefeated && list.Exists((EnemyData x) => x.Id == bossData.Id))
			{
				UnlockAchievement();
				return true;
			}
		}
		return false;
	}

	private void OnLevelProgressionManagerLoaded()
	{
		CheckBossDefeated();
	}

	private void OnDefeatBoss(EnemyData data)
	{
		if (bossData.Id == data.Id)
		{
			UnlockAchievement();
		}
	}
}
