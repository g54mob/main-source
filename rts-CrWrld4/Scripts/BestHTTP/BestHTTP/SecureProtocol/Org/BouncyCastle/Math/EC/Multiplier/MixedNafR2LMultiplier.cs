namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Multiplier
{
	public class MixedNafR2LMultiplier : AbstractECMultiplier
	{
		protected readonly int additionCoord;

		protected readonly int doublingCoord;

		public MixedNafR2LMultiplier()
		{
		}

		public MixedNafR2LMultiplier(int additionCoord, int doublingCoord)
		{
		}

		protected override ECPoint MultiplyPositive(ECPoint p, BigInteger k)
		{
			return null;
		}

		protected virtual ECCurve ConfigureCurve(ECCurve c, int coord)
		{
			return null;
		}
	}
}
