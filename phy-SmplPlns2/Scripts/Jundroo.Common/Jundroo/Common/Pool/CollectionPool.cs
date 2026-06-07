using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Jundroo.Common.Pool
{
	public class CollectionPool<TCollection, TItem> where TCollection : class, ICollection<TItem>, new()
	{
		private static readonly ObjectPool<TCollection> _sharedPool = new ObjectPool<TCollection>(() => new TCollection(), null, delegate(TCollection c)
		{
			c.Clear();
		});

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TCollection Get()
		{
			return _sharedPool.Get();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PooledObject<TCollection> Get(out TCollection value)
		{
			return _sharedPool.Get(out value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Release(TCollection value)
		{
			_sharedPool.Release(value);
		}
	}
}
