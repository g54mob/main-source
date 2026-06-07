using System;
using System.Linq;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct InventoryChangeRecord
	{
		public ItemChangeRecord[] changes;

		public bool HasChanges
		{
			get
			{
				if (changes != null)
				{
					return changes.Length != 0;
				}
				return false;
			}
		}

		public long TotalQuantityBefore => changes.Sum((ItemChangeRecord x) => x.TotalQuantityBefore);

		public long TotalQuantityAfter => changes.Sum((ItemChangeRecord x) => x.TotalQuantityAfter);

		public long TotalQuantityChange => changes.Sum((ItemChangeRecord x) => x.TotalQuantityChange);
	}
}
