using System.Collections.Generic;
using ZLinq;
using ZLinq.Linq;

public static class ZLinqExtensions
{
	public static IEnumerable<T> AsEnumerable<TEnumerator, T>(this ValueEnumerable<TEnumerator, T> valueEnumerable) where TEnumerator : struct, IValueEnumerator<T>
	{
		using TEnumerator e = valueEnumerable.Enumerator;
		T current;
		while (e.TryGetNext(out current))
		{
			yield return current;
		}
	}

	public static ValueEnumerable<Where<TEnumerator, string>, string> IsNullOrEmpty<TEnumerator>(this ValueEnumerable<TEnumerator, string> valueEnumerable) where TEnumerator : struct, IValueEnumerator<string>
	{
		return valueEnumerable.Where(string.IsNullOrEmpty);
	}

	public static ValueEnumerable<Where<TEnumerator, string>, string> IsNotNullOrEmpty<TEnumerator>(this ValueEnumerable<TEnumerator, string> valueEnumerable) where TEnumerator : struct, IValueEnumerator<string>
	{
		return valueEnumerable.Where((string x) => !string.IsNullOrEmpty(x));
	}
}
