using System;
using System.Collections.Generic;

namespace SQLite
{
	internal static class EnumCache
	{
		private static readonly Dictionary<Type, EnumCacheInfo> Cache;

		public static EnumCacheInfo GetInfo<T>()
		{
			return null;
		}

		public static EnumCacheInfo GetInfo(Type type)
		{
			return null;
		}
	}
}
