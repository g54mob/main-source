using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FishingSimulator : MonoBehaviour
{
	[Header("Simulation Settings")]
	[Tooltip("If true, assumes you clicked the first available tile.")]
	public bool autoSelectTile = true;

	[Header("Debug Results")]
	public double lastSimulatedMoney;

	public int lastSimulatedXP;

	public string rarityDistribution;

	public PlayerManager playerManager;

	private void Update()
	{
	}

	[ContextMenu("Simulate Full Day")]
	public void SimulateDay()
	{
		if (playerManager == null || GameManager.Instance == null)
		{
			Debug.LogError("Managers not found! Make sure you are in the Gameplay Scene.");
			return;
		}
		int currentEnergy = playerManager.currentEnergy;
		int num = PlayerStats.Instance.EnergyCostPerCast;
		if (num <= 0)
		{
			num = 1;
		}
		int num2 = currentEnergy / num;
		if (num2 <= 0)
		{
			Debug.LogWarning("Not enough energy to simulate a day!");
			return;
		}
		ZoneData currentZone = GameManager.Instance.currentZone;
		Tile tile = FishingManager.Instance.currentTile;
		if (tile == null && autoSelectTile)
		{
			tile = Object.FindObjectOfType<Tile>();
		}
		Debug.Log($"<color=cyan>--- STARTING SIMULATION: {num2} CASTS ---</color>");
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		double num3 = 0.0;
		int num4 = 0;
		for (int i = 0; i < num2; i++)
		{
			CaughtFish caughtFish = DropChanceManager.Instance.RollForFish(currentZone, tile);
			if (caughtFish != null)
			{
				playerManager.inventory.AddFish(caughtFish);
				FishLogManager.Instance.LogFish(caughtFish);
				num3 += caughtFish.value;
				num4 += caughtFish.xpValue;
				if (!dictionary.ContainsKey(caughtFish.rarityName))
				{
					dictionary[caughtFish.rarityName] = 0;
				}
				dictionary[caughtFish.rarityName]++;
			}
			playerManager.UseEnergy();
		}
		lastSimulatedMoney = num3;
		lastSimulatedXP = num4;
		rarityDistribution = string.Join(", ", dictionary.Select((KeyValuePair<string, int> x) => $"{x.Key}: {x.Value}"));
		Debug.Log("<b>SIMULATION COMPLETE</b>\n" + $"Total Money: <color=green>${num3}</color>\n" + $"Total XP: <color=yellow>{num4}</color>\n" + "Breakdown: " + rarityDistribution);
		playerManager.EndDay();
	}
}
