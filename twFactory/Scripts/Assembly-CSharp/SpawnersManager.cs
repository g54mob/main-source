using System;
using System.Collections.Generic;
using LightTower;
using UnityEngine;

public class SpawnersManager : MonoBehaviour, ISavable
{
	public static SpawnersManager instance;

	[SerializeField]
	private PathTile firstPathTile;

	[SerializeField]
	private LTSpawner roundSpawnerPrefab;

	[SerializeField]
	private WaveSpawner waveSpawnerPrefab;

	[SerializeField]
	private LevelSpawners levelSpanwers;

	[Savable("roundSpawners", true, false)]
	private List<LTSpawner> roundSpawners;

	[Savable("waveSpawner", true, false)]
	private WaveSpawner waveSpawner;

	private PathTile spawnPathTile;

	[Savable("spawnedEnemies", false, true)]
	private List<Enemy> spawnedEnemies;

	protected int currentCycle;

	private ECycleMode currentCycleMode;

	private Dictionary<string, object> loadedData;

	public PathTile FirstPathTile
	{
		get
		{
			return firstPathTile;
		}
		set
		{
			firstPathTile = value;
		}
	}

	public PathTile SpawnPathTile
	{
		get
		{
			return spawnPathTile;
		}
		set
		{
			if (!value || !(spawnPathTile != value))
			{
				return;
			}
			spawnPathTile = value;
			foreach (LTSpawner roundSpawner in roundSpawners)
			{
				roundSpawner.StartPathTile = spawnPathTile;
			}
			if ((bool)waveSpawner)
			{
				waveSpawner.StartPathTile = spawnPathTile;
			}
		}
	}

	public LevelSpawners LevelSpanwers
	{
		get
		{
			return levelSpanwers;
		}
		set
		{
			levelSpanwers = value;
		}
	}

	public List<Enemy> SpawnedEnemies => spawnedEnemies;

	public event Action<Enemy> onEnemySpawned;

	public event Action<Enemy> onBossSpawned;

	public event Action<Enemy> onEnemyDies;

	private void Awake()
	{
		if ((bool)instance)
		{
			UnityEngine.Object.Destroy(instance.gameObject);
		}
		instance = this;
		roundSpawners = new List<LTSpawner>();
		SpawnPathTile = FirstPathTile;
		spawnedEnemies = new List<Enemy>();
		currentCycle = -1;
	}

	protected virtual void Start()
	{
		CyclesManager cyclesManager = LTFunctionLibrary.GetCyclesManager();
		cyclesManager.onCycleChanged = (Action<int, ECycleMode>)Delegate.Combine(cyclesManager.onCycleChanged, new Action<int, ECycleMode>(OnCycleChanged));
		LTFunctionLibrary.GetLTLevelController().onPathVisibilityUpdated += OnPathVisibilityUpdated;
		LTGameManager lTGameManager = LTFunctionLibrary.GetLTGameManager();
		lTGameManager.onVictoryAnimationStarted = (Action)Delegate.Combine(lTGameManager.onVictoryAnimationStarted, new Action(OnEndingAnimationStarted));
		LTGameManager lTGameManager2 = LTFunctionLibrary.GetLTGameManager();
		lTGameManager2.onGameOverAnimationStarted = (Action)Delegate.Combine(lTGameManager2.onGameOverAnimationStarted, new Action(OnEndingAnimationStarted));
		LTGameManager lTGameManager3 = LTFunctionLibrary.GetLTGameManager();
		lTGameManager3.onGameStarted = (Action)Delegate.Combine(lTGameManager3.onGameStarted, new Action(OnGameStarted));
	}

