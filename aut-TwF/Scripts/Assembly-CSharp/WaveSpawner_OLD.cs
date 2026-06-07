using System;
using System.Collections;
using System.Collections.Generic;
using LightTower;
using UnityEngine;

public class WaveSpawner_OLD : MonoBehaviour, ISavable
{
	private class FUnorderedCoroutineSavedData : ISavable
	{
		[Savable("startTime", true, false)]
		public double startTime;

		[Savable("objectToSpawnIdx", true, false)]
		public int objectToSpawnIdx;

		[Savable("spawnIteration", true, false)]
		public int spawnIteration;

		[Savable("lastInBetweenStartTime", true, false)]
		public double lastInBetweenStartTime = -1.0;

		public void OnSave()
		{
		}

		public void OnPreLoad()
		{
		}

		public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
		{
		}
	}

	[SerializeField]
	private List<WaveSpawnerConfig_OLD> configs;

	[SerializeField]
	private PathTile startPathTile;

	[Savable("currentWave", true, false)]
	private int currentWave;

	[Savable("isVeryFirstSpawner", true, false)]
	private bool isVeryFirstSpawner = true;

	[Savable("unorderedSavedDatas", true, false)]
	private List<FUnorderedCoroutineSavedData> unorderedSavedDatas;

	[Savable("currentSpawnConfigIdx", true, false)]
	private int currentSpawnConfigIdx;

	[Savable("spawnCoroutineStartTime", true, false)]
	private double spawnCoroutineStartTime;

	[Savable("objectToSpawnIdx", true, false)]
	private int objectToSpawnIdx = -1;

	[Savable("spawnIteration", true, false)]
	public int spawnIteration;

	[Savable("lastInBetweenStartTime", true, false)]
	public double lastInBetweenStartTime = -1.0;

	private int spawnedObjectsAmount;

	private int deadSpawnedObjects;

	private Coroutine spawnCoroutine;

	public List<WaveSpawnerConfig_OLD> Configs
	{
		get
		{
			return configs;
		}
		set
		{
			configs = value;
		}
	}

	public PathTile StartPathTile
	{
		get
		{
			return startPathTile;
		}
		set
		{
			startPathTile = value;
			this.onStartPathTileChanged?.Invoke();
		}
	}

	public event Action<GameObject> onSpawn;

	public event Action<WaveSpawner_OLD> onAllSpanwdObjectsDead;

	public event Action onStartPathTileChanged;

	private void Awake()
	{
		ResetSpawner();
	}

	public void StartSpawner()
	{
		this.StartCoroutineCheckingVar(SpawnCoroutine(), ref spawnCoroutine, stopCoroutineIfRunning: true);
	}

	public void StopSpawner()
	{
		this.StopCoroutineCheckingVar(ref spawnCoroutine);
		ResetSpawner();
	}

	public void PauseSpawner()
	{
		this.StopCoroutineCheckingVar(ref spawnCoroutine);
	}

	private void ResetSpawner()
	{
		spawnedObjectsAmount = 0;
		deadSpawnedObjects = 0;
		unorderedSavedDatas = new List<FUnorderedCoroutineSavedData>();
	}

	private GameObject SpawnObject(GameObject objectToSpawn, GameObject spawnVFX, int enemyEssence)
	{
		Vector3 position = startPathTile.GetAllPaths()[0].positions[0];
		Quaternion rotation = Quaternion.LookRotation((startPathTile.GetAllPaths()[0].positions[1] - startPathTile.GetAllPaths()[0].positions[0]).normalized.XZ().XZ());
		GameObject gameObject = UnityEngine.Object.Instantiate(objectToSpawn, position, rotation, base.transform);
		if ((bool)spawnVFX)
		{
			UnityEngine.Object.Instantiate(spawnVFX, base.transform.position, base.transform.rotation, base.transform);
		}
		gameObject.transform.SetParent(null);
		Enemy component = gameObject.GetComponent<Enemy>();
		component.EnemyMovement.CurrentPathTile = StartPathTile;
		component.EnemyEssenceDropped = enemyEssence;
		RegisterEnemy(component);
		this.onSpawn?.Invoke(gameObject);
		return gameObject;
	}

