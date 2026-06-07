using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Modes
{
	public class KCcmBlockCipher : IAeadBlockCipher, IAeadCipher
	{
		private static readonly int BYTES_IN_INT;

		private static readonly int BITS_IN_BYTE;

		private static readonly int MAX_MAC_BIT_LENGTH;

		private static readonly int MIN_MAC_BIT_LENGTH;

		private IBlockCipher engine;

		private int macSize;

		private bool forEncryption;

		private byte[] initialAssociatedText;

		private byte[] mac;

		private byte[] macBlock;

		private byte[] nonce;

		private byte[] G1;

		private byte[] buffer;

		private byte[] s;

		private byte[] counter;

		private readonly MemoryStream associatedText;

		private readonly MemoryStream data;

		private int Nb_;

		public virtual string AlgorithmName => null;

		private void setNb(int Nb)
		{
		}

		public KCcmBlockCipher(IBlockCipher engine)
		{
		}

		public KCcmBlockCipher(IBlockCipher engine, int Nb)
		{
		}

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public virtual int GetBlockSize()
		{
			return 0;
		}

		public virtual IBlockCipher GetUnderlyingCipher()
		{
			return null;
		}

		public virtual void ProcessAadByte(byte input)
		{
		}

		public virtual void ProcessAadBytes(byte[] input, int inOff, int len)
		{
		}

		private void ProcessAAD(byte[] assocText, int assocOff, int assocLen, int dataLen)
		{
		}

		public virtual int ProcessByte(byte input, byte[] output, int outOff)
		{
			return 0;
		}

		public virtual int ProcessBytes(byte[] input, int inOff, int inLen, byte[] output, int outOff)
		{
			return 0;
		}

		public int ProcessPacket(byte[] input, int inOff, int len, byte[] output, int outOff)
		{
			return 0;
		}

		private void ProcessBlock(byte[] input, int inOff, int len, byte[] output, int outOff)
		{
		}

		private void CalculateMac(byte[] authText, int authOff, int len)
		{
		}

		public virtual int DoFinal(byte[] output, int outOff)
		{
			return 0;
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

		public virtual void Reset()
		{
		}

		private void intToBytes(int num, byte[] outBytes, int outOff)
		{
		}

		private byte getFlag(bool authTextPresents, int macSize)
		{
			return 0;
		}
	}
}
