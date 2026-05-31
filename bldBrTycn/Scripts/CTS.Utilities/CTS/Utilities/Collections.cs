using System;
using System.Collections.Generic;
using CTS.Core.Utilities;

namespace CTS.Utilities
{
	public static class Collections<T>
	{
		private static readonly HashSet<T> _tempFilter = new HashSet<T>();

		private static readonly HashSet<T> _returnList = new HashSet<T>();

		private static void Prepare<TCollection>(TCollection collection) where TCollection : IEnumerable<T>
		{
			_tempFilter.Clear();
			_returnList.Clear();
			foreach (T item in collection)
			{
				_tempFilter.Add(item);
			}
		}

		public static ReadOnlyHashSet<T> Filter<TCollection>(TCollection collection, Func<T, bool> filter) where TCollection : IEnumerable<T>
		{
			Prepare(collection);
			foreach (T item in _tempFilter)
			{
				if (filter(item))
				{
					_returnList.Add(item);
				}
			}
			return _returnList;
		}

		public static void Filter<TCollection>(TCollection collection, HashSet<T> returnList, Func<T, bool> filter) where TCollection : IEnumerable<T>
		{
			Prepare(collection);
			returnList.Clear();
			foreach (T item in _tempFilter)
			{
				if (filter(item))
				{
					returnList.Add(item);
				}
			}
		}

		public static ReadOnlyHashSet<T> Filter<TCollection, TArg1>(TCollection collection, Func<T, TArg1, bool> filter, TArg1 arg1) where TCollection : IEnumerable<T>
		{
			Prepare(collection);
			foreach (T item in _tempFilter)
			{
				if (filter(item, arg1))
				{
					_returnList.Add(item);
				}
			}
			return _returnList;
		}

		public static void Filter<TCollection, TArg1>(TCollection collection, HashSet<T> returnList, Func<T, TArg1, bool> filter, TArg1 arg1) where TCollection : IEnumerable<T>
		{
			Prepare(collection);
			returnList.Clear();
			foreach (T item in _tempFilter)
			{
				if (filter(item, arg1))
				{
					returnList.Add(item);
				}
			}
		}

		public static ReadOnlyHashSet<T> Filter<TCollection, TArg1, TArg2>(TCollection collection, Func<T, TArg1, TArg2, bool> filter, TArg1 arg1, TArg2 arg2) where TCollection : IEnumerable<T>
		{
			Prepare(collection);
			foreach (T item in _tempFilter)
			{
				if (filter(item, arg1, arg2))
				{
					_returnList.Add(item);
				}
			}
			return _returnList;
		}

		public static void Filter<TCollection, TArg1, TArg2>(TCollection collection, HashSet<T> returnList, Func<T, TArg1, TArg2, bool> filter, TArg1 arg1, TArg2 arg2) where TCollection : IEnumerable<T>
		{
			Prepare(collection);
			returnList.Clear();
			foreach (T item in _tempFilter)
			{
				if (filter(item, arg1, arg2))
				{
					returnList.Add(item);
				}
			}
		}

		public static ReadOnlyHashSet<T> Filter<TCollection, TArg1, TArg2, TArg3>(TCollection collection, Func<T, TArg1, TArg2, TArg3, bool> filter, TArg1 arg1, TArg2 arg2, TArg3 arg3) where TCollection : IEnumerable<T>
		{
			Prepare(collection);
			foreach (T item in _tempFilter)
			{
				if (filter(item, arg1, arg2, arg3))
				{
					_returnList.Add(item);
				}
			}
			return _returnList;
		}

		public static void Filter<TCollection, TArg1, TArg2, TArg3>(TCollection collection, HashSet<T> returnList, Func<T, TArg1, TArg2, TArg3, bool> filter, TArg1 arg1, TArg2 arg2, TArg3 arg3) where TCollection : IEnumerable<T>
		{
			Prepare(collection);
			returnList.Clear();
			foreach (T item in _tempFilter)
			{
				if (filter(item, arg1, arg2, arg3))
				{
					returnList.Add(item);
				}
			}
		}
	}
}
