using System;
using CloudOnce;
using SafeTypes;
using UnityEngine;

public class GameStates : MonoBehaviour
{
	public enum State
	{
		None = 0,
		QuickCheats = 1,
		LanguageSelectionScreen = 2,
		Logo = 3,
		StorageLoading = 4,
		CloudConnectionError = 5,
		StorageLoadingError = 6,
		StorageMergeDialog = 7,
		GameCenterError = 8,
		MainMenu = 9,
		Intro = 10,
		Soulstone = 11,
		OuroborosPaint = 12,
		StarStonePaint = 13,
		EpilogueCredits = 14,
		QuestScreen = 15,
		QuestOutroDialog = 16,
		SoulstoneQuestTransition = 17,
		StarstoneQuestTransition = 18,
		QuestStoneFTUETransition = 19,
		OuroborosPaintTransition = 20,
		StarStonePaintTransition = 21,
		OuroborosMainMenuTransition = 22,
		MoonstoneRestartTransition = 23,
		WorkstationScreen = 24,
		WorkstationOutroDialog = 25,
		ItemScreen = 26,
		CustomQuests = 27,
		SequentialPopupRewards = 28,
		ExitApp = 29,
		RestartProgressConfirmation = 30,
		LoadingStonescripts = 31,
		Playing = 32,
		SightstonePlayTransition = 33,
		SoulstonePlayTransition = 34,
		OuroborosPlayTransition = 35,
		PlayingOutroDialog = 36,
		HeadDroppingDeath = 37,
		PlayChoiceDialog = 38,
		PlayPaused = 39,
		PlayItemScreen = 40,
		PlayXpGained = 41,
		PlayAbilityActivated = 42,
		SightstoneCharacterDialog = 43,
		PlayMindStoneEdit = 44,
		PlaySettingsScreen = 45,
		Gate = 46,
		GateNoKeyDialog = 47,
		GateShopScreen = 48,
		GateShopReward = 49
	}

	private bool LOAD_AND_SAVE_PROGRESS = true;

	public AsciiRenderProcedural asciiRendererPrefab;

	public LogoLogic logoPrefab;

	private LogoLogic logo;

	public MainMenu mainMenuPrefab;

	private MainMenu mainMenu;

	public IntroScreen introPrefab;

	private IntroScreen intro;

	public SoulstoneScreen soulstoneScreenPrefab;

	private SoulstoneScreen soulstoneScreen;

	public OuroborosPaintScreen ouroborosPaintScreenPrefab;

	private OuroborosPaintScreen ouroborosPaintScreen;

	public StarStonePaintScreen starStonePaintScreenPrefab;

	private StarStonePaintScreen starStonePaintScreen;

	public AsciiAnimation sightstonePlayAnimationPrefab;

	private AsciiAnimation sightstonePlayAnimation;

	public AsciiAnimation magicPlayAnimationPrefab;

	private AsciiAnimation magicPlayAnimation;

	public AsciiAnimation soulstoneTransitionOverlayPrefab;

	private AsciiAnimation soulstoneTransitionOverlay;

	public CreditsScreen demoCreditsScreenPrefab;

	public CreditsScreen trailerCreditsPrefab;

	public MainNavigationBar navBarPrefab;

	public PlayItemNavigationBar playItemNavBarPrefab;

	public QuestScreen questScreenPrefab;

	public WorkstationScreen workstationScreenPrefab;

	public ItemScreen itemScreenPrefab;

	public CustomQuestsScreen customQuestsScreenPrefab;

	public CustomQuestsUi customQuestsUiPrefab;

	private CustomQuestsUi _customQuestsUi;

	public GateShopScreen gateShopScreenPrefab;

	public MoneyUI moneyPrefab;

	public Level levelPrefab;

	public string firstQuestId = "rocky_plateau";

	public Hero heroPrefab;

	public Hud hudPrefab;

	public AsciiAnimation headDroppingAnmPrefab;

	public AsciiAnimation bigHeadDroppingAnmPrefab;

	private AsciiAnimation normalHeadDroppingAnm;

	private AsciiAnimation bigHeadDroppingAnm;

	private AsciiAnimation headDroppingAnm;

	public QuestExitMessageDialog questExitDialogPrefab;

	private QuestExitMessageDialog questExitDialog;

	public PlayChoiceDialog playChoiceDialogPrefab;

	public DialogButton pauseButtonPrefab;

	private DialogButton pauseButton;

	public DialogButton resumeButtonPrefab;

	private DialogButton resumeButton;

	public DialogButton pauseOptionsButtonPrefab;

	private DialogButton pauseOptionsButton;

	public XpGainedDialog xpGainedDialogPrefab;

	private XpGainedDialog xpGainedDialog;

	public BannerSplash bannerSplashPrefab;

	private BannerSplash bannerSplash;

	public SightstoneCharacterDialog sightstoneCharacterDialogPrefab;

	private SightstoneCharacterDialog sightstoneCharacterDialog;

	public GateScreen gateScreenPrefab;

	private GateScreen gateScreen;

	public QuickCheats quickCheatsMenuPrefab;

	public TransitionManager transitionPrefab;

	private TransitionManager transition;

	public TwoChoiceDialog exitAppDialogPrefab;

	private TwoChoiceDialog exitAppDialog;

	public TwoChoiceDialog restartProgressDialogPrefab;

	private TwoChoiceDialog restartProgressDialog;

	public SettingsScreen settingsScreenPrefab;

	public SettingsScreen settingsScreenPrefabAndroid;

	public SettingsScreen settingsScreenPrefabiOS;

	public AbilityActivationHUD abilityActivationHUDPrefab;

	public RewardProgressCard rewardProgressCardPrefab;

	public WeeklyQuestProgressCard weeklyQuestProgressCardPrefab;

	private WeeklyQuestProgressCard weeklyQuestProgressCard;

	public AsciiSprite loadingSpinner;

	public TwoChoiceDialog cloudConnectionErrorDialog;

	public TwoChoiceDialog storageMergeDialog;

	public Action OnEndQuest;

	private State currentState;

	private HeroController[] heroControllers;

	[NonSerialized]
	public GateController gateController = new GateController();

	private State nextState;

	private IAsciiObject currentScreen;

	private IAsciiObject nextScreen;

	private bool playBanner;

	private SafeInt _totalLocationTime;

	private bool isLocationBegin;

	private bool isLocationLoop;

	private float accumulatedTicTime;

	private Data.Quest tempQuestData;

	private Data.Quest pendingQuestData;

	private bool isDrawingMouse = true;

	private AsciiRenderProcedural.Clip utilityBeltClip;

	private int lastGameCamPosX;

	private int lastGameCamPosY;

	private string lastQuestId;

	private bool savePending;

	private static string PREV_APP_VERSION_KEY = "app_prev_version";

	private static GameStates _instance;

	public AsciiRenderProcedural asciiRenderer { get; private set; }

	public AsciiParticleLayer gameParticleLayer { get; private set; }

	public AsciiParticleLayer uiParticleLayer { get; private set; }

	public CreditsScreen demoCreditsScreen { get; private set; }

	public MainNavigationBar navBar { get; private set; }

	public PlayItemNavigationBar playItemNavBar { get; private set; }

	public QuestScreen questScreen { get; private set; }

	public WorkstationScreen workstationScreen { get; private set; }

	public ItemScreen itemScreen { get; private set; }

	public CustomQuestsScreen customQuestsScreen { get; private set; }

	public CustomQuestsUi customQuestsUi
	{
		get
		{
			if (_customQuestsUi == null)
			{
				_customQuestsUi = UnityEngine.Object.Instantiate(customQuestsUiPrefab);
			}
			return _customQuestsUi;
		}
	}

	public GateShopScreen gateShopScreen { get; private set; }

	public MoneyUI money { get; private set; }

	public Level level { get; private set; }

	public Data.Quest parentQuest { get; private set; }

	public Hero hero { get; private set; }

	public Hud hud { get; private set; }

	public PlayChoiceDialog playChoiceDialog { get; private set; }

	public QuickCheats quickCheatsMenu { get; private set; }

	public SettingsScreen settingsScreen { get; private set; }

	public AbilityActivationHUD abilityActivationHUD { get; private set; }

	public RewardProgressCard rewardProgressCard { get; private set; }

	public bool userCanLeaveQuest { get; set; }

	public bool bannerEnabled { get; set; }

	public State CurrentState => currentState;

	public int stateElapsedTics { get; private set; }

	public State previousState { get; private set; }

	public SuperAbilityActivationState currentAbilityActivationState { get; private set; }

	public int totalLocationTime
	{
		get
		{
			return _totalLocationTime.GetValue();
		}
		set
		{
			_totalLocationTime = new SafeInt(value);
		}
	}

	public bool isTransitioning { get; private set; }

	public State postTransitionState { get; private set; }

	public bool xpDialogScheduled { get; private set; }

	public bool pauseScheduled { get; private set; }

	public static GameStates Singleton => _instance;

	public event Action OnInitializationComplete;

	public event Action<State, State> OnStateChanged;

	public static event Action<Data.Quest> OnQuestStarting;

	public int GetTotalTime()
	{
		return totalLocationTime + level.gameTime;
	}

	public bool IsPlaying()
	{
		if (currentState < State.Playing)
		{
			if (currentState == State.SequentialPopupRewards)
			{
				return previousState >= State.Playing;
			}
			return false;
		}
		return true;
	}

	private void ShowHorizontalScreen(AsciiObject screen)
	{
		navBar.SetScreen(screen);
	}

