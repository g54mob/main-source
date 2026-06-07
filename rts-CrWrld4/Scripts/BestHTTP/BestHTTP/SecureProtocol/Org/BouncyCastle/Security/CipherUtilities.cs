using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Security
{
	public sealed class CipherUtilities
	{
		private enum CipherAlgorithm
		{
			AES = 0,
			ARC4 = 1,
			BLOWFISH = 2,
			CAMELLIA = 3,
			CAST5 = 4,
			CAST6 = 5,
			CHACHA = 6,
			CHACHA20_POLY1305 = 7,
			CHACHA7539 = 8,
			DES = 9,
			DESEDE = 10,
			ELGAMAL = 11,
			GOST28147 = 12,
			HC128 = 13,
			HC256 = 14,
			IDEA = 15,
			NOEKEON = 16,
			PBEWITHSHAAND128BITRC4 = 17,
			PBEWITHSHAAND40BITRC4 = 18,
			RC2 = 19,
			RC5 = 20,
			RC5_64 = 21,
			RC6 = 22,
			RIJNDAEL = 23,
			RSA = 24,
			SALSA20 = 25,
			SEED = 26,
			SERPENT = 27,
			SKIPJACK = 28,
			SM4 = 29,
			TEA = 30,
			THREEFISH_256 = 31,
			THREEFISH_512 = 32,
			THREEFISH_1024 = 33,
			TNEPRES = 34,
			TWOFISH = 35,
			VMPC = 36,
			VMPC_KSA3 = 37,
			XTEA = 38
		}

		private enum CipherMode
		{
			ECB = 0,
			NONE = 1,
			CBC = 2,
			CCM = 3,
			CFB = 4,
			CTR = 5,
			CTS = 6,
			EAX = 7,
			GCM = 8,
			GOFB = 9,
			OCB = 10,
			OFB = 11,
			OPENPGPCFB = 12,
			SIC = 13
		}

		private enum CipherPadding
		{
			NOPADDING = 0,
			RAW = 1,
			ISO10126PADDING = 2,
			ISO10126D2PADDING = 3,
			ISO10126_2PADDING = 4,
			ISO7816_4PADDING = 5,
			ISO9797_1PADDING = 6,
			ISO9796_1 = 7,
			ISO9796_1PADDING = 8,
			OAEP = 9,
			OAEPPADDING = 10,
			OAEPWITHMD5ANDMGF1PADDING = 11,
			OAEPWITHSHA1ANDMGF1PADDING = 12,
			OAEPWITHSHA_1ANDMGF1PADDING = 13,
			OAEPWITHSHA224ANDMGF1PADDING = 14,
			OAEPWITHSHA_224ANDMGF1PADDING = 15,
			OAEPWITHSHA256ANDMGF1PADDING = 16,
			OAEPWITHSHA_256ANDMGF1PADDING = 17,
			OAEPWITHSHA384ANDMGF1PADDING = 18,
			OAEPWITHSHA_384ANDMGF1PADDING = 19,
			OAEPWITHSHA512ANDMGF1PADDING = 20,
			OAEPWITHSHA_512ANDMGF1PADDING = 21,
			PKCS1 = 22,
			PKCS1PADDING = 23,
			PKCS5 = 24,
			PKCS5PADDING = 25,
			PKCS7 = 26,
			PKCS7PADDING = 27,
			TBCPADDING = 28,
			WITHCTS = 29,
			X923PADDING = 30,
			ZEROBYTEPADDING = 31
		}

		private static readonly IDictionary algorithms;

		private static readonly IDictionary oids;

		public static ICollection Algorithms => null;

		static CipherUtilities()
		{
		}

		private CipherUtilities()
		{
		}

		public static DerObjectIdentifier GetObjectIdentifier(string mechanism)
		{
			return null;
		}

		public static IBufferedCipher GetCipher(DerObjectIdentifier oid)
		{
			return null;
		}

		public static IBufferedCipher GetCipher(string algorithm)
		{
			return null;
		}

		public static string GetAlgorithmName(DerObjectIdentifier oid)
		{
			return null;
		}

		private static int GetDigitIndex(string s)
		{
			return 0;
		}

		private static IBlockCipher CreateBlockCipher(CipherAlgorithm cipherAlgorithm)
		{
			return null;
		}
	}
}
