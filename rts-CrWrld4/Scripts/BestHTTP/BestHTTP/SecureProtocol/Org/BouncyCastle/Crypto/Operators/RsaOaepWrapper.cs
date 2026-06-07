using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Operators
{
	internal class RsaOaepWrapper : IKeyWrapper, IKeyUnwrapper
	{
		private readonly AlgorithmIdentifier algId;

		private readonly IAsymmetricBlockCipher engine;

		public object AlgorithmDetails => null;

		public RsaOaepWrapper(bool forWrapping, ICipherParameters parameters, DerObjectIdentifier digestOid)
		{
		}

		public IBlockResult Unwrap(byte[] cipherText, int offset, int length)
		{
			return null;
		}

		public IBlockResult Wrap(byte[] keyData)
		{
			return null;
		}
	}
}