	public void SetState(State newState)
	{
		CrashReportController.singleton.AddBreadcrumb("stateChange(" + currentState.ToString() + "->" + newState.ToString() + ")");
		if (quickCheatsMenu != null)
		{
			quickCheatsMenu.gameObject.SetActive(newState == State.QuickCheats);
		}
		if (level != null)
		{
			level.gameObject.SetActive(newState >= State.Playing);
		}
		if (demoCreditsScreen != null)
		{
			demoCreditsScreen.gameObject.SetActive(newState == State.EpilogueCredits);
		}
		if (newState == State.MainMenu)
		{
			nextState = State.None;
			AnalyticsMacros.MainMenuInit();
			if (currentState < State.MainMenu && currentState != State.QuickCheats)
			{
				SaveFiles.singleton.Init();
				GameSave.SelectTopSaveFile();
			}
			InitMainMenu();
			InitEverythingElse();
		}
		else if (currentState < State.QuestScreen && newState >= State.QuestScreen)
		{
			InitNavBarAndMainScreens();
		}
		if (hero != null)
		{
			if (currentState >= State.Playing && newState < State.Playing)
			{
				hero.SetState(Hero.State.Idle);
				hero.CancelAttack();
			}
			hero.cinematicHideRightWeapon = newState == State.SightstonePlayTransition;
		}
		if (newState == State.PlayPaused || (newState == State.Playing && currentState == State.PlayPaused))
		{
			SfxController.singleton.Play("click");
		}
		AsciiAnimation.gameplayPaused = newState != State.Playing;
		switch (newState)
		{
		case State.EpilogueCredits:
			MusicController.singleton.FadeToSilence();
			MusicController.singleton.Play("credits");
			AnalyticsMacros.SawCredits();
			break;
		case State.QuestScreen:
		case State.QuestOutroDialog:
		case State.SoulstoneQuestTransition:
		case State.StarstoneQuestTransition:
		case State.QuestStoneFTUETransition:
		case State.OuroborosPaintTransition:
		case State.StarStonePaintTransition:
		case State.OuroborosMainMenuTransition:
		case State.WorkstationScreen:
		case State.WorkstationOutroDialog:
		case State.ItemScreen:
		case State.CustomQuests:
		case State.ExitApp:
		case State.LoadingStonescripts:
			if (!TryPlayEventThemeMusic())
			{
				MusicController.singleton.Play("main_menu");
			}
			break;
		default:
			if (currentState == State.GateShopScreen && newState != State.GateShopReward && newState != State.SequentialPopupRewards)
			{
				MusicController.singleton.ResumePreviousMusic();
			}
			break;
		}
		if (newState >= State.QuestScreen && newState < State.Playing)
		{
			TryToRefillPotion();
		}
		if (newState == State.QuestScreen || newState == State.CustomQuests)
		{
			hero.renderingEnabled = true;
			hero.Hidden = false;
			hero.canChangeEquipment = true;
			hero.GetComponent<DynamicActivatedAbilityProvider>().Clear();
			Hud.EnableAll();
			bannerEnabled = true;
			AbilityActivationHUD.activationFullDisable = false;
			UtilityBeltKeyShortcuts.singleton.inputEnabled = true;
			UtilityBeltKeyShortcuts.singleton.printEnabled = true;
			HeroAI.moveSpeedBuffsEnabled = true;
		}
		if (currentState == State.HeadDroppingDeath)
		{
			AsciiAnimation.allAnimationsEnabled = true;
		}
		if (currentState == State.MainMenu && GameSave.activeSaveFile != null && (newState == State.QuestScreen || newState == State.WorkstationScreen || newState == State.ItemScreen || newState == State.CustomQuests))
		{
			EventController.singleton.UnlockEpicQuestIfNeeded();
			GoalController.singleton.ProcessRewards();
			OfflineFarmController.singleton.ProcessRewards();
		}
		switch (newState)
		{
		case State.QuestScreen:
		case State.QuestOutroDialog:
		case State.SoulstoneQuestTransition:
		case State.StarstoneQuestTransition:
		case State.QuestStoneFTUETransition:
			gateShopScreen.Preload();
			if (newState == State.QuestStoneFTUETransition)
			{
				UpdateNavBarForProgressFlags();
			}
			ShowHorizontalScreen(questScreen);
			break;
		case State.OuroborosPaintTransition:
		case State.StarStonePaintTransition:
			ShowHorizontalScreen(questScreen);
			navBar.JumpScreen();
			break;
		case State.WorkstationScreen:
		case State.WorkstationOutroDialog:
			ShowHorizontalScreen(workstationScreen);
			break;
		case State.ItemScreen:
			ShowHorizontalScreen(itemScreen);
			break;
		case State.CustomQuests:
			ShowHorizontalScreen(customQuestsScreen);
			break;
		}
		switch (newState)
		{
		case State.LanguageSelectionScreen:
			LanguageSelectionScreen.singleton.canBack = false;
			LanguageSelectionScreen.singleton.Show();
			break;
		case State.Logo:
			AnalyticsMacros.LogoInit();
			logo.Reset();
			logo.enabled = true;
			break;
		case State.StorageLoading:
			SaveFiles.singleton.storage.Load();
			break;
		case State.CloudConnectionError:
		{
			string format = Te.xt("tid_ui_not_connected");
			string arg = "?";
			format = string.Format(format, arg);
			cloudConnectionErrorDialog.SetMessage(format);
			cloudConnectionErrorDialog.Show();
			nextState = State.MainMenu;
			break;
		}
		case State.StorageLoadingError:
		{
			string message2 = Te.xt("tid_ui_storage_load_error");
			cloudConnectionErrorDialog.SetMessage(message2);
			cloudConnectionErrorDialog.Show();
			nextState = State.MainMenu;
			break;
		}
		case State.StorageMergeDialog:
		{
			string message = Te.xt("tid_ui_storage_merge");
			storageMergeDialog.SetMessage(message);
			storageMergeDialog.Show();
			nextState = State.MainMenu;
			break;
		}
		case State.GameCenterError:
		{
			string message3 = Te.xt("tid_ui_game_center");
			storageMergeDialog.SetMessage(message3);
			storageMergeDialog.Show();
			nextState = State.MainMenu;
			break;
		}
		case State.MainMenu:
			level.QuestData = null;
			mainMenu.Activate();
			break;
		case State.Intro:
			intro.Activate();
			break;
		case State.OuroborosPaint:
			if (ouroborosPaintScreen == null)
			{
				ouroborosPaintScreen = UnityEngine.Object.Instantiate(ouroborosPaintScreenPrefab);
			}
			ouroborosPaintScreen.Activate();
			break;
		case State.StarStonePaint:
			if (starStonePaintScreen == null)
			{
				starStonePaintScreen = UnityEngine.Object.Instantiate(starStonePaintScreenPrefab);
			}
			starStonePaintScreen.Activate();
			break;
		case State.SoulstoneQuestTransition:
		case State.StarstoneQuestTransition:
		case State.QuestStoneFTUETransition:
		case State.OuroborosPaintTransition:
		case State.StarStonePaintTransition:
		case State.MoonstoneRestartTransition:
			soulstoneTransitionOverlay.Play();
			break;
		case State.OuroborosMainMenuTransition:
			soulstoneTransitionOverlay.Play();
			mainMenu.Activate(fadeIn: false);
			break;
		case State.EpilogueCredits:
			demoCreditsScreen.Activate();
			break;
		case State.QuestOutroDialog:
		case State.WorkstationOutroDialog:
		case State.GateNoKeyDialog:
			questExitDialog.Show();
			break;
		case State.HeadDroppingDeath:
			AsciiAnimation.allAnimationsEnabled = false;
			MusicController.singleton.FadeToSilence();
			hero.PauseAI(5f);
			hero.SetState(Hero.State.Idle);
			headDroppingAnm = (HeroSettings.bigHeadEnabled ? bigHeadDroppingAnm : normalHeadDroppingAnm);
			headDroppingAnm.gameObject.SetActive(value: true);
			headDroppingAnm.Stop();
			headDroppingAnm.Play();
			break;
		}
		switch (newState)
		{
		case State.SightstonePlayTransition:
			if (level.QuestData == null)
			{
				Data.Quest questById = QuestController.singleton.GetQuestById(firstQuestId);
				QuestController.singleton.MakeAvailable(questById);
				StartQuest(questById, playTransition: false);
				hero.PositionZ--;
			}
			sightstonePlayAnimation.Play();
			break;
		case State.SoulstonePlayTransition:
			magicPlayAnimation.Play();
			break;
		case State.OuroborosPlayTransition:
			if (OuroborosWeapon.questToReplay != null)
			{
				Utils.LogIfEditor("Ouroboros triggered");
				level.loops++;
				isLocationLoop = true;
				StartQuest(OuroborosWeapon.questToReplay, playTransition: false);
				playBanner = false;
				TryToRefillPotion();
			}
			magicPlayAnimation.Play();
			break;
		case State.Playing:
			asciiRenderer.defaultForegroundColor = ColorConstants.white;
			asciiRenderer.defaultBackgroundColor = ColorConstants.black;
			if (pendingQuestData != null)
			{
				bool flag = currentState == State.Playing;
				RemoteScriptImporter.singleton.ClearCache();
				MindStoneController singleton = MindStoneController.singleton;
				singleton.Activate();
				if (singleton.GameModel != null)
				{
					if (RemoteScriptImporter.singleton.IsBusy())
					{
						SetState(State.LoadingStonescripts);
						return;
					}
					if (isLocationLoop)
					{
						singleton.GameModel.SetLoopEvent();
					}
					else if (isLocationBegin)
					{
						singleton.ClearVariables();
						singleton.GameModel.SetStartEvent();
						DiagnosticsUI.singleton.ClearStonescriptErrors();
					}
				}
				isLocationBegin = false;
				isLocationLoop = false;
				Utils.LogIfEditor("Restoring things prior to starting level " + pendingQuestData.id + " start");
				level.QuestData = pendingQuestData;
				pendingQuestData = null;
				level.Reset(flag);
				hero.Hidden = false;
				hero.RestoreAI();
				gameParticleLayer.RecycleAllParticles();
				AsciiParticle.DestroyOld();
				MoneyUI.singleton.hideTopHUD = false;
				if (!flag)
				{
					AmbianceController.singleton.StopAllAmbient();
				}
				if (currentState < State.Playing)
				{
					SSUILayer.singleton.Clear();
					AbilityClock.ClearAll();
				}
			}
			abilityActivationHUD.UpdateContents();
			break;
		case State.PlayingOutroDialog:
		case State.PlayChoiceDialog:
		case State.PlayPaused:
			playChoiceDialog.Show();
			break;
		case State.PlayItemScreen:
			playItemNavBar.SetQuestData(level.QuestData);
			itemScreen.Activate();
			AchievementController.singleton.ReportEquipmentChanged();
			break;
		case State.PlayXpGained:
			xpGainedDialog.Show();
			break;
		case State.PlayAbilityActivated:
			currentAbilityActivationState.Activate();
			break;
		case State.SightstoneCharacterDialog:
			sightstoneCharacterDialog.Show();
			break;
		case State.PlayMindStoneEdit:
			MindStoneScreen.singleton.Show();
			break;
		case State.PlaySettingsScreen:
			settingsScreen.Show();
			break;
		case State.GateShopScreen:
			gateShopScreen.Activate();
			break;
		case State.SequentialPopupRewards:
			SequentialPopupManager.singleton.Activate();
			break;
		case State.ExitApp:
			exitAppDialog.Show();
			break;
		case State.RestartProgressConfirmation:
			restartProgressDialog.Show();
			break;
		}
		if (currentState == State.Logo)
		{
			AnalyticsMacros.TrackStartup();
		}
		loadingSpinner.enabled = newState == State.LoadingStonescripts || newState == State.StorageLoading;
		previousState = currentState;
		currentState = newState;
		stateElapsedTics = 0;
		if (this.OnStateChanged != null)
		{
			this.OnStateChanged(newState, previousState);
		}
	}

	private void Update()
	{
		Cursor.visible = currentState == State.QuickCheats;
		if (CurrentState == State.MainMenu && Input.GetKeyDown(KeyCode.C) && (Input.GetKey(KeyCode.LeftMeta) || Input.GetKey(KeyCode.LeftControl)))
		{
			GameplayActionMessages.SetMessage(" Game state copied to clipboard. ");
			GUIUtility.systemCopyBuffer = GameSave.CopyProgressData();
		}
		if (CurrentState == State.Playing)
		{
			UpdateHeroInput(Utils.deltaTime);
		}
		if (currentState == State.Playing && userCanLeaveQuest && ((Binding.singleton.IsDown(Binding.Action.Pause) && !IsThereNPCDialog()) || (Input.GetKeyDown(KeyCode.P) && IsThereNPCDialog())))
		{
			SchedulePause();
		}
		else if (currentState == State.Playing && userCanLeaveQuest && Binding.singleton.IsDown(Binding.Action.Inventory) && ProgressFlags.GetFlag("show_items"))
		{
			OpenPlayItemScreen();
		}
		else if ((currentState == State.Playing || currentState == State.PlayPaused) && userCanLeaveQuest && Binding.singleton.IsDown(Binding.Action.Mindstone) && QuestController.singleton.IsAvailable("automate"))
		{
			OpenPlayMindStoneScreen();
		}
		else if (currentState == State.PlayItemScreen && (Binding.singleton.IsDown(Binding.Action.Inventory) || (Input.GetKeyDown(KeyCode.Escape) && itemScreen.currentState == ItemScreen.State.Normal)))
		{
			HandlePlayItemBackPressed(null);
		}
		else if (CurrentState == State.PlayPaused && (Input.GetKeyDown(KeyCode.Escape) || Binding.singleton.IsDown(Binding.Action.Pause)))
		{
			DoResumePlay();
		}
		else if (currentState == State.GateShopScreen && gateShopScreen.currentState == GateShopScreen.State.Normal && Input.GetKeyDown(KeyCode.Escape))
		{
			HandlePlayItemBackPressed(null);
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if ((CurrentState == State.QuestScreen && !questScreen.IsShowingDifficultySubMenu()) || (CurrentState == State.WorkstationScreen && workstationScreen.currentState == WorkstationScreen.State.Normal) || (CurrentState == State.ItemScreen && itemScreen.currentState == ItemScreen.State.Normal) || (CurrentState == State.CustomQuests && !customQuestsScreen.IsShowingSubScreen()))
			{
				HandleMainMenuOptionsButtonPressed(null);
			}
			else if (CurrentState == State.ExitApp)
			{
				exitAppDialog.Hide();
			}
		}
		UpdateTics(Utils.deltaTime);
		GameplayActionMessages.Update();
		Draw();
	}

	private void UpdateTics(float deltaTime)
	{
		deltaTime *= 1f;
		accumulatedTicTime += deltaTime;
		accumulatedTicTime = Mathf.Clamp(accumulatedTicTime, 0f, 0.1f);
		while (accumulatedTicTime >= 0.03333333f)
		{
			accumulatedTicTime -= 0.03333333f;
			CrashReportController.singleton.ClearBreadcrumbs();
			try
			{
				UpdateTic();
			}
			catch (Exception ex)
			{
				ExceptionHandlingUI.Report(ex);
				Utils.LogError(ex.ToString());
			}
		}
	}

