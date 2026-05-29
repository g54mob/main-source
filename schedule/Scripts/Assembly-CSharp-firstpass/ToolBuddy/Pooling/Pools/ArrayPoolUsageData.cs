namespace ToolBuddy.Pooling.Pools
{
	public readonly struct ArrayPoolUsageData
	{
		public long ElementsCount { get; }

		public int ArraysCount { get; }

		public long ElementsCapacity { get; }

		public ArrayPoolUsageData(long elementsCount, int arraysCount, long elementsCapacity)
		{
			ElementsCount = 0L;
			ArraysCount = 0;
			ElementsCapacity = 0L;
		}

		public bool Equals(ArrayPoolUsageData other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(ArrayPoolUsageData a, ArrayPoolUsageData b)
		{
			return false;
		}

		public static bool operator !=(ArrayPoolUsageData a, ArrayPoolUsageData b)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
