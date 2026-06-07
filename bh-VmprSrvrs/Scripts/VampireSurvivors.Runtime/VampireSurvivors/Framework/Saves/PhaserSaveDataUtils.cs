using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.Framework.Saves
{
	public class PhaserSaveDataUtils
	{
		private const string ElectronDataFolderName = "Vampire_Survivors";

		private const string SaveDataFolderName = "Vampire_Survivors_Data";

		private const string SavesFolderName = "saves";

		private const string BackupsFolderName = "backups";

		private const string SaveFileName = "SaveData.sav";

		private const string SaveBackupFileName = "SaveDataBackup.sav";

		private const string LastRunBackupFileName = "LastRunBackup.sav";

		private const string LastRunBackupBakFileName = "LastRunBackup.bak.sav";

		private const string DeletedSaveFileName = "deleted_SaveData";

		private const bool IPCRENDERER = true;

		private static PlayerOptions _playerOptions;

		[Inject]
		private void Construct(PlayerOptions playerOptions)
		{
		}

		private static bool UsesLocalSaves()
		{
			return false;
		}

		private static bool CheckExists(string[] segments)
		{
			return false;
		}

		private static string BuildPath(string[] segments)
		{
			return null;
		}

		private static string InitPath(string[] segments)
		{
			return null;
		}

		private static string GetSaveDataPath()
		{
			return null;
		}

		private static string GetSaveDataPathWithSave()
		{
			return null;
		}

		private static string InitSaveDataPath()
		{
			return null;
		}

		private static bool SaveDataHasSave()
		{
			return false;
		}

		private static bool SaveDataPathExists()
		{
			return false;
		}

		private static string GetElectronDataPath()
		{
			return null;
		}

		private static string GetElectronDataSavesPath()
		{
			return null;
		}

		private static bool ElectronDataHasSave()
		{
			return false;
		}

		private static string GetTempDataPath(string tempFolderName)
		{
			return null;
		}

		private static string GetTempDataPathWithSavesFolder(string tempFolderName)
		{
			return null;
		}

		private static string GetBackupsPath()
		{
			return null;
		}

		private static bool LastRunBackupExists()
		{
			return false;
		}

		private static string GetLastRunBackupPath()
		{
			return null;
		}

		private static string GetLastRunBackupBakPath()
		{
			return null;
		}

		private static string GetBaseDataPath()
		{
			return null;
		}

		private static string[] GetTempFolders()
		{
			return null;
		}

		public static object[] GetLocalBackupsList()
		{
			return null;
		}

		public static void RestoreLocalBackup(string filename)
		{
		}

		public static bool HasBackup()
		{
			return false;
		}

		public static void RestoreLastRunBackup(bool bypassReload = false)
		{
		}

		private static bool HasNewSaveFiles()
		{
			return false;
		}

		public static PlayerOptionsData LoadSaveFiles()
		{
			return null;
		}

		private static bool MakeNewSaveFiles()
		{
			return false;
		}

		private static string LoadNewSaves()
		{
			return null;
		}
	}
}
