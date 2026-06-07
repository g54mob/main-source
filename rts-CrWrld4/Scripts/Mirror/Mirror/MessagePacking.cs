using System;

namespace Mirror
{
	public static class MessagePacking
	{
		internal const int HeaderSize = 2;

		public static int GetId<T>() where T : struct, NetworkMessage
		{
			return 0;
		}

		public static void Pack<T>(T message, NetworkWriter writer) where T : struct, NetworkMessage
		{
		}

		public static bool Unpack(NetworkReader messageReader, out int msgType)
		{
			msgType = default(int);
			return false;
		}

		[Obsolete]
		public static bool UnpackMessage(NetworkReader messageReader, out int msgType)
		{
			msgType = default(int);
			return false;
		}

		internal static NetworkMessageDelegate WrapHandler<T, C>(Action<C, T> handler, bool requireAuthentication) where T : struct, NetworkMessage where C : NetworkConnection
		{
			return null;
		}
	}
}
