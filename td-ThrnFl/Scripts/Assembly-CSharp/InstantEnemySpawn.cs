using System.Collections;
using UnityEngine;

public class InstantEnemySpawn : MonoBehaviour
{
	public Wave wave;

	private bool spawnRunning;

	public void SpawnWave()
	{
		if (!spawnRunning)
		{
			StartCoroutine(SpawningWave());
		}
	}

	private IEnumerator SpawningWave()
	{
		spawnRunning = true;
		wave.Reset();
		while (!wave.HasFinished())
		{
			wave.Update();
			yield return null;
		}
		spawnRunning = false;
	}
}
