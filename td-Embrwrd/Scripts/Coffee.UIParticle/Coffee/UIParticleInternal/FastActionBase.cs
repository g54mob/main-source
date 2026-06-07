using System;
using System.Collections.Generic;

namespace Coffee.UIParticleInternal
{
	internal class FastActionBase<T>
	{
		private static readonly InternalObjectPool<LinkedListNode<T>> s_NodePool;

		private readonly LinkedList<T> _delegates;

		public void Add(T rhs)
		{
		}

		public void Remove(T rhs)
		{
		}

		protected void Invoke(Action<T> callback)
		{
		}

		public void Clear()
		{
		}
	}
}
