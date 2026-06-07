using System;

namespace SkywardRay.FileBrowser
{
	public class SfbSavedLocationEntry : SfbFileSystemEntry
	{
		public SfbSavedLocationType locationType;

		public DateTime savedDate;

		public SfbSavedLocationEntry(SfbSavedLocationType locationType, string path, bool hidden, SfbFileSystemEntryType type)
			: base(null, hidden: false, default(SfbFileSystemEntryType))
		{
		}

		private SfbSavedLocationEntry(SfbSavedLocationType locationType, DateTime savedDate, string path, bool hidden, SfbFileSystemEntryType type)
			: base(null, hidden: false, default(SfbFileSystemEntryType))
		{
		}

		public string FormatForSave()
		{
			return null;
		}

		public static SfbSavedLocationEntry FromFileSystemEntry(SfbSavedLocationType locationType, SfbFileSystemEntry fileSystemEntry)
		{
			return null;
		}

		public static SfbSavedLocationEntry FromSavedData(string data)
		{
			return null;
		}
	}
}
