using System;

namespace Coherence.Transport.Web
{
	public struct WebCallbacks
	{
		public Action OnOpen;

		public Action<byte[]> OnPacket;

		public Action<JsError> OnError;
	}
}
