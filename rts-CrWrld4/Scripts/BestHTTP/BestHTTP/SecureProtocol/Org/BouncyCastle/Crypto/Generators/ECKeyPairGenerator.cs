using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X9;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Multiplier;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class ECKeyPairGenerator : IAsymmetricCipherKeyPairGenerator
	{
		private readonly string algorithm;

		private ECDomainParameters parameters;

		private DerObjectIdentifier publicKeyParamSet;

		private SecureRandom random;

		public ECKeyPairGenerator()
		{
		}

		public ECKeyPairGenerator(string algorithm)
		{
		}

		public void Init(KeyGenerationParameters parameters)
		{
		}

		public AsymmetricCipherKeyPair GenerateKeyPair()
		{
			return null;
		}

		protected virtual ECMultiplier CreateBasePointMultiplier()
		{
			return null;
		}

		internal static X9ECParameters FindECCurveByOid(DerObjectIdentifier oid)
		{
			return null;
		}

		internal static ECPublicKeyParameters GetCorrespondingPublicKey(ECPrivateKeyParameters privKey)
		{
			return null;
		}
	}
}
