using UnityEngine;

public static class SaveDebugLogger
{
	public static void LogMetaSave(MetaSavefile save)
	{
		Debug.Log("=== MetaSavefile Debug ===");
		Debug.Log($"cores: {save.cores}");
		Debug.Log($"totalCores: {save.totalCores}");
		Debug.Log("radarUpgradesBought: " + string.Join(",", save.radarUpgradesBought));
		Debug.Log("radarUpgradesToggledOff: " + string.Join(",", save.radarUpgradesToggledOff));
		Debug.Log($"isTutorialCompleted: {save.isTutorialCompleted}");
		Debug.Log("savedMilestoneNames: " + string.Join(",", save.savedMilestoneNames));
		Debug.Log("savedMilestoneCompleted: " + string.Join(",", save.savedMilestoneCompleted));
		Debug.Log("savedMilestoneProgress: " + string.Join(",", save.savedMilestoneProgress));
		Debug.Log($"mostEnemiesKilled: {save.mostEnemiesKilled}");
		Debug.Log($"mostDamageDealt: {save.mostDamageDealt}");
		Debug.Log($"totalEnemiesKilled: {save.totalEnemiesKilled}");
		Debug.Log($"totalKilometersTraveled: {save.totalKilometersTraveled}");
		Debug.Log($"totalJourneys: {save.totalJourneys}");
		Debug.Log($"isRadarFixed: {save.isRadarFixed}");
		Debug.Log($"isPaintStationFixed: {save.isPaintStationFixed}");
		Debug.Log($"isDifficultyStationFixed: {save.isDifficultyStationFixed}");
		Debug.Log($"currentDifficultyIndex: {save.currentDifficultyIndex}");
		Debug.Log("unlockedDifficultyIndexes: " + string.Join(",", save.unlockedDifficultyIndexes));
		Debug.Log($"isFirstLoad: {save.isFirstLoad}");
		Debug.Log("===========================");
	}
}
