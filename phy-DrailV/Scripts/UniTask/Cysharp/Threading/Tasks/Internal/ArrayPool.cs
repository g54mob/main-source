using System;
using System.Threading;

namespace Cysharp.Threading.Tasks.Internal
{
	internal sealed class ArrayPool<T>
	{
		private const int DefaultMaxNumberOfArraysPerBucket = 50;

		private static readonly T[] EmptyArray = new T[0];

		public static readonly ArrayPool<T> Shared = new ArrayPool<T>();

		private readonly MinimumQueue<T[]>[] buckets;

		private readonly SpinLock[] locks;

		private ArrayPool()
		{
			buckets = new MinimumQueue<T[]>[18];
			locks = new SpinLock[18];
			for (int i = 0; i < buckets.Length; i++)
			{
				buckets[i] = new MinimumQueue<T[]>(4);
				locks[i] = new SpinLock(enableThreadOwnerTracking: false);
			}
		}

		public T[] Rent(int minimumLength)
		{
			if (minimumLength < 0)
			{
				throw new ArgumentOutOfRangeException("minimumLength");
			}
			if (minimumLength == 0)
			{
				return EmptyArray;
			}
			int num = CalculateSize(minimumLength);
			int queueIndex = GetQueueIndex(num);
			if (queueIndex != -1)
			{
				MinimumQueue<T[]> minimumQueue = buckets[queueIndex];
				bool lockTaken = false;
				try
				{
					locks[queueIndex].Enter(ref lockTaken);
					if (minimumQueue.Count != 0)
					{
						return minimumQueue.Dequeue();
					}
				}
				finally
				{
					if (lockTaken)
					{
						locks[queueIndex].Exit(useMemoryBarrier: false);
					}
				}
			}
			return new T[num];
		}

		public void Return(T[] array, bool clearArray = false)
		{
			if (array == null || array.Length == 0)
			{
				return;
			}
			int queueIndex = GetQueueIndex(array.Length);
			if (queueIndex == -1)
			{
				return;
			}
			if (clearArray)
			{
				Array.Clear(array, 0, array.Length);
			}
			MinimumQueue<T[]> minimumQueue = buckets[queueIndex];
			bool lockTaken = false;
			try
			{
				locks[queueIndex].Enter(ref lockTaken);
				if (minimumQueue.Count <= 50)
				{
					minimumQueue.Enqueue(array);
				}
			}
			finally
			{
				if (lockTaken)
				{
					locks[queueIndex].Exit(useMemoryBarrier: false);
				}
			}
		}

		private static int CalculateSize(int size)
		{
			size--;
			size |= size >> 1;
			size |= size >> 2;
			size |= size >> 4;
			size |= size >> 8;
			size |= size >> 16;
			size++;
			if (size < 8)
			{
				size = 8;
			}
			return size;
		}

		private static int GetQueueIndex(int size)
		{
			switch (size)
			{
			case 8:
				return 0;
			case 16:
				return 1;
			case 32:
				return 2;
			case 64:
				return 3;
			case 128:
				return 4;
			case 256:
				return 5;
			case 512:
				return 6;
			case 1024:
				return 7;
			case 2048:
				return 8;
			case 4096:
				return 9;
			case 8192:
				return 10;
			case 16384:
				return 11;
			case 32768:
				return 12;
			case 65536:
				return 13;
			case 131072:
				return 14;
			case 262144:
				return 15;
			case 524288:
				return 16;
			case 1048576:
				return 17;
			default:
				return -1;
			}
		}
	}
}
