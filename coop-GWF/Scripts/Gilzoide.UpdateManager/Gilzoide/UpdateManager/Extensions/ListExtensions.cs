using System.Collections.Generic;

namespace Gilzoide.UpdateManager.Extensions
{
	public static class ListExtensions
	{
		public static void RemoveAtSwapBack<T>(this IList<T> list, int index, out T swappedValue)
		{
			int num = list.Count - 1;
			if (num > 0 && num != index)
			{
				T val = (list[index] = list[num]);
				swappedValue = val;
			}
			else
			{
				swappedValue = default(T);
			}
			list.RemoveAt(num);
		}

		public static void Swap<T>(this IList<T> list, int sourceIndex, int destinationIndex, out T newDestinationValue)
		{
			newDestinationValue = list[sourceIndex];
			list[sourceIndex] = list[destinationIndex];
			list[destinationIndex] = newDestinationValue;
		}
	}
}
