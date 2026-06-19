using System;

namespace UniversalInventorySystem
{
	[Serializable]
	public class CraftItemData
	{
		public Item[] items;

		public int[] amounts;

		public static readonly CraftItemData nullData = new CraftItemData(null, null);

		public CraftItemData(Item[] _items, int[] _amounts)
		{
			items = _items;
			amounts = _amounts;
		}

		public static bool operator true(CraftItemData c)
		{
			if (c.items == null)
			{
				return c.amounts != null;
			}
			return true;
		}

		public static bool operator false(CraftItemData c)
		{
			if (c.items != null)
			{
				return c.amounts == null;
			}
			return true;
		}
	}
}
