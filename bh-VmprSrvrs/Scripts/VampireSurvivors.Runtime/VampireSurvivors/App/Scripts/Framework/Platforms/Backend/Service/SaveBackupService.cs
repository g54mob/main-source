using VampireSurvivors.Data;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service
{
	public static class SaveBackupService
	{
		private static PlayerOptionsData _backupSaveData;

		public static void Backup(PlayerOptionsData pod)
		{
		}

		public static PlayerOptionsData GetBackup()
		{
			return null;
		}

		public static void ClearBackup()
		{
		}

		public static bool HasBackup()
		{
			return false;
		}
	}
}
