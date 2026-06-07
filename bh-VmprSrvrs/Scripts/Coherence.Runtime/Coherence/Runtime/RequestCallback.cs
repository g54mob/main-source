using System;

namespace Coherence.Runtime
{
	public struct RequestCallback
	{
		public OnRequest onRequest;

		public DateTime maxTime;

		public string requestId;

		internal RequestMeta meta;
	}
}
