using System;

namespace R3.Internal
{
	internal struct ListDisposableCore : IDisposable
	{
		private IDisposable?[] disposables;

		private int count;

		private object gate;

		public ListDisposableCore(int initialCount, object gate)
		{
			count = 0;
			disposables = new IDisposable[initialCount];
			this.gate = gate;
		}

		public void Add(IDisposable disposable)
		{
			lock (gate)
			{
				if (disposables.Length == count)
				{
					Array.Resize(ref disposables, count * 2);
				}
				disposables[count++] = disposable;
			}
		}

		public void RemoveAt(int index)
		{
			lock (gate)
			{
				if (index >= 0 && index < count)
				{
					ref IDisposable reference = ref disposables[index];
					if (reference != null)
					{
						reference.Dispose();
					}
					reference = null;
				}
			}
		}

		public void RemoveAllExceptAt(int index)
		{
			lock (gate)
			{
				if (index < 0 || index >= count)
				{
					return;
				}
				for (int i = 0; i < count; i++)
				{
					if (i != index)
					{
						ref IDisposable reference = ref disposables[i];
						if (reference != null)
						{
							reference.Dispose();
						}
						reference = null;
					}
				}
			}
		}

		public void Dispose()
		{
			lock (gate)
			{
				for (int i = 0; i < count; i++)
				{
					disposables[i]?.Dispose();
					disposables[i] = null;
				}
				count = 0;
			}
		}
	}
}
