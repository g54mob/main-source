using UnityEngine;

[CreateAssetMenu(fileName = "WaveSpawnerConfig_default", menuName = "Tower Factory/Spawners/WaveSpawnerConfig_OLD")]
public class WaveSpawnerConfig_OLD : ScriptableObject
{
	[SerializeField]
	private GameObject[] objectsToSpawn;

	[SerializeField]
	private int startWave;

	[SerializeField]
	private int wavesAmount;

	[SerializeField]
	private int objectsPerWave;

	[SerializeField]
	private int totalEnemyEssence;

	[SerializeField]
	[Tooltip("Delay antes de cada wave. Se ignora si es el primer spawn de todo de la oleada, para que no se retrase el comienzo de la noche")]
	private float startDelay;

	[SerializeField]
	private float timeBetweenObjects;

	[SerializeField]
	private bool ignoreOrder;

	[Header("Visuals")]
	[SerializeField]
	private GameObject spawnVFX;

	public GameObject[] ObjectsToSpawn => objectsToSpawn;

	public int StartWave => startWave;

	public int WavesAmount => wavesAmount;

	public int ObjectsPerWave => objectsPerWave;

	public float TimeBetweenObjects => timeBetweenObjects;

	public float StartDelay => startDelay;

	public bool IgnoreOrder => ignoreOrder;

	public int TotalEnemyEssence => totalEnemyEssence;

	public GameObject SpawnVFX => spawnVFX;

	public float CalculateTotalStat(EStats stat)
	{
		float num = 0f;
		for (int i = 0; i < ObjectsToSpawn.Length; i++)
		{
			num += ObjectsToSpawn[i].GetComponent<StatsComponent>().GetConfigStat(stat) * (float)WavesAmount * (float)ObjectsPerWave;
		}
		return num;
	}

	public float CalculateTotalSpawnerDuration()
	{
		float num = CalculateWaveDuration();
		return (float)wavesAmount * num + (float)wavesAmount * startDelay;
	}

	public float CalculateWaveDuration()
	{
		return (float)(objectsToSpawn.Length * objectsPerWave - 1) * timeBetweenObjects + startDelay;
	}

	private string CalculateTotalLifeText()
	{
		int num = (int)CalculateTotalStat(EStats.HealthMax);
		int num2 = (int)CalculateTotalStat(EStats.ArmorMax);
		int num3 = (int)CalculateTotalStat(EStats.ShieldMax);
		float num4 = CalculateWaveDuration();
		string text = "Total life: " + (num + num2 + num3) + " (" + FunctionLibrary.RoundToDecimals((float)(num + num2 + num3) / num4 / (float)wavesAmount, 2) + "/s each wave)";
		text = text + "\nHealth: " + num + " (" + FunctionLibrary.RoundToDecimals((float)num / num4 / (float)wavesAmount, 2) + "/s each wave)";
		if (num2 > 0)
		{
			text = text + "\nArmor: " + num2 + " (" + FunctionLibrary.RoundToDecimals((float)num2 / num4 / (float)wavesAmount, 2) + "/s each wave)";
		}
		if (num3 > 0)
		{
			text = text + "\nShield: " + num3 + " (" + FunctionLibrary.RoundToDecimals((float)num3 / num4 / (float)wavesAmount, 2) + "/s each wave)";
		}
		return text + "\nWave duration: " + FunctionLibrary.RoundToDecimals(num4, 2) + "s";
	}

	public float CalculateEnemyEssencePerEnemy()
	{
		return (float)TotalEnemyEssence / (float)(WavesAmount * ObjectsPerWave * ObjectsToSpawn.Length);
	}

	private string CalculateEnemyEssencePerEnemyText()
	{
		return "Essence per enemy: " + FunctionLibrary.RoundToDecimals(CalculateEnemyEssencePerEnemy(), 3);
	}
}
