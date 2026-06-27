using System;
using System.Collections.Generic;

namespace Helpers.Extensions
{
	public static class ListExtensions
	{
		public static List<T> Clone<T>(this List<T> source) where T : ICloneable
		{
			List<T> list = new List<T>(source.Count);
			foreach (T item in source)
			{
				list.Add((T)item.Clone());
			}
			return list;
		}

		public static bool Replace<T>(this List<T> source, T oldValue, T newValue)
		{
			bool result = false;
			for (int i = 0; i < source.Count; i++)
			{
				if (source[i].Equals(oldValue))
				{
					source[i] = newValue;
					result = true;
				}
			}
			return result;
		}
	}
}
