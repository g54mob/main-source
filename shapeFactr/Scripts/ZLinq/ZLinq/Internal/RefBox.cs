using System;

namespace ZLinq.Internal
{
	internal sealed class RefBox<T> : IDisposable where T : struct, IDisposable
	{
		private T value;

		private bool isDisposed;

		public RefBox(T value)
		{
		}

		public ref T GetValueRef()
		{
			throw null;
		}

		public void Dispose()
		{
		}
	}
}
