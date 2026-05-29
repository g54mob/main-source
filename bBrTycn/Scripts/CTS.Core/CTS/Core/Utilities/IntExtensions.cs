using System;
using System.Collections;

namespace CTS.Core.Utilities
{
	public static class IntExtensions
	{
		public static int ClampIndex(this int index, ICollection collection)
		{
			if (collection == null || collection.Count <= 0)
			{
				return -1;
			}
			return Math.Clamp(index, 0, Math.Max(0, collection.Count - 1));
		}

		public static bool IsCorrectArrayIndex(this int index, ICollection collection)
		{
			if (collection == null || collection.Count <= 0)
			{
				return false;
			}
			return Math.Clamp(index, 0, Math.Max(0, collection.Count - 1)) == index;
		}
	}
}
