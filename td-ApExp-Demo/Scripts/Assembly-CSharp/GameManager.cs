using System;
using System.Collections;
using AudioSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, ISaveable
{
	public bool isDemo;

	public int SupportedWorlds = 3;

	public const float PPU = 100f;

	public const float DISTANCE_MULT = 10f;

	public static GameManager Instance;

	private bool isPaused = true;

	public StateMachine sm;

	[NonSerialized]
	[Header("Game Speed")]
	public float TopGameSpeed = 4.8f;

	[NonSerialized]
	public float GameSpeedNormal;

	[Header("Version Support")]
	[SerializeField]
	[Tooltip("Anything below this will be overridden, e.g. if Version is 0.1 and minVersion is 0.1, anything below will be overridden.")]
	public string MinVersionMeta;

	[SerializeField]
	[Tooltip("Anything below this will be overridden, e.g. if Version is 0.1 and minVersion is 0.1, anything below will be overridden.")]
	public string MinVersionSettings;

	[SerializeField]
	[Tooltip("Anything below this will be overridden, e.g. if Version is 0.1 and minVersion is 0.1, anything below will be overridden.")]
	public string MinVersionJourney;

	[Header("Stats")]
	public float playtimeInRun;

	public float TotalDamageInRun;

	public float TotalDamageMitigatedInRun;

	public float TotalDamageTakenInRun;

	public float TotalDamageRepairedInRun;

	public float TotalKillsInRun;

	public float TotalModulesActivated;

	public float TotalEnhancementsCollected;

	public int cannonHitsInRun;

	public int cannonFiresInRun;

	[NonSerialized]
	public float locationsVisitedInRun;

	public float TotalKilometersTraveled;

	public float totalJourneys;

	[Header("Drop Shadows")]
	[Range(0f, 360f)]
	public float lightAngle;

	public Color shadowColor;

	public Color shadowColorFlying;

	[Header("UI")]
	[SerializeField]
	private float uiFadeScreenDelay = 0.1f;

	[Header("SFX")]
	[SerializeField]
	private SoundData screenshotSfx;

	private SoundBuilder soundBuilder;

	[Header("Animators")]
	[SerializeField]
	private Animator postcardAnim;

	[SerializeField]
	private Animator apertureAnim;

	[Header("Other")]
	public GameObject hubExitCollider;

	public GameObject repairPsPrefab;

	[SerializeField]
	private Image screenshotImg;

	[SerializeField]
	private Image bastardImg;

	[SerializeField]
	private Transform worldUiCamera;

	[NonSerialized]
	public bool isReadyToSave;

	private MonoBehaviour pauseLockHolder;

	public bool bulletCollisionOn;

	[NonSerialized]
	public bool isTimingMinigameEnabled;

	[NonSerialized]
	public bool minigameTracksReady;

	[NonSerialized]
	public bool minigameTurnReady;

	[NonSerialized]
	public bool ringEventStarted;

	[NonSerialized]
	public bool minigameInProgress;

	[NonSerialized]
	public bool isOverfillStationConditionMet = true;

	private Sprite killerSprite;

	[field: NonSerialized]
	public int UnlockedWorlds { get; private set; }

	public bool IsPaused => isPaused;

	public float MinigameTimescale { get; set; } = 1f;

	[field: SerializeField]
	public float CurrentGameSpeed { get; private set; }

	[field: SerializeField]
	private float MinGameSpeed { get; set; }

	public float GameSpeedModifier => CurrentGameSpeed / TopGameSpeed;

	[field: Header("Release Information")]
	[field: SerializeField]
	[field: Tooltip("e.g. 0.1 Early Access")]
	public string Version { get; private set; }

	[field: SerializeField]
	[field: Tooltip("Format MMM DD YYYY e.g. Oct 22 2024, Jan 01 2025, etc.")]
	public string ReleaseDate { get; private set; }

	public float CannonMissPercent => (float)cannonHitsInRun / (float)cannonFiresInRun * 100f;

	[field: SerializeField]
	public RepairMinigame[] RepairMinigames { get; private set; }

	public bool IsJourneyStarted { get; set; }

	public bool IsTutorialClicked { get; set; }

	[field: SerializeField]
	public TimingRingMinigame ringMinigame { get; private set; }

	[field: NonSerialized]
	public bool RunStarted { get; private set; }

	public event Action JourneyStarted;

	public event Action JourneyContinued;

	public event Action RunQuit;

	private void Awake()
	{
		Instance = this;
		Debug.Log("GameManager Awake");
		Application.targetFrameRate = 60;
		LeanTween.init(1000);
		RepairMinigame[] repairMinigames = RepairMinigames;
		for (int i = 0; i < repairMinigames.Length; i++)
		{
			repairMinigames[i].Initialize();
		}
		sm = new StateMachine();
		sm.BuildStateDictionary(new StateBase[3]
		{
			new GameStateTitle(sm),
			new GameStatePlay(sm),
			new GameStateEnd(sm)
		});
	}

	private void Start()
	{
		LevelUtils.PreloadLevelNameParts();
		MenuManager.Instance.LastMenuClosed += delegate
		{
			HandleMenuClosed(null);
		};
		MenuManager.Instance.MenuOpened += HandleMenuOpened;
		MenuManager.Instance.MenuClosed += HandleMenuClosed;
		JourneyStarted += HandleJourneyStarted;
		JourneyContinued += HandleJourneyStarted;
		MenuSettings optionsMenu = MenuManager.Instance.GetMenu(MenuType.Options).GetComponent<MenuSettings>();
		JourneyStarted += delegate
		{
			optionsMenu.gameSpeedSlider.interactable = false;
		};
		JourneyContinued += delegate
		{
			optionsMenu.gameSpeedSlider.interactable = false;
		};
		RunQuit += delegate
		{
			optionsMenu.gameSpeedSlider.interactable = true;
		};
		GameSpeedNormal = optionsMenu.gameSpeedSettings["Normal"];
		LevelManager.Instance.LevelStarted += delegate
		{
			RunStarted = true;
		};
		CombatManager.Instance.HealthChanged += TrackDamageDone;
		CombatManager.Instance.DamageHealed += TrackHealingDone;
		CombatManager.Instance.EnemyKilled += TrackKills;
		soundBuilder = PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder();
	}

	private void Update()
	{
		sm.UpdateStates();
		UpdatePlayTime();
		TotalKilometersTraveled = Train.Instance.GlobalDistance;
	}

	public void GameOver(bool victory)
	{
		HUB.Instance.hubElements["NoticeBoard"].gameObject.GetComponent<NoticeBoardHub>().UnlockStation();
		DataTrackingManager.Instance.InitializeFromGameManager(this);
		DataTrackingManager.Instance.SendData();
		SaveManager.Instance.isReadyToSaveStats = true;
		SaveManager.Instance.ShouldSaveJourney = false;
		SaveManager.Instance.Save(saveJourney: true);
		sm.ForceState("End");
		if (victory)
		{
			StartCoroutine(Victory());
		}
		else
		{
			StartCoroutine(Defeat());
		}
	}

	private IEnumerator Defeat()
	{
		AudioSource[] array;
		for (int i = 0; i < 10; i++)
		{
			Time.timeScale -= 0.075f;
			array = (AudioSource[])UnityEngine.Object.FindObjectsOfType(typeof(AudioSource));
			for (int j = 0; j < array.Length; j++)
			{
				array[j].pitch = Mathf.Max(Time.timeScale, 0.5f);
			}
			yield return new WaitForSeconds(0.05f);
		}
		yield return new WaitForSeconds(0.25f);
		apertureAnim.Play("ApertureClosing");
		soundBuilder.Play(screenshotSfx);
		yield return new WaitForSeconds(0.1f);
		worldUiCamera.transform.position = new Vector3(999f, 999f, -10f);
		MouseCursor.Instance.HideCursor(blockCursor: true);
		CameraController.Instance.BlockCameraMovement = true;
		Time.timeScale = 0f;
		array = (AudioSource[])UnityEngine.Object.FindObjectsOfType(typeof(AudioSource));
		foreach (AudioSource audioSource in array)
		{
			if (audioSource.outputAudioMixerGroup == AudioManager.Instance.SfxGroup)
			{
				audioSource.volume = 0f;
			}
		}
		yield return new WaitForSecondsRealtime(1f);
		MenuManager.Instance.OpenMenu(MenuType.GameOver);
		if (killerSprite != null)
		{
			bastardImg.sprite = killerSprite;
			MenuManager.Instance.GetMenu(MenuType.GameOver).GetComponent<PostcardMenu>().killerFound = true;
		}
		CaptureScreen();
		yield return new WaitForSecondsRealtime(0.1f);
		MouseCursor.Instance.ShowCursor();
		postcardAnim.Play("PostcardZoomIn");
		yield return new WaitForSeconds(1f);
	}

	private IEnumerator Victory()
	{
		yield return new WaitForSeconds(0.5f);
		apertureAnim.Play("ApertureClosing");
		soundBuilder.Play(screenshotSfx);
		yield return new WaitForSeconds(0.4f);
		worldUiCamera.transform.position = new Vector3(999f, 999f, -10f);
		MouseCursor.Instance.HideCursor(blockCursor: true);
		CameraController.Instance.BlockCameraMovement = true;
		Time.timeScale = 0f;
		AudioSource[] array = (AudioSource[])UnityEngine.Object.FindObjectsOfType(typeof(AudioSource));
		foreach (AudioSource audioSource in array)
		{
			if (audioSource.outputAudioMixerGroup == AudioManager.Instance.SfxGroup)
			{
				audioSource.volume = 0f;
			}
		}
		yield return new WaitForSecondsRealtime(1f);
		MenuManager.Instance.OpenMenu(MenuType.GameOver);
		CaptureScreen();
		yield return new WaitForSecondsRealtime(0.1f);
		MouseCursor.Instance.ShowCursor();
		postcardAnim.Play("PostcardVictory");
		yield return new WaitForSeconds(1f);
	}

	public void NewJourney()
	{
		if (IsJourneyStarted)
		{
			Debug.LogError("Tried to start journey when it's already started.");
			return;
		}
		UIManager.Instance.FadeScreen.BlackScreen();
		PlayAgainHandler.Instance.playAgain = false;
		SaveManager.Instance.NewJourney();
		ZoneManager.Instance.SetFirstZone();
		ZoneManager.Instance.SetZoneAtCurrentZoneIndex(SaveManager.Instance.IsTutorialComplete && !IsTutorialClicked);
		Train.Instance.SetMaxHullBasedOnModules();
		this.JourneyStarted?.Invoke();
		LevelManager.Instance.sm.ForceState("Station");
		sm.ForceState("Play");
		IsJourneyStarted = true;
		if (!SaveManager.Instance.IsTutorialComplete || IsTutorialClicked)
		{
			UIManager.Instance.FadeScreen.ShowUIDelay(1.5f);
		}
		else
		{
			UIManager.Instance.FadeScreen.ShowUIDelay(UIManager.Instance.WorldStartFadeTime);
		}
		isOverfillStationConditionMet = true;
	}

	public void ContinueJourney()
	{
		UIManager.Instance.FadeScreen.BlackScreen();
		SimpleFade.Instance.IsFadeLocked = true;
		SaveManager.Instance.JourneySaveBlocked = true;
		PlayAgainHandler.Instance.playAgain = false;
		ZoneManager.Instance.SetFirstZone();
		SaveManager.Instance.LoadJourney();
		LevelManager.Instance.SetUpNextZoneOnStation = false;
		this.JourneyContinued?.Invoke();
		StartCoroutine(LoadLevelsCoroutine());
		IEnumerator LoadLevelsCoroutine()
		{
			yield return new WaitUntil(() => LevelManager.Instance.Levels.Count > 0);
			if (!SaveManager.Instance.JourneySavedOnLevelStart)
			{
				LevelManager.Instance.DestinationReachedOnLoad = true;
			}
			if (LevelManager.Instance.CurrentLevel.LevelType != LevelType.Hub)
			{
				TrackManager.Instance.HideHub();
				LevelManager.Instance.LoadLastLevelPlayed();
				if (SaveManager.Instance.JourneySavedOnLevelStart)
				{
					Train.Instance.SetLevelDistanceToStart(2f);
				}
				else
				{
					Train.Instance.SetLevelDistanceToEnd();
				}
				LevelManager.Instance.sm.ForceState("Playing");
			}
			else
			{
				Train.Instance.PlacePlayersInTrain();
				LevelManager.Instance.ClearNextLevel();
				LevelManager.Instance.sm.ForceState("Station");
			}
			SaveManager.Instance.JourneySaveBlocked = false;
			sm.ForceState("Play");
			IsJourneyStarted = true;
			LevelManager.Instance.Map.RefreshMap();
			yield return new WaitUntil(() => LevelManager.Instance.sm.CurrentState.Key == "Station" || LevelManager.Instance.sm.CurrentState.Key == "Playing");
			if (ZoneManager.Instance.CurrentZone.Definition.ZoneName == "Z3_Viaduct")
			{
				TrackManager.Instance.ShowParallaxBackground(show: true);
			}
			SimpleFade.Instance.IsFadeLocked = false;
			Train.Instance.HideTrainMap();
			foreach (PlayerController player in PlayerManager.Instance.Players)
			{
				player.interactor.RefreshInteractablesArray();
				player.interactor.WhitelistAllInteractables();
			}
			if (LevelManager.Instance.CurrentLevel.LevelType == LevelType.Hub)
			{
				UIManager.Instance.FadeScreen.ShowUIDelay(UIManager.Instance.WorldStartFadeTime);
			}
			else if (SaveManager.Instance.JourneySavedOnLevelStart)
			{
				UIManager.Instance.FadeScreen.ShowUIDelay(UIManager.Instance.LevelStartFadeTime);
			}
			else
			{
				UIManager.Instance.FadeScreen.ShowUIDelay(UIManager.Instance.LevelEndFadeTime);
			}
			LevelManager.Instance.ClearNextLevel();
		}
	}

	public void QuitRun()
	{
		this.RunQuit?.Invoke();
		SaveManager.Instance.ShouldSaveJourney = true;
		SaveManager.Instance.Save();
		DataTrackingManager.Instance.InitializeFromGameManager(this, atQuit: true);
		RestartGame();
	}

	public void RestartGame()
	{
		LeanTween.cancelAll();
		UpgradeManager.Instance.ResetAllUpgrades();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void StartNewGame()
	{
		PlayAgainHandler.Instance.playAgain = true;
		RestartGame();
	}

	public void QuitGame()
	{
		SaveManager.Instance.Save();
		if (IsJourneyStarted)
		{
			DataTrackingManager.Instance.SendData();
		}
		Application.Quit();
	}

	private void HandleJourneyStarted()
	{
		ResumeGame();
	}

	private void HandleMenuOpened(Menu menu)
	{
		PauseGame();
	}

	private void HandleMenuClosed(Menu menu)
	{
		if (MenuManager.Instance.CurrentMenu == null)
		{
			ResumeGame();
		}
	}

	public void PauseGame(MonoBehaviour pauseHolder = null)
	{
		if ((bool)pauseLockHolder && pauseHolder != pauseLockHolder)
		{
			Debug.LogWarning("Attempted to pause game while a different pause holder is active. Ignoring pause request.");
			return;
		}
		isPaused = true;
		pauseLockHolder = pauseHolder;
		Time.timeScale = 0f;
		Physics2D.simulationMode = SimulationMode2D.Script;
		Debug.Log("Game Paused");
	}

	public void ResumeGame(MonoBehaviour pauseHolder = null)
	{
		if ((bool)pauseLockHolder && pauseHolder != pauseLockHolder)
		{
			Debug.LogWarning("Attempted to resume game while a pause holder is active. Ignoring resume request.");
			return;
		}
		isPaused = false;
		pauseLockHolder = null;
		Time.timeScale = 1f;
		Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
		Debug.Log("Game Resumed");
	}

	public void UpdatePlayTime()
	{
		if (RunStarted && Application.isFocused)
		{
			playtimeInRun += Time.deltaTime;
		}
	}

	public void UpgradeMinigames()
	{
		RepairMinigame[] repairMinigames = RepairMinigames;
		for (int i = 0; i < repairMinigames.Length; i++)
		{
			repairMinigames[i].OnMinigameUpgrade();
		}
	}

	public void SetCurrentGameSpeed(float value)
	{
		CurrentGameSpeed = Mathf.Clamp(value, MinGameSpeed, TopGameSpeed);
	}

	private void OnApplicationQuit()
	{
		DataTrackingManager.Instance.InitializeFromGameManager(this, atQuit: true);
		QuitGame();
	}

	public void UnlockNextWorld()
	{
		if (UnlockedWorlds + 1 <= SupportedWorlds)
		{
			WorldMap.Instance.Zones[UnlockedWorlds].AddToNewUnlocks();
			UnlockedWorlds++;
		}
	}

	private void TrackDamageDone(HealthChangeInfo info)
	{
		if (info.source is Unit { IsEnemy: false } && info.Target.EnemyBase != null && info.Target.EnemyBase.IsEnemy && info.HealthChange < 0f)
		{
			TotalDamageInRun += Mathf.Abs(info.HealthChange);
		}
	}

	private void TrackHealingDone(HealthChangeInfo info)
	{
		if (info.Target != null && info.Target.EnemyBase == null && info.source != null && info.HealthChange > 0f)
		{
			TotalDamageRepairedInRun += info.HealthChange;
		}
	}

	private void TrackKills(EnemyBase enemy, Unit killer, HealthChangeInfo info)
	{
		if (killer != null && !killer.IsEnemy && enemy != null && enemy.IsEnemy)
		{
			TotalKillsInRun += 1f;
		}
	}

	private void CaptureScreen()
	{
		Texture2D texture2D = ScreenCapture.CaptureScreenshotAsTexture();
		if (!(texture2D == null))
		{
			texture2D.Apply();
			Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
			if (screenshotImg != null)
			{
				screenshotImg.sprite = sprite;
			}
			else
			{
				Debug.LogError("Screenshot UI Image reference is missing!");
			}
		}
	}

	public void CaptureEnemyWithBackground(GameObject targetObject, int xSize = 288, int ySize = 162)
	{
		StartCoroutine(CaptureEnemyCoroutine(targetObject, xSize, ySize));
	}

	private IEnumerator CaptureEnemyCoroutine(GameObject targetObject, int xSize = 288, int ySize = 162)
	{
		yield return new WaitForEndOfFrame();
		Vector3 vector = Camera.main.WorldToScreenPoint(targetObject.transform.position);
		int value = (int)vector.x - xSize / 2;
		int value2 = (int)vector.y - ySize / 2;
		value = Mathf.Clamp(value, 0, Screen.width - xSize);
		value2 = Mathf.Clamp(value2, 0, Screen.height - ySize);
		Texture2D texture2D = new Texture2D(xSize, ySize, TextureFormat.RGB24, mipChain: false);
		texture2D.ReadPixels(new Rect(value, value2, xSize, ySize), 0, 0);
		texture2D.Apply();
		Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
		killerSprite = sprite;
	}

	public void Save(SaveDataContext saveDataContext)
	{
		MetaSavefile metaSave = saveDataContext.MetaSave;
		metaSave.unlockedWorlds = UnlockedWorlds;
		metaSave.isOverfillStationConditionMet = isOverfillStationConditionMet;
	}

	public void Load(SaveDataContext saveDataContext, bool isNewJourney)
	{
		MetaSavefile metaSave = saveDataContext.MetaSave;
		UnlockedWorlds = metaSave.unlockedWorlds;
		isOverfillStationConditionMet = metaSave.isOverfillStationConditionMet;
	}
}
