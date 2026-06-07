using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class DefaultSignatureAlgorithmIdentifierFinder
	{
		private static readonly IDictionary algorithms;

		private static readonly ISet noParams;

		private static readonly IDictionary _params;

		private static readonly ISet pkcs15RsaEncryption;

		private static readonly IDictionary digestOids;

		private static readonly IDictionary digestBuilders;

		private static readonly DerObjectIdentifier ENCRYPTION_RSA;

		private static readonly DerObjectIdentifier ENCRYPTION_DSA;

		private static readonly DerObjectIdentifier ENCRYPTION_ECDSA;

		private static readonly DerObjectIdentifier ENCRYPTION_RSA_PSS;

		private static readonly DerObjectIdentifier ENCRYPTION_GOST3410;

		private static readonly DerObjectIdentifier ENCRYPTION_ECGOST3410;

		private static readonly DerObjectIdentifier ENCRYPTION_ECGOST3410_2012_256;

		private static readonly DerObjectIdentifier ENCRYPTION_ECGOST3410_2012_512;

		static DefaultSignatureAlgorithmIdentifierFinder()
		{
		}

		private static AlgorithmIdentifier Generate(string signatureAlgorithm)
		{
			return null;
		}

		private static RsassaPssParameters CreatePssParams(AlgorithmIdentifier hashAlgId, int saltSize)
		{
			return null;
		}

		public AlgorithmIdentifier Find(string sigAlgName)
		{
			return null;
		}
	}
}
