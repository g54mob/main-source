using System.Collections.Generic;

namespace Utils
{
	public static class LinkedListNodeExtensions
	{
		public static LinkedListNode<T> LoopingNext<T>(this LinkedListNode<T> node)
		{
			bool didLoop;
			return node.LoopingNext(out didLoop);
		}

		public static LinkedListNode<T> LoopingNext<T>(this LinkedListNode<T> node, out bool didLoop)
		{
			if (node.Next == null)
			{
				didLoop = true;
				return node.List.First;
			}
			didLoop = false;
			return node.Next;
		}

		public static LinkedListNode<T> LoopingPrevious<T>(this LinkedListNode<T> node)
		{
			bool didLoop;
			return node.LoopingPrevious(out didLoop);
		}

		public static LinkedListNode<T> LoopingPrevious<T>(this LinkedListNode<T> node, out bool didLoop)
		{
			if (node.Previous == null)
			{
				didLoop = true;
				return node.List.Last;
			}
			didLoop = false;
			return node.Previous;
		}
	}
}
