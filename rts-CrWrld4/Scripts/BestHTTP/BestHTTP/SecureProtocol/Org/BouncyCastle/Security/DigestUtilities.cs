using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Security
{
	public sealed class DigestUtilities
	{
		private enum DigestAlgorithm
		{
			BLAKE2B_160 = 0,
			BLAKE2B_256 = 1,
			BLAKE2B_384 = 2,
			BLAKE2B_512 = 3,
			BLAKE2S_128 = 4,
			BLAKE2S_160 = 5,
			BLAKE2S_224 = 6,
			BLAKE2S_256 = 7,
			DSTU7564_256 = 8,
			DSTU7564_384 = 9,
			DSTU7564_512 = 10,
			GOST3411 = 11,
			GOST3411_2012_256 = 12,
			GOST3411_2012_512 = 13,
			KECCAK_224 = 14,
			KECCAK_256 = 15,
			KECCAK_288 = 16,
			KECCAK_384 = 17,
			KECCAK_512 = 18,
			MD2 = 19,
			MD4 = 20,
			MD5 = 21,
			NONE = 22,
			RIPEMD128 = 23,
			RIPEMD160 = 24,
			RIPEMD256 = 25,
			RIPEMD320 = 26,
			SHA_1 = 27,
			SHA_224 = 28,
			SHA_256 = 29,
			SHA_384 = 30,
			SHA_512 = 31,
			SHA_512_224 = 32,
			SHA_512_256 = 33,
			SHA3_224 = 34,
			SHA3_256 = 35,
			SHA3_384 = 36,
			SHA3_512 = 37,
			SHAKE128 = 38,
			SHAKE256 = 39,
			SM3 = 40,
			TIGER = 41,
			WHIRLPOOL = 42
		}

		private static readonly IDictionary algorithms;

		private static readonly IDictionary oids;

		public static ICollection Algorithms => null;

		private DigestUtilities()
		{
		}

		static DigestUtilities()
		{
		}

		public static DerObjectIdentifier GetObjectIdentifier(string mechanism)
		{
			return null;
		}

		public static IDigest GetDigest(DerObjectIdentifier id)
		{
			return null;
		}

		public static IDigest GetDigest(string algorithm)
		{
			return null;
		}

		public static string GetAlgorithmName(DerObjectIdentifier oid)
		{
			return null;
		}

		public static byte[] CalculateDigest(DerObjectIdentifier id, byte[] input)
		{
			return null;
		}

		public static byte[] CalculateDigest(string algorithm, byte[] input)
		{
			return null;
		}

		public static byte[] DoFinal(IDigest digest)
		{
			return null;
		}

		public static byte[] DoFinal(IDigest digest, byte[] input)
		{
			return null;
		}
	}
}
