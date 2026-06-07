using System;
using System.Collections;
using System.Collections.Generic;
using LightTower;
using UnityEngine;

public class WaveSpawner : MonoBehaviour, ISavable
{
	private class WaveSpawnCoroutineSavedData : ISavable
	{
		[Savable("startTime", true, false)]
		public double startTime;

		[Savable("objectToSpawnIdx", true, false)]
		public int objectToSpawnIdx;

		[Savable("enemyData", true, false)]
		public int enemyDataIdx;

		[Savable("lastInBetweenStartTime", true, false)]
		public double lastInBetweenStartTime;

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
	private List<WaveSpawnerConfig> configs;

	[SerializeField]
	private PathTile startPathTile;

	private int spawnedObjectsAmount;

	private int deadSpawnedObjects;

	[Savable("spawnCurrentConfigIndex", true, false)]
	private int spawnCurrentConfigIdx;

	[Savable("mainWaveSpawnSavedData", true, false)]
	private WaveSpawnCoroutineSavedData mainWaveSpawnSavedData;

	[Savable("secondaryWaveSpawnSavedData", true, false)]
	private WaveSpawnCoroutineSavedData secondaryWaveSpawnSavedData;

	private Coroutine spawnCoroutine;

	private Coroutine mainWaveSpawnCoroutine;

	private Coroutine secondaryWaveSpawnCoroutine;

	private bool hasMainWaveEndedSpawn;

	private bool hasSecondaryWaveEndedSpawn;

	public List<WaveSpawnerConfig> Configs
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

	public event Action<WaveSpawner> onAllSpanwdObjectsDead;

	public event Action onStartPathTileChanged;

	private void Awake()
	{
		ResetSpawner();
	}

	public void StartSpawner()
	{
		this.StartCoroutineCheckingVar(SpawnCoroutine(), ref spawnCoroutine);
	}

	public void StopSpawner()
	{
		this.StopCoroutineCheckingVar(ref spawnCoroutine);
		this.StopCoroutineCheckingVar(ref mainWaveSpawnCoroutine);
		this.StopCoroutineCheckingVar(ref secondaryWaveSpawnCoroutine);
		ResetSpawner();
	}

	public void PauseSpawner()
	{
		this.StopCoroutineCheckingVar(ref spawnCoroutine);
		this.StopCoroutineCheckingVar(ref mainWaveSpawnCoroutine);
		this.StopCoroutineCheckingVar(ref secondaryWaveSpawnCoroutine);
	}

	private void ResetSpawner()
	{
		spawnedObjectsAmount = 0;
		deadSpawnedObjects = 0;
	}

	private GameObject SpawnObject(GameObject objectToSpawn, int enemyEssence)
	{
		Vector3 position = startPathTile.GetAllPaths()[0].positions[0];
		Quaternion rotation = Quaternion.LookRotation((startPathTile.GetAllPaths()[0].positions[1] - startPathTile.GetAllPaths()[0].positions[0]).normalized.XZ().XZ());
		GameObject gameObject = UnityEngine.Object.Instantiate(objectToSpawn, position, rotation, base.transform);
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
		while (spawnCurrentConfigIdx < configs.Count)
		{
			WaveSpawnerConfig waveSpawnerConfig = configs[spawnCurrentConfigIdx];
			float num = waveSpawnerConfig.MainWaveStartDelay;
			float num2 = waveSpawnerConfig.SecondaryWaveStartDelay;
			if (spawnCurrentConfigIdx == 0)
			{
				float minStartDelay = waveSpawnerConfig.GetMinStartDelay();
				num -= minStartDelay;
				num2 -= minStartDelay;
			}
			if (waveSpawnerConfig.MainWaveEnemies != null && waveSpawnerConfig.MainWaveEnemies.Count > 0)
			{
				this.StartCoroutineCheckingVar(WaveSpawnCoroutine(waveSpawnerConfig.MainWaveEnemies, num, mainWaveSpawnSavedData, delegate(WaveSpawnCoroutineSavedData x)
				{
					mainWaveSpawnSavedData = x;
				}), ref mainWaveSpawnCoroutine);
			}
			if (waveSpawnerConfig.SecondaryWaveEnemies != null && waveSpawnerConfig.SecondaryWaveEnemies.Count > 0)
			{
				this.StartCoroutineCheckingVar(WaveSpawnCoroutine(waveSpawnerConfig.SecondaryWaveEnemies, num2, secondaryWaveSpawnSavedData, delegate(WaveSpawnCoroutineSavedData x)
				{
					secondaryWaveSpawnSavedData = x;
				}), ref secondaryWaveSpawnCoroutine);
			}
			yield return mainWaveSpawnCoroutine;
			yield return secondaryWaveSpawnCoroutine;
			mainWaveSpawnSavedData = null;
			secondaryWaveSpawnSavedData = null;
			mainWaveSpawnCoroutine = null;
			secondaryWaveSpawnCoroutine = null;
			spawnCurrentConfigIdx++;
		}
		spawnCoroutine = null;
	}

