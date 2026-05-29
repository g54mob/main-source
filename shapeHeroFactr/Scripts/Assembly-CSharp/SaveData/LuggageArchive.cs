using System;

namespace SaveData
{
	[Serializable]
	public class LuggageArchive : ArchiveData
	{
		public bool isManufacture;

		public int maxLevel;

		public LuggageArchive(bool everGet = true, bool isRead = false, bool isPermanent = true, bool isManufacture = false, int maxLevel = 0)
			: base(everGet: false, isRead: false, isPermanent: false)
		{
		}
	}
}