	private void UpdateTic()
	{
		stateElapsedTics++;
		UpdateParticleLayer();
		if (currentState != State.QuickCheats)
		{
			AsciiMouse.singleton.UpdateTic();
		}
		else
		{
			AsciiMouse.singleton.Clear();
		}
		if (isTransitioning)
		{
			UpdateTransition();
			if (isTransitioning)
			{
				return;
			}
		}
		if (playBanner && !isTransitioning && CurrentState != State.LoadingStonescripts)
		{
			playBanner = false;
			bannerSplash.Play();
		}
		AnimatedResourceFlyup.singleton.UpdateTic();
		if (CurrentState == State.LanguageSelectionScreen)
		{
			LanguageSelectionScreen.singleton.UpdateTic();
			if (LanguageSelectionScreen.singleton.IsDone())
			{
				SetState(State.Logo);
			}
		}
		else if (CurrentState == State.Logo)
		{
			logo.UpdateTic();
			if (QuickCheats.SkipAheadKeyPressed() || logo.IsDone())
			{
				if (!Features.HasExpired() && !Localization.singleton.IsBusy() && MainInstantiator.isLoadingComplete)
				{
					SetState(State.StorageLoading);
				}
			}
			else if (AsciiMouse.singleton.down0)
			{
				logo.Skip();
			}
		}
		else if (CurrentState == State.StorageLoading)
		{
			if (SaveFiles.singleton.storage.GetState() == AStorage.State.Success)
			{
				SetState(State.MainMenu);
			}
			else if (SaveFiles.singleton.storage.GetState() == AStorage.State.ConnectionError)
			{
				SetState(State.CloudConnectionError);
			}
			else if (SaveFiles.singleton.storage.GetState() == AStorage.State.LoadingError)
			{
				SetState(State.StorageLoadingError);
			}
			else if (SaveFiles.singleton.storage.GetState() == AStorage.State.StorageMerge)
			{
				SetState(State.StorageMergeDialog);
			}
		}
		else if (CurrentState == State.CloudConnectionError || CurrentState == State.StorageLoadingError)
		{
			cloudConnectionErrorDialog.UpdateTic();
			if (cloudConnectionErrorDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(nextState);
				nextState = State.None;
			}
			else if (CurrentState == State.CloudConnectionError && Cloud.IsSignedIn)
			{
				nextState = State.StorageLoading;
				cloudConnectionErrorDialog.Hide();
			}
		}
		else if (currentState == State.StorageMergeDialog || currentState == State.GameCenterError)
		{
			storageMergeDialog.UpdateTic();
			if (storageMergeDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(State.MainMenu);
			}
		}
		else if (CurrentState == State.MainMenu)
		{
			mainMenu.UpdateTic();
			if (mainMenu.currentState == MainMenu.State.Done && ItemFactory.singleton.HasLoadedAllPrefabs())
			{
				if (GameSave.selectedSaveFile == GameSave.activeSaveFile)
				{
					Utils.Log("Continuing game");
					if (nextState != State.None)
					{
						TransitionToState(nextState);
						nextState = State.None;
					}
					else if (previousState == State.WorkstationScreen || previousState == State.ItemScreen || previousState == State.CustomQuests)
					{
						TransitionToState(previousState);
					}
					else
					{
						TransitionToState(State.QuestScreen);
					}
				}
				else if (GameSave.selectedSaveFile.IsNew())
				{
					Utils.Log("Starting new game");
					InitNavBarAndMainScreens();
					level.QuestData = null;
					QuestRow.questInProgress = null;
					SaveFiles.singleton.ClearActiveMemory();
					GameSave.activeSaveFile = null;
					UpdateNavBarForProgressFlags();
					navBar.Reset();
					SetState(State.Intro);
				}
				else
				{
					Utils.Log("Loading save: " + GameSave.selectedSaveFile.progressData);
					QuestRow.questInProgress = null;
					SaveFiles.singleton.LoadSaveFile(GameSave.selectedSaveFile);
					GameSave.activeSaveFile = GameSave.selectedSaveFile;
					EventController.singleton.UnlockEpicQuestIfNeeded();
					GoalController.singleton.ProcessRewards();
					OfflineFarmController.singleton.ProcessRewards();
					UpdateNavBarForProgressFlags();
					if (CustomQuestsController.Singleton.ftueStep == CustomQuestsController.FTUEStep.UnlockBasicQuests && CustomQuestsController.Singleton.HasQueststoneUnlocked)
					{
						navBar.SetScreen(questScreen);
						soulstoneScreen.Setup(SoulstoneScreen.Type.QuestStone);
						currentState = State.Soulstone;
						nextState = State.QuestStoneFTUETransition;
						MusicController.singleton.FadeToSilence();
					}
					else if (nextState != State.None)
					{
						SetState(nextState);
						nextState = State.None;
					}
					navBar.JumpSelector();
					navBar.JumpScreen();
					isTransitioning = true;
					transition.FadeIn();
				}
			}
		}
		else if (CurrentState == State.Intro)
		{
			intro.UpdateTic();
			if (intro.CurrentState == IntroScreen.State.Done)
			{
				SetState(State.SightstonePlayTransition);
			}
		}
		else if (CurrentState == State.Soulstone)
		{
			soulstoneScreen.UpdateTic();
			if (soulstoneScreen.currentState == SoulstoneScreen.State.Done)
			{
				if (soulstoneScreen.currentType == SoulstoneScreen.Type.MoonStone)
				{
					TransitionToState(nextState, TransitionManager.Type.WhiteToBlack);
				}
				else
				{
					SetState(nextState);
				}
				nextState = State.None;
			}
		}
		else if (CurrentState == State.OuroborosPaint)
		{
			ouroborosPaintScreen.UpdateTic();
			if (ouroborosPaintScreen.currentState == UpgradeRelicScreen.State.Done)
			{
				SetState(State.OuroborosPaintTransition);
			}
		}
		else if (CurrentState == State.StarStonePaint)
		{
			starStonePaintScreen.UpdateTic();
			if (starStonePaintScreen.currentState == UpgradeRelicScreen.State.Done)
			{
				SetState(State.StarStonePaintTransition);
			}
		}
		else if (CurrentState == State.EpilogueCredits)
		{
			demoCreditsScreen.UpdateTic();
			if (demoCreditsScreen.isDone)
			{
				TransitionToState(State.Playing);
			}
		}
		else if (CurrentState == State.QuestScreen)
		{
			navBar.UpdateTic();
			QuestController singleton = QuestController.singleton;
			if (singleton.pendingIncreaseStarForQuestId != null && stateElapsedTics == 15)
			{
				IncreaseStarDifficultyForQuestNow(singleton.pendingIncreaseStarDifficultyForQuest, singleton.pendingIncreaseStarForQuestId);
				singleton.pendingIncreaseStarForQuestId = null;
			}
			if (questScreen.IsCurrentStateIdle())
			{
				CheckSequentialPopupManager();
			}
		}
		else if (CurrentState == State.WorkstationScreen || CurrentState == State.ItemScreen || CurrentState == State.CustomQuests)
		{
			navBar.UpdateTic();
			if ((CurrentState == State.WorkstationScreen && workstationScreen.currentState == WorkstationScreen.State.Normal) || (CurrentState == State.ItemScreen && itemScreen.currentState == ItemScreen.State.Normal) || (CurrentState == State.CustomQuests && customQuestsScreen.ShouldCheckSequentialPopupManager()))
			{
				CheckSequentialPopupManager();
			}
		}
		else if (CurrentState == State.SoulstoneQuestTransition && stateElapsedTics == 20)
		{
			currentState = State.QuestScreen;
			stateElapsedTics = 0;
		}
		else if (CurrentState == State.StarstoneQuestTransition)
		{
			if (stateElapsedTics == 20)
			{
				IncreaseStarDifficultyForQuestNow(1, "caustic_caves");
			}
			else if (stateElapsedTics == 35 && ProgressFlags.GetFlag("got_treasure_ranting_tree"))
			{
				IncreaseStarDifficultyForQuestNow(1, "deadwood_valley");
			}
			else if (stateElapsedTics == 50)
			{
				if (ProgressFlags.GetFlag("got_metal_2_from_boulder"))
				{
					IncreaseStarDifficultyForQuestNow(1, "rocky_plateau");
				}
				currentState = State.QuestScreen;
				stateElapsedTics = 0;
			}
		}
		else if (CurrentState == State.QuestStoneFTUETransition && stateElapsedTics == 20)
		{
			currentState = State.QuestScreen;
			stateElapsedTics = 0;
			SetState(State.CustomQuests);
		}
		else if (CurrentState == State.OuroborosPaintTransition)
		{
			navBar.UpdateTic();
			if (stateElapsedTics >= 20)
			{
				currentState = State.QuestScreen;
				stateElapsedTics = 0;
				if (level.QuestData != null && QuestController.singleton.GetStarDifficultyForQuest(level.QuestData.id) >= 3)
				{
					questScreen.ShowDifficultySubMenu(level.QuestData);
				}
			}
		}
		else if (CurrentState == State.StarStonePaintTransition)
		{
			navBar.UpdateTic();
			if (stateElapsedTics == 20 && QuestController.singleton.HasAspiringStarDifficulties())
			{
				int difficulty = (StarStoneWeapon.singleton.level - 1) * 5 + 1;
				string questId = QuestController.singleton.AspiringStarDifficultyIds[0];
				IncreaseStarDifficultyForQuestNow(difficulty, questId);
				QuestController.singleton.RemoveAspiringStarDifficulty(questId);
				if (QuestController.singleton.HasAspiringStarDifficulties())
				{
					stateElapsedTics -= 15;
				}
			}
			if (stateElapsedTics >= 50)
			{
				currentState = State.QuestScreen;
				stateElapsedTics = 0;
			}
		}
		else if (CurrentState == State.OuroborosMainMenuTransition)
		{
			mainMenu.UpdateTic();
			if (stateElapsedTics >= 20)
			{
				currentState = State.MainMenu;
				stateElapsedTics = 0;
			}
		}
		else if (CurrentState == State.MoonstoneRestartTransition && stateElapsedTics == 40)
		{
			SetState(State.QuestScreen);
			for (int i = 0; i < 40; i++)
			{
				UpdateTic();
			}
			SetState(State.Intro);
			UpdateNavBarForProgressFlags();
			navBar.JumpSelector();
		}
		else if (CurrentState == State.SightstonePlayTransition)
		{
			if (!sightstonePlayAnimation.Playing)
			{
				SetState(State.Playing);
			}
			else if (stateElapsedTics == 25)
			{
				MusicController.singleton.Play("rocky_plateau_0");
			}
		}
		else if (CurrentState == State.SoulstonePlayTransition || CurrentState == State.OuroborosPlayTransition)
		{
			if (!magicPlayAnimation.Playing)
			{
				SetState(State.Playing);
				AchievementController.singleton.ReportOuroborosTriggered(OuroborosWeapon.questToReplay);
			}
		}
		else if (CurrentState == State.LoadingStonescripts)
		{
			if (!RemoteScriptImporter.singleton.IsBusy())
			{
				SetState(State.Playing);
			}
		}
		else if (CurrentState == State.Playing)
		{
			level.UpdateTic();
			if (isTransitioning || CurrentState != State.Playing)
			{
				return;
			}
			if ((level.LevelComplete || xpDialogScheduled) && level.XpEarned > 0 && XPController.singleton.HasXpStone() && !XPController.singleton.isMaxLevel)
			{
				xpDialogScheduled = false;
				int xpEarned = level.XpEarned;
				level.XpEarned = 0;
				xpGainedDialog.Setup_Pre();
				xpEarned = XPController.singleton.AddXP(xpEarned);
				xpGainedDialog.Setup_Post(xpEarned);
				SetState(State.PlayXpGained);
			}
			else if (pauseScheduled && userCanLeaveQuest)
			{
				pauseScheduled = false;
				if (ProgressFlags.GetFlag("show_items"))
				{
					Pause();
				}
				else
				{
					CompleteQuest();
				}
				AchievementController.singleton.ReportLocationPausedManually();
			}
			else if (level.LevelComplete && hero.CurrentState == Hero.State.Idle)
			{
				Data.Quest quest = ((parentQuest != null) ? parentQuest : level.QuestData);
				bool flag = quest.outro != null && !QuestController.singleton.HasCompleted(quest);
				bool num = level.LevelComplete && OuroborosWeapon.IsEnabled() && !flag && previousState != State.OuroborosPlayTransition;
				int num2 = MaxStarDifficulty();
				int aspiringStarDifficulty = QuestController.singleton.GetAspiringStarDifficulty(quest.id);
				bool flag2 = quest.level < num2 && quest.level == QuestController.singleton.GetStarDifficultyForQuest(quest.id);
				flag2 |= quest.level == num2 && aspiringStarDifficulty <= quest.level;
				if (num && quest.level >= 3 && !flag2)
				{
					if (quest.level <= 10)
					{
						hero.Cleanse();
					}
					CompleteQuest();
					OuroborosWeapon.questToReplay = quest;
					ShowSoulstoneScreen(SoulstoneScreen.Type.OuroborosStone, State.OuroborosPlayTransition);
				}
				else if (ProgressFlags.GetFlag("show_items"))
				{
					ShowCompletionBanner(quest);
					Pause();
				}
				else
				{
					CompleteQuest();
				}
			}
			else
			{
				for (int j = 0; j < heroControllers.Length; j++)
				{
					if (heroControllers[j].enabled)
					{
						heroControllers[j].UpdateTic();
					}
				}
				hero.UpdateTic();
				level.LateUpdateTic();
				MindStoneController.singleton.UpdateTic();
				SSUILayer.singleton.UpdateTic();
				CheckSequentialPopupManager();
				if (ShouldDrawPauseButton() && Hud.IsEnabled(Hud.Flag.PAUSE))
				{
					pauseButton.UpdateTic();
				}
				abilityActivationHUD.UpdateTic();
				UtilityBeltUI.singleton.UpdateTic();
			}
		}
		else if (CurrentState == State.QuestOutroDialog || CurrentState == State.WorkstationOutroDialog)
		{
			questExitDialog.UpdateTic();
			if (questExitDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				CompleteQuest(questExitDialog.QuestData);
			}
		}
		else if (CurrentState == State.HeadDroppingDeath)
		{
			if (stateElapsedTics >= 175)
			{
				Utils.Log("Died");
				HeadStones.AddAt(level.QuestData.id, level.QuestData.level, hero.PositionX, hero.PositionZ);
				EndQuest();
			}
			else
			{
				headDroppingAnm.UpdateWithDeltaTime(0.03333333f);
			}
		}
		else if (CurrentState == State.PlayChoiceDialog || CurrentState == State.PlayingOutroDialog || CurrentState == State.PlayPaused)
		{
			playChoiceDialog.UpdateTic();
			if (ShouldDrawResumeButton())
			{
				resumeButton.UpdateTic();
				pauseOptionsButton.UpdateTic();
				if (CurrentState == State.PlayPaused)
				{
					UtilityBeltUI.singleton.UpdateTic();
				}
			}
		}
		else if (CurrentState == State.PlayItemScreen)
		{
			playItemNavBar.UpdateTic();
			itemScreen.UpdateTic();
		}
		else if (CurrentState == State.PlayXpGained)
		{
			xpGainedDialog.UpdateTic();
			if (xpGainedDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(State.Playing);
			}
		}
		else if (CurrentState == State.PlayAbilityActivated)
		{
			currentAbilityActivationState.UpdateTic();
			if (currentAbilityActivationState.IsDone())
			{
				currentAbilityActivationState = null;
				SetState(State.Playing);
			}
			else if (currentAbilityActivationState.runGameClock)
			{
				level.gameTime++;
			}
		}
		else if (CurrentState == State.SightstoneCharacterDialog)
		{
			sightstoneCharacterDialog.UpdateTic();
			if (sightstoneCharacterDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(State.Playing);
			}
		}
		else if (CurrentState == State.PlayMindStoneEdit)
		{
			MindStoneScreen.singleton.UpdateTic();
			if (MindStoneScreen.singleton.currentState == PopUpModalScreen.State.Disabled)
			{
				MindStoneController.singleton.Activate();
				SetState(State.Playing);
			}
		}
		else if (CurrentState == State.Gate)
		{
			gateScreen.UpdateTic();
		}
		else if (CurrentState == State.GateNoKeyDialog)
		{
			questExitDialog.UpdateTic();
			if (questExitDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				AmbianceController.singleton.StopAllAmbient();
				TransitionToState(State.QuestScreen);
			}
		}
		else if (CurrentState == State.GateShopScreen || currentState == State.GateShopReward)
		{
			if (CurrentState == State.GateShopScreen && gateShopScreen.currentState == GateShopScreen.State.Normal)
			{
				playItemNavBar.UpdateTic();
			}
			gateShopScreen.UpdateTic();
			if (currentState == State.GateShopReward && gateShopScreen.shopKeeper.currentState == ShopKeeper.State.DoneReward)
			{
				TransitionToState(State.QuestScreen);
			}
			CheckSequentialPopupManager();
		}
		else if (CurrentState == State.PlaySettingsScreen)
		{
			settingsScreen.UpdateTic();
			if (settingsScreen.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(previousState);
			}
		}
		else if (CurrentState == State.SequentialPopupRewards)
		{
			SequentialPopupManager.singleton.UpdateTic();
			if (SequentialPopupManager.singleton.currentState == SequentialPopupManager.State.Disabled)
			{
				SetState(previousState);
			}
		}
		else if (CurrentState == State.ExitApp)
		{
			exitAppDialog.UpdateTic();
			if (exitAppDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(previousState);
			}
		}
		else if (CurrentState == State.RestartProgressConfirmation)
		{
			restartProgressDialog.UpdateTic();
			if (restartProgressDialog.CurrentState == DialogNineSlice.State.Disabled)
			{
				SetState(previousState);
			}
		}
		if (rewardProgressCard != null)
		{
			rewardProgressCard.UpdateTic();
		}
		if (weeklyQuestProgressCard != null)
		{
			weeklyQuestProgressCard.UpdateTic();
		}
		if (bannerSplash != null)
		{
			bannerSplash.UpdateTic();
		}
		if ((bool)_customQuestsUi)
		{
			_customQuestsUi.UpdateTic();
			CustomQuestsController.Singleton.UpdateTic();
		}
	}

