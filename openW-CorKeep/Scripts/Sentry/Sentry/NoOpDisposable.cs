using System;

namespace Sentry
{
	internal class NoOpDisposable : IDisposable
	{
		private static readonly Lazy<NoOpDisposable> LazyInstance = new Lazy<NoOpDisposable>();

		internal static NoOpDisposable Instance => LazyInstance.Value;

		public void Dispose()
		{
		}
	}
}
