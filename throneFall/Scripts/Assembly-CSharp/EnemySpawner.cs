using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, DayNightCycle.IDaytimeSensitive, ISaveLoad
{
	private PerkManager perkManager;

	private EnemySpawnManager enemySpawnManager;

	public static EnemySpawner instance;

	private TutorialManager tutorialManager;

	public LocalGamestate.GameMode currentMode;

	public int goldBalanceAtStart = 10;

	private bool loadedBalanceFromSave;

	private bool spawningInProgress;

	public EternalWaveGenerator waveGeneratorScript;

	public List<Wave> waves = new List<Wave>();

	private List<ScreenMarker> screenMarkersEnemySpawns = new List<ScreenMarker>();

	private List<ScreenMarker> screenMarkersOffscreenWarnings = new List<ScreenMarker>();

	private int wavenumber = -1;

	private int wavenumberLoadedFromSave = -1;

	private float lastSpawnPeriodDuration;

	private float lastSpawnPeriodClock;

	private bool treasureHunterActive;

	private bool cheeseGodActive;

	private bool loadedFromSave;

	private int numberOfEnemiesOnTheMap;

	[SerializeField]
	private int pauseSpawningAtEnemyCount = 275;

	[SerializeField]
	private bool endlessMode;

	public EternalWaveGenerator endlessModeWaveGeneratorScript;

	private int endlessSeed;

	private bool endlessSeedLoadedFromSave;

	public static int totalEnemiesSpawnedThisWave;

	public Sprite difficultySprite;

	public NNConstraint flyingConstraint = new NNConstraint();

	public NNConstraint groundConstraint = new NNConstraint();

	public NNConstraint groundConstraintLarge = new NNConstraint();

	private float timeSinceSpaningEnded;

	[HideInInspector]
	public bool reduceSpawnWaitTimes = true;

	public bool SpawningInProgress => spawningInProgress;

	public int WaveCount => waves.Count;

	public int Wavenumber => wavenumber;

	public bool MatchOver
	{
		get
		{
			if (wavenumber >= waves.Count - 1)
			{
				return !SpawningInProgress;
			}
			return false;
		}
	}

	public bool LevelBeatenAsSoonAsWaveFinished => wavenumber > waves.Count - 2;

	public bool PreFinalWaveComingUp => wavenumber == waves.Count - 3;

	public float LastSpawnPeriodDuration => lastSpawnPeriodDuration;

	public float LastSpawnPeriodClock => lastSpawnPeriodClock;

	public bool InfinitelySpawning { get; set; }

	private bool isInClassicMode => currentMode == LocalGamestate.GameMode.Classic;

	private bool isInEternalTrialMode => currentMode == LocalGamestate.GameMode.EternalTrial;

	public int NumberOfEnemiesOnTheMap => numberOfEnemiesOnTheMap;

	public float TimeSinceSpawningEnded => timeSinceSpaningEnded;

	public bool TwoWavesBeforeFinalWaveComingUp(int w)
	{
		return w == waves.Count - 4;
	}

	public bool WaveBeforeFinalWaveComingUp(int w)
	{
		return w == waves.Count - 3;
	}

	public bool FinalWaveComingUp(int w)
	{
		return w == waves.Count - 2;
	}

	public static Vector3 GetValidSpawnPointForEnemy(bool large, bool flying, Vector3 targetPosition)
	{
		NNConstraint constraint = (large ? instance.groundConstraintLarge : (flying ? instance.flyingConstraint : instance.groundConstraint));
		return AstarPath.active.GetNearest(targetPosition, constraint).position;
	}

	public void OnDuskEarly()
	{
	}

	public void DebugSkipWave()
	{
		if (!spawningInProgress)
		{
			DestroyMarkers();
			wavenumber++;
			if (wavenumber >= WaveCount)
			{
				wavenumber = -1;
			}
			PlaceMarkersForNextWave();
		}
	}

	public void EnemySpawnersHornFocussed()
	{
		if ((bool)tutorialManager && !tutorialManager.MayShowEnemySpawn)
		{
			for (int i = 0; i < screenMarkersEnemySpawns.Count; i++)
			{
				screenMarkersEnemySpawns[i].showWhenOnScreen = false;
				screenMarkersEnemySpawns[i].showWhenOffScreen = false;
			}
			for (int j = 0; j < screenMarkersOffscreenWarnings.Count; j++)
			{
				screenMarkersOffscreenWarnings[j].showWhenOnScreen = false;
				screenMarkersOffscreenWarnings[j].showWhenOffScreen = false;
			}
		}
		else
		{
			for (int k = 0; k < screenMarkersEnemySpawns.Count; k++)
			{
				screenMarkersEnemySpawns[k].showWhenOnScreen = true;
				screenMarkersEnemySpawns[k].showWhenOffScreen = true;
			}
			for (int l = 0; l < screenMarkersOffscreenWarnings.Count; l++)
			{
				screenMarkersOffscreenWarnings[l].showWhenOnScreen = false;
				screenMarkersOffscreenWarnings[l].showWhenOffScreen = false;
			}
		}
	}

	public void EnemySpawnersHornUnFocussed()
	{
		if ((bool)tutorialManager && !tutorialManager.MayShowEnemySpawn)
		{
			for (int i = 0; i < screenMarkersEnemySpawns.Count; i++)
			{
				screenMarkersEnemySpawns[i].showWhenOnScreen = false;
				screenMarkersEnemySpawns[i].showWhenOffScreen = false;
			}
			for (int j = 0; j < screenMarkersOffscreenWarnings.Count; j++)
			{
				screenMarkersOffscreenWarnings[j].showWhenOnScreen = false;
				screenMarkersOffscreenWarnings[j].showWhenOffScreen = false;
			}
		}
		else
		{
			for (int k = 0; k < screenMarkersEnemySpawns.Count; k++)
			{
				screenMarkersEnemySpawns[k].showWhenOnScreen = true;
				screenMarkersEnemySpawns[k].showWhenOffScreen = true;
			}
			for (int l = 0; l < screenMarkersOffscreenWarnings.Count; l++)
			{
				screenMarkersOffscreenWarnings[l].showWhenOnScreen = false;
				screenMarkersOffscreenWarnings[l].showWhenOffScreen = false;
			}
		}
	}

	public void OnBeforeMainLoadPass(string guid)
	{
	}

	public void OnAfterMainLoadPass(string guid)
	{
	}

	public void OnLoad(string guid)
	{
		goldBalanceAtStart = 0;
		loadedBalanceFromSave = MatchSaveLoadHandler.TryLoadValue(guid, "wavenumber", ref wavenumberLoadedFromSave);
		loadedFromSave = true;
	}

	public void OnSave(string guid)
	{
		MatchSaveLoadHandler.SaveValue(guid, "wavenumber", wavenumber);
		MatchSaveLoadHandler.SaveValue(guid, "endlessSeed", endlessSeed);
	}

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		flyingConstraint.graphMask = GraphMask.FromGraphName("Enemy Units Air");
		groundConstraint.graphMask = GraphMask.FromGraphName("Enemy Units S");
		groundConstraintLarge.graphMask = GraphMask.FromGraphName("Enemy Units L");
		if (LocalGamestate.GameModeSet)
		{
			currentMode = LocalGamestate.SelectedGameMode;
		}
		else
		{
			LocalGamestate.SelectedGameMode = currentMode;
		}
		perkManager = PerkManager.instance;
		enemySpawnManager = EnemySpawnManager.instance;
		tutorialManager = TutorialManager.instance;
		EnemySpawnersHornUnFocussed();
		if ((bool)DayNightCycle.Instance)
		{
			DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		}
		spawningInProgress = false;
		wavenumber = -1;
		if (isInClassicMode && DebugController.instance.StartGameInWave != -1)
		{
			wavenumber = DebugController.instance.StartGameInWave - 1;
		}
		if (wavenumberLoadedFromSave != -1)
		{
			wavenumber = wavenumberLoadedFromSave;
		}
		if (isInEternalTrialMode && waveGeneratorScript != null)
		{
			LevelInfo levelInfoFromCurrentSceneName = LevelProgressManager.instance.GetLevelInfoFromCurrentSceneName();
			if (levelInfoFromCurrentSceneName == null)
			{
				Debug.LogError("Warning! We apparently did not recieve correct Level Info.");
			}
			waves = waveGeneratorScript.GenerateWaves(base.transform.GetComponentsInChildren<EnemySpawnLine>(), levelInfoFromCurrentSceneName, EternalTrialsRunManager.CurrentRun.stage, out goldBalanceAtStart, EternalTrialsRunManager.CurrentRun.currentStageSeed);
		}
		else if (endlessMode && endlessModeWaveGeneratorScript != null)
		{
			LevelInfo levelInfoFromCurrentSceneName2 = LevelProgressManager.instance.GetLevelInfoFromCurrentSceneName();
			if (levelInfoFromCurrentSceneName2 == null)
			{
				Debug.LogError("Warning! We apparently did not recieve correct Level Info.");
			}
			endlessSeedLoadedFromSave = MatchSaveLoadHandler.TryLoadValue(GetComponent<SaveLoadEntity>().GUID, "endlessSeed", ref endlessSeed);
			if (MatchSaveLoadHandler.OverwriteCurrentSave || !endlessSeedLoadedFromSave)
			{
				Random.InitState(Mathf.RoundToInt(Time.unscaledTime * 1000000f));
				endlessSeed = Random.Range(-1000000, 1000000);
			}
			waves = endlessModeWaveGeneratorScript.GenerateWaves(base.transform.GetComponentsInChildren<EnemySpawnLine>(), levelInfoFromCurrentSceneName2, 3, out goldBalanceAtStart, endlessSeed);
		}
		if (PerkManager.instance.EliteGodEquipped)
		{
			int num = PerkManager.instance.eliteGodSpawnInterval;
			foreach (Wave wave in waves)
			{
				foreach (Spawn spawn in wave.spawns)
				{
					if (!spawn.eliteEnemies)
					{
						num--;
						if (num <= 0)
						{
							spawn.eliteEnemies = true;
							num = PerkManager.instance.eliteGodSpawnInterval;
						}
					}
				}
			}
		}
		if (PerkManager.instance.RatGodActive)
		{
			float num2 = 0f;
			foreach (Wave wave2 in waves)
			{
				foreach (Spawn spawn2 in wave2.spawns)
				{
					float num3 = (float)spawn2.goldCoins * PerkManager.instance.ratGod_GoldModifyer + num2;
					spawn2.goldCoins = Mathf.CeilToInt(Mathf.Max(0f, num3));
					num2 = num3 - (float)spawn2.goldCoins;
				}
			}
		}
		if (PerkManager.instance.LoanEquipped)
		{
			goldBalanceAtStart += PerkManager.instance.loanBonusMoney;
			int num4 = PerkManager.instance.loanInterestMoney;
			for (int i = 0; i < waves.Count; i++)
			{
				foreach (Spawn spawn3 in waves[i].spawns)
				{
					int num5 = Mathf.Min(spawn3.goldCoins, num4);
					num4 -= num5;
					spawn3.goldCoins -= num5;
				}
			}
		}
		if (PerkManager.instance.RoyalMintActive && !loadedBalanceFromSave)
		{
			goldBalanceAtStart += PerkManager.instance.royalMint_startGoldBonus;
		}
		if (!loadedBalanceFromSave)
		{
			PlayerMovement[] registeredPlayers = PlayerManager.Instance.RegisteredPlayers;
			for (int j = 0; j < registeredPlayers.Length; j++)
			{
				registeredPlayers[j].GetComponent<PlayerInteraction>().AddCoin(goldBalanceAtStart);
			}
		}
		LevelProgressManager.instance.GetLevelDataForActiveScene()?.dayToDayNetworth.Add(goldBalanceAtStart);
		treasureHunterActive = PerkManager.instance.TreasureHunterActive;
		cheeseGodActive = PerkManager.instance.CheeseGodActive;
		if (cheeseGodActive)
		{
			for (int k = 0; k < Mathf.Min(PerkManager.instance.cheeseGod_affectedNights, waves.Count); k++)
			{
				foreach (Spawn spawn4 in waves[k].spawns)
				{
					spawn4.count = Mathf.RoundToInt((float)spawn4.count * PerkManager.instance.cheeseGod_spawnAmountMulti);
					spawn4.interval /= PerkManager.instance.cheeseGod_firstWavesSpawnSpeed;
					spawn4.delay /= PerkManager.instance.cheeseGod_firstWavesSpawnSpeed;
				}
			}
		}
		OnStartOfTheDay();
	}

	private void Update()
	{
		lastSpawnPeriodClock += Time.deltaTime;
		if (!spawningInProgress)
		{
			numberOfEnemiesOnTheMap = TagManager.instance.CountAllTaggedObjectsWithTag(TagManager.ETag.EnemyOwned);
			timeSinceSpaningEnded += Time.deltaTime;
			return;
		}
		lastSpawnPeriodDuration += Time.deltaTime;
		if (numberOfEnemiesOnTheMap < pauseSpawningAtEnemyCount)
		{
			waves[wavenumber].Update();
			if (waves[wavenumber].HasFinished())
			{
				if (InfinitelySpawning)
				{
					if (TagManager.instance.CountAllTaggedObjectsWithTag(TagManager.ETag.EnemyOwned) <= 0)
					{
						foreach (Spawn spawn in waves[wavenumber].spawns)
						{
							spawn.Reset(_resetGold: false);
						}
					}
				}
				else
				{
					StopSpawnAfterWaveAndReset();
				}
			}
		}
		numberOfEnemiesOnTheMap = TagManager.instance.CountAllTaggedObjectsWithTag(TagManager.ETag.EnemyOwned);
		if (numberOfEnemiesOnTheMap <= 0)
		{
			waves[wavenumber].ReduceMaxDelayTillNextSpawn();
		}
	}

	public void OnStartOfTheDay()
	{
		timeSinceSpaningEnded = 0f;
		if (wavenumber + 1 >= waves.Count)
		{
			return;
		}
		if (treasureHunterActive && !loadedFromSave)
		{
			int amount = 0;
			if (GetTreasureHunterBonus(wavenumber, out amount))
			{
				PlayerMovement[] registeredPlayers = PlayerManager.Instance.RegisteredPlayers;
				for (int i = 0; i < registeredPlayers.Length; i++)
				{
					registeredPlayers[i].GetComponent<PlayerInteraction>().AddCoin(amount);
				}
			}
		}
		PlaceMarkersForNextWave();
		EnemySpawnersHornUnFocussed();
	}

	public void PlaceMarkersForNextWave()
	{
		Wave wave = waves[wavenumber + 1];
		List<Vector3> list = new List<Vector3>();
		foreach (Spawn spawn in wave.spawns)
		{
			Vector3 vector = spawn.spawnLine.position;
			if (spawn.spawnLine.childCount > 0)
			{
				vector = (spawn.spawnLine.GetChild(0).position + spawn.spawnLine.GetChild(spawn.spawnLine.childCount - 1).position) / 2f;
			}
			if (!list.Contains(vector))
			{
				list.Add(vector);
			}
			ScreenMarkerIcon component = spawn.enemyPrefab.GetComponent<ScreenMarkerIcon>();
			if (component == null)
			{
				continue;
			}
			Sprite sprite = component.sprite;
			ScreenMarker screenMarker = null;
			for (int i = 0; i < screenMarkersEnemySpawns.Count; i++)
			{
				if (!(screenMarkersEnemySpawns[i].Sprite != sprite) && !(screenMarkersEnemySpawns[i].transform.position != vector) && screenMarkersEnemySpawns[i].Elite == spawn.eliteEnemies)
				{
					screenMarker = screenMarkersEnemySpawns[i];
					screenMarker.SetNumber(screenMarker.Number + spawn.count);
				}
			}
			if (!(screenMarker != null))
			{
				ScreenMarker component2 = Object.Instantiate(enemySpawnManager.screenMarkerPrefabEnemySpawns, vector, Quaternion.identity).GetComponent<ScreenMarker>();
				component2.SetSprite(sprite);
				component2.SetNumber(spawn.count);
				component2.SetElite(spawn.eliteEnemies);
				screenMarkersEnemySpawns.Add(component2);
			}
		}
		if (wave.difficultyMulti == 1f)
		{
			return;
		}
		foreach (Vector3 item in list)
		{
			ScreenMarker component3 = Object.Instantiate(enemySpawnManager.screenMarkerPrefabEnemySpawns, item, Quaternion.identity).GetComponent<ScreenMarker>();
			component3.SetSprite(difficultySprite);
			component3.SetNumber(Mathf.RoundToInt((wave.difficultyMulti - 1f) / 0.1f));
			component3.SetElite(_elite: false);
			screenMarkersEnemySpawns.Add(component3);
		}
	}

	public bool GetTreasureHunterBonus(int wave, out int amount)
	{
		amount = 0;
		if (TwoWavesBeforeFinalWaveComingUp(wave))
		{
			amount = PerkManager.instance.treasureHunterGoldAmountWave1;
			return true;
		}
		if (WaveBeforeFinalWaveComingUp(wave))
		{
			amount = PerkManager.instance.treasureHunterGoldAmountWave2;
			return true;
		}
		if (FinalWaveComingUp(wave))
		{
			amount = PerkManager.instance.treasureHunterGoldAmountWave3;
			return true;
		}
		return false;
	}

	public void OnStartOfTheNight()
	{
		loadedFromSave = false;
		timeSinceSpaningEnded = 0f;
		totalEnemiesSpawnedThisWave = 0;
		DestroyMarkers();
		StartSpawning();
	}

	public void DestroyMarkers()
	{
		for (int num = screenMarkersEnemySpawns.Count - 1; num >= 0; num--)
		{
			Object.Destroy(screenMarkersEnemySpawns[num].gameObject);
		}
		screenMarkersEnemySpawns.Clear();
		for (int num2 = screenMarkersOffscreenWarnings.Count - 1; num2 >= 0; num2--)
		{
			Object.Destroy(screenMarkersOffscreenWarnings[num2].gameObject);
		}
		screenMarkersOffscreenWarnings.Clear();
	}

	public void StartSpawning()
	{
		if (spawningInProgress)
		{
			return;
		}
		lastSpawnPeriodDuration = 0f;
		lastSpawnPeriodClock = 0f;
		wavenumber++;
		wavenumber = Mathf.Clamp(wavenumber, 0, waves.Count - 1);
		waves[wavenumber].Reset();
		spawningInProgress = true;
		foreach (Spawn spawn in waves[wavenumber].spawns)
		{
			if (!spawn.enemyPrefab.scene.isLoaded)
			{
				continue;
			}
			try
			{
				NavmeshCut componentInChildren = spawn.enemyPrefab.transform.parent.GetComponentInChildren<NavmeshCut>();
				if ((bool)(Object)(object)componentInChildren)
				{
					Object.Destroy((Object)(object)componentInChildren);
				}
			}
			catch
			{
				Debug.LogWarning("Enemy was spawned form scene but something went wrong with disabling potential NavmeshCuts.");
			}
		}
	}

	public void StopSpawnAfterWaveAndReset()
	{
		if (spawningInProgress)
		{
			spawningInProgress = false;
		}
	}

	public void OnDusk()
	{
		OnStartOfTheNight();
	}

	public void OnDawn_AfterSunrise()
	{
		OnStartOfTheDay();
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	public static WaveInfo GetWaveInfoForNextWave()
	{
		if (instance == null)
		{
			return new WaveInfo();
		}
		if (DayNightCycle.Instance.CurrentTimestate == DayNightCycle.Timestate.Night)
		{
			return instance.GetWaveInfo(instance.wavenumber);
		}
		return instance.GetWaveInfo(instance.wavenumber + 1);
	}

	public static WaveInfo GetWaveInfoByNumber(int _wavenumber)
	{
		if (instance == null)
		{
			return new WaveInfo();
		}
		return instance.GetWaveInfo(_wavenumber);
	}

	public static Wave GetNextWave()
	{
		if (instance == null)
		{
			return new Wave();
		}
		if (DayNightCycle.Instance.CurrentTimestate == DayNightCycle.Timestate.Night)
		{
			return instance.waves[Mathf.Min(instance.wavenumber, instance.waves.Count - 1)];
		}
		return instance.waves[Mathf.Min(instance.wavenumber + 1, instance.waves.Count - 1)];
	}

	private WaveInfo GetWaveInfo(int waveNumber)
	{
		if (waveNumber >= waves.Count || waveNumber < 0)
		{
			return new WaveInfo();
		}
		WaveInfo waveInfo = new WaveInfo();
		waveInfo.waveNumber = waveNumber + 1;
		waveInfo.outOfWaves = waves.Count;
		Wave wave = waves[waveNumber];
		waveInfo.difficultyMulti = wave.difficultyMulti;
		foreach (Spawn spawn in wave.spawns)
		{
			if (spawn.enemyPrefab == null)
			{
				continue;
			}
			ScreenMarkerIcon component = spawn.enemyPrefab.GetComponent<ScreenMarkerIcon>();
			if (component == null)
			{
				continue;
			}
			string unitDescription = component.UnitDescription;
			string unitName = component.UnitName;
			Sprite sprite = component.sprite;
			WaveEnemyInfo waveEnemyInfo = null;
			foreach (WaveEnemyInfo enemy in waveInfo.enemies)
			{
				if (enemy.enemyIcon == sprite && enemy.enemyName == unitName && enemy.eliteEnemy == spawn.eliteEnemies)
				{
					waveEnemyInfo = enemy;
					break;
				}
			}
			if (waveEnemyInfo == null)
			{
				waveEnemyInfo = new WaveEnemyInfo();
				waveEnemyInfo.enemyDescription = unitDescription;
				waveEnemyInfo.enemyName = unitName;
				waveEnemyInfo.enemyIcon = sprite;
				waveEnemyInfo.eliteEnemy = spawn.eliteEnemies;
				waveInfo.enemies.Add(waveEnemyInfo);
			}
			waveInfo.goldReward += spawn.goldCoins;
			waveEnemyInfo.enemyCount += spawn.count;
		}
		return waveInfo;
	}
}
