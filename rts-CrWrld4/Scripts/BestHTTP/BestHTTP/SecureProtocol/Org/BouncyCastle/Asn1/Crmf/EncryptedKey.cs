using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Cms;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Crmf
{
	public class EncryptedKey : Asn1Encodable, IAsn1Choice
	{
		private readonly EnvelopedData envelopedData;

		private readonly EncryptedValue encryptedValue;

		public virtual bool IsEncryptedValue => false;

		public virtual Asn1Encodable Value => null;

		public static EncryptedKey GetInstance(object o)
		{
			return null;
		}

		public EncryptedKey(EnvelopedData envelopedData)
		{
		}

		public EncryptedKey(EncryptedValue encryptedValue)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
