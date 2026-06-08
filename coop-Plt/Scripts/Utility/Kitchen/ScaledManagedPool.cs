using System;

namespace Kitchen
{
	public class ScaledManagedPool<T> : ManagedPool<T>
	{
		public readonly int Size;

		private readonly Func<int, T> SizedCreate;

		public ScaledManagedPool(int size, Func<int, T> create, Func<T, bool> reset)
			: base((Func<T>)(() => create(size)), reset)
		{
			Size = size;
			SizedCreate = create;
		}

		public PoolElement<T> Request(int size)
		{
			if (size > Size)
			{
				return new PoolElement<T>
				{
					Element = SizedCreate(size),
					Pool = this
				};
			}
			return Request();
		}
	}
}
