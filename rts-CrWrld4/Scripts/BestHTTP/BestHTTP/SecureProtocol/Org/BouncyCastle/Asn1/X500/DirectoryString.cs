namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X500
{
	public class DirectoryString : Asn1Encodable, IAsn1Choice, IAsn1String
	{
		private readonly DerStringBase str;

		public static DirectoryString GetInstance(object obj)
		{
			return null;
		}

		public static DirectoryString GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		private DirectoryString(DerStringBase str)
		{
		}

		public DirectoryString(string str)
		{
		}

		public string GetString()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
