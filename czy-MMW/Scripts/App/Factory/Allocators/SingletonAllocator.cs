using System;

namespace Factory.Allocators
{
	public class SingletonAllocator<T> : IAllocator<T>, IDisposable
	{
		private readonly T _instance;

		public SingletonAllocator(T instance)
		{
			_instance = instance;
		}

		public T Allocate(IScope context)
		{
			return _instance;
		}

		public bool Release(T obj, IScope context)
		{
			return true;
		}

		public virtual void OnObjectAssembled(T obj, IScope context)
		{
		}

		public void Dispose()
		{
		}
	}
}
