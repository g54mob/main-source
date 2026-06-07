using System.Collections.Generic;

namespace viperOSK
{
	public class OSK_Keymap
	{
		public Dictionary<string, OSK_KeyCode> chartoKeycode;

		public Dictionary<string, int> altAlphabeticalAssignment;

		private Dictionary<string, OSK_KeyCode> keyCodeDict;

		public void SupportGlyphs(OSK_LanguagePackage glyphProfile)
		{
		}

		public static string BaseCharacter(string accentedChar)
		{
			return null;
		}

		public static bool IsAccentedCharacter(char c)
		{
			return false;
		}

		public static Dictionary<string, OSK_KeyCode> GenKeyMapDict()
		{
			return null;
		}

		public static string GenKeyMapStr()
		{
			return null;
		}

		public string AutoCorrectLayout(string layout)
		{
			return null;
		}

		private string AutoCorrectRow(string row)
		{
			return null;
		}

		private void AutoCorrectRecursive(string input, List<string> result)
		{
		}

		private string GetCorrectedKey(string key)
		{
			return null;
		}

		private string CapitalizeCorrectly(string input, string correctForm)
		{
			return null;
		}

		public static string AddDiacritic(char baseChar, params char[] diacritics)
		{
			return null;
		}
	}
}
