using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class DHParameters : ICipherParameters
	{
		private const int DefaultMinimumLength = 160;

		private readonly BigInteger p;

		private readonly BigInteger g;

		private readonly BigInteger q;

		private readonly BigInteger j;

		private readonly int m;

		private readonly int l;

		private readonly DHValidationParameters validation;

		public BigInteger P => null;

		public BigInteger G => null;

		public BigInteger Q => null;

		public BigInteger J => null;

		public int M => 0;

		public int L => 0;

		public DHValidationParameters ValidationParameters => null;

		private static int GetDefaultMParam(int lParam)
		{
			return 0;
		}

		public DHParameters(BigInteger p, BigInteger g)
		{
		}

		public DHParameters(BigInteger p, BigInteger g, BigInteger q)
		{
		}

		public DHParameters(BigInteger p, BigInteger g, BigInteger q, int l)
		{
		}

		public DHParameters(BigInteger p, BigInteger g, BigInteger q, int m, int l)
		{
		}

		public DHParameters(BigInteger p, BigInteger g, BigInteger q, BigInteger j, DHValidationParameters validation)
		{
		}

		public DHParameters(BigInteger p, BigInteger g, BigInteger q, int m, int l, BigInteger j, DHValidationParameters validation)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		protected virtual bool Equals(DHParameters other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
