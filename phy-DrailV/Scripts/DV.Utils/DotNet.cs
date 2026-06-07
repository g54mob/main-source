using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class DotNet
{
	public class GroupOfAdjacent<TSource, TKey> : IEnumerable<TSource>, IEnumerable, IGrouping<TKey, TSource>
	{
		public TKey Key { get; set; }

		private List<TSource> GroupList { get; set; }

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<TSource>)this).GetEnumerator();
		}

		IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
		{
			foreach (TSource group in GroupList)
			{
				yield return group;
			}
		}

		public GroupOfAdjacent(List<TSource> source, TKey key)
		{
			GroupList = source;
			Key = key;
		}
	}

	public static IEnumerable<TResult> Pairwise<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, TResult> resultSelector)
	{
		TSource previous = default(TSource);
		using (IEnumerator<TSource> it = source.GetEnumerator())
		{
			if (it.MoveNext())
			{
				previous = it.Current;
			}
			while (it.MoveNext())
			{
				TSource arg = previous;
				TSource current;
				previous = (current = it.Current);
				yield return resultSelector(arg, current);
			}
		}
	}

	public static IEnumerable<IGrouping<TKey, TSource>> GroupAdjacent<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		TKey val = default(TKey);
		bool haveLast = false;
		List<TSource> list = new List<TSource>();
		foreach (TSource s in source)
		{
			TKey k = keySelector(s);
			if (haveLast)
			{
				if (!k.Equals(val))
				{
					yield return new GroupOfAdjacent<TSource, TKey>(list, val);
					list = new List<TSource>();
					list.Add(s);
					val = k;
				}
				else
				{
					list.Add(s);
					val = k;
				}
			}
			else
			{
				list.Add(s);
				val = k;
				haveLast = true;
			}
		}
		if (haveLast)
		{
			yield return new GroupOfAdjacent<TSource, TKey>(list, val);
		}
	}
}
