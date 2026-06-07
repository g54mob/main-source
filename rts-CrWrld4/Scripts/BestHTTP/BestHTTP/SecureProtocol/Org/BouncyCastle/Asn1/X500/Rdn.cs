namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X500
{
	public class Rdn : Asn1Encodable
	{
		private readonly Asn1Set values;

		public virtual bool IsMultiValued => false;

		public virtual int Count => 0;

		private Rdn(Asn1Set values)
		{
		}

		public static Rdn GetInstance(object obj)
		{
			return null;
		}

		public Rdn(DerObjectIdentifier oid, Asn1Encodable value)
		{
		}

		public Rdn(AttributeTypeAndValue attrTAndV)
		{
		}

		public Rdn(AttributeTypeAndValue[] aAndVs)
		{
		}

		public virtual AttributeTypeAndValue GetFirst()
		{
			return null;
		}

		public virtual AttributeTypeAndValue[] GetTypesAndValues()
		{
			return null;
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
