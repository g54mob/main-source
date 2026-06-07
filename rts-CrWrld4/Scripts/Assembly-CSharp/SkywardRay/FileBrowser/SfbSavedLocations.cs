using System.Collections.Generic;

namespace SkywardRay.FileBrowser
{
	public class SfbSavedLocations
	{
		private Dictionary<string, SfbSavedLocationEntry> recentList;

		private Dictionary<string, SfbSavedLocationEntry> favoriteList;

		public uint maxRecentEntries;

		public void AddRecentEntry(SfbFileSystemEntry fileSystemEntry)
		{
		}

		public void AddRecentEntry(SfbSavedLocationEntry savedLocationEntry)
		{
		}

		public void RemoveRecentEntry(string path)
		{
		}

		public void RemoveOldestRecent()
		{
		}

		public void AddFavoriteEntry(SfbFileSystemEntry fileSystemEntry)
		{
		}

		public void AddFavoriteEntry(SfbSavedLocationEntry savedLocationEntry)
		{
		}

		public void RemoveFavoriteEntry(string path)
		{
		}

		public void AddEntry(SfbSavedLocationEntry savedLocationEntry)
		{
		}

		public void RemoveEntry(SfbSavedLocationEntry savedLocationEntry)
		{
		}

		public void RemoveEntry(string path)
		{
		}

		public IEnumerable<SfbSavedLocationEntry> GetRecentEntries()
		{
			return null;
		}

		public IEnumerable<SfbSavedLocationEntry> GetRecentAndFavoriteEntries()
		{
			return null;
		}

		public string FormatForSave()
		{
			return null;
		}

		public void ParseSavedData(string data)
		{
		}
	}
}
