namespace TH20
{
	public static class SaveUtils
	{
		public const string BackupExtensionWithDot = ".bak";

		private const string TempFileExtensionWithDot = ".temp";

		public static string GetBackupSavePath(string path, int backupNumber)
		{
			if (backupNumber == 0)
			{
				return path;
			}
			return path + "." + (backupNumber + 1) + ".bak";
		}

		public static string GetTempSavePath(string path)
		{
			return path + ".temp";
		}
	}
}
