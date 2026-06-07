namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class Pkcs5S1ParametersGenerator : PbeParametersGenerator
	{
		private readonly IDigest digest;

		public Pkcs5S1ParametersGenerator(IDigest digest)
		{
		}

		private byte[] GenerateDerivedKey()
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
