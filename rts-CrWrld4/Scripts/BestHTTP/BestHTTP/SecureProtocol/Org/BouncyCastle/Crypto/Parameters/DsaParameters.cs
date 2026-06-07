using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class DsaParameters : ICipherParameters
	{
		private readonly BigInteger p;

		private readonly BigInteger q;

		private readonly BigInteger g;

		private readonly DsaValidationParameters validation;

		public BigInteger P => null;

		public BigInteger Q => null;

		public BigInteger G => null;

		public DsaValidationParameters ValidationParameters => null;

		public DsaParameters(BigInteger p, BigInteger q, BigInteger g)
		{
		}

		public DsaParameters(BigInteger p, BigInteger q, BigInteger g, DsaValidationParameters parameters)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		protected bool Equals(DsaParameters other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
