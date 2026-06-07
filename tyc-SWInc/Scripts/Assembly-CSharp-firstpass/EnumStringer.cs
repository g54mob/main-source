using System;
using System.Collections.Generic;

public class EnumStringer<T>
{
	private static Dictionary<T, string> _cache = null;

	private static object _lock = new object();

	public static string ToString(T key)
	{
		lock (_lock)
		{
			if (_cache == null)
			{
				_cache = new Dictionary<T, string>();
				foreach (object value in Enum.GetValues(typeof(T)))
				{
					_cache[(T)value] = value.ToString();
				}
			}
			return _cache[key];
		}
	}
}
