using System.Collections.Generic;

namespace FSG.MeshAnimator
{
	public class PooledDictionary<T, T2> : Dictionary<T, T2>
	{
		private static Stack<PooledDictionary<T, T2>> stack;

		private static uint checkedOut;

		private static uint returned;

		public bool recycleable { get; set; }

		public static void Init(int initialPoolSize = 10)
		{
		}

		public static PooledDictionary<T, T2> Get(int capacity, IEqualityComparer<T> comparer = null)
		{
			return null;
		}

		public static PooledDictionary<T, T2> Get()
		{
			return null;
		}

		public static PooledDictionary<T, T2> Get(IEqualityComparer<T> comparer)
		{
			return null;
		}

		public PooledDictionary()
		{
		}

		public PooledDictionary(int capacity)
		{
		}

		public PooledDictionary(int capacity, IEqualityComparer<T> comparer)
		{
		}

		public void ReturnToPool(bool force = false)
		{
		}
	}
}
