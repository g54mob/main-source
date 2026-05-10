using System.Collections.Generic;
using System.Linq;
using CTS.Core.StatisticsSystem;
using UnityEngine;

namespace CTS.Utilities
{
	public static class DictionnariesExtensions
	{
		public static T DrawWeightedRandom<T>(this IDictionary<T, NumericStatistic> dict)
		{
			T[] array = dict.Keys.ToArray();
			NumericStatistic[] array2 = dict.Values.ToArray();
			float num = 0f;
			NumericStatistic[] array3 = array2;
			foreach (NumericStatistic numericStatistic in array3)
			{
				num += numericStatistic.Value;
			}
			float num2 = Random.Range(0f, num);
			int num3 = 0;
			for (int j = 0; j < array2.Length; j++)
			{
				num2 -= array2[j].Value;
				if (num2 < 0f)
				{
					num3 = j;
					break;
				}
			}
			return array[num3];
		}

		public static T DrawWeightedRandom<T>(this IDictionary<T, float> dict)
		{
			T[] array = dict.Keys.ToArray();
			float[] array2 = dict.Values.ToArray();
			float maxInclusive = array2.Sum();
			float num = Random.Range(0f, maxInclusive);
			int num2 = 0;
			for (int i = 0; i < array2.Length; i++)
			{
				num -= array2[i];
				if (num < 0f)
				{
					num2 = i;
					break;
				}
			}
			if (array.Length == 0)
			{
				return default(T);
			}
			return array[num2];
		}

		public static T DrawWeightedRandom<T>(this IDictionary<T, int> dict)
		{
			T[] array = dict.Keys.ToArray();
			int[] array2 = dict.Values.ToArray();
			int num = array2.Sum();
			int num2 = Random.Range(0, num + 1);
			int num3 = 0;
			for (int i = 0; i < array2.Length; i++)
			{
				num2 -= array2[i];
				if (num2 < 0)
				{
					num3 = i;
				}
			}
			return array[num3];
		}
	}
}
