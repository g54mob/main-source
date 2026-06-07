using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crmf
{
	public interface IPKMacPrimitivesProvider
	{
		IDigest CreateDigest(AlgorithmIdentifier digestAlg);

		IMac CreateMac(AlgorithmIdentifier macAlg);
	}
}
