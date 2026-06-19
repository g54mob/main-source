using System;
using System.Collections.Generic;
using Unity.Entities;

namespace Pug.ECS.Serialization.DOTS100
{
	public static class StableTypeHash
	{
		private static bool _isInitialized;

		private static Dictionary<Type, ulong> _cache = new Dictionary<Type, ulong>();

		private static Dictionary<ulong, Type> _reverseLookup = new Dictionary<ulong, Type>();

		private static void InitializeCacheIfNeeded()
		{
			if (_isInitialized)
			{
				return;
			}
			_isInitialized = true;
			foreach (TypeManager.TypeInfo allType in TypeManager.AllTypes)
			{
				if (!(allType.Type == null))
				{
					bool hasCustomMemoryOrder;
					ulong key = ((allType.Type.FullName == "Unity.Entities.Entity") ? 7998976012602596137uL : TypeHash.CalculateMemoryOrdering(allType.Type, out hasCustomMemoryOrder, _cache));
					_reverseLookup[key] = allType.Type;
				}
			}
		}

		public static ulong GetStableTypeHash<T>()
		{
			return GetStableTypeHash(typeof(T));
		}

		public static ulong GetStableTypeHash(Type type)
		{
			InitializeCacheIfNeeded();
			return _cache[type];
		}

		public static Type GetTypeFromTypeHash(ulong typeHash)
		{
			InitializeCacheIfNeeded();
			return _reverseLookup[typeHash];
		}
	}
}
