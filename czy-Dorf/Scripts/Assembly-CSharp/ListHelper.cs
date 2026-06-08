using System.Collections.Generic;
using System.Linq;

public static class ListHelper
{
	private sealed class _003C_003Ec__DisplayClass4_0<T>
	{
		public IEnumerable<T> listB;

		internal bool _003CListsContainAMatchingValue_003Eb__0(T x)
		{
			return Enumerable.Contains(listB, x);
		}
	}

	public static string ListDebugString<T>(List<T> listToDebug, string separator = ", ")
	{
		string text = "";
		foreach (T item in listToDebug)
		{
			string text2 = text;
			T val = item;
			text = text2 + val?.ToString() + separator;
		}
		return text;
	}

	public static bool Equals<TKey, TValue>(IDictionary<TKey, TValue> x, IDictionary<TKey, TValue> y)
	{
		if (y == null)
		{
			return x == null;
		}
		if (x == null)
		{
			return false;
		}
		if (x == y)
		{
			return true;
		}
		if (x.Count != y.Count)
		{
			return false;
		}
		foreach (TKey key in x.Keys)
		{
			if (!y.ContainsKey(key))
			{
				return false;
			}
		}
		foreach (TKey key2 in x.Keys)
		{
			if (!x[key2].Equals(y[key2]))
			{
				return false;
			}
		}
		return true;
	}

	public static float Sum(List<float> values)
	{
		float num = 0f;
		foreach (float value in values)
		{
			num += value;
		}
		return num;
	}

	public static bool ListsContainAMatchingValue<T>(IEnumerable<T> listA, IEnumerable<T> listB)
	{
		_003C_003Ec__DisplayClass4_0<T> CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass4_0<T>();
		CS_0024_003C_003E8__locals2.listB = listB;
		return Enumerable.Any(listA, (T x) => Enumerable.Contains(CS_0024_003C_003E8__locals2.listB, x));
	}
}
