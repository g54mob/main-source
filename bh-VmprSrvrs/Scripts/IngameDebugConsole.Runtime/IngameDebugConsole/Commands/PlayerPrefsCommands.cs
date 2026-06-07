using UnityEngine.Scripting;

namespace IngameDebugConsole.Commands
{
	public class PlayerPrefsCommands
	{
		[ConsoleMethod("prefs.int", "Returns the value of an Integer PlayerPrefs field", new string[] { })]
		[Preserve]
		public static string PlayerPrefsGetInt(string key)
		{
			return null;
		}

		[ConsoleMethod("prefs.int", "Sets the value of an Integer PlayerPrefs field", new string[] { })]
		[Preserve]
		public static void PlayerPrefsSetInt(string key, int value)
		{
		}

		[ConsoleMethod("prefs.float", "Returns the value of a Float PlayerPrefs field", new string[] { })]
		[Preserve]
		public static string PlayerPrefsGetFloat(string key)
		{
			return null;
		}

		[ConsoleMethod("prefs.float", "Sets the value of a Float PlayerPrefs field", new string[] { })]
		[Preserve]
		public static void PlayerPrefsSetFloat(string key, float value)
		{
		}

		[ConsoleMethod("prefs.string", "Returns the value of a String PlayerPrefs field", new string[] { })]
		[Preserve]
		public static string PlayerPrefsGetString(string key)
		{
			return null;
		}

		[ConsoleMethod("prefs.string", "Sets the value of a String PlayerPrefs field", new string[] { })]
		[Preserve]
		public static void PlayerPrefsSetString(string key, string value)
		{
		}

		[ConsoleMethod("prefs.delete", "Deletes a PlayerPrefs field", new string[] { })]
		[Preserve]
		public static void PlayerPrefsDelete(string key)
		{
		}

		[ConsoleMethod("prefs.clear", "Deletes all PlayerPrefs fields", new string[] { })]
		[Preserve]
		public static void PlayerPrefsClear()
		{
		}
	}
}
