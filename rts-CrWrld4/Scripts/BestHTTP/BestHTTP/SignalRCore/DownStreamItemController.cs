using System;
using BestHTTP.Futures;

namespace BestHTTP.SignalRCore
{
	public sealed class DownStreamItemController<TResult> : IFuture<TResult>, IDisposable
	{
		public readonly long invocationId;

		public readonly HubConnection hubConnection;

		public readonly IFuture<TResult> future;

		public FutureState state => default(FutureState);

		public TResult value => default(TResult);

		public Exception error => null;

		public bool IsCanceled { get; private set; }

		public DownStreamItemController(HubConnection hub, long iId, IFuture<TResult> future)
		{
		}

		public void Cancel()
		{
		}

		public void Dispose()
		{
		}

		public IFuture<TResult> OnItem(FutureValueCallback<TResult> callback)
		{
			return null;
		}

		public IFuture<TResult> OnSuccess(FutureValueCallback<TResult> callback)
		{
			return null;
		}

		public IFuture<TResult> OnError(FutureErrorCallback callback)
		{
			return null;
		}

		public IFuture<TResult> OnComplete(FutureCallback<TResult> callback)
		{
			return null;
		}
	}
}
