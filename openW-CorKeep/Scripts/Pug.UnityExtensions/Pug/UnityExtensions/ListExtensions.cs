using System.Collections.Generic;

namespace Pug.UnityExtensions
{
	public static class ListExtensions
	{
		public static void Resize<T>(this List<T> genericList, T elementToFillOutWith, int length)
		{
			int num = genericList.Count - length;
			if (num > 0)
			{
				genericList.RemoveRange(length, num);
			}
			else if (num < 0)
			{
				genericList.Capacity = length;
				for (int i = 0; i < -num; i++)
				{
					genericList.Add(elementToFillOutWith);
				}
			}
		}
	}
}
