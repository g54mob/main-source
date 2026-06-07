using System;

namespace Factory.Allocators
{
	public interface IAllocator<T> : IDisposable
	{
		T Allocate(IScope owningScope);

		bool Release(T obj, IScope owningScope);

		void OnObjectAssembled(T obj, IScope owningScope);
	}
}
