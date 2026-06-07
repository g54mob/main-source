namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class OpenSslPbeParametersGenerator : PbeParametersGenerator
	{
		private readonly IDigest digest;

		public override void Init(byte[] password, byte[] salt, int iterationCount)
		{
		}

		public virtual void Init(byte[] password, byte[] salt)
		{
		}

		private byte[] GenerateDerivedKey(int bytesNeeded)
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
