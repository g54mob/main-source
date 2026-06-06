using BrewGame.SaveSystem.Core;
using BrewGame.SaveSystem.Data;

namespace BrewGame.SaveSystem.Serialization
{
	public static class SaveSerializer
	{
		public const int CURRENT_SAVE_VERSION = 2;

		private static bool _showDebugLogs;

		public static byte[] Serialize(SaveGameData data)
		{
			return null;
		}

		public static SaveGameData Deserialize(byte[] bytes, bool validateChecksum = true)
		{
			return null;
		}

		public static (SaveGameData, SaveIntegrityChecker.ValidationResult) DeserializeWithValidation(byte[] bytes)
		{
			return default((SaveGameData, SaveIntegrityChecker.ValidationResult));
		}

		public static SaveGameData CreateNewSave(string hostSteamId, string hostPlayerName)
		{
			return null;
		}

		public static void SetDebugLogging(bool enabled)
		{
		}
	}
}
