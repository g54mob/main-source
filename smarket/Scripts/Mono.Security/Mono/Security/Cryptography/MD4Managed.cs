namespace Mono.Security.Cryptography
{
	public class MD4Managed : MD4
	{
		private uint[] state;

		private byte[] buffer;

		private uint[] count;

		private uint[] x;

		private byte[] digest;

		public override void Initialize()
		{
		}

		protected override void HashCore(byte[] array, int ibStart, int cbSize)
		{
		}

		protected override byte[] HashFinal()
		{
			return null;
		}

		private byte[] Padding(int nLength)
		{
			return null;
		}

		private uint F(uint x, uint y, uint z)
		{
			return 0u;
		}

		private uint G(uint x, uint y, uint z)
		{
			return 0u;
		}

		private uint H(uint x, uint y, uint z)
		{
			return 0u;
		}

		private uint ROL(uint x, byte n)
		{
			return 0u;
		}

		private void FF(ref uint a, uint b, uint c, uint d, uint x, byte s)
		{
		}

		private void GG(ref uint a, uint b, uint c, uint d, uint x, byte s)
		{
		}

		private void HH(ref uint a, uint b, uint c, uint d, uint x, byte s)
		{
		}

		private void Encode(byte[] output, uint[] input)
		{
		}

		private void Decode(uint[] output, byte[] input, int index)
		{
		}

		private void MD4Transform(uint[] state, byte[] block, int index)
		{
		}
	}
}
