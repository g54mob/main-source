using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using LitJson;

namespace Gh.Tk
{
	[Serializable]
	public class GameDifficultySettingsData : IPersistable
	{
		private static GameDifficultySettingsData _dummy;

		private static (GameSettingsGameModifierAttribute attr, Action<GameDifficultySettingsData, int> setMethod, Func<GameDifficultySettingsData, int> getMethod)[] _gameSettingProperties;

		private static Dictionary<string, (GameSettingsGameModifierAttribute attr, Action<GameDifficultySettingsData, int> setMethod, Func<GameDifficultySettingsData, int> getMethod)> _gameSettingsPropertiesLookup;

		private DataStore _settings;

		private bool _isSettingPreset;

		public int minStartingMoney;

		public int maxStartingMoney;

		public int[] startingMoneyDifficultyPresets;

		public const int BankruptcyDelayDisabledValue = 49;

		public static GameDifficultySettingsData Current => null;

		[JsonIgnore]
		[IgnoreDataMember]
		public int StartingMoney
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("SpoilRateModifierPercentage", "Spoil Rate", false, new int[] { -50, 50 }, -101, 100, 0, -101, GameDifficultyValueDisplayType.Percentage, 0, "Storage")]
		public int SpoilRateModifierPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("LoanInterestRatingModifierPercentage", "Loan Interest Rates", false, new int[] { -50, 100 }, -80, 200, 0, -100, GameDifficultyValueDisplayType.Percentage, 0, "Money")]
		public int LoanInterestRatingModifierPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("BankruptcyDelay", "Bankruptcy Grace Period", true, new int[] { 49, 12 }, 2, 49, 24, 49, GameDifficultyValueDisplayType.Hours, 0, "Money")]
		public int BankruptcyDelay
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("GratuityPercentage", "Gratuity", true, new int[] { 35, 0 }, 0, 100, 0, -100, GameDifficultyValueDisplayType.Percentage, 0, "Money")]
		public int GratuityPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("SalesTaxPercentage", "Sales Tax", false, new int[] { 0, 25 }, 0, 50, 0, -100, GameDifficultyValueDisplayType.Percentage, 0, "Money")]
		public int SalesTaxPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("PatronPatienceModifierPercentage", "Patron Patience", true, new int[] { 50, -25 }, -50, 90, 0, -100, GameDifficultyValueDisplayType.Percentage, 0, "Patrons")]
		public int PatronPatienceModifierPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("DirtSpawnPercentage", "Dirt Spawning", false, new int[] { -50, 50 }, -80, 100, 0, -100, GameDifficultyValueDisplayType.Percentage, 0, "Dirt & Filth")]
		public int DirtSpawnPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("CleaningSpeedPercentage", "Cleaning Speed", true, new int[] { 50, -50 }, -80, 100, 0, -100, GameDifficultyValueDisplayType.Percentage, 0, "Dirt & Filth")]
		public int CleaningSpeedPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("FireChanceModifierPercentage", "Fire Chance", false, new int[] { -80, 20 }, -100, 100, 0, -100, GameDifficultyValueDisplayType.Percentage, 0, "Fire")]
		public int FireChanceModifierPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("FireFightEffectivenessModifierPercentage", "Fire Fighting Effectiveness", true, new int[] { 100, -40 }, -80, 200, 0, -100, GameDifficultyValueDisplayType.Percentage, 0, "Fire")]
		public int FireFightEffectivenessModifierPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("ContaminationChanceModifierPercentage", "Contamination Chance", false, new int[] { -80, 100 }, -100, 100, 0, -100, GameDifficultyValueDisplayType.Percentage, 0, "Cooking")]
		public int ContaminationChanceModifierPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("InfestationChanceModifierPercentage", "Infestation Chance", false, new int[] { -80, 20 }, -100, 100, 0, -100, GameDifficultyValueDisplayType.Percentage, 0, "Dirt & Filth")]
		public int InfestationChanceModifierPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("DeliveryTimeModiferPercentage", "Shop Delivery Time", false, new int[] { -50, 50 }, -80, 100, 0, -100, GameDifficultyValueDisplayType.Percentage, 0, "Shops")]
		public int DeliveryTimeModiferPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("StoryTellerFrequencyModifierPercentage", "Random Event Frequency", false, new int[] { -20, 0 }, -80, 20, 0, -100, GameDifficultyValueDisplayType.Custom, 10, "Storyteller")]
		public int StoryTellerFrequencyModifierPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("StoryTellerGoodBalanceEnabled", "Enable Good/Bad Balance", new bool[] { true, true }, true, "Storyteller")]
		public bool StoryTellerGoodBalanceEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("StoryTellerGoodBalance", "Event Good vs. Bad Balance", true, new int[] { 20, -20 }, -50, 50, 10, -100, GameDifficultyValueDisplayType.Percentage, 0, "Storyteller")]
		public int StoryTellerGoodBalance
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("StoryTellerChaosFactor", "Chaos Events", false, new int[] { 5, 35 }, 0, 100, 10, -100, GameDifficultyValueDisplayType.Custom, 0, "Storyteller")]
		public int StoryTellerChaosFactor
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("StoryTellerAllowVeryGoodEvents", "Allow Very Good Events", new bool[] { true, false }, true, "Storyteller")]
		public bool StoryTellerAllowVeryGoodEvents
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		[IgnoreDataMember]
		[GameSettingsGameModifier("StoryTellerAllowVeryBadEvents", "Allow Very Bad Events", new bool[] { false, true }, false, "Storyteller")]
		public bool StoryTellerAllowVeryBadEvents
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static event EventHandler<string> SettingsChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler PresetChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected GameDifficultySettingsData()
		{
		}

		public static GameDifficultySettingsData CreateNewBalancedSettingsData()
		{
			return null;
		}

		public static (GameSettingsGameModifierAttribute, Action<GameDifficultySettingsData, int>, Func<GameDifficultySettingsData, int>) GetPropertyByName(string propertyName)
		{
			return default((GameSettingsGameModifierAttribute, Action<GameDifficultySettingsData, int>, Func<GameDifficultySettingsData, int>));
		}

		public static (GameSettingsGameModifierAttribute, Action<GameDifficultySettingsData, int>, Func<GameDifficultySettingsData, int>)[] GetAllGameSettingProperties()
		{
			return null;
		}

		public static bool IsSettingDisabled(string propertyName)
		{
			return false;
		}

		public static int GetEffectiveGameBalanceSetting(string propertyName, StringBuilder detail = null)
		{
			return 0;
		}

		public static float GetContaminationChanceFactorFromGameSettings()
		{
			return 0f;
		}

		private bool SetSettingValue<T>(string key, T value)
		{
			return false;
		}

		private T GetSettingValue<T>(string key)
		{
			return default(T);
		}

		private T GetSettingValue<T>(string key, T defaultValue)
		{
			return default(T);
		}

		private bool HasSettingValue(string key)
		{
			return false;
		}

		public void SelectPreset(DifficultyPreset preset)
		{
		}

		public static void SelectPresetAndNotifyOfChange(DifficultyPreset preset)
		{
		}

		public DifficultyPreset GetCurrentPreset()
		{
			return default(DifficultyPreset);
		}

		public static void RaiseGameplayBalanceSettingsChangedEvent()
		{
		}

		private int GetGameBalanceSettingValue(string attrPropertyName, int defaultValue = 0)
		{
			return 0;
		}

		private void SetGameBalanceSettingValue(string key, int value)
		{
		}

		private void SaveAllValuesToCustom()
		{
		}

		public GameDifficultySettingsData CloneSlow()
		{
			return null;
		}
	}
}
