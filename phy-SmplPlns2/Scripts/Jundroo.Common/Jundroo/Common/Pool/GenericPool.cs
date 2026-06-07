namespace Jundroo.Common.Pool
{
	public class GenericPool<T> where T : class, new()
	{
		private static readonly ObjectPool<T> _sharedPool = new ObjectPool<T>(() => new T());

		public static T Get()
		{
			return _sharedPool.Get();
		}

		public static PooledObject<T> Get(out T value)
		{
			return _sharedPool.Get(out value);
		}

		public static void Release(T value)
		{
			_sharedPool.Release(value);
		}
	}
}
