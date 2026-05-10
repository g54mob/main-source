using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSpawnerConfig_default", menuName = "Tower Factory/Spawners/Wave Spawner Config")]
public class WaveSpawnerConfig : ScriptableObject
{
	[SerializeField]
	private float mainWaveStartDelay;

	[SerializeField]
	private float secondaryWaveStartDelay;

	[SerializeField]
	private List<WaveEnemyData> mainWaveEnemies;

	[SerializeField]
	private List<WaveEnemyData> secondaryWaveEnemies;

	public List<WaveEnemyData> MainWaveEnemies
	{
		get
		{
			return mainWaveEnemies;
		}
		set
		{
			mainWaveEnemies = value;
		}
	}

	public List<WaveEnemyData> SecondaryWaveEnemies
	{
		get
		{
			return secondaryWaveEnemies;
		}
		set
		{
			secondaryWaveEnemies = value;
		}
	}

	public float MainWaveStartDelay
	{
		get
		{
			return mainWaveStartDelay;
		}
		set
		{
			mainWaveStartDelay = value;
		}
	}

	public float SecondaryWaveStartDelay
	{
		get
		{
			return secondaryWaveStartDelay;
		}
		set
		{
			secondaryWaveStartDelay = value;
		}
	}

	public float GetMinStartDelay()
	{
		float a = ((mainWaveEnemies != null && mainWaveEnemies.Count > 0) ? mainWaveStartDelay : float.PositiveInfinity);
		float b = ((secondaryWaveEnemies != null && secondaryWaveEnemies.Count > 0) ? secondaryWaveStartDelay : float.PositiveInfinity);
		return Mathf.Min(a, b);
	}

	public static float CalculateInBetweenTimeDifferentEnemies(WaveEnemyData firstEnemy, WaveEnemyData secondEnemy)
	{
		float configStat = firstEnemy.EnemyToSpawn.GetComponent<StatsComponent>().GetConfigStat(EStats.MovementSpeed);
		float objectRadius = FunctionLibrary.GetObjectRadius(firstEnemy.EnemyToSpawn.gameObject);
		float objectRadius2 = FunctionLibrary.GetObjectRadius(secondEnemy.EnemyToSpawn.gameObject);
		return (objectRadius + objectRadius2) / configStat + 0.05f;
	}

	public float CalculateMainWaveDuration(float customStartDelay = -1f)
	{
		return CalculateWaveDuration(mainWaveEnemies, (customStartDelay >= 0f) ? customStartDelay : mainWaveStartDelay);
	}

	public float CalculateSecondaryWaveDuration(float customStartDelay = -1f)
	{
		return CalculateWaveDuration(secondaryWaveEnemies, (customStartDelay >= 0f) ? customStartDelay : secondaryWaveStartDelay);
	}

	private float CalculateWaveDuration(List<WaveEnemyData> enemyDatas, float startDelay)
	{
		if (enemyDatas == null || enemyDatas.Count == 0)
		{
			return 0f;
		}
		float num = startDelay;
		bool flag = false;
		for (int i = 0; i < enemyDatas.Count; i++)
		{
			if (enemyDatas[i].EnemyToSpawn == null || enemyDatas[i].AmountToSpawn <= 0)
			{
				continue;
			}
			flag = true;
			if (i > 0)
			{
				for (int num2 = i - 1; num2 >= 0; num2--)
				{
					if (enemyDatas[num2].AmountToSpawn > 0)
					{
						num += CalculateInBetweenTimeDifferentEnemies(enemyDatas[num2], enemyDatas[i]);
						break;
					}
				}
			}
			num += enemyDatas[i].CalculateDuration();
		}
		if (!flag)
		{
			return 0f;
		}
		return num;
	}

	public int CalculateTotalStat(EStats stat)
	{
		return CalculateWaveTotalStat(mainWaveEnemies, stat) + CalculateWaveTotalStat(secondaryWaveEnemies, stat);
	}

	private int CalculateWaveTotalStat(List<WaveEnemyData> waveEnemyDatas, EStats stat)
	{
		int num = 0;
		for (int i = 0; i < waveEnemyDatas.Count; i++)
		{
			num += (int)waveEnemyDatas[i].CalculateTotalStat(stat);
		}
		return num;
	}

