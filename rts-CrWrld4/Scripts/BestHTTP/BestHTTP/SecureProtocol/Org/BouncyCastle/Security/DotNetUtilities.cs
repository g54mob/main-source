using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Security
{
	public sealed class DotNetUtilities
	{
		private DotNetUtilities()
		{
		}

		public static System.Security.Cryptography.X509Certificates.X509Certificate ToX509Certificate(X509CertificateStructure x509Struct)
		{
			return null;
		}

		public static System.Security.Cryptography.X509Certificates.X509Certificate ToX509Certificate(BestHTTP.SecureProtocol.Org.BouncyCastle.X509.X509Certificate x509Cert)
		{
			return null;
		}

		public static BestHTTP.SecureProtocol.Org.BouncyCastle.X509.X509Certificate FromX509Certificate(System.Security.Cryptography.X509Certificates.X509Certificate x509Cert)
		{
			return null;
		}

		public static AsymmetricCipherKeyPair GetDsaKeyPair(DSA dsa)
		{
			return null;
		}

		public static AsymmetricCipherKeyPair GetDsaKeyPair(DSAParameters dp)
		{
			return null;
		}

		public static DsaPublicKeyParameters GetDsaPublicKey(DSA dsa)
		{
			return null;
		}

		public static DsaPublicKeyParameters GetDsaPublicKey(DSAParameters dp)
		{
			return null;
		}

		public static AsymmetricCipherKeyPair GetRsaKeyPair(RSA rsa)
		{
			return null;
		}

		public static AsymmetricCipherKeyPair GetRsaKeyPair(RSAParameters rp)
		{
			return null;
		}

		public static RsaKeyParameters GetRsaPublicKey(RSA rsa)
		{
			return null;
		}

		public static RsaKeyParameters GetRsaPublicKey(RSAParameters rp)
		{
			return null;
		}

		public static AsymmetricCipherKeyPair GetKeyPair(AsymmetricAlgorithm privateKey)
		{
			return null;
		}

		public static RSA ToRSA(RsaKeyParameters rsaKey)
		{
			return null;
		}

		public static RSA ToRSA(RsaKeyParameters rsaKey, CspParameters csp)
		{
			return null;
		}

		public static RSA ToRSA(RsaPrivateCrtKeyParameters privKey)
		{
			return null;
		}

		public static RSA ToRSA(RsaPrivateCrtKeyParameters privKey, CspParameters csp)
		{
			return null;
		}

		public static RSA ToRSA(RsaPrivateKeyStructure privKey)
		{
			return null;
		}

		public static RSA ToRSA(RsaPrivateKeyStructure privKey, CspParameters csp)
		{
			return null;
		}

		public static RSAParameters ToRSAParameters(RsaKeyParameters rsaKey)
		{
			return default(RSAParameters);
		}

		public static RSAParameters ToRSAParameters(RsaPrivateCrtKeyParameters privKey)
		{
			return default(RSAParameters);
		}

		public static RSAParameters ToRSAParameters(RsaPrivateKeyStructure privKey)
		{
			return default(RSAParameters);
		}

		private static byte[] ConvertRSAParametersField(BigInteger n, int size)
		{
			return null;
		}

		private static RSA CreateRSAProvider(RSAParameters rp)
		{
			return null;
		}

		private static RSA CreateRSAProvider(RSAParameters rp, CspParameters csp)
		{
			return null;
		}
	}
}
