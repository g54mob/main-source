namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class Pkcs12ParametersGenerator : PbeParametersGenerator
	{
		public const int KeyMaterial = 1;

		public const int IVMaterial = 2;

		public const int MacMaterial = 3;

		private readonly IDigest digest;

		private readonly int u;

		private readonly int v;

		public Pkcs12ParametersGenerator(IDigest digest)
		{
		}

		private void Adjust(byte[] a, int aOff, byte[] b)
		{
		}

		private byte[] GenerateDerivedKey(int idByte, int n)
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
