using System;

namespace R3
{
	public struct DisposableBag : IDisposable
	{
		private IDisposable[]? items;

		private bool isDisposed;

		private int count;

		public DisposableBag(int capacity)
		{
			isDisposed = false;
			count = 0;
			items = new IDisposable[capacity];
		}

		public void Add(IDisposable item)
		{
			if (isDisposed)
			{
				item.Dispose();
				return;
			}
			if (items == null)
			{
				items = new IDisposable[4];
			}
			else if (count == items.Length)
			{
				Array.Resize(ref items, count * 2);
			}
			items[count++] = item;
		}

		public void Clear()
		{
			if (items != null)
			{
				for (int i = 0; i < count; i++)
				{
					items[i]?.Dispose();
				}
				items = null;
				count = 0;
			}
		}

		public void Dispose()
		{
			Clear();
			isDisposed = true;
		}
	}
}
