using BrewGame.SaveSystem.Data;

namespace BrewGame.SaveSystem.Serialization
{
	public static class SaveMigration
	{
		private static bool _showDebugLogs;

		public static SaveGameData Migrate(SaveGameData data, int targetVersion)
		{
			return null;
		}

		private static bool ApplyMigration(SaveGameData data, int fromVersion, int toVersion)
		{
			return false;
		}

		private static bool MigrateV0ToV1(SaveGameData data)
		{
			return false;
		}

		private static bool MigrateV1ToV2(SaveGameData data)
		{
			return false;
		}

		public static bool NeedsMigration(SaveGameData data, int targetVersion)
		{
			return false;
		}

		public static string GetMigrationDescription(int fromVersion, int toVersion)
		{
			return null;
		}

		public static void SetDebugLogging(bool enabled)
		{
		}
	}
}
