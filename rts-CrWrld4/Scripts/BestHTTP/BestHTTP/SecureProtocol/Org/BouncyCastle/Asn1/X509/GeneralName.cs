namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class GeneralName : Asn1Encodable, IAsn1Choice
	{
		public const int OtherName = 0;

		public const int Rfc822Name = 1;

		public const int DnsName = 2;

		public const int X400Address = 3;

		public const int DirectoryName = 4;

		public const int EdiPartyName = 5;

		public const int UniformResourceIdentifier = 6;

		public const int IPAddress = 7;

		public const int RegisteredID = 8;

		internal readonly Asn1Encodable obj;

		internal readonly int tag;

		public int TagNo => 0;

		public Asn1Encodable Name => null;

		public GeneralName(X509Name directoryName)
		{
		}

		public GeneralName(Asn1Object name, int tag)
		{
		}

		public GeneralName(int tag, Asn1Encodable name)
		{
		}

		public GeneralName(int tag, string name)
		{
		}

		public static GeneralName GetInstance(object obj)
		{
			return null;
		}

		public static GeneralName GetInstance(Asn1TaggedObject tagObj, bool explicitly)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		private byte[] toGeneralNameEncoding(string ip)
		{
			return null;
		}

		private void parseIPv4Mask(string mask, byte[] addr, int offset)
		{
		}

		private void parseIPv4(string ip, byte[] addr, int offset)
		{
		}

		private int[] parseMask(string mask)
		{
			return null;
		}

		private void copyInts(int[] parsedIp, byte[] addr, int offSet)
		{
		}

		private int[] parseIPv6(string ip)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
