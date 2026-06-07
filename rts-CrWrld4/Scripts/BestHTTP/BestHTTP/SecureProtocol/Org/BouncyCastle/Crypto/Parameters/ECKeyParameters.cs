using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public abstract class ECKeyParameters : AsymmetricKeyParameter
	{
		private static readonly string[] algorithms;

		private readonly string algorithm;

		private readonly ECDomainParameters parameters;

		private readonly DerObjectIdentifier publicKeyParamSet;

		public string AlgorithmName => null;

		public ECDomainParameters Parameters => null;

		public DerObjectIdentifier PublicKeyParamSet => null;

		protected ECKeyParameters(string algorithm, bool isPrivate, ECDomainParameters parameters)
			: base(privateKey: false)
		{
		}

		protected ECKeyParameters(string algorithm, bool isPrivate, DerObjectIdentifier publicKeyParamSet)
			: base(privateKey: false)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		protected bool Equals(ECKeyParameters other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		internal ECKeyGenerationParameters CreateKeyGenerationParameters(SecureRandom random)
		{
			return null;
		}

		internal static string VerifyAlgorithmName(string algorithm)
		{
			return null;
		}

		internal static ECDomainParameters LookupParameters(DerObjectIdentifier publicKeyParamSet)
		{
			return null;
		}
	}
}
