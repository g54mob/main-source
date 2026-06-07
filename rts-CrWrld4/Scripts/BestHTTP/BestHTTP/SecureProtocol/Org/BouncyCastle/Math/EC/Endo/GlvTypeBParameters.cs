namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Endo
{
	public class GlvTypeBParameters
	{
		protected readonly BigInteger m_beta;

		protected readonly BigInteger m_lambda;

		protected readonly ScalarSplitParameters m_splitParams;

		public virtual BigInteger Beta => null;

		public virtual BigInteger Lambda => null;

		public virtual ScalarSplitParameters SplitParams => null;

		public virtual BigInteger[] V1 => null;

		public virtual BigInteger[] V2 => null;

		public virtual BigInteger G1 => null;

		public virtual BigInteger G2 => null;

		public virtual int Bits => 0;

		public GlvTypeBParameters(BigInteger beta, BigInteger lambda, BigInteger[] v1, BigInteger[] v2, BigInteger g1, BigInteger g2, int bits)
		{
		}

		public GlvTypeBParameters(BigInteger beta, BigInteger lambda, ScalarSplitParameters splitParams)
		{
		}
	}
}
