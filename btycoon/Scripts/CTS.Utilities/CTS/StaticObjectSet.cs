using System;
using System.Collections.Generic;
using CTS.Core.Utilities;

namespace CTS
{
	public static class StaticObjectSet<T> where T : class
	{
		private static readonly HashSet<T> _objects = new HashSet<T>();

		private static readonly Dictionary<Type, HashSet<T>> _variants = new Dictionary<Type, HashSet<T>>();

		public static ReadOnlyHashSet<T> List => _objects;

		public static void Add(T obj)
		{
			if (!_objects.Contains(obj))
			{
				Type type = obj.GetType();
				_variants.EnsureKeyExists(type);
				_variants[type].Add(obj);
				_objects.Add(obj);
			}
		}

		public static void Remove(T obj)
		{
			if (_objects.Contains(obj))
			{
				Type type = obj.GetType();
				_variants[type].Remove(obj);
				_objects.Remove(obj);
			}
		}

		public static void Clear()
		{
			_objects.Clear();
			_variants.Clear();
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

		public static bool ContainsChild<TChild>() where TChild : T
		{
			Type typeFromHandle = typeof(TChild);
			if (_variants.TryGetValue(typeFromHandle, out var value) && value.Count > 0)
			{
				return true;
			}
			foreach (var (type2, hashSet2) in _variants)
			{
				if (!(type2 == typeFromHandle) && typeFromHandle.IsAssignableFrom(type2) && hashSet2.Count > 0)
				{
					return true;
				}
			}
			return false;
		}

		public static bool ContainsChild<TChild>(Func<TChild, bool> filter) where TChild : T
		{
			Type typeFromHandle = typeof(TChild);
			if (_variants.TryGetValue(typeFromHandle, out var value) && SetContains(value))
			{
				return true;
			}
			foreach (var (type2, list) in _variants)
			{
				if (!(type2 == typeFromHandle) && typeFromHandle.IsAssignableFrom(type2) && SetContains(list))
				{
					return true;
				}
			}
			return false;
			bool SetContains(HashSet<T> hashSet2)
			{
				foreach (TChild item in hashSet2)
				{
					if (filter(item))
					{
						return true;
					}
				}
				return false;
			}
		}

		public static bool ContainsChild<TChild, TArg1>(Func<TChild, TArg1, bool> filter, TArg1 arg1) where TChild : T
		{
			Type typeFromHandle = typeof(TChild);
			if (_variants.TryGetValue(typeFromHandle, out var value) && ListContains(value))
			{
				return true;
			}
			foreach (var (type2, list) in _variants)
			{
				if (!(type2 == typeFromHandle) && typeFromHandle.IsAssignableFrom(type2) && ListContains(list))
				{
					return true;
				}
			}
			return false;
			bool ListContains(HashSet<T> hashSet2)
			{
				foreach (TChild item in hashSet2)
				{
					if (filter(item, arg1))
					{
						return true;
					}
				}
				return false;
			}
		}

		public static bool ContainsChild<TChild, TArg1, TArg2>(Func<TChild, TArg1, TArg2, bool> filter, TArg1 arg1, TArg2 arg2) where TChild : T
		{
			Type typeFromHandle = typeof(TChild);
			if (_variants.TryGetValue(typeFromHandle, out var value) && ListContains(value))
			{
				return true;
			}
			foreach (var (type2, list) in _variants)
			{
				if (!(type2 == typeFromHandle) && typeFromHandle.IsAssignableFrom(type2) && ListContains(list))
				{
					return true;
				}
			}
			return false;
			bool ListContains(HashSet<T> hashSet2)
			{
				foreach (TChild item in hashSet2)
				{
					if (filter(item, arg1, arg2))
					{
						return true;
					}
				}
				return false;
			}
		}

		public static bool ContainsChild<TChild, TArg1, TArg2, TArg3>(Func<TChild, TArg1, TArg2, TArg3, bool> filter, TArg1 arg1, TArg2 arg2, TArg3 arg3) where TChild : T
		{
			Type typeFromHandle = typeof(TChild);
			if (_variants.TryGetValue(typeFromHandle, out var value) && ListContains(value))
			{
				return true;
			}
			foreach (var (type2, list) in _variants)
			{
				if (!(type2 == typeFromHandle) && typeFromHandle.IsAssignableFrom(type2) && ListContains(list))
				{
					return true;
				}
			}
			return false;
			bool ListContains(HashSet<T> hashSet2)
			{
				foreach (TChild item in hashSet2)
				{
					if (filter(item, arg1, arg2, arg3))
					{
						return true;
					}
				}
				return false;
			}
		}
	}
}
