using System;
using System.Collections.Generic;

namespace Jundroo.Common.Extensions
{
	public static class QueueExtensions
	{
		public static void EnqueueRange<T>(this Queue<T> queue, IEnumerable<T> items)
		{
			if (items is IList<T> list)
			{
				for (int i = 0; i < list.Count; i++)
				{
					queue.Enqueue(list[i]);
				}
				return;
			}
			foreach (T item in items)
			{
				queue.Enqueue(item);
			}
		}

		public static TSource Last<TSource>(this Queue<TSource> source)
		{
			using Queue<TSource>.Enumerator enumerator = source.GetEnumerator();
			if (enumerator.MoveNext())
			{
				TSource current;
				do
				{
					current = enumerator.Current;
				}
				while (enumerator.MoveNext());
				return current;
			}
			throw new InvalidOperationException("The source queue is empty. Unable to obtain the last element.");
		}

		public static TSource LastOrDefault<TSource>(this Queue<TSource> source)
		{
			using Queue<TSource>.Enumerator enumerator = source.GetEnumerator();
			if (enumerator.MoveNext())
			{
				TSource current;
				do
				{
					current = enumerator.Current;
				}
				while (enumerator.MoveNext());
				return current;
			}
			return default(TSource);
		}

		public static bool Remove<T>(this Queue<T> queue, T itemToRemove)
		{
			bool flag = false;
			int count = queue.Count;
			for (int i = 0; i < count; i++)
			{
				T val = queue.Dequeue();
				if (!flag && EqualityComparer<T>.Default.Equals(val, itemToRemove))
				{
					flag = true;
				}
				else
				{
					queue.Enqueue(val);
				}
			}
			return flag;
		}
	}
}
