using System;

namespace MessagePipe
{
	internal class EmptyDisposable : IDisposable
	{
		internal static readonly IDisposable Instance = new EmptyDisposable();

		private EmptyDisposable()
		{
		}

		public void Dispose()
		{
		}
	}
}
