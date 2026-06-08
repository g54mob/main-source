using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik.CreativeMode;
using UnityEngine;

namespace Dorfromantik
{
	public class CustomModeConfiguration : ScriptableObject
	{
		private sealed class _003C_003Ec__DisplayClass42_0
		{
			public CustomRuleType ruleType;

			internal bool _003CSetCustomRuleValue_003Eb__0(CustomRuleData x)
			{
				return x.ruleType == ruleType;
			}
		}

		private sealed class _003C_003Ec__DisplayClass45_0
		{
			public CustomRuleType ruleType;

			internal bool _003CGetCurrentLevel_003Eb__0(CustomRuleData x)
			{
				return x.ruleType == ruleType;
			}
		}

		private sealed class _003C_003Ec__DisplayClass46_0
		{
			public CustomRuleType ruleType;

			internal bool _003CGetDefaultLevel_003Eb__0(CustomRuleData x)
			{
				return x.ruleType == ruleType;
			}
		}

		private sealed class _003C_003Ec__DisplayClass48_0
		{
			public CustomRuleType ruleType;

			internal bool _003CGetProbabilityByLevel_003Eb__0(CustomModeLevelProbabilities x)
			{
				return x.ruleType == ruleType;
			}

			internal bool _003CGetProbabilityByLevel_003Eb__1(CustomModeLevelProbabilities x)
			{
				return x.ruleType == ruleType;
			}
		}

		private sealed class _003C_003Ec__DisplayClass55_0
		{
			public CustomRuleData currentLevel;

			internal bool _003CReset_003Eb__0(CustomRuleData x)
			{
				return x.ruleType == currentLevel.ruleType;
			}
		}

		public int configStringLength = 12;

		public int separatorIndex = 4;

		public string configString;

		public int seed;

		public int year;

		public int month;

		private DateTime currentTime;

		private DateTime currentRemoteTime;

		[SerializeField]
		private List<GroupTypeProbability> debug_ElementProbabilities;

		public List<CustomRuleData> currentLevels;

		public NumberSystemConverter numberConverter;

		[SerializeField]
		private MonthlyModeManager monthlyModeManager;

		[SerializeField]
		private GameModeLibrary gameModeLibrary;

		[SerializeField]
		private SettingsRouter settingsRouter;

		public CustomRuleLevelConfiguration levelConfiguration;

		[SerializeField]
		private bool ignoreDateValidation;

		[SerializeField]
		private bool useOverwriteDate;

		[SerializeField]
		private bool useRandomOverwriteDate;

		[SerializeField]
		private int overwriteYear;

		[SerializeField]
		private int overwriteMonth;

		[SerializeField]
		private Vector2Int overwriteYearRange;

		[SerializeField]
		private Vector2Int overwriteMonthRange;

		private readonly Dictionary<GroupTypeId, CustomRuleType> ruleTypeByGroupType = new Dictionary<GroupTypeId, CustomRuleType>
		{
			{
				GroupTypeId.Village,
				CustomRuleType.VillageProbability
			},
			{
				GroupTypeId.Forest,
				CustomRuleType.ForestProbability
			},
			{
				GroupTypeId.Agriculture,
				CustomRuleType.AgricultureProbability
			},
			{
				GroupTypeId.Water,
				CustomRuleType.WaterProbability
			},
			{
				GroupTypeId.TrainTracks,
				CustomRuleType.TrainTrackProbability
			}
		};

		private Dictionary<CustomRuleType, GroupTypeId> groupTypeByRuleType = new Dictionary<CustomRuleType, GroupTypeId>
		{
			{
				CustomRuleType.VillageProbability,
				GroupTypeId.Village
			},
			{
				CustomRuleType.ForestProbability,
				GroupTypeId.Forest
			},
			{
				CustomRuleType.AgricultureProbability,
				GroupTypeId.Agriculture
			},
			{
				CustomRuleType.WaterProbability,
				GroupTypeId.Water
			},
			{
				CustomRuleType.TrainTrackProbability,
				GroupTypeId.TrainTracks
			}
		};

		private bool UsingRandomOverwriteDate
		{
			get
			{
				if (useOverwriteDate)
				{
					return useRandomOverwriteDate;
				}
				return false;
			}
		}

		private bool UsingFixedOverwriteDate
		{
			get
			{
				if (useOverwriteDate)
				{
					return !useRandomOverwriteDate;
				}
				return false;
			}
		}

		public bool HasInfiniteTileStack => float.IsPositiveInfinity(GetValue(CustomRuleType.TileStackHeight));

		public string DateKey => $"{year:0000}{month:00}";

		public event Action OnUpdated;

		public event Action OnRequestCurrentTime;

		public event Action<CustomRuleType, int> OnRuleUpdated;

