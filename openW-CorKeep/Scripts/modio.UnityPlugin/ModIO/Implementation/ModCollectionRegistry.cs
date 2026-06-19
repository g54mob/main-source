using System;
using System.Collections.Generic;

namespace ModIO.Implementation
{
	[Serializable]
	internal class ModCollectionRegistry
	{
		public Dictionary<long, UserModCollectionData> existingUsers = new Dictionary<long, UserModCollectionData>();

		public Dictionary<ModId, ModCollectionEntry> mods = new Dictionary<ModId, ModCollectionEntry>();
	}
}
