using BestHTTP.PlatformSupport.IL2CPP;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Macs
{
	[Il2CppEagerStaticClassConstruction]
	public sealed class Poly1305 : IMac
	{
		private const int BlockSize = 16;

		private readonly IBlockCipher cipher;

		private readonly byte[] singleByte;

		private uint r0;

		private uint r1;

		private uint r2;

		private uint r3;

		private uint r4;

		private uint s1;

		private uint s2;

		private uint s3;

		private uint s4;

		private uint k0;

		private uint k1;

		private uint k2;

		private uint k3;

		private byte[] currentBlock;

		private int currentBlockOffset;

		private uint h0;

		private uint h1;

		private uint h2;

		private uint h3;

		private uint h4;

		public string AlgorithmName => null;

		public Poly1305()
		{
		}

		public Poly1305(IBlockCipher cipher)
		{
		}

		public void Init(ICipherParameters parameters)
		{
		}

		private void SetKey(byte[] key, byte[] nonce)
		{
		}

		public int GetMacSize()
		{
			return 0;
		}

		public void Update(byte input)
		{
		}

		public void BlockUpdate(byte[] input, int inOff, int len)
		{
		}

		public int DoFinal(byte[] output, int outOff)
		{
			return 0;
		}

		public void Reset()
		{
		}

		private static ulong mul32x32_64(uint i1, uint i2)
		{
			return 0uL;
		}
	}
}
