using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public static class QualitySettingUtils
	{
		private static bool? _areQualitiesOrderedLowToHigh;

		public static bool AreQualitiesOrderedLowToHigh()
		{
			if (_areQualitiesOrderedLowToHigh.HasValue)
			{
				return _areQualitiesOrderedLowToHigh.Value;
			}
			string[] names = QualitySettings.names;
			if (names != null && names.Length != 0)
			{
				string text = names[0];
				string text2 = names[^1];
				if (text.Contains("High") || text.Contains("Best") || text.Contains("Ultra") || text2.Contains("Low") || text2.Contains("Bad") || text2.Contains("Worst"))
				{
					_areQualitiesOrderedLowToHigh = false;
					return false;
				}
			}
			_areQualitiesOrderedLowToHigh = true;
			return true;
		}

		public static int MapToQualityLevel(int value, int min, int max)
		{
			int num = QualitySettings.names.Length - 1;
			if (num == 0)
			{
				return 0;
			}
			float num2 = (float)(value - min) / (float)(max - min);
			return Mathf.RoundToInt((float)num * num2);
		}

		public static int InvertQualityLevel(int qualityLevel)
		{
			return QualitySettings.names.Length - 1 - qualityLevel;
		}

		public static int MapQualityLevelToRange(int qualityLevel, int min, int max)
		{
			int num = QualitySettings.names.Length - 1;
			if (num == 0)
			{
				return min;
			}
			float num2 = qualityLevel;
			return Mathf.RoundToInt((float)min + (float)(max - min) * (num2 / (float)num));
		}
	}
}