	private IEnumerator WaveSpawnCoroutine(List<WaveEnemyData> enemyDatas, float startDelay, WaveSpawnCoroutineSavedData savedData, Action<WaveSpawnCoroutineSavedData> set)
	{
		if (savedData == null)
		{
			savedData = new WaveSpawnCoroutineSavedData();
			savedData.startTime = LTFunctionLibrary.GetTimeManager().GetTimeSeconds();
			savedData.enemyDataIdx = 0;
			savedData.objectToSpawnIdx = 0;
			savedData.lastInBetweenStartTime = -1.0;
			set(savedData);
		}
		if (startDelay > 0f)
		{
			yield return new WaitForSeconds(startDelay - (float)(LTFunctionLibrary.GetTimeManager().GetTimeSeconds() - savedData.startTime));
		}
		float num = 0f;
		if (savedData.lastInBetweenStartTime != -1.0)
		{
			num = (float)(LTFunctionLibrary.GetTimeManager().GetTimeSeconds() - savedData.lastInBetweenStartTime);
		}
		for (int i = savedData.enemyDataIdx; i < enemyDatas.Count; i++)
		{
			WaveEnemyData auxData = enemyDatas[i];
			WaitForSeconds inBetweenWFS = new WaitForSeconds(auxData.InBetweenSpawnsTime);
			for (int j = savedData.objectToSpawnIdx; j < auxData.AmountToSpawn; j++)
			{
				if (j == 0 && i != 0)
				{
					if (num == 0f)
					{
						savedData.lastInBetweenStartTime = LTFunctionLibrary.GetTimeManager().GetTimeSeconds();
					}
					yield return new WaitForSeconds(WaveSpawnerConfig.CalculateInBetweenTimeDifferentEnemies(enemyDatas[i - 1], enemyDatas[i]) - num);
				}
				else if (j != 0)
				{
					if (num == 0f)
					{
						savedData.lastInBetweenStartTime = LTFunctionLibrary.GetTimeManager().GetTimeSeconds();
						yield return inBetweenWFS;
					}
					else
					{
						yield return new WaitForSeconds(auxData.InBetweenSpawnsTime - num);
					}
				}
				num = 0f;
				float enemyEssencePerEnemy = auxData.GetEnemyEssencePerEnemy();
				enemyEssencePerEnemy = (int)enemyEssencePerEnemy + ((UnityEngine.Random.value <= enemyEssencePerEnemy - (float)(int)enemyEssencePerEnemy) ? 1 : 0);
				SpawnObject(auxData.EnemyToSpawn, Mathf.RoundToInt(enemyEssencePerEnemy));
				savedData.objectToSpawnIdx = j + 1;
			}
			savedData.objectToSpawnIdx = 0;
			savedData.enemyDataIdx = i + 1;
		}
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
		if (hasLoadedSomething && data != null)
		{
			if (data.ContainsKey("mainWaveSpawnSavedData"))
			{
				mainWaveSpawnSavedData = new WaveSpawnCoroutineSavedData();
				SaveSystem.LoadObjectData(mainWaveSpawnSavedData, data["mainWaveSpawnSavedData"] as Dictionary<string, object>);
			}
			if (data.ContainsKey("secondaryWaveSpawnSavedData"))
			{
				secondaryWaveSpawnSavedData = new WaveSpawnCoroutineSavedData();
				SaveSystem.LoadObjectData(secondaryWaveSpawnSavedData, data["secondaryWaveSpawnSavedData"] as Dictionary<string, object>);
			}
		}
	}
}
