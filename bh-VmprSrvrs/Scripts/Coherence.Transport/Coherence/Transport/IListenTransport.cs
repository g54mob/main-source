using System.Net;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Connection;

namespace Coherence.Transport
{
	public interface IListenTransport : ITransport
	{
		void Listen(EndpointData entpointData, ConnectionSettings settings);

		void SendTo(IOutOctetStream data, IPEndPoint endpoint, SessionID sessionID);
	}
}
