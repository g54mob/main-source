using System;
using System.Collections.Generic;

namespace UIUtilities
{
	public class TypedDictionary
	{
		private readonly Dictionary<Type, object> dict;

		public List<Type> Keys()
		{
			return null;
		}

		public void Add<T>(T item)
		{
		}

		public void Add<T, T1>(T1 item)
		{
		}

		public T Get<T>()
		{
			return default(T);
		}

		public T1 Get<T, T1>()
		{
			return default(T1);
		}

		public T1 Get<T1>(Type type)
		{
			return default(T1);
		}

		public void Set<T, T1>(T1 item)
		{
		}

		public void Set<T1>(Type type, T1 item)
		{
		}

		public bool ContainsKey<T>()
		{
			return false;
		}

		public bool ContainsKey(Type type)
		{
			return false;
		}
	}
}