	public int CalculateTotalEnemiesAmount()
	{
		return CalculateWaveTotalEnemiesAmount(mainWaveEnemies) + CalculateWaveTotalEnemiesAmount(secondaryWaveEnemies);
	}

	private int CalculateWaveTotalEnemiesAmount(List<WaveEnemyData> waveEnemyDatas)
	{
		int num = 0;
		for (int i = 0; i < waveEnemyDatas.Count; i++)
		{
			if (!(waveEnemyDatas[i].EnemyToSpawn == null))
			{
				num += waveEnemyDatas[i].AmountToSpawn;
			}
		}
		return num;
	}

	public int CalculateTotalEnemiesAmountByType(GameObject type)
	{
		return CalculateWaveTotalEnemiesAmountByType(mainWaveEnemies, type) + CalculateWaveTotalEnemiesAmountByType(secondaryWaveEnemies, type);
	}

	private int CalculateWaveTotalEnemiesAmountByType(List<WaveEnemyData> waveEnemyDatas, GameObject type)
	{
		int num = 0;
		for (int i = 0; i < waveEnemyDatas.Count; i++)
		{
			if (!(waveEnemyDatas[i].EnemyToSpawn == null) && !(waveEnemyDatas[i].EnemyToSpawn != type))
			{
				num += waveEnemyDatas[i].AmountToSpawn;
			}
		}
		return num;
	}

	public void IncreaseEnemyAmountByType(GameObject type, int amountToAdd)
	{
		for (int i = 0; i < mainWaveEnemies.Count; i++)
		{
			if (mainWaveEnemies[i].EnemyToSpawn == type)
			{
				mainWaveEnemies[i].AmountToSpawn += amountToAdd;
				mainWaveEnemies[i].AmountToSpawn = Mathf.Max(mainWaveEnemies[i].AmountToSpawn, 0);
				return;
			}
		}
		for (int j = 0; j < secondaryWaveEnemies.Count; j++)
		{
			if (secondaryWaveEnemies[j].EnemyToSpawn == type)
			{
				secondaryWaveEnemies[j].AmountToSpawn += amountToAdd;
				secondaryWaveEnemies[j].AmountToSpawn = Mathf.Max(secondaryWaveEnemies[j].AmountToSpawn, 0);
				break;
			}
		}
	}

	public int CalculateTotalEnemyEssence()
	{
		int num = 0;
		for (int i = 0; i < mainWaveEnemies.Count; i++)
		{
			num += mainWaveEnemies[i].EnemyEssence;
		}
		for (int j = 0; j < secondaryWaveEnemies.Count; j++)
		{
			num += secondaryWaveEnemies[j].EnemyEssence;
		}
		return num;
	}

	private string GetFullInfoText(List<WaveEnemyData> waveEnemyDatas, float startDelay)
	{
		if (waveEnemyDatas == null || waveEnemyDatas.Count == 0)
		{
			return "No enemies found";
		}
		int num = CalculateWaveTotalStat(waveEnemyDatas, EStats.HealthMax);
		int num2 = CalculateWaveTotalStat(waveEnemyDatas, EStats.ArmorMax);
		int num3 = CalculateWaveTotalStat(waveEnemyDatas, EStats.ShieldMax);
		int num4 = CalculateWaveTotalEnemiesAmount(waveEnemyDatas);
		float num5 = CalculateWaveDuration(waveEnemyDatas, startDelay);
		string text = "Total life: " + (num + num2 + num3);
		text = text + " (" + FunctionLibrary.RoundToDecimals((float)(num + num2 + num3) / num5, 2) + "/s)";
		text = text + "\nHealth: " + num;
		text = text + " (" + FunctionLibrary.RoundToDecimals((float)num / num5, 2) + "/s)";
		if (num2 > 0)
		{
			text = text + "\nArmor: " + num2;
			text = text + " (" + FunctionLibrary.RoundToDecimals((float)num2 / num5, 2) + "/s)";
		}
		if (num3 > 0)
		{
			text = text + "\nShield: " + num3;
			text = text + " (" + FunctionLibrary.RoundToDecimals((float)num3 / num5, 2) + "/s)";
		}
		text = text + "\nWave duration: " + FunctionLibrary.RoundToDecimals(num5, 2) + "s";
		return text + "\nSpawn rate: " + FunctionLibrary.RoundToDecimals((float)num4 / num5, 2) + "/s";
	}
}
