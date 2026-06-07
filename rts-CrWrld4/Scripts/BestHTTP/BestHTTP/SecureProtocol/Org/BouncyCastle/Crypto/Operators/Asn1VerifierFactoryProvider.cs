using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Operators
{
	public class Asn1VerifierFactoryProvider : IVerifierFactoryProvider
	{
		private readonly AsymmetricKeyParameter publicKey;

		public IEnumerable SignatureAlgNames => null;

		public Asn1VerifierFactoryProvider(AsymmetricKeyParameter publicKey)
		{
		}

		public IVerifierFactory CreateVerifierFactory(object algorithmDetails)
		{
			return null;
		}
	}
}
