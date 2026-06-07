using Coherence.Brook;

namespace Coherence.Brisk.Models
{
	public struct ConnectInfo
	{
		public uint ProtocolVersion { get; }

		public string AuthToken { get; }

		public ulong RoomUid { get; }

		public string SchemaId { get; }

		public string RoomSecret { get; private set; }

		public bool IsSimulator { get; }

		public uint Scene { get; }

		public string RSVersion { get; }

		public ushort MTU { get; }

		public ConnectInfo(uint protocolVersion, ulong roomUid, string schemaId, string authToken, string roomSecret, bool isSimulator, uint scene, string rsVersion, ushort mtu)
		{
			ProtocolVersion = 0u;
			AuthToken = null;
			RoomUid = 0uL;
			SchemaId = null;
			RoomSecret = null;
			IsSimulator = false;
			Scene = 0u;
			RSVersion = null;
			MTU = 0;
		}

		private void ValidateRoomSecretLength()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public void Serialize(IOutOctetStream stream)
		{
		}

		public static ConnectInfo Deserialize(IInOctetStream stream)
		{
			return default(ConnectInfo);
		}

		private static string ReadShortRleString(IInOctetStream stream)
		{
			return null;
		}

		private static void WriteShortRleString(IOutOctetStream stream, string str)
		{
		}

		private static string ReadByteRleString(IInOctetStream stream)
		{
			return null;
		}

		private static void WriteByteRleString(IOutOctetStream stream, string str)
		{
		}

		private static bool ReadBool(IInOctetStream stream)
		{
			return false;
		}

		private static void WriteBool(IOutOctetStream stream, bool value)
		{
		}
	}
}
