using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509
{
	internal class X509SignatureUtilities
	{
		private static readonly Asn1Null derNull;

		internal static void SetSignatureParameters(ISigner signature, Asn1Encodable parameters)
		{
		}

		internal static string GetSignatureName(AlgorithmIdentifier sigAlgId)
		{
			return null;
		}

		private static string GetDigestAlgName(DerObjectIdentifier digestAlgOID)
		{
			return null;
		}
	}
}
