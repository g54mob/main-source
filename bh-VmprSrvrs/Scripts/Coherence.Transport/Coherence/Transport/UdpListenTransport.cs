using System.Net;
using Coherence.Brook;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Stats;

namespace Coherence.Transport
{
	public class UdpListenTransport : UdpTransport, IListenTransport, ITransport
	{
		public UdpListenTransport(IStats stats, Logger logger, IDateTimeProvider dateTimeProvider = null)
			: base(null, null)
		{
		}

		public void Listen(EndpointData endpoint, ConnectionSettings settings)
		{
		}

		public void SendTo(IOutOctetStream stream, IPEndPoint endpoint, SessionID toSession)
		{
		}

		private void WriteHeaderWithSpaceForRoomID(IOutOctetStream stream, SessionID toSession)
		{
		}

		protected override void CheckForTimeout(bool anyValidPacketReceived)
		{
		}

		protected override bool HandleSessionID(IInOctetStream stream)
		{
			return false;
		}
	}
}
