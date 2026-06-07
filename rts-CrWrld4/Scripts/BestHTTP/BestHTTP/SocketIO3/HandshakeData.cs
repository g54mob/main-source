using System.Collections.Generic;

namespace BestHTTP.SocketIO3
{
	public sealed class HandshakeData
	{
		public string Sid { get; private set; }

		public List<string> Upgrades { get; private set; }

		public int PingInterval { get; private set; }

		public int PingTimeout { get; private set; }
	}
}
