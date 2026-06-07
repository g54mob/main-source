using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class DHBasicKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
	{
		private DHKeyGenerationParameters param;

		public virtual void Init(KeyGenerationParameters parameters)
		{
		}

		public virtual AsymmetricCipherKeyPair GenerateKeyPair()
		{
			return null;
		}
	}
}