	private void OnGameStarted()
	{
		OnPathVisibilityUpdated();
		OnCycleChanged(LTFunctionLibrary.GetCyclesManager().CurrentCycle, LTFunctionLibrary.GetCyclesManager().CurrentCycleMode);
		if (loadedData != null && loadedData.ContainsKey("spawnedEnemies"))
		{
			foreach (Dictionary<string, object> item in loadedData["spawnedEnemies"] as List<Dictionary<string, object>>)
			{
				Enemy enemy = UnityEngine.Object.Instantiate(LTAssetsReferences.instance.GetEnemyDataById((item["enemyData"] as Dictionary<string, object>)["id"] as string).EnemyPrefab);
				SaveSystem.LoadObjectData(enemy, item, hasSaveTransformAtt: true);
				OnSpawnerSpawnsObject(enemy.gameObject);
			}
			if (waveSpawner != null)
			{
				foreach (Enemy spawnedEnemy in SpawnedEnemies)
				{
					waveSpawner.RegisterEnemy(spawnedEnemy);
				}
			}
		}
		loadedData = null;
	}

	private void StartRoundSpawners(List<SpawnerConfig> newSpawnerConfigs)
	{
		if (newSpawnerConfigs == null)
		{
			return;
		}
		foreach (SpawnerConfig newSpawnerConfig in newSpawnerConfigs)
		{
			LTSpawner component = UnityEngine.Object.Instantiate(roundSpawnerPrefab, Vector3.zero, Quaternion.identity, base.transform).GetComponent<LTSpawner>();
			roundSpawners.Add(component);
			component.Config = newSpawnerConfig;
			component.StartPathTile = SpawnPathTile;
			component.onSpawn += OnSpawnerSpawnsObject;
		}
		if (loadedData != null)
		{
			int num = 0;
			foreach (Dictionary<string, object> item in loadedData["roundSpawners"] as List<Dictionary<string, object>>)
			{
				SaveSystem.LoadObjectData(roundSpawners[num], item);
				num++;
			}
		}
		for (int i = 0; i < roundSpawners.Count; i++)
		{
			roundSpawners[i].StartSpawner();
		}
	}

	protected void StopRoundSpawners()
	{
		for (int num = roundSpawners.Count - 1; num >= 0; num--)
		{
			roundSpawners[num].StopSpawner();
			UnityEngine.Object.Destroy(roundSpawners[num].gameObject);
		}
		roundSpawners.Clear();
	}

	private void StartWaveSpawners(List<WaveSpawnerConfig> newSpawnerConfigs)
	{
		if (newSpawnerConfigs != null)
		{
			waveSpawner = UnityEngine.Object.Instantiate(waveSpawnerPrefab, Vector3.zero, Quaternion.identity, base.transform).GetComponent<WaveSpawner>();
			waveSpawner.Configs = newSpawnerConfigs;
			waveSpawner.StartPathTile = SpawnPathTile;
			waveSpawner.onSpawn += OnSpawnerSpawnsObject;
			LTFunctionLibrary.GetCyclesManager().RegisterWaveSpawner(waveSpawner);
			if (loadedData != null)
			{
				SaveSystem.LoadObjectData(waveSpawner, loadedData["waveSpawner"] as Dictionary<string, object>);
			}
			waveSpawner.StartSpawner();
		}
	}

	protected void StopWaveSpawners()
	{
		if (waveSpawner != null)
		{
			waveSpawner.StopSpawner();
			UnityEngine.Object.Destroy(waveSpawner.gameObject);
			waveSpawner = null;
		}
	}

	public void RegisterExternalSpawner(Spawner spawner)
	{
		spawner.onSpawn += OnSpawnerSpawnsObject;
	}

	private List<SpawnerConfig> GetRoundSpawnerConfigs(int cycle)
	{
		return GetCycleSpawnersByCycle(cycle).RoundSpawners;
	}

	private List<WaveSpawnerConfig> GetWaveSpawnerConfigs(int cycle)
	{
		return GetCycleSpawnersByCycle(cycle).WaveSpawners;
	}

	private CycleSpawners GetCycleSpawnersByCycle(int cycle)
	{
		List<CycleSpawners> list = null;
		list = LevelSpanwers.CycleSpawners;
		if (list == null)
		{
			return null;
		}
		for (int num = list.Count - 1; num >= 0; num--)
		{
			if (list[num].Cycle <= cycle)
			{
				return list[num];
			}
		}
		return null;
	}

