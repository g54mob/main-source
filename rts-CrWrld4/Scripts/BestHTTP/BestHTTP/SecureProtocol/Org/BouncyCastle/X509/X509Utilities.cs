using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.X509
{
	internal class X509Utilities
	{
		private static readonly IDictionary algorithms;

		private static readonly IDictionary exParams;

		private static readonly ISet noParams;

		static X509Utilities()
		{
		}

		private static RsassaPssParameters CreatePssParams(AlgorithmIdentifier hashAlgId, int saltSize)
		{
			return null;
		}

		internal static DerObjectIdentifier GetAlgorithmOid(string algorithmName)
		{
			return null;
		}

		internal static AlgorithmIdentifier GetSigAlgID(DerObjectIdentifier sigOid, string algorithmName)
		{
			return null;
		}

		internal static IEnumerable GetAlgNames()
		{
			return null;
		}

		internal static byte[] GetSignatureForObject(DerObjectIdentifier sigOid, string sigName, AsymmetricKeyParameter privateKey, SecureRandom random, Asn1Encodable ae)
		{
			return null;
		}
	}
}