	public void RegisterEnemy(Enemy enemyToRegister)
	{
		enemyToRegister.CombatComponent.onDie += OnSpawnedObjectDies;
		spawnedObjectsAmount++;
	}

	private IEnumerator SpawnCoroutine()
	{
		yield return null;
		int totalWaves = 0;
		List<WaveSpawnerConfig_OLD> orderedConfigs = new List<WaveSpawnerConfig_OLD>();
		List<WaveSpawnerConfig_OLD> unorderedConfigs = new List<WaveSpawnerConfig_OLD>();
		List<Coroutine> unorederedCoroutines = new List<Coroutine>();
		foreach (WaveSpawnerConfig_OLD config2 in Configs)
		{
			if (config2.StartWave + config2.WavesAmount > totalWaves)
			{
				totalWaves = config2.StartWave + config2.WavesAmount;
			}
			if (config2.IgnoreOrder)
			{
				unorderedConfigs.Add(config2);
			}
			else
			{
				orderedConfigs.Add(config2);
			}
		}
		while (currentWave < totalWaves)
		{
			int num = 0;
			unorederedCoroutines.Clear();
			foreach (WaveSpawnerConfig_OLD item in unorderedConfigs)
			{
				if (currentWave >= item.StartWave && currentWave < item.StartWave + item.WavesAmount)
				{
					unorederedCoroutines.Add(StartCoroutine(UnorderedSpawnCoroutine(item, unorederedCoroutines, num)));
					num++;
				}
			}
			while (currentSpawnConfigIdx < orderedConfigs.Count)
			{
				WaveSpawnerConfig_OLD config = orderedConfigs[currentSpawnConfigIdx];
				if (currentWave >= config.StartWave && currentWave < config.StartWave + config.WavesAmount)
				{
					if (!isVeryFirstSpawner)
					{
						if (spawnCoroutineStartTime < 0.0)
						{
							spawnCoroutineStartTime = LTFunctionLibrary.GetTimeManager().GetTimeSeconds();
						}
						yield return new WaitForSeconds(config.StartDelay - (float)(LTFunctionLibrary.GetTimeManager().GetTimeSeconds() - spawnCoroutineStartTime));
					}
					isVeryFirstSpawner = false;
					WaitForSeconds inBetweenWFS = new WaitForSeconds(config.TimeBetweenObjects);
					if (lastInBetweenStartTime > 0.0)
					{
						yield return new WaitForSeconds(config.TimeBetweenObjects - (float)(LTFunctionLibrary.GetTimeManager().GetTimeSeconds() - lastInBetweenStartTime));
						spawnIteration++;
					}
					while (spawnIteration < config.ObjectsPerWave * config.ObjectsToSpawn.Length)
					{
						float num2 = config.CalculateEnemyEssencePerEnemy();
						num2 = (int)num2 + ((UnityEngine.Random.value <= num2 - (float)(int)num2) ? 1 : 0);
						objectToSpawnIdx = spawnIteration % config.ObjectsToSpawn.Length;
						SpawnObject(config.ObjectsToSpawn[objectToSpawnIdx], config.SpawnVFX, (int)num2);
						if (spawnIteration < config.ObjectsPerWave * config.ObjectsToSpawn.Length - 1)
						{
							lastInBetweenStartTime = LTFunctionLibrary.GetTimeManager().GetTimeSeconds();
							yield return inBetweenWFS;
							lastInBetweenStartTime = -1.0;
						}
						spawnIteration++;
					}
					spawnIteration = 0;
					objectToSpawnIdx = 0;
					spawnCoroutineStartTime = -1.0;
				}
				currentSpawnConfigIdx++;
			}
			bool allUnorderedCorutinesHaveEnd = false;
			while (!allUnorderedCorutinesHaveEnd)
			{
				allUnorderedCorutinesHaveEnd = true;
				foreach (Coroutine item2 in unorederedCoroutines)
				{
					if (item2 != null)
					{
						allUnorderedCorutinesHaveEnd = false;
						break;
					}
				}
				yield return null;
			}
			currentWave++;
			currentSpawnConfigIdx = 0;
			unorderedSavedDatas.Clear();
		}
		spawnCoroutine = null;
	}

