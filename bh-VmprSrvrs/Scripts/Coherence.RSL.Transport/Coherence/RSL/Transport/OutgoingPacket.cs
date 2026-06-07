using System.Net;
using Coherence.Brook.Octet;
using Coherence.Transport;

namespace Coherence.RSL.Transport
{
	public struct OutgoingPacket
	{
		public OutOctetStream Stream;

		public SessionID SessionId;

		public IPEndPoint Endpoint;
	}
}
