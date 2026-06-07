using System;
using System.Collections;

namespace FuryStudios.FurySDK
{
	public interface IAsyncRequest : IEnumerator
	{
		AsyncRequestState State { get; }

		Exception Error { get; }

		event Action OnComplete;
	}
	public interface IAsyncRequest<R> : IAsyncRequest, IEnumerator
	{
		R Result { get; }
	}
}
