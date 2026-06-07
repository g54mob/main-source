using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Modes
{
	public class CcmBlockCipher : IAeadBlockCipher, IAeadCipher
	{
		private static readonly int BlockSize;

		private readonly IBlockCipher cipher;

		private readonly byte[] macBlock;

		private bool forEncryption;

		private byte[] nonce;

		private byte[] initialAssociatedText;

		private int macSize;

		private ICipherParameters keyParam;

		private readonly MemoryStream associatedText;

		private readonly MemoryStream data;

		public virtual string AlgorithmName => null;

		public CcmBlockCipher(IBlockCipher cipher)
		{
		}

		public virtual IBlockCipher GetUnderlyingCipher()
		{
			return null;
		}

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public virtual int GetBlockSize()
		{
			return 0;
		}

		public virtual void ProcessAadByte(byte input)
		{
		}

		public virtual void ProcessAadBytes(byte[] inBytes, int inOff, int len)
		{
		}

		public virtual int ProcessByte(byte input, byte[] outBytes, int outOff)
		{
			return 0;
		}

		public virtual int ProcessBytes(byte[] inBytes, int inOff, int inLen, byte[] outBytes, int outOff)
		{
			return 0;
		}

		public virtual int DoFinal(byte[] outBytes, int outOff)
		{
			return 0;
		}

		public virtual void Reset()
		{
		}

		public virtual byte[] GetMac()
		{
			return null;
		}

		public virtual int GetUpdateOutputSize(int len)
		{
			return 0;
		}

		public virtual int GetOutputSize(int len)
		{
			return 0;
		}

		public virtual byte[] ProcessPacket(byte[] input, int inOff, int inLen)
		{
			return null;
		}

		public virtual int ProcessPacket(byte[] input, int inOff, int inLen, byte[] output, int outOff)
		{
			return 0;
		}

		private int CalculateMac(byte[] data, int dataOff, int dataLen, byte[] macBlock)
		{
			return 0;
		}

		private int GetMacSize(bool forEncryption, int requestedMacBits)
		{
			return 0;
		}

		private int GetAssociatedTextLength()
		{
			return 0;
		}

		private bool HasAssociatedText()
		{
			return false;
		}
	}
}
