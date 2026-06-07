namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public class IetfAttrSyntax : Asn1Encodable
	{
		public const int ValueOctets = 1;

		public const int ValueOid = 2;

		public const int ValueUtf8 = 3;

		internal readonly GeneralNames policyAuthority;

		internal readonly Asn1EncodableVector values;

		internal int valueChoice;

		public GeneralNames PolicyAuthority => null;

		public int ValueType => 0;

		public IetfAttrSyntax(Asn1Sequence seq)
		{
		}

		public object[] GetValues()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
