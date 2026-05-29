using System;
using System.Collections.Generic;

namespace Coffee.UIParticleInternal
{
	internal class ObjectPool<T>
	{
		private readonly Func<T> _onCreate;

		private readonly Action<T> _onReturn;

		private readonly Predicate<T> _onValid;

		private readonly Stack<T> _pool;

		private int _count;

		public ObjectPool(Func<T> onCreate, Predicate<T> onValid, Action<T> onReturn)
		{
		}

		public T Rent()
		{
			return default(T);
		}

		public void Return(ref T instance)
		{
		}
	}
}
