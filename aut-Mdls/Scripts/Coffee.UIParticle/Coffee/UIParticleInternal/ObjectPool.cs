using System;
using System.Collections.Generic;

namespace Coffee.UIParticleInternal
{
	internal class ObjectPool<T>
	{
		private readonly Func<T> _onCreate;

		private readonly Action<T> _onReturn;

		private readonly Predicate<T> _onValid;

		private readonly Stack<T> _pool = new Stack<T>(32);

		private int _count;

		public ObjectPool(Func<T> onCreate, Predicate<T> onValid, Action<T> onReturn)
		{
			_onCreate = onCreate;
			_onValid = onValid;
			_onReturn = onReturn;
		}

		public T Rent()
		{
			while (0 < _pool.Count)
			{
				T val = _pool.Pop();
				if (_onValid(val))
				{
					return val;
				}
			}
			return _onCreate();
		}

		public void Return(ref T instance)
		{
			if (instance != null && !_pool.Contains(instance))
			{
				_onReturn(instance);
				_pool.Push(instance);
				instance = default(T);
			}
		}
	}
}
