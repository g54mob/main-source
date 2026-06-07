using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement.Srp
{
	public class Srp6Client
	{
		protected BigInteger N;

		protected BigInteger g;

		protected BigInteger privA;

		protected BigInteger pubA;

		protected BigInteger B;

		protected BigInteger x;

		protected BigInteger u;

		protected BigInteger S;

		protected BigInteger M1;

		protected BigInteger M2;

		protected BigInteger Key;

		protected IDigest digest;

		protected SecureRandom random;

		public virtual void Init(BigInteger N, BigInteger g, IDigest digest, SecureRandom random)
		{
		}

		public virtual void Init(Srp6GroupParameters group, IDigest digest, SecureRandom random)
		{
		}

		public virtual BigInteger GenerateClientCredentials(byte[] salt, byte[] identity, byte[] password)
		{
			return null;
		}

		public virtual BigInteger CalculateSecret(BigInteger serverB)
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

		public virtual BigInteger CalculateClientEvidenceMessage()
		{
			return null;
		}

		public virtual bool VerifyServerEvidenceMessage(BigInteger serverM2)
		{
			return false;
		}

		public virtual BigInteger CalculateSessionKey()
		{
			return null;
		}
	}
}
