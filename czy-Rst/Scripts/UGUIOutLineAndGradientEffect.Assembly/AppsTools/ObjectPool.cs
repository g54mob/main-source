using System.Collections.Generic;
using UnityEngine.Events;

namespace AppsTools
{
	public class ObjectPool<T> where T : new()
	{
		private readonly Stack<T> sk = new Stack<T>();

		private readonly UnityAction<T> getAction;

		private readonly UnityAction<T> rAction;

		public int countAll { get; private set; }

		public int countActive => countAll - countInactive;

		public int countInactive => sk.Count;

		public ObjectPool(UnityAction<T> _getAction, UnityAction<T> _rAction)
		{
			getAction = _getAction;
			rAction = _rAction;
		}

		public T Get()
		{
			T val;
			if (sk.Count == 0)
			{
				val = new T();
				countAll++;
			}
			else
			{
				val = sk.Pop();
			}
			if (getAction != null)
			{
				getAction(val);
			}
			return val;
		}

		public void Release(T element)
		{
			if (sk.Count <= 0 || (object)sk.Peek() != (object)element)
			{
				if (rAction != null)
				{
					rAction(element);
				}
				sk.Push(element);
			}
		}
	}
}
