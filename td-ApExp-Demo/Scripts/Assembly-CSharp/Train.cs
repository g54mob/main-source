using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using AudioSystem;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Train : MonoBehaviour, ISaveable
{
	public delegate void NewWagonSetHandler(Wagon wagon);

	private struct SpeedTracking
	{
		public float speed;

		public float time;
	}

	private const float CONNECTOR_WIDTH = 0.1f;

	public float WAGON_TRANSPARENCY_ALPHA = 0.2f;

	public TrainDirections moveDirection = TrainDirections.None;

	private Animator locomotiveAnim;

	private bool isDebugSpeedOn;

	[NonSerialized]
	public float SpeedMax;

	public float CoopCoalSecondsCapacityPercentDeduction = 60f;

	private float coalSeconds;

	[NonSerialized]
	public bool pauseCoal;

	[NonSerialized]
	public bool preventCoalGain;

	[SerializeField]
	private float slowDebuffSpeed;

	public const float SPEED_CHANGE_TIME = 5f;

	[SerializeField]
	private float brakeEffectValueCap;

	private float targetSpeed;

	private bool isReducingSpeed;

	[NonSerialized]
	public float repairableDamageTaken;

	public bool IsOverfillEnabled;

	public bool IsInOverfill;

	public bool isOverfillSpeedDial;

	private float OverfillSpeedDialTimeNeeded = 0.25f;

	private float OverfillSpeedDialTimeNow;

	private float OverfillSpeedDialUpdateTime = 0.1f;

	[HideInInspector]
	public float momentumTimer;

	public static bool ShowRoofOnEmptyWagons;

	[Header("Train Component Prefabs")]
	[SerializeField]
	private GameObject wagonConnectorPrefab;

	[SerializeField]
	private Transform backBlocker;

	private AudioSource audioSource;

	private Animator impactAnim;

	private SpriteRenderer impactSr;

	private AudioSource impactAudioSource;

	private float brakingAcceleration = 0.5f;

	private float maxSpeed = 1f;

	public Transform platformTf;

	[SerializeField]
	private ParticleSystem dustPs;

	[SerializeField]
	public bool hideDust;

	[SerializeField]
	private AudioClip chooChooSound;

	[SerializeField]
	private AudioClip trainStoppingClip;

	[SerializeField]
	private float maxBrakeSparks = 100f;

	[SerializeField]
	private ParticleSystem[] brakePSs;

	[NonSerialized]
	[HideInInspector]
	public bool moduleDeflectOn;

	[NonSerialized]
	[HideInInspector]
	public ModuleDeflect moduleDeflect;

	[NonSerialized]
	[HideInInspector]
	public float hackExpiryStunDurationAndDamage;

	[NonSerialized]
	[HideInInspector]
	public float hackDamageMult = 1f;

	[NonSerialized]
	public bool AutoRepairModules;

	[NonSerialized]
	public float AutoRepairModulesTimer;

	[NonSerialized]
	public float AutoRepairModulesHealthPercent;

	[NonSerialized]
	public bool MagneticHullActive;

	[NonSerialized]
	public float MagneticHullRepairPercent;

	private ModuleSlot furnaceModuleSlot;

	private ModuleSlot leverModuleSlot;

	private ModuleSlot cannonModuleSlot;

	private ModuleSlot clawModuleSlot;

	public PlayerController _drivingPlayer;

	public Action<bool> OnShowRoof;

	[NonSerialized]
	[HideInInspector]
	public int obstacleImmunitiesPerLevel;

	private int obstacleImmunitiesRemaining;

	public SpriteRenderer plowSr;

	[NonSerialized]
	public bool moduleDeathBulletBurst;

	public GameObject bulletPrefab;

	[NonSerialized]
	public int projectileScreenWarpCounter;

	[SerializeField]
	private GameObject explosionPrefab;

	[NonSerialized]
	public bool coalInfusionOn;

	[NonSerialized]
	public float coalFillPercent;

	[SerializeField]
	[Range(0f, 1f)]
	private float directHitHullDamageTaken;

	public float BaseGrace = 10f;

	public float GraceInterval = 1.5f;

	private float graceTimer;

	private float graceDamageRemaining;

	[SerializeField]
	public float healthIncreasePerModule;

	[SerializeField]
	public float hullDamageTakenOnModuleBreak;

	private float maxSpeedDialDistance = 0.75f;

	[NonSerialized]
	public bool isInOverdrive;

	private bool isDying;

	private List<EnemyBase> coalDrainers;

	[Header("Speed Tracking Settings")]
	[SerializeField]
	private float speedIncreaseChangePercentNeeded;

	[SerializeField]
	private float speedDecreaseChangePercentNeeded;

	[SerializeField]
	private float amountOfTime;

	private List<SpeedTracking> speedHistory;

	private float speedInLastFrame;

	private float startingMaxSpeed;

	private bool startedBraking;

	[NonSerialized]
	public bool isNextTurnFake;

	[NonSerialized]
	public int cannonDamageIncreaseCounter;

	[NonSerialized]
	public int playerRepairSpeedIncreaseCounter;

	private List<Coroutine> currentSpeedBuffCoroutines = new List<Coroutine>();

	private bool speedLock;

	private TrainSelectionWindow trainSelectionWindow;

	private Transform playerParent;

	[NonSerialized]
	public bool isSwapping;

	private TrainType newTrainType;

	[SerializeField]
	private List<ParticleSystem> brakePsForSwapping;

	[SerializeField]
	private SpriteRenderer locomotive;

	[SerializeField]
	private SpriteRenderer locomotiveFiller;

	[SerializeField]
	private SpriteRenderer locomotiveMetal;

	[SerializeField]
	private Animator locomotiveAnimator;

	[SerializeField]
	private SpriteRenderer roofSr;

	public static Train Instance { get; set; }

	public TrainCustomization Customization { get; private set; }

	public float WAGON_HALF_WIDTH => 0.15f;

	public float MODULE_HALF_WIDTH => WAGON_HALF_WIDTH;

	public ModuleFurnace furnace { get; private set; }

	[field: SerializeField]
	public ModuleDirectionLever DirectionLever { get; private set; }

	public bool DebugIsImmune { get; private set; }

	public float CoalSecondsCapacity
	{
		get
		{
			float num = ((PlayerManager.Instance.Players.Count <= 1) ? 1f : (Mathf.Clamp(100f - CoopCoalSecondsCapacityPercentDeduction, 0f, 100f) / 100f));
			return furnace.GetUpgradedStatValueByStatType(StatTypes.capacity) * num;
		}
	}

	public float CoalFillNormalizedOnLevelStart { get; set; } = 0.5f;

	public float CoalSeconds
	{
		get
		{
			return coalSeconds;
		}
		set
		{
			coalSeconds = Mathf.Clamp(value, 0f, CoalSecondsCapacity);
		}
	}

	public float GlobalDistance
	{
		get
		{
			return Wagons[0].pathFollower.globalDistance;
		}
		set
		{
			Wagons[0].pathFollower.globalDistance = value;
		}
	}

	public float LevelDistance => Wagons[0].pathFollower.globalDistance - LevelManager.Instance.CurrentLevel.GlobalStartDistance;

	public float SpeedCurrent { get; set; }

	public float TrainSpeedNormalized => Mathf.Clamp01(SpeedCurrent / SpeedMax);

	public float SlowPercentDebuff { get; set; }

	private float SlowNormalized => (100f - Math.Clamp(SlowPercentDebuff, 0f, 100f)) / 100f;

	public List<Wagon> Wagons { get; private set; }

	public List<Module> Modules { get; private set; }

	public bool RoofsVisible { get; private set; }

	public float PlatformDst { get; private set; }

	[field: SerializeField]
	public Health HealthComponent { get; private set; }

	[field: Header("Sounds")]
	[field: SerializeField]
	public AudioClip moduleDestroyedClip { get; private set; }

	[field: SerializeField]
	public AudioClip moduleEMPClip { get; private set; }

	public int TrainGlobalIndex => Mathf.FloorToInt(GlobalDistance / 4.8f);

	public int ObstacleImmunitiesRemaining
	{
		get
		{
			return obstacleImmunitiesRemaining;
		}
		private set
		{
			obstacleImmunitiesRemaining = value;
			plowSr.enabled = obstacleImmunitiesRemaining > 0;
		}
	}

	public bool IsInstantReload { get; private set; }

	public float GraceDamage => Instance.BaseGrace * (1f + DifficultyManager.Instance.graceDamageMultiplier);

	[field: SerializeField]
	public Animator locomotiveTopCoalAnimator { get; private set; }

	[field: SerializeField]
	public Animator fireTrainAnimator { get; private set; }

	[field: SerializeField]
	public Transform snowmakerPositionUp { get; private set; }

	[field: SerializeField]
	public Transform snowmakerPositionDown { get; private set; }

	[field: SerializeField]
	public SerializedDictionary<NewTrainBase, bool> trains { get; private set; }

	[field: NonSerialized]
	public NewTrainBase currentTrain { get; private set; }

	public float DirectHitHullDamageTaken => directHitHullDamageTaken;

	[field: SerializeField]
	public WagonConnector lastConnector { get; private set; }

	public float TrainFrontPosX => Wagons[0].GetComponentInChildren<BoxCollider2D>().size.x / 2f;

	public float TrainBackPosX => GetLastWagon().transform.position.x - GetLastWagon().GetComponentInChildren<BoxCollider2D>().size.x / 2f;

	public event Action<float> DistanceTraveled;

	public event Action<bool> OnOverfillStatusChanged;

	public event Action<Module> ModuleEnabled;

	public event Action<Module> ModuleDisabled;

	public event Action ObstacleHit;

	public event NewWagonSetHandler OnNewWagonSet;

	public event Action<float> OnMitigateDamage;

	public event Action<bool> OnBraking;

	public event Action<bool> OnSpeedingUp;

	public event Action<float> OnHealthBarUpdated;

	public void OnDistanceTraveled(float distance)
	{
		this.DistanceTraveled?.Invoke(distance);
	}

	public void SetLevelDistanceToStart(float distanceFromStart = 1f)
	{
		Wagons[0].pathFollower.globalDistance = LevelManager.Instance.CurrentLevel.GlobalStartDistance + distanceFromStart;
	}

	public void SetLevelDistanceToEnd(float distanceToEnd = 1f)
	{
		Wagons[0].pathFollower.globalDistance = LevelManager.Instance.CurrentLevel.GlobalEndDistance - distanceToEnd;
	}

	public void RemoveModuleFromList(Module m)
	{
		if (Modules != null && Modules.Count > 0 && (bool)m)
		{
			Modules.Remove(m);
		}
	}

	public ModuleSlot GetFurnaceModuleSlot()
	{
		if ((bool)furnaceModuleSlot)
		{
			return furnaceModuleSlot;
		}
		foreach (Wagon wagon in Wagons)
		{
			ModuleSlot[] moduleSlots = wagon.ModuleSlots;
			foreach (ModuleSlot moduleSlot in moduleSlots)
			{
				if (moduleSlot.Module is ModuleFurnace)
				{
					furnaceModuleSlot = moduleSlot;
					return moduleSlot;
				}
			}
		}
		Debug.LogError("Furnace not found!");
		return null;
	}

	public ModuleSlot GetLeverModuleSlot()
	{
		if ((bool)leverModuleSlot)
		{
			return leverModuleSlot;
		}
		foreach (Wagon wagon in Wagons)
		{
			ModuleSlot[] moduleSlots = wagon.ModuleSlots;
			foreach (ModuleSlot moduleSlot in moduleSlots)
			{
				if (moduleSlot.Module is ModuleDirectionLever)
				{
					leverModuleSlot = moduleSlot;
					return moduleSlot;
				}
			}
		}
		Debug.LogError("Lever not found!");
		return null;
	}

	public ModuleSlot GetCannonModuleSlot()
	{
		if ((bool)cannonModuleSlot)
		{
			return cannonModuleSlot;
		}
		foreach (Wagon wagon in Wagons)
		{
			ModuleSlot[] moduleSlots = wagon.ModuleSlots;
			foreach (ModuleSlot moduleSlot in moduleSlots)
			{
				if (moduleSlot.Module is ModuleCannon)
				{
					cannonModuleSlot = moduleSlot;
					return moduleSlot;
				}
			}
		}
		Debug.LogError("Cannon not found!");
		return null;
	}

	public ModuleSlot GetClawModuleSlot()
	{
		if ((bool)clawModuleSlot)
		{
			return clawModuleSlot;
		}
		foreach (Wagon wagon in Wagons)
		{
			ModuleSlot[] moduleSlots = wagon.ModuleSlots;
			foreach (ModuleSlot moduleSlot in moduleSlots)
			{
				if (moduleSlot.Module is ModuleClaw)
				{
					clawModuleSlot = moduleSlot;
					return moduleSlot;
				}
			}
		}
		if ((bool)Wagons[1] && Wagons[1].ModuleSlots.Length == 4)
		{
			return Wagons[1].ModuleSlots[3];
		}
		Debug.LogError("Claw not found!");
		return null;
	}

	public void ResetStartingModuleSlots()
	{
		furnaceModuleSlot = null;
		leverModuleSlot = null;
		cannonModuleSlot = null;
		clawModuleSlot = null;
	}

	public int GetModuleIndex(ModuleSlot moduleSlot)
	{
		return GetModuleIndex(moduleSlot.Module);
	}

	public int GetModuleIndex(Module module)
	{
		int num = 0;
		foreach (Wagon wagon in Wagons)
		{
			Module[] modules = wagon.Modules;
			for (int i = 0; i < modules.Length; i++)
			{
				if (modules[i] == module)
				{
					return num;
				}
				num++;
			}
		}
		return -1;
	}

	public bool IsFirstModule(Module module)
	{
		return Wagons[0].Modules[0] == module;
	}

	public bool IsLastModule(Module module)
	{
		return GetLastWagon().Modules[^1] == module;
	}

	public void OnModuleEnabled(Module module)
	{
		this.ModuleEnabled?.Invoke(module);
	}

	public void OnModuleDisabled(Module module)
	{
		this.ModuleDisabled?.Invoke(module);
	}

	public void HideTrainMap()
	{
		Modules[0].GetComponentInChildren<StationMapTooltip>()?.ForceHide();
	}

	public void DebugSetInstantReload(bool instantReload)
	{
		IsInstantReload = instantReload;
		GetModuleByType<ModuleCannon>().cannon.DebugSetInstantReload(IsInstantReload);
	}

	public void ResetObstacleImmunitiesRemaining()
	{
		ObstacleImmunitiesRemaining = obstacleImmunitiesPerLevel;
	}

	public void SetNewTrain(NewTrainBase newTrain)
	{
		currentTrain = newTrain;
	}

	public float ModuleTryTakeDamage(float damage)
	{
		if (damage >= 0f)
		{
			return 0f;
		}
		float num = Mathf.Max(damage, 0f - graceDamageRemaining);
		graceDamageRemaining += num;
		return num;
	}

	private void Awake()
	{
		Debug.Log("Train Awake");
		Instance = this;
		Customization = GetComponent<TrainCustomization>();
		SlowPercentDebuff = 0f;
		HealthComponent.OnDeath += OnDeath;
		HealthComponent.OnHealthChanged += OnHealthChanged;
		Wagons = GetComponentsInChildren<Wagon>().ToList();
		locomotiveAnim = Wagons[0].GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		impactAnim = GameObject.Find("FX Impact").GetComponent<Animator>();
		impactSr = GameObject.Find("FX Impact").GetComponent<SpriteRenderer>();
		impactAudioSource = GameObject.Find("FX Impact").GetComponent<AudioSource>();
		speedHistory = new List<SpeedTracking>();
		speedInLastFrame = 999f;
	}

	private void Start()
	{
		RefreshModules();
		InitializeMilestones();
		SetDirectionLever();
		SetFurnace();
		UIManager.Instance.TrainHealthBar.repairableBar.SetValue(0f);
		LevelManager.Instance.LevelCompleted += HandleLevelCompleted;
		LevelManager.Instance.DestinationReached += OnDestinationReached;
		LevelManager.Instance.LevelStarted += HandleLevelStarted;
		LevelManager.Instance.NextLevelSelected += delegate
		{
			HandleNextLevelSelected();
		};
		HealthComponent.OnDamageReduced += DamageMitigated;
		GameManager.Instance.JourneyStarted += HandleJourneyStarted;
		GameManager.Instance.JourneyContinued += HandleJourneyContinued;
		LevelManager.Instance.LevelCompleted += DealDamageOnStation;
		LevelManager.Instance.LevelStarted += delegate
		{
			repairableDamageTaken = 0f;
		};
		coalDrainers = new List<EnemyBase>();
		SpeedMax = GameManager.Instance.CurrentGameSpeed;
		startingMaxSpeed = SpeedMax;
		targetSpeed = startingMaxSpeed;
		trainSelectionWindow = MenuManager.Instance.GetMenu(MenuType.TrainSelection).gameObject.GetComponent<TrainSelectionWindow>();
	}

	private void OnDestroy()
	{
		LevelManager.Instance.LevelCompleted -= HandleLevelCompleted;
		LevelManager.Instance.DestinationReached -= OnDestinationReached;
		LevelManager.Instance.LevelStarted -= HandleLevelStarted;
		LevelManager.Instance.NextLevelSelected -= delegate
		{
			HandleNextLevelSelected();
		};
		HealthComponent.OnDamageReduced -= DamageMitigated;
		GameManager.Instance.JourneyStarted -= HandleJourneyStarted;
		GameManager.Instance.JourneyContinued -= HandleJourneyContinued;
		LevelManager.Instance.LevelCompleted -= DealDamageOnStation;
		if (MagneticHullActive)
		{
			CombatManager.Instance.EnemyKilled -= HandleEnemyKilled;
		}
	}

	private void HandleModuleBreak(Module module)
	{
		throw new NotImplementedException();
	}

	public void SetMaxHullBasedOnModules()
	{
		int num = Modules.Where((Module m) => m).Count();
		Instance.HealthComponent.SetMaxHealth((float)num * healthIncreasePerModule);
		RadarUpgrade[] radarUpgradeSaves = UpgradeManager.Instance.RadarUpgradeSaves;
		foreach (RadarUpgrade radarUpgrade in radarUpgradeSaves)
		{
			if (radarUpgrade != null && radarUpgrade.isBought && radarUpgrade.IsApplied && radarUpgrade.upgrade is RadarStartingHull)
			{
				radarUpgrade.upgrade.OnApplied();
			}
		}
	}

	public void SetMaxHullBasedOnModulesAndUpgrades()
	{
		SetMaxHullBasedOnModules();
		List<EnhancementUpgrade> list = UpgradeManager.Instance.UpgradesInInventory.Where((EnhancementUpgrade u) => u is IEnhancementMaxHull).ToList();
		EnhancementUpgrade[] relicsInInventory = UpgradeManager.Instance.RelicsInInventory;
		if (list != null)
		{
			foreach (IEnhancementMaxHull item in list)
			{
				item?.ExecuteOnLoad();
			}
		}
		if (relicsInInventory != null)
		{
			EnhancementUpgrade[] array = relicsInInventory;
			for (int num = 0; num < array.Length; num++)
			{
				((IEnhancementMaxHull)array[num])?.ExecuteOnLoad();
			}
		}
	}

	public void SetDirectionLever()
	{
		DirectionLever = GetModuleByType<ModuleDirectionLever>();
	}

	public void SetFurnace()
	{
		furnace = GetModuleByType<ModuleFurnace>();
	}

	public void SetClaw()
	{
	}

	public void SetWagonsLayout(TrainWagonLayout[] wagonLayouts)
	{
		UpgradeManager.Instance.ModulesInInventory = new List<EnhancementModule>();
		for (int i = 0; i < wagonLayouts.Length; i++)
		{
			if (i >= Wagons.Count)
			{
				AddWagon(UpgradeManager.Instance.Wagons[wagonLayouts[i].wagonSize - 1].WagonPrefab);
			}
			int j;
			for (j = 0; j < wagonLayouts[i].wagonSize; j++)
			{
				if (wagonLayouts[i].modules[j] == ModuleTypes.None)
				{
					continue;
				}
				if (Wagons[i].ModuleSlots[j].Module == null)
				{
					EnhancementModule enhancementModule = UpgradeManager.Instance.Modules.FirstOrDefault((EnhancementModule m) => m.ModuleType == wagonLayouts[i].modules[j]);
					if ((object)enhancementModule != null)
					{
						Wagons[i].ModuleSlots[j].SetModule(enhancementModule);
						UpgradeManager.Instance.ModulesInInventory.Add(enhancementModule);
					}
				}
				else
				{
					UpgradeManager.Instance.ModulesInInventory.Add(Wagons[i].ModuleSlots[j].Module.Enhancement);
				}
			}
		}
	}

	private void Update()
	{
		if (!GameManager.Instance.IsJourneyStarted)
		{
			return;
		}
		CheckForInstantSpeedChange();
		speedInLastFrame = SpeedCurrent;
		RecordSpeed();
		if (impactAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
		{
			impactSr.enabled = false;
		}
		if (IsInOverfill)
		{
			foreach (MilestoneOverfillDuration overfillDurationMilestone in MilestoneManager.Instance.OverfillDurationMilestones)
			{
				if (!overfillDurationMilestone.Completed)
				{
					overfillDurationMilestone.AddProgress(Time.deltaTime);
				}
			}
		}
		UpdateDustParticles();
		backBlocker.position = GetLastWagon().backBlockerPosition.position;
		locomotiveAnim.SetFloat("Speed", SpeedCurrent / 2.4f);
		audioSource.pitch = Mathf.Min(1.25f, SpeedCurrent / 4.8f);
		if (SpeedCurrent <= 0.1f)
		{
			audioSource.Stop();
		}
		else if (!audioSource.isPlaying)
		{
			audioSource.Play();
		}
		if (!IsInOverfill && !isInOverdrive)
		{
			UIManager.Instance.SpeedDial.SetRot01(TrainSpeedNormalized * maxSpeedDialDistance);
		}
		else if (isInOverdrive)
		{
			UIManager.Instance.SpeedDial.SetRot01(TrainSpeedNormalized);
		}
		else if (!isOverfillSpeedDial)
		{
			StartCoroutine(TweenToOverdriveSpeed());
			isOverfillSpeedDial = true;
		}
		graceTimer -= Time.deltaTime;
		if (graceTimer <= 0f)
		{
			graceTimer = GraceInterval;
			graceDamageRemaining = GraceDamage;
		}
	}

	private void UpdateDustParticles()
	{
		if (LevelManager.Instance.CurrentLevel == null || LevelManager.Instance.CurrentLevel.Index == 0)
		{
			return;
		}
		if (hideDust)
		{
			dustPs.Stop();
			return;
		}
		if (!dustPs.isPlaying)
		{
			dustPs.Play();
		}
		ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = dustPs.velocityOverLifetime;
		velocityOverLifetime.speedModifier = TrainSpeedNormalized * 2f;
		ParticleSystem.EmissionModule emission = dustPs.emission;
		emission.rateOverTimeMultiplier = TrainSpeedNormalized * 25f;
	}

	public void RemoveModulesForTutorial()
	{
		List<Module> list = new List<Module>();
		if (Modules == null)
		{
			return;
		}
		for (int i = 0; i < Modules.Count; i++)
		{
			if (Modules[i] != null && (Modules[i].Name == "Track Lever" || Modules[i].Name == "Claw" || Modules[i].Name == "Cannon"))
			{
				list.Add(Modules[i]);
				Modules[i] = null;
			}
		}
		foreach (Module item in list)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
	}

	public void RefreshModules()
	{
		List<Module> list = new List<Module>();
		foreach (Wagon wagon in Wagons)
		{
			ModuleSlot[] moduleSlots = wagon.ModuleSlots;
			foreach (ModuleSlot moduleSlot in moduleSlots)
			{
				if (moduleSlot.Module != null)
				{
					list.Add(moduleSlot.Module);
				}
			}
		}
		Modules = list;
	}

	public Module[] FindAdjacentModules(Module targetModule)
	{
		Module[] array = new Module[2];
		for (int i = 0; i < Instance.Modules.Count; i++)
		{
			Module module = Instance.Modules[i];
			if ((bool)module && module == targetModule)
			{
				if (i - 1 >= 0)
				{
					array[0] = Instance.Modules[i - 1];
				}
				else
				{
					array[0] = null;
				}
				if (i + 1 < Instance.Modules.Count)
				{
					array[1] = Instance.Modules[i + 1];
				}
				else
				{
					array[1] = null;
				}
			}
		}
		return array;
	}

	public Module[] FindAdjacentModulesWithoutEmptySlots(Unit targetModule)
	{
		List<Module> list = new List<Module>();
		foreach (Wagon wagon in Wagons)
		{
			ModuleSlot[] moduleSlots = wagon.ModuleSlots;
			foreach (ModuleSlot moduleSlot in moduleSlots)
			{
				list.Add(moduleSlot.Module);
			}
		}
		Module[] array = new Module[2];
		for (int j = 0; j < list.Count; j++)
		{
			Module module = list[j];
			if ((bool)module && module == targetModule)
			{
				if (j - 1 >= 0)
				{
					array[0] = list[j - 1];
				}
				else
				{
					array[0] = null;
				}
				if (j + 1 < list.Count)
				{
					array[1] = list[j + 1];
				}
				else
				{
					array[1] = null;
				}
			}
		}
		return array;
	}

	public void AddWagon(GameObject wagonPrefab)
	{
		float lastWagonLeftPosX = GetLastWagonLeftPosX();
		Vector3 position = new Vector3(lastWagonLeftPosX - wagonPrefab.GetComponent<BoxCollider2D>().size.x / 2f - 0.1f, 0f);
		Wagon component = UnityEngine.Object.Instantiate(wagonPrefab, position, Quaternion.identity, base.transform).GetComponent<Wagon>();
		Wagons.Add(component);
		UpdateDoorLocks();
		this.OnNewWagonSet?.Invoke(component);
		if (coalInfusionOn)
		{
			ModuleSlot[] componentsInChildren = component.GetComponentsInChildren<ModuleSlot>();
			foreach (ModuleSlot obj in componentsInChildren)
			{
				obj.coalFillPercent = coalFillPercent;
				obj.coalInfusionOn = true;
			}
		}
		WagonConnector component2 = UnityEngine.Object.Instantiate(wagonConnectorPrefab, base.transform.position, Quaternion.identity, base.transform).GetComponent<WagonConnector>();
		component2.ahead = Wagons[Wagons.Count - 2];
		component2.behind = Wagons[Wagons.Count - 1];
		component2.transform.SetSiblingIndex(component2.transform.GetSiblingIndex() - 1);
		component2.name = $"Conn {component2.ahead.wagonIndex}-{component2.behind.wagonIndex}";
		lastConnector = component2;
	}

	public void Move()
	{
		if (furnace.IsEMPattached)
		{
			if (targetSpeed != 0f && SpeedCurrent <= targetSpeed)
			{
				SpeedReduced();
				SpeedMax = targetSpeed;
			}
			if (!startedBraking)
			{
				startedBraking = true;
				NotifyOfBraking(forcedSlow: true);
			}
			momentumTimer = Mathf.Clamp(momentumTimer - Time.deltaTime, 0f, 5f);
		}
		else if (!ResourceManager.Instance.DebugIsInfiniteCoal && (CoalSeconds <= 0f || (furnace.IsFullyBroken && !furnace.continueDuringDeath)))
		{
			if (LevelManager.Instance.IsPlaying)
			{
				GameManager.Instance.isOverfillStationConditionMet = false;
			}
			if (targetSpeed != 0f && SpeedCurrent <= targetSpeed)
			{
				SpeedReduced();
				SpeedMax = targetSpeed;
			}
			if (!startedBraking)
			{
				startedBraking = true;
				NotifyOfBraking(forcedSlow: true);
			}
			if (!IsInOverfill)
			{
				momentumTimer = Mathf.Clamp(momentumTimer - Time.deltaTime, 0f, 5f);
			}
			else
			{
				furnace.TurnOverfillOff();
				momentumTimer = Mathf.Clamp(momentumTimer - Time.deltaTime, 0f, 5f);
				furnace.HealthComponent.SetHealthWithInfo(new HealthChangeInfo(furnace, furnace.HealthComponent, -100f, isPercent: true, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
				furnace.HealthComponent.ReduceHealthTo0(furnace);
				CoalSeconds -= CoalSecondsCapacity * 0.5f;
			}
		}
		else if (coalSeconds > 0f)
		{
			if (!ResourceManager.Instance.DebugIsInfiniteCoal)
			{
				if (IsInOverfill && CoalSeconds < 10f)
				{
					HUD.Instance.OverfillWarning.SetActive(value: true);
				}
				else if (IsInOverfill && CoalSeconds >= 10f)
				{
					HUD.Instance.OverfillWarning.SetActive(value: false);
				}
			}
			if (isReducingSpeed)
			{
				ForceBrake(targetSpeed);
				return;
			}
			startedBraking = false;
			momentumTimer += Time.deltaTime;
		}
		float t = Mathf.Clamp01(momentumTimer / 5f);
		SpeedCurrent = Mathf.Lerp(0f, SpeedMax * SlowNormalized, t);
	}

	public void PlayStoppingClip()
	{
		AudioManager.Instance.PlayClipWithMixer(trainStoppingClip, AMG.SFX, 0.2f);
	}

	public void Brake()
	{
		momentumTimer = 0f;
		if (!(TrackManager.Instance.PlatformTf == null))
		{
			if (base.transform.position.x > TrackManager.Instance.PlatformTf.position.x || SpeedCurrent < 0.01f)
			{
				StopBrakePs();
				SpeedCurrent = 0f;
				return;
			}
			PlatformDst = Vector2.Distance(base.transform.position, TrackManager.Instance.PlatformTf.position);
			PlatformDst = Mathf.Max(PlatformDst, 0.1f);
			float num = Mathf.Max(Mathf.Lerp(0f, brakingAcceleration, Mathf.Clamp01(SpeedCurrent / maxSpeed)), 0.1f);
			float a = Mathf.Pow(SpeedCurrent, 2.5f) / (2f * PlatformDst);
			a = Mathf.Max(a, 0.1f);
			float num2 = num - a;
			SpeedCurrent += num2 * Time.deltaTime;
			PlayBrakePs();
		}
	}

	public void ForceBrake(float targetValue)
	{
		SpeedCurrent -= SpeedCurrent / targetSpeed * Time.deltaTime;
		if (SpeedCurrent <= targetSpeed && targetSpeed != 0f)
		{
			SpeedMax = targetSpeed;
			SpeedReduced();
		}
	}

	private void PlayBrakePs()
	{
		ParticleSystem[] array = brakePSs;
		foreach (ParticleSystem particleSystem in array)
		{
			if (!particleSystem.isPlaying)
			{
				particleSystem.Play();
			}
			ParticleSystem.EmissionModule emission = particleSystem.emission;
			emission.rateOverTime = TrainSpeedNormalized * maxBrakeSparks;
		}
	}

	private void StopBrakePs()
	{
		ParticleSystem[] array = brakePSs;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
		}
	}

	public void NotifyOfBraking(bool forcedSlow)
	{
		this.OnBraking?.Invoke(forcedSlow);
	}

	public void NotifyOfSpeedingUp(bool forcedSpeedUp)
	{
		this.OnSpeedingUp?.Invoke(forcedSpeedUp);
	}

	private void OnHealthChanged(HealthChangeInfo info)
	{
		BarControllerHull trainHealthBar = UIManager.Instance.TrainHealthBar;
		trainHealthBar.SetValues(HealthComponent.HealthCurrent / HealthComponent.HealthMax);
		trainHealthBar.UpdateRepairableBarPosition();
		DataTrackingManager.Instance.AddHullDamageTaken(info.HealthChange);
		if (!isDying)
		{
			CheckRepairableDamageOverkill(info);
		}
		if (GameManager.Instance.IsJourneyStarted)
		{
			this.OnHealthBarUpdated?.Invoke(info.HealthChange);
		}
	}

	public void CheckRepairableDamageOverkill(HealthChangeInfo info)
	{
		if (HealthComponent.HealthCurrent <= repairableDamageTaken)
		{
			HealthComponent.OnPreDeath(info);
			if (!(HealthComponent.HealthCurrent > repairableDamageTaken))
			{
				BarControllerHull trainHealthBar = UIManager.Instance.TrainHealthBar;
				trainHealthBar.repairableBar.SetValue(0f);
				trainHealthBar.SetValues(0f);
				isDying = true;
				HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(info.source, HealthComponent, 0f - repairableDamageTaken, isPercent: false, null, canRes: false, ignoreArmor: true, ignoreImmunity: true, isBurn: false, ignoreGrace: true, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
			}
		}
	}

	public void OnModuleDamaged()
	{
	}

	public void OnModuleDestroyed(Module module)
	{
		repairableDamageTaken += module.HealthComponent.HealthMax;
		BarControllerHull trainHealthBar = UIManager.Instance.TrainHealthBar;
		trainHealthBar.repairableBar.lerpMovement = true;
		trainHealthBar.repairableBar.SetValue(trainHealthBar.repairableBar.value01 + module.HealthComponent.HealthMax / HealthComponent.HealthMax);
	}

	public void OnModuleRepaired(Module module)
	{
		repairableDamageTaken -= module.HealthComponent.HealthMax;
		BarControllerHull trainHealthBar = UIManager.Instance.TrainHealthBar;
		trainHealthBar.repairableBar.SetValue(trainHealthBar.repairableBar.value01 - module.HealthComponent.HealthMax / HealthComponent.HealthMax);
	}

	private void OnDeath(HealthChangeInfo info)
	{
		if (info.source != null)
		{
			GameObject targetObject = info.source.AsGameObject();
			GameManager.Instance.CaptureEnemyWithBackground(targetObject);
		}
		StartCoroutine(HandleTrainDestructionSequence());
	}

	private IEnumerator HandleTrainDestructionSequence()
	{
		SaveManager.Instance.ShouldSaveJourney = false;
		SaveManager.Instance.SaveJourney();
		foreach (PlayerController player in PlayerManager.Instance.Players)
		{
			if (player != null && player.gameObject.activeInHierarchy)
			{
				player.interactor.InteractorState = InteractorStates.Disabled;
				player.canMove = false;
			}
		}
		HUD.Instance.ShowAll(show: false);
		SetRoofVisibilities(visible: true);
		CameraController.Instance.ZoomOut();
		yield return new WaitForSeconds(0.5f);
		for (int w = Wagons.Count - 1; w >= 0; w--)
		{
			Wagon wagon = Wagons[w];
			Module[] modules = (from s in wagon.ModuleSlots
				where s.Module != null
				select s.Module).Reverse().ToArray();
			Module[] array = modules;
			foreach (Module module in array)
			{
				UnityEngine.Object.Instantiate(explosionPrefab, module.transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(null, 0.125f, 0f);
				yield return new WaitForSeconds(0.125f);
			}
			if (modules.Length != 0)
			{
				UnityEngine.Object.Instantiate(explosionPrefab, wagon.transform.position, Quaternion.identity).GetComponent<Explosion>().Initialize(null, 0.333f, 0f);
				yield return new WaitForSeconds(0.25f);
			}
		}
		yield return new WaitForSeconds(1f);
		GameManager.Instance.GameOver(victory: false);
	}

	public void GetHitByObstacle(int damage, GameObject obstacle)
	{
		impactSr.enabled = true;
		impactAnim.Play("Impact", 0, 0f);
		impactAudioSource.Play();
		ObstacleImmunitiesRemaining--;
		if (ObstacleImmunitiesRemaining >= 0)
		{
			this.ObstacleHit?.Invoke();
			return;
		}
		plowSr.enabled = false;
		if (!ResourceManager.Instance.DebugIsInfiniteCoal)
		{
			CoalSeconds -= CoalSecondsCapacity * 0.5f;
		}
		HealthChangeInfo info = new HealthChangeInfo(obstacle, Modules[0].HealthComponent, -damage, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: true, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God);
		Modules[0].HealthComponent.ChangeHealthWithInfo(info);
		PlayStoppingClip();
		this.ObstacleHit?.Invoke();
	}

	public void GetHitByBombardment(float damage, GameObject bomb)
	{
		ObstacleImmunitiesRemaining--;
		if (ObstacleImmunitiesRemaining < 0)
		{
			plowSr.enabled = false;
			HealthChangeInfo info = new HealthChangeInfo(bomb, Instance.HealthComponent, damage, isPercent: true);
			Instance.HealthComponent.ChangeHealthWithInfo(info);
		}
	}

	public void SetRoofVisibilities(bool visible)
	{
		RoofsVisible = visible;
		OnShowRoof?.Invoke(visible);
		foreach (Wagon wagon in Wagons)
		{
			wagon.SetRoofsVisibility(visible ? RoofVisibility.Visible : RoofVisibility.Invisible);
		}
	}

	public void SetRoofVisibilities()
	{
		foreach (Wagon wagon in Wagons)
		{
			wagon.UpdateRoofsVisibility();
		}
		OnShowRoof?.Invoke(obj: false);
	}

	public void UpdateDoorLocks()
	{
		foreach (Wagon wagon in Wagons)
		{
			wagon.UpdateDoorLocks();
		}
	}

	[Obsolete("Use TrainFrontPosX instead")]
	public float GetFirstWagonRightPosX()
	{
		return Wagons[0].GetComponentInChildren<BoxCollider2D>().size.x / 2f;
	}

	[Obsolete("Use TrainBackPosX instead")]
	public float GetLastWagonLeftPosX()
	{
		float num = GetLastWagon().GetComponentInChildren<BoxCollider2D>().size.x / 2f;
		return GetLastWagon().transform.position.x - num;
	}

	public Vector2 GetRandomVisiblePosition()
	{
		return new Vector2(y: (UnityEngine.Random.Range(0, 2) != 0) ? UnityEngine.Random.Range(-1.5f, -1f) : UnityEngine.Random.Range(1f, 1.5f), x: UnityEngine.Random.Range(-1.5f, 1.5f));
	}

	public Vector3 GetPlayerSpawnPoint(int playerIndex)
	{
		if (playerIndex < 0)
		{
			Debug.LogError("Invalid player index for GetNewPlayerSpawnPoint: " + playerIndex);
			return Vector3.zero;
		}
		if (Modules == null || Modules.Count == 0)
		{
			Debug.LogError("No modules found for GetNewPlayerSpawnPoint.");
			return Vector3.zero;
		}
		do
		{
			if (playerIndex >= Modules.Count)
			{
				List<Module> modules = Modules;
				if (!(modules[modules.Count - 1] != null))
				{
					return GetLastWagon().ModuleSlots[^1].transform.position;
				}
				List<Module> modules2 = Modules;
				return modules2[modules2.Count - 1].transform.position;
			}
			if (!Modules[playerIndex])
			{
				playerIndex++;
				continue;
			}
			return Modules[playerIndex].transform.position;
		}
		while (playerIndex < Modules.Count + 1);
		return GetLastWagon().ModuleSlots[^1].transform.position;
	}

	public ModuleSlot GetFirstEmptyModuleSlot()
	{
		return (from slot in Wagons.SelectMany((Wagon wagon) => wagon.ModuleSlots)
			where slot.Module == null
			orderby slot.ModuleType == ModuleCombatTypes.Wild
			select slot).FirstOrDefault();
	}

	public int GetNumberOfEmptyModuleSlots()
	{
		new List<ModuleSlot>();
		return (from slot in Wagons.SelectMany((Wagon wagon) => wagon.ModuleSlots)
			where slot.Module == null
			orderby slot.ModuleType == ModuleCombatTypes.Wild
			select slot).ToList().Count();
	}

	private void OnDestinationReached()
	{
		foreach (Module module in Modules)
		{
			if ((bool)module)
			{
				module.HandleDestinationReached();
				module.HealthComponent.StopBurn();
			}
		}
		ResetObstacleImmunitiesRemaining();
		if (ZoneManager.Instance.CurrentZone == null)
		{
			Wagons[0].LockExteriorDoors((true, true));
		}
		else if (LevelManager.Instance.CurrentLevel.Index == 0 && ZoneManager.Instance.CurrentZone.Definition.ZoneName == "T0_Tutorial")
		{
			Wagons[0].LockExteriorDoors((false, false));
		}
		else if (LevelManager.Instance.CurrentLevel.Index == 0 && ZoneManager.Instance.CurrentZone.Definition.ZoneName == "Z1_Wasteland")
		{
			Wagons[0].LockExteriorDoors((false, false));
		}
		else
		{
			Wagons[0].LockExteriorDoors((true, true));
		}
		if (IsInOverfill)
		{
			furnace.TurnOverfillOffOnDestinationReached();
		}
		CoalSeconds = 0f;
	}

	private void HandleJourneyStarted()
	{
		Wagons[0].LockExteriorDoors((false, false));
	}

	private void HandleJourneyContinued()
	{
		Wagons[0].LockExteriorDoors((true, true));
	}

	private void HandleNextLevelSelected()
	{
		SetRoofVisibilities(visible: true);
		PlayChooChoo();
		Wagons[0].LockExteriorDoors((true, true));
	}

	private void HandleLevelStarted()
	{
		SlowPercentDebuff = 0f;
		HealthComponent.IsImmune = DebugIsImmune;
		SetAllModulesImmunity(DebugIsImmune);
		CoalSeconds = CoalSecondsCapacity * CoalFillNormalizedOnLevelStart;
		SetRoofVisibilities(SaveManager.Instance.ShowRoofOnEmptyWagons);
	}

	private void HandleLevelCompleted()
	{
		SpeedMax = startingMaxSpeed;
		isDebugSpeedOn = false;
		SlowPercentDebuff = 0f;
		HealthComponent.IsImmune = true;
		SetAllModulesImmunity(isImmune: true);
	}

	public void PlacePlayersInTrain()
	{
		if (PlayerManager.Instance.IsCoop)
		{
			_ = _drivingPlayer != null;
		}
		for (int i = 0; i < PlayerManager.Instance.Players.Count; i++)
		{
			PlayerController playerController = PlayerManager.Instance.Players[i];
			if (playerController != null && playerController.gameObject.activeInHierarchy)
			{
				playerController.transform.position = GetPlayerSpawnPoint(i);
			}
		}
	}

	public void SetAllModulesImmunity(bool isImmune)
	{
		foreach (Module module in Modules)
		{
			if ((bool)module)
			{
				module.HealthComponent.IsImmune = isImmune;
				if (isImmune)
				{
					module.HealthComponent.StopBurn();
				}
			}
		}
	}

	public void MaxHealAllModules(bool hideHealParticles = false)
	{
		foreach (Module module in Modules)
		{
			if (!(module == null))
			{
				HealthChangeInfo info = new HealthChangeInfo(this, module.HealthComponent, 100f, isPercent: true, null, canRes: true, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God);
				module.HealthComponent.SetHealthWithInfo(info, hideHealParticles);
			}
		}
	}

	public void DebugSetImmunity(bool isImmune)
	{
		HealthComponent.IsImmune = isImmune;
		foreach (Module module in Modules)
		{
			if ((bool)module)
			{
				module.HealthComponent.IsImmune = isImmune;
			}
		}
		DebugIsImmune = isImmune;
	}

	public T GetModuleByType<T>() where T : Module
	{
		if (Modules == null)
		{
			return null;
		}
		foreach (Module module in Modules)
		{
			if (module is T)
			{
				return (T)module;
			}
		}
		return null;
	}

	public T[] GetModulesByType<T>() where T : Module
	{
		return Modules.OfType<T>().ToArray();
	}

	public void PlayChooChoo()
	{
		AudioManager.Instance.PlayClipWithMixer(chooChooSound, AMG.SFX);
	}

	public void Save(SaveDataContext context)
	{
		if (!GameManager.Instance.IsJourneyStarted)
		{
			return;
		}
		MetaSavefile metaSave = context.MetaSave;
		metaSave.currentTrain = (int)currentTrain.trainType;
		metaSave.cannonDamageIncreaseCounter = cannonDamageIncreaseCounter;
		metaSave.playerRepairSpeedIncreaseCounter = playerRepairSpeedIncreaseCounter;
		bool flag = false;
		foreach (KeyValuePair<NewTrainBase, bool> train in trains)
		{
			for (int i = 0; i < metaSave.trainNames.Count; i++)
			{
				AddMissingTrainWorldBeatenToSave(metaSave.trainNames[i], i, metaSave);
				if (metaSave.trainNames[i] == train.Key.TrainName)
				{
					metaSave.isTrainUnlocked[i] = train.Value;
					metaSave.trainWorldBeaten[i] = train.Key.WorldBeaten;
					flag = true;
				}
			}
			if (flag)
			{
				flag = false;
				continue;
			}
			metaSave.trainNames.Add(train.Key.TrainName);
			metaSave.isTrainUnlocked.Add(train.Value);
			metaSave.trainWorldBeaten.Add(train.Key.WorldBeaten);
		}
	}

	private void AddMissingTrainWorldBeatenToSave(string trainName, int i, MetaSavefile metaSave)
	{
		if (metaSave.trainWorldBeaten.Count < i + 1)
		{
			NewTrainBase trainByName = GetTrainByName(trainName);
			if (trainByName != null)
			{
				metaSave.trainWorldBeaten.Add(trainByName.WorldBeaten);
			}
		}
	}

	public void Load(SaveDataContext context, bool isNewJourney)
	{
		HealthComponent.SetHealthWithInfo(new HealthChangeInfo(null, HealthComponent, HealthComponent.HealthMax, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God), hideHealParticles: true);
		MetaSavefile metaSave = context.MetaSave;
		JourneySavefile journeySave = context.JourneySave;
		foreach (string trainName in metaSave.trainNames)
		{
			foreach (NewTrainBase key in trains.Keys)
			{
				if (trainName == key.TrainName)
				{
					int num = metaSave.trainNames.IndexOf(trainName);
					trains[key] = metaSave.isTrainUnlocked[num];
					if (metaSave.trainWorldBeaten == null || metaSave.trainWorldBeaten.Count - 1 < num)
					{
						key.WorldBeaten = 0;
					}
					else
					{
						key.WorldBeaten = metaSave.trainWorldBeaten[num];
					}
					break;
				}
			}
		}
		if (metaSave.trainNames == null || metaSave.trainNames.Count == 0)
		{
			foreach (NewTrainBase key2 in Instance.trains.Keys)
			{
				key2.WorldBeaten = 0;
			}
		}
		if (isNewJourney)
		{
			currentTrain = trains.Keys.ElementAt(0);
			return;
		}
		foreach (NewTrainBase key3 in trains.Keys)
		{
			if (key3.trainType != (TrainType)metaSave.currentTrain)
			{
				continue;
			}
			currentTrain = key3;
			currentTrain.ApplyNewTrain(ignoreEnhancements: true, forceApply: true);
			if (currentTrain is CannonTrain cannonTrain)
			{
				cannonDamageIncreaseCounter = metaSave.cannonDamageIncreaseCounter;
				if (journeySave.SavedOnLevelStart)
				{
					cannonTrain.LoadCannonDamage();
				}
				else
				{
					cannonTrain.LoadCannonDamage(-1);
				}
			}
			else if (currentTrain is ArmoredTrain armoredTrain)
			{
				playerRepairSpeedIncreaseCounter = metaSave.playerRepairSpeedIncreaseCounter;
				if (journeySave.SavedOnLevelStart)
				{
					armoredTrain.LoadStacks();
				}
				else
				{
					armoredTrain.LoadStacks(-1);
				}
			}
			break;
		}
	}

	public void InitializeMilestones()
	{
		if (MilestoneManager.Instance.milestones.Count == 0)
		{
			return;
		}
		foreach (MilestoneMinigamesCompleted minigamesCompletedMilestone in MilestoneManager.Instance.MinigamesCompletedMilestones)
		{
			minigamesCompletedMilestone.Initialize();
		}
		foreach (MilestoneModuleDealDamage moduleDealDamageMilestone in MilestoneManager.Instance.ModuleDealDamageMilestones)
		{
			moduleDealDamageMilestone.Initialize();
		}
		foreach (MilestoneModuleMitigateDamage moduleMitigateDamageMilestone in MilestoneManager.Instance.ModuleMitigateDamageMilestones)
		{
			moduleMitigateDamageMilestone.Initialize();
		}
		foreach (MilestoneModuleUsed moduleUsedMilestone in MilestoneManager.Instance.ModuleUsedMilestones)
		{
			moduleUsedMilestone.Initialize();
		}
	}

	public virtual void DamageMitigated(float damageMitigated)
	{
		this.OnMitigateDamage?.Invoke(damageMitigated);
	}

	public float GetOverfillPercent()
	{
		return furnace.OverfillTimeNow / furnace.OverfillTimeNeeded;
	}

	private IEnumerator TweenToOverdriveSpeed()
	{
		while (OverfillSpeedDialTimeNeeded > OverfillSpeedDialTimeNow)
		{
			UIManager.Instance.SpeedDial.SetRot01(Vector2.Lerp(new Vector3(TrainSpeedNormalized * maxSpeedDialDistance, 0f), new Vector3(TrainSpeedNormalized, 0f), OverfillSpeedDialTimeNow / OverfillSpeedDialTimeNeeded).x);
			OverfillSpeedDialTimeNow += Time.deltaTime;
			yield return new WaitForSeconds(OverfillSpeedDialUpdateTime);
		}
		UIManager.Instance.SpeedDial.SetRot01(TrainSpeedNormalized);
		OverfillSpeedDialTimeNow = 0f;
	}

	public void AddSlowDebuff(float amount, float speed = 1f)
	{
		if (amount > 0f)
		{
			StartCoroutine(AddSlowDebuffCoroutine(amount, speed));
		}
		else
		{
			SlowPercentDebuff += amount;
		}
	}

	private IEnumerator AddSlowDebuffCoroutine(float targetAmount, float speed = 1f)
	{
		PlayStoppingClip();
		PlayBrakePs();
		float amount = 0f;
		while (amount < targetAmount)
		{
			amount += slowDebuffSpeed * speed;
			SlowPercentDebuff += slowDebuffSpeed * speed;
			if (SlowPercentDebuff < 0f)
			{
				SlowPercentDebuff = 0f;
				break;
			}
			yield return new WaitForSeconds(0.01f);
		}
		StopBrakePs();
	}

	public void RemoveSlowDebuff()
	{
		AddSlowDebuff(0f - SlowPercentDebuff);
	}

	public void RemoveSlowDebuffGradually()
	{
		StopBrakePs();
		StartCoroutine(RemoveSlowDebuffGraduallyCoroutine());
		IEnumerator RemoveSlowDebuffGraduallyCoroutine()
		{
			while (SlowPercentDebuff > 0f)
			{
				SlowPercentDebuff -= slowDebuffSpeed;
				if (SlowPercentDebuff < 0f)
				{
					SlowPercentDebuff = 0f;
					break;
				}
				yield return new WaitForSeconds(0.01f);
			}
		}
	}

	internal void DestroyFurnace(bool emptyCoal = false)
	{
		if (emptyCoal)
		{
			CoalSeconds = 0f;
		}
		furnace.HealthComponent.SetHealthWithInfo(new HealthChangeInfo(null, furnace.HealthComponent, -100f, isPercent: true, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
	}

	private void DealDamageOnStation()
	{
		BarControllerHull trainHealthBar = UIManager.Instance.TrainHealthBar;
		trainHealthBar.repairableBar.lerpMovement = false;
		trainHealthBar.repairableBar.SetValue(0f);
		HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(PlayerManager.Instance.Players[0], HealthComponent, 0f - repairableDamageTaken, isPercent: false, null, canRes: false, ignoreArmor: true, ignoreImmunity: true, isBurn: false, ignoreGrace: true, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
		repairableDamageTaken = 0f;
	}

	public void DrainCoal(float amount, EnemyBase drainer)
	{
		if (!coalDrainers.Contains(drainer) && !drainer.IsHacked)
		{
			coalDrainers.Add(drainer);
			drainer.OnDeathEvent += delegate
			{
				if (coalDrainers.Contains(drainer))
				{
					coalDrainers.Remove(drainer);
					if (coalDrainers.Count < 2)
					{
						preventCoalGain = false;
					}
				}
			};
			if (coalDrainers.Count >= 2)
			{
				preventCoalGain = true;
			}
		}
		else if (coalDrainers.Contains(drainer) && drainer.IsHacked)
		{
			coalDrainers.Remove(drainer);
			if (coalDrainers.Count < 2)
			{
				preventCoalGain = false;
			}
		}
		if (!ResourceManager.Instance.DebugIsInfiniteCoal)
		{
			float value = Instance.CoalSeconds - amount;
			Instance.CoalSeconds = Math.Clamp(value, 0f, Instance.CoalSecondsCapacity);
		}
	}

	public void RemoveDrainer(EnemyBase drainer)
	{
		if (coalDrainers.Contains(drainer))
		{
			coalDrainers.Remove(drainer);
			if (coalDrainers.Count < 2)
			{
				preventCoalGain = false;
			}
		}
	}

	public void RecordSpeed()
	{
		speedHistory.Add(new SpeedTracking
		{
			speed = SpeedCurrent,
			time = Time.time
		});
		RemoveOldEvents();
		IsSpeedChangeBigEnough();
	}

	public void IsSpeedChangeBigEnough()
	{
		RemoveOldEvents();
		float num = 0f;
		float speed = speedHistory[0].speed;
		foreach (SpeedTracking item in speedHistory)
		{
			float num2 = (speed - item.speed) / startingMaxSpeed * 100f;
			if (num2 < 0f)
			{
				if (num2 < num)
				{
					num = num2;
				}
				if (Mathf.Abs(num) >= speedIncreaseChangePercentNeeded)
				{
					speedHistory.Clear();
					NotifyOfSpeedingUp(forcedSpeedUp: false);
					break;
				}
			}
		}
	}

	private void RemoveOldEvents()
	{
		float currentTime = Time.time;
		speedHistory.RemoveAll((SpeedTracking e) => currentTime - e.time > amountOfTime);
	}

	private void CheckForInstantSpeedChange()
	{
		float num = (speedInLastFrame - SpeedCurrent) / startingMaxSpeed * 100f;
		if (speedInLastFrame == 0f)
		{
			if (SpeedCurrent > 0f)
			{
				NotifyOfSpeedingUp(forcedSpeedUp: false);
			}
		}
		else if (speedInLastFrame > SpeedCurrent)
		{
			speedInLastFrame = SpeedCurrent;
			NotifyOfBraking(forcedSlow: false);
		}
		else if (Mathf.Abs(num) >= speedIncreaseChangePercentNeeded && num < 0f)
		{
			speedInLastFrame = SpeedCurrent;
			NotifyOfSpeedingUp(forcedSpeedUp: true);
		}
	}

	internal Interactable[] GetModuleInteractables()
	{
		Module[] array = Modules.Where((Module m) => m).ToArray();
		Interactable[] array2 = new Interactable[array.Length];
		for (int num = 0; num < array.Length; num++)
		{
			if ((bool)array[num] && array[num].Interactable != null)
			{
				array2[num] = array[num].Interactable;
			}
		}
		return array2;
	}

	internal void SetDrivingPlayer()
	{
		ModuleSlot moduleSlot = GetFurnaceModuleSlot();
		if ((object)moduleSlot != null && moduleSlot.Module is ModuleFurnace moduleFurnace && moduleFurnace.Interactable.Interactor != null)
		{
			_drivingPlayer = moduleFurnace.Interactable.Interactor.playerController;
		}
	}

	public void ApplyDeflectSplitBullet()
	{
		StartCoroutine(ApplyUpgrade());
		IEnumerator ApplyUpgrade()
		{
			yield return new WaitUntil(() => moduleDeflect);
			moduleDeflect.deflectSplitBullet = true;
		}
	}

	public void ApplyDeflectCanHack(float probability)
	{
		StartCoroutine(ApplyUpgrade());
		IEnumerator ApplyUpgrade()
		{
			yield return new WaitUntil(() => moduleDeflect);
			moduleDeflect.deflectCanHack = true;
			moduleDeflect.deflectHackProbability = probability;
		}
	}

	public void ApplyDeflectBulletDamageUp(float increasePercent)
	{
		StartCoroutine(ApplyUpgrade());
		IEnumerator ApplyUpgrade()
		{
			yield return new WaitUntil(() => moduleDeflect);
			moduleDeflect.deflectDamageIncrease = increasePercent;
		}
	}

	public void ApplyDeflectDoubleWave()
	{
		StartCoroutine(ApplyUpgrade());
		IEnumerator ApplyUpgrade()
		{
			yield return new WaitUntil(() => moduleDeflect);
			moduleDeflect.deflectDoubleWave = true;
		}
	}

	public void ApplyDeflectRefundCooldown()
	{
		StartCoroutine(ApplyUpgrade());
		IEnumerator ApplyUpgrade()
		{
			yield return new WaitUntil(() => moduleDeflect);
			moduleDeflect.deflectRefundCooldown = true;
		}
	}

	public void ApplyDeflectCannonDamage()
	{
		StartCoroutine(ApplyUpgrade());
		IEnumerator ApplyUpgrade()
		{
			yield return new WaitUntil(() => moduleDeflect);
			moduleDeflect.deflectCanBoostCannon = true;
		}
	}

	internal void ApplyDeflectWidth()
	{
		StartCoroutine(ApplyUpgrade());
		IEnumerator ApplyUpgrade()
		{
			yield return new WaitUntil(() => moduleDeflect);
			moduleDeflect.deflectWidthIncrease = true;
		}
	}

	internal void ApplyDeflectAutowave(float autowaveCooldown)
	{
		StartCoroutine(ApplyUpgrade());
		IEnumerator ApplyUpgrade()
		{
			yield return new WaitUntil(() => moduleDeflect);
			moduleDeflect.autoWaveOn = true;
			moduleDeflect.autoWaveCooldown = autowaveCooldown;
		}
	}

	public void ApplyShieldCooldown(Action<Module> functionCovered, Action<Module> functionUncovered)
	{
		StartCoroutine(ApplyUpgrade());
		IEnumerator ApplyUpgrade()
		{
			ModuleShield shield = GetModuleByType<ModuleShield>();
			if ((object)shield != null)
			{
				yield return new WaitUntil(() => shield.plate);
				shield.plate.OnModuleCovered += functionCovered;
				shield.plate.OnModuleUncovered += functionUncovered;
			}
		}
	}

	public void ApplyShieldDouble()
	{
		StartCoroutine(ApplyUpgrade());
		IEnumerator ApplyUpgrade()
		{
			ModuleShield shield = GetModuleByType<ModuleShield>();
			if ((object)shield != null)
			{
				yield return new WaitUntil(() => (bool)shield.plateN && (bool)shield.plateS);
				shield.SetPlatesActive((true, true));
			}
		}
	}

	public void ApplyShieldHeal(Action<float> function)
	{
		StartCoroutine(ApplyUpgrade());
		IEnumerator ApplyUpgrade()
		{
			ModuleShield shield = GetModuleByType<ModuleShield>();
			if ((object)shield != null)
			{
				yield return new WaitUntil(() => (bool)shield.plateN && (bool)shield.plateS);
				shield.plateN.GetComponent<Health>().OnDamageReduced += function;
				shield.plateS.GetComponent<Health>().OnDamageReduced += function;
			}
		}
	}

	public void ApplyShieldRicochet(float ricochetChance)
	{
		StartCoroutine(ApplyUpgrade());
		IEnumerator ApplyUpgrade()
		{
			ModuleShield shield = GetModuleByType<ModuleShield>();
			if ((object)shield != null)
			{
				yield return new WaitUntil(() => (bool)shield.plateN && (bool)shield.plateS);
				shield.plateRicochetChance = ricochetChance;
				shield.SetPlateRicochet();
			}
		}
	}

	public void ApplyShieldWide()
	{
		StartCoroutine(ApplyUpgrade());
		IEnumerator ApplyUpgrade()
		{
			ModuleShield shield = GetModuleByType<ModuleShield>();
			if ((object)shield != null)
			{
				yield return new WaitUntil(() => (bool)shield.plateN && (bool)shield.plateS);
				shield.SetPlatesSize();
			}
		}
	}

	public void OverfillStatusChanged(bool isInOverfill)
	{
		this.OnOverfillStatusChanged?.Invoke(isInOverfill);
	}

	public Module GetRandomModule()
	{
		int index = UnityEngine.Random.Range(0, Instance.Modules.Count);
		return Instance.Modules[index];
	}

	public Module GetRandomModule(Module[] exclude = null, Module[] whitelist = null)
	{
		List<Module> list = new List<Module>();
		list = ((exclude == null || exclude.Length == 0) ? Modules.ToList() : Modules.Except(exclude).ToList());
		if (whitelist != null && whitelist.Length != 0)
		{
			list = list.Intersect(whitelist).ToList();
		}
		if (list.Count == 0)
		{
			return null;
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public Module[] GetDamagedModules()
	{
		return Modules.Where((Module m) => (bool)m && m.HealthComponent.HealthCurrent < m.HealthComponent.HealthMax).ToArray();
	}

	public void LockMaxSpeed(bool isLocked, float targetSpeedValue = 0f)
	{
		if (targetSpeedValue > 0f && isLocked)
		{
			SpeedMax = targetSpeedValue;
		}
		speedLock = isLocked;
		if (isLocked)
		{
			foreach (Coroutine currentSpeedBuffCoroutine in currentSpeedBuffCoroutines)
			{
				StopCoroutine(currentSpeedBuffCoroutine);
			}
			if (currentSpeedBuffCoroutines.Count > 0)
			{
				currentSpeedBuffCoroutines.Clear();
			}
		}
		else
		{
			SpeedMax = GameManager.Instance.CurrentGameSpeed;
		}
	}

	public void SpeedChange(float speedAmount, bool isPercent = false)
	{
		if (speedAmount != 0f && !speedLock)
		{
			if (isPercent)
			{
				speedAmount = GameManager.Instance.GameSpeedNormal * (speedAmount / 100f);
			}
			speedAmount *= GameManager.Instance.GameSpeedModifier;
			targetSpeed += speedAmount;
			if (targetSpeed >= SpeedMax)
			{
				SpeedReduced();
				SpeedMax = targetSpeed;
			}
			else
			{
				ReduceSpeedTo(targetSpeed);
			}
		}
	}

	public void SpeedUpBuff(float speedAmount, float duration, bool isPercent = false)
	{
		if (speedAmount != 0f && !speedLock)
		{
			Coroutine self = null;
			self = StartCoroutine(SpeedUpCoroutine(self, speedAmount, duration, isPercent));
			currentSpeedBuffCoroutines.Add(self);
		}
	}

	private IEnumerator SpeedUpCoroutine(Coroutine self, float speedAmount, float duration, bool isPercent = false)
	{
		SpeedChange(speedAmount, isPercent);
		yield return new WaitForSeconds(duration);
		SpeedChange(0f - speedAmount, isPercent);
	}

	public void DebugSpeedOn()
	{
		if (!isDebugSpeedOn)
		{
			isDebugSpeedOn = true;
			SpeedMax += 40f;
		}
	}

	public void DebugSpeedOff()
	{
		if (isDebugSpeedOn)
		{
			isDebugSpeedOn = false;
			SpeedMax -= 40f;
		}
	}

	public float CurrentSpeedIndex()
	{
		return SpeedCurrent / startingMaxSpeed;
	}

	public void ChangeGameSpeed(float value)
	{
		if (!speedLock)
		{
			SpeedMax = value;
			startingMaxSpeed = SpeedMax;
			targetSpeed = startingMaxSpeed;
		}
	}

	public void RemoveAllBurn()
	{
		foreach (Module module in Modules)
		{
			if (module.HealthComponent.isBurning)
			{
				module.HealthComponent.StopBurn();
			}
		}
	}

	public void ReduceSpeedTo(float targetSpeed)
	{
		isReducingSpeed = true;
		if (SpeedCurrent - targetSpeed > brakeEffectValueCap * GameManager.Instance.GameSpeedModifier)
		{
			PlayBrakePs();
			PlayStoppingClip();
		}
	}

	public void SpeedReduced()
	{
		StopBrakePs();
		isReducingSpeed = false;
	}

	public Wagon GetLastWagon()
	{
		List<Wagon> wagons = Wagons;
		if ((bool)wagons[wagons.Count - 1])
		{
			List<Wagon> wagons2 = Wagons;
			return wagons2[wagons2.Count - 1];
		}
		return Wagons[0];
	}

	public void DriveOut(TrainType type)
	{
		isSwapping = true;
		trainSelectionWindow.LockAllButtons(isLocked: true);
		MenuManager.Instance.preventMenuClose = true;
		newTrainType = type;
		playerParent = PlayerManager.Instance.Players[0].transform.parent;
		foreach (PlayerController player in PlayerManager.Instance.Players)
		{
			player.transform.parent = null;
		}
		GetComponent<Animator>().Play("TrainSwapAnim");
	}

	public void SwapTrain()
	{
		trainSelectionWindow.SwapTrains(newTrainType);
		EffectsUtils.PlayMultipleParticles(brakePsForSwapping, play: true);
	}

	public void SwapFinished()
	{
		foreach (PlayerController player in PlayerManager.Instance.Players)
		{
			player.transform.parent = playerParent;
		}
		isSwapping = false;
		trainSelectionWindow.SwappingFinished(newTrainType);
		MenuManager.Instance.preventMenuClose = false;
	}

	public void SwapTrainArt(NewTrainBase newTrain)
	{
		locomotive.sprite = newTrain.locomotiveArt;
		locomotiveFiller.enabled = false;
		locomotiveMetal.enabled = false;
		foreach (Transform item in locomotiveMetal.transform)
		{
			SpriteRenderer componentInChildren = item.gameObject.GetComponentInChildren<SpriteRenderer>();
			if ((object)componentInChildren != null)
			{
				componentInChildren.enabled = false;
			}
		}
		roofSr.sprite = newTrain.roofSprite;
		roofSr.color = Color.white;
		locomotiveAnimator.Play(newTrain.animName ?? "");
		if (newTrain.PlowArt == null)
		{
			plowSr.sprite = trains.Keys.ElementAt(0).PlowArt;
		}
		else
		{
			plowSr.sprite = newTrain.PlowArt;
		}
		foreach (Wagon wagon in Wagons)
		{
			wagon.SetHardedningArt(newTrain);
		}
		Customization.ChangeCategoryColor(newTrain.trainColor, TrainCustomization.ColorCategory.Paint);
	}

	public void ResetTrainArt(NewTrainBase newTrain)
	{
		locomotive.sprite = newTrain.locomotiveArt;
		locomotiveFiller.enabled = true;
		locomotiveMetal.enabled = true;
		foreach (Transform item in locomotiveMetal.transform)
		{
			SpriteRenderer componentInChildren = item.gameObject.GetComponentInChildren<SpriteRenderer>();
			if ((object)componentInChildren != null)
			{
				componentInChildren.enabled = true;
			}
		}
		roofSr.sprite = newTrain.roofSprite;
		roofSr.color = newTrain.trainColor;
		locomotiveAnimator.Play(newTrain.animName ?? "");
		if (newTrain.PlowArt == null)
		{
			plowSr.sprite = trains.Keys.ElementAt(0).PlowArt;
		}
		else
		{
			plowSr.sprite = newTrain.PlowArt;
		}
		foreach (Wagon wagon in Wagons)
		{
			wagon.SetHardedningArt(newTrain);
		}
		Customization.ChangeCategoryColor(newTrain.trainColor, TrainCustomization.ColorCategory.Paint);
	}

	public NewTrainBase GetTrainByType(TrainType trainType)
	{
		foreach (NewTrainBase key in trains.Keys)
		{
			if (key.trainType == trainType)
			{
				return key;
			}
		}
		return null;
	}

	public NewTrainBase GetTrainByName(string name)
	{
		foreach (NewTrainBase key in trains.Keys)
		{
			if (key.TrainName == name)
			{
				return key;
			}
		}
		return null;
	}

	internal void TurnOnMagneticHull(float amount)
	{
		MagneticHullActive = true;
		MagneticHullRepairPercent = amount;
		CombatManager.Instance.EnemyKilled += HandleEnemyKilled;
	}

	private void HandleEnemyKilled(EnemyBase @base, Unit unit, HealthChangeInfo info)
	{
		Module randomModule = GetRandomModule(null, GetDamagedModules());
		if ((bool)randomModule)
		{
			randomModule.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(this, randomModule.HealthComponent, MagneticHullRepairPercent, isPercent: true, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
		}
	}

	public List<ModuleSlot> GetAllModuleSlots()
	{
		List<ModuleSlot> list = new List<ModuleSlot>();
		foreach (Wagon wagon in Wagons)
		{
			list.AddRange(wagon.ModuleSlots);
		}
		return list;
	}
}
