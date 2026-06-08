using System;
using System.Collections.Generic;

namespace NUnit.Framework.Internal.Builders
{
	internal class ProviderCache
	{
		private class CacheEntry
		{
			private Type providerType;

			public CacheEntry(Type providerType, object[] providerArgs)
			{
				this.providerType = providerType;
			}

			public override bool Equals(object obj)
			{
				if (!(obj is CacheEntry cacheEntry))
				{
					return false;
				}
				return providerType == cacheEntry.providerType;
			}

			public override int GetHashCode()
			{
				return providerType.GetHashCode();
			}
		}

		private static Dictionary<CacheEntry, object> instances = new Dictionary<CacheEntry, object>();

		public static object GetInstanceOf(Type providerType)
		{
			return GetInstanceOf(providerType, null);
		}

		public static object GetInstanceOf(Type providerType, object[] providerArgs)
		{
			CacheEntry key = new CacheEntry(providerType, providerArgs);
			object obj = (instances.ContainsKey(key) ? instances[key] : null);
			if (obj == null)
			{
				obj = (instances[key] = Reflect.Construct(providerType, providerArgs));
			}
			return obj;
		}

		public static void Clear()
		{
			foreach (CacheEntry key in instances.Keys)
			{
				if (instances[key] is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			instances.Clear();
		}
	}
}
