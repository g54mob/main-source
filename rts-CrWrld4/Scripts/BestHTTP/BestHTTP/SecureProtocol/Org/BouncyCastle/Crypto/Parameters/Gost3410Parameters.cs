using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class Gost3410Parameters : ICipherParameters
	{
		private readonly BigInteger p;

		private readonly BigInteger q;

		private readonly BigInteger a;

		private readonly Gost3410ValidationParameters validation;

		public BigInteger P => null;

		public BigInteger Q => null;

		public BigInteger A => null;

		public Gost3410ValidationParameters ValidationParameters => null;

		public Gost3410Parameters(BigInteger p, BigInteger q, BigInteger a)
		{
		}

		public Gost3410Parameters(BigInteger p, BigInteger q, BigInteger a, Gost3410ValidationParameters validation)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		protected bool Equals(Gost3410Parameters other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
