using System;

namespace Factory.Allocators
{
	public class HeapAllocator<T> : IAllocator<T>, IDisposable where T : new()
	{
		public T Allocate(IScope context)
		{
			T val = new T();
			OnObjectAllocated(val, context);
			return val;
		}

		public bool Release(T obj, IScope context)
		{
			OnObjectReleased(obj, context);
			return true;
		}

		public virtual void OnObjectAssembled(T obj, IScope context)
		{
		}

		protected virtual void OnObjectAllocated(T obj, IScope context)
		{
		}

		protected virtual void OnObjectReleased(T obj, IScope context)
		{
		}

		public void Dispose()
		{
		}
	}
}
