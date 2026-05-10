namespace Mono.Math.Prime.Generator
{
	public class SequentialSearchPrimeGeneratorBase : PrimeGeneratorBase
	{
		protected virtual BigInteger GenerateSearchBase(int bits, object context)
		{
			return null;
		}

		public override BigInteger GenerateNewPrime(int bits)
		{
			return null;
		}

		public virtual BigInteger GenerateNewPrime(int bits, object context)
		{
			return null;
		}

		protected virtual bool IsPrimeAcceptable(BigInteger bi, object context)
		{
			return false;
		}
	}
}