	private void CheckSequentialPopupManager()
	{
		if ((currentState != State.Playing || !(UulaaShopScreen.singleton != null) || UulaaShopScreen.singleton.currentState != UulaaShopScreen.State.OpeningTreasures || !(level.QuestData.id == "uulaa_shop")) && SequentialPopupManager.singleton.IsPending())
		{
			SetState(State.SequentialPopupRewards);
		}
	}

	private void UpdateTransition()
	{
		transition.UpdateTic();
		if (transition.CurrentTransition == null && !LoadingAccountant.IsBusy())
		{
			isTransitioning = false;
			if (postTransitionState != State.None)
			{
				UpdateSave();
				SetState(postTransitionState);
				postTransitionState = State.None;
			}
		}
		else if (transition.CurrentTransition.CurrentState == Transition.State.Blank && transition.CurrentTransition.stateElapsedTics > 2 && !LoadingAccountant.IsBusy())
		{
			if (postTransitionState != State.None)
			{
				UpdateSave();
				SetState(postTransitionState);
				postTransitionState = State.None;
			}
			transition.FadeIn();
		}
		else if (transition.CurrentTransition.CurrentState == Transition.State.Disabled)
		{
			isTransitioning = false;
		}
		if ((bool)_customQuestsUi)
		{
			_customQuestsUi.UpdateTic();
		}
	}

	public void TransitionToState(State newState, TransitionManager.Type transitionType = TransitionManager.Type.Fade)
	{
		isTransitioning = true;
		postTransitionState = newState;
		transition.FadeOut(transitionType);
		if (((newState != State.MainMenu && newState != State.QuestScreen && newState != State.WorkstationScreen && newState != State.ItemScreen && newState != State.CustomQuests) || !TryPlayEventThemeMusic()) && newState != currentState && newState != State.GateShopScreen && currentState != State.Intro && currentState != State.SequentialPopupRewards)
		{
			MusicController.singleton.FadeToSilence();
		}
	}

	public void LeaveQuest()
	{
		Utils.Log("Leave Quest");
		Data.Quest quest = ((parentQuest != null) ? parentQuest : level.QuestData);
		EndQuest(quest);
		level.Leave();
	}

	public void CompleteQuest(bool stopAudio = true)
	{
		Utils.LogIfEditor("Complete Quest");
		Data.Quest quest = ((parentQuest != null) ? parentQuest : level.QuestData);
		CompleteQuest(quest, stopAudio);
	}

	private void CompleteQuest(Data.Quest quest, bool stopAudio = true)
	{
		State state = State.None;
		AnalyticsMacros.QuestCompleted(quest.id, quest.level, 0, 0, 0);
		if (quest.outro != null && currentState != State.PlayingOutroDialog && currentState != State.QuestOutroDialog && currentState != State.WorkstationOutroDialog && !QuestController.singleton.HasCompleted(quest))
		{
			if (currentState == State.Playing || currentState == State.PlayPaused)
			{
				SetupOutroDialogForQuest(quest);
				state = State.PlayingOutroDialog;
			}
			else if (navBar.activeScreen == questScreen)
			{
				SetupOutroWindowForQuest(quest);
				state = State.QuestOutroDialog;
			}
			else
			{
				SetupOutroWindowForQuest(quest);
				state = State.WorkstationOutroDialog;
			}
		}
		if (state != State.None)
		{
			SetState(state);
			return;
		}
		bool flag = !QuestController.singleton.HasCompleted(quest);
		if (flag || !quest.oneShot)
		{
			QuestController.singleton.ProcessOnComplete(quest);
			QuestController.singleton.GrantRewards(quest);
			int totalTime = GetTotalTime();
			WeeklyQuestsController.singleton.SetupPreviousAverageTime(quest.id, quest.level);
			OfflineFarmController.singleton.ReportQuestCompletionTime(quest.id, quest.level, totalTime);
			WeeklyQuestsController.singleton.ReportQuestCompletionTime(quest.id, quest.level, totalTime);
			SubmitLeaderboardStats(quest);
		}
		QuestController.singleton.FireOnComplete(quest, flag);
		if (quest.oneShot)
		{
			QuestController.singleton.MakeUnavailable(quest);
		}
		else if (quest.level == QuestController.singleton.GetStarDifficultyForQuest(quest.id))
		{
			ScheduleIncreaseStarForQuest(quest.id);
		}
		EndQuest(quest, stopAudio);
		level.Complete();
		QuestExceptions.AfterQuestCompleted(quest);
	}

	public void SubmitLeaderboardStats(Data.Quest quest)
	{
		Utils.LogIfEditor("SubmitLeaderboardStats: quest: " + quest);
		if (quest.level <= 0 || quest.level % 5 != 0)
		{
			return;
		}
		string leaderboardId = quest.id + "_" + quest.level;
		if (LeaderboardController.singleton.HasSubmitted())
		{
			Data.QuestStats statsForQuest = OfflineFarmController.singleton.GetStatsForQuest(quest.id, quest.level);
			Utils.LogIfEditor("SubmitLeaderboardStats: stats: " + statsForQuest);
			if (statsForQuest != null)
			{
				int bestTime = statsForQuest.bestTime;
				LeaderboardController.singleton.SubmitLocationScore(leaderboardId, bestTime);
			}
		}
	}

	public void EndQuest(bool stopAudio = true)
	{
		Utils.LogIfEditor("End Quest");
		Data.Quest quest = ((parentQuest != null) ? parentQuest : level.QuestData);
		hero.Cleanse();
		EndQuest(quest, stopAudio);
	}

	private void EndQuest(Data.Quest quest, bool stopAudio = true)
	{
		Utils.LogIfEditor("End Quest (Data.Quest)");
		parentQuest = null;
		OnEndQuest?.Invoke();
		ShowMouse();
		if (stopAudio)
		{
			AmbianceController.singleton.StopAllAmbient();
			SfxController.singleton.StopAllSfx();
		}
		State state = ((quest.id == "build_workstation") ? State.WorkstationScreen : ((quest.id == "prospect_cliff") ? State.ItemScreen : ((navBar.activeScreen == workstationScreen) ? State.WorkstationScreen : ((navBar.activeScreen == itemScreen) ? State.ItemScreen : ((!(navBar.activeScreen == customQuestsScreen)) ? State.QuestScreen : State.CustomQuests)))));
		if (currentState == State.Playing || currentState == State.PlayingOutroDialog || currentState == State.HeadDroppingDeath || currentState == State.PlayPaused || currentState == State.SequentialPopupRewards || currentState == State.PlayChoiceDialog)
		{
			savePending = true;
			TransitionToState(state);
		}
		else
		{
			SetState(state);
		}
	}

	private void SetupOutroDialogForQuest(Data.Quest quest)
	{
		playChoiceDialog.SetupText(quest.outro.line1, quest.outro.buttonLabel, KeyCode.Return);
		playChoiceDialog.buttonSingle.OnPressed += OnOutroDialogPressed;
		tempQuestData = quest;
	}

	private void OnOutroDialogPressed(DialogButton btn)
	{
		Utils.Log("Button Pressed");
		btn.OnPressed -= OnOutroDialogPressed;
		CompleteQuest(tempQuestData);
		tempQuestData = null;
	}

	private void SetupOutroWindowForQuest(Data.Quest quest)
	{
		questExitDialog.QuestData = quest;
		questExitDialog.SetString(quest.outro.line1, quest.outro.buttonLabel);
	}