		public void LoadFrom(CustomModeData loadedGameCustomModeData)
		{
			configString = loadedGameCustomModeData.configString;
			seed = loadedGameCustomModeData.seed;
			year = loadedGameCustomModeData.year;
			month = loadedGameCustomModeData.month;
			foreach (CustomRuleData customRuleDatum in loadedGameCustomModeData.customRuleData)
			{
				if (Enum.IsDefined(typeof(CustomRuleType), customRuleDatum.ruleType))
				{
					SetCustomRuleValue(customRuleDatum.ruleType, customRuleDatum.value);
				}
			}
			this.OnUpdated?.Invoke();
		}

		private void SetCustomRuleValue(CustomRuleType ruleType, int level)
		{
			_003C_003Ec__DisplayClass42_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass42_0();
			CS_0024_003C_003E8__locals2.ruleType = ruleType;
			Enumerable.First(currentLevels, (CustomRuleData x) => x.ruleType == CS_0024_003C_003E8__locals2.ruleType).value = level;
		}

		public float GetValue(CustomRuleType ruleType)
		{
			int currentLevel = GetCurrentLevel(ruleType);
			return GetProbabilityByLevel(ruleType, currentLevel);
		}

		public string GetDisplayValue(CustomRuleType ruleType, int level)
		{
			switch (ruleType)
			{
			case CustomRuleType.VillageProbability:
			case CustomRuleType.ForestProbability:
			case CustomRuleType.AgricultureProbability:
			case CustomRuleType.WaterProbability:
			case CustomRuleType.TrainTrackProbability:
				if (level != 1)
				{
					return $"{GetProbabilityByLevel(ruleType, level) / 10f:##0}%";
				}
				return LocalizationManager.Instance.GetLocalizedValue("off").ToUpper();
			case CustomRuleType.QuestProbability:
			case CustomRuleType.QuestDifficulty:
			case CustomRuleType.FlagQuestProbability:
				return $"{GetProbabilityByLevel(ruleType, level) * 100f}%";
			case CustomRuleType.TileStackHeight:
				if (level == 9)
				{
					return "∞";
				}
				break;
			case CustomRuleType.TileLimit:
				if (GetProbabilityByLevel(CustomRuleType.TileLimit, level) == 0f)
				{
					return LocalizationManager.Instance.GetLocalizedValue("off").ToUpper();
				}
				break;
			case CustomRuleType.WorldBorderRadius:
				if (level == 1)
				{
					return LocalizationManager.Instance.GetLocalizedValue("off").ToUpper();
				}
				break;
			}
			return GetProbabilityByLevel(ruleType, level).ToString();
		}

		public int GetCurrentLevel(CustomRuleType ruleType)
		{
			_003C_003Ec__DisplayClass45_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass45_0();
			CS_0024_003C_003E8__locals2.ruleType = ruleType;
			return Enumerable.First(currentLevels, (CustomRuleData x) => x.ruleType == CS_0024_003C_003E8__locals2.ruleType).value;
		}

		public int GetDefaultLevel(CustomRuleType ruleType)
		{
			_003C_003Ec__DisplayClass46_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass46_0();
			CS_0024_003C_003E8__locals2.ruleType = ruleType;
			return Enumerable.First(levelConfiguration.defaultLevels, (CustomRuleData x) => x.ruleType == CS_0024_003C_003E8__locals2.ruleType).value;
		}

		public void SetupFromConfigString(string newConfigString, int newSeed = -1)
		{
			configString = newConfigString.Replace("-", "");
			while (configString.Length < configStringLength)
			{
				configString += "0";
			}
			if (configString.Length > configStringLength)
			{
				configString = configString.Substring(0, configStringLength);
			}
			seed = ((newSeed != -1) ? newSeed : numberConverter.DecodeNumber(configString.Substring(0, 6)));
			numberConverter.DecodeNumber(configString.Substring(6, 6), numberCanBeNegative: false);
			List<int> list = numberConverter.DecodeNumberAsDigits(configString.Substring(6, 6));
			while (list.Count < 10)
			{
				list.Insert(0, 0);
			}
			SetCustomRuleValue(CustomRuleType.VillageProbability, list[1]);
			SetCustomRuleValue(CustomRuleType.ForestProbability, list[2]);
			SetCustomRuleValue(CustomRuleType.AgricultureProbability, list[3]);
			SetCustomRuleValue(CustomRuleType.WaterProbability, list[4]);
			SetCustomRuleValue(CustomRuleType.TrainTrackProbability, list[5]);
			SetCustomRuleValue(CustomRuleType.TileStackHeight, list[6]);
			SetCustomRuleValue(CustomRuleType.TileLimit, list[7]);
			SetCustomRuleValue(CustomRuleType.Density, list[8]);
			SetCustomRuleValue(CustomRuleType.QuestProbability, list[9]);
			List<int> list2 = numberConverter.DecodeNumberAsDigits(configString.Substring(12, 6));
			while (list2.Count < 10)
			{
				list2.Insert(0, 0);
			}
			SetCustomRuleValue(CustomRuleType.QuestDifficulty, list2[1]);
			SetCustomRuleValue(CustomRuleType.FlagQuestProbability, list2[2]);
			SetCustomRuleValue(CustomRuleType.WorldBorderRadius, list2[3]);
			this.OnUpdated?.Invoke();
		}

