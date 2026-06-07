using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScriptHelpers
{
	public static class ListExtend
	{
		private static System.Random r = new System.Random();

		public static void Shuffle<T>(this IList<T> list)
		{
			int num = list.Count;
			while (num > 1)
			{
				num--;
				int num2 = r.Next(num + 1);
				int index = num2;
				int index2 = num;
				T val = list[num];
				T val2 = list[num2];
				T val3 = (list[index] = val);
				val3 = (list[index2] = val2);
			}
		}

		public static T MaxBy<T, R>(this IEnumerable<T> en, Func<T, R> evaluate) where R : IComparable<R>
		{
			if (!en.Any())
			{
				return default(T);
			}
			return en.Select((T t) => new Tuple<T, R>(t, evaluate(t))).Aggregate((Tuple<T, R> max, Tuple<T, R> next) => (next.Item2.CompareTo(max.Item2) <= 0) ? max : next).Item1;
		}

		public static T MinBy<T, R>(this IEnumerable<T> en, Func<T, R> evaluate) where R : IComparable<R>
		{
			if (!en.Any())
			{
				return default(T);
			}
			return en.Select((T t) => new Tuple<T, R>(t, evaluate(t))).Aggregate((Tuple<T, R> max, Tuple<T, R> next) => (next.Item2.CompareTo(max.Item2) >= 0) ? max : next).Item1;
		}

		public static T RandomElement<T>(this IEnumerable<T> en)
		{
			int num = en.Count();
			if (num >= 1)
			{
				return en.ElementAt(r.Next(0, num));
			}
			return default(T);
		}

		public static int IndexOfClosest(this IList<float> list, float value)
		{
			float num = float.PositiveInfinity;
			int result = -1;
			for (int i = 0; i < list.Count; i++)
			{
				float num2 = list[i];
				if (!(num < Mathf.Abs(num2 - value)))
				{
					num = Mathf.Abs(num2 - value);
					result = i;
				}
			}
			return result;
		}

		public static int IndexOfClosest(this IList<int> list, float value)
		{
			float num = float.PositiveInfinity;
			int result = -1;
			for (int i = 0; i < list.Count; i++)
			{
				int num2 = list[i];
				if (!(num < Mathf.Abs((float)num2 - value)))
				{
					num = Mathf.Abs((float)num2 - value);
					result = i;
				}
			}
			return result;
		}
	}
}