	private void ScheduleIncreaseStarForQuest(string questId)
	{
		if (!Inventory.Singleton.HasItemById("star_stone"))
		{
			return;
		}
		int num = QuestController.singleton.GetStarDifficultyForQuest(questId) + 1;
		if (num > MaxStarDifficulty() || !QuestController.singleton.HasQuestByIdAndDifficulty(questId, num))
		{
			if (num > 5)
			{
				QuestController.singleton.SetAspiringStarDifficulty(questId, num);
			}
			return;
		}
		QuestController.singleton.RemoveAspiringStarDifficulty(questId);
		if (currentState == State.QuestScreen || currentState == State.SoulstoneQuestTransition || currentState == State.StarstoneQuestTransition || currentState == State.StarStonePaintTransition)
		{
			IncreaseStarDifficultyForQuestNow(num, questId);
			return;
		}
		QuestController singleton = QuestController.singleton;
		if (singleton.pendingIncreaseStarForQuestId != null)
		{
			IncreaseStarDifficultyForQuestNow(singleton.pendingIncreaseStarDifficultyForQuest, singleton.pendingIncreaseStarForQuestId);
		}
		singleton.pendingIncreaseStarForQuestId = questId;
		singleton.pendingIncreaseStarDifficultyForQuest = num;
	}

	private int MaxStarDifficulty()
	{
		int result = 5;
		if (StarStoneWeapon.singleton != null)
		{
			result = StarStoneWeapon.singleton.level * 5;
		}
		return result;
	}

	private void IncreaseStarDifficultyForQuestNow(int difficulty, string questId)
	{
		QuestController.singleton.SetStarDifficultyForQuest(difficulty, questId);
		for (int i = 0; i < questScreen.rows.Count; i++)
		{
			QuestRow questRow = questScreen.rows[i] as QuestRow;
			if (questRow.QuestData.id == questId)
			{
				questRow.SetStarDifficulty(difficulty, animated: true);
				break;
			}
		}
	}

	public void UpdateNavBarForProgressFlags()
	{
		navBar.SetIndexEnabled(1, ProgressFlags.GetFlag("show_workstation"));
		navBar.SetIndexEnabled(2, ProgressFlags.GetFlag("show_items"));
		navBar.SetIndexEnabled(3, CustomQuestsController.Singleton.HasQueststoneUnlocked);
	}

	private void HandleNavBarChanged(int newIndex, AsciiObject screenObject)
	{
		if (screenObject == questScreen && currentState != State.QuestScreen)
		{
			SetState(State.QuestScreen);
		}
		else if (screenObject == workstationScreen && currentState != State.WorkstationScreen)
		{
			SetState(State.WorkstationScreen);
		}
		else if (screenObject == itemScreen && currentState != State.ItemScreen)
		{
			SetState(State.ItemScreen);
		}
		else if (screenObject == customQuestsScreen && currentState != State.CustomQuests)
		{
			SetState(State.CustomQuests);
		}
	}

	private void HandleMainMenuOptionsButtonPressed(DialogButton btn)
	{
		if (CurrentState == State.ItemScreen)
		{
			SetState(State.QuestScreen);
			return;
		}
		TryToSaveProgress();
		TransitionToState(State.MainMenu);
	}

	private void HandleOfflineFarmSelected(Data.Quest questData, int difficulty)
	{
		TryToSaveProgress();
		HideMouse();
		soulstoneScreen.isOfflineFarmTransition = true;
		ShowSoulstoneScreen(SoulstoneScreen.Type.OuroborosStone, State.OuroborosMainMenuTransition);
	}

	private void HandleCustomQuestCompleted(Data.CustomQuestInstance questInstance)
	{
		TryToSaveProgress();
	}

	private void HandlePlayItemBackPressed(DialogButton button)
	{
		if (CurrentState == State.GateShopScreen)
		{
			TryToSaveProgress();
			if (gateShopScreen.IsRewardPending())
			{
				if (level.QuestData != null && level.QuestData.level == 1 && level.QuestData.id == "fungus_forest")
				{
					CompleteQuest();
				}
				gateShopScreen.ShowReward();
				SetState(State.GateShopReward);
			}
			else if (previousState == State.Playing)
			{
				CompleteQuest();
			}
			else
			{
				TransitionToState(State.QuestScreen);
			}
		}
		else
		{
			if (level.QuestData.restoreAIonInventoryBack)
			{
				hero.RestoreAI();
			}
			level.LevelComplete = false;
			AsciiMouse.singleton.Hide();
			SetState(State.Playing);
		}
	}

	private void HandleOnQuestTimerCompleted(Data.Quest quest)
	{
		CompleteQuest(quest, stopAudio: false);
	}

	private void HandleOnCharacterGoingToTakeDamage(Character character, Damage dmg)
	{
		if (character == hero)
		{
			int num = hero.Hitpoints;
			if (!dmg.tags.Contains("pure"))
			{
				num += Mathf.CeilToInt(hero.Armor);
			}
			if (dmg.amount >= num && level.QuestData != null)
			{
				dmg.amount = 0;
				level.XpEarned = 0;
				AnalyticsMacros.Died(level.QuestData.id, level.QuestData.level, dmg.Owner ? dmg.Owner.id : "unknown");
				SetState(State.HeadDroppingDeath);
			}
		}
	}

	private void HandleOnQuestSelected(Data.Quest questData)
	{
		Utils.Log("Selected: " + questData.id + " Lv" + questData.level);
		if (questData.id == "mushroom_shop")
		{
			questData = CustomQuestsController.Singleton.HandlePreLoc(questData);
			if (questData.id != "mushroom_shop")
			{
				HandleOnQuestSelected(questData);
				return;
			}
			QuestController.singleton.MarkAsPlayed(questData.id);
			AnalyticsMacros.ShopOpened();
			ShowShop("mushroom_shop");
			return;
		}
		if (questData.id == "upgrade_ouroboros")
		{
			TransitionToState(State.OuroborosPaint);
			return;
		}
		if (questData.id == "upgrade_star_stone")
		{
			TransitionToState(State.StarStonePaint);
			return;
		}
		hero.ReplenishHitpoints();
		hero.Cleanse();
		hero.ResetTicsToMove();
		hero.Hidden = false;
		AsciiMouse.singleton.Hide();
		xpDialogScheduled = false;
		pauseScheduled = false;
		parentQuest = null;
		isLocationBegin = true;
		level.loops = 0;
		StartQuest(questData);
		AchievementController.singleton.ReportLocationStartedManually(questData);
	}

	public void SubQuest(Data.Quest questData, bool playTransition = true)
	{
		Utils.LogIfEditor("Sub-Quest: " + questData.id + ", parentQuest: " + level.QuestData.id);
		int gameTime = level.gameTime;
		parentQuest = level.QuestData;
		StartQuest(questData, playTransition);
		totalLocationTime += gameTime;
	}

	public void StartQuest(Data.Quest questData, bool playTransition = true, bool hardReset = false)
	{
		if (hardReset)
		{
			hero.ReplenishHitpoints();
			hero.Cleanse();
			hero.ResetTicsToMove();
			hero.Hidden = false;
			AsciiMouse.singleton.Hide();
			xpDialogScheduled = false;
			pauseScheduled = false;
			parentQuest = null;
			isLocationBegin = true;
		}
		questData = CustomQuestsController.Singleton.HandlePreLoc(questData);
		totalLocationTime = 0;
		if (questData.level <= 0)
		{
			int starDifficultyForQuest = QuestController.singleton.GetStarDifficultyForQuest(questData.id);
			if (starDifficultyForQuest > 0)
			{
				Data.Quest questByIdAndDifficulty = QuestController.singleton.GetQuestByIdAndDifficulty(questData.id, starDifficultyForQuest);
				if (questByIdAndDifficulty != null)
				{
					questData = questByIdAndDifficulty;
				}
			}
		}
		PreloadAsyncAssets(questData);
		QuestController.singleton.ProcessOnPlay(questData);
		QuestExceptions.HandleQuestStarting(questData);
		if (questData.timeProgress != null)
		{
			return;
		}
		userCanLeaveQuest = true;
		if (questData.isGate)
		{
			GateData orLoadGate = gateController.GetOrLoadGate(questData.id);
			if (orLoadGate != null)
			{
				gateScreen.gateData = orLoadGate;
				if (playTransition)
				{
					TransitionToState(State.Gate);
				}
				else
				{
					SetState(State.Gate);
				}
			}
			return;
		}
		FireQuestStarting(questData);
		pendingQuestData = questData;
		if (playTransition)
		{
			TransitionToState(State.Playing);
		}
		else
		{
			SetState(State.Playing);
		}
		if (ProgressFlags.GetFlag("show_banner") && !questData.id.StartsWith("uulaa_shop") && !string.IsNullOrEmpty(questData.Name))
		{
			playBanner = true;
			string message = Te.xt(questData.Name);
			if (!questData.safe && EventController.singleton.CanPlayerSeeEvents() && EventController.singleton.IsEventActive("3xXP"))
			{
				string message2 = Te.xt("tid_3x_xp");
				bannerSplash.Setup(message, message2, ColorConstants.rarityUncommon);
			}
			else
			{
				bannerSplash.Setup(message);
			}
		}
	}

	public void SetGameTime(int time)
	{
		totalLocationTime += level.gameTime;
		level.SetTime(0);
	}

	private void PreloadAsyncAssets(Data.Quest questData)
	{
		PreloadEncounters(questData.fixedEncounters);
		if (questData.sections != null)
		{
			for (int i = 0; i < questData.sections.Length; i++)
			{
				Data.QuestSection questSection = questData.sections[i];
				PreloadEncounters(questSection.fixedEncounters);
			}
		}
	}

	private void PreloadEncounters(Data.Encounter[] encounters)
	{
		if (encounters == null)
		{
			return;
		}
		for (int i = 0; i < encounters.Length; i++)
		{
			string args = encounters[i].args;
			if (args == null)
			{
				continue;
			}
			if (args.StartsWith("["))
			{
				string[] array = SlimJson.ParseArray("{0:" + args + "}", "0");
				for (int j = 0; j < array.Length; j++)
				{
					PreloadArgument(array[j]);
				}
				break;
			}
			PreloadArgument(args);
		}
	}

	private void PreloadArgument(string sjson)
	{
		string text = SlimJson.Parse(sjson, "drop");
		if (text != null)
		{
			Utils.PreloadAsyncPrefab(text);
		}
	}

	private void HandleOnOpenGate(GateData gateData)
	{
		AmbianceController.singleton.StopAllAmbient();
		Data.Quest questById = QuestController.singleton.GetQuestById("bronze_mine");
		QuestController.singleton.MakeAvailable(questById);
		StartQuest(questById);
		AchievementController.singleton.ReportLocationStartedManually(questById);
	}

	private void HandleOnGateCannotOpen(GateData gateData)
	{
		if (gateData.lockedDialog != null)
		{
			questExitDialog.SetString(gateData.lockedDialog.line1, gateData.lockedDialog.buttonLabel);
			SetState(State.GateNoKeyDialog);
		}
		else
		{
			TransitionToState(State.QuestScreen);
		}
	}

	private void HandleOnGateEscape(GateData gateData)
	{
		if (CurrentState == State.Gate)
		{
			AmbianceController.singleton.StopAllAmbient();
			TransitionToState(State.QuestScreen);
		}
	}

	private void HandleExitAppConfirmed(DialogButton btn)
	{
		Application.Quit();
	}

	private void HandleRestarProgressConfirmed(DialogButton btn)
	{
		GameSave.RestartProgress();
		CrossDeadwoodLogic.ResetTentacleCount();
		level.QuestData = null;
		ShowSoulstoneScreen(SoulstoneScreen.Type.MoonStone, State.MoonstoneRestartTransition);
		AnalyticsMacros.RestartProgress();
	}

	private void HandleAbilityActivated(IAbilityActivationProvider provider, SuperAbilityActivationState activationState, bool withStonescript)
	{
		if (activationState != null)
		{
			currentAbilityActivationState = activationState;
			SetState(State.PlayAbilityActivated);
		}
	}

	public void ShowPlayChoiceDialog(string message, string button1, string button2, KeyCode keyCodeForButton1, KeyCode keyCodeForButton2)
	{
		playChoiceDialog.SetupText(message, button1, button2, keyCodeForButton1, keyCodeForButton2);
		ShowPlayChoiceDialog();
	}

	public void ShowPlayChoiceDialog(string message, string button, KeyCode keyCodeForButton)
	{
		playChoiceDialog.SetupText(message, button, keyCodeForButton);
		ShowPlayChoiceDialog();
	}

	public void ShowPlayChoiceDialog(string message, string button1, string button2, Binding.Action actionForButton1, Binding.Action actionForButton2)
	{
		playChoiceDialog.SetupText(message, button1, button2, actionForButton1, actionForButton2);
		ShowPlayChoiceDialog();
	}

	public void ShowPlayChoiceDialog(string message, string button, Binding.Action actionForButton)
	{
		playChoiceDialog.SetupText(message, button, actionForButton);
		ShowPlayChoiceDialog();
	}

	public void ShowPlayChoiceDialog()
	{
		if (CurrentState == State.PlayPaused)
		{
			UnregisterPauseDialogCallbacks();
		}
		SetState(State.PlayChoiceDialog);
		SfxController.singleton.Play("prompt_choice");
	}

	public void SchedulePause()
	{
		pauseScheduled = true;
	}

