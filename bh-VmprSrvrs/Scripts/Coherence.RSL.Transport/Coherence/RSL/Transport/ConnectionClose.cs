using System;
using System.Net;

namespace Coherence.RSL.Transport
{
	public class ConnectionClose
	{
		public IPAddress Address;

		public ITransportConnection Connection;

		public Action Execute;
	}
}
