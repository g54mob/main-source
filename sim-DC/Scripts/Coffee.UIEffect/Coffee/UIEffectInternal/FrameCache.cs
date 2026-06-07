using System;
using System.Collections.Generic;

namespace Coffee.UIEffectInternal
{
	internal static class FrameCache
	{
		private interface IFrameCache
		{
			void Clear();
		}

		private class FrameCacheContainer<T> : IFrameCache
		{
			private readonly Dictionary<(int, int), T> _caches;

			public void Clear()
			{
			}

			public bool TryGet((int, int) key, out T result)
			{
				result = default(T);
				return false;
			}

			public void Set((int, int) key, T result)
			{
			}
		}

		private static readonly Dictionary<Type, IFrameCache> s_Caches;

		static FrameCache()
		{
		}

		public static bool TryGet<T>(object key1, string key2, out T result)
		{
			result = default(T);
			return false;
		}

		public static bool TryGet<T>(object key1, string key2, int key3, out T result)
		{
			result = default(T);
			return false;
		}

		public static void Set<T>(object key1, string key2, T result)
		{
		}

		public static void Set<T>(object key1, string key2, int key3, T result)
		{
		}

		private static void ClearAllCache()
		{
		}

		private static FrameCacheContainer<T> GetFrameCache<T>()
		{
			return null;
		}
	}
}
