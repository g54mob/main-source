using System;
using System.Collections;
using System.Collections.Generic;

namespace DepthFirstScheduler
{
	public static class IEnumeratorExtensions
	{
		[Obsolete("Use CoroutineToEnd")]
		public static void CoroutinetoEnd(this IEnumerator coroutine)
		{
			coroutine.CoroutineToEnd();
		}

		public static void CoroutineToEnd(this IEnumerator coroutine)
		{
			Stack<IEnumerator> stack = new Stack<IEnumerator>();
			stack.Push(coroutine);
			while (stack.Count > 0)
			{
				if (stack.Peek().MoveNext())
				{
					if (stack.Peek().Current is IEnumerator item)
					{
						stack.Push(item);
					}
				}
				else
				{
					stack.Pop();
				}
			}
		}
	}
}
