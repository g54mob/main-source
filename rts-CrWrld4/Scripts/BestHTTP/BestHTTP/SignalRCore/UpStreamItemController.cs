using System;
using BestHTTP.Futures;

namespace BestHTTP.SignalRCore
{
	public sealed class UpStreamItemController<TResult> : IUPloadItemController<TResult>, IDisposable, IFuture<TResult>
	{
		public readonly long invocationId;

		public readonly string[] streamingIds;

		public readonly HubConnection hubConnection;

		public readonly IFuture<TResult> future;

		private object[] streams;

		public string[] StreamingIDs => null;

		public HubConnection Hub => null;

		public FutureState state => default(FutureState);

		public TResult value => default(TResult);

		public Exception error => null;

		public bool IsFinished { get; private set; }

		public bool IsCanceled { get; private set; }

		public UpStreamItemController(HubConnection hub, long iId, string[] sIds, IFuture<TResult> future)
		{
		}

		public UploadChannel<TResult, T> GetUploadChannel<T>(int paramIdx)
		{
			return null;
		}

		public void UploadParam<T>(string streamId, T item)
		{
		}

		public void Finish()
		{
		}

		public void Cancel()
		{
		}

		void IDisposable.Dispose()
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
