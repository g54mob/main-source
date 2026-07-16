using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour, ISaveable
{
	public StateMachine sm;

	[SerializeField]
	private ScriptableObject originalConfigDoNotEdit;

	[SerializeField]
	private List<GameObject> SandstormPrefabs;

	[NonSerialized]
	public bool SandstormTutorialFinished;

	public Dictionary<Level, MapNode> levelToMapNode = new Dictionary<Level, MapNode>();

	public bool SkipNextDestinationReached;

	public bool DestinationReachedOnLoad;

	public List<Level> LevelOverrides;

	private List<LevelData> levelDataList;

	public bool BuildingLevelsComplete;

	public bool SetUpNextZoneOnStation;

	public static LevelManager Instance { get; private set; }

	public LevelConfig Config { get; private set; }

	[field: SerializeField]
	public Map Map { get; private set; }

	[field: SerializeField]
	public float SandstormStartTime { get; private set; }

	[field: NonSerialized]
	public Sandstorm Sandstorm { get; private set; }

	public List<Level> Levels { get; private set; } = new List<Level>();

	public List<int> LevelHistory { get; private set; }

	public List<int> TotalLevelHistory { get; private set; }

	public Level NextLevel { get; private set; }

	public Level? CurrentLevel
	{
		get
		{
			if (Levels != null && Levels.Count != 0 && LevelHistory != null && LevelHistory.Count != 0)
			{
				List<Level> levels = Levels;
				List<int> levelHistory = LevelHistory;
				return levels[levelHistory[levelHistory.Count - 1]];
			}
			return null;
		}
	}

	public Level PreviousLevel
	{
		get
		{
			List<Level> levels = Levels;
			List<int> levelHistory = LevelHistory;
			return levels[levelHistory[levelHistory.Count - 2]];
		}
	}

	public float CurrentLevelProgress01 => Mathf.Clamp01(Train.Instance.LevelDistance / CurrentLevel.LevelDistance);

	public TrackEventSwitch CurrentSwitchEvent => CurrentLevel.Switches?.FirstOrDefault();

	public TrackEventResource CurrentResourceEvent => CurrentLevel.Resources?.FirstOrDefault();

	public bool IsAtDestination => sm.CurrentState.Key == "Station";

	public bool IsPlaying => sm.CurrentState.Key == "Playing";

	public bool IsSlowing => sm.CurrentState.Key == "Slowing";

	[field: SerializeField]
	[field: Tooltip("Which interactables the player can interact with in the station, and no others.")]
	public Interactable[] StationInteractableWhitelist { get; private set; }

	public event Action<Level> NextLevelSelected;

	public event Action LevelSlowingStarted;

	public event Action LevelSlowingFinished;

	public event Action LevelStarted;

	public event Action LevelCompleted;

	public event Action DestinationReached;

	public event Action<int> BossBeaten;

	public void LoadLevelHistory(List<int> levels)
	{
		LevelHistory = new List<int>(levels);
	}

	public void LoadTotalLevelHistory(List<int> levels)
	{
		TotalLevelHistory = new List<int>(levels);
	}

	public void OnNextLevelSelected(Level level)
	{
		DataTrackingManager.Instance.AddLocationCountByType(level.LootType);
		DataTrackingManager.Instance.AddLocationCountByDifficulty(level.Difficulty.Name ?? "");
		foreach (PlayerController player in PlayerManager.Instance.Players)
		{
			player.transform.position = Train.Instance.GetPlayerSpawnPoint(player.PlayerIndex);
		}
		this.NextLevelSelected?.Invoke(level);
	}

	public void OnLevelStarting()
	{
		if (NextLevel != null)
		{
			TryAddLevelToHistory(NextLevel.Index);
		}
		if (ZoneManager.Instance != null && ZoneManager.Instance.CurrentZoneIndex >= 1)
		{
			Level? currentLevel = CurrentLevel;
			if (currentLevel == null || currentLevel.LevelType != LevelType.Hub)
			{
				SaveManager.Instance.SaveJourney(forceLoadable: true, ignoreLevelStart: false, savedOnLevelStart: true);
			}
		}
		SaveManager.Instance.ClearShopSave();
		SaveManager.Instance.ClearRewards();
		SaveManager.Instance.ClearEncounter();
		DestinationReachedOnLoad = false;
	}

	public void OnLevelStarted()
	{
		AddLevelDifficultyModifers();
		DataTrackingManager.Instance.SetLevelAtEnd(TotalLevelHistory.Count - 1);
		this.LevelStarted?.Invoke();
	}

	public void OnLevelCompleted()
	{
		ClearLevelDifficultyModifiers();
		if (CurrentLevel.LevelType == LevelType.Boss)
		{
			DataTrackingManager.Instance.AddBossesKilled();
		}
		if (ZoneManager.Instance != null && ZoneManager.Instance.CurrentZoneIndex >= 1)
		{
			Level? currentLevel = CurrentLevel;
			if (currentLevel == null || currentLevel.LevelType != LevelType.Hub)
			{
				Level? currentLevel2 = CurrentLevel;
				if (currentLevel2 == null || currentLevel2.LevelType != LevelType.Boss)
				{
					SaveManager.Instance.SaveJourney(forceLoadable: true, ignoreLevelStart: false);
				}
			}
		}
		this.LevelCompleted?.Invoke();
		this.LevelSlowingStarted?.Invoke();
	}

	public void TryAddLevelToHistory(int levelIndex)
	{
		if (LevelHistory == null)
		{
			LevelHistory = new List<int>();
		}
		List<int> levelHistory = LevelHistory;
		if (levelHistory[levelHistory.Count - 1] != levelIndex)
		{
			LevelHistory.Add(levelIndex);
		}
		if (TotalLevelHistory == null)
		{
			TotalLevelHistory = new List<int>();
		}
		List<int> totalLevelHistory = TotalLevelHistory;
		if (totalLevelHistory[totalLevelHistory.Count - 1] != levelIndex)
		{
			TotalLevelHistory.Add(levelIndex);
		}
	}

	public void OnDestinationReached()
	{
		if (ZoneManager.Instance != null && ZoneManager.Instance.CurrentZoneIndex >= 1)
		{
			SaveManager.Instance.SaveJourney();
		}
		this.DestinationReached?.Invoke();
		this.LevelSlowingFinished?.Invoke();
	}

	private void Awake()
	{
		Instance = this;
		Debug.Log("LevelManager Awake");
		Config = UnityEngine.Object.Instantiate(originalConfigDoNotEdit) as LevelConfig;
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new LevelBaseState[6]
		{
			new LevelStateFadeIn(sm),
			new LevelStateFadeOut(sm),
			new LevelStateStation(sm),
			new LevelStateStarting(sm),
			new LevelStatePlaying(sm),
			new LevelStateSlowing(sm)
		};
		stateMachine.BuildStateDictionary(newStates);
	}

	private void Start()
	{
		if (ZoneManager.Instance == null)
		{
			Debug.LogError("ZoneManager is not initialized before LevelManager.");
		}
		GameManager.Instance.JourneyStarted += HandleNewJourney;
		GameManager.Instance.JourneyContinued += HandleContinueJourney;
		ZoneManager.Instance.OnNewZone += HandleNewZone;
	}

	private void Update()
	{
		if (Time.timeScale != 0f && GameManager.Instance.IsJourneyStarted)
		{
			sm.UpdateStates();
			sm.FixedUpdateStates();
			if (sm.CurrentState.Key == "Starting" && Train.Instance.GlobalDistance > 10000f)
			{
				Train.Instance.GlobalDistance = Instance.CurrentLevel.GlobalStartDistance;
			}
			_ = sm?.CurrentState?.Key;
			if (CurrentLevel != null)
			{
				CurrentLevel.GlobalStartDistance.ToString("0.0");
			}
			if (Train.Instance != null)
			{
				Train.Instance.GlobalDistance.ToString("0.0");
			}
			if (CurrentLevel != null)
			{
				CurrentLevel.GlobalEndDistance.ToString("0.0");
			}
			if (NextLevel != null)
			{
				NextLevel.GlobalStartDistance.ToString("0.0");
			}
		}
	}

	private void HandleNewJourney()
	{
		LevelHistory = new List<int> { 0 };
		TotalLevelHistory = new List<int> { 0 };
		HandleJourneyStarted();
	}

	private void HandleContinueJourney()
	{
		List<LevelSaveData> levelSaveData = SaveManager.Instance.GetLevelSaveData();
		if (levelSaveData != null && levelSaveData.Count > 0)
		{
			HandleLoadedZone(ZoneManager.Instance.CurrentZone, levelSaveData);
		}
		HandleJourneyStarted();
	}

	private void HandleJourneyStarted()
	{
		StateMachine stateMachine = sm;
		StateBase[] newStates = new LevelBaseState[7]
		{
			new LevelStateEmpty(sm),
			new LevelStateStation(sm),
			new LevelStateStarting(sm),
			new LevelStatePlaying(sm),
			new LevelStateSlowing(sm),
			new LevelStateFadeOut(sm),
			new LevelStateFadeIn(sm)
		};
		stateMachine.BuildStateDictionary(newStates);
	}

	private void HandleNewZone(Zone zone)
	{
		BuildLevels(zone);
		Map.DiscoverNodes();
		Train.Instance.GlobalDistance = 3.6f;
		if (ZoneManager.Instance.CurrentZoneIndex > 0)
		{
			UIManager.Instance.FadeScreen.ForceShowUI();
		}
	}

	private void HandleLoadedZone(Zone zone, List<LevelSaveData> savedLevels)
	{
		LoadLevels(zone, savedLevels);
		Map.DiscoverNodes();
		Train.Instance.GlobalDistance = 3.6f;
		if (ZoneManager.Instance.CurrentZoneIndex > 0)
		{
			UIManager.Instance.FadeScreen.ForceShowUI();
		}
	}

	public void LoadLevels(Zone zone, List<LevelSaveData> savedLevels)
	{
		BuildLevelsFromSave(zone, savedLevels);
	}

	public void BuildLevels(Zone zone)
	{
		LevelHistory = new List<int> { 0 };
		Debug.Log("New zone levels building - LevelHistory reset to new List { 0 }");
		Levels = new List<Level>();
		levelToMapNode = new Dictionary<Level, MapNode>();
		Map.ResetMap();
		for (int i = 0; i < zone.LevelDataList.Count; i++)
		{
			Level level = LevelFactory.CreateLevel(zone.LevelDataList[i], zone, i);
			GameObject obj = UnityEngine.Object.Instantiate(Config.MapNodePrefab, Map.ElementsTf);
			obj.name = $"Level {level.Index} {level.Difficulty.Name} {level.LootType}";
			MapNode component = obj.GetComponent<MapNode>();
			component.Initialize(level);
			Levels.Add(level);
			levelToMapNode.Add(level, component);
		}
		if (TotalLevelHistory == null)
		{
			TotalLevelHistory = new List<int>();
		}
		if (TotalLevelHistory.Count == 0)
		{
			TotalLevelHistory.Add(0);
		}
		Map.ConstructLinesFromLevelDataList(zone.LevelDataList);
		BuildingLevelsComplete = true;
	}

	private void BuildLevelsFromSave(Zone zone, List<LevelSaveData> savedLevels)
	{
		Debug.Log("Zone levels building from save");
		Levels = new List<Level>();
		levelToMapNode = new Dictionary<Level, MapNode>();
		Map.ResetMap();
		for (int i = 0; i < savedLevels.Count; i++)
		{
			Level level = LevelFactory.CreateLevel(savedLevels[i], zone);
			GameObject obj = UnityEngine.Object.Instantiate(Config.MapNodePrefab, Map.ElementsTf);
			obj.name = $"Level {level.Index} {level.Difficulty.Name} {level.LootType}";
			MapNode component = obj.GetComponent<MapNode>();
			component.Initialize(level);
			Levels.Add(level);
			levelToMapNode.Add(level, component);
		}
		Map.ConstructLinesFromLevelSaveData(savedLevels);
		BuildingLevelsComplete = true;
	}

	public void TrackEventUpdates<T>(List<T> trackEvents) where T : TrackEvent
	{
		if (trackEvents != null && trackEvents.Count != 0)
		{
			TrackEvent trackEvent = trackEvents[0];
			trackEvent?.Update();
			if (trackEvent != null && trackEvent.DistanceRemaining <= 0f)
			{
				trackEvent.EndEvent();
				trackEvents.RemoveAt(0);
				trackEvents.FirstOrDefault()?.StartEvent();
			}
		}
	}

	public void DelayedBreak()
	{
		StartCoroutine(DelayedBreakCoroutine());
	}

	public IEnumerator DelayedBreakCoroutine()
	{
		yield return new WaitForSeconds(0.7f);
		Train.Instance.PlayStoppingClip();
		Train.Instance.Brake();
	}

	public void OnNodeClick(MapNode node)
	{
		if (!TutorialManager.Instance.MapLocked)
		{
			Train.Instance.SetDrivingPlayer();
			TrySetNextLevel(node.Level);
		}
	}

	public void TryStartFirstLevel()
	{
		TrySetNextLevel(Levels[1]);
	}

	private void TrySetNextLevel(Level nextLevel)
	{
		int distanceBetweenLevels = MapHelper.GetDistanceBetweenLevels(CurrentLevel, nextLevel);
		bool flag = false;
		if ((distanceBetweenLevels == 1 || flag) && IsAtDestination)
		{
			SetNextLevel(nextLevel);
		}
	}

	private void SetNextLevel(Level nextLevel, bool loaded = false)
	{
		nextLevel.StartIndex = CurrentLevel.EndIndex + 1;
		nextLevel.GlobalStartDistance = (float)nextLevel.StartIndex * 4.8f;
		nextLevel.GlobalEndDistance = nextLevel.GlobalStartDistance + nextLevel.LevelDistance;
		NextLevel = nextLevel;
		if (loaded)
		{
			Train.Instance.GlobalDistance = nextLevel.GlobalEndDistance + 2f;
		}
		OnNextLevelSelected(nextLevel);
	}

	public void LoadLastLevelPlayed()
	{
		List<Level> levels = Levels;
		List<int> levelHistory = LevelHistory;
		SetNextLevel(levels[levelHistory[levelHistory.Count - 1]], loaded: true);
	}

	public void HandleBossBeaten(int coresDropped = 0, bool tutorial = false)
	{
		Debug.Log("Entered HandleBossBeaten");
		if (tutorial)
		{
			MenuSettings component = MenuManager.Instance.GetMenu(MenuType.Options).gameObject.GetComponent<MenuSettings>();
			if (component.lastGameSpeed <= 3)
			{
				component.SetGameSpeed(component.lastGameSpeed);
				SaveManager.Instance.settingsSavefile.ChosenGameSpeed = component.lastGameSpeed;
			}
			SaveManager.Instance.IsTutorialComplete = true;
			SaveManager.Instance.Save();
		}
		else
		{
			ResourceManager.Instance.DropCoresFromBoss(coresDropped);
			DataTrackingManager.Instance.AddBossesKilled();
			DataTrackingManager.Instance.SetCoreCount((int)ResourceManager.Instance.Cores.Value);
			if (Train.Instance.currentTrain.WorldBeaten < ZoneManager.Instance.CurrentZoneIndex)
			{
				Train.Instance.currentTrain.WorldBeaten = ZoneManager.Instance.CurrentZoneIndex;
			}
			if (Train.Instance.GetTrainByType(TrainType.Fire).CheckUnlockRequirements())
			{
				Train.Instance.GetTrainByType(TrainType.Fire).UnlockTrain();
			}
			if ((bool)Sandstorm)
			{
				Sandstorm.TurnOff();
			}
			this.BossBeaten?.Invoke(ZoneManager.Instance.CurrentZoneIndex);
		}
		bool flag = (GameManager.Instance.isDemo && ZoneManager.Instance.CurrentZone.Definition.ZoneName != "T0_Tutorial") || ZoneManager.Instance.CurrentZoneIndex + 1 > GameManager.Instance.SupportedWorlds || ZoneManager.Instance.CurrentZoneIndex + 1 > GameManager.Instance.UnlockedWorlds;
		if (ZoneManager.Instance.CurrentZoneIndex == 1)
		{
			foreach (NewTrainBase key in Train.Instance.trains.Keys)
			{
				if (key.trainType == TrainType.Cannon)
				{
					key.UnlockTrain();
					break;
				}
			}
		}
		else if (ZoneManager.Instance.CurrentZoneIndex == 2)
		{
			if (Train.Instance.currentTrain.trainType == TrainType.Cannon)
			{
				foreach (NewTrainBase key2 in Train.Instance.trains.Keys)
				{
					if (key2.trainType == TrainType.Warp)
					{
						key2.UnlockTrain();
						break;
					}
				}
			}
		}
		else if (ZoneManager.Instance.CurrentZoneIndex == 3)
		{
			foreach (NewTrainBase key3 in Train.Instance.trains.Keys)
			{
				if (key3.trainType == TrainType.Armored)
				{
					key3.UnlockTrain();
					break;
				}
			}
		}
		SaveManager.Instance.HandleBossBeaten(flag);
		Train.Instance.SetAllModulesImmunity(isImmune: true);
		ModuleFurnace moduleByType = Train.Instance.GetModuleByType<ModuleFurnace>();
		moduleByType.HealthComponent.Res(new HealthChangeInfo(this, new Health(), 5f, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
		moduleByType.HealthComponent.Heal(moduleByType.HealthComponent.HealthMax);
		Train.Instance.CoalSeconds += 100f;
		if (flag)
		{
			StartCoroutine(HandleFinalBossBeatenCoroutine());
			return;
		}
		UIManager.Instance.FadeScreen.OnUIHidden += HandleBossFade;
		UIManager.Instance.FadeScreen.HideUI();
	}

	private void HandleBossFade()
	{
		Debug.Log("Entered HandleBossFade");
		UIManager.Instance.FadeScreen.OnUIHidden -= HandleBossFade;
		UIManager.Instance.HUD.ShowNonEssential(show: false);
		TrackManager.Instance.DestroyTrackResources();
		SetUpNextZoneOnStation = true;
		Train.Instance.SetLevelDistanceToEnd();
	}

	private IEnumerator HandleFinalBossBeatenCoroutine()
	{
		foreach (Wagon wagon in Train.Instance.Wagons)
		{
			EffectsUtils.PlayMultipleParticles(wagon.Fireworks, play: true);
		}
		DifficultyManager.Instance.RunBeaten();
		SaveManager.Instance.ShouldSaveJourney = false;
		SaveManager.Instance.SaveJourney();
		yield return new WaitForSeconds(5f);
		Train.Instance.AddSlowDebuff(100f, 2f);
		yield return new WaitForSeconds(3f);
		if (!GameManager.Instance.isDemo)
		{
			GameManager.Instance.UnlockNextWorld();
		}
		GameManager.Instance.GameOver(victory: true);
	}

	public void AdvanceToNextLevel()
	{
		if (NextLevel != null)
		{
			TryAddLevelToHistory(NextLevel.Index);
			NextLevel = null;
			Map.UndiscoverAllNodes();
			Map.DiscoverNodes();
		}
	}

	public void ClearNextLevel()
	{
		NextLevel = null;
	}

	public void SkipToBoss()
	{
		SetNextLevel(Levels[Levels.Count - 1]);
	}

	public void DiscoverLevel(Level level)
	{
		if (!level.Discovered)
		{
			level.Discovered = true;
			if (levelToMapNode.TryGetValue(level, out var value))
			{
				value.OnLevelDiscovered();
			}
		}
	}

	public void UndiscoverLevel(Level level)
	{
		if (level.Discovered)
		{
			level.Discovered = false;
			if (levelToMapNode.TryGetValue(level, out var value))
			{
				value.OnLevelUndiscovered();
			}
		}
	}

	public MapNode GetMapNode(Level level)
	{
		if (levelToMapNode.TryGetValue(level, out var value))
		{
			return value;
		}
		return null;
	}

	public void Save(SaveDataContext context)
	{
		context.MetaSave.sandstormTutorialFinished = SandstormTutorialFinished;
	}

	public void Load(SaveDataContext context, bool isNewJourney)
	{
		_ = context.JourneySave;
		MetaSavefile metaSave = context.MetaSave;
		SandstormTutorialFinished = metaSave.sandstormTutorialFinished;
	}

	internal void ResetLevelHistoryToHUB()
	{
		LevelHistory = new List<int> { 0 };
	}

	public void SpawnSandstorm()
	{
		if (ZoneManager.Instance.CurrentZoneIndex > 0)
		{
			Sandstorm = UnityEngine.Object.Instantiate(SandstormPrefabs[ZoneManager.Instance.CurrentZoneIndex - 1], new Vector3(Train.Instance.TrainFrontPosX - Train.Instance.LevelDistance, 0f, 0f), Quaternion.identity).GetComponent<Sandstorm>();
		}
	}

	public void DespawnSandstorm()
	{
		if ((bool)Sandstorm)
		{
			Sandstorm.TurnOff();
		}
	}

	private void AddLevelDifficultyModifers()
	{
		DifficultyManager.Instance.enemyDamageMultiplier += CurrentLevel.EnemyDamageModifier;
		DifficultyManager.Instance.scrapGain += CurrentLevel.ResourceGainModifier;
		DifficultyManager.Instance.waveSpawnModifier += CurrentLevel.WaveSpawnTimeModifier;
		DifficultyManager.Instance.stormSpawnModifier += CurrentLevel.StormSpawnTimeModifier;
		DifficultyManager.Instance.stormDamageMultiplier += CurrentLevel.StormDamageModifier;
		DifficultyManager.Instance.additionalEnemies += CurrentLevel.AdditionalEnemies;
		DifficultyManager.Instance.armoredEnemyChance += CurrentLevel.ArmoredEnemiesAmount;
	}

	private void ClearLevelDifficultyModifiers()
	{
		DifficultyManager.Instance.enemyDamageMultiplier -= CurrentLevel.EnemyDamageModifier;
		DifficultyManager.Instance.scrapGain -= CurrentLevel.ResourceGainModifier;
		DifficultyManager.Instance.waveSpawnModifier -= CurrentLevel.WaveSpawnTimeModifier;
		DifficultyManager.Instance.stormSpawnModifier -= CurrentLevel.StormSpawnTimeModifier;
		DifficultyManager.Instance.stormDamageMultiplier -= CurrentLevel.StormDamageModifier;
		DifficultyManager.Instance.additionalEnemies -= CurrentLevel.AdditionalEnemies;
		DifficultyManager.Instance.armoredEnemyChance -= CurrentLevel.ArmoredEnemiesAmount;
	}
}
