using System;

namespace Coherence.Connection
{
	[Serializable]
	public struct EndpointData
	{
		public enum SimulatorType
		{
			world = 0,
			room = 1
		}

		public const string LocalRegion = "local";

		public string host;

		public int port;

		public string authToken;

		public string runtimeKey;

		public ushort roomId;

		public ulong uniqueRoomId;

		public ulong worldId;

		public string region;

		public string schemaId;

		public string simulatorType;

		public string roomSecret;

		public string rsVersion;

		public bool customLocalToken;

		public string GetHostAndPort()
		{
			return null;
		}

		public (bool, string) Validate(bool ignoreIpAddressValidation = true)
		{
			return default((bool, string));
		}

		public override string ToString()
		{
			return null;
		}

		public string WorldIdString()
		{
			return null;
		}

		public static bool TryParse(string value, out EndpointData endpointData)
		{
			endpointData = default(EndpointData);
			return false;
		}

		private static bool TryGetHostAndPort(string value, out string host, out int port, out ushort roomId)
		{
			host = null;
			port = default(int);
			roomId = default(ushort);
			return false;
		}

		private static bool ExtractParameter(string source, string parameter, out string value)
		{
			value = null;
			return false;
		}

		private static bool IsValidIpAddress(string value)
		{
			return false;
		}

		private static string[] GetAllLocalIPAddresses()
		{
			return null;
		}

		private static bool IsValidDomain(string value)
		{
			return false;
		}
	}
}
