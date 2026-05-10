using System;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;

[CreateAssetMenu(fileName = "SteamAchievement_killEnemies_default", menuName = "Tower Factory/Steam Achievements/Kill Enemies")]
public class SteamAchievement_killEnemies : SteamAchievement
{
	[Serializable]
	private class FEnemyInfo
	{
		[SerializeField]
		private EnemyData enemyData;

		[SerializeField]
		private int amountToKill;

		[SerializeField]
		private string statId;

		private int alreadyKilledAmount;

		public EnemyData EnemyData => enemyData;

		public int AmountToKill => amountToKill;

		public string StatId => statId;

		public int AlreadyKilledAmount
		{
			get
			{
				return alreadyKilledAmount;
			}
			set
			{
				alreadyKilledAmount = value;
			}
		}
	}

	[Header("Kill Enemies")]
	[SerializeField]
	private List<FEnemyInfo> enemyInfos;

	public override void StartAchievement()
	{
		base.StartAchievement();
		foreach (FEnemyInfo enemyInfo in enemyInfos)
		{
			SteamUserStats.GetStat(enemyInfo.StatId, out int pData);
			enemyInfo.AlreadyKilledAmount = pData;
		}
	}

	protected override void OnStartGame()
	{
		base.OnStartGame();
		LTFunctionLibrary.GetGameStatsManager().onEnemyKilled += OnEnemyKilled;
	}

	private void CheckAchievementCompleted()
	{
		foreach (FEnemyInfo enemyInfo in enemyInfos)
		{
			if (enemyInfo.AlreadyKilledAmount < enemyInfo.AmountToKill)
			{
				return;
			}
		}
		UnlockAchievement();
		LTFunctionLibrary.GetGameStatsManager().onEnemyKilled -= OnEnemyKilled;
	}

	private void OnEnemyKilled(string enemyID, int totalAmount)
	{
		foreach (FEnemyInfo enemyInfo in enemyInfos)
		{
			if (enemyID == enemyInfo.EnemyData.Id)
			{
				enemyInfo.AlreadyKilledAmount++;
				SteamUserStats.SetStat(enemyInfo.StatId, enemyInfo.AlreadyKilledAmount);
				SteamUserStats.StoreStats();
				CheckAchievementCompleted();
				break;
			}
		}
	}
}
