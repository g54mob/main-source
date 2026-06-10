using System;
using System.Collections.Generic;

namespace ModIO.Implementation
{
	[Serializable]
	internal class ModCollectionRegistry
	{
		public Dictionary<long, UserModCollectionData> existingUsers;

		public Dictionary<ModId, ModCollectionEntry> mods;
	}
}
