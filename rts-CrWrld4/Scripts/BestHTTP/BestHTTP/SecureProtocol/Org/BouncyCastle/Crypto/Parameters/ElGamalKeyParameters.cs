namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class ElGamalKeyParameters : AsymmetricKeyParameter
	{
		private readonly ElGamalParameters parameters;

		public ElGamalParameters Parameters => null;

		protected ElGamalKeyParameters(bool isPrivate, ElGamalParameters parameters)
			: base(privateKey: false)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		protected bool Equals(ElGamalKeyParameters other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
