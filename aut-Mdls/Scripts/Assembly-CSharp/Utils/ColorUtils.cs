using System.Collections.Generic;

namespace Utils
{
	public static class ColorUtils
	{
		private static Dictionary<string, string> _hexColorToNameDictionary = new Dictionary<string, string>
		{
			{ "CFCFCF", "Grey" },
			{ "58575E", "Dark Grey" },
			{ "48ADD7", "Turquoise" },
			{ "86EBB4", "Green" },
			{ "FF759D", "Pink" },
			{ "DC89F1", "Magenta" },
			{ "FFB875", "Orange" },
			{ "FFDE53", "Yellow" }
		};

		public static string GetColorNameFromCode(string hexCode)
		{
			if (_hexColorToNameDictionary.TryGetValue(hexCode, out var value))
			{
				return value;
			}
			return "#" + hexCode;
		}

		public static Dictionary<string, string> GetAllColors()
		{
			return _hexColorToNameDictionary;
		}
	}
}