	public void Pause()
	{
		if (currentState != State.Playing)
		{
			Utils.Log("Can only pause from the Play state");
			return;
		}
		playChoiceDialog.SetupText("", "Leave", "Items", Binding.Action.Leave, Binding.Action.Inventory);
		RegisterPauseDialogCallbacks();
		SetState(State.PlayPaused);
	}

	public void OpenPlayItemScreen()
	{
		if (currentState == State.Playing && userCanLeaveQuest && ProgressFlags.GetFlag("show_items"))
		{
			UnregisterPauseDialogCallbacks();
			SetState(State.PlayItemScreen);
		}
	}

	public void OpenPlayMindStoneScreen()
	{
		if ((currentState == State.Playing || currentState == State.PlayPaused) && userCanLeaveQuest && QuestController.singleton.IsAvailable("automate"))
		{
			UnregisterPauseDialogCallbacks();
			SetState(State.PlayMindStoneEdit);
		}
	}

	private void ShowCompletionBanner(Data.Quest quest)
	{
		string text = Te.xt(quest.name);
		if (Te.IsFemale(text))
		{
			ShowBanner(text, Te.xt("tid_location_complete_f"));
		}
		else
		{
			ShowBanner(text, Te.xt("tid_location_complete_m"));
		}
	}

	public void ShowBanner(string message1, string message2 = null)
	{
		if (!string.IsNullOrEmpty(message1))
		{
			bannerSplash.Setup(message1, message2);
			bannerSplash.Play();
		}
	}

	public void ShowMouse()
	{
		isDrawingMouse = true;
	}

	public void HideMouse()
	{
		isDrawingMouse = false;
	}

	public void ScheduleXpDialog()
	{
		xpDialogScheduled = true;
	}

	private void HandlePauseButtonPressed(DialogButton button)
	{
		if (currentState == State.Playing)
		{
			SchedulePause();
		}
	}

	private void HandleResumeButtonPressed(DialogButton button)
	{
		DoResumePlay();
	}

	private void HandlePausedDialogButton1(DialogButton button)
	{
		UnregisterPauseDialogCallbacks();
		hero.Cleanse();
		if (level.LevelComplete)
		{
			CompleteQuest();
			return;
		}
		level.XpEarned = 0;
		LeaveQuest();
	}

	private void HandlePausedDialogButton2(DialogButton button)
	{
		UnregisterPauseDialogCallbacks();
		SetState(State.PlayItemScreen);
	}

	private void HandlePausedDialogClickedOutside()
	{
		AsciiCellProcedural cell = asciiRenderer.GetCell(AsciiMouse.singleton.x, AsciiMouse.singleton.y);
		if (cell != null && cell.GetInteractionLayer() == null)
		{
			DoResumePlay();
		}
	}

	private void DoResumePlay()
	{
		if (!level.LevelComplete)
		{
			UnregisterPauseDialogCallbacks();
			AsciiMouse.singleton.Hide();
			SetState(State.Playing);
		}
	}

	private void RegisterPauseDialogCallbacks()
	{
		playChoiceDialog.button1.OnPressed += HandlePausedDialogButton1;
		playChoiceDialog.button2.OnPressed += HandlePausedDialogButton2;
		playChoiceDialog.OnClickedOutside += HandlePausedDialogClickedOutside;
	}

	private void UnregisterPauseDialogCallbacks()
	{
		playChoiceDialog.button1.OnPressed -= HandlePausedDialogButton1;
		playChoiceDialog.button2.OnPressed -= HandlePausedDialogButton2;
		playChoiceDialog.OnClickedOutside -= HandlePausedDialogClickedOutside;
	}

	private void HandlePlayOptionsButtonPressed(DialogButton button)
	{
		SetState(State.PlaySettingsScreen);
	}

	private void HandleRetryCloudStoragePressed(DialogButton btn)
	{
		CloudOneStorage cloudOneStorage = SaveFiles.singleton.storage as CloudOneStorage;
		if (cloudOneStorage.GetState() == AStorage.State.ConnectionError)
		{
			cloudOneStorage.RetrySignIn();
		}
		else
		{
			cloudOneStorage.RetryLoad();
		}
		nextState = State.StorageLoading;
		cloudConnectionErrorDialog.Hide();
	}

	private void HandlePlayLocalPressed(DialogButton btn)
	{
		CloudOneStorage cloudOneStorage = SaveFiles.singleton.storage as CloudOneStorage;
		if (cloudOneStorage.GetState() != AStorage.State.Success)
		{
			cloudOneStorage.LoadFromPlayerPrefs();
		}
	}

	public void ShowShop(string shopId)
	{
		ShopData shopById = ShopController.singleton.GetShopById(shopId);
		playItemNavBar.SetData(shopById.name, shopById.iconId);
		gateShopScreen.Setup(shopId);
		TransitionToState(State.GateShopScreen);
	}

	public bool IsOuroborosRun()
	{
		return level.loops > 0;
	}

	public bool InFinalBossRoom()
	{
		Data.Quest quest = ((parentQuest != null) ? parentQuest : level.QuestData);
		if (quest != null && quest.level >= 3)
		{
			if (level.QuestData.sections != null)
			{
				return level.sectionIndex == level.QuestData.sections.Length - 1;
			}
			return true;
		}
		return false;
	}

	public bool IsUndeadCryptIntro()
	{
		if (level.QuestData != null)
		{
			return level.QuestData.id == "undead_crypt_intro";
		}
		return false;
	}

	public bool AreAdsLoaded()
	{
		bool num = AdsWrapper.singleton.IsReady();
		if (!num)
		{
			Debug.LogError("Ads are not loaded, skipping treasure upgrade offer.");
		}
		return num;
	}

	public void AddItemFromPickup(Item item, int count = 1, bool offerUpgradeOption = false)
	{
		if (IsUndeadCryptIntro() && UndeadCryptIntro.timesPlayed >= 4 && W2ETreasureUpgradeDialog.CanTreasureBeUpgraded(item.id) && !W2ETreasureUpgradeDialog.InCooldownPeriod())
		{
			TreasureItem upgraded = TreasureFactory.singleton.MakeTreasureItem("treasure_upgrade", "skullnata", TreasureFactory.singleton.MakeListOfPossibleElements());
			SequentialPopupManager.singleton.ScheduleTreasureUpgrade((TreasureItem)item, upgraded);
		}
		else
		{
			item = Inventory.Singleton.GainItem(item, count);
			SequentialPopupManager.singleton.ScheduleItemFound(item, count);
		}
	}

	public void ShowSightstoneCharacter(Character character)
	{
		sightstoneCharacterDialog.Setup(character);
		SetState(State.SightstoneCharacterDialog);
		AnalyticsMacros.SightstoneUsed(level.QuestData, character.id);
	}

	public void ShowSoulstoneScreen(SoulstoneScreen.Type soulstoneType, State nextState)
	{
		soulstoneScreen.Setup(soulstoneType);
		TransitionToState(State.Soulstone);
		this.nextState = nextState;
		SoulstoneScreen.hideStopButton = false;
	}

	public void ExitSoulstoneScreen()
	{
		nextState = State.None;
		if (navBar.activeScreen == customQuestsScreen)
		{
			TransitionToState(State.CustomQuests);
		}
		else
		{
			TransitionToState(State.QuestScreen);
		}
	}

	public void RestartProgress(bool immediate)
	{
		if (immediate)
		{
			HandleRestarProgressConfirmed(null);
		}
		else
		{
			SetState(State.RestartProgressConfirmation);
		}
	}

	private void TryToRefillPotion()
	{
		Potion item = Potion.GetItem();
		if (item != null && item.autoRefill && item.type == Potion.Type.Empty)
		{
			item.Refill();
		}
	}

