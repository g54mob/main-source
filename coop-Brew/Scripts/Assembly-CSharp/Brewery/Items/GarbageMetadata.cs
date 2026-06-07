using System;

namespace Brewery.Items
{
	[Serializable]
	public struct GarbageMetadata
	{
		public int BottleCount;

		public bool IsEmpty => false;

		public bool IsFull(int maxCapacity)
		{
			return false;
		}

		public float GetFillRatio(int maxCapacity)
		{
			return 0f;
		}

		public static GarbageMetadata Create(int bottleCount = 0)
		{
			return default(GarbageMetadata);
		}
	}
}
