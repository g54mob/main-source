using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	private static MenuManager _instance;

	public AudioSource audioSource;

	public Transform modalMenuRoot;

	public Transform centerPanelRoot;

	public Transform backgroundPanelRoot;

	public Transform overlayPanelRoot;

	public Transform leftBottomPanelRoot;

	public Transform leftMiddlePanelRoot;

	public RectTransform questRegion;

	public RectTransform inventoryRegion;

	public RectTransform coinRegionRoot;

	public CursorDisplay cursorDisplay;

	public Canvas canvas;

	public CanvasScaler canvasScaler;

	public CanvasGroup welcomeCanvasGroup;

	public CanvasGroup mainCanvasGroup;

	public Image backgroundImage;

	public Image centerPanelBackground;

	public SearchHeader searchHeader;

	public MenuButton searchToggleButton;

	public LabelButton inputDeltaButton;

	public GameObject searchHeaderRegion;

	public Sprite buttonImageDefault;

	public Sprite buttonImageDisabled;

	[Header("Panel Prefabs")]
	public GameObject inventoryPanelPrefab;

	public GameObject harvestingPanelPrefab;

	public GameObject craftingPanelPrefab;

	public GameObject buildingsPanelPrefab;

	public GameObject worldPanelPrefab;

	public GameObject worldPerksPanelPrefab;

	public GameObject townPerksPanelPrefab;

	public GameObject townResetPanelPrefab;

	public GameObject marketPanelPrefab;

	public GameObject farmingPanelPrefab;

	public GameObject miningPanelPrefab;

	public GameObject tradingPanelPrefab;

	public GameObject researchPanelPrefab;

	public GameObject upgradesPanelPrefab;

	public GameObject combinedProductionPanelPrefab;

	public GameObject questsPanelPrefab;

	public GameObject coinsPanelPrefab;

	public GameObject logPanelPrefab;

	public GameObject townStatsPanelPrefab;

	public GameObject debugPanelPrefab;

	public GameObject tooltipPanelPrefab;

	public GameObject textEntryPanelPrefab;

	public GameObject miningGamePanelPrefab;

	public GameObject waterGamePanelPrefab;

	public GameObject researchGamePanelPrefab;

	public GameObject farmingGamePanelPrefab;

	public GameObject diceGamePanelPrefab;

	public GameObject woodGamePanelPrefab;

	public GameObject minigameSelectionPanelPrefab;

	public GameObject rewardPanelPrefab;

	public GameObject gameMenuPrefab;

	public GameObject popupMenuPrefab;

	public GameObject popupIconGridPrefab;

	public GameObject optionsPanelPrefab;

	public GameObject controlsPanelPrefab;

	public GameObject playerPromptPanelPrefab;

	public GameObject biomeSelectionPanelPrefab;

	public GameObject idleProgressPanelPrefab;

	public GameObject timeTokensPanelPrefab;

	public GameObject clickablesPanelPrefab;

	public GameObject fullGameVersionPanelPrefab;

	public GameObject creditsPanelPrefab;

	public GameObject productionConfigPanelPrefab;

	public GameObject victoryPanelPrefab;

	public GameObject constructionDetailsPanelPrefab;

	public GameObject levelUpRewardsPanelPrefab;

	public GameObject biomeUnlockPanelPrefab;

	public GameObject pointerPanelPrefab;

	public GameObject recipeConfigPanelPrefab;

	public GameObject fileListPanelPrefab;

	public GameObject gameSetupPanelPrefab;

	[NonSerialized]
	public InventoryPanel inventoryPanel;

	[NonSerialized]
	public InventoryPanel inventoryPanelPopup;

	[NonSerialized]
	public CoinPanel coinPanel;

	public WelcomePanel welcomePanel;

	[NonSerialized]
	public QuestsPanel questsPanel;

	[NonSerialized]
	public QuestsPanel questsPanelPopup;

	[NonSerialized]
	public LogPanel logPanel;

	[NonSerialized]
	public BuildingsPanel buildingsPanel;

	[NonSerialized]
	public WorldPanel worldPanel;

	[NonSerialized]
	public PerksPanel worldPerksPanel;

	[NonSerialized]
	public PerksPanel townPerksPanel;

	[NonSerialized]
	public TownResetPanel townResetPanel;

	[NonSerialized]
	public ProductionListPanelCombined combinedProductionPanel;

	[NonSerialized]
	public ResearchPanel researchPanel;

	[NonSerialized]
	public UpgradesPanel upgradesPanel;

	[NonSerialized]
	public OptionsPanel optionsPanel;

	[NonSerialized]
	public ControlsPanel controlsPanel;

	[NonSerialized]
	public DebugPanel debugPanel;

	[NonSerialized]
	public PlayerPromptPanel playerPromptPanel;

	[NonSerialized]
	public IdleGainPanel idleProgressPanel;

	[NonSerialized]
	public TimeTokensPanel timeTokensPanel;

	[NonSerialized]
	public BiomeSelectionPanel biomeSelectionPanel;

	[NonSerialized]
	public TooltipPanel tooltipPanel;

	[NonSerialized]
	public ConstructionDetailsPanel constructionDetailsPanel;

	[NonSerialized]
	public TextEntryPanel textEntryPanel;

	[NonSerialized]
	public MiningMap minigamePanelMining;

	[NonSerialized]
	public MinigamePanelWater minigamePanelWater;

	[NonSerialized]
	public MinigamePanelResearch minigamePanelResearch;

	[NonSerialized]
	public MinigamePanelFarming minigamePanelFarming;

	[NonSerialized]
	public MinigamePanelDice minigamePanelDice;

	[NonSerialized]
	public MinigamePanelWood minigamePanelWood;

	[NonSerialized]
	public MinigameSelectionPanel minigameSelectionPanel;

	[NonSerialized]
	public RewardPanel rewardPanel;

	[NonSerialized]
	public VideoPreferencesPanel videoPreferencesPanel;

	[NonSerialized]
	public GameMenuPanel gameMenuPanel;

	[NonSerialized]
	public FileListPanel fileListPanel;

	[NonSerialized]
	public PopupMenu popupMenu;

	[NonSerialized]
	public PopupIconGrid popupIconGrid;

	[NonSerialized]
	public FullGameVersionPanel fullGameVersionPanel;

	[NonSerialized]
	public CreditsPanel creditsPanel;

	[NonSerialized]
	public ProductionLimitPanel productionLimitPanel;

	[NonSerialized]
	public VictoryPanel victoryPanel;

	[NonSerialized]
	public LevelUpRewardPanel levelUpRewardPanel;

	[NonSerialized]
	public BiomeUnlockPanel biomeUnlockPanel;

	[NonSerialized]
	public PointerPanel pointerPanel;

	[NonSerialized]
	public RecipeConfigPanel recipeConfigPanel;

	[NonSerialized]
	public GameSetupPanel gameSetupPanel;

	public TownStatsPanel townStatsPanel;

	public NavigationPanel navigationPanel;

	public GameObject highlightedGameObject;

	public MenuButton highlightedMenuButton;

	public TextTooltip textTooltip;

	public PlayerMessageItem playerMessageItem;

	public CanvasGroup loadingCover;

	public Transform loadingFrame;

	public TextMeshProUGUI loadingLabel;

	[Header("Misc Prefabs")]
	public GameObject buttonHighlightPrefab;

	public GameObject sectionHeaderPrefab;

	public GameObject tradingPostSectionHeaderPrefab;

	public GameObject simpleSectionHeaderPrefab;

	public GameObject simpleSectionHeaderTallPrefab;

	public GameObject sectionGroupPrefab;

	public GameObject alertPrefab;

	public GameObject attemptIconPrefab;

	public GameObject entityIconPrefab;

	public GameObject costIconPrefab;

	public GameObject costIconWidePrefab;

	public GameObject costIconSliderPrefab;

	public GameObject costIconWideSliderPrefab;

	public GameObject spacerArrowPrefab;

	public GameObject modifierIconPrefab;

	public int queuedLoadingMenuAction;

	public const int LoadingMenuActionShowWelcome = 0;

	public const int LoadingMenuActionLoadSelectedSlot = 1;

	public const int LoadingMenuActionCreateNewTown = 2;

	private readonly List<MenuPanel> modalMenuStack = new List<MenuPanel>();

	private readonly List<MenuPanel> nonModalMenus = new List<MenuPanel>();

	[NonSerialized]
	public readonly List<MinigamePanelParent> minigamePanels = new List<MinigamePanelParent>();

	private readonly List<HighlightImage> highlightImagePool = new List<HighlightImage>();

	[NonSerialized]
	public readonly Dictionary<MenuPanelType, MenuPanel> menuPanels = new Dictionary<MenuPanelType, MenuPanel>(new MenuPanelEqualityComparer());

	public CustomAnimation loadingCoverAnimation;

	public bool isHighlightingWorkerAssignment;

	private const float progressBarLerpSpeed = 0.05f;

	public bool canvasMode;

	private bool _canvasMode;

	public bool disableAutoSize;

	private bool _disableAutoSize;

	public const bool disableInactiveObjects = true;

	private float tooltipCountdown;

	private float tooltipResetCountdown;

	private bool isInImmediateTooltipMode;

	public bool isTooltipStale;

	public bool isLeftLayoutStale;

	public int lastScrollDir;

	public int numScrollRepeats;

	public float scrollCooldown;

	private bool isInParticlesMode;

	public GameObject animatedIconPrefab;

	private IObjectPool<AnimatedIcon> animatedIconPool;

	public GameObject digParticlePrefab;

	public IObjectPool<PooledParticleParent> digParticlePool;

	public GameObject starParticlePrefab;

	public IObjectPool<PooledParticleParent> starParticlePool;

	public GameObject chargePathParticlePrefab;

	public IObjectPool<PooledParticleParent> chargePathParticlePool;

	private int debugAnimatedIconCount;

	public Image modalBackgroundImage;

	public static bool useDynamicSizing = true;

	public static bool applyVisibilityChangesImmediately;

	private EntityId activeNavigationEntity;

	private Stack<EntityId> navigationStack = new Stack<EntityId>();

	private Stack<EntityId> navigationStackReverse = new Stack<EntityId>();

	private Queue<Notification> notificationQueue = new Queue<Notification>();

	public static bool isSearchApplied;

	public static string currentSearchText;

	[NonSerialized]
	public TooltipOptions inventoryTooltipOptions;

	[NonSerialized]
	public TooltipOptions tradeStorageTooltipOptions;

	[NonSerialized]
	public TooltipOptions currencyTooltipOptions;

	[NonSerialized]
	public TooltipOptions recipeLabelTooltipOptions;

	[NonSerialized]
	public TooltipOptions rewardTooltipOptions;

	[NonSerialized]
	public TooltipOptions headerInfoTooltipOptions;

	[NonSerialized]
	public TooltipOptions lockedBiomeTooltipOptions;

	[NonSerialized]
	public TooltipOptions centeredTooltipOptions;

	[NonSerialized]
	public TooltipOptions defaultTooltipOptions;

	private int lastDisplayedBaselineDelta;

	private int buttonHighlightIndex;

	[NonSerialized]
	public float pointerDelayCounter;

	private const float MarginTop = 14f;

	private const float MarginLeft = 14f;

	private const float MarginBottom = 17f;

	private const float MinimizedHeight = 44f;

	private const float TownStatsRegionHeight = 208f;

	private const float LeftPanelSpacing = 4f;

	private const float DefaultQuestsHeight = 276f;

	public HeaderCollapseManager tradingHeaderCollapseManager;

	public EntityId queuedNotificationEntitiy;

	public static MenuManager Instance => _instance;

	private static GameManager gm => GameManager.Instance;

	private Town displayedTown => gm.activeTown;

	private void Awake()
	{
		loadingCoverAnimation = new CustomAnimation(0f, 1f, 0.5f, Ease.Linear);
		textTooltip.gameObject.SetActive(value: false);
		SetParticlesMode(enable: true);
		canvasMode = true;
		_canvasMode = true;
		_instance = this;
		debugPanel = UnityEngine.Object.Instantiate(debugPanelPrefab, overlayPanelRoot).GetComponent<DebugPanel>();
		debugPanel.gameObject.SetActive(value: false);
		animatedIconPool = new ObjectPool<AnimatedIcon>(CreatePooledAnimatedIcon, GameUtility.OnPooledObjectGet, GameUtility.OnPooledObjectReleased, null, collectionCheck: true, 10, 20);
		digParticlePool = new ObjectPool<PooledParticleParent>(CreatePooledDigParticle, null, GameUtility.OnPooledObjectReleased, null, collectionCheck: true, 10, 20);
		starParticlePool = new ObjectPool<PooledParticleParent>(CreatePooledStarParticle, null, GameUtility.OnPooledObjectReleased, null, collectionCheck: true, 10, 20);
		chargePathParticlePool = new ObjectPool<PooledParticleParent>(CreatePooledChargedPathParticle, null, GameUtility.OnPooledObjectReleased, null, collectionCheck: true, 10, 20);
	}

	public IObjectPool<MonoBehaviour> GetPool(object obj)
	{
		return null;
	}

	public MonoBehaviour GetFromPool(object obj)
	{
		IObjectPool<MonoBehaviour> pool = GetPool(obj);
		MonoBehaviour monoBehaviour = pool.Get();
		if (monoBehaviour is CommonListItem commonListItem)
		{
			commonListItem.parentPool = pool;
		}
		return monoBehaviour;
	}

	private MonoBehaviour CreateCommonListItemForPool(GameObject prefab)
	{
		GameObject obj = UnityEngine.Object.Instantiate(prefab);
		obj.transform.localScale = Vector3.one;
		CommonListItem component = obj.GetComponent<CommonListItem>();
		component.Initialize();
		return component;
	}

	private void AddBuiltInMenu(MenuPanel p, MenuPanelType t, string headerLocalizationKey)
	{
		p.panelCategory = PanelCategory.Background;
		p.panelType = t;
		p.headerLocalizationKey = headerLocalizationKey;
		p.headerSprite = IconManager.SpriteForMenuPanel(t);
		if (canvasMode)
		{
			p.AddCanvas();
		}
		menuPanels[t] = p;
	}

	private PooledParticleParent CreatePooledDigParticle()
	{
		return CreatePooledItem(digParticlePrefab, digParticlePool);
	}

	private PooledParticleParent CreatePooledStarParticle()
	{
		return CreatePooledItem(starParticlePrefab, starParticlePool);
	}

	private PooledParticleParent CreatePooledChargedPathParticle()
	{
		return CreatePooledItem(chargePathParticlePrefab, chargePathParticlePool);
	}

	private AnimatedIcon CreatePooledAnimatedIcon()
	{
		AnimatedIcon component = UnityEngine.Object.Instantiate(animatedIconPrefab, overlayPanelRoot).GetComponent<AnimatedIcon>();
		component.animatedIconIndex = debugAnimatedIconCount;
		debugAnimatedIconCount++;
		return component;
	}

	public void TryModify(int dir)
	{
		if (null != highlightedGameObject)
		{
			CommonListItem componentInParent = highlightedGameObject.GetComponentInParent<CommonListItem>();
			if (null != componentInParent && null != componentInParent.workerAssignmentRegion)
			{
				componentInParent.workerAssignmentRegion.TryModify(dir);
			}
		}
	}

	public void TrySelect()
	{
		if (null != highlightedGameObject && highlightedGameObject.TryGetComponent<MenuButton>(out var component))
		{
			component.Press();
			component.pointerDownDelegate?.Invoke();
		}
	}

	public void TryScroll(int dir)
	{
		if (dir != lastScrollDir)
		{
			scrollCooldown = 0f;
		}
		lastScrollDir = dir;
		if (!(scrollCooldown > 0f) && null != highlightedGameObject)
		{
			ScrollRect componentInParent = highlightedGameObject.GetComponentInParent<ScrollRect>();
			if (null != componentInParent)
			{
				MenuUtility.ScrollPage(componentInParent, dir);
				scrollCooldown = UserInput.InputRepeatCooldown(numScrollRepeats) * 0.5f;
				numScrollRepeats++;
			}
		}
	}

	public void ReturnToAnimatedIconPool(AnimatedIcon sender)
	{
		animatedIconPool.Release(sender);
	}

	private T AddCenterMenuPanel<T>(MenuPanelType type, GameObject prefab, string headerLocalizationKey) where T : MenuPanel
	{
		T component = UnityEngine.Object.Instantiate(prefab, centerPanelRoot).GetComponent<T>();
		component.headerLocalizationKey = headerLocalizationKey;
		component.headerSprite = IconManager.SpriteForMenuPanel(type);
		component.panelCategory = PanelCategory.CenteredTown;
		if (canvasMode)
		{
			component.AddCanvas();
		}
		menuPanels[type] = component;
		component.panelType = type;
		return component;
	}

	private T AddSubMenuPanel<T>(MenuPanelType type, GameObject prefab, string headerLocalizationKey, Transform root) where T : MenuPanel
	{
		T component = UnityEngine.Object.Instantiate(prefab, root).GetComponent<T>();
		component.headerLocalizationKey = headerLocalizationKey;
		component.panelCategory = PanelCategory.LeftBottom;
		component.headerSprite = IconManager.SpriteForMenuPanel(type);
		if (canvasMode)
		{
			component.AddCanvas();
		}
		menuPanels.ContainsKey(type);
		menuPanels[type] = component;
		component.panelType = type;
		return component;
	}

	public static PanelCategory CategoryForMenu(MenuPanelType t)
	{
		switch (t)
		{
		case MenuPanelType.Quests:
		case MenuPanelType.Inventory:
			return PanelCategory.LeftBottom;
		case MenuPanelType.Tooltip:
		case MenuPanelType.Trading:
		case MenuPanelType.TimeTokens:
		case MenuPanelType.ConstructionDetails:
		case MenuPanelType.Log:
		case MenuPanelType.QuestsPopup:
		case MenuPanelType.InventoryPopup:
			return PanelCategory.FloatingModal;
		case MenuPanelType.GameMenu:
		case MenuPanelType.TextEntry:
		case MenuPanelType.PlayerPrompt:
		case MenuPanelType.BiomeSelection:
		case MenuPanelType.FullGame:
		case MenuPanelType.Credits:
		case MenuPanelType.IdleProgress:
		case MenuPanelType.Victory:
		case MenuPanelType.LevelUpRewards:
		case MenuPanelType.BiomeUnlock:
		case MenuPanelType.FileList:
		case MenuPanelType.GameSetup:
			return PanelCategory.FixedModal;
		case MenuPanelType.Buildings:
		case MenuPanelType.World:
		case MenuPanelType.Research:
		case MenuPanelType.Upgrades:
		case MenuPanelType.Perks:
		case MenuPanelType.Reward:
		case MenuPanelType.PopupMenu:
		case MenuPanelType.Options:
		case MenuPanelType.TownPerks:
		case MenuPanelType.TownReset:
		case MenuPanelType.ProductionConfig:
		case MenuPanelType.PopupGridMenu:
		case MenuPanelType.Controls:
		case MenuPanelType.RecipeConfig:
			return PanelCategory.DismissableModal;
		default:
			UnityEngine.Debug.LogError("Did not assign panel category to " + t);
			return PanelCategory.None;
		}
	}

	private bool IsCategoryInModalStack(PanelCategory c)
	{
		if ((uint)(c - 3) <= 2u)
		{
			return true;
		}
		return false;
	}

	private bool DoesPanelCategoryBlockBackground(PanelCategory c)
	{
		if ((uint)(c - 4) <= 1u)
		{
			return true;
		}
		return false;
	}

	private T AddModalMenuPanel<T>(MenuPanelType type, GameObject prefab, string headerLocalizationKey) where T : MenuPanel
	{
		PanelCategory panelCategory = CategoryForMenu(type);
		Transform parent = backgroundPanelRoot;
		if (DoesPanelCategoryBlockBackground(panelCategory))
		{
			parent = modalMenuRoot;
		}
		if (type == MenuPanelType.Tooltip)
		{
			parent = modalMenuRoot;
		}
		T component = UnityEngine.Object.Instantiate(prefab, parent).GetComponent<T>();
		component.headerLocalizationKey = headerLocalizationKey;
		component.panelCategory = panelCategory;
		switch (type)
		{
		case MenuPanelType.TownStats:
		case MenuPanelType.Quests:
		case MenuPanelType.Inventory:
		case MenuPanelType.Buildings:
		case MenuPanelType.Research:
		case MenuPanelType.Upgrades:
		case MenuPanelType.Tooltip:
		case MenuPanelType.Reward:
		case MenuPanelType.GameMenu:
		case MenuPanelType.TextEntry:
		case MenuPanelType.PopupMenu:
		case MenuPanelType.FullGame:
		case MenuPanelType.Credits:
		case MenuPanelType.IdleProgress:
		case MenuPanelType.ProductionConfig:
		case MenuPanelType.UpgradesPopup:
		case MenuPanelType.Victory:
		case MenuPanelType.TimeTokens:
		case MenuPanelType.QuestsPopup:
		case MenuPanelType.LevelUpRewards:
		case MenuPanelType.InventoryPopup:
		case MenuPanelType.BiomeUnlock:
		case MenuPanelType.RecipeConfig:
		case MenuPanelType.FileList:
		case MenuPanelType.GameSetup:
			component.skipAlert = true;
			break;
		}
		component.headerSprite = IconManager.SpriteForMenuPanel(type);
		if (canvasMode)
		{
			component.AddCanvas();
		}
		menuPanels[type] = component;
		component.panelType = type;
		return component;
	}

	private void Update()
	{
		if (null != minigamePanelFarming)
		{
			minigamePanelFarming.UpdateFarmingState();
		}
		if (loadingCoverAnimation.isRunning)
		{
			loadingCoverAnimation.UpdateAnimation();
			loadingCover.alpha = loadingCoverAnimation.progress;
			if (!loadingCoverAnimation.isRunning)
			{
				if (loadingCoverAnimation.isReversed)
				{
					OnCompletedLoadingCoverFadeOut();
				}
				else
				{
					OnCompletedLoadingCoverFadeIn();
				}
			}
		}
		if (tooltipCountdown > 0f)
		{
			tooltipCountdown -= TimeManager.MenuDelta;
			if (tooltipCountdown <= 0f)
			{
				isInImmediateTooltipMode = true;
				UpdateTooltip();
			}
		}
		if (tooltipResetCountdown > 0f)
		{
			tooltipResetCountdown -= TimeManager.MenuDelta;
			if (tooltipResetCountdown <= 0f)
			{
				isInImmediateTooltipMode = false;
			}
		}
		TryUpdateTooltip();
		if (lastDisplayedBaselineDelta != UserInput.baselineGlobalIncrement)
		{
			lastDisplayedBaselineDelta = UserInput.baselineGlobalIncrement;
			inputDeltaButton.label.text = "x" + TextDisplay.LocalizedNumber(UserInput.baselineGlobalIncrement);
		}
		if (isLeftLayoutStale)
		{
			UpdateLeftPanelLayouts();
		}
		TestPointerPanelDisplay();
		if (scrollCooldown > 0f)
		{
			scrollCooldown -= TimeManager.MenuDelta;
			if (scrollCooldown <= 0f)
			{
				lastScrollDir = 0;
			}
		}
		if (queuedNotificationEntitiy.type != EntityType.None)
		{
			if (GameManager.GameState == GameState.InGame && queuedNotificationEntitiy.TryAsBuilding(out var b))
			{
				AnimateConstructionComplete(b);
			}
			queuedNotificationEntitiy = EntityId.None;
		}
	}

	public void UpdateVisiblePanels()
	{
		foreach (MenuPanel value in menuPanels.Values)
		{
			value.UpdateIfVisible();
		}
		navigationPanel.UpdateIfVisible();
	}

	public void SetLoadedTownAsDisplayedTown()
	{
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in menuPanels)
		{
			menuPanel.Value.SetDisplayedTown(gm.activeTown);
		}
		foreach (MenuPanel nonModalMenu in nonModalMenus)
		{
			nonModalMenu.SetDisplayedTown(gm.activeTown);
		}
	}

	public void ApplyLoadedTownStateToMenus()
	{
		FlagAllPriorityStale();
		FlagAllProductionLimitsStale();
		FlagAllAutoAssignStale();
		FlagAllAutoClaimStale();
		FlagAllPauseStale();
		FlagAllTradeModeStale();
		navigationPanel.SetButtonVisibilityForCategory(BuildingCategory.None, isVisible: false);
		foreach (KeyValuePair<BuildingCategory, NavigationButton> recipeNavigationButton in navigationPanel.recipeNavigationButtons)
		{
			navigationPanel.SetButtonVisibilityForPanel(recipeNavigationButton.Key);
		}
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in menuPanels)
		{
			MenuPanel value = menuPanel.Value;
			value.ForceRefreshTownLayout();
			value.CalcPanelAvailability();
			navigationPanel.SetButtonVisibilityForPanel(value.panelType, value.IsNavigationButtonVisible());
			navigationPanel.CalcAlertForPanel(value);
			if (value.isBackgroundPanel)
			{
				value.ShowIfUnlocked();
			}
		}
		navigationPanel.ForceRefreshTownLayout();
		townStatsPanel.ForceRefreshTownLayout();
		questsPanel.ForceRefreshTownLayout();
		questsPanelPopup.ForceRefreshTownLayout();
		combinedProductionPanel.Show();
		if (gm.questCoinState.currentCount < 10.0)
		{
			worldPerksPanel.alertStateSelf = false;
			navigationPanel.CalcAlertForPanel(worldPerksPanel);
		}
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel2 in menuPanels)
		{
			if (!menuPanel2.Value.IsVisible())
			{
				menuPanel2.Value.gameObject.SetActive(value: false);
			}
		}
		townStatsPanel.ReloadTownDetails();
		CalcPanelAvailability();
		if (researchPanel.IsVisible() || gm.activeTown == null)
		{
			return;
		}
		foreach (ResearchState value2 in gm.activeTown.research.Values)
		{
			if (value2.availability == BuildObjectAvailability.Available && value2.isReadyToClaim)
			{
				navigationPanel.SetAlertForPanel(researchPanel, nextState: true);
			}
		}
	}

	public void OnIncrementChanged()
	{
		foreach (BuildingState value in displayedTown.buildings.Values)
		{
			value.CacheRemovalState(UserInput.activeGlobalIncrement);
		}
		FlagAllCostsStale();
		UpdateVisiblePanels();
	}

	public void FinalizeWorldLoad()
	{
		if (SaveFile.queuedProductionPanelFilter != BuildingCategory.None)
		{
			navigationPanel.SelectBuildingCategory(SaveFile.queuedProductionPanelFilter);
			SaveFile.queuedProductionPanelFilter = BuildingCategory.None;
		}
		else
		{
			navigationPanel.SelectPanel(MenuPanelType.All);
		}
		questsPanel.Show();
		inventoryPanel.Show();
		coinPanel.Show();
		welcomePanel.Hide();
		backgroundPanelRoot.gameObject.SetActive(value: true);
		modalMenuRoot.gameObject.SetActive(value: true);
		FadeLoadingCoverOut();
		townStatsPanel.useFrequentQuestUpdates = !GameManager.IsGlobalQuestComplete(Quest.FrequentProgressUpdates);
		UpdateLeftPanelLayouts();
		UpdateVisiblePanels();
	}

	private void DisplayQuestStateNotification(QuestType q, Sprite associatedSprite)
	{
		if (!(townStatsPanel.townLogItem.animatePositionProgress > 0f) || townStatsPanel.townLogItem.isCurrentNotificationPermanent)
		{
			Quest value;
			bool num = gm.globalQuests.TryGetValue(q, out value) && value.IsReadyToClaim();
			string text = TextDisplay.LabelForQuest(q);
			Notification n = new Notification(num ? TextDisplay.FormattedKeyValue("QuestComplete", text) : text, associatedSprite, null, null, permanent: true);
			townStatsPanel.townLogItem.DisplayNotification(n);
		}
	}

	public void CalcPanelAvailability()
	{
		gm.isPanelAvailabilityStale = false;
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in menuPanels)
		{
			menuPanel.Value.CalcPanelAvailability();
		}
		foreach (KeyValuePair<BuildingCategory, NavigationButton> recipeNavigationButton in navigationPanel.recipeNavigationButtons)
		{
			navigationPanel.SetButtonVisibilityForPanel(recipeNavigationButton.Key);
		}
	}

	public static void ClearGrid(Transform t)
	{
		foreach (Transform item in t)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
	}

	private void CreateTooltipOptions()
	{
		inventoryTooltipOptions = new TooltipOptions();
		inventoryTooltipOptions.tooltipAnchorPlacement = TextAnchor.MiddleRight;
		inventoryTooltipOptions.tooltipDisplayPlacement = TextAnchor.MiddleRight;
		inventoryTooltipOptions.tooltipOffset = 50f;
		inventoryTooltipOptions.tooltipCenterY = true;
		inventoryTooltipOptions.panelSize = new Vector2(1000f, 600f);
		tradeStorageTooltipOptions = new TooltipOptions();
		tradeStorageTooltipOptions.tooltipAnchorPlacement = TextAnchor.MiddleRight;
		tradeStorageTooltipOptions.tooltipDisplayPlacement = TextAnchor.MiddleRight;
		tradeStorageTooltipOptions.tooltipOffset = 10f;
		tradeStorageTooltipOptions.tooltipCenterY = true;
		tradeStorageTooltipOptions.panelSize = new Vector2(800f, 600f);
		lockedBiomeTooltipOptions = new TooltipOptions();
		lockedBiomeTooltipOptions.tooltipAnchorPlacement = TextAnchor.LowerCenter;
		lockedBiomeTooltipOptions.tooltipDisplayPlacement = TextAnchor.LowerCenter;
		lockedBiomeTooltipOptions.tooltipOffset = 10f;
		lockedBiomeTooltipOptions.tooltipCenterY = false;
		lockedBiomeTooltipOptions.panelSize = new Vector2(650f, 240f);
		centeredTooltipOptions = new TooltipOptions();
		centeredTooltipOptions.tooltipAnchorPlacement = TextAnchor.MiddleCenter;
		centeredTooltipOptions.tooltipDisplayPlacement = TextAnchor.MiddleCenter;
		centeredTooltipOptions.tooltipCenterY = true;
		centeredTooltipOptions.tooltipCenterX = true;
		centeredTooltipOptions.panelSize = new Vector2(800f, 500f);
		defaultTooltipOptions = new TooltipOptions();
		defaultTooltipOptions.tooltipAnchorPlacement = TextAnchor.MiddleRight;
		defaultTooltipOptions.tooltipDisplayPlacement = TextAnchor.MiddleRight;
		defaultTooltipOptions.tooltipCenterY = false;
		defaultTooltipOptions.tooltipCenterX = false;
		defaultTooltipOptions.tooltipOffset = 10f;
		defaultTooltipOptions.panelSize = new Vector2(800f, 500f);
		defaultTooltipOptions.allowHorizontalFlip = true;
		headerInfoTooltipOptions = new TooltipOptions();
		headerInfoTooltipOptions.tooltipAnchorPlacement = TextAnchor.MiddleRight;
		headerInfoTooltipOptions.tooltipDisplayPlacement = TextAnchor.MiddleRight;
		headerInfoTooltipOptions.tooltipOffset = 20f;
		headerInfoTooltipOptions.tooltipCenterY = true;
		headerInfoTooltipOptions.panelSize = new Vector2(800f, 600f);
		currencyTooltipOptions = new TooltipOptions();
		currencyTooltipOptions.tooltipAnchorPlacement = TextAnchor.MiddleCenter;
		currencyTooltipOptions.tooltipDisplayPlacement = TextAnchor.MiddleCenter;
		currencyTooltipOptions.tooltipOffset = 0f;
		currencyTooltipOptions.tooltipCenterY = true;
		currencyTooltipOptions.tooltipCenterX = true;
		recipeLabelTooltipOptions = new TooltipOptions();
		recipeLabelTooltipOptions.tooltipAnchorPlacement = TextAnchor.MiddleLeft;
		recipeLabelTooltipOptions.tooltipDisplayPlacement = TextAnchor.MiddleRight;
		recipeLabelTooltipOptions.tooltipOffset = 200f;
		recipeLabelTooltipOptions.panelSize = new Vector2(800f, 500f);
		recipeLabelTooltipOptions.tooltipCenterY = true;
		rewardTooltipOptions = new TooltipOptions();
		rewardTooltipOptions.tooltipAnchorPlacement = TextAnchor.LowerCenter;
		rewardTooltipOptions.tooltipDisplayPlacement = TextAnchor.LowerCenter;
		rewardTooltipOptions.tooltipOffset = 0f;
		rewardTooltipOptions.panelSize = new Vector2(600f, 300f);
		rewardTooltipOptions.tooltipCenterY = false;
		rewardTooltipOptions.tooltipCenterX = false;
	}

	public void CreatePanels()
	{
		CreateTooltipOptions();
		textEntryPanel = AddModalMenuPanel<TextEntryPanel>(MenuPanelType.TextEntry, textEntryPanelPrefab, "Text Entry");
		productionLimitPanel = AddModalMenuPanel<ProductionLimitPanel>(MenuPanelType.ProductionConfig, productionConfigPanelPrefab, "ProductionTarget");
		recipeConfigPanel = AddModalMenuPanel<RecipeConfigPanel>(MenuPanelType.RecipeConfig, recipeConfigPanelPrefab, "Recipe");
		modalMenuRoot.gameObject.SetActive(value: true);
		tradingHeaderCollapseManager = new HeaderCollapseManager();
		searchHeader.searchChangeDelegate = OnSearchTextChanged;
		searchHeader.searchClearDelegate = OnClearSearchButtonPressed;
		searchHeader.Initialize();
		AddBuiltInMenu(townStatsPanel, MenuPanelType.TownStats, "TownStats");
		tooltipPanel = AddModalMenuPanel<TooltipPanel>(MenuPanelType.Tooltip, tooltipPanelPrefab, "Tooltip");
		constructionDetailsPanel = AddModalMenuPanel<ConstructionDetailsPanel>(MenuPanelType.ConstructionDetails, constructionDetailsPanelPrefab, null);
		rewardPanel = AddModalMenuPanel<RewardPanel>(MenuPanelType.Reward, rewardPanelPrefab, "Reward");
		gameMenuPanel = AddModalMenuPanel<GameMenuPanel>(MenuPanelType.GameMenu, gameMenuPrefab, "Menu");
		fileListPanel = AddModalMenuPanel<FileListPanel>(MenuPanelType.FileList, fileListPanelPrefab, "Menu");
		gameSetupPanel = AddModalMenuPanel<GameSetupPanel>(MenuPanelType.GameSetup, gameSetupPanelPrefab, "Menu");
		fullGameVersionPanel = AddModalMenuPanel<FullGameVersionPanel>(MenuPanelType.FullGame, fullGameVersionPanelPrefab, "FullVersionDetails");
		creditsPanel = AddModalMenuPanel<CreditsPanel>(MenuPanelType.Credits, creditsPanelPrefab, "MenuCredits");
		popupMenu = AddModalMenuPanel<PopupMenu>(MenuPanelType.PopupMenu, popupMenuPrefab, "Menu");
		optionsPanel = AddModalMenuPanel<OptionsPanel>(MenuPanelType.Options, optionsPanelPrefab, "MenuFunctionOptions");
		controlsPanel = AddModalMenuPanel<ControlsPanel>(MenuPanelType.Controls, controlsPanelPrefab, "MenuFunctionControls");
		worldPanel = AddModalMenuPanel<WorldPanel>(MenuPanelType.World, worldPanelPrefab, "World");
		worldPerksPanel = AddModalMenuPanel<PerksPanel>(MenuPanelType.Perks, worldPerksPanelPrefab, "WorldPerks");
		victoryPanel = AddModalMenuPanel<VictoryPanel>(MenuPanelType.Victory, victoryPanelPrefab, "Victory");
		levelUpRewardPanel = AddModalMenuPanel<LevelUpRewardPanel>(MenuPanelType.LevelUpRewards, levelUpRewardsPanelPrefab, "LevelUpExclamation");
		biomeUnlockPanel = AddModalMenuPanel<BiomeUnlockPanel>(MenuPanelType.BiomeUnlock, biomeUnlockPanelPrefab, "LevelUpExclamation");
		worldPerksPanel.isGlobal = true;
		researchPanel = AddModalMenuPanel<ResearchPanel>(MenuPanelType.Research, researchPanelPrefab, "Research");
		buildingsPanel = AddModalMenuPanel<BuildingsPanel>(MenuPanelType.Buildings, buildingsPanelPrefab, "Construction");
		upgradesPanel = AddModalMenuPanel<UpgradesPanel>(MenuPanelType.Upgrades, upgradesPanelPrefab, "Upgrades");
		inventoryPanel = AddSubMenuPanel<InventoryPanel>(MenuPanelType.Inventory, inventoryPanelPrefab, "Inventory", leftBottomPanelRoot);
		questsPanel = AddSubMenuPanel<QuestsPanel>(MenuPanelType.Quests, questsPanelPrefab, "Quests", leftMiddlePanelRoot);
		coinPanel = AddSubMenuPanel<CoinPanel>(MenuPanelType.Coins, coinsPanelPrefab, "Coins", coinRegionRoot);
		questsPanelPopup = AddModalMenuPanel<QuestsPanel>(MenuPanelType.QuestsPopup, questsPanelPrefab, "Quests");
		inventoryPanelPopup = AddModalMenuPanel<InventoryPanel>(MenuPanelType.InventoryPopup, inventoryPanelPrefab, "Inventory");
		logPanel = AddModalMenuPanel<LogPanel>(MenuPanelType.Log, logPanelPrefab, "Notifications");
		townPerksPanel = AddModalMenuPanel<PerksPanel>(MenuPanelType.TownPerks, townPerksPanelPrefab, "TownPerks");
		townResetPanel = AddModalMenuPanel<TownResetPanel>(MenuPanelType.TownReset, townResetPanelPrefab, "TownReset");
		playerPromptPanel = AddModalMenuPanel<PlayerPromptPanel>(MenuPanelType.PlayerPrompt, playerPromptPanelPrefab, null);
		biomeSelectionPanel = AddModalMenuPanel<BiomeSelectionPanel>(MenuPanelType.BiomeSelection, biomeSelectionPanelPrefab, null);
		idleProgressPanel = AddModalMenuPanel<IdleGainPanel>(MenuPanelType.IdleProgress, idleProgressPanelPrefab, null);
		timeTokensPanel = AddModalMenuPanel<TimeTokensPanel>(MenuPanelType.TimeTokens, timeTokensPanelPrefab, "TimeManagement");
		combinedProductionPanel = AddCenterMenuPanel<ProductionListPanelCombined>(MenuPanelType.CombinedProduction, combinedProductionPanelPrefab, "Crafting");
		playerMessageItem.isCenterNotification = true;
		nonModalMenus.Add(navigationPanel);
		foreach (MenuPanel nonModalMenu in nonModalMenus)
		{
			nonModalMenu.targetVisibilityState = true;
			if (canvasMode)
			{
				nonModalMenu.AddCanvas();
			}
		}
		navigationPanel.Initialize();
		navigationPanel.Hide();
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in menuPanels)
		{
			menuPanel.Value.Initialize();
			menuPanel.Value.Hide();
		}
		searchToggleButton.AddPointerClickTrigger(OnSearchTogglePressed);
		SetSearchActive(nextState: false);
		combinedProductionPanel.transform.SetSiblingIndex(0);
		welcomePanel.CreateItems();
		optionsPanel.CreateItems();
		controlsPanel.CreateItems();
		gameMenuPanel.CreateItems();
		navigationPanel.CreateItems();
		upgradesPanel.FormatAsPopup(isPopup: true);
		inventoryPanelPopup.FormatAsPopup();
		inputDeltaButton.InitializeButton();
		inputDeltaButton.buttonState = CustomButtonState.Default;
		inputDeltaButton.AddPointerClickTrigger(OnInputDeltaPressed);
		inputDeltaButton.highlightTextDelegate = InputDeltaTooltip;
		inputDeltaButton.animateSize = true;
	}

	public void CreatePanelContents()
	{
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in menuPanels)
		{
			if (null != menuPanel.Value.header)
			{
				menuPanel.Value.header.UpdateDisplay();
			}
		}
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel2 in menuPanels)
		{
			if (!menuPanel2.Value.hasCreatedItems)
			{
				menuPanel2.Value.CreateItems();
			}
		}
		navigationPanel.CreateNavigationButtons();
		if (null != minigameSelectionPanel)
		{
			minigameSelectionPanel.CreateItems();
		}
	}

	public string HeaderKeyForPanel(MenuPanelType t)
	{
		if (menuPanels.TryGetValue(t, out var value))
		{
			return value.headerLocalizationKey;
		}
		return null;
	}

	public void FlagAllCostsStale()
	{
		buildingsPanel.arePanelCostsStale = true;
		buildingsPanel.areCountsStale = true;
		upgradesPanel.arePanelCostsStale = true;
		combinedProductionPanel.arePanelCostsStale = true;
	}

	public void FlagAllTownLinksStale()
	{
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in menuPanels)
		{
			menuPanel.Value.isTownLayoutStale = true;
		}
	}

	public void FlagAllSimulationDataStale()
	{
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in menuPanels)
		{
			menuPanel.Value.isSimulationDataStale = true;
		}
		if (null != highlightedMenuButton && highlightedMenuButton.isTooltipUpdatedEverySimulationStep)
		{
			isTooltipStale = true;
		}
		tooltipPanel.isSimulationDataStale = true;
		upgradesPanel.isSimulationDataStale = true;
		researchPanel.isSimulationDataStale = true;
		timeTokensPanel.isSimulationDataStale = true;
	}

	public void FlagAllAvailabilityStale()
	{
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in menuPanels)
		{
			menuPanel.Value.isItemAvailabilityStale = true;
		}
	}

	public void FlagAllAutoAssignStale()
	{
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in menuPanels)
		{
			menuPanel.Value.isAutoAssignStale = true;
		}
	}

	public void FlagAllTradeModeStale()
	{
		combinedProductionPanel.isTradeModeStale = true;
	}

	public void FlagAllAutoClaimStale()
	{
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in menuPanels)
		{
			menuPanel.Value.isAutoClaimStale = true;
		}
	}

	public void FlagAllPauseStale()
	{
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in menuPanels)
		{
			menuPanel.Value.isPauseStale = true;
		}
	}

	public void FlagAllProductionLimitsStale()
	{
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in menuPanels)
		{
			menuPanel.Value.isProductionLimitStale = true;
		}
	}

	public void FlagAllPriorityStale()
	{
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in menuPanels)
		{
			menuPanel.Value.isPriorityStale = true;
		}
	}

	public void ResetMenuState()
	{
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in menuPanels)
		{
			menuPanel.Value.ResetPanel();
		}
		if (null != minigameSelectionPanel)
		{
			minigameSelectionPanel.ResetPanel();
		}
		navigationPanel.ResetPanel();
		townStatsPanel.ResetPanel();
		pointerDelayCounter = 0f;
	}

	public void ReloadLabels()
	{
		foreach (KeyValuePair<MenuPanelType, MenuPanel> menuPanel in menuPanels)
		{
			if (menuPanel.Value.hasCreatedItems)
			{
				menuPanel.Value.ReloadLabels();
			}
			else
			{
				menuPanel.Value.isLabelReloadQueued = true;
			}
		}
		foreach (MenuPanel nonModalMenu in nonModalMenus)
		{
			nonModalMenu.ReloadLabels();
		}
		welcomePanel.ReloadLabels();
		loadingLabel.text = "Loading".Localized() + "...";
	}

	public static GameObject InstantiatedTextAlert(Transform parent)
	{
		GameObject menuObject = GetMenuObject(_instance.alertPrefab, parent);
		RectTransform component = menuObject.GetComponent<RectTransform>();
		component.SetPosX(5f);
		component.SetPosY(0f);
		component.anchorMin = new Vector2(1f, 0.5f);
		component.anchorMax = new Vector2(1f, 0.5f);
		component.pivot = new Vector2(0f, 0.5f);
		return menuObject;
	}

	public static CraftingSectionHeader InstantiatedSectionHeader(Transform parent)
	{
		CraftingSectionHeader component = GetMenuObject(_instance.sectionHeaderPrefab, parent).GetComponent<CraftingSectionHeader>();
		component.Initialize();
		if (useDynamicSizing)
		{
			if (component.TryGetComponent<LayoutGroup>(out var component2))
			{
				component2.enabled = false;
			}
			if (component.TryGetComponent<ContentSizeFitter>(out var component3))
			{
				component3.enabled = false;
			}
		}
		return component;
	}

	public static SectionHeader InstantiatedSimpleSectionHeaderTall(Transform parent, string localizationKey)
	{
		SectionHeader component = GetMenuObject(_instance.simpleSectionHeaderTallPrefab, parent).GetComponent<SectionHeader>();
		component.Initialize();
		component.localizationKey = localizationKey;
		return component;
	}

	public static SectionHeader InstantiatedSimpleSectionHeader(Transform parent, string localizationKey)
	{
		SectionHeader component = GetMenuObject(_instance.simpleSectionHeaderPrefab, parent).GetComponent<SectionHeader>();
		component.Initialize();
		component.localizationKey = localizationKey;
		return component;
	}

	public static Transform InstantiatedSectionGroup(Transform parent)
	{
		return GetMenuObject(_instance.sectionGroupPrefab, parent).transform;
	}

	public static GameObject GetMenuObject(GameObject prefab, Transform parent)
	{
		GameObject obj = UnityEngine.Object.Instantiate(prefab, parent);
		obj.transform.localScale = Vector3.one;
		return obj;
	}

	public bool HideTopDismissableModalMenu()
	{
		int count = modalMenuStack.Count;
		if (count > 0)
		{
			MenuPanel menuPanel = modalMenuStack[count - 1];
			if (menuPanel == levelUpRewardPanel)
			{
				levelUpRewardPanel.OnBackgroundClick();
			}
			else if (menuPanel == biomeUnlockPanel)
			{
				biomeUnlockPanel.OnBackgroundClick();
			}
			else
			{
				if (menuPanel.isPinned)
				{
					menuPanel.Unpin();
				}
				menuPanel.Hide();
			}
			return true;
		}
		return false;
	}

	private void UpdateClickableBackground()
	{
		if (modalMenuStack.Count > 0)
		{
			for (int num = modalMenuStack.Count - 1; num >= 0; num--)
			{
				MenuPanel menuPanel = modalMenuStack[num];
				if (DoesPanelCategoryBlockBackground(menuPanel.panelCategory))
				{
					int siblingIndex = menuPanel.transform.GetSiblingIndex();
					if (siblingIndex == 0)
					{
						modalBackgroundImage.transform.SetAsFirstSibling();
					}
					else
					{
						modalBackgroundImage.transform.SetSiblingIndex(siblingIndex - 1);
					}
					SetDismissableBackground(nextState: true);
					return;
				}
			}
		}
		SetDismissableBackground(nextState: false);
	}

	public void ShowMenu(MenuPanel m)
	{
		if (null != m)
		{
			if (IsCategoryInModalStack(m.panelCategory))
			{
				modalMenuStack.Remove(m);
				modalMenuStack.Add(m);
				m.TrySendToFront();
				UpdateClickableBackground();
			}
			SetPanelState(m, state: true);
			if (gm.gameState == GameState.InGame)
			{
				m.alertStateSelf = false;
				navigationPanel.CalcAlertForPanel(m);
			}
		}
	}

	public void SetPanelState(MenuPanel m, bool state)
	{
		m.targetVisibilityState = state;
		bool flag = canvasMode && !m.ShouldBecomeInactiveOnHide();
		if (flag)
		{
			if (!m.gameObject.activeSelf)
			{
				m.gameObject.SetActive(value: true);
			}
			if (null == m.canvas)
			{
				m.AddCanvas();
			}
		}
		else if (null != m.canvas)
		{
			m.canvas.enabled = true;
		}
		if (null != m.canvas && flag)
		{
			m.canvas.enabled = state;
		}
		else
		{
			m.gameObject.SetActive(state);
		}
	}

	public void HideMenu(MenuPanel m)
	{
		if (null == m)
		{
			UnityEngine.Debug.LogWarning("Can't hide null menu!");
		}
		else if (m.IsVisible())
		{
			if (modalMenuStack.Contains(m))
			{
				modalMenuStack.Remove(m);
				UpdateClickableBackground();
			}
			SetPanelState(m, state: false);
			if (m.alertStateSelf)
			{
				m.alertStateSelf = false;
				navigationPanel.CalcAlertForPanel(m);
			}
		}
	}

	public static float AnimatedProgress(float currentDisplayedValue, float targetValue)
	{
		if (targetValue > currentDisplayedValue)
		{
			currentDisplayedValue = Mathf.Lerp(currentDisplayedValue, targetValue, 0.05f);
		}
		else if (targetValue < currentDisplayedValue)
		{
			currentDisplayedValue = Mathf.Lerp(currentDisplayedValue, targetValue + 1f, 0.05f);
			if (currentDisplayedValue >= 0.99f)
			{
				currentDisplayedValue -= 1f;
			}
		}
		return currentDisplayedValue;
	}

	public void NavigateToEntity(EntityId id)
	{
		BuildingType b;
		ResearchType i;
		NaturalResource i2;
		NaturalResource i3;
		NaturalResource i4;
		if (id.TryAsRecipe(out var r))
		{
			if (gm.activeTown.recipes.TryGetValue(r, out var value))
			{
				combinedProductionPanel.JumpToState(value);
			}
		}
		else if (id.TryAsBuilding(out b))
		{
			buildingsPanel.QueueJumpToBuilding(b);
		}
		else if (id.TryAsResearch(out i))
		{
			researchPanel.JumpToResearch(i);
		}
		else if (id.TryAsFarming(out i2))
		{
			combinedProductionPanel.JumpToResource(i2);
		}
		else if (id.TryAsMining(out i3))
		{
			combinedProductionPanel.JumpToResource(i3);
		}
		else if (id.TryAsNaturalResource(out i4))
		{
			combinedProductionPanel.JumpToResource(i4);
		}
	}

	public void NavigateToProductionOutput(ItemType t)
	{
		if (gm.activeTown.inventory.TryGetValue(t, out var value))
		{
			NavigateToCountableState(value);
		}
	}

	public void JumpToAndSelectResearch(ResearchType t)
	{
		tooltipPanel.LoadEntityDescription(EntityId.FromResearch(t));
		if (researchPanel.IsVisible() && gm.activeTown.research.TryGetValue(t, out var value))
		{
			researchPanel.JumpToAndSelectResearch(value);
		}
	}

	public bool TryNavigateToRequirementRecursively(Requirement req)
	{
		if (!(req is RequiredQuest requiredQuest))
		{
			if (!(req is RequiredResearch requiredResearch))
			{
				if (req is RequiredMinBuildingCount requiredMinBuildingCount)
				{
					RequiredMinBuildingCount requiredMinBuildingCount2 = requiredMinBuildingCount;
					BuildingState value;
					if (requiredMinBuildingCount2.buildingType == BuildingType.Base)
					{
						worldPanel.ManuallyOpen();
					}
					else if (gm.activeTown.buildings.TryGetValue(requiredMinBuildingCount2.buildingType, out value))
					{
						if (value.availability == BuildObjectAvailability.Available)
						{
							buildingsPanel.Show();
							buildingsPanel.QueueJumpToBuilding(requiredMinBuildingCount2.buildingType);
							return true;
						}
						NavigateToRequirementRecursively(value.unlockRequirements.requirements);
						return true;
					}
					return false;
				}
				if (req is RequiredProductionCount { itemType: var itemType })
				{
					NavigateToProductionOutput(itemType);
					return true;
				}
				HarvestState value2;
				if (!(req is RequiredGenericCount))
				{
					if (req is RequiredCoinSpendCount)
					{
						upgradesPanel.Show();
						return true;
					}
					if (req is RequiredMinigameLevel requiredMinigameLevel)
					{
						RequiredMinigameLevel requiredMinigameLevel2 = requiredMinigameLevel;
						navigationPanel.SelectPanel(requiredMinigameLevel2.minigamePanelType);
						return true;
					}
					if (!(req is RequiredTownLevel requiredTownLevel))
					{
						if (!(req is RequiredSkillLevel requiredSkillLevel))
						{
							if (req is RequiredUpgrade || req is RequiredUpgradeCount)
							{
								navigationPanel.SelectPanel(MenuPanelType.Upgrades);
								return true;
							}
							if (req is RequiredPerk requiredPerk)
							{
								RequiredPerk requiredPerk2 = requiredPerk;
								if (Crafting.globalPerks.Contains(requiredPerk2.perkType))
								{
									worldPerksPanel.ManuallyOpen();
								}
								else
								{
									townPerksPanel.ManuallyOpen();
								}
								return true;
							}
							if (!(req is RequiredSkillLevelCount requiredSkillLevelCount))
							{
								if (!(req is RequiredSkillXP requiredSkillXP))
								{
									if (req is RequiredBuildingSkills { buildingType: var buildingType })
									{
										switch (buildingType)
										{
										case BuildingType.Farm:
										case BuildingType.Forester:
										case BuildingType.Fishery:
											navigationPanel.SelectPanel(MenuPanelType.CombinedProduction);
											return true;
										case BuildingType.Mine:
										case BuildingType.Quarry:
										case BuildingType.GemMine:
											navigationPanel.SelectPanel(MenuPanelType.CombinedProduction);
											return true;
										default:
											navigationPanel.SelectPanel(MenuPanelType.CombinedProduction);
											return true;
										}
									}
									if (req is RequiredMinResearchCount)
									{
										researchPanel.Show();
										return true;
									}
									if (req is RequiredItem { itemType: var itemType2 })
									{
										switch (itemType2)
										{
										case ItemType.Steel:
											NavigateToEntity(EntityId.FromRecipe(RecipeType.MakeSteel));
											return true;
										case ItemType.CopperWire:
											NavigateToEntity(EntityId.FromRecipe(RecipeType.MakeCopperWire));
											return true;
										case ItemType.ResearchTomeIndustry2:
											NavigateToEntity(EntityId.FromRecipe(RecipeType.MakeTomeIndustry2));
											return true;
										case ItemType.Quartz:
											NavigateToEntity(EntityId.FromRecipe(RecipeType.MakeQuartzFromStone));
											return true;
										case ItemType.Pickaxe:
											NavigateToEntity(EntityId.FromRecipe(RecipeType.MakePickaxe));
											return true;
										case ItemType.WoodAxe:
											NavigateToEntity(EntityId.FromRecipe(RecipeType.MakeWoodAxe));
											return true;
										default:
											return false;
										}
									}
								}
								else
								{
									if (requiredSkillXP.skillType == SkillType.Crafting)
									{
										navigationPanel.SelectPanel(MenuPanelType.CombinedProduction);
										return true;
									}
									if (requiredSkillXP.skillType == SkillType.Cultivation)
									{
										navigationPanel.SelectPanel(MenuPanelType.CombinedProduction);
										return true;
									}
									if (requiredSkillXP.skillType == SkillType.Prospecting)
									{
										navigationPanel.SelectPanel(MenuPanelType.CombinedProduction);
										return true;
									}
									if (requiredSkillXP.skillType == SkillType.Harvesting)
									{
										navigationPanel.SelectPanel(MenuPanelType.CombinedProduction);
										return true;
									}
								}
							}
							else
							{
								if (requiredSkillLevelCount.skillType == SkillType.Crafting)
								{
									navigationPanel.SelectPanel(MenuPanelType.CombinedProduction);
									return true;
								}
								if (requiredSkillLevelCount.skillType == SkillType.Cultivation)
								{
									navigationPanel.SelectPanel(MenuPanelType.CombinedProduction);
									return true;
								}
								if (requiredSkillLevelCount.skillType == SkillType.Prospecting)
								{
									navigationPanel.SelectPanel(MenuPanelType.CombinedProduction);
									return true;
								}
								if (requiredSkillLevelCount.skillType == SkillType.Harvesting)
								{
									navigationPanel.SelectPanel(MenuPanelType.CombinedProduction);
									return true;
								}
							}
						}
						else
						{
							RequiredSkillLevel requiredSkillLevel2 = requiredSkillLevel;
							if (!requiredSkillLevel2.skillId.TryAsNaturalResource(out var i))
							{
								RequiredSkillLevel requiredSkillLevel3 = requiredSkillLevel;
								NavigateToEntity(requiredSkillLevel3.skillId);
								return true;
							}
							if (requiredSkillLevel2.skillType == SkillType.Harvesting)
							{
								NavigateToEntity(requiredSkillLevel2.skillId);
								return true;
							}
							if (requiredSkillLevel2.skillType == SkillType.Prospecting)
							{
								NavigateToEntity(EntityId.FromMining(i));
								return true;
							}
							if (requiredSkillLevel2.skillType == SkillType.Cultivation)
							{
								NavigateToEntity(EntityId.FromFarming(i));
								return true;
							}
						}
					}
					else
					{
						RequiredTownLevel requiredTownLevel2 = requiredTownLevel;
						if (requiredTownLevel2.requiredBiome != BiomeType.None && requiredTownLevel2.requiredBiome != gm.activeTown.biomeType)
						{
							worldPanel.ManuallyOpen();
							return true;
						}
					}
				}
				else if (gm.activeTown.harvesting.TryGetValue(HarvestRecipeType.Tree, out value2))
				{
					combinedProductionPanel.QueueJumpToItemWithLinkedObject(value2);
				}
			}
			else
			{
				RequiredResearch requiredResearch2 = requiredResearch;
				if (gm.activeTown.research.TryGetValue(requiredResearch2.researchType, out var value3))
				{
					if (researchPanel.isLocked)
					{
						if (!GameManager.IsGlobalQuestComplete(Quest.ResourceUnlockQuestRock))
						{
							questsPanel.QueueJumpToQuest(Quest.ResourceUnlockQuestRock);
							return true;
						}
						if (!GameManager.IsGlobalQuestComplete(QuestType.MilestoneHouses10))
						{
							questsPanel.QueueJumpToQuest(QuestType.MilestoneHouses10);
							return true;
						}
						if (!GameManager.IsGlobalQuestComplete(QuestType.HousesForSchool))
						{
							questsPanel.QueueJumpToQuest(QuestType.HousesForSchool);
							return true;
						}
						if (!GameManager.IsGlobalQuestComplete(QuestType.SchoolForResearchPanel))
						{
							questsPanel.QueueJumpToQuest(QuestType.SchoolForResearchPanel);
							return true;
						}
						return false;
					}
					researchPanel.JumpToState(value3);
					return true;
				}
			}
			return false;
		}
		RequiredQuest requiredQuest2 = requiredQuest;
		if (questsPanelPopup.QueueJumpToQuest(requiredQuest2.questType))
		{
			questsPanelPopup.Show();
			return true;
		}
		return false;
	}

	public bool NavigateToRequirementRecursively(List<Requirement> reqs)
	{
		foreach (Requirement req in reqs)
		{
			if (!req.IsMet() && TryNavigateToRequirementRecursively(req))
			{
				return true;
			}
		}
		return false;
	}

	public void SetAsNavigationEntity(EntityId id)
	{
		activeNavigationEntity = id.GetCopy();
	}

	public void TryAddToNavigationStack(EntityId id)
	{
		navigationStackReverse.Clear();
		if (navigationStack.Count <= 0 || !navigationStack.Peek().Equals(id))
		{
			navigationStack.Push(id);
			navigationStackReverse.Clear();
		}
	}

	[Conditional("UNITY_EDITOR")]
	private void DebugNavigationStack()
	{
		StringBuilder sb = TextDisplay.sb;
		sb.Clear();
		sb.Append("Active: " + activeNavigationEntity);
		sb.Append("...REGULAR Nav Stack: " + navigationStack.Count);
		if (navigationStack.Count == 0)
		{
			sb.Append(" = Empty");
		}
		else
		{
			foreach (EntityId item in navigationStack)
			{
				sb.Append(", " + item);
			}
		}
		sb.Append("...REVERSE Nav Stack: " + navigationStackReverse.Count);
		if (navigationStackReverse.Count == 0)
		{
			sb.Append(" = Empty");
			return;
		}
		foreach (EntityId item2 in navigationStackReverse)
		{
			sb.Append(", " + item2);
		}
	}

	public void NavigateForward()
	{
		if (navigationStackReverse.TryPop(out var result))
		{
			if (activeNavigationEntity.type != EntityType.None)
			{
				navigationStack.Push(activeNavigationEntity);
			}
			NavigateToEntity(result);
		}
	}

	public void NavigateBack()
	{
		if (navigationStack.TryPop(out var result))
		{
			if (activeNavigationEntity.type != EntityType.None)
			{
				navigationStackReverse.Push(activeNavigationEntity);
			}
			NavigateToEntity(result);
		}
	}

	public void NavigateToStateManager(StateManager sm)
	{
		if (MenuPanelForState(sm) is MenuListPanel menuListPanel)
		{
			menuListPanel.QueueJumpToItemWithLinkedObject(sm);
		}
	}

	public void ApplyStateManagerFilter(StateManager state)
	{
		searchHeader.searchField.text = string.Empty;
		combinedProductionPanel.ClearAllSearchProperties();
		navigationPanel.SelectBuildingCategory(BuildingCategory.None, sendEvent: false);
		combinedProductionPanel.itemFilter = state;
		researchPanel.Hide();
		upgradesPanel.Hide();
		OnSearchPropertiesChanged();
	}

	public void ApplyCountableStateFilter(CountableState state)
	{
		searchHeader.searchField.text = string.Empty;
		combinedProductionPanel.ClearAllSearchProperties();
		navigationPanel.SelectBuildingCategory(BuildingCategory.None, sendEvent: false);
		combinedProductionPanel.itemFilter = state;
		researchPanel.Hide();
		upgradesPanel.Hide();
		OnSearchPropertiesChanged();
	}

	public void NavigateToCountableState(CountableState state)
	{
		if (state is ItemState itemState)
		{
			if (itemState.type == ItemType.YellowCoin || itemState.type == ItemType.RedCoin || itemState.type == ItemType.BlueCoin || itemState.type == ItemType.PurpleCoin || itemState.type == ItemType.OmniCoin)
			{
				if (itemState.type == ItemType.YellowCoin && displayedTown.buildings.TryGetValue(BuildingType.GeneralGoods, out var value) && value.availability != BuildObjectAvailability.Available)
				{
					if (!GameManager.IsGlobalQuestComplete(QuestType.GeneralStoreForMarketPanel))
					{
						questsPanelPopup.QueueJumpToQuest(QuestType.GeneralStoreForMarketPanel);
					}
					else
					{
						NavigateToRequirementRecursively(value.unlockRequirements.requirements);
					}
					return;
				}
				if (itemState.type == ItemType.OmniCoin && displayedTown.buildings[BuildingType.ArcaneStore].availability != BuildObjectAvailability.Available)
				{
					NavigateToRequirementRecursively(displayedTown.buildings[BuildingType.ArcaneStore].unlockRequirements.requirements);
				}
			}
			if (!itemState.isLocked)
			{
				ApplyCountableStateFilter(itemState);
				combinedProductionPanel.HighlightRecipesWithOutput(itemState);
			}
			else if (!combinedProductionPanel.TryJumpToOutputItem(itemState.type) && !TryJumpToTrading(itemState.type))
			{
				tooltipPanel.LoadEntityDescription(EntityId.FromItem(itemState.type));
				tooltipPanel.Pin();
			}
			return;
		}
		if (state is ResourceState resourceState)
		{
			ApplyCountableStateFilter(resourceState);
			combinedProductionPanel.JumpToResource(resourceState.type);
			return;
		}
		if (state is BuildingState buildingState)
		{
			{
				foreach (KeyValuePair<BuildingType, BuildingState> building in displayedTown.buildings)
				{
					if (building.Value == buildingState)
					{
						buildingsPanel.QueueJumpToItemWithLinkedObject(buildingState);
					}
				}
				return;
			}
		}
		if (state is WorkerState && displayedTown.buildings.TryGetValue(BuildingType.House, out var value2))
		{
			buildingsPanel.QueueJumpToItemWithLinkedObject(value2);
		}
	}

	private bool TryJumpToTrading(ItemType t)
	{
		if (displayedTown.trading.TryGetValue(t, out var value) && !value.globalWarehouseState.isLocked)
		{
			combinedProductionPanel.JumpToState(value);
			return true;
		}
		return false;
	}

	public MenuPanel MenuPanelForState(object state)
	{
		if (state is RecipeState)
		{
			return combinedProductionPanel;
		}
		if (state is FarmingState)
		{
			return combinedProductionPanel;
		}
		if (state is MiningState)
		{
			return combinedProductionPanel;
		}
		if (state is SellState)
		{
			return combinedProductionPanel;
		}
		if (state is HarvestState)
		{
			return combinedProductionPanel;
		}
		if (state is ResearchState)
		{
			return researchPanel;
		}
		if (state is TradingState)
		{
			return combinedProductionPanel;
		}
		if (state is BuildingState || state is ConstructionState)
		{
			return combinedProductionPanel;
		}
		if (state is Upgrade || state is UpgradeLevel)
		{
			return upgradesPanel;
		}
		if (state is PerkState perkState)
		{
			if (perkState.perk.isGlobal)
			{
				return worldPerksPanel;
			}
			return townPerksPanel;
		}
		if (state is ResourceState || state is ItemState)
		{
			return inventoryPanel;
		}
		UnityEngine.Debug.LogError("No menu panel for " + state);
		return null;
	}

	public void JumpToState(StateManager state)
	{
		MenuPanel menuPanel = MenuPanelForState(state);
		if (menuPanel is ProductionListPanel productionListPanel)
		{
			productionListPanel.JumpToState(state);
		}
		else if (menuPanel is BuildingsPanel buildingsPanel)
		{
			buildingsPanel.JumpToState(state);
		}
	}

	public void OnStateLostAlertDuringGame(object state)
	{
		MenuPanel menuPanel = MenuPanelForState(state);
		if (null != menuPanel)
		{
			navigationPanel.CalcAlertForPanel(menuPanel);
		}
	}

	public void OnStateBecameAvailableInActiveTownDuringGame(object state)
	{
		if (GameManager.everythingUnlocked)
		{
			return;
		}
		MenuPanel menuPanel = MenuPanelForState(state);
		if (null != menuPanel)
		{
			_ = state is UpgradeLevel;
			menuPanel.isItemAvailabilityStale = true;
			if (menuPanel is ProductionListPanel productionListPanel)
			{
				productionListPanel.isBuildingDataStale = true;
			}
			if (!menuPanel.IsVisible())
			{
				menuPanel.AddAlertState();
			}
		}
	}

	public void SetParticlesMode(bool enable)
	{
		isInParticlesMode = enable;
		if (TryGetComponent<Canvas>(out var component))
		{
			if (enable)
			{
				component.renderMode = RenderMode.ScreenSpaceCamera;
				component.worldCamera = StartupManager.Instance.mainCamera;
			}
			else
			{
				component.renderMode = RenderMode.ScreenSpaceOverlay;
				component.worldCamera = null;
			}
		}
	}

	public void AnimateText(string text, Vector3 origin)
	{
		float num = (GameUtility.BoolWithProbability(0.5f) ? 1f : (-1f));
		float num2 = UnityEngine.Random.Range(0f, 0.1f) * num;
		float num3 = UnityEngine.Random.Range(0f, 0.1f);
		Vector3 vector = new Vector3(origin.x + num2, origin.y + num3);
		AnimateText(to: new Vector3(vector.x, vector.y + 1f, origin.z), text: text, from: vector);
	}

	public void AnimateSingleItem(EntityId earnedItem, double amount, Vector3 origin)
	{
		float num = (GameUtility.BoolWithProbability(0.5f) ? 1f : (-1f));
		float num2 = UnityEngine.Random.Range(0f, 0.2f) * num;
		float num3 = UnityEngine.Random.Range(0f, 0.2f);
		Vector3 vector = new Vector3(origin.x + num2, origin.y + num3);
		AnimateItem(to: new Vector3(vector.x, vector.y + 1f, origin.z), t: earnedItem, count: 1, totalValue: amount, from: vector, onCompleted: null, showValue: true);
	}

	public void AnimateSingleItem(EntityId earnedItem, double amount, Vector3 origin, float xOffsetDir, float yOffset = 0f)
	{
		float num = (GameUtility.BoolWithProbability(0.5f) ? 1f : (-1f));
		float num2 = UnityEngine.Random.Range(0f, 0.4f) * num;
		float num3 = UnityEngine.Random.Range(0f, 0.4f);
		Vector3 vector = new Vector3(origin.x + num2, origin.y + num3);
		AnimateItem(to: new Vector3(vector.x, vector.y + 1f, origin.z), t: earnedItem, count: 1, totalValue: amount, from: vector, onCompleted: null, showValue: true);
	}

	public void AnimateText(string text, Vector3 from, Vector3 to)
	{
		AnimatedIcon animatedIcon = animatedIconPool.Get();
		animatedIcon.imageIcon.enabled = false;
		animatedIcon.label.text = text;
		animatedIcon.onCompleted = null;
		animatedIcon.displayedEntity = EntityId.None;
		float duration = 1f + UnityEngine.Random.Range(-0.3f, 0.2f);
		animatedIcon.Animate(from, to, duration, 0.0);
	}

	public void AnimateItem(EntityId t, int count, double totalValue, Vector3 from, Vector3 to, AnimatedIcon.OnIconAnimationCompleted onCompleted = null, bool showValue = false)
	{
		if (count == 0)
		{
			return;
		}
		double num = 0.0;
		double num2 = totalValue;
		if (count > 1)
		{
			num2 = totalValue / (double)count;
			if (num2 < 2147483647.0)
			{
				num2 = Math.Floor(num2);
			}
		}
		for (int i = 0; i < count; i++)
		{
			AnimatedIcon animatedIcon = animatedIconPool.Get();
			animatedIcon.imageIcon.enabled = true;
			animatedIcon.imageIcon.sprite = IconManager.SpriteForEntity(t);
			double num3 = num2;
			if (i == count - 1)
			{
				num3 = totalValue - num;
			}
			num += num3;
			if (showValue)
			{
				if (num3 >= 0.0)
				{
					animatedIcon.label.text = "+" + TextDisplay.LocalizedNumber(num3);
				}
				else
				{
					animatedIcon.label.text = TextDisplay.LocalizedNumber(num3);
				}
				animatedIcon.label.gameObject.SetActive(value: true);
			}
			else
			{
				animatedIcon.label.gameObject.SetActive(value: false);
			}
			float angleProgress = (float)i / (float)count;
			float duration = 1f + UnityEngine.Random.Range(-0.3f, 0.2f);
			animatedIcon.onCompleted = onCompleted;
			animatedIcon.displayedEntity = t;
			animatedIcon.Animate(from, to, duration, num3, angleProgress);
		}
	}

	public static PooledParticleParent CreatePooledItem(GameObject prefab, IObjectPool<PooledParticleParent> pool)
	{
		PooledParticleParent component = UnityEngine.Object.Instantiate(prefab, Instance.overlayPanelRoot).GetComponent<PooledParticleParent>();
		component.InitFromPool(pool);
		return component;
	}

	private void OnPooledObjectGet(MonoBehaviour b)
	{
		GameUtility.OnPooledObjectGet(b);
	}

	private void OnPooledObjectReleased(MonoBehaviour b)
	{
		GameUtility.OnPooledObjectReleased(b);
	}

	public void PlayStarParticles(Vector3 position)
	{
		starParticlePool.Get().Play(position);
	}

	public void PlayDigParticles(Vector3 position)
	{
		digParticlePool.Get().Play(position);
	}

	public void PlayChargePathParticles(Vector3 p1, Vector3 p2, float t)
	{
		PooledParticleParent pooledParticleParent = chargePathParticlePool.Get();
		pooledParticleParent.Play(p1);
		pooledParticleParent.transform.DOMove(p2, t);
	}

	private void TryUpdateTooltip()
	{
		if (isTooltipStale && null != highlightedMenuButton && (isInImmediateTooltipMode || !highlightedMenuButton.DelayTooltip()))
		{
			UpdateTooltip();
		}
	}

	public void SetHighlighted(GameObject go)
	{
		highlightedGameObject = go;
		if (null != go && go.TryGetComponent<MenuButton>(out var component))
		{
			highlightedMenuButton = component;
		}
		else
		{
			highlightedMenuButton = null;
		}
		if (null != highlightedMenuButton && highlightedMenuButton.DelayTooltip())
		{
			tooltipResetCountdown = 0f;
			if (isInImmediateTooltipMode)
			{
				UpdateTooltip();
			}
			else
			{
				tooltipCountdown = 1f;
			}
			return;
		}
		tooltipCountdown = 0f;
		if (isInImmediateTooltipMode && tooltipResetCountdown <= 0f)
		{
			tooltipResetCountdown = 1f;
		}
		UpdateTooltip();
	}

	public void UpdateTooltip()
	{
		if (null == tooltipPanel)
		{
			return;
		}
		if (null == highlightedMenuButton)
		{
			textTooltip.gameObject.SetActive(value: false);
			if (tooltipPanel.IsVisible() && !tooltipPanel.isPinned)
			{
				tooltipPanel.Hide();
			}
			if (constructionDetailsPanel.IsVisible() && !constructionDetailsPanel.isPinned)
			{
				constructionDetailsPanel.Hide();
			}
		}
		else if (highlightedMenuButton is BuildingCountRegion region)
		{
			constructionDetailsPanel.TryShowFromHighlightedRegion(region);
		}
		else if (highlightedMenuButton is BuildingCountSubRegion buildingCountSubRegion)
		{
			constructionDetailsPanel.TryShowFromHighlightedRegion(buildingCountSubRegion.parentRegion);
		}
		else if (highlightedMenuButton is InventoryListItem inventoryListItem)
		{
			textTooltip.gameObject.SetActive(value: false);
			if (!tooltipPanel.isPinned || !tooltipPanel.IsVisible())
			{
				tooltipPanel.LoadState(inventoryListItem.itemState);
				tooltipPanel.ManuallyOpen();
				if (highlightedMenuButton.transform is RectTransform)
				{
					tooltipPanel.SetPosition(highlightedMenuButton);
				}
			}
		}
		else if (highlightedMenuButton.tooltipModifier == TooltipModifier.ShowProductionDetails)
		{
			textTooltip.gameObject.SetActive(value: false);
			if (!tooltipPanel.isPinned || !tooltipPanel.IsVisible())
			{
				tooltipPanel.LoadEntityProduction(highlightedMenuButton.tooltipEntity);
				if (highlightedMenuButton.transform is RectTransform)
				{
					tooltipPanel.SetPosition(highlightedMenuButton);
				}
			}
		}
		else if (highlightedMenuButton.tooltipModifier == TooltipModifier.ShowGuide)
		{
			textTooltip.gameObject.SetActive(value: false);
			if (!tooltipPanel.isPinned || !tooltipPanel.IsVisible())
			{
				tooltipPanel.LoadEntityDescription(highlightedMenuButton.tooltipEntity);
				if (highlightedMenuButton.transform is RectTransform)
				{
					tooltipPanel.SetPosition(highlightedMenuButton);
				}
			}
		}
		else if (highlightedMenuButton.tooltipModifier == TooltipModifier.Requirements)
		{
			textTooltip.gameObject.SetActive(value: false);
			if (!tooltipPanel.isPinned || !tooltipPanel.IsVisible())
			{
				tooltipPanel.LoadRequirements(highlightedMenuButton.tooltipEntity);
				if (highlightedMenuButton.transform is RectTransform)
				{
					tooltipPanel.SetPosition(highlightedMenuButton);
				}
			}
		}
		else
		{
			if (highlightedMenuButton.tooltipEntity.TryAsItem(out var i) && displayedTown.inventory.TryGetValue(i, out var value))
			{
				_ = value.isLocked;
			}
			if (constructionDetailsPanel.IsVisible() && !constructionDetailsPanel.isPinned)
			{
				constructionDetailsPanel.Hide();
			}
			if (tooltipPanel.IsVisible() && !tooltipPanel.isPinned)
			{
				tooltipPanel.Hide();
			}
			string text = highlightedMenuButton.HighlightText();
			if (text == null)
			{
				textTooltip.gameObject.SetActive(value: false);
			}
			else
			{
				textTooltip.label.text = text;
				if (highlightedMenuButton.transform is RectTransform rt)
				{
					textTooltip.SetPosition(rt, highlightedMenuButton.useVerticalTooltip);
				}
				else
				{
					textTooltip.SetPosition(highlightedMenuButton.transform.position);
				}
				textTooltip.gameObject.SetActive(value: true);
			}
		}
		isTooltipStale = false;
	}

	public void ShowWelcomeMenu()
	{
		GameManager.GameState = GameState.Welcome;
		backgroundPanelRoot.gameObject.SetActive(value: false);
		modalMenuRoot.gameObject.SetActive(value: true);
		welcomePanel.SetToWelcomeState();
		welcomePanel.Show();
		loadingCover.gameObject.SetActive(value: false);
	}

	public void ShowMessage(string s)
	{
		AnimateMessage(s);
	}

	public void ShowMessage(InvalidReason r)
	{
		AnimateMessage(TextDisplay.TextForInvalidReason(r));
	}

	public void HideAllModals()
	{
		foreach (MenuPanel value in menuPanels.Values)
		{
			PanelCategory panelCategory = value.panelCategory;
			if ((uint)(panelCategory - 3) <= 2u)
			{
				value.Hide();
			}
		}
		ClearNotifications();
	}

	public void FadeLoadingCoverIn()
	{
		loadingCover.gameObject.SetActive(value: true);
		loadingCover.alpha = 0f;
		loadingCoverAnimation.Run();
	}

	private void OnCompletedLoadingCoverFadeIn()
	{
		welcomePanel.gameObject.SetActive(value: false);
		if (queuedLoadingMenuAction == 0)
		{
			ShowWelcomeMenu();
			FadeLoadingCoverOut();
		}
		else if (queuedLoadingMenuAction == 1)
		{
			welcomePanel.PerformLoadOfSelectedSlot();
		}
		else if (queuedLoadingMenuAction == 2)
		{
			welcomePanel.PerformCreateGameOfSelectedSlot();
		}
	}

	public void FadeLoadingCoverOut()
	{
		loadingCover.alpha = 1f;
		loadingCoverAnimation.RunReversed();
		MusicPlayer.Instance.FadeOutPlayingSong();
	}

	private void OnCompletedLoadingCoverFadeOut()
	{
		loadingCover.gameObject.SetActive(value: false);
	}

	public void ShowGameMenu()
	{
		gameMenuPanel.Show();
	}

	public static void SetFocusOnInputField(TMP_InputField field, bool jumpToEnd = false)
	{
		field.OnPointerClick(new PointerEventData(EventSystem.current));
		UserInput.DidEnterTextInput = true;
		if (jumpToEnd)
		{
			field.MoveTextEnd(shift: true);
		}
	}

	public PopupIconGrid ShowPopupIconGrid(RectTransform source, float width = 40f)
	{
		if (null == popupIconGrid)
		{
			popupIconGrid = UnityEngine.Object.Instantiate(popupIconGridPrefab, modalMenuRoot).GetComponent<PopupIconGrid>();
		}
		else
		{
			popupIconGrid.ClearPopup();
		}
		GridLayoutGroup layoutGroup = popupIconGrid.layoutGroup;
		if ((object)layoutGroup != null)
		{
			layoutGroup.cellSize = new Vector2(width, 40f);
		}
		RectTransform viewTransform = popupIconGrid.viewTransform;
		Vector3 position = source.position;
		Rect rect = source.rect;
		Vector3 vector = StartupManager.Instance.mainCamera.WorldToScreenPoint(position);
		Rect screenSpaceRect = Instance.GetScreenSpaceRect(source);
		Vector2 vector2 = new Vector2(rect.xMin + rect.width * 0.5f, rect.height + rect.yMin);
		vector.x += vector2.x;
		if (vector.y + vector2.y > (float)Screen.height - 100f * canvas.scaleFactor)
		{
			Vector3 position2 = new Vector3(screenSpaceRect.x + screenSpaceRect.width * 0.5f, screenSpaceRect.y, vector.z);
			Vector3 position3 = StartupManager.Instance.mainCamera.ScreenToWorldPoint(position2);
			viewTransform.pivot = new Vector2(0.5f, 1f);
			viewTransform.anchoredPosition = new Vector2(0f, -5f);
			viewTransform.position = position3;
		}
		else
		{
			Vector3 position4 = new Vector3(screenSpaceRect.x + screenSpaceRect.width * 0.5f, screenSpaceRect.y + screenSpaceRect.height, vector.z);
			Vector3 position5 = StartupManager.Instance.mainCamera.ScreenToWorldPoint(position4);
			viewTransform.pivot = new Vector2(0.5f, 0f);
			viewTransform.anchoredPosition = new Vector2(0f, 5f);
			viewTransform.position = position5;
		}
		popupIconGrid.Show();
		return popupIconGrid;
	}

	public PopupMenu ShowPopupMenu(RectTransform source)
	{
		if (null == popupMenu)
		{
			popupMenu = UnityEngine.Object.Instantiate(popupMenuPrefab, modalMenuRoot).GetComponent<PopupMenu>();
		}
		else
		{
			popupMenu.ClearPopup();
		}
		popupMenu.Show();
		RectTransform viewTransform = popupMenu.viewTransform;
		if (null == source)
		{
			viewTransform.pivot = new Vector2(0.5f, 0.5f);
			viewTransform.position = Vector3.zero;
		}
		else
		{
			if (source.anchoredPosition.x < 0f)
			{
				viewTransform.pivot = new Vector2(0f, 0.5f);
			}
			else
			{
				viewTransform.pivot = new Vector2(1f, 0.5f);
			}
			Vector3 position = source.position;
			viewTransform.position = new Vector3(position.x, position.y, position.z);
		}
		return popupMenu;
	}

	public void SetDismissableBackground(bool nextState)
	{
		if (nextState)
		{
			modalBackgroundImage.enabled = true;
			mainCanvasGroup.alpha = 0.5f;
			mainCanvasGroup.blocksRaycasts = false;
		}
		else
		{
			modalBackgroundImage.enabled = false;
			mainCanvasGroup.alpha = 1f;
			mainCanvasGroup.blocksRaycasts = true;
		}
	}

	public void OnBackgroundPointerDown()
	{
		int count = modalMenuStack.Count;
		if (count > 0)
		{
			MenuPanel menuPanel = modalMenuStack[count - 1];
			if (menuPanel.panelCategory == PanelCategory.DismissableModal || menuPanel.panelCategory == PanelCategory.FloatingModal)
			{
				menuPanel.Hide();
			}
			else if (menuPanel == levelUpRewardPanel)
			{
				levelUpRewardPanel.OnBackgroundClick();
			}
			else if (menuPanel == biomeUnlockPanel)
			{
				biomeUnlockPanel.OnBackgroundClick();
			}
		}
	}

	public static void OnManuallyProduced(EntityId id, float amount)
	{
	}

	public void AddLogForUnlock(EntityLevel l, Town t)
	{
		if (l.entityId.TryAsResearch(out var i))
		{
			t.AddLog(new LogEntry(l.entityId, l.level, t.townIndex));
			string label = Research.GetLabel(i, l.level);
			Notification n = new Notification(TextDisplay.FormattedKeyValue("ResearchComplete", label) + " (" + t.townName + ")", IconManager.SpriteForResearch(i), IconManager.SpriteForBiome(t.biomeType), string.Empty);
			PlayOrQueueTownLogNotification(n);
		}
	}

	public void AnimateResearchComplete(ResearchState rs, float xp, Town town)
	{
		town.AddLog(new LogEntry(rs.AsEntity(), rs.numCompleted, town.townIndex));
		string text = rs.GetLabel();
		if (town != gm.activeTown)
		{
			text = text + " (" + town.townName + ")";
		}
		Notification n = new Notification(TextDisplay.FormattedKeyValue("ResearchComplete", text), IconManager.SpriteForResearch(rs.type), IconManager.SpriteForItem(ItemType.TownExperiencePoint), "+" + TextDisplay.LocalizedNumber(xp));
		PlayOrQueueTownLogNotification(n);
	}

	public void AddLogLevelUp(string townName, int nextLevel, float landGain)
	{
		string format = TextDisplay.LocalizedTwoValueFormat();
		string s;
		if (LocalizationManager.IsEnglish())
		{
			s = "Town Level Up! " + townName + " reached Level " + TextDisplay.LocalizedNumber(nextLevel);
		}
		else
		{
			string formattedLevel = TextDisplay.GetFormattedLevel(nextLevel);
			string arg = string.Format(format, townName, formattedLevel);
			s = string.Format(format, "LevelUpExclamation".Localized(), arg);
		}
		string value = string.Format(format, "Land".Localized(), "+" + TextDisplay.LocalizedNumber(landGain));
		Notification n = new Notification(s, IconManager.Instance.townLevel, IconManager.Instance.land, value);
		PlayOrQueueTownLogNotification(n);
	}

	public void AnimateConstructionComplete(BuildingType t)
	{
		Notification n = new Notification(TextDisplay.FormattedKeyValue("ConstructionComplete", TextDisplay.LabelForBuilding(t)), IconManager.SpriteForBuilding(t), null, null);
		PlayOrQueueTownLogNotification(n);
	}

	public void AnimateMessage(string message)
	{
		Notification n = new Notification(message);
		PlayPopupImmediate(n);
	}

	public bool TryNextNotification()
	{
		if (notificationQueue.TryDequeue(out var result))
		{
			townStatsPanel.townLogItem.DisplayNotification(result);
			return true;
		}
		return false;
	}

	public void PlayPopupImmediate(Notification n)
	{
		playerMessageItem.DisplayNotification(n);
	}

	public void PlayOrQueueTownLogNotification(Notification n)
	{
		townStatsPanel.townLogItem.DisplayNotification(n);
	}

	public void ClearNotifications()
	{
		townStatsPanel.townLogItem.Reset();
		foreach (Town town in gm.towns)
		{
			town?.logEntries.Clear();
			town?.newLogs.Clear();
		}
		logPanel.isItemAvailabilityStale = true;
		playerMessageItem.Reset();
		notificationQueue.Clear();
	}

	public void ClearSelections()
	{
		if (constructionDetailsPanel.IsVisible())
		{
			constructionDetailsPanel.Unpin();
			constructionDetailsPanel.Hide();
		}
		inventoryPanel.SetFilter(null);
		foreach (MenuPanel value in menuPanels.Values)
		{
			if (value is MenuListPanel menuListPanel)
			{
				menuListPanel.selectionManager?.ClearSelection();
			}
		}
	}

	public void ApplyBiomeColors()
	{
		backgroundImage.sprite = IconManager.BackgroundForBiome(gm.activeTown.biomeType);
	}

	public static void SetGreyscale(Image a, bool displayAsFullColor)
	{
		a.color = (displayAsFullColor ? Color.white : ColorManager.greyscaleColor);
	}

	public static bool PassesTextFilter(string stringToTest)
	{
		return LocalizationManager.LocalizedIndexOf(stringToTest, currentSearchText) >= 0;
	}

	private void OnClearSearchButtonPressed()
	{
		ClearSearch();
	}

	public void ClearSearch()
	{
		combinedProductionPanel.ClearAllSearchProperties();
		navigationPanel.SelectBuildingCategory(BuildingCategory.None, sendEvent: false);
		SetSearchActive(nextState: false);
		OnSearchTextChanged();
	}

	private void OnSearchTextChanged()
	{
		OnSearchPropertiesChanged();
	}

	public void OnSearchPropertiesChanged()
	{
		currentSearchText = searchHeader.searchField.text;
		isSearchApplied = !string.IsNullOrEmpty(currentSearchText) || combinedProductionPanel.entityFilter.type != EntityType.None || combinedProductionPanel.itemFilter != null;
		combinedProductionPanel.filteredCollapseManager.Reset();
		combinedProductionPanel.AssignHeaderCollapseManager();
		searchHeader.SetFilterDisplay(combinedProductionPanel.itemFilter, combinedProductionPanel.entityFilter, isSearchApplied);
		combinedProductionPanel.isItemAvailabilityStale = true;
		searchHeader.cancelSearchField.buttonState = ((!string.IsNullOrEmpty(searchHeader.searchField.text)) ? CustomButtonState.BlueFlashing : CustomButtonState.Background);
		combinedProductionPanel.selectionManager.ClearSelection();
	}

	private void OnInputDeltaPressed()
	{
		PopupIconGrid target = Instance.ShowPopupIconGrid((RectTransform)inputDeltaButton.transform, 60f);
		AddPopup(1, target);
		AddPopup(5, target);
		AddPopup(10, target);
		AddPopup(100, target);
	}

	private void AddPopup(int amount, PopupIconGrid target)
	{
		target.AddTextButton(TextDisplay.Multiplier + amount, amount, OnInputDeltaSelected).isSelected = UserInput.baselineGlobalIncrement == amount;
	}

	private void OnInputDeltaSelected(NavigationIcon sender)
	{
		if (sender.loadedObject is int baselineGlobalIncrement)
		{
			UserInput.baselineGlobalIncrement = baselineGlobalIncrement;
		}
		Instance.OnIncrementChanged();
		Instance.popupIconGrid.Hide();
	}

	private string InputDeltaTooltip()
	{
		if (LocalizationManager.IsEnglish())
		{
			return "Adjustment Factor";
		}
		return null;
	}

	public void SetTooltipPosition(RectTransform source, RectTransform target, TextAnchor anchor, TextAnchor placement, float offset, bool centerX, bool centerY, bool allowHorizontalFlip)
	{
		Vector3 position = source.position;
		Vector3 vector = StartupManager.Instance.mainCamera.WorldToScreenPoint(position);
		float scaleFactor = canvas.scaleFactor;
		Rect screenSpaceRect = GetScreenSpaceRect(source);
		float num = screenSpaceRect.x;
		float num2 = screenSpaceRect.y;
		float height = screenSpaceRect.height;
		float width = screenSpaceRect.width;
		switch (anchor)
		{
		case TextAnchor.UpperLeft:
			num2 += height;
			break;
		case TextAnchor.UpperCenter:
			num += width * 0.5f;
			num2 += height;
			break;
		case TextAnchor.UpperRight:
			num += width;
			num2 += height;
			break;
		case TextAnchor.MiddleLeft:
			num2 += height * 0.5f;
			break;
		case TextAnchor.MiddleCenter:
			num += width * 0.5f;
			num2 += height * 0.5f;
			break;
		case TextAnchor.MiddleRight:
			num += width;
			num2 += height * 0.5f;
			break;
		case TextAnchor.LowerCenter:
			num += width * 0.5f;
			break;
		case TextAnchor.LowerRight:
			num += width;
			break;
		}
		float num3 = offset * scaleFactor;
		bool flag = false;
		if (allowHorizontalFlip)
		{
			if ((double)(num + num3) >= (double)Screen.width * 0.5)
			{
				if (placement == TextAnchor.MiddleRight)
				{
					flag = true;
					num -= width;
					num3 *= -1f;
				}
			}
			else if (placement == TextAnchor.MiddleLeft)
			{
				flag = true;
				num += width;
				num3 *= -1f;
			}
		}
		num += num3;
		if (centerY)
		{
			num2 = (float)Screen.height * 0.5f;
		}
		if (centerX)
		{
			num = (float)Screen.width * 0.5f;
		}
		switch (placement)
		{
		case TextAnchor.UpperLeft:
			target.pivot = new Vector2(1f, 0f);
			break;
		case TextAnchor.UpperCenter:
			target.pivot = new Vector2(0.5f, 0f);
			break;
		case TextAnchor.UpperRight:
			target.pivot = new Vector2(0f, 0f);
			break;
		case TextAnchor.MiddleLeft:
			target.pivot = new Vector2(1f, 0.5f);
			break;
		case TextAnchor.MiddleCenter:
			target.pivot = new Vector2(0.5f, 0.5f);
			break;
		case TextAnchor.MiddleRight:
			target.pivot = new Vector2(0f, 0.5f);
			break;
		case TextAnchor.LowerLeft:
			target.pivot = new Vector2(1f, 1f);
			break;
		case TextAnchor.LowerCenter:
			target.pivot = new Vector2(0.5f, 1f);
			break;
		case TextAnchor.LowerRight:
			target.pivot = new Vector2(0f, 1f);
			break;
		}
		if (flag)
		{
			Vector2 pivot = target.pivot;
			target.pivot = new Vector2(1f - pivot.x, pivot.y);
		}
		Vector3 vector2 = StartupManager.Instance.mainCamera.ScreenToWorldPoint(new Vector3(num, num2, vector.z));
		target.position = new Vector3(vector2.x, vector2.y, vector2.z);
	}

	public HighlightImage GetPooledHighlightImage(MenuButton parent)
	{
		List<HighlightImage> list = highlightImagePool;
		if (list.Count > 0)
		{
			HighlightImage highlightImage = list[list.Count - 1];
			list.Remove(highlightImage);
			highlightImage.LinkWithParent(parent);
			highlightImage.gameObject.SetActive(value: true);
			return highlightImage;
		}
		HighlightImage component = GetMenuObject(Instance.buttonHighlightPrefab, null).GetComponent<HighlightImage>();
		component.LinkWithParent(parent);
		buttonHighlightIndex++;
		return component;
	}

	public void ReturnPooledHighlightImage(HighlightImage highlightImage)
	{
		highlightImage.ResetState();
		highlightImagePool.Add(highlightImage);
	}

	public Rect GetScreenSpaceRect(RectTransform rt)
	{
		Vector3 position = rt.position;
		Rect rect = rt.rect;
		Vector3 vector = StartupManager.Instance.mainCamera.WorldToScreenPoint(position);
		float scaleFactor = canvas.scaleFactor;
		GetScreenSpaceRect(rt, StartupManager.Instance.mainCamera, canvas);
		return new Rect(vector.x + rect.xMin * scaleFactor, vector.y + rect.yMin * scaleFactor, rect.width * scaleFactor, rect.height * scaleFactor);
	}

	public static Rect GetScreenSpaceRect(RectTransform rt, Camera camera, Canvas canvas)
	{
		Vector3 position = rt.position;
		Rect rect = rt.rect;
		Vector3 vector = camera.WorldToScreenPoint(position);
		float scaleFactor = canvas.scaleFactor;
		return new Rect(vector.x + rect.xMin * scaleFactor, vector.y + rect.yMin * scaleFactor, rect.width * scaleFactor, rect.height * scaleFactor);
	}

	public Vector3 GetScreenSpaceCenter(RectTransform rt)
	{
		Vector3 position = rt.position;
		Rect rect = rt.rect;
		Vector3 vector = StartupManager.Instance.mainCamera.WorldToScreenPoint(position);
		float scaleFactor = canvas.scaleFactor;
		return new Vector3(vector.x + (rect.xMin + rect.width * 0.5f) * scaleFactor, vector.y + (rect.yMin + rect.height * 0.5f) * scaleFactor, vector.z);
	}

	public void SetQuestsStale()
	{
		questsPanel.isItemAvailabilityStale = true;
		questsPanelPopup.isItemAvailabilityStale = true;
		questsPanel.isTownLayoutStale = true;
		questsPanelPopup.isTownLayoutStale = true;
	}

	public void TestPointerPanelDisplay()
	{
		if (GameManager.GameState != GameState.InGame)
		{
			HidePointerPanel();
			return;
		}
		if (gm.suppressPointerPanel)
		{
			if (null != pointerPanel && pointerPanel.gameObject.activeInHierarchy)
			{
				HidePointerPanel();
			}
			return;
		}
		pointerDelayCounter += TimeManager.MenuDelta;
		if (Platform.Instance.GetStatInt(StatType.MaxTownLevel) >= 10)
		{
			gm.suppressPointerPanel = true;
			return;
		}
		if (pointerDelayCounter < 4f)
		{
			HidePointerPanel();
			return;
		}
		if (modalMenuStack.Count > 0)
		{
			foreach (MenuPanel item in modalMenuStack)
			{
				if (item != constructionDetailsPanel)
				{
					HidePointerPanel();
					return;
				}
			}
		}
		if (gm.globalQuests.TryGetValue(gm.tutorialQuestType, out var value) && value.IsReadyToClaim())
		{
			if (!value.hasTriggeredNotification)
			{
				HidePointerPanel();
			}
			else if (questsPanel.GetVisibleListItemWithObject(value) is QuestListItem questListItem)
			{
				ShowPointerPanel((RectTransform)questListItem.transform);
			}
			return;
		}
		if (gm.tutorialQuestType == QuestType.WoodForHouse)
		{
			if (gm.activeTown.harvesting.TryGetValue(HarvestRecipeType.Tree, out var value2))
			{
				MonoBehaviour visibleListItemWithObject = combinedProductionPanel.GetVisibleListItemWithObject(value2);
				if (visibleListItemWithObject is ProductionListItem productionListItem && null != productionListItem.costGrid.craftArrow && visibleListItemWithObject.gameObject.activeInHierarchy)
				{
					ShowPointerPanel((RectTransform)productionListItem.costGrid.craftArrow.transform);
				}
				else
				{
					combinedProductionPanel.TryAddPointerToExpandBuilding(BuildingType.HarvesterHut);
				}
				return;
			}
		}
		else if (gm.tutorialQuestType == QuestType.HouseForHarvesterHut)
		{
			if (gm.activeTown.buildings.TryGetValue(BuildingType.House, out var value3) && gm.isPromptingForHouse && value3.constructionState.numWorkersAssigned <= 0f && combinedProductionPanel.TryAddPointerToAddBuilding(BuildingType.House))
			{
				return;
			}
		}
		else if (gm.tutorialQuestType == QuestType.HarvesterHutForAssignWorkers)
		{
			if (gm.activeTown.buildings.TryGetValue(BuildingType.HarvesterHut, out var value4) && gm.isPromptingForHarvesterHut && value4.constructionState.numWorkersAssigned <= 0f && combinedProductionPanel.TryAddPointerToAddBuilding(BuildingType.HarvesterHut))
			{
				return;
			}
		}
		else if (gm.tutorialQuestType == QuestType.AssignWorkersForGeneralStore)
		{
			if (gm.activeTown.harvesting.TryGetValue(HarvestRecipeType.Tree, out var value5))
			{
				if (value5.producingBuilding.numAvailable > 0.0 && value5.numWorkersAssigned < (float)Quest.NumWorkersToAssign)
				{
					if (combinedProductionPanel.GetVisibleListItemWithObject(value5) is ProductionListItem productionListItem2)
					{
						ShowPointerPanel((RectTransform)productionListItem2.workerAssignmentRegion.increaseButton.transform);
					}
					else
					{
						combinedProductionPanel.TryAddPointerToExpandBuilding(BuildingType.HarvesterHut);
					}
					return;
				}
				if (gm.activeTown.workerState.numAvailable > 0.0)
				{
					if (gm.activeTown.buildings.TryGetValue(BuildingType.HarvesterHut, out var value6) && value6.constructionState.numWorkersAssigned <= 0f && combinedProductionPanel.TryAddPointerToAddBuilding(BuildingType.HarvesterHut))
					{
						return;
					}
				}
				else if (TryPointToHouse())
				{
					return;
				}
			}
		}
		else if (gm.tutorialQuestType == QuestType.GeneralStoreForMarketPanel)
		{
			if (gm.activeTown.buildings.TryGetValue(BuildingType.GeneralGoods, out var value7))
			{
				if (gm.activeTown.workerState.numAvailable > 0.0)
				{
					if (value7.constructionState.numWorkersAssigned <= 0f && combinedProductionPanel.TryAddPointerToAddBuilding(BuildingType.GeneralGoods))
					{
						return;
					}
				}
				else if (TryPointToHouse())
				{
					return;
				}
			}
		}
		else if (gm.tutorialQuestType == QuestType.EarnCoinsForLumberMill)
		{
			if (gm.activeTown.marketItems.TryGetValue(ItemType.Wood, out var value8) && value8.numWorkersAssigned < 1f && combinedProductionPanel.GetVisibleListItemWithObject(value8) is MarketListItem marketListItem)
			{
				ShowPointerPanel((RectTransform)marketListItem.workerAssignmentRegion.increaseButton.transform);
				return;
			}
		}
		else if (gm.activeTown.hasRewardToClaim && !gm.hasClaimedLevelRewards)
		{
			ShowPointerPanel((RectTransform)townStatsPanel.levelUpButton.transform);
			return;
		}
		if (gm.hasGlobalPerkAvailable && !gm.hasOpenedQuestCoinsPanel && gm.questCoinState.currentCount >= 5.0)
		{
			ShowPointerPanel((RectTransform)navigationPanel.questCoinsButton.transform);
		}
		else if (gm.activeTown.hasTownPerkAvailable && !gm.hasOpenedPerksPanel)
		{
			ShowPointerPanel((RectTransform)townStatsPanel.townPerkPointStat.transform);
		}
		else
		{
			HidePointerPanel();
		}
	}

	private bool TryPointToHouse()
	{
		if (gm.activeTown.buildings.TryGetValue(BuildingType.House, out var value) && value.constructionState.numWorkersAssigned <= 0f && combinedProductionPanel.TryAddPointerToAddBuilding(BuildingType.House))
		{
			return true;
		}
		return false;
	}

	public void ShowPointerPanel(RectTransform target)
	{
		if (null == pointerPanel)
		{
			GameObject menuObject = GetMenuObject(pointerPanelPrefab, overlayPanelRoot);
			pointerPanel = menuObject.GetComponent<PointerPanel>();
		}
		pointerPanel.AttachToTarget(target);
	}

	public void HidePointerPanel()
	{
		if (null != pointerPanel && pointerPanel.gameObject.activeSelf)
		{
			pointerPanel.gameObject.SetActive(value: false);
		}
	}

	public void UpdateLeftPanelLayouts()
	{
		RectTransform rt = questRegion;
		RectTransform rt2 = inventoryRegion;
		questsPanel.scrollRect.gameObject.SetActive(!questsPanel.isMinimized);
		inventoryPanel.scrollRect.gameObject.SetActive(!inventoryPanel.isMinimized);
		float num = 44f;
		_ = inventoryPanel.isMinimized;
		float num2 = 208f + coinPanel.GetLayoutHeight();
		if (inventoryPanel.isMinimized && questsPanel.isMinimized)
		{
			rt2.PinToAnchorY(1f);
			rt2.SetHeight(num);
			rt2.SetPosY(-14f - num2 - 4f);
			rt.PinToAnchorY(1f);
			rt.SetHeight(44f);
			rt.SetPosY(-14f - num2 - 4f - num - 4f);
		}
		else if (inventoryPanel.isMinimized && !questsPanel.isMinimized)
		{
			rt2.PinToAnchorY(1f);
			rt2.SetHeight(num);
			rt2.SetPosY(-14f - num2 - 4f);
			rt.StretchHeight();
			rt.SetTop(14f + num2 + 4f + num + 4f);
			rt.SetBottom(17f);
		}
		else if (!inventoryPanel.isMinimized && questsPanel.isMinimized)
		{
			rt2.StretchHeight();
			rt2.SetTop(14f + num2 + 4f);
			rt2.SetBottom(65f);
			rt.PinToAnchorY(0f);
			rt.SetHeight(44f);
			rt.SetPosY(17f);
		}
		else
		{
			rt2.StretchHeight();
			rt2.SetTop(14f + num2 + 4f);
			rt2.SetBottom(297f);
			rt.PinToAnchorY(0f);
			rt.SetHeight(276f);
			rt.SetPosY(17f);
		}
		SetCollapsed(questsPanel.collapseButtonImage, questsPanel.isMinimized);
		SetCollapsed(inventoryPanel.collapseButtonImage, inventoryPanel.isMinimized);
		inventoryPanel.isTownLayoutStale = true;
		questsPanel.isTownLayoutStale = true;
		isLeftLayoutStale = false;
	}

	public void SetCollapsed(Image image, bool nextState)
	{
		if (nextState)
		{
			image.sprite = IconManager.Instance.caratCollapsed;
		}
		else
		{
			image.sprite = IconManager.Instance.caratExpanded;
		}
	}

	public void OnInventoryNavigationPressed()
	{
		inventoryPanelPopup.ToggleDisplayForTown(gm.activeTown);
	}

	public void OnQuestsNavigationPressed()
	{
		questsPanelPopup.ToggleDisplayForTown(gm.activeTown);
	}

	public void OnClickedTooltipNavigation(EntityId navigationTarget)
	{
		if (navigationTarget.type != EntityType.None && (navigationTarget.type == EntityType.Building || navigationTarget.type == EntityType.Research || navigationTarget.type == EntityType.Quest || navigationTarget.type == EntityType.NaturalResource || navigationTarget.type == EntityType.Farming || navigationTarget.type == EntityType.HarvestRecipe || navigationTarget.type == EntityType.Mining || navigationTarget.type == EntityType.Recipe || navigationTarget.type == EntityType.Item || navigationTarget.type == EntityType.Biome || navigationTarget.type == EntityType.Upgrade))
		{
			if (navigationTarget.TryAsResearch(out var i) && researchPanel.IsVisible() && GameManager.Instance.activeTown.research.TryGetValue(i, out var value))
			{
				researchPanel.JumpToAndSelectResearch(value);
			}
			tooltipPanel.LoadEntityDescription(navigationTarget);
		}
	}

	private void OnSearchTogglePressed()
	{
		SetSearchActive(!searchHeader.gameObject.activeSelf);
		if (searchHeader.gameObject.activeSelf)
		{
			SetFocusOnInputField(searchHeader.searchField);
		}
	}

	public void SetSearchActive(bool nextState)
	{
		searchHeader.gameObject.SetActive(nextState);
		searchToggleButton.isSelected = nextState;
	}
}
