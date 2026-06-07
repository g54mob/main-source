using System.Collections.Generic;

namespace DV
{
	public static class ArrayPoolExtensions
	{
		public static PooledArray<T> ToArrayPooled<T>(this ICollection<T> source)
		{
			PooledArray<T> pooledArray = ArrayPool<T>.New(source.Count);
			source.CopyTo(pooledArray, 0);
			return pooledArray;
		}
	}
}
