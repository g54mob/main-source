using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModApi.Common.Extensions
{
	public static class MonoBehaviourExtensions
	{
		public static Coroutine StartThrowingCoroutine(this MonoBehaviour monoBehaviour, IEnumerator enumerator, Action<Exception> onException)
		{
			return monoBehaviour.StartCoroutine(RunThrowingIteratorWithNesting(enumerator, onException));
		}

		private static IEnumerator RunThrowingIteratorWithNesting(IEnumerator enumerator, Action<Exception> onException)
		{
			Stack<IEnumerator> stack = new Stack<IEnumerator>();
			stack.Push(enumerator);
			while (stack.Count > 0)
			{
				IEnumerator enumerator2 = stack.Peek();
				object current;
				try
				{
					if (!enumerator2.MoveNext())
					{
						stack.Pop();
						continue;
					}
					current = enumerator2.Current;
				}
				catch (Exception obj)
				{
					onException(obj);
					break;
				}
				if (current is IEnumerator item)
				{
					stack.Push(item);
				}
				else
				{
					yield return current;
				}
			}
		}
	}
}
