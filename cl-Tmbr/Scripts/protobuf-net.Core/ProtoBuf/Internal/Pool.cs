using System;
using System.Collections.Generic;

namespace ProtoBuf.Internal
{
	internal static class Pool<T> where T : class
	{
		[ThreadStatic]
		private static T ts_local;

		private const int POOL_SIZE = 20;

		private static readonly Queue<T> s_pool = new Queue<T>(20);

		internal static T TryGet()
		{
			T val = ts_local;
			if (val != null)
			{
				ts_local = null;
				return val;
			}
			return GetShared();
		}

		internal static void Put(T obj)
		{
			if (obj != null)
			{
				if (ts_local == null)
				{
					ts_local = obj;
				}
				else
				{
					PutShared(obj);
				}
			}
		}

		private static T GetShared()
		{
			Queue<T> queue = s_pool;
			lock (queue)
			{
				return (queue.Count == 0) ? null : queue.Dequeue();
			}
		}

		private static void PutShared(T obj)
		{
			Queue<T> queue = s_pool;
			lock (queue)
			{
				if (queue.Count < 20)
				{
					queue.Enqueue(obj);
				}
			}
		}
	}
}
