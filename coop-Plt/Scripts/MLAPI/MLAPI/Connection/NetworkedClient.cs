using System.Collections.Generic;

namespace MLAPI.Connection
{
	public class NetworkedClient
	{
		public ulong ClientId;

		public NetworkedObject PlayerObject;

		public readonly List<NetworkedObject> OwnedObjects = new List<NetworkedObject>();

		public byte[] AesKey;
	}
}
