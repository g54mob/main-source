using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Operators
{
	public class Asn1SignatureFactory : ISignatureFactory
	{
		private readonly AlgorithmIdentifier algID;

		private readonly string algorithm;

		private readonly AsymmetricKeyParameter privateKey;

		private readonly SecureRandom random;

		public object AlgorithmDetails => null;

		public static IEnumerable SignatureAlgNames => null;

		public Asn1SignatureFactory(string algorithm, AsymmetricKeyParameter privateKey)
		{
		}

		public Asn1SignatureFactory(string algorithm, AsymmetricKeyParameter privateKey, SecureRandom random)
		{
		}

		public IStreamCalculator CreateCalculator()
		{
			return null;
		}
	}
}
