using System;
using System.Collections.Generic;

namespace ScheduleOne.ItemFramework
{
	[Serializable]
	public class SlotFilter
	{
		public enum EType
		{
			None = 0,
			Whitelist = 1,
			Blacklist = 2
		}

		public EType Type;

		public List<string> ItemIDs;

		public List<EQuality> AllowedQualities;

		public bool DoesItemMatchFilter(ItemInstance instance)
		{
			return false;
		}

		public bool IsDefault()
		{
			return false;
		}

		public SlotFilter Clone()
		{
			return null;
		}
	}
}
