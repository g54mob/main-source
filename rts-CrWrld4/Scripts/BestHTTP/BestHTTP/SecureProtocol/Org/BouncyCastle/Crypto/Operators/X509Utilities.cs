using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Operators
{
	internal class X509Utilities
	{
		private static readonly Asn1Null derNull;

		private static readonly IDictionary algorithms;

		private static readonly IDictionary exParams;

		private static readonly ISet noParams;

		static X509Utilities()
		{
		}

		private static string GetDigestAlgName(DerObjectIdentifier digestAlgOID)
		{
			return null;
		}

		internal static string GetSignatureName(AlgorithmIdentifier sigAlgId)
		{
			return null;
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
	}
}
