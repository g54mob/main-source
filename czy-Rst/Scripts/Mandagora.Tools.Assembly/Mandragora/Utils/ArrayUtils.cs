using System;
using UnityEngine;

namespace Mandragora.Utils
{
	public static class ArrayUtils
	{
		public static bool CheckLengths(Array a, Array b, int dimensions = 1)
		{
			dimensions = Mathf.Max(dimensions, 0);
			for (int i = 0; i < dimensions; i++)
			{
				if (a.GetLength(i) != b.GetLength(i))
				{
					return false;
				}
			}
			return true;
		}
	}
}
