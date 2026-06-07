using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement
{
	public class ECDHCBasicAgreement : IBasicAgreement
	{
		private ECPrivateKeyParameters privKey;

		public virtual void Init(ICipherParameters parameters)
		{
		}

		public virtual int GetFieldSize()
		{
			return 0;
		}

		public virtual BigInteger CalculateAgreement(ICipherParameters pubKey)
		{
			return null;
		}
	}
}
