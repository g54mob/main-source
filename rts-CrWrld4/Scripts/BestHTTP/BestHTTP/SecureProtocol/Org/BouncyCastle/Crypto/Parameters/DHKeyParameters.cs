using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class DHKeyParameters : AsymmetricKeyParameter
	{
		private readonly DHParameters parameters;

		private readonly DerObjectIdentifier algorithmOid;

		public DHParameters Parameters => null;

		public DerObjectIdentifier AlgorithmOid => null;

		protected DHKeyParameters(bool isPrivate, DHParameters parameters)
			: base(privateKey: false)
		{
		}

		protected DHKeyParameters(bool isPrivate, DHParameters parameters, DerObjectIdentifier algorithmOid)
			: base(privateKey: false)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		protected bool Equals(DHKeyParameters other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
