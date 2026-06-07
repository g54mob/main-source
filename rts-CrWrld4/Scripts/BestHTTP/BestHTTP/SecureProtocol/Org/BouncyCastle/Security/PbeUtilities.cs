using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Security
{
	public sealed class PbeUtilities
	{
		private const string Pkcs5S1 = "Pkcs5S1";

		private const string Pkcs5S2 = "Pkcs5S2";

		private const string Pkcs12 = "Pkcs12";

		private const string OpenSsl = "OpenSsl";

		private static readonly IDictionary algorithms;

		private static readonly IDictionary algorithmType;

		private static readonly IDictionary oids;

		public static ICollection Algorithms => null;

		private PbeUtilities()
		{
		}

		static PbeUtilities()
		{
		}

		private static PbeParametersGenerator MakePbeGenerator(string type, IDigest digest, byte[] key, byte[] salt, int iterationCount)
		{
			return null;
		}

		public static DerObjectIdentifier GetObjectIdentifier(string mechanism)
		{
			return null;
		}

		public static bool IsPkcs12(string algorithm)
		{
			return false;
		}

		public static bool IsPkcs5Scheme1(string algorithm)
		{
			return false;
		}

		public static bool IsPkcs5Scheme2(string algorithm)
		{
			return false;
		}

		public static bool IsOpenSsl(string algorithm)
		{
			return false;
		}

		public static bool IsPbeAlgorithm(string algorithm)
		{
			return false;
		}

		public static Asn1Encodable GenerateAlgorithmParameters(DerObjectIdentifier algorithmOid, byte[] salt, int iterationCount)
		{
			return null;
		}

		public static Asn1Encodable GenerateAlgorithmParameters(string algorithm, byte[] salt, int iterationCount)
		{
			return null;
		}

		public static Asn1Encodable GenerateAlgorithmParameters(DerObjectIdentifier cipherAlgorithm, DerObjectIdentifier hashAlgorithm, byte[] salt, int iterationCount, SecureRandom secureRandom)
		{
			return null;
		}

		public static ICipherParameters GenerateCipherParameters(DerObjectIdentifier algorithmOid, char[] password, Asn1Encodable pbeParameters)
		{
			return null;
		}

		public static ICipherParameters GenerateCipherParameters(DerObjectIdentifier algorithmOid, char[] password, bool wrongPkcs12Zero, Asn1Encodable pbeParameters)
		{
			return null;
		}

		public static ICipherParameters GenerateCipherParameters(AlgorithmIdentifier algID, char[] password)
		{
			return null;
		}

		public static ICipherParameters GenerateCipherParameters(AlgorithmIdentifier algID, char[] password, bool wrongPkcs12Zero)
		{
			return null;
		}

		public static ICipherParameters GenerateCipherParameters(string algorithm, char[] password, Asn1Encodable pbeParameters)
		{
			return null;
		}

		public static ICipherParameters GenerateCipherParameters(string algorithm, char[] password, bool wrongPkcs12Zero, Asn1Encodable pbeParameters)
		{
			return null;
		}

		public static object CreateEngine(DerObjectIdentifier algorithmOid)
		{
			return null;
		}

		public static object CreateEngine(AlgorithmIdentifier algID)
		{
			return null;
		}

		public static object CreateEngine(string algorithm)
		{
			return null;
		}

		public static string GetEncodingName(DerObjectIdentifier oid)
		{
			return null;
		}

		private static ICipherParameters FixDesParity(string mechanism, ICipherParameters parameters)
		{
			return null;
		}
	}
}
