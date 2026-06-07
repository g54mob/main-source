using System.Collections.Generic;

namespace InventorySystem
{
	public static class ItemRegistry
	{
		private static readonly Dictionary<string, Item> itemsById;

		private static bool attemptedWarmup;

		public static void ClearCache()
		{
		}

		public static void Warmup()
		{
		}

		public static void Register(Item item)
		{
		}

		public static Item GetItem(string itemId)
		{
			return null;
		}

		public static IEnumerable<Item> GetAllItems()
		{
			return null;
		}

		private static void EnsureCache()
		{
		}
	}
}
