using MLAPI.Security;

namespace MLAPI.Connection
{
	public class PendingClient
	{
		public enum State
		{
			PendingHail = 0,
			PendingConnection = 1
		}

		public ulong ClientId;

		internal EllipticDiffieHellman KeyExchange;

		public byte[] AesKey;

		public State ConnectionState;
	}
}
