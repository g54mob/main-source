using System;
using System.Collections.Generic;

namespace ModIO.Implementation
{
	[Serializable]
	internal class UserModCollectionData
	{
		public long userId;

		public HashSet<ModId> subscribedMods;

		public HashSet<ModId> disabledMods;

		public List<ModId> unsubscribeQueue;
	}
}
