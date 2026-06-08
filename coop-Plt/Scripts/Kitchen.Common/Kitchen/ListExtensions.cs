using System.Collections.Generic;

namespace Kitchen
{
	public static class ListExtensions
	{
		public static T Wrap<T>(this List<T> list, ref int index)
		{
			return list[index % list.Count];
		}
	}
}
