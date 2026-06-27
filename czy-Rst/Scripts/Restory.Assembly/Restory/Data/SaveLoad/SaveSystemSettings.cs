using UnityEngine;

namespace Restory.Data.SaveLoad
{
	public class SaveSystemSettings : ScriptableObject
	{
		[Header("General settings")]
		[SerializeField]
		private string subDirectoryName = "SaveSystem";

		[SerializeField]
		private string backupDirectoryName = "BackupSaveData";

		[SerializeField]
		[Min(1f)]
		private int maxSaveRecordsSize = 5;

		[SerializeField]
		private double requiredSaveFilesSpaceMb;

		[Header("File name settings")]
		[SerializeField]
		private string corruptedPrefix = "corrupted";

		[SerializeField]
		private string DatetimeSeparator = "-";

		[SerializeField]
		private string iterationSeparator = "-No-";

		[SerializeField]
		private string slotSeparator = ".slot";

		[SerializeField]
		private string demoPostfix = "demo";

		[SerializeField]
		private string playtestPostfix = "playtest";

		[SerializeField]
		private string releasePostfix = "release";

		[SerializeField]
		private string tempFileName = "CandidateSaveFileRecord";

		public string WorkDirectory => subDirectoryName;

		public string BackupDirectory => backupDirectoryName;

		public int MaxSaveRecordsSize => maxSaveRecordsSize;

		public double RequiredSaveFilesSpaceMb => requiredSaveFilesSpaceMb;

		public string CorruptedPrefix => corruptedPrefix;

		public string DateTimeSeparator => DatetimeSeparator;

		public string IterationSeparator => iterationSeparator;

		public string SlotSeparator => slotSeparator;

		public string DemoPostfix => demoPostfix;

		public string PlaytestPostfix => playtestPostfix;

		public string ReleasePostfix => releasePostfix;

		public string TempFileName => tempFileName;
	}
}
