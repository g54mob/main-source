using System;
using System.Collections.Generic;

namespace Kitchen
{
	public static class ManagedPool
	{
		public static ScaledManagedPool<byte[]> ByteArrayPool(int size)
		{
			return new ScaledManagedPool<byte[]>(size, (int s) => new byte[(s > size) ? s : size], delegate(byte[] b)
			{
				if (b.Length > size)
				{
					return false;
				}
				for (int i = 0; i < size; i++)
				{
					b[i] = 0;
				}
				return true;
			});
		}

		public static ManagedPool<List<T>> ListPool<T>()
		{
			return new ManagedPool<List<T>>(() => new List<T>(), delegate(List<T> b)
			{
				b.Clear();
				return true;
			});
		}
	}
	public class ManagedPool<T>
	{
		private Queue<PoolElement<T>> Storage = new Queue<PoolElement<T>>();

		private Func<T> Create;

		private Func<T, bool> Reset;

		public ManagedPool(Func<T> create, Func<T, bool> reset)
		{
			Create = create;
			Reset = reset;
		}

		public PoolElement<T> Request()
		{
			if (Storage.Count <= 0)
			{
				return new PoolElement<T>
				{
					Element = Create(),
					Pool = this
				};
			}
			return Storage.Dequeue();
		}

		public void Free(PoolElement<T> element)
		{
			if (Reset(element.Element))
			{
				Storage.Enqueue(element);
			}
		}

		public void Free(T element)
		{
			if (Reset(element))
			{
				Storage.Enqueue(new PoolElement<T>
				{
					Element = element,
					Pool = this
				});
			}
		}
	}
}
