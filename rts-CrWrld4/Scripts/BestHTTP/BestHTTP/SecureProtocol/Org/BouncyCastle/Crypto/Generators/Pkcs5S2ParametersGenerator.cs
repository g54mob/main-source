namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class Pkcs5S2ParametersGenerator : PbeParametersGenerator
	{
		private readonly IMac hMac;

		private readonly byte[] state;

		public Pkcs5S2ParametersGenerator()
		{
		}

		public Pkcs5S2ParametersGenerator(IDigest digest)
		{
		}

		private void F(byte[] S, int c, byte[] iBuf, byte[] outBytes, int outOff)
		{
		}

		private byte[] GenerateDerivedKey(int dkLen)
		{
			return null;
		}

		public override ICipherParameters GenerateDerivedParameters(int keySize)
		{
			return null;
		}

		public override ICipherParameters GenerateDerivedParameters(string algorithm, int keySize)
		{
			return null;
		}

		public override ICipherParameters GenerateDerivedParameters(int keySize, int ivSize)
		{
			return null;
		}

		public override ICipherParameters GenerateDerivedParameters(string algorithm, int keySize, int ivSize)
		{
			return null;
		}

		public override ICipherParameters GenerateDerivedMacParameters(int keySize)
		{
			return null;
		}
	}
}
