using System;
using System.Collections.Generic;
using System.Linq;

namespace Dorfromantik
{
	[Serializable]
	public class CustomModeData
	{
		private sealed class _003C_003Ec__DisplayClass6_0
		{
			public CustomRuleType ruleType;

			internal bool _003CSetCustomRuleValue_003Eb__0(CustomRuleData x)
			{
				return x.ruleType == ruleType;
			}

			internal bool _003CSetCustomRuleValue_003Eb__1(CustomRuleData x)
			{
				return x.ruleType == ruleType;
			}
		}

		private sealed class _003C_003Ec__DisplayClass7_0
		{
			public CustomRuleType ruleType;

			internal bool _003CGetCustomRuleLevel_003Eb__0(CustomRuleData x)
			{
				return x.ruleType == ruleType;
			}

			internal bool _003CGetCustomRuleLevel_003Eb__1(CustomRuleData x)
			{
				return x.ruleType == ruleType;
			}
		}

		public int seed;

		public string configString;

		public int year;

		public int month;

		public List<CustomRuleData> customRuleData;

		public CustomModeData(CustomModeConfiguration configuration)
		{
			configString = configuration.configString;
			seed = configuration.seed;
			year = configuration.year;
			month = configuration.month;
			foreach (CustomRuleData currentLevel in configuration.currentLevels)
			{
				SetCustomRuleValue(currentLevel.ruleType, currentLevel.value);
			}
		}

		public void SetCustomRuleValue(CustomRuleType ruleType, int value)
		{
			_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass6_0();
			CS_0024_003C_003E8__locals4.ruleType = ruleType;
			if (customRuleData == null)
			{
				customRuleData = new List<CustomRuleData>();
			}
			if (Enumerable.Count(customRuleData, (CustomRuleData x) => x.ruleType == CS_0024_003C_003E8__locals4.ruleType) == 0)
			{
				customRuleData.Add(new CustomRuleData(CS_0024_003C_003E8__locals4.ruleType, value));
				return;
			}
			Enumerable.First(customRuleData, (CustomRuleData x) => x.ruleType == CS_0024_003C_003E8__locals4.ruleType).value = value;
		}

		public int GetCustomRuleLevel(CustomRuleType ruleType)
		{
			_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass7_0();
			CS_0024_003C_003E8__locals3.ruleType = ruleType;
			if (Enumerable.Count(customRuleData, (CustomRuleData x) => x.ruleType == CS_0024_003C_003E8__locals3.ruleType) == 0)
			{
				return 0;
			}
			return Enumerable.First(customRuleData, (CustomRuleData x) => x.ruleType == CS_0024_003C_003E8__locals3.ruleType).value;
		}

		public List<int> GetRuleIntegers()
		{
			return new List<int>
			{
				100000000 * GetCustomRuleLevel(CustomRuleType.VillageProbability) + 10000000 * GetCustomRuleLevel(CustomRuleType.ForestProbability) + 1000000 * GetCustomRuleLevel(CustomRuleType.AgricultureProbability) + 100000 * GetCustomRuleLevel(CustomRuleType.WaterProbability) + 10000 * GetCustomRuleLevel(CustomRuleType.TrainTrackProbability) + 1000 * GetCustomRuleLevel(CustomRuleType.TileStackHeight) + 100 * GetCustomRuleLevel(CustomRuleType.TileLimit) + 10 * GetCustomRuleLevel(CustomRuleType.Density) + GetCustomRuleLevel(CustomRuleType.QuestProbability),
				100000000 * GetCustomRuleLevel(CustomRuleType.QuestDifficulty) + 10000000 * GetCustomRuleLevel(CustomRuleType.FlagQuestProbability) + 1000000 * GetCustomRuleLevel(CustomRuleType.WorldBorderRadius)
			};
		}
	}
}
