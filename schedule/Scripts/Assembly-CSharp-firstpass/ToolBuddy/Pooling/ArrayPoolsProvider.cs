using System;
using System.Collections.Generic;
using ToolBuddy.Pooling.Pools;

namespace ToolBuddy.Pooling
{
	public class ArrayPoolsProvider
	{
		private static readonly Dictionary<Type, object> arrayPools;

		private static readonly object lockObject;

		public static ArrayPool<T> GetPool<T>()
		{
			return null;
		}
	}
}