	private IEnumerator UnorderedSpawnCoroutine(WaveSpawnerConfig_OLD config, List<Coroutine> unorderedCoroutinesList, int coroutineIdx)
	{
		yield return null;
		FUnorderedCoroutineSavedData savedData;
		if (unorderedSavedDatas.Count - 1 < coroutineIdx)
		{
			unorderedSavedDatas.Add(new FUnorderedCoroutineSavedData());
			savedData = unorderedSavedDatas[coroutineIdx];
			savedData.startTime = LTFunctionLibrary.GetTimeManager().GetTimeSeconds();
		}
		else
		{
			savedData = unorderedSavedDatas[coroutineIdx];
		}
		if (savedData.spawnIteration >= config.ObjectsPerWave * config.ObjectsToSpawn.Length)
		{
			unorderedCoroutinesList[coroutineIdx] = null;
			yield break;
		}
		yield return new WaitForSeconds(config.StartDelay - (float)(LTFunctionLibrary.GetTimeManager().GetTimeSeconds() - savedData.startTime));
		WaitForSeconds inBetweenWFS = new WaitForSeconds(config.TimeBetweenObjects);
		if (savedData.lastInBetweenStartTime > 0.0)
		{
			yield return new WaitForSeconds(config.TimeBetweenObjects - (float)(LTFunctionLibrary.GetTimeManager().GetTimeSeconds() - savedData.lastInBetweenStartTime));
			savedData.spawnIteration++;
		}
		while (savedData.spawnIteration < config.ObjectsPerWave * config.ObjectsToSpawn.Length)
		{
			float num = config.CalculateEnemyEssencePerEnemy();
			num = (int)num + ((UnityEngine.Random.value <= num - (float)(int)num) ? 1 : 0);
			savedData.objectToSpawnIdx = savedData.spawnIteration % config.ObjectsToSpawn.Length;
			SpawnObject(config.ObjectsToSpawn[savedData.objectToSpawnIdx], config.SpawnVFX, (int)num);
			if (savedData.spawnIteration < config.ObjectsPerWave * config.ObjectsToSpawn.Length - 1)
			{
				savedData.lastInBetweenStartTime = LTFunctionLibrary.GetTimeManager().GetTimeSeconds();
				yield return inBetweenWFS;
				savedData.lastInBetweenStartTime = -1.0;
			}
			savedData.spawnIteration++;
		}
		savedData.objectToSpawnIdx = 0;
		unorderedCoroutinesList[coroutineIdx] = null;
	}

	public bool IsSpawning()
	{
		return spawnCoroutine != null;
	}

	public bool HasEndedSpawning()
	{
		return !IsSpawning();
	}

	protected virtual void DestroySpawner()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public bool AreAllSpawnedObjectsDead()
	{
		if (HasEndedSpawning())
		{
			return deadSpawnedObjects >= spawnedObjectsAmount;
		}
		return false;
	}

	private void OnSpawnedObjectDies(CombatComponent combatComponent)
	{
		combatComponent.onDie -= OnSpawnedObjectDies;
		deadSpawnedObjects++;
		if (AreAllSpawnedObjectsDead())
		{
			this.onAllSpanwdObjectsDead?.Invoke(this);
		}
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (!hasLoadedSomething || data == null || !data.ContainsKey("unorderedSavedDatas"))
		{
			return;
		}
		unorderedSavedDatas = new List<FUnorderedCoroutineSavedData>();
		int num = 0;
		foreach (Dictionary<string, object> item in data["unorderedSavedDatas"] as List<Dictionary<string, object>>)
		{
			unorderedSavedDatas.Add(new FUnorderedCoroutineSavedData());
			SaveSystem.LoadObjectData(unorderedSavedDatas[num], item);
			num++;
		}
	}
}
