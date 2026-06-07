using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.Pkcs;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Pkcs
{
	public sealed class EncryptedPrivateKeyInfoFactory
	{
		private EncryptedPrivateKeyInfoFactory()
		{
		}

		public static EncryptedPrivateKeyInfo CreateEncryptedPrivateKeyInfo(DerObjectIdentifier algorithm, char[] passPhrase, byte[] salt, int iterationCount, AsymmetricKeyParameter key)
		{
			return null;
		}

		public static EncryptedPrivateKeyInfo CreateEncryptedPrivateKeyInfo(string algorithm, char[] passPhrase, byte[] salt, int iterationCount, AsymmetricKeyParameter key)
		{
			return null;
		}

		public static EncryptedPrivateKeyInfo CreateEncryptedPrivateKeyInfo(string algorithm, char[] passPhrase, byte[] salt, int iterationCount, PrivateKeyInfo keyInfo)
		{
			return null;
		}

		public static EncryptedPrivateKeyInfo CreateEncryptedPrivateKeyInfo(DerObjectIdentifier cipherAlgorithm, DerObjectIdentifier prfAlgorithm, char[] passPhrase, byte[] salt, int iterationCount, SecureRandom random, AsymmetricKeyParameter key)
		{
			return null;
		}

		public static EncryptedPrivateKeyInfo CreateEncryptedPrivateKeyInfo(DerObjectIdentifier cipherAlgorithm, DerObjectIdentifier prfAlgorithm, char[] passPhrase, byte[] salt, int iterationCount, SecureRandom random, PrivateKeyInfo keyInfo)
		{
			return null;
		}
	}
}
