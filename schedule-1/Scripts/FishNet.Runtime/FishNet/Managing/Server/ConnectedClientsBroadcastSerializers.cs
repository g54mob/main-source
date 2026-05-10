using FishNet.Serializing;

namespace FishNet.Managing.Server
{
	internal static class ConnectedClientsBroadcastSerializers
	{
		public static void WriteConnectedClientsBroadcast(this PooledWriter writer, ConnectedClientsBroadcast value)
		{
		}

		public static ConnectedClientsBroadcast ReadConnectedClientsBroadcast(this PooledReader reader)
		{
			return default(ConnectedClientsBroadcast);
		}
	}
}
