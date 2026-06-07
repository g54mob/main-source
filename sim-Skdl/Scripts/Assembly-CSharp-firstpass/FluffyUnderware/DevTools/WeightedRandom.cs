using System.Collections.Generic;

namespace FluffyUnderware.DevTools
{
	public class WeightedRandom<T>
	{
		private readonly List<T> mData;

		private int mCurrentPosition;

		private T mCurrentItem;

		public int Seed { get; set; }

		public bool RandomizeSeed { get; set; }

		public int Size => 0;

		public WeightedRandom(int initCapacity = 0)
		{
		}

		public WeightedRandom(int initCapacity, int seed)
		{
		}

		public void Add(T item, int amount)
		{
		}

		public T Next()
		{
			return default(T);
		}

		public void Reset()
		{
		}

		public void Clear()
		{
		}
	}
}
