using System;
using System.Collections.Generic;
using Extensions;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Settings/Game Settings", fileName = "GameSettings")]
public class GameSettings : ScriptableObject
{
	[Serializable]
	public class CasinoFloorData
	{
		[Min(0.1f)]
		public float estimatedValueMultiplier = 1f;

		[Min(0f)]
		public long requiredQuotaToAccess = 3L;

		[Min(0f)]
		public int ticketReward = 5;

		[Min(1f)]
		public float shreddingEyePrice = 7f;

		[Min(1f)]
		public float shreddingMouthPrice = 5f;

		[Min(1f)]
		public float shreddingBodyPrice = 10f;

		public List<QuotaExcess> quotaExcessRewards = new List<QuotaExcess>();

		public int rerollCost = 2;
	}

	[Serializable]
	public class QuotaExcess
	{
		public float requirement;

		public int reward;
	}

	[Header("Game State")]
	public bool gameHasStarted;

	[Header("Game Speed")]
	[Tooltip("Global time scale for the game. 1.0 = normal speed, 0.5 = half speed, 2.0 = double speed")]
	[Range(0.5f, 100f)]
	public float timeScale = 1f;

	[Header("Settings")]
	[Tooltip("If false, API updates from GameSettingsAPIManager will be ignored")]
	public bool useAPIUpdates = true;

	public bool apiDebugMode;

	public int daysBeforeQuota = 3;

	public float dayDuration = 300f;

	public float bossMonologueDelay = 60f;

	public int dailyTicketReward = 1;

	[Range(0.5f, 1f)]
	public float catchUpFactor = 0.75f;

	public const long MaxQuota = 1000000000000000000L;

	[Header("Starting Values")]
	public long startingQuota = 100L;

	public long startingTicket = 3L;

	public long startingMoney = 75L;

	[Header("NPC Settings")]
	public int npcCount = 10;

	public float[] auxiliaryMoneyPercentage = new float[3];

	public float[] quotas = new float[12];

	public List<CasinoFloorData> floorData = new List<CasinoFloorData>();

	public static event Action<GameSettings> SettingsChanged;

	public long GetQuota(int index, long previousQuota, long currentMoney)
	{
		if (index == 0)
		{
			return Math.Min(startingQuota, 1000000000000000000L);
		}
		if (index >= quotas.Length)
		{
			double num = (float)currentMoney * quotas[^1];
			if (double.IsNaN(num) || double.IsInfinity(num) || num >= 1E+18 || num < 0.0)
			{
				return 1000000000000000000L;
			}
			return Math.Min((long)Math.Round(num), 1000000000000000000L);
		}
		double num2 = (float)(currentMoney - previousQuota) * catchUpFactor;
		double num3 = ((double)previousQuota + num2) * (double)quotas[index];
		if (double.IsNaN(num3) || double.IsInfinity(num3) || num3 >= 1E+18 || num3 < 0.0)
		{
			return 1000000000000000000L;
		}
		long num4 = FathF.RoundByFirstNDigits((long)Math.Round(num3), 2);
		if (num4 < 0)
		{
			return 1000000000000000000L;
		}
		return Math.Min(num4, 1000000000000000000L);
	}

	public int GetQuotaExcessReward(int floor, long quota, long money)
	{
		if (quota <= 0)
		{
			return 0;
		}
		float num = (float)((double)money / (double)quota);
		int result = 0;
		foreach (QuotaExcess quotaExcessReward in floorData[floor].quotaExcessRewards)
		{
			if (quotaExcessReward.requirement <= num)
			{
				result = quotaExcessReward.reward;
				continue;
			}
			break;
		}
		return result;
	}

	public long GetAuxiliaryMoney(int daysLeft, long quota)
	{
		int num = daysBeforeQuota - daysLeft;
		if (num >= auxiliaryMoneyPercentage.Length)
		{
			return 0L;
		}
		return (long)Math.Round(auxiliaryMoneyPercentage[num] * (float)quota);
	}

	public CasinoFloorData GetCurrentFloorData()
	{
		if (floorData == null || floorData.Count == 0)
		{
			Debug.LogWarning("GameSettings.GetCurrentFloorData: floorData is null or empty. Returning null.");
			return null;
		}
		int num = ((NetworkSingleton<GameManager>.Instance != null) ? NetworkSingleton<GameManager>.Instance.currentFloor : 0);
		if (num < 0)
		{
			Debug.LogWarning($"GameSettings.GetCurrentFloorData: floor index {num} is negative. Using floor 0 instead.");
			num = 0;
		}
		else if (num >= floorData.Count)
		{
			Debug.LogWarning($"GameSettings.GetCurrentFloorData: floor index {num} is out of range (max: {floorData.Count - 1}). Using last available floor.");
			num = floorData.Count - 1;
		}
		return floorData[num];
	}

	public int GetTicketReward(int day)
	{
		if (floorData == null || floorData.Count == 0)
		{
			Debug.LogWarning("GameSettings.GetTicketReward: floorData is null or empty. Returning default reward of 0.");
			return 0;
		}
		if (day < 0)
		{
			Debug.LogWarning($"GameSettings.GetTicketReward: floor index {day} is negative. Using floor 0 instead.");
			day = 0;
		}
		return floorData[DayToFloor(day)].ticketReward;
	}

	public int DayToFloor(int day)
	{
		int result = 0;
		for (int i = 0; i < floorData.Count && floorData[i].requiredQuotaToAccess <= day; i++)
		{
			result = i;
		}
		return result;
	}

	public void NotifyChanged()
	{
		GameSettings.SettingsChanged?.Invoke(this);
	}

	public void SetTimeScale(float newTimeScale)
	{
		timeScale = Mathf.Clamp(newTimeScale, 0.5f, 100f);
		Time.timeScale = timeScale;
		NotifyChanged();
	}
}
