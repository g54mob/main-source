using BestHTTP.PlatformSupport.IL2CPP;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Modes.Gcm;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Modes
{
	[Il2CppEagerStaticClassConstruction]
	public sealed class GcmBlockCipher : IAeadBlockCipher, IAeadCipher
	{
		private const int BlockSize = 16;

		private byte[] ctrBlock;

		private readonly IBlockCipher cipher;

		private IGcmExponentiator exp;

		private bool forEncryption;

		private bool initialised;

		private int macSize;

		private byte[] lastKey;

		private byte[] nonce;

		private byte[] initialAssociatedText;

		private byte[] H;

		private byte[] J0;

		private int bufLength;

		private byte[] bufBlock;

		private byte[] macBlock;

		private byte[] S;

		private byte[] S_at;

		private byte[] S_atPre;

		private byte[] counter;

		private uint blocksRemaining;

		private int bufOff;

		private ulong totalLength;

		private byte[] atBlock;

		private int atBlockPos;

		private ulong atLength;

		private ulong atLengthPre;

		private byte[] Tables8kGcmMultiplier_H;

		private uint[][][] Tables8kGcmMultiplier_M;

		private uint[] Tables8kGcmMultiplier_z;

		public string AlgorithmName => null;

		public GcmBlockCipher(IBlockCipher c)
		{
		}

		public IBlockCipher GetUnderlyingCipher()
		{
			return null;
		}

		public int GetBlockSize()
		{
			return 0;
		}

		public void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public byte[] GetMac()
		{
			return null;
		}

		public int GetOutputSize(int len)
		{
			return 0;
		}

		public int GetUpdateOutputSize(int len)
		{
			return 0;
		}

		public void ProcessAadByte(byte input)
		{
		}

		public void ProcessAadBytes(byte[] inBytes, int inOff, int len)
		{
		}

		private void InitCipher()
		{
		}

		public int ProcessByte(byte input, byte[] output, int outOff)
		{
			return 0;
		}

		public int ProcessBytes(byte[] input, int inOff, int len, byte[] output, int outOff)
		{
			return 0;
		}

		private void ProcessBlock(byte[] buf, int bufOff, byte[] output, int outOff)
		{
		}

		public int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public void Reset()
		{
		}

		private void Reset(bool clearMac)
		{
		}

		private void ProcessPartial(byte[] buf, int off, int len, byte[] output, int outOff)
		{
		}

		private void gHASH(byte[] Y, byte[] b, int len)
		{
		}

		private void gHASHBlock(byte[] Y, byte[] b)
		{
		}

		private void gHASHBlock(byte[] Y, byte[] b, int off)
		{
		}

		private void gHASHPartial(byte[] Y, byte[] b, int off, int len)
		{
		}

		private void GetNextCtrBlock(byte[] block)
		{
		}

		private void CheckStatus()
		{
		}

		public void Tables8kGcmMultiplier_Init(byte[] H)
		{
		}

		public void Tables8kGcmMultiplier_MultiplyH(byte[] x)
		{
		}
	}
}
