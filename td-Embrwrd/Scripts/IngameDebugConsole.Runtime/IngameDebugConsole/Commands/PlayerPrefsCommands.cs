using UnityEngine.Scripting;

namespace IngameDebugConsole.Commands
{
	public class PlayerPrefsCommands
	{
		[Preserve]
		[ConsoleMethod("prefs.int", "Returns the value of an Integer PlayerPrefs field", new string[] { })]
		public static string PlayerPrefsGetInt(string key)
		{
			return null;
		}

		[ConsoleMethod("prefs.int", "Sets the value of an Integer PlayerPrefs field", new string[] { })]
		[Preserve]
		public static void PlayerPrefsSetInt(string key, int value)
		{
		}

		[Preserve]
		[ConsoleMethod("prefs.float", "Returns the value of a Float PlayerPrefs field", new string[] { })]
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

		[Preserve]
		[ConsoleMethod("prefs.string", "Sets the value of a String PlayerPrefs field", new string[] { })]
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
