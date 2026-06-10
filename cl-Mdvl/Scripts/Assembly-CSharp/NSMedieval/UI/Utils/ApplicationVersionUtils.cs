using System.Text.RegularExpressions;

namespace NSMedieval.UI.Utils
{
	public static class ApplicationVersionUtils
	{
		public const string ValidSaveVersion = "0.8.0";

		public const string ValidScenarioVersion = "0.8.0";

		public const string ValidUnifiedScenarioVersion = "0.28.0";

		public const string ValidCharacterPresetVersion = "0.8.0";

		public const string ValidNewSaveVersion = "0.17.0";

		public const string TangentsFixedVersion = "0.26.55";

		public const string HeightmapFixedVersion = "0.26.60";

		public const string GameDifficultyVersion = "0.28.0";

		public static int CompareVersion(string version1, string version2)
		{
			return GetVersionValue(version1) - GetVersionValue(version2);
		}

		public static bool IsValidSaveVersion(string modifiedVersion)
		{
			if (!ValidateFormat(modifiedVersion))
			{
				return false;
			}
			return GetVersionValue(modifiedVersion) >= GetVersionValue("0.8.0");
		}

		public static bool IsNewSaveVersion(string modifiedVersion)
		{
			if (!ValidateFormat(modifiedVersion))
			{
				return false;
			}
			return GetVersionValue(modifiedVersion) >= GetVersionValue("0.17.0");
		}

		public static bool IsValidScenarioVersion(string modifiedVersion)
		{
			if (!ValidateFormat(modifiedVersion))
			{
				return false;
			}
			return GetVersionValue(modifiedVersion) >= GetVersionValue("0.8.0");
		}

		public static bool IsValidUnifiedScenarioVersion(string modifiedVersion)
		{
			if (!ValidateFormat(modifiedVersion))
			{
				return false;
			}
			return GetVersionValue(modifiedVersion) >= GetVersionValue("0.28.0");
		}

		public static bool IsValidCharacterPresetVersion(string modifiedVersion)
		{
			if (!ValidateFormat(modifiedVersion))
			{
				return false;
			}
			return GetVersionValue(modifiedVersion) >= GetVersionValue("0.8.0");
		}

		public static int GetVersionValue(string version)
		{
			string[] array = version.Split('.');
			int num = 0;
			int num2 = 1000000;
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				if (int.TryParse(array2[i], out var result))
				{
					num += result * num2;
				}
				num2 /= 100;
			}
			return num;
		}

		private static bool ValidateFormat(string modifiedVersion)
		{
			if (string.IsNullOrEmpty(modifiedVersion))
			{
				return false;
			}
			string[] array = modifiedVersion.Split('.');
			string[] array2 = "0.8.0".Split('.');
			return array.Length == array2.Length;
		}

		public static bool IsValidVersionFormat(string version)
		{
			string pattern = "^\\d+(\\.\\d+)*$";
			return Regex.IsMatch(version, pattern);
		}
	}
}
