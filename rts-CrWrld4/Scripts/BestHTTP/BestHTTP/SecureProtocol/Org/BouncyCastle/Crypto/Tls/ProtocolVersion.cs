namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public sealed class ProtocolVersion
	{
		public static readonly ProtocolVersion SSLv3;

		public static readonly ProtocolVersion TLSv10;

		public static readonly ProtocolVersion TLSv11;

		public static readonly ProtocolVersion TLSv12;

		public static readonly ProtocolVersion DTLSv10;

		public static readonly ProtocolVersion DTLSv12;

		private readonly int version;

		private readonly string name;

		public int FullVersion => 0;

		public int MajorVersion => 0;

		public int MinorVersion => 0;

		public bool IsDtls => false;

		public bool IsSsl => false;

		public bool IsTls => false;

		private ProtocolVersion(int v, string name)
		{
		}

		public ProtocolVersion GetEquivalentTLSVersion()
		{
			return null;
		}

		public bool IsEqualOrEarlierVersionOf(ProtocolVersion version)
		{
			return false;
		}

		public bool IsLaterVersionOf(ProtocolVersion version)
		{
			return false;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public bool Equals(ProtocolVersion other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static ProtocolVersion Get(int major, int minor)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		private static ProtocolVersion GetUnknownVersion(int major, int minor, string prefix)
		{
			return null;
		}
	}
}
