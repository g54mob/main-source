using System.Collections.Generic;
using System.Linq;
using ZLinq;
using ZLinq.Linq;

public static class CollectionExtensions
{
	private class ShuffleComparer<TSource> : IComparer<TSource>
	{
		public int Compare(TSource x, TSource y)
		{
			return BiteRandom.NextInt();
		}
	}

	public static TSource Random<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
	{
		return source.ElementAt(BiteRandom.NextInt(source.Count()));
	}

	public static int RandomIndex<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
	{
		return BiteRandom.NextInt(source.Count());
	}

	public static ValueEnumerable<OrderBySkipTake<TEnumerator, TSource, TSource>, TSource> Random<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
	{
		return source.Shuffle().Take(count);
	}

	public static ValueEnumerable<OrderBy<TEnumerator, TSource, TSource>, TSource> Shuffle<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
	{
		return source.Order(new ShuffleComparer<TSource>());
	}

	public static void Shuffle<T>(this Queue<T> queue)
	{
		List<T> source = queue.ToList();
		queue.Clear();
		using ValueEnumerator<OrderBy<FromList<T>, T, T>, T> valueEnumerator = source.AsValueEnumerable().Shuffle().GetEnumerator<OrderBy<FromList<T>, T, T>, T>();
		while (valueEnumerator.MoveNext())
		{
			T current = valueEnumerator.Current;
			queue.Enqueue(current);
		}
	}
}
