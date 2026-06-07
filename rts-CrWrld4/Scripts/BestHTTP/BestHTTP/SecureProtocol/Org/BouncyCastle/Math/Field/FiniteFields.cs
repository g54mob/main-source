namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.Field
{
	public abstract class FiniteFields
	{
		internal static readonly IFiniteField GF_2;

		internal static readonly IFiniteField GF_3;

		public static IPolynomialExtensionField GetBinaryExtensionField(int[] exponents)
		{
			return null;
		}

		public static IFiniteField GetPrimeField(BigInteger characteristic)
		{
			return null;
		}
	}
}
