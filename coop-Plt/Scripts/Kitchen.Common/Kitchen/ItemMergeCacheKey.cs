using KitchenData;

namespace Kitchen
{
	public struct ItemMergeCacheKey
	{
		public int Item1Id;

		public int Item2Id;

		public ItemList Item1Components;

		public ItemList Item2Components;

		public MergeCondition C1;

		public MergeCondition C2;

		public ItemMergeCacheKey(int item1_id, int item2_id, ItemList item1_components, ItemList item2_components, MergeCondition c1, MergeCondition c2)
		{
			Item1Id = item1_id;
			Item2Id = item2_id;
			Item1Components = item1_components;
			Item2Components = item2_components;
			C1 = c1;
			C2 = c2;
		}

		public override bool Equals(object obj)
		{
			if (obj is ItemMergeCacheKey other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(ItemMergeCacheKey other)
		{
			if (Item1Id == other.Item1Id && Item2Id == other.Item2Id && Item1Components.Equals(other.Item1Components) && Item2Components.Equals(other.Item2Components) && C1 == other.C1)
			{
				return C2 == other.C2;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (int)(((uint)(((((((Item1Id * 397) ^ Item2Id) * 397) ^ Item1Components.GetHashCode()) * 397) ^ Item2Components.GetHashCode()) * 397) ^ (uint)C1) * 397) ^ (int)C2;
		}
	}
}
