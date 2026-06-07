using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Modes
{
	public class OcbBlockCipher : IAeadBlockCipher, IAeadCipher
	{
		private const int BLOCK_SIZE = 16;

		private readonly IBlockCipher hashCipher;

		private readonly IBlockCipher mainCipher;

		private bool forEncryption;

		private int macSize;

		private byte[] initialAssociatedText;

		private IList L;

		private byte[] L_Asterisk;

		private byte[] L_Dollar;

		private byte[] KtopInput;

		private byte[] Stretch;

		private byte[] OffsetMAIN_0;

		private byte[] hashBlock;

		private byte[] mainBlock;

		private int hashBlockPos;

		private int mainBlockPos;

		private long hashBlockCount;

		private long mainBlockCount;

		private byte[] OffsetHASH;

		private byte[] Sum;

		private byte[] OffsetMAIN;

		private byte[] Checksum;

		private byte[] macBlock;

		public virtual string AlgorithmName => null;

		public OcbBlockCipher(IBlockCipher hashCipher, IBlockCipher mainCipher)
		{
		}

		public virtual IBlockCipher GetUnderlyingCipher()
		{
			return null;
		}

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		protected virtual int ProcessNonce(byte[] N)
		{
			return 0;
		}

		public virtual int GetBlockSize()
		{
			return 0;
		}

		public virtual byte[] GetMac()
		{
			return null;
		}

		public virtual int GetOutputSize(int len)
		{
			return 0;
		}

		public virtual int GetUpdateOutputSize(int len)
		{
			return 0;
		}

		public virtual void ProcessAadByte(byte input)
		{
		}

		public virtual void ProcessAadBytes(byte[] input, int off, int len)
		{
		}

		public virtual int ProcessByte(byte input, byte[] output, int outOff)
		{
			return 0;
		}

		public virtual int ProcessBytes(byte[] input, int inOff, int len, byte[] output, int outOff)
		{
			return 0;
		}

		public virtual int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public virtual void Reset()
		{
		}

		protected virtual void Clear(byte[] bs)
		{
		}

		protected virtual byte[] GetLSub(int n)
		{
			return null;
		}

		protected virtual void ProcessHashBlock()
		{
		}

		protected virtual void ProcessMainBlock(byte[] output, int outOff)
		{
		}

		protected virtual void Reset(bool clearMac)
		{
		}

		protected virtual void UpdateHASH(byte[] LSub)
		{
		}

		protected static byte[] OCB_double(byte[] block)
		{
			return null;
		}

		protected static void OCB_extend(byte[] block, int pos)
		{
		}

		protected static int OCB_ntz(long x)
		{
			return 0;
		}

		protected static int ShiftLeft(byte[] block, byte[] output)
		{
			return 0;
		}

		protected static void Xor(byte[] block, byte[] val)
		{
		}
	}
}
