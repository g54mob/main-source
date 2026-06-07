using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class IesEngine
	{
		private readonly IBasicAgreement agree;

		private readonly IDerivationFunction kdf;

		private readonly IMac mac;

		private readonly BufferedBlockCipher cipher;

		private readonly byte[] macBuf;

		private bool forEncryption;

		private ICipherParameters privParam;

		private ICipherParameters pubParam;

		private IesParameters param;

		public IesEngine(IBasicAgreement agree, IDerivationFunction kdf, IMac mac)
		{
		}

		public IesEngine(IBasicAgreement agree, IDerivationFunction kdf, IMac mac, BufferedBlockCipher cipher)
		{
		}

		public virtual void Init(bool forEncryption, ICipherParameters privParameters, ICipherParameters pubParameters, ICipherParameters iesParameters)
		{
		}

		private byte[] DecryptBlock(byte[] in_enc, int inOff, int inLen, byte[] z)
		{
			return null;
		}

		private byte[] EncryptBlock(byte[] input, int inOff, int inLen, byte[] z)
		{
			return null;
		}

		private byte[] GenerateKdfBytes(KdfParameters kParam, int length)
		{
			return null;
		}

		public virtual byte[] ProcessBlock(byte[] input, int inOff, int inLen)
		{
			return null;
		}
	}
}
