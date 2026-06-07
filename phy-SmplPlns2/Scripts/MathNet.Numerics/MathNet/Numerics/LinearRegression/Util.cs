using System;
using System.Collections.Generic;

namespace MathNet.Numerics.LinearRegression
{
	internal static class Util
	{
		public static (TU[] U, TV[] V) UnpackSinglePass<TU, TV>(this IEnumerable<Tuple<TU, TV>> samples)
		{
			List<TU> list = new List<TU>();
			List<TV> list2 = new List<TV>();
			foreach (Tuple<TU, TV> sample in samples)
			{
				list.Add(sample.Item1);
				list2.Add(sample.Item2);
			}
			return (U: list.ToArray(), V: list2.ToArray());
		}

		public static (TU[] U, TV[] V) UnpackSinglePass<TU, TV>(this IEnumerable<(TU, TV)> samples)
		{
			List<TU> list = new List<TU>();
			List<TV> list2 = new List<TV>();
			foreach (var (item, item2) in samples)
			{
				list.Add(item);
				list2.Add(item2);
			}
			return (U: list.ToArray(), V: list2.ToArray());
		}
	}
}
