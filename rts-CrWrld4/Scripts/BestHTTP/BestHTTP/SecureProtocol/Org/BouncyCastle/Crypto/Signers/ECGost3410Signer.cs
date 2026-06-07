using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Multiplier;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Signers
{
	public class ECGost3410Signer : IDsaExt, IDsa
	{
		private ECKeyParameters key;

		private SecureRandom random;

		private bool forSigning;

		public virtual string AlgorithmName => null;

		public virtual BigInteger Order => null;

		public virtual void Init(bool forSigning, ICipherParameters parameters)
		{
		}

		public virtual BigInteger[] GenerateSignature(byte[] message)
		{
			return null;
		}

		public virtual bool VerifySignature(byte[] message, BigInteger r, BigInteger s)
		{
			return false;
		}

		protected virtual ECMultiplier CreateBasePointMultiplier()
		{
			return null;
		}
	}
}
