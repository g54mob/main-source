using System;
using System.Collections.Generic;
using CTS.Core.Utilities;

namespace CTS
{
	public static class StaticStructSet<T> where T : struct
	{
		private static readonly HashSet<T> _objects = new HashSet<T>();

		public static ReadOnlyHashSet<T> List => _objects;

		public static void Add(T obj)
		{
			_objects.Add(obj);
		}

		public static void Remove(T obj)
		{
			_objects.Remove(obj);
		}

		public static bool Contains(T obj)
		{
			return _objects.Contains(obj);
		}

		public static bool Contains(Func<T, bool> filter)
		{
			foreach (T @object in _objects)
			{
				if (filter(@object))
				{
					return true;
				}
			}
			return false;
		}

		public static bool Contains<TArg>(Func<T, TArg, bool> filter, TArg arg)
		{
			foreach (T @object in _objects)
			{
				if (filter(@object, arg))
				{
					return true;
				}
			}
			return false;
		}

		public static bool Contains<TArg1, TArg2>(Func<T, TArg1, TArg2, bool> filter, TArg1 arg1, TArg2 arg2)
		{
			foreach (T @object in _objects)
			{
				if (filter(@object, arg1, arg2))
				{
					return true;
				}
			}
			return false;
		}

		public static bool Contains<TArg1, TArg2, TArg3>(Func<T, TArg1, TArg2, TArg3, bool> filter, TArg1 arg1, TArg2 arg2, TArg3 arg3)
		{
			foreach (T @object in _objects)
			{
				if (filter(@object, arg1, arg2, arg3))
				{
					return true;
				}
			}
			return false;
		}
	}
}
