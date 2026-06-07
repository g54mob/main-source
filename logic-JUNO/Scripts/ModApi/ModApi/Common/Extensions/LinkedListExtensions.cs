using System;
using System.Collections.Generic;

namespace ModApi.Common.Extensions
{
	public static class LinkedListExtensions
	{
		public static bool Remove<T>(this LinkedList<T> list, T value, bool removeChildren)
		{
			return list.Remove(value, removeChildren);
		}

		public static void Remove<T>(this LinkedList<T> list, LinkedListNode<T> nodeToDelete, bool removeChildren, Action<LinkedListNode<T>> beforeAction, Action afterAction)
		{
			if (removeChildren)
			{
				if (nodeToDelete != null)
				{
					LinkedListNode<T> linkedListNode = list.Last;
					LinkedListNode<T> linkedListNode2 = null;
					while (linkedListNode != null)
					{
						linkedListNode2 = linkedListNode.Previous;
						beforeAction?.Invoke(linkedListNode);
						list.Remove(linkedListNode);
						afterAction?.Invoke();
						linkedListNode = ((linkedListNode != nodeToDelete) ? linkedListNode2 : null);
					}
				}
			}
			else
			{
				beforeAction?.Invoke(nodeToDelete);
				list.Remove(nodeToDelete);
				afterAction?.Invoke();
			}
		}
	}
}
