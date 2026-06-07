namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cmp
{
	public class PkiFreeText : Asn1Encodable
	{
		internal Asn1Sequence strings;

		public int Size => 0;

		public int Count => 0;

		public DerUtf8String Item => null;

		public static PkiFreeText GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		public static PkiFreeText GetInstance(object obj)
		{
			return null;
		}

		public PkiFreeText(Asn1Sequence seq)
		{
		}

		public PkiFreeText(DerUtf8String p)
		{
		}

		public DerUtf8String GetStringAt(int index)
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
