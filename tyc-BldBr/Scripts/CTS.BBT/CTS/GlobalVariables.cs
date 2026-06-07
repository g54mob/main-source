using System;
using System.Collections.Generic;
using CTS.Core;

namespace CTS
{
	public static class GlobalVariables<T>
	{
		private static readonly Dictionary<StringKey, T> _variables = new Dictionary<StringKey, T>();

		public static event Action<StringKey, T> VariableChanged;

		public static bool HasValue(StringKey key)
		{
			return _variables.ContainsKey(key);
		}

		public static T Get(StringKey key, T defaultValue = default(T))
		{
			return _variables.GetValueOrDefault(key, defaultValue);
		}

		public static void Set(StringKey key, T value)
		{
			if (!_variables.TryGetValue(key, out var value2) || !EqualityComparer<T>.Default.Equals(value2, value))
			{
				_variables[key] = value;
				GlobalVariables<T>.VariableChanged?.Invoke(key, value);
			}
		}
	}
}
