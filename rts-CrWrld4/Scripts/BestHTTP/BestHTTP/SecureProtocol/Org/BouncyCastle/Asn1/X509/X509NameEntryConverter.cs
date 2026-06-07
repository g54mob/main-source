namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509
{
	public abstract class X509NameEntryConverter
	{
		protected Asn1Object ConvertHexEncoded(string hexString, int offset)
		{
			return null;
		}

		protected bool CanBePrintable(string str)
		{
			return false;
		}

		public abstract Asn1Object GetConvertedValue(DerObjectIdentifier oid, string value);
	}
}
