using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class DefaultDigestAlgorithmIdentifierFinder
	{
		private static readonly IDictionary digestOids;

		private static readonly IDictionary digestNameToOids;

		static DefaultDigestAlgorithmIdentifierFinder()
		{
		}

		public AlgorithmIdentifier find(AlgorithmIdentifier sigAlgId)
		{
			return null;
		}

		public AlgorithmIdentifier find(string digAlgName)
		{
			return null;
		}
	}
}
