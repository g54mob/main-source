using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Multiplier;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Signers
{
	public class SM2Signer : ISigner
	{
		private readonly IDsaKCalculator kCalculator;

		private readonly IDigest digest;

		private readonly IDsaEncoding encoding;

		private ECDomainParameters ecParams;

		private ECPoint pubPoint;

		private ECKeyParameters ecKey;

		private byte[] z;

		public virtual string AlgorithmName => null;

		public SM2Signer()
		{
		}

		public SM2Signer(IDigest digest)
		{
		}

		public SM2Signer(IDsaEncoding encoding)
		{
		}

		public SM2Signer(IDsaEncoding encoding, IDigest digest)
		{
		}

		public virtual void Init(bool forSigning, ICipherParameters parameters)
		{
		}

		public virtual void Update(byte b)
		{
		}

		public virtual void BlockUpdate(byte[] buf, int off, int len)
		{
		}

		public virtual bool VerifySignature(byte[] signature)
		{
			return false;
		}

		public virtual void Reset()
		{
		}

		public virtual byte[] GenerateSignature()
		{
			return null;
		}

		private bool VerifySignature(BigInteger r, BigInteger s)
		{
			return false;
		}

		private byte[] GetZ(byte[] userID)
		{
			return null;
		}

		private void AddUserID(IDigest digest, byte[] userID)
		{
		}

		private void AddFieldElement(IDigest digest, ECFieldElement v)
		{
		}

		protected virtual BigInteger CalculateE(BigInteger n, byte[] message)
		{
			return null;
		}

		protected virtual ECMultiplier CreateBasePointMultiplier()
		{
			return null;
		}
	}
}
