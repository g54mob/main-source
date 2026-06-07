using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public static class SaveGameBackupCleanup
{
	private const string SAVEGAME_BACKUP_PREFIX = "savegame_backup_";

	private const string REGEX_PATTERN = "^savegame_backup_\\d{4}-\\d{2}-\\d{2}_\\d{2}-\\d{2}-\\d{2}$";

	public static List<(string path, float sizeKB)> GetSavegameBackupsInfos(string dirPath)
	{
		if (string.IsNullOrWhiteSpace(dirPath) || !Directory.Exists(dirPath))
		{
			return new List<(string, float)>();
		}
		Regex re = new Regex("^savegame_backup_\\d{4}-\\d{2}-\\d{2}_\\d{2}-\\d{2}-\\d{2}$", RegexOptions.IgnoreCase);
		return (from path in Directory.EnumerateFiles(dirPath, "savegame_backup_*", SearchOption.TopDirectoryOnly)
			where re.IsMatch(Path.GetFileName(path))
			select path).Select(delegate(string path)
		{
			FileInfo fileInfo = new FileInfo(path);
			return (FullName: fileInfo.FullName, (float)fileInfo.Length / 1024f);
		}).ToList();
	}

	public static List<string> GetPathsForDeletion(List<(string path, float sizeKB)> infos, float maxSizeKilobytes)
	{
		if (maxSizeKilobytes <= 0f)
		{
			throw new ArgumentOutOfRangeException("maxSizeKilobytes", "max size must be a positive number");
		}
		int fileCounter = 0;
		float sizeSum = 0f;
		return (from info in infos.OrderByDescending(((string path, float sizeKB) info) => Path.GetFileName(info.path)).SkipWhile(CanFit)
			select info.path).ToList();
		bool CanFit((string path, float sizeKB) info)
		{
			sizeSum += info.sizeKB;
			fileCounter++;
			if (!(sizeSum <= maxSizeKilobytes))
			{
				return fileCounter <= 3;
			}
			return true;
		}
	}
}
