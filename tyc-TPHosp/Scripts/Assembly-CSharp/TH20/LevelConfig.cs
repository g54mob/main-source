using System.Linq;
using FullInspector;
using JetBrains.Annotations;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LevelConfig : ISilverUnlockable, ISilverUnlockToken
	{
		public string UniqueId;

		[FullInspector.InspectorName("Display Name")]
		public LocalisedString DisplayNameLocalised;

		[FullInspector.InspectorName("Description Per Star")]
		public LocalisedString[] DescriptionPerStarLocalised;

		public string SceneName;

		public bool IsDebugLevel;

		public bool IssueSharesOnStart = true;

		public float StaffHappinessModifier;

		public float GuestTrainerUpfrontCostMultiplier = 1f;

		public float GuestTrainerCostPerTraineeMultiplier = 1f;

		public float InitialCameraOffset = 10f;

		[InspectorHeader("Fail State")]
		public int FailStateBalanceWarning = -150000;

		public int FailStateBalanceGameOver = -300000;

		[FullInspector.InspectorName("[DEPRECATED] Display Name")]
		[SerializeField]
		private string DisplayName = "";

		[FullInspector.InspectorName("[DEPRECATED] Description Per Star")]
		[SerializeField]
		private string[] DescriptionPerStar;

		[SerializeField]
		private int _silverCost;

		public bool CharactersCanWearWinterClothes;

		public bool CharactersCanWearSummerClothes;

		public string DesiredStartingRadioTrackID = "";

		[SerializeField]
		private SharedInstance<DLCItemDefinition> _dlcPackRequired;

		[SerializeField]
		private LocalisedString _loadingDescription;

		[SerializeField]
		private Sprite _loadingBackground;

		[SerializeField]
		private LevelProgressPrerequisite[] _levelVisiblePrerequisites;

		[SerializeField]
		private LevelProgressPrerequisite[] _levelPlayablePrerequisites;

		[SerializeField]
		private SharedInstance<LevelConfig> BaseConfig;

		[SerializeField]
		private SharedInstance<GameTime.Config> GameTimeConfig;

		[SerializeField]
		private SharedInstance<TopDownCameraLogic.Config> TopDownCameraLogicConfig;

		[SerializeField]
		private SharedInstance<BuildingLogic.Config> BuildingLogicConfig;

		[SerializeField]
		private SharedInstance<CursorManager.Config> CursorManagerConfig;

		[SerializeField]
		private SharedInstance<HUD.Config> HUDConfig;

		[SerializeField]
		private SharedInstance<WorldState.Config> WorldStateConfig;

		[SerializeField]
		private SharedInstance<CharacterManager.Config> CharacterManagerConfig;

		[SerializeField]
		private SharedInstance<VisualManager.Config> VisualManagerConfig;

		[SerializeField]
		private AudioListenerManagerConfig AudioListenerManagerConfig;

		[SerializeField]
		private HospitalAudioAmbienceManagerConfig AudioAmbienceManagerConfig;

		[SerializeField]
		private SFXManagerConfig SFXManagerConfig;

		[SerializeField]
		private HospitalAudioMixerManagerConfig HospitalAudioMixerManagerConfig;

		[SerializeField]
		private SharedInstance<CursorRoomBuild.Config> CursorRoomBuildConfig;

		[SerializeField]
		private SharedInstance<CursorEditHospital.Config> CursorEditHospitalConfig;

		[SerializeField]
		private CharacterNameGenerator CharacterNameGenerator;

		[SerializeField]
		private SharedInstance<FinanceManager.Config> FinanceManagerConfig;

		[SerializeField]
		private SharedInstance<TannoyManagerConfig> TannoyManagerConfig;

		[SerializeField]
		private SharedInstance<LevelScriptManager.Config> LevelScriptConfig;

		[SerializeField]
		private SharedInstance<NotificationMessages> NotificationMessagesConfig;

		[SerializeField]
		private MessagePresenterConfig DialogueMessageManagerConfig;

		[SerializeField]
		private SharedInstance<DataViewManager.Config> DataViewsManagerConfig;

		[SerializeField]
		private SharedInstance<StatusIconManager.Config> StatusIconManagerConfig;

		[SerializeField]
		private SharedInstance<JobApplicantManager.Config> JobApplicantManagerConfig;

		[SerializeField]
		private SharedInstance<ResearchManager.Config> ResearchManagerConfig;

		[SerializeField]
		private SharedInstance<ReputationTracker.Config> ReputationTrackerConfig;

		[SerializeField]
		private SharedInstance<ChallengeManager.Config> ChallengeManagerConfig;

		[SerializeField]
		private SharedInstance<LeaderboardConfig> LeaderboardConfig;

		[SerializeField]
		private SharedInstance<HospitalAwardsManager.Config> HospitalAwardsConfig;

		[SerializeField]
		private SharedInstance<YearlyTargetsManager.Config> YearlyTargetsManagerConfig;

		[SerializeField]
		private SharedInstance<Advisor.Config> AdvisorConfig;

		[SerializeField]
		private SharedInstance<CharacterTraitsManager.Config> CharacterTraitsConfig;

		[SerializeField]
		private SharedInstance<LoanManager.Config> LoanManagerConfig;

		[SerializeField]
		private SharedInstance<MarketingManager.Config> MarketingConfig;

		[SerializeField]
		private SharedInstance<WorkLifeBalanceManager.Config> WorkLifeBalanceConfig;

		[SerializeField]
		private PriceModifiablesConfig PriceModifiablesConfig;

		[SerializeField]
		private SharedInstance<StaffChallengeManager.Config> StaffChallengeManagerConfig;

		[SerializeField]
		private SharedInstance<PrestigeTracker.Config> PrestigeConfig;

		[SerializeField]
		private SharedInstance<GuestTrainers.Config> GuestTrainersConfig;

		[SerializeField]
		private SharedInstance<LevelDebugConfig> LevelDebugConfig;

		[SerializeField]
		private LevelLightingConfig LevelLightingConfig;

		[SerializeField]
		private SharedInstance<HospitalEventLog.Config> HospitalEventLogConfig;

		[SerializeField]
		private SharedInstance<DemolishLandscapeItemEffect.Config> DemolishLandscapeItemEffectConfig;

		[SerializeField]
		private SharedInstance<MonoBeastManager.Config> MonoBeastManagerConfig;

		[SerializeField]
		private SharedInstance<HospitalPlotFootprintVisual.Config> HospitalPlotFootprintConfig;

		[SerializeField]
		private SharedInstance<ItemSpawnLimits.Config> ItemSpawnLimitsConfig;

		[SerializeField]
		private SharedInstance<HospitalPolicy.ConfigData> HospitalPolicyConfig;

		[SerializeField]
		private SharedInstance<EmergencyDispatchMenu.Config> EmergencyUIConfig;

		[SerializeField]
		private RoomVisualOverridesDatabase RoomVisualOverridesDatabase;

		[SerializeField]
		private LevelRoomList LevelRoomBlacklist;

		[SerializeField]
		private LevelRoomList LevelRoomWhitelist;

		[SerializeField]
		private LevelItemList LevelItemBlacklist;

		[SerializeField]
		private LevelItemList LevelItemWhitelist;

		[SerializeField]
		private string _isVisibleOverrideTag;

		[SerializeField]
		private string _isPlayableOverrideTag;

		[SerializeField]
		private SharedInstance<JobApplicantManager.Config> SandboxJobApplicantManagerConfig;

		[SerializeField]
		private SharedInstance<GuestTrainers.Config> SandboxGuestTrainersConfig;

		[InspectorTooltip("Whether this is a Remix level (gets a special loading screen)")]
		public bool IsRemixLevel;

		public SharedInstance<LevelConfig> RemixLevelConfig;

		public SharedInstance<HospitalScenario> HospitalScenario;

		public LevelProgressPrerequisite[] LevelVisiblePrerequisites => _levelVisiblePrerequisites;

		public LevelProgressPrerequisite[] LevelPlayablePrerequisites => _levelPlayablePrerequisites;

		public ISilverUnlockToken SilverUnlockToken => this;

		public string IsVisibleOverrideTag => _isVisibleOverrideTag;

		public string IsPlayableOverrideTag => _isPlayableOverrideTag;

		public DLCItemDefinition GetRequiredDlcPack()
		{
			if (!_dlcPackRequired.IsNull())
			{
				return _dlcPackRequired.Instance;
			}
			return null;
		}

		public LevelRoomList GetLevelRoomBlacklist()
		{
			return LevelRoomBlacklist;
		}

		public LevelRoomList GetLevelRoomWhitelist()
		{
			return LevelRoomWhitelist;
		}

		public LevelItemList GetLevelItemBlacklist()
		{
			return LevelItemBlacklist;
		}

		public LevelItemList GetLevelItemWhitelist()
		{
			return LevelItemWhitelist;
		}

		public GameTime.Config GetGameTimeConfig()
		{
			if (!(GameTimeConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetGameTimeConfig();
			}
			return GameTimeConfig.Instance;
		}

		public TopDownCameraLogic.Config GetTopDownCameraLogicConfig()
		{
			if (!(TopDownCameraLogicConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetTopDownCameraLogicConfig();
			}
			return TopDownCameraLogicConfig.Instance;
		}

		public BuildingLogic.Config GetBuildingLogicConfig()
		{
			if (!(BuildingLogicConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetBuildingLogicConfig();
			}
			return BuildingLogicConfig.Instance;
		}

		public CursorManager.Config GetCursorManagerConfig()
		{
			if (!(CursorManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetCursorManagerConfig();
			}
			return CursorManagerConfig.Instance;
		}

		public HUD.Config GetHUDConfig()
		{
			if (!(HUDConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetHUDConfig();
			}
			return HUDConfig.Instance;
		}

		public WorldState.Config GetWorldStateConfig()
		{
			if (!(WorldStateConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetWorldStateConfig();
			}
			return WorldStateConfig.Instance;
		}

		public SharedInstance<WorldState.Config> GetWorldStateConfigInstance()
		{
			if (!(WorldStateConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetWorldStateConfigInstance();
			}
			return WorldStateConfig;
		}

		public SharedInstance<WorldState.Config> GetSharedWorldStateConfig()
		{
			if (!(WorldStateConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetSharedWorldStateConfig();
			}
			return WorldStateConfig;
		}

		public CharacterManager.Config GetCharacterManagerConfig()
		{
			if (!(CharacterManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetCharacterManagerConfig();
			}
			return CharacterManagerConfig.Instance;
		}

		public VisualManager.Config GetVisualManagerConfig()
		{
			if (!(VisualManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetVisualManagerConfig();
			}
			return VisualManagerConfig.Instance;
		}

		public SFXManagerConfig GetSFXManagerConfig()
		{
			if (!(SFXManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetSFXManagerConfig();
			}
			return SFXManagerConfig;
		}

		public AudioListenerManagerConfig GetAudioListenerManagerConfig()
		{
			if (!(AudioListenerManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetAudioListenerManagerConfig();
			}
			return AudioListenerManagerConfig;
		}

		public HospitalAudioAmbienceManagerConfig GetHospitalAudioAmbienceManagerConfig()
		{
			if (!(AudioAmbienceManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetHospitalAudioAmbienceManagerConfig();
			}
			return AudioAmbienceManagerConfig;
		}

		public HospitalAudioMixerManagerConfig GetHospitalAudioMixerManagerConfig()
		{
			if (!(HospitalAudioMixerManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetHospitalAudioMixerManagerConfig();
			}
			return HospitalAudioMixerManagerConfig;
		}

		public CursorRoomBuild.Config GetCursorRoomBuildConfig()
		{
			if (!(CursorRoomBuildConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetCursorRoomBuildConfig();
			}
			return CursorRoomBuildConfig.Instance;
		}

		public CursorEditHospital.Config GetCursorEditHospitalConfig()
		{
			if (!(CursorEditHospitalConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetCursorEditHospitalConfig();
			}
			return CursorEditHospitalConfig.Instance;
		}

		public CharacterNameGenerator GetCharacterNameGenerator()
		{
			if (!(CharacterNameGenerator != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetCharacterNameGenerator();
			}
			return CharacterNameGenerator;
		}

		public FinanceManager.Config GetFinanceManagerConfig()
		{
			if (!(FinanceManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetFinanceManagerConfig();
			}
			return FinanceManagerConfig.Instance;
		}

		public TannoyManagerConfig GetTannoyManagerConfig()
		{
			if (!(TannoyManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetTannoyManagerConfig();
			}
			return TannoyManagerConfig.Instance;
		}

		public LevelScriptManager.Config GetLevelScriptConfig()
		{
			if (!(LevelScriptConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetLevelScriptConfig();
			}
			return LevelScriptConfig.Instance;
		}

		public NotificationMessages GetNotificationMessagesConfig()
		{
			if (!(NotificationMessagesConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetNotificationMessagesConfig();
			}
			return NotificationMessagesConfig.Instance;
		}

		public MessagePresenterConfig GetDialogueMessageManagerConfig()
		{
			if (!(DialogueMessageManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetDialogueMessageManagerConfig();
			}
			return DialogueMessageManagerConfig;
		}

		public DataViewManager.Config GetDataViewManagerConfig()
		{
			if (!(DataViewsManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetDataViewManagerConfig();
			}
			return DataViewsManagerConfig.Instance;
		}

		public StatusIconManager.Config GetStatusIconManagerConfig()
		{
			if (!(StatusIconManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetStatusIconManagerConfig();
			}
			return StatusIconManagerConfig.Instance;
		}

		public JobApplicantManager.Config GetJobApplicantManagerConfig()
		{
			if (!(JobApplicantManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetJobApplicantManagerConfig();
			}
			return JobApplicantManagerConfig.Instance;
		}

		public JobApplicantManager.Config GetSandboxJobApplicantManagerConfig()
		{
			if (!(SandboxJobApplicantManagerConfig != null))
			{
				return GetJobApplicantManagerConfig();
			}
			return SandboxJobApplicantManagerConfig.Instance;
		}

		public ResearchManager.Config GetResearchManagerConfig()
		{
			if (!(ResearchManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetResearchManagerConfig();
			}
			return ResearchManagerConfig.Instance;
		}

		public ReputationTracker.Config GetReputationTrackerConfig()
		{
			if (!(ReputationTrackerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetReputationTrackerConfig();
			}
			return ReputationTrackerConfig.Instance;
		}

		public ChallengeManager.Config GetChallengeManagerConfig()
		{
			if (!(ChallengeManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetChallengeManagerConfig();
			}
			return ChallengeManagerConfig.Instance;
		}

		public LeaderboardConfig GetLeaderboardConfig()
		{
			if (!(LeaderboardConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetLeaderboardConfig();
			}
			return LeaderboardConfig.Instance;
		}

		public HospitalAwardsManager.Config GetHospitalAwardsConfig()
		{
			if (!(HospitalAwardsConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetHospitalAwardsConfig();
			}
			return HospitalAwardsConfig.Instance;
		}

		public YearlyTargetsManager.Config GetYearlyTargetsManagerConfig()
		{
			if (!(YearlyTargetsManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetYearlyTargetsManagerConfig();
			}
			return YearlyTargetsManagerConfig.Instance;
		}

		public Advisor.Config GetAdvisorConfig()
		{
			if (!(AdvisorConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetAdvisorConfig();
			}
			return AdvisorConfig.Instance;
		}

		public CharacterTraitsManager.Config GetCharacterTraitsConfig()
		{
			if (!(CharacterTraitsConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetCharacterTraitsConfig();
			}
			return CharacterTraitsConfig.Instance;
		}

		public LoanManager.Config GetLoanManagerConfig()
		{
			if (!(LoanManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetLoanManagerConfig();
			}
			return LoanManagerConfig.Instance;
		}

		public MarketingManager.Config GetMarketingConfig()
		{
			if (!(MarketingConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetMarketingConfig();
			}
			return MarketingConfig.Instance;
		}

		public WorkLifeBalanceManager.Config GetWorkLifeBalanceConfig()
		{
			if (!(WorkLifeBalanceConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetWorkLifeBalanceConfig();
			}
			return WorkLifeBalanceConfig.Instance;
		}

		public PriceModifiablesConfig GetPriceModifiablesConfig()
		{
			if (!(PriceModifiablesConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetPriceModifiablesConfig();
			}
			return PriceModifiablesConfig;
		}

		public StaffChallengeManager.Config GetStaffChallengeManagerConfig()
		{
			if (!(StaffChallengeManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetStaffChallengeManagerConfig();
			}
			return StaffChallengeManagerConfig.Instance;
		}

		public LevelDebugConfig GetLevelDebugConfig()
		{
			if (!(LevelDebugConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetLevelDebugConfig();
			}
			return LevelDebugConfig.Instance;
		}

		public LevelLightingConfig GetLevelLightingConfig()
		{
			if (!(LevelLightingConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetLevelLightingConfig();
			}
			return LevelLightingConfig;
		}

		public HospitalEventLog.Config GetHospitalEventLogConfig()
		{
			if (!(HospitalEventLogConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetHospitalEventLogConfig();
			}
			return HospitalEventLogConfig.Instance;
		}

		public DemolishLandscapeItemEffect.Config GetDemolishLandscapeItemEffectConfig()
		{
			if (!(DemolishLandscapeItemEffectConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetDemolishLandscapeItemEffectConfig();
			}
			return DemolishLandscapeItemEffectConfig.Instance;
		}

		public HospitalPolicy.ConfigData GetHospitalPolicyConfig()
		{
			if (!HospitalPolicyConfig.NotNull())
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetHospitalPolicyConfig();
			}
			return HospitalPolicyConfig.Instance;
		}

		public EmergencyDispatchMenu.Config GetEmergencyUIConfig()
		{
			if (!(EmergencyUIConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetEmergencyUIConfig();
			}
			return EmergencyUIConfig.Instance;
		}

		public RoomVisualOverridesDatabase GetRoomVisualOverridesDatabase()
		{
			if (!(RoomVisualOverridesDatabase != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetRoomVisualOverridesDatabase();
			}
			return RoomVisualOverridesDatabase;
		}

		public int SilverCost()
		{
			return _silverCost;
		}

		public LocalisedString GetUnlockName()
		{
			return default(LocalisedString);
		}

		public LocalisedString GetUnlockMessage()
		{
			return default(LocalisedString);
		}

		public Sprite GetUnlockIcon()
		{
			return null;
		}

		public ESandboxCheckType GetSandboxCheckType()
		{
			return ESandboxCheckType.None;
		}

		public string GetPlayableRequiredDescription()
		{
			if (DebugVars.EnableHandsOnDemo.Value && UniqueId != "901" && UniqueId != "902" && UniqueId != "903" && UniqueId != "904")
			{
				return "This demo is only for the first 4 levels. Sorry!";
			}
			string text = string.Empty;
			if (!_dlcPackRequired.IsNull() && !DLCUtils.IsDLCInstalled(_dlcPackRequired.Instance))
			{
				text += $"{GameStringUtils.GetDlcRequiredString(_dlcPackRequired.Instance)}\n";
			}
			if (LevelPlayablePrerequisites != null)
			{
				LevelProgressPrerequisite[] levelPlayablePrerequisites = LevelPlayablePrerequisites;
				foreach (LevelProgressPrerequisite levelProgressPrerequisite in levelPlayablePrerequisites)
				{
					text += $"{levelProgressPrerequisite.RequiredDescription()}\n";
				}
			}
			return text;
		}

		public bool IsVisible(Metagame metagame)
		{
			if (!metagame.IsUnlockMeTagTriggered(_isVisibleOverrideTag) && _levelVisiblePrerequisites != null && _levelVisiblePrerequisites.Length != 0)
			{
				return _levelVisiblePrerequisites.All((LevelProgressPrerequisite prerequisite) => prerequisite.IsComplete(metagame));
			}
			return true;
		}

		public bool IsPlayable(Metagame metagame)
		{
			if (DebugVars.EnableHandsOnDemo.Value && UniqueId != "901" && UniqueId != "902" && UniqueId != "903" && UniqueId != "904")
			{
				return false;
			}
			if (!_dlcPackRequired.IsNull() && !DLCUtils.IsDLCInstalled(_dlcPackRequired.Instance))
			{
				return false;
			}
			if (!metagame.IsUnlockMeTagTriggered(_isPlayableOverrideTag) && _levelPlayablePrerequisites != null && _levelPlayablePrerequisites.Length != 0)
			{
				return _levelPlayablePrerequisites.All((LevelProgressPrerequisite prerequisite) => prerequisite.IsComplete(metagame));
			}
			return true;
		}

		public PrestigeTracker.Config GetPrestigeConfig()
		{
			if (!(PrestigeConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetPrestigeConfig();
			}
			return PrestigeConfig.Instance;
		}

		public GuestTrainers.Config GetGuestTrainersConfig()
		{
			if (!(GuestTrainersConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetGuestTrainersConfig();
			}
			return GuestTrainersConfig.Instance;
		}

		public GuestTrainers.Config GetSandboxGuestTrainersConfig()
		{
			if (!(SandboxGuestTrainersConfig != null))
			{
				return GetGuestTrainersConfig();
			}
			return SandboxGuestTrainersConfig.Instance;
		}

		public string GetDescriptionForNumStars(int numStars)
		{
			if (DescriptionPerStarLocalised != null && DescriptionPerStarLocalised.Length != 0)
			{
				return DescriptionPerStarLocalised[Mathf.Min(DescriptionPerStarLocalised.Length - 1, numStars)].Translation;
			}
			if (DescriptionPerStar != null && DescriptionPerStar.Length != 0)
			{
				return DescriptionPerStar[Mathf.Min(DescriptionPerStar.Length - 1, numStars)];
			}
			return string.Empty;
		}

		public string GetDisplayName()
		{
			if (DisplayNameLocalised.Term == null)
			{
				return DisplayName;
			}
			return DisplayNameLocalised.ToString();
		}

		public string GetLocalisedDisplayName()
		{
			if (DisplayNameLocalised.Term == null)
			{
				return DisplayName;
			}
			return DisplayNameLocalised.Translation;
		}

		public LocalisedString GetLoadingDescriptionString()
		{
			return _loadingDescription;
		}

		public Sprite GetLoadingBackgroundSprite()
		{
			return _loadingBackground;
		}

		public MonoBeastManager.Config GetMonoBeastManagerConfig()
		{
			if (!(MonoBeastManagerConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetMonoBeastManagerConfig();
			}
			return MonoBeastManagerConfig.Instance;
		}

		public HospitalPlotFootprintVisual.Config GetHospitalPlotFootprintConfig()
		{
			if (!(HospitalPlotFootprintConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetHospitalPlotFootprintConfig();
			}
			return HospitalPlotFootprintConfig.Instance;
		}

		public ItemSpawnLimits.Config GetItemSpawnLimitsConfig()
		{
			if (!(ItemSpawnLimitsConfig != null))
			{
				if (!(BaseConfig != null))
				{
					return null;
				}
				return BaseConfig.Instance.GetItemSpawnLimitsConfig();
			}
			return ItemSpawnLimitsConfig.Instance;
		}
	}
}
