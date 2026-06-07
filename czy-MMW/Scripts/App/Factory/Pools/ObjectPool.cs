using Factory.Allocators;

namespace Factory.Pools
{
	public class ObjectPool<T> : Pool<T> where T : IReusable, new()
	{
		public ObjectPool()
			: base((IAllocator<T>)new HeapAllocator<T>())
		{
		}
	}
}
