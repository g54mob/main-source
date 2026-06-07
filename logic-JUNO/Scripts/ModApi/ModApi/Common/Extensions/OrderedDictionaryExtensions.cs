using System.Collections.Specialized;
using UnityEngine;

namespace ModApi.Common.Extensions
{
	public static class OrderedDictionaryExtensions
	{
		public static int IndexOf(this OrderedDictionary dictionary, object value)
		{
			int num = 0;
			foreach (object value2 in dictionary.Values)
			{
				if (value2.Equals(value2))
				{
					return num;
				}
				num++;
			}
			Debug.LogError($"\"{value}\" : value not found.");
			return -1;
		}

		public static int IndexOfKey(this OrderedDictionary dictionary, object key)
		{
			int num = 0;
			foreach (object key2 in dictionary.Keys)
			{
				if (key2.Equals(key))
				{
					return num;
				}
				num++;
			}
			Debug.LogError($"\"{key}\" : key not found.");
			return -1;
		}
	}
}