	protected void OnCycleChanged(int cycle, ECycleMode cycleMode)
	{
		if (currentCycle != cycle || currentCycleMode != cycleMode)
		{
			currentCycle = cycle;
			currentCycleMode = cycleMode;
			StopRoundSpawners();
			StopWaveSpawners();
			if (currentCycleMode == ECycleMode.Neutral)
			{
				StartRoundSpawners(GetRoundSpawnerConfigs(currentCycle));
			}
			else
			{
				StartWaveSpawners(GetWaveSpawnerConfigs(currentCycle));
			}
		}
	}

	public float GetEnemyStartSpawnTime()
	{
		float num = float.MaxValue;
		foreach (SpawnerConfig roundSpawnerConfig in GetRoundSpawnerConfigs(currentCycle))
		{
			num = Mathf.Min(roundSpawnerConfig.StartDelay, num);
		}
		return num;
	}

	private PathTile GetNearestVisiblePathTile()
	{
		PathTile pathTile = FirstPathTile;
		while (pathTile.NextPathTiles.Count > 0)
		{
			if (pathTile.IsVisible)
			{
				return pathTile;
			}
			if (pathTile.IsPathSplitter())
			{
				if (IsSubpathVisible(pathTile, out var subpathEndingTile))
				{
					return pathTile;
				}
				pathTile = subpathEndingTile;
			}
			else
			{
				pathTile = pathTile.NextPathTiles[0];
			}
		}
		return FirstPathTile;
	}

	private bool IsSubpathVisible(PathTile subpathSplitterTile, out PathTile subpathEndingTile)
	{
		PathTile pathTile = subpathSplitterTile;
		subpathEndingTile = null;
		for (int i = 0; i < subpathSplitterTile.NextPathTiles.Count; i++)
		{
			pathTile = subpathSplitterTile.NextPathTiles[i];
			while (!pathTile.IsPathJoiner())
			{
				if (pathTile.IsVisible)
				{
					return true;
				}
				if (pathTile.IsPathSplitter())
				{
					if (IsSubpathVisible(pathTile, out var subpathEndingTile2))
					{
						return true;
					}
					pathTile = subpathEndingTile2;
				}
				else
				{
					pathTile = pathTile.NextPathTiles[0];
				}
			}
		}
		subpathEndingTile = pathTile;
		return false;
	}

	private void OnPathVisibilityUpdated()
	{
		PathTile pathTile = GetNearestVisiblePathTile();
		if (!pathTile)
		{
			return;
		}
		int num = 3;
		for (int i = 0; i < num; i++)
		{
			if (pathTile.PreviousPathTiles == null)
			{
				break;
			}
			if (pathTile.PreviousPathTiles.Count == 0)
			{
				break;
			}
			pathTile = pathTile.PreviousPathTiles[0];
		}
		SpawnPathTile = pathTile;
	}

	private void OnSpawnerSpawnsObject(GameObject spawnedObject)
	{
		if (spawnedObject.TryGetComponent<Enemy>(out var component))
		{
			if (component.Data.Boss && (bool)LTFunctionLibrary.GetMatchInfo().CurrentLevelData)
			{
				this.onBossSpawned?.Invoke(component);
			}
			SpawnedEnemies.Add(component);
			component.onDie += OnSpawnedEnemyDies;
			this.onEnemySpawned?.Invoke(component);
		}
	}

	private void OnSpawnedEnemyDies(Enemy deadEnemy)
	{
		SpawnedEnemies.Remove(deadEnemy);
		this.onEnemyDies?.Invoke(deadEnemy);
	}

	private void OnEndingAnimationStarted()
	{
		StopRoundSpawners();
		StopWaveSpawners();
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (hasLoadedSomething)
		{
			loadedData = data;
		}
	}
}
