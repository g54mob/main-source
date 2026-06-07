namespace com.ootii.Collections
{
	public sealed class ObjectPool<T> where T : new()
	{
		private int mGrowSize;

		private T[] mPool;

		private int mNextIndex;

		public int Length => 0;

		public int Available => 0;

		public int Allocated => 0;

		public ObjectPool(int rSize)
		{
		}

		public ObjectPool(int rSize, int rGrowSize)
		{
		}

		public T Allocate()
		{
			return default(T);
		}

		public void Release(T rInstance)
		{
		}

		public void Reset()
		{
		}

		public void Resize(int rSize, bool rCopyExisting)
		{
		}
	}
}
