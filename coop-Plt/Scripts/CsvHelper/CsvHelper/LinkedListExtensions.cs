using System.Collections.Generic;

namespace CsvHelper
{
	internal static class LinkedListExtensions
	{
		public static void Drop<T>(this LinkedList<T> list, LinkedListNode<T> node)
		{
			if (list.Count == 0)
			{
				return;
			}
			while (list.Count > 0)
			{
				LinkedListNode<T> last = list.Last;
				list.RemoveLast();
				if (last == node)
				{
					break;
				}
			}
		}
	}
}
