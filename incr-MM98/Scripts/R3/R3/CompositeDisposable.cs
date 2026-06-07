using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace R3
{
	public sealed class CompositeDisposable : ICollection<IDisposable>, IEnumerable<IDisposable>, IEnumerable, IDisposable
	{
		private List<IDisposable?> list;

		private readonly object gate = new object();

		private bool isDisposed;

		private int count;

		private const int ShrinkThreshold = 64;

		public bool IsDisposed => Volatile.Read(ref isDisposed);

		public int Count
		{
			get
			{
				lock (gate)
				{
					return count;
				}
			}
		}

		public bool IsReadOnly => false;

		public CompositeDisposable()
		{
			list = new List<IDisposable>();
		}

		public CompositeDisposable(int capacity)
		{
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			list = new List<IDisposable>(capacity);
		}

		public CompositeDisposable(params IDisposable[] disposables)
		{
			list = new List<IDisposable>(disposables);
			count = list.Count;
		}

		public CompositeDisposable(IEnumerable<IDisposable> disposables)
		{
			list = new List<IDisposable>(disposables);
			count = list.Count;
		}

		public void Add(IDisposable item)
		{
			lock (gate)
			{
				if (!isDisposed)
				{
					count++;
					list.Add(item);
					return;
				}
			}
			item.Dispose();
		}

		public bool Remove(IDisposable item)
		{
			lock (gate)
			{
				if (isDisposed)
				{
					return false;
				}
				List<IDisposable> list = this.list;
				int num = list.IndexOf(item);
				if (num == -1)
				{
					return false;
				}
				list[num] = null;
				if (list.Capacity > 64 && count < list.Capacity / 2)
				{
					List<IDisposable> list2 = new List<IDisposable>(list.Capacity / 2);
					foreach (IDisposable item2 in list)
					{
						if (item2 != null)
						{
							list2.Add(item2);
						}
					}
					this.list = list2;
				}
				count--;
			}
			item.Dispose();
			return true;
		}

		public void Clear()
		{
			IDisposable[] array;
			int length;
			lock (gate)
			{
				if (isDisposed || count == 0)
				{
					return;
				}
				array = ArrayPool<IDisposable>.Shared.Rent(list.Count);
				length = list.Count;
				list.CopyTo(array);
				list.Clear();
				count = 0;
			}
			try
			{
				Span<IDisposable> span = array.AsSpan(0, length);
				for (int i = 0; i < span.Length; i++)
				{
					span[i]?.Dispose();
				}
			}
			finally
			{
				ArrayPool<IDisposable>.Shared.Return(array, clearArray: true);
			}
		}

		public bool Contains(IDisposable item)
		{
			lock (gate)
			{
				if (isDisposed)
				{
					return false;
				}
				return list.Contains(item);
			}
		}

		public void CopyTo(IDisposable[] array, int arrayIndex)
		{
			if (arrayIndex < 0 || arrayIndex >= array.Length)
			{
				throw new ArgumentOutOfRangeException("arrayIndex");
			}
			lock (gate)
			{
				if (isDisposed)
				{
					return;
				}
				if (arrayIndex + count > array.Length)
				{
					throw new ArgumentOutOfRangeException("arrayIndex");
				}
				int num = 0;
				Span<IDisposable> span = CollectionsMarshal.AsSpan(list);
				for (int i = 0; i < span.Length; i++)
				{
					IDisposable disposable = span[i];
					if (disposable != null)
					{
						array[arrayIndex + num++] = disposable;
					}
				}
			}
		}

		public void Dispose()
		{
			List<IDisposable> list;
			lock (gate)
			{
				if (isDisposed)
				{
					return;
				}
				count = 0;
				isDisposed = true;
				list = this.list;
				this.list = null;
			}
			foreach (IDisposable item in list)
			{
				item?.Dispose();
			}
			list.Clear();
		}

		public IEnumerator<IDisposable> GetEnumerator()
		{
			lock (gate)
			{
				return EnumerateAndClear(list.ToArray()).GetEnumerator();
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			lock (gate)
			{
				return EnumerateAndClear(list.ToArray()).GetEnumerator();
			}
		}

		private static IEnumerable<IDisposable> EnumerateAndClear(IDisposable?[] disposables)
		{
			try
			{
				foreach (IDisposable disposable in disposables)
				{
					if (disposable != null)
					{
						yield return disposable;
					}
				}
			}
			finally
			{
				disposables.AsSpan().Clear();
			}
		}
	}
}
