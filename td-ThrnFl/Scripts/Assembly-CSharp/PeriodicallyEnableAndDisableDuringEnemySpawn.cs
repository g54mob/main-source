using UnityEngine;

public class PeriodicallyEnableAndDisableDuringEnemySpawn : MonoBehaviour
{
	[SerializeField]
	private MonoBehaviour toEnableAndDisable;

	[SerializeField]
	private float enabledDuration = 10f;

	[SerializeField]
	private float disabledDuration = 10f;

	private EnemySpawner enemySpawner;

	private float totalTime;

	private void Start()
	{
		enemySpawner = EnemySpawner.instance;
		totalTime = enabledDuration + disabledDuration;
	}

	private void Update()
	{
		float lastSpawnPeriodClock = enemySpawner.LastSpawnPeriodClock;
		toEnableAndDisable.enabled = lastSpawnPeriodClock % totalTime < enabledDuration;
	}
}
