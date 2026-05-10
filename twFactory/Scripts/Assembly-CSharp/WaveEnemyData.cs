using System;
using UnityEngine;

[Serializable]
public class WaveEnemyData
{
	[SerializeField]
	private GameObject enemyToSpawn;

	[SerializeField]
	private int amountToSpawn = 1;

	[SerializeField]
	private float inBetweenSpawnsTime = 1f;

	[SerializeField]
	private float extraInBetweenSpawnsTime;

	[SerializeField]
	private bool autoInBetweenSpawnsTime = true;

	[SerializeField]
	private int enemyEssence;

	public GameObject EnemyToSpawn
	{
		get
		{
			return enemyToSpawn;
		}
		set
		{
			enemyToSpawn = value;
			AutoCalculateInBetweenTime();
		}
	}

	public int AmountToSpawn
	{
		get
		{
			return amountToSpawn;
		}
		set
		{
			amountToSpawn = value;
		}
	}

	public float InBetweenSpawnsTime => inBetweenSpawnsTime;

	public int EnemyEssence
	{
		get
		{
			return enemyEssence;
		}
		set
		{
			enemyEssence = value;
		}
	}

	public float ExtraInBetweenSpawnsTime
	{
		get
		{
			return extraInBetweenSpawnsTime;
		}
		set
		{
			extraInBetweenSpawnsTime = value;
			AutoCalculateInBetweenTime();
		}
	}

	private void AutoCalculateInBetweenTime()
	{
		if (autoInBetweenSpawnsTime)
		{
			float num = FunctionLibrary.GetObjectRadius(EnemyToSpawn) * 2f;
			float configStat = EnemyToSpawn.GetComponent<StatsComponent>().GetConfigStat(EStats.MovementSpeed);
			inBetweenSpawnsTime = num / configStat + ExtraInBetweenSpawnsTime + 0.05f;
		}
		else
		{
			ExtraInBetweenSpawnsTime = 0f;
		}
	}

	public float CalculateTotalStat(EStats stat)
	{
		if (!EnemyToSpawn)
		{
			return 0f;
		}
		return EnemyToSpawn.GetComponent<StatsComponent>().GetConfigStat(stat) * (float)AmountToSpawn;
	}

	public float CalculateDuration()
	{
		return (float)(AmountToSpawn - 1) * InBetweenSpawnsTime;
	}

	private string GetTotalLifeText()
	{
		int num = (int)CalculateTotalStat(EStats.HealthMax);
		int num2 = (int)CalculateTotalStat(EStats.ArmorMax);
		int num3 = (int)CalculateTotalStat(EStats.ShieldMax);
		string text = "Total life: " + (num + num2 + num3);
		text = text + "\nHealth: " + num;
		if (num2 > 0)
		{
			text = text + "\nArmor: " + num2;
		}
		if (num3 > 0)
		{
			text = text + "\nShield: " + num3;
		}
		return text;
	}

	public float GetEnemyEssencePerEnemy()
	{
		return (float)EnemyEssence / (float)AmountToSpawn;
	}

	private string GetEnemyEssencePerEnemyText()
	{
		return "Essence per enemy: " + FunctionLibrary.RoundToDecimals(GetEnemyEssencePerEnemy(), 2);
	}
}
