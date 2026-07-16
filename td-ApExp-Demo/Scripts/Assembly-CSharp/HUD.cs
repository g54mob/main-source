using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI healthText;

	[SerializeField]
	private TextMeshProUGUI waveTimerText;

	[Header("Tweeners")]
	[SerializeField]
	private Tweener healthTw;

	[SerializeField]
	private Tweener coalTw;

	[SerializeField]
	private Tweener distanceTw;

	[SerializeField]
	private Tweener cannonTw;

	[SerializeField]
	private Tweener coresTw;

	private Tweener[] allTws;

	private Tweener[] nonEssentialTws;

	[Header("Other")]
	[SerializeField]
	private FillBar progressBar;

	[SerializeField]
	private GameObject progressPointer;

	[SerializeField]
	private Image sandstormBar;

	[SerializeField]
	private Image sandstormPointer;

	private Dictionary<iBossController, BossHealthBar> bossControllers;

	[SerializeField]
	private SlidingUIElement tabTooltip;

	[SerializeField]
	private SlidingUIElement moduleSwapTooltip;

	[SerializeField]
	private BossHealthBarManager bossHealthBars;

	[Header("Ammo")]
	[SerializeField]
	private List<TextMeshProUGUI> numbersTxt;

	[SerializeField]
	private List<Digit> ammoDigits;

	[SerializeField]
	private Counter ammoCounter;

	[Header("Scrap")]
	[SerializeField]
	private Counter scrapCounter;

	[Header("Scrambling")]
	[SerializeField]
	private HudScrambleParticleController scramblePsController;

	[NonSerialized]
	public bool IsScrambled;

	private float scrambleTimer;

	private float minScrambleInterval;

	private float maxScrambleInterval;

	private bool moduleSwappingShowing;

	public static HUD Instance { get; private set; }

	[field: SerializeField]
	public CannonAmmo CannonAmmo { get; private set; }

	[field: SerializeField]
	public Coal Coal { get; private set; }

	[field: SerializeField]
	public Image CoalFill { get; private set; }

	[field: SerializeField]
	public GameObject OverfillWarning { get; private set; }

	[field: SerializeField]
	public GameObject SandstormWarning { get; private set; }

	public static event Action OnScramble;

	public static event Action OnUnscramble;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		allTws = new Tweener[4] { healthTw, coalTw, distanceTw, cannonTw };
		nonEssentialTws = new Tweener[2] { coalTw, cannonTw };
		healthTw.OnMoveToEnd += TryShowWaveTimer;
		healthTw.OnMoveToStart += delegate
		{
			waveTimerText.gameObject.SetActive(value: false);
		};
	}

	private void Start()
	{
		bossControllers = new Dictionary<iBossController, BossHealthBar>();
		LevelManager.Instance.LevelStarted += delegate
		{
			ShowAll(show: true);
		};
		LevelManager.Instance.NextLevelSelected += delegate
		{
			ShowCoresCounter(show: false);
		};
		LevelManager.Instance.LevelCompleted += delegate
		{
			ShowNonEssential(show: false);
		};
		LevelManager.Instance.LevelCompleted += delegate
		{
			ShowCoresCounter(show: true);
		};
		LevelManager.Instance.LevelCompleted += HideBossBars;
		GameManager.Instance.JourneyStarted += delegate
		{
			ShowCoresCounter(show: true);
		};
		GameManager.Instance.JourneyContinued += delegate
		{
			ShowCoresCounter(show: true);
		};
		EnemyManager.Instance.OnBossSpawned += BossSpawned;
		LevelManager.Instance.DestinationReached += tabTooltip.SlideIn;
		LevelManager.Instance.NextLevelSelected += delegate
		{
			tabTooltip.SlideOut();
		};
		LevelManager.Instance.DestinationReached += ShowModuleSwappingTooltip;
		LevelManager.Instance.NextLevelSelected += delegate
		{
			HideModuleSwappingTooltip();
		};
		LevelManager.Instance.DestinationReached += ResetSandstormDistance;
		EnemyManager.Instance.OnScramble += HandleScramble;
		EnemyManager.Instance.OnUnscramble += HandleUnscramble;
	}

	private void HandleUnscramble()
	{
		if (EnemyManager.Instance.scramblersAlive.Count == 0)
		{
			SetScramble(isScrambled: false);
		}
	}

	private void HandleScramble(Vector2 interval)
	{
		minScrambleInterval = interval.x;
		maxScrambleInterval = interval.y;
		SetScramble(isScrambled: true);
	}

	private void TryGetBoss(iBossController controller, BossHealthBar bhb)
	{
		if (LevelManager.Instance.CurrentLevel.LevelType == LevelType.Boss)
		{
			bossControllers.Add(controller, bhb);
			bhb.Activate();
		}
	}

	private void Update()
	{
		if (LevelManager.Instance.CurrentLevel == null || !GameManager.Instance.IsJourneyStarted)
		{
			return;
		}
		if (IsScrambled)
		{
			if (EnemyManager.Instance.scramblersAlive.Count == 0)
			{
				SetUnscrambledElements();
			}
			SetScrambledElements();
			return;
		}
		HideWaveTimer();
		UpdateDistanceCoalFill();
		UpdateSandstormDistance();
		if (LevelManager.Instance.CurrentLevel == null || LevelManager.Instance.CurrentLevel.LevelType == LevelType.Boss)
		{
			foreach (KeyValuePair<iBossController, BossHealthBar> bossController in bossControllers)
			{
				float values = bossController.Key.GetCurrentTotalHealth() / bossController.Key.GetTotalMaxHealth();
				bossController.Value.BarController.SetValues(values);
			}
			UIManager.Instance.TrainDistanceBar.SetValues(1f);
		}
		else
		{
			UIManager.Instance.TrainDistanceBar.SetValues(LevelManager.Instance.CurrentLevelProgress01);
		}
	}

	public void SetScramble(bool isScrambled)
	{
		IsScrambled = isScrambled;
		if (!IsScrambled)
		{
			SetUnscrambledElements();
		}
	}

	private void SetScrambledElements()
	{
		if (scrambleTimer > 0f)
		{
			scrambleTimer -= Time.deltaTime;
			return;
		}
		scrambleTimer = UnityEngine.Random.Range(minScrambleInterval, maxScrambleInterval);
		waveTimerText.text = UnityEngine.Random.Range(0f, 100f).ToString("F1");
		CoalFill.fillAmount = UnityEngine.Random.Range(0f, 1f);
		UIManager.Instance.TrainDistanceBar.SetValues(UnityEngine.Random.Range(0f, 1f));
		Coal.Scramble();
		CannonAmmo.Scramble();
		ammoCounter.Randomize();
		scrapCounter.Randomize();
		scramblePsController.PlayParticles();
		HUD.OnScramble?.Invoke();
	}

	private void SetUnscrambledElements()
	{
		CannonAmmo.Unscramble();
		ammoCounter.Unscramble(ResourceManager.Instance.Ammo.Value);
		scrapCounter.Unscramble(ResourceManager.Instance.Scrap.Value);
		scramblePsController.StopParticles();
		HUD.OnUnscramble?.Invoke();
	}

	public void ShowAll(bool show)
	{
		Tweener[] array = allTws;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Move(show);
		}
		if (LevelManager.Instance.CurrentLevel.LevelType == LevelType.Boss)
		{
			progressPointer.SetActive(value: false);
		}
		else
		{
			progressPointer.SetActive(value: true);
		}
	}

	public void ShowNonEssential(bool show)
	{
		Tweener[] array = nonEssentialTws;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Move(show);
			if (LevelManager.Instance.CurrentLevel.LevelType == LevelType.Boss)
			{
				distanceTw.Move(show);
			}
		}
	}

	public void SetHullTextActive(bool isActive)
	{
		Health healthComponent = Train.Instance.HealthComponent;
		healthText.gameObject.SetActive(isActive);
		if (isActive)
		{
			UpdateHullText();
			healthComponent.OnHealthChanged += delegate
			{
				UpdateHullText();
			};
			healthComponent.OnMaxHealthChanged += UpdateHullText;
		}
		else
		{
			healthComponent.OnHealthChanged -= delegate
			{
				UpdateHullText();
			};
			healthComponent.OnMaxHealthChanged -= UpdateHullText;
		}
	}

	private void UpdateHullText()
	{
		int num = Mathf.CeilToInt(Train.Instance.HealthComponent.HealthCurrent);
		int num2 = Mathf.CeilToInt(Train.Instance.HealthComponent.HealthMax);
		string text = $"{num}/{num2}";
		healthText.text = text;
	}

	private void TryShowWaveTimer()
	{
		if (UIManager.Instance.WaveTimerUnlocked)
		{
			waveTimerText.gameObject.SetActive(value: true);
		}
	}

	private void HideWaveTimer()
	{
		if (!LevelManager.Instance.IsPlaying)
		{
			waveTimerText.gameObject.SetActive(value: false);
		}
	}

	public void UpdateWaveTimerText()
	{
		waveTimerText.text = EnemyManager.Instance.WaveTimer.ToString("F1");
	}

	public void UpdateDistanceCoalFill()
	{
		if (CoalFill.gameObject.activeSelf && Train.Instance.SpeedCurrent != 0f)
		{
			float num = Train.Instance.CoalSeconds * Train.Instance.SpeedCurrent / LevelManager.Instance.CurrentLevel.LevelDistance;
			CoalFill.fillAmount = Mathf.Clamp01(LevelManager.Instance.CurrentLevelProgress01 + num);
		}
	}

	public void ShowCoresCounter(bool show, bool isMilestone = false)
	{
		if (SaveManager.Instance.IsTutorialComplete)
		{
			coresTw.Move(show);
			if (!isMilestone)
			{
				healthTw.Move(show);
			}
		}
	}

	public void ShowCoalGauge(bool show)
	{
		coalTw.Move(show);
	}

	public void ChangeAmmoColor(float ammo)
	{
		if (ammo < 100f)
		{
			foreach (Digit ammoDigit in ammoDigits)
			{
				ammoDigit.preventColorReset = true;
			}
			{
				foreach (TextMeshProUGUI item in numbersTxt)
				{
					item.color = ColorUtils.HexToColor("FF0800");
				}
				return;
			}
		}
		if (!(ammo > 100f) || !(numbersTxt[0].color != ColorUtils.HexToColor("FFFFFF")))
		{
			return;
		}
		foreach (Digit ammoDigit2 in ammoDigits)
		{
			ammoDigit2.preventColorReset = false;
		}
		foreach (TextMeshProUGUI item2 in numbersTxt)
		{
			item2.color = ColorUtils.HexToColor("FFFFFF");
		}
	}

	public void ResetTimer()
	{
		if (LevelManager.Instance.CurrentLevel.LevelType == LevelType.Boss)
		{
			waveTimerText.text = "";
		}
		else
		{
			waveTimerText.text = "0.0";
		}
	}

	private void BossSpawned(iMainBossController controller)
	{
		controller.ControllerDied += HideBossBars;
		distanceTw.Move(isToEndPos: false);
		bossControllers.Clear();
		switch (ZoneManager.Instance.CurrentZoneIndex)
		{
		case 0:
			TryGetBoss(controller, bossHealthBars.TutorialBoss);
			break;
		case 1:
			TryGetBoss(controller, bossHealthBars.Centipede);
			break;
		case 2:
		{
			List<iBossController> allControllers2 = controller.GetAllControllers();
			TryGetBoss(allControllers2[0], bossHealthBars.Trasher);
			TryGetBoss(allControllers2[1], bossHealthBars.Crusher);
			break;
		}
		case 3:
		{
			List<iBossController> allControllers = controller.GetAllControllers();
			TryGetBoss(allControllers[0], bossHealthBars.Eagle);
			TryGetBoss(allControllers[1], bossHealthBars.Crow);
			TryGetBoss(allControllers[2], bossHealthBars.Falcon);
			break;
		}
		case 4:
			TryGetBoss(controller, bossHealthBars.Warlord);
			break;
		}
	}

	private void HideBossBars()
	{
		foreach (KeyValuePair<iBossController, BossHealthBar> bossController in bossControllers)
		{
			bossController.Value.Deactivate();
		}
	}

	public void UpdateSandstormDistance()
	{
		if ((bool)LevelManager.Instance.Sandstorm)
		{
			sandstormBar.fillAmount = Mathf.Clamp01(LevelManager.Instance.Sandstorm.CurrentProgress);
			float width = sandstormBar.rectTransform.rect.width;
			float x = sandstormBar.fillAmount * width - width / 2f;
			sandstormPointer.rectTransform.localPosition = new Vector3(x, sandstormPointer.rectTransform.localPosition.y, 0f);
		}
	}

	public void ResetSandstormDistance()
	{
		sandstormBar.fillAmount = 0f;
		float width = sandstormBar.rectTransform.rect.width;
		float x = sandstormBar.fillAmount * width - width / 2f;
		sandstormPointer.rectTransform.localPosition = new Vector3(x, sandstormPointer.rectTransform.localPosition.y, 0f);
	}

	private void ShowModuleSwappingTooltip()
	{
		Level? currentLevel = LevelManager.Instance.CurrentLevel;
		if (currentLevel != null && currentLevel.LevelType == LevelType.Hub && ZoneManager.Instance.CurrentZoneIndex > 1)
		{
			moduleSwapTooltip.SlideIn();
			moduleSwappingShowing = true;
			distanceTw.Move(isToEndPos: true);
		}
	}

	private void HideModuleSwappingTooltip()
	{
		if (moduleSwappingShowing)
		{
			moduleSwapTooltip.SlideOut();
			moduleSwappingShowing = false;
			distanceTw.Move(isToEndPos: false);
		}
	}
}
