using System.Collections.Generic;

namespace LibTessDotNet
{
	public class DefaultTypePool<T> : ITypePool where T : class, Pooled<T>, new()
	{
		private Queue<T> _pool = new Queue<T>();

		public object Get()
		{
			lock (_pool)
			{
				if (_pool.Count > 0)
				{
					return _pool.Dequeue();
				}
			}
			return new T();
		}

		public void Return(object obj)
		{
			lock (_pool)
			{
				_pool.Enqueue(obj as T);
			}
		}
	}
}
