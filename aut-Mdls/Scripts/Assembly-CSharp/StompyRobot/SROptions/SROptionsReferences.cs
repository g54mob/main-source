using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor;
using Data.FactoryFloor.Buildings;
using Data.FactoryFloor.Maps;
using Data.FactoryFloor.Resources;
using Data.FeatureFlags;
using Data.Operator;
using Data.SaveData.PersistentSOs;
using Data.Statistics;
using Data.TechTree.Behaviours;
using Data.Variables;
using Data.Variables.Recipes;
using Events;
using Events.Analytics;
using Events.FactoryFloor;
using Events.Generic;
using Events.UI.Notifications;
using Events.UI.Overlays;
using Integrations;
using JetBrains.Annotations;
using Logic.Audio;
using Logic.Factory;
using Logic.Quests;
using Logic.SteamAchievements;
using Presentation.CameraView;
using Presentation.FactoryFloor;
using Presentation.Locators;
using Presentation.UI.Menus;
using Presentation.UI.Overlays.Notifications;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StompyRobot.SROptions
{
	public class SROptionsReferences : MonoBehaviour
	{
		[SerializeField]
		private LoadFactoryFloor _loadFactoryFloor;

		[SerializeField]
		private FactoryClearer _factoryClearer;

		[SerializeField]
		private BaseEvent _upgradeAllBuildingsEvent;

		[SerializeField]
		private FactoryValidateViews _factoryValidateViews;

		[SerializeField]
		private ShowModalDialogEvent _showModalDialogEvent;

		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private ShowNarrationDialogEvent _showNarrationDialogEvent;

		[SerializeField]
		private BaseEvent _hideNarrationDialogEvent;

		[SerializeField]
		private Sprite _modalDialogTestSprite;

		[SerializeField]
		private IntVariableSO _rawResourceAmount;

		[SerializeField]
		private IntVariableSO _globalUpdateMultiplier;

		[SerializeField]
		private IntVariableSO _conveyorUpdateFrequency;

		[SerializeField]
		private IntVariableSO _extractorUpdateFrequency;

		[SerializeField]
		private IntVariableSO _furnaceUpdateFrequency;

		[SerializeField]
		private IntVariableSO _cutterUpdateFrequency;

		[SerializeField]
		private IntVariableSO _stamperUpdateFrequency;

		[SerializeField]
		private IntVariableSO _assemblerUpdateFrequency;

		[SerializeField]
		private IntVariableSO _splitterUpdateFrequency;

		[SerializeField]
		private IntVariableSO _painterUpdateFrequency;

		[SerializeField]
		private IntVariableSO _cameraZoomLimitMin;

		[SerializeField]
		private IntVariableSO _cameraZoomLimitMax;

		[SerializeField]
		private BoolVariableSO _heatmapIsOn;

		[SerializeField]
		private LockedFactoryObjectsPersistentSO _lockedFactoryObjectsPersistentSO;

		[SerializeField]
		private LockedFactoryToolsPersistentSO _lockedFactoryToolsPersistentSO;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		[SerializeField]
		private ChangeBoolVariableBehaviour _unlockBlueprints;

		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		[SerializeField]
		private CameraControllerSwitcherLocator _cameraControllerSwitcherLocator;

		[SerializeField]
		private QuestManagerLocator _questManagerLocator;

		[SerializeField]
		private TechTreeManagerLocator _techTreeManagerLocator;

		[SerializeField]
		private ObjectivesManagerLocator _objectivesManagerLocator;

		[SerializeField]
		private ObjectivesPersistentSO _objectivesPersistentSO;

		[SerializeField]
		private UIMenuLocator _objectivesUILocator;

		[SerializeField]
		private UIMenuLocator _productionGraphLocator;

		[SerializeField]
		private List<ParticleSystem> _windParticleSystems;

		[SerializeField]
		private FeatureFlags _featureFlags;

		[SerializeField]
		private IntEvent _placementToolButtonPressedEvent;

		[SerializeField]
		private AddXPEvent _addXPEvent;

		[SerializeField]
		private RankConfigSO _rankConfig;

		[SerializeField]
		private CurrencyPersistentSO _currencyPersistentSO;

		[SerializeField]
		private StatisticsSO _statisticsSO;

		[SerializeField]
		private ResourceDataSO _greyDataShardResource;

		[SerializeField]
		private ResourceDataSO _blueDataShardResource;

		[SerializeField]
		private ResourceDataSO _yellowDataShardResource;

		[SerializeField]
		private ResourceDataSO _redDataShardResource;

		[SerializeField]
		private AnalyticsQueueEvent _analyticsQueueEvent;

		[SerializeField]
		private NonShapeResourceDataSO _expansionPermitResource;

		[SerializeField]
		private AddCurrencyEvent _addCurrencyEvent;

		[SerializeField]
		private InputActionAsset _inputActionAsset;

		[SerializeField]
		private BuildingMaxLockedStageData _greyMaxLockedBuildingStageData;

		[SerializeField]
		private BuildingMaxLockedStageData _blueMaxLockedBuildingStageData;

		[SerializeField]
		private BuildingMaxLockedStageData _yellowMaxLockedBuildingStageData;

		[SerializeField]
		private UnlockedRecipesPersistentSO _unlockedRecipesPersistentSO;

		[SerializeField]
		private RecipeDatabase _recipeDatabase;

		[SerializeField]
		private FadeToBlackUI _fadeToBlackUI;

		[SerializeField]
		private InGameNotificationUI inGameNotificationUI;

		[SerializeField]
		private Sprite _greyMonumentImage;

		[SerializeField]
		private AmbientAudioController ambientAudioController;

		[SerializeField]
		private BuildingObjectData _buildingObjectData;

		[SerializeField]
		private List<FactoryObjectData> _autoSpawnerList;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryLayer _terrainLayer;

		[SerializeField]
		private CreateFactoryObjectEvent _createFactoryObjectEvent;

		[SerializeField]
		private GridLocator _gridLocator;

		[SerializeField]
		private IntListEvent _factoryObjectsRemoveViewsEvent;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private IntVariableSO _dayNightCycleStateSO;

		[SerializeField]
		private AutoSaveService _autoSaveService;

		[SerializeField]
		private IntroManagerLocator _introManagerLocator;

		[SerializeField]
		private NotificationEvent _notificationEvent;

		[SerializeField]
		private Sprite _chargeNotificationSprite;

		[SerializeField]
		private SteamAchievementsManager _steamAchievementsManager;

		[SerializeField]
		private IntegrationManagerLocator _integrationManagerLocator;

		private static SROptionsReferences _instance;

		public LoadFactoryFloor LoadFactoryFloor => _loadFactoryFloor;

		public FactoryClearer FactoryClearer => _factoryClearer;

		public BaseEvent UpgradeAllBuildingsEvent => _upgradeAllBuildingsEvent;

		public FactoryValidateViews FactoryValidateViews => _factoryValidateViews;

		public ShowModalDialogEvent ShowModalDialogEvent => _showModalDialogEvent;

		public ShowMenuModalDialogEvent ShowMenuModalDialogEvent => _showMenuModalDialogEvent;

		public ShowNarrationDialogEvent ShowNarrationDialogEvent => _showNarrationDialogEvent;

		public BaseEvent HideNarrationDialogEvent => _hideNarrationDialogEvent;

		public Sprite ModalDialogTestsprite => _modalDialogTestSprite;

		public IntVariableSO RawResourceAmount => _rawResourceAmount;

		public IntVariableSO GlobalUpdateMultiplier => _globalUpdateMultiplier;

		public IntVariableSO ConveyorUpdateFrequency => _conveyorUpdateFrequency;

		public IntVariableSO ExtractorUpdateFrequency => _extractorUpdateFrequency;

		public IntVariableSO FurnaceUpdateFrequency => _furnaceUpdateFrequency;

		public IntVariableSO CutterUpdateFrequency => _cutterUpdateFrequency;

		public IntVariableSO StamperUpdateFrequency => _stamperUpdateFrequency;

		public IntVariableSO AssemblerUpdateFrequency => _assemblerUpdateFrequency;

		public IntVariableSO SplitterUpdateFrequency => _splitterUpdateFrequency;

		public IntVariableSO PainterUpdateFrequency => _painterUpdateFrequency;

		public IntVariableSO CameraZoomLimitMin => _cameraZoomLimitMin;

		public IntVariableSO CameraZoomLimitMax => _cameraZoomLimitMax;

		public BoolVariableSO HeatmapIsOn => _heatmapIsOn;

		public LockedFactoryObjectsPersistentSO LockedFactoryObjectsPersistentSO => _lockedFactoryObjectsPersistentSO;

		public LockedFactoryToolsPersistentSO LockedFactoryToolsPersistentSO => _lockedFactoryToolsPersistentSO;

		public UnlockedIslandsPersistentSO UnlockedIslandsPersistentSO => _unlockedIslandsPersistentSO;

		public ChangeBoolVariableBehaviour UnlockBlueprints => _unlockBlueprints;

		public CameraView CameraView => _cameraViewLocator.CameraView;

		public CameraControllerSwitcher CameraControllerSwitcher => _cameraControllerSwitcherLocator.CameraControllerSwitcher;

		public QuestManager QuestManager => _questManagerLocator.QuestManager;

		public TechTreeManager TechTreeManager => _techTreeManagerLocator.TechTreeManager;

		public ObjectiveManager ObjectiveManager => _objectivesManagerLocator.ObjectivesManager;

		public ObjectivesPersistentSO ObjectivesPersistentSO => _objectivesPersistentSO;

		public IntroManagerLocator IntroManagerLocator => _introManagerLocator;

		public UIMenuLocator ObjectivesUILocator => _objectivesUILocator;

		public UIMenuLocator ProdutionGraphUILocator => _productionGraphLocator;

		public List<ParticleSystem> WindParticleSystems => _windParticleSystems;

		public FeatureFlags FeatureFlags => _featureFlags;

		public AddXPEvent AddXPEvent => _addXPEvent;

		public RankConfigSO RankConfig => _rankConfig;

		public CurrencyPersistentSO CurrencyPersistentSO => _currencyPersistentSO;

		public StatisticsSO StatisticsSO => _statisticsSO;

		public ResourceDataSO GreyDataShardResource => _greyDataShardResource;

		public ResourceDataSO BlueDataShardResource => _blueDataShardResource;

		public ResourceDataSO YellowDataShardResource => _yellowDataShardResource;

		public ResourceDataSO RedDataShardResource => _redDataShardResource;

		public AnalyticsQueueEvent AnalyticsQueueEvent => _analyticsQueueEvent;

		public NonShapeResourceDataSO ExpansionPermitResource => _expansionPermitResource;

		public AddCurrencyEvent AddCurrencyEvent => _addCurrencyEvent;

		public FadeToBlackUI FadeToBlackUI => _fadeToBlackUI;

		public InGameNotificationUI InGameNotificationUI => inGameNotificationUI;

		public Sprite GreyMonumentImage => _greyMonumentImage;

		public AmbientAudioController AmbientAudioController => ambientAudioController;

		public BuildingObjectData BuildingObjectData => _buildingObjectData;

		public List<FactoryObjectData> AutoSpawnerList => _autoSpawnerList;

		public IslandLayer IslandLayer => _islandLayer;

		public FactoryLayer FactoryLayer => _factoryLayer;

		public FactoryLayer TerrainLayer => _terrainLayer;

		public CreateFactoryObjectEvent CreateFactoryObjectEvent => _createFactoryObjectEvent;

		public GridLocator GridLocator => _gridLocator;

		public IntListEvent FactoryObjectsRemoveViewsEvent => _factoryObjectsRemoveViewsEvent;

		public AudioManagerLocator AudioManagerLocator => _audioManagerLocator;

		[CanBeNull]
		public IntVariableSO DayNightCycleStateSO => _dayNightCycleStateSO;

		public AutoSaveService AutoSaveService => _autoSaveService;

		public NotificationEvent NotificationEvent => _notificationEvent;

		public Sprite ChargeNotificationSprite => _chargeNotificationSprite;

		public SteamAchievementsManager SteamAchievementsManager => _steamAchievementsManager;

		public IntegrationManager IntegrationManager => _integrationManagerLocator.Integration;

		public static SROptionsReferences Instance => _instance;

		public IntEvent PlacementToolPressedEvent => _placementToolButtonPressedEvent;

		public BuildingMaxLockedStageData GreyMaxLockedBuildingStageData => _greyMaxLockedBuildingStageData;

		public BuildingMaxLockedStageData BlueMaxLockedBuildingStageData => _blueMaxLockedBuildingStageData;

		public BuildingMaxLockedStageData YellowMaxLockedBuildingStageData => _yellowMaxLockedBuildingStageData;

		public UnlockedRecipesPersistentSO UnlockedRecipesPersistentSO => _unlockedRecipesPersistentSO;

		public RecipeDatabase RecipeDatabase => _recipeDatabase;

		public string GetCurrentlyEnabledInputMaps()
		{
			string text = string.Empty;
			foreach (InputActionMap actionMap in _inputActionAsset.actionMaps)
			{
				if (actionMap.enabled)
				{
					text = text + actionMap.name + " ";
				}
			}
			return text;
		}

		private void Awake()
		{
			if (_instance != null)
			{
				Object.Destroy(this);
			}
			else
			{
				_instance = this;
			}
		}
	}
}
