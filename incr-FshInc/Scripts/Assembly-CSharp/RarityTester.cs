using System.Collections.Generic;
using UnityEngine;

public class RarityTester : MonoBehaviour
{
	public Fish fishToTest;

	private void Update()
	{
	}

	public void TestRarity(int fishLevel)
	{
		Debug.Log("--- STARTING RARITY TEST (Player Skills) ---");
		Dictionary<FishRarity, float> globalRarityPercentagesWithBonuses = DropChanceManager.Instance.GetGlobalRarityPercentagesWithBonuses();
		Debug.LogFormat("GLOBAL CHANCES (After Skills): C: {0:P2}, U: {1:P2}, R: {2:P2}, E: {3:P2}, L: {4:P2}", globalRarityPercentagesWithBonuses[FishRarity.Common], globalRarityPercentagesWithBonuses[FishRarity.Uncommon], globalRarityPercentagesWithBonuses[FishRarity.Rare], globalRarityPercentagesWithBonuses[FishRarity.Epic], globalRarityPercentagesWithBonuses[FishRarity.Legendary]);
		Debug.Log($"--- APPLYING FISH LEVEL SHIFT (Fish Level: {fishLevel}) ---");
		Dictionary<FishRarity, float> levelModifiedRarityWeights = fishToTest.GetLevelModifiedRarityWeights(fishLevel);
		float num = 0f;
		foreach (float value in levelModifiedRarityWeights.Values)
		{
			num += value;
		}
		Debug.LogFormat("<color=cyan>FINAL CHANCES (To Catch): C: {0:P2}, U: {1:P2}, R: {2:P2}, E: {3:P2}, L: {4:P2}</color>", levelModifiedRarityWeights[FishRarity.Common] / num, levelModifiedRarityWeights[FishRarity.Uncommon] / num, levelModifiedRarityWeights[FishRarity.Rare] / num, levelModifiedRarityWeights[FishRarity.Epic] / num, levelModifiedRarityWeights[FishRarity.Legendary] / num);
	}
}
