using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Ocsp
{
	internal class OcspUtilities
	{
		private static readonly IDictionary algorithms;

		private static readonly IDictionary oids;

		private static readonly ISet noParams;

		internal static IEnumerable AlgNames => null;

		static OcspUtilities()
		{
		}

		internal static DerObjectIdentifier GetAlgorithmOid(string algorithmName)
		{
			return null;
		}

		internal static string GetAlgorithmName(DerObjectIdentifier oid)
		{
			return null;
		}

		internal static AlgorithmIdentifier GetSigAlgID(DerObjectIdentifier sigOid)
		{
			return null;
		}
	}
}
