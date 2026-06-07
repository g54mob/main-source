namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.Field
{
	internal class PrimeField : IFiniteField
	{
		protected readonly BigInteger characteristic;

		public virtual BigInteger Characteristic => null;

		public virtual int Dimension => 0;

		internal PrimeField(BigInteger characteristic)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
