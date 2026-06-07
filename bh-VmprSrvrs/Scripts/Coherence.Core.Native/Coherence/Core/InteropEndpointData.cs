using Coherence.Connection;

namespace Coherence.Core
{
	public struct InteropEndpointData
	{
		public const int HostMaxLength = 128;

		public const int AuthTokenMaxLength = 512;

		public const int RuntimeKeyMaxLength = 128;

		public const int RegionMaxLength = 32;

		public const int SchemaIdMaxLength = 128;

		public const int SimulatorTypeMaxLength = 32;

		public const int RoomSecretMaxLength = 128;

		public const int RsVersionMaxLength = 32;

		public string Host;

		public uint Port;

		public string AuthToken;

		public string RuntimeKey;

		public uint RoomId;

		public ulong UniqueRoomId;

		public ulong WorldId;

		public string Region;

		public string SchemaId;

		public string SimulatorType;

		public string RoomSecret;

		public string RSVersion;

		public byte CustomLocalToken;

		public override string ToString()
		{
			return null;
		}

		public InteropEndpointData(EndpointData data)
		{
			Host = null;
			Port = 0u;
			AuthToken = null;
			RuntimeKey = null;
			RoomId = 0u;
			UniqueRoomId = 0uL;
			WorldId = 0uL;
			Region = null;
			SchemaId = null;
			SimulatorType = null;
			RoomSecret = null;
			RSVersion = null;
			CustomLocalToken = 0;
		}

		public EndpointData Into()
		{
			return default(EndpointData);
		}
	}
}
