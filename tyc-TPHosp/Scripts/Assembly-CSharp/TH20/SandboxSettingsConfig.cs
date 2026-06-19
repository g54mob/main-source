using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class SandboxSettingsConfig
	{
		public readonly SandboxSliderOption BalanceOptions;

		public readonly SandboxSliderOption KudoshOptions;

		public readonly SandboxSliderOption IncomeMultiplier;

		public readonly SandboxLevelOption[] LevelOptions;

		public readonly SharedInstance<LevelConfig>[] OldLevelOrder;

		public readonly SharedInstance<RoomDefinition>[] InitialRooms;

		public readonly LevelRoomList LevelRoomBlacklist;

		public readonly LevelRoomList LevelRoomWhitelist;

		public readonly LevelItemList LevelItemBlacklist;

		public readonly LevelItemList LevelItemWhitelist;

		public readonly SandboxJobApplicantsOption[] JobApplicants;

		public readonly SandboxLevelScriptOption[] LevelScripts;

		public readonly SandboxWeightedIllnessesOption[] WeightedIllnesses;

		public readonly SandboxToggleOption[] OnOffOptions = new SandboxToggleOption[2]
		{
			new SandboxToggleOption(),
			new SandboxToggleOption()
		};

		public readonly SandboxToggleOption[] RoomOptions = new SandboxToggleOption[2]
		{
			new SandboxToggleOption(),
			new SandboxToggleOption()
		};

		public readonly SandboxToggleOption[] ItemOptions = new SandboxToggleOption[2]
		{
			new SandboxToggleOption(),
			new SandboxToggleOption()
		};

		public readonly SandboxToggleOption[] UpgradeOptions = new SandboxToggleOption[2]
		{
			new SandboxToggleOption(),
			new SandboxToggleOption()
		};

		public readonly SandboxTemperatureOption[] TemperatureOptions = new SandboxTemperatureOption[3]
		{
			new SandboxTemperatureOption
			{
				Value = -1f
			},
			new SandboxTemperatureOption
			{
				Value = 0f
			},
			new SandboxTemperatureOption
			{
				Value = 1f
			}
		};

		public readonly SandboxToggleOption[] PlotOptions = new SandboxToggleOption[2]
		{
			new SandboxToggleOption(),
			new SandboxToggleOption()
		};

		public readonly SandboxSliderOption PatientArrivalRateOptions;

		public readonly SharedInstance<SandboxThumbnail.Style> ThumbnailStyle;

		[InspectorHeader("Localisation")]
		public LocalisedString LevelName = new LocalisedString("Menu/Sandbox/LevelName_CS");

		public LocalisedString LevelTooltip = new LocalisedString("Menu/Sandbox/LevelName_CS");

		public LocalisedString CashName = new LocalisedString("Menu/Sandbox/Cash_CS");

		public LocalisedString CashTooltip = new LocalisedString("Menu/Sandbox/Cash_CS");

		public LocalisedString KudoshName = new LocalisedString("Menu/Sandbox/Kudosh_CS");

		public LocalisedString KudoshTooltip = new LocalisedString("Menu/Sandbox/Kudosh_CS");

		public LocalisedString IncomeMultiplierName = new LocalisedString("Menu/Sandbox/IncomeMultiplier_CS");

		public LocalisedString IncomeMultiplierTooltip = new LocalisedString("Menu/Sandbox/IncomeMultiplier_CS");

		public LocalisedString PatientArrivalRateName = new LocalisedString("Menu/Sandbox/PatientArrivalRate_CS");

		public LocalisedString PatientArrivalRateTooltip = new LocalisedString("Menu/Sandbox/PatientArrivalRate_CS");

		public LocalisedString IllnessesName = new LocalisedString("Menu/Sandbox/Illnesses_CS");

		public LocalisedString IllnessesTooltip = new LocalisedString("Menu/Sandbox/Illnesses_CS");

		public LocalisedString ObjectivesName = new LocalisedString("Menu/Sandbox/Objectives_CS");

		public LocalisedString ObjectivesTooltip = new LocalisedString("Menu/Sandbox/Objectives_CS");

		public LocalisedString JobApplicantsName = new LocalisedString("Menu/Sandbox/JobApplicants_CS");

		public LocalisedString JobApplicantsTooltip = new LocalisedString("Menu/Sandbox/JobApplicants_CS");

		public LocalisedString TemperatureName = new LocalisedString("Menu/Sandbox/Temperature_CS");

		public LocalisedString TemperatureTooltip = new LocalisedString("Menu/Sandbox/Temperature_CS");

		public LocalisedString RoomsName = new LocalisedString("Menu/Sandbox/Rooms_CS");

		public LocalisedString RoomsTooltip = new LocalisedString("Menu/Sandbox/Rooms_CS");

		public LocalisedString ItemsName = new LocalisedString("Menu/Sandbox/Items_CS");

		public LocalisedString ItemsTooltip = new LocalisedString("Menu/Sandbox/Items_CS");

		public LocalisedString UpgradesName = new LocalisedString("Menu/Sandbox/Upgrades_CS");

		public LocalisedString UpgradesTooltip = new LocalisedString("Menu/Sandbox/Upgrades_CS");

		public LocalisedString PlotsName = new LocalisedString("Menu/Sandbox/Plots_CS");

		public LocalisedString PlotsTooltip = new LocalisedString("Menu/Sandbox/Plots_CS");

		public LocalisedString ChallengesStaffName = new LocalisedString("Menu/Sandbox/Challenges_Staff_CS");

		public LocalisedString ChallengesStaffTooltip = new LocalisedString("Menu/Sandbox/Challenges_Staff_CS");

		public LocalisedString ChallengesPatientsName = new LocalisedString("Menu/Sandbox/Challenges_Patients_CS");

		public LocalisedString ChallengesPatientsTooltip = new LocalisedString("Menu/Sandbox/Challenges_Patients_CS");

		public LocalisedString ChallengesVIPsName = new LocalisedString("Menu/Sandbox/Challenges_VIPs_CS");

		public LocalisedString ChallengesVIPsTooltip = new LocalisedString("Menu/Sandbox/Challenges_VIPs_CS");

		public LocalisedString ChallengesDisastersName = new LocalisedString("Menu/Sandbox/Challenges_Disasters_CS");

		public LocalisedString ChallengesDisastersTooltip = new LocalisedString("Menu/Sandbox/Challenges_Disasters_CS");

		public LocalisedString ChallengesEpidemicsName = new LocalisedString("Menu/Sandbox/Challenges_Epidemics_CS");

		public LocalisedString ChallengesEpidemicsTooltip = new LocalisedString("Menu/Sandbox/Challenges_Epidemics_CS");

		[InspectorHeader("Level Config Overrides")]
		public readonly SharedInstance<Advisor.Config> AdvisorConfig;

		public readonly SharedInstance<FinanceManager.Config> FinanceConfig;

		public readonly SharedInstance<ResearchManager.Config> ResearchConfig;

		public readonly SharedInstance<ChallengeManager.Config> ChallengeConfig;

		public readonly SharedInstance<StaffChallengeManager.Config> StaffChallengeConfig;

		public readonly SharedInstance<HospitalAwardsManager.Config> HospitalAwardsConfig;

		public readonly SharedInstance<AnachronisticManager.EraConfig> AnachronisticManagerConfig;
	}
}
