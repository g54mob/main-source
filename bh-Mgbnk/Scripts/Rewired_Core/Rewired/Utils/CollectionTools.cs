using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class CollectionTools
	{
		public static Dictionary<TValue, TKey> CreateInverseDictionary<TKey, TValue>(Dictionary<TKey, TValue> dict)
		{
			return null;
		}

		public static TReturn GetDictionaryValueSafe<TReturn>(Dictionary<string, object> dictionary, string key)
		{
			return default(TReturn);
		}

		public static TReturn GetDictionaryValueSafe<TReturn>(Dictionary<string, object> dictionary, string key, out bool success)
		{
			success = default(bool);
			return default(TReturn);
		}

		public static TValue GetDictionaryValueSafe<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key)
		{
			return default(TValue);
		}

		public static TValue GetDictionaryValueSafe<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, out bool success)
		{
			success = default(bool);
			return default(TValue);
		}

		public static bool GetDictionaryValueSafe<TReturn>(Dictionary<string, object> dictionary, string key, ref TReturn value)
		{
			return false;
		}

		public static bool GetDictionaryValueSafe(Dictionary<string, object> dictionary, string key, Type type, ref object value)
		{
			return false;
		}

		public static bool GetDictionaryValueSafe_float(Dictionary<string, object> dictionary, string key, ref float value)
		{
			return false;
		}

		public static bool GetDictionaryValueSafe_int(Dictionary<string, object> dictionary, string key, ref int value)
		{
			return false;
		}

		public static void AddValueSafe(Dictionary<string, object> data, string key, object value)
		{
		}

		public static T GetValue<T>(IEnumerable<T> enumerable, int index)
		{
			return default(T);
		}

		public static T GetValue<T>(IEnumerable enumerable, int index)
		{
			return default(T);
		}

		public static void Enqueue<T>(IObjectPool<T> pool, RingBuffer<T> buffer, T item, out bool overrun)
		{
			overrun = default(bool);
		}

		public static void Clear<T>(IObjectPool<T> pool, RingBuffer<T> buffer)
		{
		}
	}
}
