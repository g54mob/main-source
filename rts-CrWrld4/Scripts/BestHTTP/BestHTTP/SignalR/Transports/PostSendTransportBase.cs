using System.Collections.Generic;

namespace BestHTTP.SignalR.Transports
{
	public abstract class PostSendTransportBase : TransportBase
	{
		protected List<HTTPRequest> sendRequestQueue;

		public PostSendTransportBase(string name, Connection con)
			: base(null, null)
		{
		}

		protected override void SendImpl(string json)
		{
		}

		private void OnSendRequestFinished(HTTPRequest req, HTTPResponse resp)
		{
		}
	}
}
