using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class ListUtils
	{
		public static void Shuffle<T>(this List<T> list)
		{
			for (int num = list.Count - 1; num > 1; num--)
			{
				int num2 = Random.Range(0, num + 1);
				int index = num2;
				int index2 = num;
				T val = list[num];
				T val2 = list[num2];
				T val3 = (list[index] = val);
				val3 = (list[index2] = val2);
			}
		}
	}
}
