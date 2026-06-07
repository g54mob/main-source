using Coherence.Connection;

namespace Coherence.Core
{
	public struct InteropClientID
	{
		public uint Id;

		public InteropClientID(ClientID clientID)
		{
			Id = 0u;
		}

		public ClientID Into()
		{
			return default(ClientID);
		}
	}
}
