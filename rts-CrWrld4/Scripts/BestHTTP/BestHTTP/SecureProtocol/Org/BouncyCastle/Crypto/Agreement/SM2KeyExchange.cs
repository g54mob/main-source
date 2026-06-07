using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Agreement
{
	public class SM2KeyExchange
	{
		private readonly IDigest mDigest;

		private byte[] mUserID;

		private ECPrivateKeyParameters mStaticKey;

		private ECPoint mStaticPubPoint;

		private ECPoint mEphemeralPubPoint;

		private ECDomainParameters mECParams;

		private int mW;

		private ECPrivateKeyParameters mEphemeralKey;

		private bool mInitiator;

		public SM2KeyExchange()
		{
		}

		public SM2KeyExchange(IDigest digest)
		{
		}

		public virtual void Init(ICipherParameters privParam)
		{
		}

		public virtual byte[] CalculateKey(int kLen, ICipherParameters pubParam)
		{
			return null;
		}

		public virtual byte[][] CalculateKeyWithConfirmation(int kLen, byte[] confirmationTag, ICipherParameters pubParam)
		{
			return null;
		}

		protected virtual ECPoint CalculateU(SM2KeyExchangePublicParameters otherPub)
		{
			return null;
		}

		protected virtual byte[] Kdf(ECPoint u, byte[] za, byte[] zb, int klen)
		{
			return null;
		}

		private BigInteger Reduce(BigInteger x)
		{
			return null;
		}

		private byte[] S1(IDigest digest, ECPoint u, byte[] inner)
		{
			return null;
		}

		private byte[] CalculateInnerHash(IDigest digest, ECPoint u, byte[] za, byte[] zb, ECPoint p1, ECPoint p2)
		{
			return null;
		}

		private byte[] S2(IDigest digest, ECPoint u, byte[] inner)
		{
			return null;
		}

		private byte[] GetZ(IDigest digest, byte[] userID, ECPoint pubPoint)
		{
			return null;
		}

		private void AddUserID(IDigest digest, byte[] userID)
		{
		}

		private void AddFieldElement(IDigest digest, ECFieldElement v)
		{
		}
	}
}
