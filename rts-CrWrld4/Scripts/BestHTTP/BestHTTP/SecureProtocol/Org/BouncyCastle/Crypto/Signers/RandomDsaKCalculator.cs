using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Signers
{
	public class RandomDsaKCalculator : IDsaKCalculator
	{
		private BigInteger q;

		private SecureRandom random;

		public virtual bool IsDeterministic => false;

		public virtual void Init(BigInteger n, SecureRandom random)
		{
		}

		public virtual void Init(BigInteger n, BigInteger d, byte[] message)
		{
		}

		public virtual BigInteger NextK()
		{
			return null;
		}
	}
}
