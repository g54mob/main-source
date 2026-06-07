using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Security
{
	public sealed class ParameterUtilities
	{
		private static readonly IDictionary algorithms;

		private static readonly IDictionary basicIVSizes;

		private ParameterUtilities()
		{
		}

		static ParameterUtilities()
		{
		}

		private static void AddAlgorithm(string canonicalName, params object[] aliases)
		{
		}

		private static void AddBasicIVSizeEntries(int size, params string[] algorithms)
		{
		}

		public static string GetCanonicalAlgorithmName(string algorithm)
		{
			return null;
		}

		public static KeyParameter CreateKeyParameter(DerObjectIdentifier algOid, byte[] keyBytes)
		{
			return null;
		}

		public static KeyParameter CreateKeyParameter(string algorithm, byte[] keyBytes)
		{
			return null;
		}

		public static KeyParameter CreateKeyParameter(DerObjectIdentifier algOid, byte[] keyBytes, int offset, int length)
		{
			return null;
		}

		public static KeyParameter CreateKeyParameter(string algorithm, byte[] keyBytes, int offset, int length)
		{
			return null;
		}

		public static ICipherParameters GetCipherParameters(DerObjectIdentifier algOid, ICipherParameters key, Asn1Object asn1Params)
		{
			return null;
		}

		public static ICipherParameters GetCipherParameters(string algorithm, ICipherParameters key, Asn1Object asn1Params)
		{
			return null;
		}

		public static Asn1Encodable GenerateParameters(DerObjectIdentifier algID, SecureRandom random)
		{
			return null;
		}

		public static Asn1Encodable GenerateParameters(string algorithm, SecureRandom random)
		{
			return null;
		}

		public static ICipherParameters WithRandom(ICipherParameters cp, SecureRandom random)
		{
			return null;
		}

		private static Asn1OctetString CreateIVOctetString(SecureRandom random, int ivLength)
		{
			return null;
		}

		private static byte[] CreateIV(SecureRandom random, int ivLength)
		{
			return null;
		}

		private static int FindBasicIVSize(string canonicalName)
		{
			return 0;
		}
	}
}
