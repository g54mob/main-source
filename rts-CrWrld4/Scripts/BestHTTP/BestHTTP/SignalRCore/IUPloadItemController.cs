using System;

namespace BestHTTP.SignalRCore
{
	public interface IUPloadItemController<TResult> : IDisposable
	{
		string[] StreamingIDs { get; }

		HubConnection Hub { get; }

		void UploadParam<T>(string streamId, T item);

		void Cancel();
	}
}
