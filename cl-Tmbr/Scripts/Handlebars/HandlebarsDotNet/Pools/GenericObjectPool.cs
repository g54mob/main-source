using System.Runtime.InteropServices;

namespace HandlebarsDotNet.Pools
{
	internal class GenericObjectPool<T> : InternalObjectPool<T, GenericObjectPool<T>.Policy> where T : class, new()
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public readonly struct Policy : IInternalObjectPoolPolicy<T>
		{
			public T Create()
			{
				return new T();
			}

			public bool Return(T item)
			{
				return true;
			}
		}

		public static GenericObjectPool<T> Shared { get; } = new GenericObjectPool<T>();

		private GenericObjectPool()
			: base(default(Policy))
		{
		}
	}
}
