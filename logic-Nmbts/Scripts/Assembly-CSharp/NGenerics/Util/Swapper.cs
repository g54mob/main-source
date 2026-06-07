using System.Collections.Generic;

namespace NGenerics.Util
{
	internal static class Swapper
	{
		internal static void Swap<T>(IList<T> list, int pos1, int pos2)
		{
			T value = list[pos1];
			list[pos1] = list[pos2];
			list[pos2] = value;
		}
	}
}
