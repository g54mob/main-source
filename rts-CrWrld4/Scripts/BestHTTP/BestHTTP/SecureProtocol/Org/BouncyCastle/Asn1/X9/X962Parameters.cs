namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9
{
	public class X962Parameters : Asn1Encodable, IAsn1Choice
	{
		private readonly Asn1Object _params;

		public bool IsNamedCurve => false;

		public bool IsImplicitlyCA => false;

		public Asn1Object Parameters => null;

		public static X962Parameters GetInstance(object obj)
		{
			return null;
		}

		public X962Parameters(X9ECParameters ecParameters)
		{
		}

		public X962Parameters(DerObjectIdentifier namedCurve)
		{
		}

		public X962Parameters(Asn1Null obj)
		{
		}

		public X962Parameters(Asn1Object obj)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
