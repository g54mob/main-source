using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentAssertions.Common
{
	internal static class EnumerableExtensions
	{
		public static ICollection<T> ConvertOrCastToCollection<T>(this IEnumerable<T> source)
		{
			return (source as ICollection<T>) ?? source.ToList();
		}

		public static IList<T> ConvertOrCastToList<T>(this IEnumerable<T> source)
		{
			return (source as IList<T>) ?? source.ToList();
		}

		public static int IndexOfFirstDifferenceWith<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, bool> equalityComparison)
		{
			using IEnumerator<TFirst> enumerator = first.GetEnumerator();
			using IEnumerator<TSecond> enumerator2 = second.GetEnumerator();
			int num = 0;
			while (true)
			{
				bool flag = !enumerator.MoveNext();
				bool flag2 = !enumerator2.MoveNext();
				if (flag && flag2)
				{
					return -1;
				}
				if (flag != flag2)
				{
					return num;
				}
				if (!equalityComparison(enumerator.Current, enumerator2.Current))
				{
					break;
				}
				num++;
			}
			return num;
		}
	}
}
