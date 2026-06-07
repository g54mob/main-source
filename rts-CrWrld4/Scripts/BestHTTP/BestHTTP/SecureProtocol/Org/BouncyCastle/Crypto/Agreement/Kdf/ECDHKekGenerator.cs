using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement.Kdf
{
	public class ECDHKekGenerator : IDerivationFunction
	{
		private readonly IDerivationFunction kdf;

		private DerObjectIdentifier algorithm;

		private int keySize;

		private byte[] z;

		public virtual IDigest Digest => null;

		public ECDHKekGenerator(IDigest digest)
		{
		}

		public virtual void Init(IDerivationParameters param)
		{
		}

		public virtual int GenerateBytes(byte[] outBytes, int outOff, int len)
		{
			return 0;
		}
	}
}
