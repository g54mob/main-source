using System;
using UnityEngine.Pool;

namespace Coffee.UIParticleInternal
{
	internal class InternalObjectPool<T> where T : class
	{
		private readonly Predicate<T> _onValid;

		private readonly ObjectPool<T> _pool;

		public InternalObjectPool(Func<T> onCreate, Predicate<T> onValid, Action<T> onReturn)
		{
		}

		public T Rent()
		{
			return null;
		}

		public void Return(ref T instance)
		{
		}
	}
}
