namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class DisplayText : Asn1Encodable, IAsn1Choice
	{
		public const int ContentTypeIA5String = 0;

		public const int ContentTypeBmpString = 1;

		public const int ContentTypeUtf8String = 2;

		public const int ContentTypeVisibleString = 3;

		public const int DisplayTextMaximumSize = 200;

		internal readonly int contentType;

		internal readonly IAsn1String contents;

		public DisplayText(int type, string text)
		{
		}

		public DisplayText(string text)
		{
		}

		public DisplayText(IAsn1String contents)
		{
		}

		public static DisplayText GetInstance(object obj)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}

		public string GetString()
		{
			return null;
		}
	}
}
