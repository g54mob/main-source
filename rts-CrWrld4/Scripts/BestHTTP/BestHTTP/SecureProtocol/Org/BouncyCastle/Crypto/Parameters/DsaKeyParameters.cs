namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public abstract class DsaKeyParameters : AsymmetricKeyParameter
	{
		private readonly DsaParameters parameters;

		public DsaParameters Parameters => null;

		protected DsaKeyParameters(bool isPrivate, DsaParameters parameters)
			: base(privateKey: false)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		protected bool Equals(DsaKeyParameters other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
