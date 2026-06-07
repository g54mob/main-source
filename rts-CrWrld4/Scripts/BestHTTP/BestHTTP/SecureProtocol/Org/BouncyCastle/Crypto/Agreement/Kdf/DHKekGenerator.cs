using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement.Kdf
{
	public class DHKekGenerator : IDerivationFunction
	{
		private readonly IDigest digest;

		private DerObjectIdentifier algorithm;

		private int keySize;

		private byte[] z;

		private byte[] partyAInfo;

		public virtual IDigest Digest => null;

		public DHKekGenerator(IDigest digest)
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
