using VampireSurvivors.Data;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;

public static class SaveBackupService
{
	private static PlayerOptionsData _backupSaveData;

	public static void Backup(PlayerOptionsData pod)
	{
		_backupSaveData = pod;
	}

	public static PlayerOptionsData GetBackup()
	{
		return _backupSaveData;
	}

	public static void ClearBackup()
	{
		_backupSaveData = null;
	}

	public static bool HasBackup()
	{
		bool flag = (nint)_backupSaveData < 0;
		bool flag2 = _backupSaveData == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}
}
