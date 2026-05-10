using ToolBuddy.Pooling.Pools;

namespace ToolBuddy.Pooling.Collections
{
	public struct SubArrayList<T>
	{
		private readonly ArrayPool<T> typePool;

		private SubArray<T> subArray;

		public T[] Array => null;

		public int Count { get; private set; }

		public SubArrayList(int initialCapacity, ArrayPool<T> typePool)
		{
			this.typePool = null;
			subArray = default(SubArray<T>);
			Count = 0;
		}

		public void Add(T element)
		{
		}

		public SubArray<T> ToSubArray()
		{
			return default(SubArray<T>);
		}

		public bool Equals(SubArrayList<T> other)
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

		public static bool operator ==(SubArrayList<T> a, SubArrayList<T> b)
		{
			return false;
		}

		public static bool operator !=(SubArrayList<T> a, SubArrayList<T> b)
		{
			return false;
		}
	}
}
