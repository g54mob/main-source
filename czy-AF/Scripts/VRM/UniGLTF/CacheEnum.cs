using System;
using System.Collections.Generic;

namespace UniGLTF
{
	public sealed class CacheEnum
	{
		private static class CacheParse<T> where T : struct, Enum
		{
			private static Dictionary<string, T> _values;

			private static Dictionary<string, T> _ignoreCaseValues;

			static CacheParse()
			{
				_values = new Dictionary<string, T>();
				_ignoreCaseValues = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
			}

			public static T ParseIgnoreCase(string name)
			{
				if (_ignoreCaseValues.TryGetValue(name, out var value))
				{
					return value;
				}
				if (!Enum.TryParse<T>(name, ignoreCase: true, out var result))
				{
					throw new ArgumentException("result");
				}
				value = result;
				_ignoreCaseValues.Add(name, value);
				return value;
			}

			public static T Parse(string name)
			{
				if (_values.TryGetValue(name, out var value))
				{
					return value;
				}
				if (!Enum.TryParse<T>(name, ignoreCase: false, out var result))
				{
					throw new ArgumentException("result");
				}
				value = result;
				_values.Add(name, value);
				return value;
			}
		}

		private static class CacheValues<T> where T : struct, Enum
		{
			public static readonly T[] Values;

			static CacheValues()
			{
				Values = Enum.GetValues(typeof(T)) as T[];
			}
		}

		public static T Parse<T>(string name, bool ignoreCase = false) where T : struct, Enum
		{
			if (ignoreCase)
			{
				return CacheParse<T>.ParseIgnoreCase(name);
			}
			return CacheParse<T>.Parse(name);
		}

		public static T TryParseOrDefault<T>(string name, bool ignoreCase = false, T defaultValue = default(T)) where T : struct, Enum
		{
			try
			{
				if (ignoreCase)
				{
					return CacheParse<T>.ParseIgnoreCase(name);
				}
				return CacheParse<T>.Parse(name);
			}
			catch
			{
				return defaultValue;
			}
		}

		public static T[] GetValues<T>() where T : struct, Enum
		{
			return CacheValues<T>.Values;
		}
	}
}
