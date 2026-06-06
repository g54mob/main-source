using System;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	internal sealed class AsyncDisposableBridge : IUniTaskAsyncDisposable
	{
		private readonly IDisposable disposable;

		public AsyncDisposableBridge(IDisposable disposable)
		{
			this.disposable = disposable;
		}

		public UniTask DisposeAsync()
		{
			disposable.Dispose();
			return default(UniTask);
		}
	}
}
