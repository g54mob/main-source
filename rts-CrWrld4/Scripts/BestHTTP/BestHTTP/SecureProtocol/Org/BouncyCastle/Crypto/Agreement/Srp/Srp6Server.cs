using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement.Srp
{
	public class Srp6Server
	{
		protected BigInteger N;

		protected BigInteger g;

		protected BigInteger v;

		protected SecureRandom random;

		protected IDigest digest;

		protected BigInteger A;

		protected BigInteger privB;

		protected BigInteger pubB;

		protected BigInteger u;

		protected BigInteger S;

		protected BigInteger M1;

		protected BigInteger M2;

		protected BigInteger Key;

		public virtual void Init(BigInteger N, BigInteger g, BigInteger v, IDigest digest, SecureRandom random)
		{
		}

		public virtual void Init(Srp6GroupParameters group, BigInteger v, IDigest digest, SecureRandom random)
		{
		}

		public virtual BigInteger GenerateServerCredentials()
		{
			return null;
		}

		public virtual BigInteger CalculateSecret(BigInteger clientA)
		{
			return null;
		}

		protected virtual BigInteger SelectPrivateValue()
		{
			return null;
		}

		private BigInteger CalculateS()
		{
			return null;
		}

		public virtual bool VerifyClientEvidenceMessage(BigInteger clientM1)
		{
			return false;
		}

		public virtual BigInteger CalculateServerEvidenceMessage()
		{
			return null;
		}

		public virtual BigInteger CalculateSessionKey()
		{
			return null;
		}
	}
}
