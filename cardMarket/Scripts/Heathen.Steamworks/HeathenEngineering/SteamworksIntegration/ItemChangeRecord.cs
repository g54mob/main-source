using System;
using System.Linq;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct ItemChangeRecord
	{
		public ItemDefinitionObject item;

		public ItemInstanceChangeRecord[] changes;

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

		public long TotalQuantityBefore => changes.Sum((ItemInstanceChangeRecord x) => x.quantityBefore);

		public long TotalQuantityAfter => changes.Sum((ItemInstanceChangeRecord x) => x.quantityAfter);

		public long TotalQuantityChange => changes.Sum((ItemInstanceChangeRecord x) => x.QuantityChange);
	}
}
