namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class TlsECDsaSigner : TlsDsaSigner
	{
		protected override byte SignatureAlgorithm => 0;

		public override bool IsValidPublicKey(AsymmetricKeyParameter publicKey)
		{
			return false;
		}

		protected override IDsa CreateDsaImpl(byte hashAlgorithm)
		{
			return null;
		}
	}
}
