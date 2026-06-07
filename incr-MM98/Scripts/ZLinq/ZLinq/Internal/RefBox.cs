using System;

namespace ZLinq.Internal
{
	internal sealed class RefBox<T> : IDisposable where T : struct, IDisposable
	{
		private T value;

		private bool isDisposed;

		public RefBox(T value)
		{
			this.value = value;
		}

		public ref T GetValueRef()
		{
			return ref value;
		}

		public void Dispose()
		{
			if (!isDisposed)
			{
				isDisposed = true;
				value.Dispose();
			}
		}
	}
}
