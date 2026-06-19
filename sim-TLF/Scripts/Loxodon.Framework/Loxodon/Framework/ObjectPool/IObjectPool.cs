using System;

namespace Loxodon.Framework.ObjectPool
{
	public interface IObjectPool : IDisposable
	{
		object Allocate();

		void Free(object obj);
	}
	public interface IObjectPool<T> : IObjectPool, IDisposable where T : class
	{
		new T Allocate();

		void Free(T obj);
	}
}
