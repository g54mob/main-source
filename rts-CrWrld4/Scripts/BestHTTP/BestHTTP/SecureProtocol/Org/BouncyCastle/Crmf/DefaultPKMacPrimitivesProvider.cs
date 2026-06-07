using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crmf
{
	public class DefaultPKMacPrimitivesProvider : IPKMacPrimitivesProvider
	{
		public IDigest CreateDigest(AlgorithmIdentifier digestAlg)
		{
			return null;
		}

		public IMac CreateMac(AlgorithmIdentifier macAlg)
		{
			return null;
		}
	}
}
