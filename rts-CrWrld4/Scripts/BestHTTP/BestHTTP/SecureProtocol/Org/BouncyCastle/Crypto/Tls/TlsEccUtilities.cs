using System.Collections;
using System.IO;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class TlsEccUtilities
	{
		private static readonly string[] CurveNames;

		public static void AddSupportedEllipticCurvesExtension(IDictionary extensions, int[] namedCurves)
		{
		}

		public static void AddSupportedPointFormatsExtension(IDictionary extensions, byte[] ecPointFormats)
		{
		}

		public static int[] GetSupportedEllipticCurvesExtension(IDictionary extensions)
		{
			return null;
		}

		public static byte[] GetSupportedPointFormatsExtension(IDictionary extensions)
		{
			return null;
		}

		public static byte[] CreateSupportedEllipticCurvesExtension(int[] namedCurves)
		{
			return null;
		}

		public static byte[] CreateSupportedPointFormatsExtension(byte[] ecPointFormats)
		{
			return null;
		}

		public static int[] ReadSupportedEllipticCurvesExtension(byte[] extensionData)
		{
			return null;
		}

		public static byte[] ReadSupportedPointFormatsExtension(byte[] extensionData)
		{
			return null;
		}

		public static string GetNameOfNamedCurve(int namedCurve)
		{
			return null;
		}

		public static ECDomainParameters GetParametersForNamedCurve(int namedCurve)
		{
			return null;
		}

		public static bool HasAnySupportedNamedCurves()
		{
			return false;
		}

		public static bool ContainsEccCipherSuites(int[] cipherSuites)
		{
			return false;
		}

		public static bool IsEccCipherSuite(int cipherSuite)
		{
			return false;
		}

		public static bool AreOnSameCurve(ECDomainParameters a, ECDomainParameters b)
		{
			return false;
		}

		public static bool IsSupportedNamedCurve(int namedCurve)
		{
			return false;
		}

		public static bool IsCompressionPreferred(byte[] ecPointFormats, byte compressionFormat)
		{
			return false;
		}

		public static byte[] SerializeECFieldElement(int fieldSize, BigInteger x)
		{
			return null;
		}

		public static byte[] SerializeECPoint(byte[] ecPointFormats, ECPoint point)
		{
			return null;
		}

		public static byte[] SerializeECPublicKey(byte[] ecPointFormats, ECPublicKeyParameters keyParameters)
		{
			return null;
		}

		public static BigInteger DeserializeECFieldElement(int fieldSize, byte[] encoding)
		{
			return null;
		}

		public static ECPoint DeserializeECPoint(byte[] ecPointFormats, ECCurve curve, byte[] encoding)
		{
			return null;
		}

		public static ECPublicKeyParameters DeserializeECPublicKey(byte[] ecPointFormats, ECDomainParameters curve_params, byte[] encoding)
		{
			return null;
		}

		public static byte[] CalculateECDHBasicAgreement(ECPublicKeyParameters publicKey, ECPrivateKeyParameters privateKey)
		{
			return null;
		}

		public static AsymmetricCipherKeyPair GenerateECKeyPair(SecureRandom random, ECDomainParameters ecParams)
		{
			return null;
		}

		public static ECPrivateKeyParameters GenerateEphemeralClientKeyExchange(SecureRandom random, byte[] ecPointFormats, ECDomainParameters ecParams, Stream output)
		{
			return null;
		}

		internal static ECPrivateKeyParameters GenerateEphemeralServerKeyExchange(SecureRandom random, int[] namedCurves, byte[] ecPointFormats, Stream output)
		{
			return null;
		}

		public static ECPublicKeyParameters ValidateECPublicKey(ECPublicKeyParameters key)
		{
			return null;
		}

		public static int ReadECExponent(int fieldSize, Stream input)
		{
			return 0;
		}

		public static BigInteger ReadECFieldElement(int fieldSize, Stream input)
		{
			return null;
		}

		public static BigInteger ReadECParameter(Stream input)
		{
			return null;
		}

		public static ECDomainParameters ReadECParameters(int[] namedCurves, byte[] ecPointFormats, Stream input)
		{
			return null;
		}

		private static void CheckNamedCurve(int[] namedCurves, int namedCurve)
		{
		}

		public static void WriteECExponent(int k, Stream output)
		{
		}

		public static void WriteECFieldElement(ECFieldElement x, Stream output)
		{
		}

		public static void WriteECFieldElement(int fieldSize, BigInteger x, Stream output)
		{
		}

		public static void WriteECParameter(BigInteger x, Stream output)
		{
		}

		public static void WriteExplicitECParameters(byte[] ecPointFormats, ECDomainParameters ecParameters, Stream output)
		{
		}

		public static void WriteECPoint(byte[] ecPointFormats, ECPoint point, Stream output)
		{
		}

		public static void WriteNamedECParameters(int namedCurve, Stream output)
		{
		}
	}
}
