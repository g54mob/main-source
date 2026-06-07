using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class TlsDHUtilities
	{
		internal static readonly BigInteger Two;

		private static readonly string draft_ffdhe2432_p;

		internal static readonly DHParameters draft_ffdhe2432;

		private static readonly string draft_ffdhe3072_p;

		internal static readonly DHParameters draft_ffdhe3072;

		private static readonly string draft_ffdhe4096_p;

		internal static readonly DHParameters draft_ffdhe4096;

		private static readonly string draft_ffdhe6144_p;

		internal static readonly DHParameters draft_ffdhe6144;

		private static readonly string draft_ffdhe8192_p;

		internal static readonly DHParameters draft_ffdhe8192;

		private static BigInteger FromHex(string hex)
		{
			return null;
		}

		private static DHParameters FromSafeP(string hexP)
		{
			return null;
		}

		public static void AddNegotiatedDheGroupsClientExtension(IDictionary extensions, byte[] dheGroups)
		{
		}

		public static void AddNegotiatedDheGroupsServerExtension(IDictionary extensions, byte dheGroup)
		{
		}

		public static byte[] GetNegotiatedDheGroupsClientExtension(IDictionary extensions)
		{
			return null;
		}

		public static short GetNegotiatedDheGroupsServerExtension(IDictionary extensions)
		{
			return 0;
		}

		public static byte[] CreateNegotiatedDheGroupsClientExtension(byte[] dheGroups)
		{
			return null;
		}

		public static byte[] CreateNegotiatedDheGroupsServerExtension(byte dheGroup)
		{
			return null;
		}

		public static byte[] ReadNegotiatedDheGroupsClientExtension(byte[] extensionData)
		{
			return null;
		}

		public static byte ReadNegotiatedDheGroupsServerExtension(byte[] extensionData)
		{
			return 0;
		}

		public static DHParameters GetParametersForDHEGroup(short dheGroup)
		{
			return null;
		}

		public static bool ContainsDheCipherSuites(int[] cipherSuites)
		{
			return false;
		}

		public static bool IsDheCipherSuite(int cipherSuite)
		{
			return false;
		}

		public static bool AreCompatibleParameters(DHParameters a, DHParameters b)
		{
			return false;
		}

		public static byte[] CalculateDHBasicAgreement(DHPublicKeyParameters publicKey, DHPrivateKeyParameters privateKey)
		{
			return null;
		}

		public static AsymmetricCipherKeyPair GenerateDHKeyPair(SecureRandom random, DHParameters dhParams)
		{
			return null;
		}

		public static DHPrivateKeyParameters GenerateEphemeralClientKeyExchange(SecureRandom random, DHParameters dhParams, Stream output)
		{
			return null;
		}

		public static DHPrivateKeyParameters GenerateEphemeralServerKeyExchange(SecureRandom random, DHParameters dhParams, Stream output)
		{
			return null;
		}

		public static BigInteger ReadDHParameter(Stream input)
		{
			return null;
		}

		public static DHParameters ReadDHParameters(Stream input)
		{
			return null;
		}

		public static DHParameters ReceiveDHParameters(TlsDHVerifier dhVerifier, Stream input)
		{
			return null;
		}

		public static void WriteDHParameter(BigInteger x, Stream output)
		{
		}

		public static void WriteDHParameters(DHParameters dhParameters, Stream output)
		{
		}
	}
}
