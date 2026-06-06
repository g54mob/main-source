using System.Collections.Generic;

namespace Coffee.UISoftMaskInternal
{
	internal static class ListExtensions
	{
		public static void RemoveAtFast<T>(this List<T> self, int index)
		{
			if (self != null)
			{
				int index2 = self.Count - 1;
				self[index] = self[index2];
				self.RemoveAt(index2);
			}
		}
	}
}