		public float GetProbabilityByLevel(CustomRuleType ruleType, int level)
		{
			_003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass48_0();
			CS_0024_003C_003E8__locals5.ruleType = ruleType;
			if (level == 0)
			{
				level = GetDefaultLevel(CS_0024_003C_003E8__locals5.ruleType);
			}
			if (Enumerable.Count(levelConfiguration.probabilityByLevel, (CustomModeLevelProbabilities x) => x.ruleType == CS_0024_003C_003E8__locals5.ruleType) == 0)
			{
				Debug.LogError($"no entry in probabilityByLevel for {CS_0024_003C_003E8__locals5.ruleType}");
				return 0f;
			}
			return Enumerable.First(levelConfiguration.probabilityByLevel, (CustomModeLevelProbabilities x) => x.ruleType == CS_0024_003C_003E8__locals5.ruleType).probabilityByLevel[level];
		}

		public string GetDisplayConfigString()
		{
			string text = configString;
			for (int i = separatorIndex; i < configString.Length; i += separatorIndex + 1)
			{
				text = text.Insert(i, "-");
			}
			return text;
		}

		public void CopyConfigStringToClipboard()
		{
			ClipboardUtility.CopyToClipboard(GetDisplayConfigString());
		}

		public bool IsScoreValid(LeaderboardEntryData entryData)
		{
			if (entryData.tileLimit > 0 && entryData.tilesPlaced > entryData.tileLimit + 3)
			{
				Debug.Log($"Score not valid - tiles placed: {entryData.tilesPlaced}, " + $"tile limit: {entryData.tileLimit + 3}");
				return false;
			}
			if (entryData.worldBorder > 0 && entryData.tilesPlaced > WorldBorder.MaxTilesByWorldBorder[entryData.worldBorder] + 3)
			{
				Debug.Log($"Score not valid - tiles placed: {entryData.tilesPlaced}, " + $"world Border: {entryData.worldBorder}, " + $"maxAllowedTiles: {WorldBorder.MaxTilesByWorldBorder[entryData.worldBorder] + 3}");
				return false;
			}
			GameMode gameModeById = gameModeLibrary.GetGameModeById(entryData.gameModeId);
			if (gameModeById.configType == CustomConfigType.PredefinedWithRandomSeed && gameModeById.configurationString != entryData.configString)
			{
				Debug.Log("Wrong config string! used: " + entryData.configString + ", required: " + gameModeById.configurationString);
				return false;
			}
			if (ignoreDateValidation)
			{
				return true;
			}
			if (settingsRouter.defaultSettings.validateServerTimeInMonthlyMode)
			{
				RequestCurrentRemoteTime();
				if (gameModeById.configType == CustomConfigType.Monthly && (entryData.configString != monthlyModeManager.GetCurrentConfigString().Replace("-", "") || entryData.year != currentRemoteTime.Year || entryData.month != currentRemoteTime.Month))
				{
					Debug.Log("Not submitting monthly highscore: " + $"Remote time {currentRemoteTime.Month:00}/{currentRemoteTime.Year:0000}, " + $"Game time: {month:00}/{year:0000}\n" + "Month seed: " + monthlyModeManager.GetCurrentConfigString() + ", Game seed: " + configString + ",\n" + $"ignore date validation: {ignoreDateValidation}");
					return false;
				}
			}
			return true;
		}

		public void SetCurrentRemoteTime(DateTime utcTime)
		{
			currentRemoteTime = utcTime.ToLocalTime();
		}

		public void InitializeCurrentTime()
		{
			currentTime = DateTime.MinValue;
			currentRemoteTime = DateTime.MinValue;
			this.OnRequestCurrentTime?.Invoke();
			currentTime = ((currentRemoteTime != DateTime.MinValue) ? currentRemoteTime : DateTime.Now);
			if (useOverwriteDate)
			{
				if (useRandomOverwriteDate)
				{
					year = UnityEngine.Random.Range(overwriteYearRange.x, overwriteYearRange.y + 1);
					month = UnityEngine.Random.Range(overwriteMonthRange.x, overwriteMonthRange.y + 1);
				}
				else
				{
					year = overwriteYear;
					month = overwriteMonth;
				}
			}
			else
			{
				year = currentTime.Year;
				month = currentTime.Month;
			}
		}

		public void RequestCurrentRemoteTime()
		{
			currentRemoteTime = DateTime.Now;
			this.OnRequestCurrentTime?.Invoke();
		}

		public void Reset()
		{
			using (List<CustomRuleData>.Enumerator enumerator = currentLevels.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass55_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass55_0();
					CS_0024_003C_003E8__locals3.currentLevel = enumerator.Current;
					CS_0024_003C_003E8__locals3.currentLevel.value = Enumerable.First(levelConfiguration.defaultLevels, (CustomRuleData x) => x.ruleType == CS_0024_003C_003E8__locals3.currentLevel.ruleType).value;
				}
			}
			month = 0;
			year = 0;
		}
	}
}
