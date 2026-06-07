using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Cms;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Tsp
{
	public class TspUtil
	{
		private static ISet EmptySet;

		private static IList EmptyList;

		private static readonly IDictionary digestLengths;

		private static readonly IDictionary digestNames;

		static TspUtil()
		{
		}

		public static ICollection GetSignatureTimestamps(SignerInformation signerInfo)
		{
			return null;
		}

		public static void ValidateCertificate(X509Certificate cert)
		{
		}

		internal static string GetDigestAlgName(string digestAlgOID)
		{
			return null;
		}

		internal static int GetDigestLength(string digestAlgOID)
		{
			return 0;
		}

		internal static IDigest CreateDigestInstance(string digestAlgOID)
		{
			return null;
		}

		internal static ISet GetCriticalExtensionOids(X509Extensions extensions)
		{
			return null;
		}

		internal static ISet GetNonCriticalExtensionOids(X509Extensions extensions)
		{
			return null;
		}

		internal static IList GetExtensionOids(X509Extensions extensions)
		{
			return null;
		}
	}
}
