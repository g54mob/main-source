using System;
using System.Collections.Generic;

namespace MiscUtil.Collections
{
	public class DictionaryByType
	{
		private readonly IDictionary<Type, object> dictionary = new Dictionary<Type, object>();

		public void Add<T>(T value)
		{
			dictionary.Add(typeof(T), value);
		}

		public void Put<T>(T value)
		{
			dictionary[typeof(T)] = value;
		}

		public T Get<T>()
		{
			return (T)dictionary[typeof(T)];
		}

		public bool TryGet<T>(out T value)
		{
			if (dictionary.TryGetValue(typeof(T), out var value2))
			{
				value = (T)value2;
				return true;
			}
			value = default(T);
			return false;
		}
	}
}
