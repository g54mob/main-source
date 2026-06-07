using System;

namespace Coherence.Cloud
{
	public struct RequestResponse<T>
	{
		public RequestStatus Status;

		public T Result;

		public Exception Exception;

		public static RequestResponse<T> GetRequestResponse(RequestResponse<string> response)
		{
			return default(RequestResponse<T>);
		}
	}
}
