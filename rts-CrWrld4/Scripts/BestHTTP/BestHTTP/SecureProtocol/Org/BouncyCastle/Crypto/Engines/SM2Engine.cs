using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Multiplier;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class SM2Engine
	{
		private readonly IDigest mDigest;

		private bool mForEncryption;

		private ECKeyParameters mECKey;

		private ECDomainParameters mECParams;

		private int mCurveLength;

		private SecureRandom mRandom;

		public SM2Engine()
		{
		}

		public SM2Engine(IDigest digest)
		{
		}

		public virtual void Init(bool forEncryption, ICipherParameters param)
		{
		}

		public virtual byte[] ProcessBlock(byte[] input, int inOff, int inLen)
		{
			return null;
		}

		protected virtual ECMultiplier CreateBasePointMultiplier()
		{
			return null;
		}

		private byte[] Encrypt(byte[] input, int inOff, int inLen)
		{
			return null;
		}

		private byte[] Decrypt(byte[] input, int inOff, int inLen)
		{
			return null;
		}

		private bool NotEncrypted(byte[] encData, byte[] input, int inOff)
		{
			return false;
		}

		private void Kdf(IDigest digest, ECPoint c1, byte[] encData)
		{
		}

		private void Xor(byte[] data, byte[] kdfOut, int dOff, int dRemaining)
		{
		}

		private BigInteger NextK()
		{
			return null;
		}

		private void AddFieldElement(IDigest digest, ECFieldElement v)
		{
		}
	}
}
