using System;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms.Saves;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Framework.Saves
{
	public static class SaveSystem
	{
		private static IPlatformSaveUtils SaveUtil => null;

		static SaveSystem()
		{
		}

		public static void Save(PlayerOptionsData data, bool commitImmediately = true, bool createBackup = false, CommitOptions options = CommitOptions.Default)
		{
		}

		public static void LoadAsync(PlayerOptions playerOptions, Action<StorageResult> onComplete)
		{
		}

		private static void TryRestoreDataAsync(Action<StorageResult, PlayerOptionsData> onComplete)
		{
		}

		public static void DeleteSave()
		{
		}

		public static bool BackupExists()
		{
			return false;
		}

		public static void TryRestoreBackup(PlayerOptions playerOptions, Action<bool> onComplete)
		{
		}

		public static void HandleConflictResolution(byte[] dataA, byte[] dataB, Action<byte[]> onComplete)
		{
		}
	}
}