	private void Draw()
	{
		AsciiRenderProcedural asciiRenderProcedural = asciiRenderer;
		asciiRenderProcedural.Clear();
		bool flag = false;
		if (CurrentState != State.QuickCheats)
		{
			if (CurrentState == State.LanguageSelectionScreen)
			{
				LanguageSelectionScreen.singleton.Draw(asciiRenderProcedural, asciiRenderProcedural.width >> 1, 0);
			}
			else if (CurrentState == State.Logo)
			{
				logo.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2);
			}
			else if (CurrentState == State.StorageLoading)
			{
				if (stateElapsedTics > 1 && loadingSpinner != null)
				{
					loadingSpinner.Draw(asciiRenderProcedural, asciiRenderProcedural.width >> 1, asciiRenderProcedural.height >> 1);
				}
			}
			else if (CurrentState == State.CloudConnectionError || CurrentState == State.StorageLoadingError)
			{
				cloudConnectionErrorDialog.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2);
			}
			else if (currentState == State.StorageMergeDialog || currentState == State.GameCenterError)
			{
				storageMergeDialog.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2);
			}
			else if (CurrentState == State.MainMenu)
			{
				mainMenu.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2);
				if (loadingSpinner != null && mainMenu.currentState == MainMenu.State.Done && !ItemFactory.singleton.HasLoadedAllPrefabs())
				{
					loadingSpinner.Draw(asciiRenderProcedural, asciiRenderProcedural.width >> 1, asciiRenderProcedural.height >> 1);
				}
			}
			else if (CurrentState == State.Intro)
			{
				intro.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2);
			}
			else if (CurrentState == State.Soulstone)
			{
				soulstoneScreen.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2);
				DrawParticleLayer(asciiRenderProcedural);
			}
			else if (CurrentState == State.OuroborosPaint)
			{
				ouroborosPaintScreen.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2);
			}
			else if (CurrentState == State.StarStonePaint)
			{
				starStonePaintScreen.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2);
			}
			else if (CurrentState == State.EpilogueCredits)
			{
				demoCreditsScreen.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2);
			}
			else if (CurrentState == State.QuestScreen || CurrentState == State.WorkstationScreen || CurrentState == State.ItemScreen || CurrentState == State.CustomQuests)
			{
				navBar.Draw(asciiRenderProcedural, 0, 0);
				DrawParticleLayer(asciiRenderProcedural);
			}
			else if (CurrentState == State.SoulstoneQuestTransition || CurrentState == State.StarstoneQuestTransition || CurrentState == State.QuestStoneFTUETransition)
			{
				navBar.Draw(asciiRenderProcedural, 0, 0);
				money.Draw(asciiRenderProcedural, 0, 0, currentState);
				if (AdditionalSettings.isScreenFlash)
				{
					soulstoneTransitionOverlay.Sprite.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2);
				}
				else
				{
					soulstoneTransitionOverlay.Sprite.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2, 0.35f);
				}
				DrawParticleLayer(asciiRenderProcedural);
			}
			else if (CurrentState == State.OuroborosPaintTransition || CurrentState == State.StarStonePaintTransition)
			{
				navBar.Draw(asciiRenderProcedural, 0, 0);
				money.Draw(asciiRenderProcedural, 0, 0, currentState);
				soulstoneTransitionOverlay.Sprite.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2, UpgradeRelicScreen.selectedRarityColor);
				DrawParticleLayer(asciiRenderProcedural);
			}
			else if (CurrentState == State.OuroborosMainMenuTransition)
			{
				mainMenu.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2);
				Color selectedRarityColor = UpgradeRelicScreen.selectedRarityColor;
				if (!AdditionalSettings.isScreenFlash)
				{
					selectedRarityColor *= 0.35f;
				}
				soulstoneTransitionOverlay.Sprite.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2, selectedRarityColor);
			}
			else if (CurrentState == State.MoonstoneRestartTransition)
			{
				soulstoneTransitionOverlay.Sprite.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2);
			}
			else if (CurrentState == State.QuestOutroDialog || CurrentState == State.WorkstationOutroDialog)
			{
				navBar.Draw(asciiRenderProcedural, 0, 0);
				questExitDialog.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2);
			}
			else if (CurrentState == State.PlayItemScreen)
			{
				int emptySpace = asciiRenderProcedural.width - playItemNavBar.width - itemScreen.Width - UtilityBeltUI.singleton.displayedWidth;
				int num = playItemNavBar.ComputeLeftMargin(emptySpace);
				int num2 = playItemNavBar.ComputeMidMargin(emptySpace);
				playItemNavBar.Draw(asciiRenderProcedural, num, 0);
				itemScreen.Draw(asciiRenderProcedural, num + playItemNavBar.width + num2, 0);
			}
			else if (CurrentState == State.Gate)
			{
				gateScreen.Draw(asciiRenderProcedural, 0, 0);
			}
			else if (CurrentState == State.GateNoKeyDialog)
			{
				gateScreen.Draw(asciiRenderProcedural, 0, 0);
				questExitDialog.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2);
			}
			else if (CurrentState == State.GateShopScreen || currentState == State.GateShopReward)
			{
				DrawShopScreen(asciiRenderProcedural);
			}
			else if (CurrentState == State.SequentialPopupRewards && previousState != State.Playing)
			{
				if (previousState == State.GateShopScreen || previousState == State.GateShopReward)
				{
					DrawShopScreen(asciiRenderProcedural);
				}
				else
				{
					navBar.Draw(asciiRenderProcedural, 0, 0);
				}
				SequentialPopupManager.singleton.Draw(asciiRenderProcedural);
			}
			else if (CurrentState == State.ExitApp)
			{
				navBar.Draw(asciiRenderProcedural, 0, 0);
				exitAppDialog.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2);
			}
			else if (CurrentState == State.RestartProgressConfirmation)
			{
				navBar.Draw(asciiRenderProcedural, 0, 0);
				restartProgressDialog.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2);
			}
			else if (CurrentState == State.LoadingStonescripts)
			{
				if (loadingSpinner != null)
				{
					loadingSpinner.Draw(asciiRenderProcedural, asciiRenderProcedural.width >> 1, asciiRenderProcedural.height >> 1);
				}
			}
			else
			{
				level.Draw(asciiRenderProcedural);
				DrawParticleLayer(asciiRenderProcedural);
				abilityActivationHUD.Draw(asciiRenderProcedural);
				hud.Draw(asciiRenderProcedural, 0, 0);
				SSUILayer.singleton.Draw(asciiRenderProcedural, 0, 0);
				customQuestsUi.Draw(asciiRenderProcedural, 0, 0);
				flag = true;
				if (CurrentState == State.SightstonePlayTransition)
				{
					money.Draw(asciiRenderProcedural, 0, 0, currentState);
					if (AdditionalSettings.isScreenFlash)
					{
						sightstonePlayAnimation.Sprite.Draw(asciiRenderProcedural, asciiRenderProcedural.width >> 1, asciiRenderProcedural.height >> 1);
					}
					else
					{
						sightstonePlayAnimation.Sprite.Draw(asciiRenderProcedural, asciiRenderProcedural.width >> 1, asciiRenderProcedural.height >> 1, 0.35f);
					}
				}
				else if (CurrentState == State.SoulstonePlayTransition || CurrentState == State.OuroborosPlayTransition)
				{
					money.Draw(asciiRenderProcedural, 0, 0, currentState);
					if (AdditionalSettings.isScreenFlash)
					{
						magicPlayAnimation.Sprite.Draw(asciiRenderProcedural, asciiRenderProcedural.width >> 1, asciiRenderProcedural.height >> 1);
					}
					else
					{
						magicPlayAnimation.Sprite.Draw(asciiRenderProcedural, asciiRenderProcedural.width >> 1, asciiRenderProcedural.height >> 1, 0.35f);
					}
				}
				else if (CurrentState == State.HeadDroppingDeath)
				{
					float t = Mathf.Clamp01(((float)stateElapsedTics - 10f) / 20f);
					for (int i = 0; i < asciiRenderProcedural.width; i++)
					{
						for (int j = 0; j < asciiRenderProcedural.height; j++)
						{
							AsciiCellProcedural cell = asciiRenderProcedural.GetCell(i, j);
							Color foreground = cell.GetForeground();
							foreground = Color.Lerp(foreground, Color.black, t);
							Color background = cell.GetBackground();
							background = Color.Lerp(background, Color.black, t);
							cell.SetForeground(foreground);
							cell.SetBackground(background);
						}
					}
					t = Mathf.Clamp01(((float)stateElapsedTics - 130f) / 30f);
					headDroppingAnm.Sprite.Draw(asciiRenderProcedural, hero.lastDrawX, hero.lastDrawY, Color.Lerp(Color.white, Color.black, t));
				}
				else if (CurrentState == State.PlayChoiceDialog || CurrentState == State.PlayingOutroDialog)
				{
					playChoiceDialog.Draw(asciiRenderProcedural, (asciiRenderProcedural.width - 46) / 2, asciiRenderProcedural.height);
				}
				else if (CurrentState == State.PlayPaused)
				{
					playChoiceDialog.Draw(asciiRenderProcedural, (asciiRenderProcedural.width - 46) / 2, asciiRenderProcedural.height + ((!level.QuestData.safe) ? (-1) : 0));
					if (ShouldDrawResumeButton() && Hud.IsEnabled(Hud.Flag.PAUSE))
					{
						resumeButton.Draw(asciiRenderProcedural, asciiRenderProcedural.width - UtilityBeltUI.singleton.displayedWidth, asciiRenderProcedural.height);
						pauseOptionsButton.Draw(asciiRenderProcedural, 0, asciiRenderProcedural.height);
					}
				}
				else if (CurrentState == State.SequentialPopupRewards)
				{
					SequentialPopupManager.singleton.Draw(asciiRenderProcedural);
				}
				else if (CurrentState == State.PlayXpGained)
				{
					xpGainedDialog.Draw(asciiRenderProcedural, asciiRenderProcedural.width >> 1, asciiRenderProcedural.height >> 1);
				}
				else if (CurrentState == State.PlayAbilityActivated)
				{
					currentAbilityActivationState.Draw(asciiRenderProcedural);
				}
				else if (CurrentState == State.SightstoneCharacterDialog)
				{
					sightstoneCharacterDialog.Draw(asciiRenderProcedural, asciiRenderProcedural.width >> 1, asciiRenderProcedural.height >> 1);
				}
				else if (CurrentState == State.PlayMindStoneEdit)
				{
					MindStoneScreen.singleton.Draw(asciiRenderProcedural, asciiRenderProcedural.width >> 1, 0);
				}
				else if (CurrentState == State.PlaySettingsScreen)
				{
					settingsScreen.Draw(asciiRenderProcedural, asciiRenderProcedural.width / 2, asciiRenderProcedural.height / 2);
				}
				else if (ShouldDrawPauseButton() && Hud.IsEnabled(Hud.Flag.PAUSE))
				{
					pauseButton.Draw(asciiRenderProcedural, asciiRenderProcedural.width - UtilityBeltUI.singleton.displayedWidth, asciiRenderProcedural.height);
				}
			}
		}
		if (currentState != State.SoulstoneQuestTransition && currentState != State.StarstoneQuestTransition && currentState != State.OuroborosPaintTransition && currentState != State.StarStonePaintTransition && currentState != State.MoonstoneRestartTransition && (currentState != State.WorkstationScreen || workstationScreen.currentState != WorkstationScreen.State.MindStone) && currentState != State.ItemScreen && (currentState != State.SequentialPopupRewards || SequentialPopupManager.singleton.ShouldDrawMoneyHud()) && (currentState != State.ExitApp || previousState != State.ItemScreen) && currentState != State.RestartProgressConfirmation && currentState != State.LoadingStonescripts && currentState != State.HeadDroppingDeath && currentState != State.PlayItemScreen && currentState != State.SightstonePlayTransition && currentState != State.SoulstonePlayTransition && currentState != State.OuroborosPlayTransition && currentState != State.OuroborosMainMenuTransition && currentState != State.Gate && currentState != State.GateNoKeyDialog && (currentState != State.GateShopScreen || gateShopScreen.ShouldShowMoneyHUD()) && currentState != State.GateShopReward && currentState >= State.QuestScreen && questScreen.ShouldShowMoneyHUD() && (currentState != State.CustomQuests || customQuestsScreen.ShouldDrawMoneyHud()))
		{
			money.Draw(asciiRenderProcedural, 0, 0, currentState);
		}
		_ = userCanLeaveQuest;
		if (currentState == State.GateShopScreen)
		{
			gateShopScreen.DrawInAppPurchasePendingProgress(asciiRenderProcedural);
		}
		if (rewardProgressCard != null)
		{
			rewardProgressCard.Draw(asciiRenderProcedural, asciiRenderProcedural.width, 0);
		}
		if (weeklyQuestProgressCard != null)
		{
			weeklyQuestProgressCard.Draw(asciiRenderProcedural, asciiRenderProcedural.width, 0);
		}
		if (CurrentState != State.QuickCheats && isDrawingMouse)
		{
			AsciiMouse.singleton.Draw(asciiRenderProcedural, 0, 0);
		}
		if (transition != null)
		{
			transition.Draw(asciiRenderProcedural, 0, 0);
		}
		if ((bool)_customQuestsUi)
		{
			if (!flag)
			{
				_customQuestsUi.Draw(asciiRenderProcedural, 0, 0);
			}
			_customQuestsUi.LateDraw(asciiRenderProcedural, 0, 0);
		}
		if (bannerEnabled && bannerSplash != null)
		{
			bannerSplash.Draw(asciiRenderProcedural, 0, 0);
		}
		if (CurrentState < State.Playing || CurrentState == State.HeadDroppingDeath || CurrentState == State.PlayItemScreen || CurrentState == State.Gate || CurrentState == State.GateShopScreen)
		{
			DrawParticleLayer(asciiRenderProcedural);
		}
		AnimatedResourceFlyup.singleton.Draw(asciiRenderProcedural);
		GameplayActionMessages.Draw(asciiRenderProcedural);
		DiagnosticsUI.singleton.Draw(asciiRenderProcedural);
		asciiRenderProcedural.Push();
		ForeignLanguageRenderer.singleton.Draw(asciiRenderProcedural);
	}

	private void DrawShopScreen(AsciiRenderProcedural r)
	{
		int emptySpace = r.width - playItemNavBar.width - gateShopScreen.Width;
		int num = playItemNavBar.ComputeLeftMargin(emptySpace);
		int num2 = playItemNavBar.ComputeMidMargin(emptySpace);
		playItemNavBar.Draw(r, num, 0);
		gateShopScreen.Draw(r, num + playItemNavBar.width + num2, 0);
	}

	private void UpdateParticleLayer()
	{
		if (currentState >= State.Playing && currentState <= State.SightstoneCharacterDialog && currentState != State.PlayItemScreen)
		{
			if (!(gameParticleLayer == null))
			{
				gameParticleLayer.UpdateTic();
			}
		}
		else if (uiParticleLayer != null)
		{
			uiParticleLayer.UpdateTic();
		}
	}

	private void DrawParticleLayer(AsciiRenderProcedural r)
	{
		if (currentState >= State.Playing && currentState <= State.SightstoneCharacterDialog && currentState != State.PlayItemScreen && currentState != State.GateShopScreen)
		{
			if (gameParticleLayer == null)
			{
				return;
			}
			if (lastGameCamPosX != level.gameCamera.PositionX || lastGameCamPosY != level.gameCamera.PositionY)
			{
				int translateX = lastGameCamPosX - level.gameCamera.PositionX;
				int translateY = lastGameCamPosY - level.gameCamera.PositionY;
				lastGameCamPosX = level.gameCamera.PositionX;
				lastGameCamPosY = level.gameCamera.PositionY;
				if (level.QuestData == null || lastQuestId == level.QuestData.id)
				{
					gameParticleLayer.MoveParticles(translateX, translateY);
				}
				lastQuestId = ((level.QuestData == null) ? null : level.QuestData.id);
			}
			gameParticleLayer.Draw(r, 0, 0);
		}
		else if (uiParticleLayer != null)
		{
			uiParticleLayer.Draw(r, 0, 0);
		}
	}

	private void UpdateHeroInput(float deltaTime)
	{
		for (int i = 0; i < heroControllers.Length; i++)
		{
			if (heroControllers[i].enabled)
			{
				heroControllers[i].UpdateInput(deltaTime);
			}
		}
	}

	private void DebugDrawTable(AsciiRenderProcedural r)
	{
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				r.SetCell(i, j, i + j * 16);
			}
		}
	}

	private void DebugFillScreenWithSymbol(AsciiRenderProcedural r, int symbol)
	{
		for (int i = 0; i < r.width; i++)
		{
			for (int j = 0; j < r.height; j++)
			{
				r.SetCell(i, j, symbol);
			}
		}
	}

	private void OnApplicationPause(bool pause)
	{
	}

	private void OnApplicationQuit()
	{
	}

	public void TryToSaveProgress()
	{
		if (LOAD_AND_SAVE_PROGRESS && CurrentState != State.QuickCheats && CurrentState >= State.OuroborosPaint && !ExceptionHandlingUI.HasErrors())
		{
			MindStoneController.singleton.SaveStorage();
			GameSave.Save();
			InAppPurchaseController.singleton.CleanupAllPurchases();
		}
	}

	private void UpdateSave()
	{
		if (savePending)
		{
			savePending = false;
			TryToSaveProgress();
		}
	}

	private bool ShouldDrawPauseButton()
	{
		if (userCanLeaveQuest && !isTransitioning && stateElapsedTics > 0)
		{
			return !AsciiMouse.singleton.IsHidden();
		}
		return false;
	}

	private bool ShouldDrawResumeButton()
	{
		if (currentState == State.PlayPaused && !level.LevelComplete)
		{
			return playChoiceDialog.CurrentState == DialogNineSlice.State.Idle;
		}
		return false;
	}

	private bool IsThereNPCDialog()
	{
		NPCDialogBubble[] array = UnityEngine.Object.FindObjectsOfType<NPCDialogBubble>();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].CurrentState == DialogNineSlice.State.In || array[i].CurrentState == DialogNineSlice.State.Idle)
			{
				return true;
			}
		}
		return false;
	}

	private void FireQuestStarting(Data.Quest questData)
	{
		if (GameStates.OnQuestStarting != null)
		{
			GameStates.OnQuestStarting(questData);
		}
	}

	private void UpdateAppLastRunVersion()
	{
		Features.PREV_APP_VERSION = Version.FromString(PlayerPrefs.GetString(PREV_APP_VERSION_KEY, null));
		if (Features.PREV_APP_VERSION < Features.VERSION)
		{
			PlayerPrefs.SetString(PREV_APP_VERSION_KEY, Features.VERSION.ToString());
			PlayerPrefs.Save();
		}
	}

	private bool TryPlayEventThemeMusic()
	{
		EventController.EventData activeAndStartedEvent = EventController.singleton.GetActiveAndStartedEvent();
		if (activeAndStartedEvent != null && !string.IsNullOrEmpty(activeAndStartedEvent.music))
		{
			MusicController.singleton.Play(activeAndStartedEvent.music);
			return true;
		}
		return false;
	}

	public int GetStateNumericRepresentation()
	{
		int num = GetStateNumericRepresentation(currentState);
		if (currentState == State.WorkstationScreen)
		{
			num += workstationScreen.GetStateNumericRepresentation();
		}
		else if (currentState == State.ItemScreen)
		{
			num += itemScreen.GetStateNumericRepresentation();
		}
		return num;
	}

	public int GetStateNumericRepresentation(State state)
	{
		return (int)state * 10000;
	}

	public int GetStateNumericRepresentation(string stateStr)
	{
		State state = (State)Enum.Parse(typeof(State), stateStr);
		return GetStateNumericRepresentation(state);
	}

	public bool CanCustomQuestInvokeScriptCallbacks()
	{
		if (CurrentState >= State.Playing)
		{
			if (isTransitioning)
			{
				return postTransitionState >= State.Playing;
			}
			return true;
		}
		return false;
	}

	public void ProcessDeepLink(string appUrl)
	{
		string[] array = appUrl.Split('+', StringSplitOptions.RemoveEmptyEntries);
		appUrl = array[0];
		if (appUrl == "app_quest_screen" && CurrentState == State.MainMenu)
		{
			if (CustomQuestsController.Singleton.HasQueststoneUnlocked)
			{
				CustomQuestsScreen.deepLinkParams = array;
				nextState = State.CustomQuests;
			}
			mainMenu.HandlePlayPressed(null);
		}
	}

	private void InitMainMenu()
	{
		if (mainMenu == null)
		{
			mainMenu = UnityEngine.Object.Instantiate(mainMenuPrefab);
			settingsScreen = UnityEngine.Object.Instantiate(settingsScreenPrefab);
		}
	}

	private void InitNavBarAndMainScreens()
	{
		if (!(navBar != null))
		{
			navBar = UnityEngine.Object.Instantiate(navBarPrefab);
			questScreen = UnityEngine.Object.Instantiate(questScreenPrefab);
			workstationScreen = UnityEngine.Object.Instantiate(workstationScreenPrefab);
			itemScreen = UnityEngine.Object.Instantiate(itemScreenPrefab);
			customQuestsScreen = UnityEngine.Object.Instantiate(customQuestsScreenPrefab);
			navBar.AddScreen(questScreen);
			navBar.AddScreen(workstationScreen);
			navBar.AddScreen(itemScreen);
			navBar.AddScreen(customQuestsScreen);
			navBar.OnScreenChanged += HandleNavBarChanged;
			navBar.mainMenuOptionsButton.OnPressed += HandleMainMenuOptionsButtonPressed;
			questScreen.OnQuestSelected += HandleOnQuestSelected;
			questScreen.OnQuestTimerCompleted += HandleOnQuestTimerCompleted;
			QuestDifficultySubMenuAdvanced difficultySubMenuAdvanced = questScreen.difficultySubMenuAdvanced;
			difficultySubMenuAdvanced.OnOfflineFarmSelected = (Action<Data.Quest, int>)Delegate.Combine(difficultySubMenuAdvanced.OnOfflineFarmSelected, new Action<Data.Quest, int>(HandleOfflineFarmSelected));
			questScreen.difficultyOverride = CustomQuestsController.Singleton.OverrideLocationDifficulty;
			workstationScreen.OnQuestSelected += HandleOnQuestSelected;
			workstationScreen.OnQuestTimerCompleted += HandleOnQuestTimerCompleted;
			CustomQuestsController.Singleton.customQuestsScreen = customQuestsScreen;
			CustomQuestsController.Singleton.ConnectToAnvilScreen();
			CustomQuestsController.Singleton.ConnectToCauldronScreen();
			CustomQuestsController.Singleton.OnQuestCompleted += HandleCustomQuestCompleted;
			playItemNavBar = UnityEngine.Object.Instantiate(playItemNavBarPrefab);
			playItemNavBar.backButton.OnPressed += HandlePlayItemBackPressed;
			money = UnityEngine.Object.Instantiate(moneyPrefab);
			this.OnInitializationComplete?.Invoke();
		}
	}

	private void InitEverythingElse()
	{
		if (!(intro != null))
		{
			intro = UnityEngine.Object.Instantiate(introPrefab);
			soulstoneScreen = UnityEngine.Object.Instantiate(soulstoneScreenPrefab);
			sightstonePlayAnimation = UnityEngine.Object.Instantiate(sightstonePlayAnimationPrefab);
			sightstonePlayAnimation.Sprite.Load();
			magicPlayAnimation = UnityEngine.Object.Instantiate(magicPlayAnimationPrefab);
			magicPlayAnimation.Sprite.Load();
			soulstoneTransitionOverlay = UnityEngine.Object.Instantiate(soulstoneTransitionOverlayPrefab);
			demoCreditsScreen = UnityEngine.Object.Instantiate(demoCreditsScreenPrefab);
			gateShopScreen = UnityEngine.Object.Instantiate(gateShopScreenPrefab);
			level = UnityEngine.Object.Instantiate(levelPrefab);
			hero = UnityEngine.Object.Instantiate(heroPrefab);
			hero.Init();
			hud = UnityEngine.Object.Instantiate(hudPrefab);
			questExitDialog = UnityEngine.Object.Instantiate(questExitDialogPrefab);
			playChoiceDialog = UnityEngine.Object.Instantiate(playChoiceDialogPrefab);
			pauseButton = UnityEngine.Object.Instantiate(pauseButtonPrefab);
			resumeButton = pauseButton;
			pauseOptionsButton = UnityEngine.Object.Instantiate(pauseOptionsButtonPrefab);
			xpGainedDialog = UnityEngine.Object.Instantiate(xpGainedDialogPrefab);
			bannerSplash = UnityEngine.Object.Instantiate(bannerSplashPrefab);
			sightstoneCharacterDialog = UnityEngine.Object.Instantiate(sightstoneCharacterDialogPrefab);
			gateScreen = UnityEngine.Object.Instantiate(gateScreenPrefab);
			quickCheatsMenu = UnityEngine.Object.Instantiate(quickCheatsMenuPrefab);
			transition = UnityEngine.Object.Instantiate(transitionPrefab);
			exitAppDialog = UnityEngine.Object.Instantiate(exitAppDialogPrefab);
			restartProgressDialog = UnityEngine.Object.Instantiate(restartProgressDialogPrefab);
			abilityActivationHUD = UnityEngine.Object.Instantiate(abilityActivationHUDPrefab);
			rewardProgressCard = UnityEngine.Object.Instantiate(rewardProgressCardPrefab);
			SequentialPopupManager.singleton.Initialize();
			weeklyQuestProgressCard = UnityEngine.Object.Instantiate(weeklyQuestProgressCardPrefab);
			normalHeadDroppingAnm = UnityEngine.Object.Instantiate(headDroppingAnmPrefab);
			normalHeadDroppingAnm.Sprite.Load();
			normalHeadDroppingAnm.gameObject.SetActive(value: false);
			bigHeadDroppingAnm = UnityEngine.Object.Instantiate(bigHeadDroppingAnmPrefab);
			bigHeadDroppingAnm.Sprite.Load();
			bigHeadDroppingAnm.gameObject.SetActive(value: false);
			heroControllers = hero.GetComponentsInChildren<HeroController>();
			Character.OnCharacterGoingToTakeDamage += HandleOnCharacterGoingToTakeDamage;
			pauseButton.OnPressed += HandlePauseButtonPressed;
			resumeButton.OnPressed += HandleResumeButtonPressed;
			pauseOptionsButton.OnPressed += HandlePlayOptionsButtonPressed;
			gateScreen.OnOpenGate += HandleOnOpenGate;
			gateScreen.OnCannotOpen += HandleOnGateCannotOpen;
			gateScreen.OnEscape += HandleOnGateEscape;
			exitAppDialog.okButton.OnPressed += HandleExitAppConfirmed;
			restartProgressDialog.okButton.OnPressed += HandleRestarProgressConfirmed;
			abilityActivationHUD.OnActivated += HandleAbilityActivated;
		}
	}

	private void Start()
	{
		UpdateAppLastRunVersion();
		GameSave.InitStorageType();
		SettingsScreen.LoadSettings();
		if (string.IsNullOrEmpty(AdditionalSettings.selectedLanguage))
		{
			SetState(State.LanguageSelectionScreen);
			return;
		}
		Localization.singleton.SetLanguage(AdditionalSettings.selectedLanguage);
		SetState(State.Logo);
	}

	private void OnDestroy()
	{
		Character.OnCharacterGoingToTakeDamage -= HandleOnCharacterGoingToTakeDamage;
		if (navBar != null)
		{
			navBar.OnScreenChanged -= HandleNavBarChanged;
			navBar.mainMenuOptionsButton.OnPressed -= HandleMainMenuOptionsButtonPressed;
			playItemNavBar.backButton.OnPressed -= HandlePlayItemBackPressed;
		}
		if (questScreen != null)
		{
			questScreen.OnQuestSelected -= HandleOnQuestSelected;
			questScreen.OnQuestTimerCompleted -= HandleOnQuestTimerCompleted;
			QuestDifficultySubMenuAdvanced difficultySubMenuAdvanced = questScreen.difficultySubMenuAdvanced;
			difficultySubMenuAdvanced.OnOfflineFarmSelected = (Action<Data.Quest, int>)Delegate.Remove(difficultySubMenuAdvanced.OnOfflineFarmSelected, new Action<Data.Quest, int>(HandleOfflineFarmSelected));
		}
		if (workstationScreen != null)
		{
			workstationScreen.OnQuestSelected -= HandleOnQuestSelected;
			workstationScreen.OnQuestTimerCompleted -= HandleOnQuestTimerCompleted;
		}
		if (pauseButton != null)
		{
			pauseButton.OnPressed -= HandlePauseButtonPressed;
			resumeButton.OnPressed -= HandleResumeButtonPressed;
			pauseOptionsButton.OnPressed -= HandlePlayOptionsButtonPressed;
		}
		if (gateScreen != null)
		{
			gateScreen.OnOpenGate -= HandleOnOpenGate;
			gateScreen.OnCannotOpen -= HandleOnGateCannotOpen;
			gateScreen.OnEscape -= HandleOnGateEscape;
		}
		if (exitAppDialog != null)
		{
			exitAppDialog.okButton.OnPressed -= HandleExitAppConfirmed;
		}
		if (restartProgressDialog != null)
		{
			restartProgressDialog.okButton.OnPressed -= HandleRestarProgressConfirmed;
		}
		if (abilityActivationHUD != null)
		{
			abilityActivationHUD.OnActivated -= HandleAbilityActivated;
		}
		cloudConnectionErrorDialog.okButton.OnPressed -= HandleRetryCloudStoragePressed;
		cloudConnectionErrorDialog.cancelButton.OnPressed -= HandlePlayLocalPressed;
	}

	private void Awake()
	{
		_instance = this;
		asciiRenderer = UnityEngine.Object.Instantiate(asciiRendererPrefab);
		AsciiParticleLayer[] components = asciiRenderer.GetComponents<AsciiParticleLayer>();
		gameParticleLayer = components[0];
		uiParticleLayer = components[1];
		logo = UnityEngine.Object.Instantiate(logoPrefab);
		logo.enabled = false;
		Application.targetFrameRate = 60;
		bannerEnabled = true;
		cloudConnectionErrorDialog.okButton.OnPressed += HandleRetryCloudStoragePressed;
		cloudConnectionErrorDialog.cancelButton.OnPressed += HandlePlayLocalPressed;
	}
}
