using System;
using System.Linq;
using FullInspector;
using JetBrains.Annotations;
using TH20.Analytics;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly]
	public class SandboxSettings
	{
		public string Name;

		public string DisplayName;

		public LevelConfig LevelConfig;

		public int Balance;

		public int Kudosh;

		public int Rooms;

		public int Items;

		public int Upgrades;

		public int ChallengesStaff;

		public int ChallengesPatient;

		public int ChallengesVisitor;

		public int ChallengesDisasters;

		public int ChallengesEpidemics;

		public int Temperature;

		public float PatientArrivalRate;

		public JobApplicantManager.Config JobApplicantsConfig;

		public LevelScriptManager.Config LevelScriptConfig;

		public float IncomeMultiplier;

		public WeightedIllnessList IllnessConfig;

		public int Plots;

		private int Level;

		private int JobApplicants;

		private int LevelScript;

		private int Illnesses;

		[DontSave]
		private SandboxSettingsConfig _config;

		[DontSave]
		private Texture2D _thumbnail;

		public Action OnSettingsChanged;

		public SandboxSettingsConfig Config => _config;

		public string SaveFolder => $"{Name.GetHashCode():X8}";

		public SandboxSettings(SandboxSettingsConfig config)
		{
			_config = config;
			Name = string.Empty;
			DisplayName = string.Empty;
			Reset();
		}

		public void Reset()
		{
			Level = 0;
			LevelConfig = _config.LevelOptions[Level].Level.Instance;
			Balance = (int)_config.BalanceOptions.Default;
			Kudosh = (int)_config.KudoshOptions.Default;
			IncomeMultiplier = _config.IncomeMultiplier.Default;
			Rooms = 1;
			Items = 1;
			Upgrades = 1;
			ChallengesStaff = 0;
			ChallengesPatient = 0;
			ChallengesVisitor = 0;
			ChallengesDisasters = 0;
			ChallengesEpidemics = 0;
			Temperature = 1;
			PatientArrivalRate = _config.PatientArrivalRateOptions.Default;
			JobApplicants = 0;
			JobApplicantsConfig = _config.JobApplicants[Level].Config.Instance;
			LevelScript = 0;
			LevelScriptConfig = _config.LevelScripts[Level].Config.Instance;
			Illnesses = 0;
			IllnessConfig = _config.WeightedIllnesses[Level].Config.Instance;
			Plots = 0;
		}

		public void RestoreFromSave(SandboxSettingsConfig config, int fileVersion)
		{
			_config = config;
			if (fileVersion < 5 || LevelConfig == null || JobApplicantsConfig == null || LevelScriptConfig == null || IllnessConfig == null)
			{
				LevelConfig = _config.OldLevelOrder[Level].Instance;
				JobApplicantsConfig = _config.JobApplicants[JobApplicants].Config.Instance;
				LevelScriptConfig = _config.LevelScripts[LevelScript].Config.Instance;
				IllnessConfig = _config.WeightedIllnesses[Illnesses].Config.Instance;
			}
		}

		public void Apply(Level level, bool playingLevel)
		{
			Metagame metagame = level.Metagame;
			if (!playingLevel)
			{
				if (Plots == 1)
				{
					foreach (HospitalPlot hospitalPlot in level.WorldState.HospitalPlots)
					{
						hospitalPlot.SetBoughtNoBuild();
					}
					foreach (HospitalPlot hospitalPlot2 in level.WorldState.HospitalPlots)
					{
						if (hospitalPlot2.HospitalMap != null)
						{
							level.WorldState.SetBoughtHospitalMap(hospitalPlot2.HospitalMap);
							if (hospitalPlot2.HospitalMap.HasMergedPlots)
							{
								hospitalPlot2.HospitalMap.RebuildWalls();
							}
						}
					}
					level.WorldState.UpdateNavigation();
				}
				level.FinanceManager.Balance = Balance;
				metagame.AwardSilver(Kudosh);
				metagame.RemoveExcludedResearchProjects();
			}
			SetupRooms(metagame, level);
			SetupItems(metagame, level);
			level.WorldState.HospitalAttributeMaps[0].OverrideInitialValue(_config.TemperatureOptions[Temperature].Value);
			level.CharacterManager.OverrideIllnesses(IllnessConfig);
			level.CharacterManager.PatientArrivalRateMultiplier = PatientArrivalRate;
			level.CharacterManager.OverrideAnachronisticManager(_config.AnachronisticManagerConfig.Instance);
			level.FinanceManager.IncomeMultiplier = IncomeMultiplier;
			level.JobApplicantManager.OnConfigChanged(level.GetJobApplicantManagerConfig());
			level.LevelAnalyticsManager.SendSandboxSetupData();
		}

		private void SetupRooms(Metagame metagame, Level level)
		{
			bool num = Rooms == 0;
			BuildEvents buildEvents = level.BuildEvents;
			SharedInstance<RoomDefinition>[] rooms;
			if (num)
			{
				LevelRoomList levelRoomBlacklist = level.GetSandboxSettings().GetLevelRoomBlacklist();
				LevelRoomList levelRoomWhitelist = level.GetSandboxSettings().GetLevelRoomWhitelist();
				rooms = metagame.RoomDatabase.Instance.Rooms;
				foreach (SharedInstance<RoomDefinition> sharedInstance in rooms)
				{
					if ((sharedInstance.Instance.DlcPackRequired.IsNull() || DLCUtils.IsDLCInstalled(sharedInstance.Instance.DlcPackRequired.Instance)) && (!sharedInstance.Instance.MustBeWhiteListed || (levelRoomWhitelist != null && levelRoomWhitelist.RoomList.Contains(sharedInstance))) && (levelRoomBlacklist == null || !levelRoomBlacklist.RoomList.Contains(sharedInstance)))
					{
						metagame.UnlockItem(sharedInstance.Instance, spendSilver: false, showMessage: false);
					}
				}
				return;
			}
			rooms = _config.InitialRooms;
			foreach (SharedInstance<RoomDefinition> sharedInstance2 in rooms)
			{
				if (sharedInstance2.Instance.DlcPackRequired.IsNull() || DLCUtils.IsDLCInstalled(sharedInstance2.Instance.DlcPackRequired.Instance))
				{
					buildEvents.OnAddRoomDefinition.InvokeSafe(sharedInstance2.Instance, param2: true, param3: false, param4: false);
				}
			}
		}

		private void SetupItems(Metagame metagame, Level level)
		{
			bool flag = Items == 0;
			bool flag2 = Upgrades == 0;
			BuildEvents buildEvents = level.BuildEvents;
			LevelItemList levelItemBlacklist = level.GetSandboxSettings().GetLevelItemBlacklist();
			LevelItemList levelItemWhitelist = level.GetSandboxSettings().GetLevelItemWhitelist();
			SharedInstance<RoomItemDefinition>[] roomItems = metagame.RoomItemDatabase.Instance.RoomItems;
			foreach (SharedInstance<RoomItemDefinition> sharedInstance in roomItems)
			{
				RoomItemDefinition instance = sharedInstance.Instance;
				if (instance.ItemDeprecated || (instance.MustBeWhiteListed && (!(levelItemWhitelist != null) || !levelItemWhitelist.ItemList.Contains(sharedInstance))) || (!(levelItemBlacklist == null) && levelItemBlacklist.ItemList.Contains(sharedInstance)))
				{
					continue;
				}
				bool num = instance.DlcPackRequired.IsNull() && instance.PrimeEntitlementRequired == 0 && instance.CollaborativeResearchRequired.IsNull() && instance.SuperBugVictoryRequired.IsNull();
				bool flag3 = !instance.DlcPackRequired.IsNull() && DLCUtils.IsDLCOwned(instance.DlcPackRequired.Instance);
				bool flag4 = (instance.PrimeEntitlementRequired > 0 && level.App.UserProfile.PrimeEntitlementClaimed(instance.PrimeEntitlementRequired.ToString())) || flag3;
				bool flag5 = !instance.CollaborativeResearchRequired.IsNull() && (metagame.IsCollaborativeResearchProjectCompleted(instance.CollaborativeResearchRequired.Instance) || metagame.GiveAllCollaborativeRewards);
				bool flag6 = !instance.SuperBugVictoryRequired.IsNull() && (metagame.IsSuperBugVictoryAchieved(instance.SuperBugVictoryRequired.Instance) || metagame.GiveAllCollaborativeRewards);
				if (!num && !flag4 && !flag5 && !flag6)
				{
					continue;
				}
				if (flag || !instance.InitiallyAvailable)
				{
					buildEvents.OnAddRoomItemDefinition.InvokeSafe(instance, flag, param3: false, param4: false);
				}
				if (instance.Upgrades == null || (!flag2 && instance.InitiallyAvailable))
				{
					continue;
				}
				SharedInstance<RoomItemUpgradeDefinition>[] upgrades = instance.Upgrades;
				foreach (SharedInstance<RoomItemUpgradeDefinition> sharedInstance2 in upgrades)
				{
					if (!sharedInstance2.Instance.RequiresSandboxResearch)
					{
						metagame.UnlockItem(sharedInstance2.Instance, spendSilver: false, showMessage: false);
					}
				}
			}
			if (!flag)
			{
				return;
			}
			StaffDefinition.Type[] allTypes = StaffDefinition.AllTypes;
			foreach (StaffDefinition.Type staffType in allTypes)
			{
				CustomisationOption[] options = metagame.MetagameConfig.StaffCustomisationOptions.GetOptions(staffType);
				if (options != null)
				{
					CustomisationOption[] array = options;
					foreach (CustomisationOption silverUnlockable in array)
					{
						metagame.UnlockItem(silverUnlockable, spendSilver: false, showMessage: false);
					}
				}
			}
		}

		public static bool IsChallengeConfigValid(ChallengeConfig config)
		{
			SandboxSettings currentSettings = SandboxSaveManager.CurrentSettings;
			if (currentSettings != null)
			{
				if (config is ChallengeEarthquakeConfig && currentSettings.ChallengesDisasters != 0)
				{
					return false;
				}
				if (config is ChallengeEpidemicConfig && currentSettings.ChallengesEpidemics != 0)
				{
					return false;
				}
				if (config is ChallengeSpecialPatientConfig && currentSettings.ChallengesPatient != 0)
				{
					return false;
				}
				if (config is VIPChallengeConfig && currentSettings.ChallengesVisitor != 0)
				{
					return false;
				}
			}
			return true;
		}

		public static bool AreStaffChallengesAvailable()
		{
			SandboxSettings currentSettings = SandboxSaveManager.CurrentSettings;
			if (currentSettings != null)
			{
				return currentSettings.ChallengesStaff == 0;
			}
			return true;
		}

		public void AddSetupAnalyticsEventData(GameEvent sandboxSetupDataEvent, Level level)
		{
			sandboxSetupDataEvent?.AddLevelHeader(level).AddParam("userLevelName", Name).AddParam("originalLevelId", level.Config.UniqueId)
				.AddParam("balance", Balance)
				.AddParam("kudosh", Kudosh)
				.AddParam("incomeMultiplier", IncomeMultiplier)
				.AddParam("patientArrivalRate", PatientArrivalRate)
				.AddParam("illnesses", _config.WeightedIllnesses[GetIllnessListIndex()].AnalyticsName)
				.AddParam("objectives", _config.LevelScripts[GetLevelScriptIndex()].AnalyticsName)
				.AddParam("staffHiring", _config.JobApplicants[GetJobApplicantsIndex()].AnalyticsName)
				.AddParam("temperature", _config.TemperatureOptions[Temperature].Value)
				.AddParam("roomOptions", _config.RoomOptions[Rooms].AnalyticsName)
				.AddParam("itemsOptions", _config.ItemOptions[Items].AnalyticsName)
				.AddParam("upgradeOptions", _config.UpgradeOptions[Upgrades].AnalyticsName)
				.AddParam("plotOptions", _config.PlotOptions[Plots].AnalyticsName)
				.AddParam("challengesStaff", ChallengesStaff)
				.AddParam("challengesPatient", ChallengesPatient)
				.AddParam("challengesDisasters", ChallengesDisasters)
				.AddParam("challengesEpidemics", ChallengesEpidemics);
		}

		public Texture2D GetThumbnailTexture(SaveSystem saveSystem, SaveFileHeader saveFileHeader, Level level, bool uncompressedFormat = false)
		{
			SaveFileHeader saveFileHeader2 = ((saveFileHeader == null) ? saveSystem.GetSaveForSandbox(this) : saveFileHeader);
			if (saveFileHeader2 == null)
			{
				_thumbnail = SandboxThumbnail.Generate(_config.LevelOptions[Level].Level.Instance, _config.LevelOptions[Level].GetThumbnailStyle(_config.ThumbnailStyle.Instance));
			}
			else
			{
				_thumbnail = new Texture2D(1, 1, uncompressedFormat ? TextureFormat.ARGB32 : TextureFormat.DXT1, mipChain: false, linear: false);
				if (level != null && this == SandboxSaveManager.CurrentSettings)
				{
					_thumbnail.LoadImage(level.ThumbnailPNG);
				}
				else
				{
					_thumbnail.LoadImage(saveFileHeader2.ThumbnailPNG);
				}
			}
			return _thumbnail;
		}

		public void SetJobApplicantsIndex(int index)
		{
			JobApplicantsConfig = _config.JobApplicants[index].Config.Instance;
		}

		public int GetJobApplicantsIndex()
		{
			for (int i = 0; i < _config.JobApplicants.Length; i++)
			{
				if (_config.JobApplicants[i].Config.Instance == JobApplicantsConfig)
				{
					return i;
				}
			}
			return 0;
		}

		public void SetLevelScriptIndex(int index)
		{
			LevelScriptConfig = _config.LevelScripts[index].Config.Instance;
		}

		public int GetLevelScriptIndex()
		{
			for (int i = 0; i < _config.LevelScripts.Length; i++)
			{
				if (_config.LevelScripts[i].Config.Instance == LevelScriptConfig)
				{
					return i;
				}
			}
			return 0;
		}

		public void SetIllnessListIndex(int index)
		{
			WeightedIllnessList instance = _config.WeightedIllnesses[index].Config.Instance;
			while (!instance.IsValid())
			{
				index++;
				if (index >= _config.WeightedIllnesses.Length)
				{
					index = 0;
				}
				instance = _config.WeightedIllnesses[index].Config.Instance;
			}
			IllnessConfig = instance;
		}

		public int GetIllnessListIndex()
		{
			for (int i = 0; i < _config.WeightedIllnesses.Length; i++)
			{
				if (_config.WeightedIllnesses[i].Config.Instance == IllnessConfig)
				{
					return i;
				}
			}
			return 0;
		}

		public bool ShouldUnlockableItemBeUnlockedForCheckType(ESandboxCheckType checkType)
		{
			bool result = false;
			switch (checkType)
			{
			case ESandboxCheckType.Rooms:
				result = SandboxSaveManager.CurrentSettings.Rooms == 0;
				break;
			case ESandboxCheckType.RoomItems:
				result = SandboxSaveManager.CurrentSettings.Items == 0;
				break;
			case ESandboxCheckType.RoomItemUpgrades:
				result = SandboxSaveManager.CurrentSettings.Upgrades == 0;
				break;
			}
			return result;
		}

		public LevelRoomList GetLevelRoomBlacklist()
		{
			return _config.LevelRoomBlacklist;
		}

		public LevelRoomList GetLevelRoomWhitelist()
		{
			return _config.LevelRoomWhitelist;
		}

		public LevelItemList GetLevelItemBlacklist()
		{
			return _config.LevelItemBlacklist;
		}

		public LevelItemList GetLevelItemWhitelist()
		{
			return _config.LevelItemWhitelist;
		}
	}
}
