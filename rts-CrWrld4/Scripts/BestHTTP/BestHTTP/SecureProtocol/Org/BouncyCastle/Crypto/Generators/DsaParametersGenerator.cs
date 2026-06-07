using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Math;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Generators
{
	public class DsaParametersGenerator
	{
		private IDigest digest;

		private int L;

		private int N;

		private int certainty;

		private SecureRandom random;

		private bool use186_3;

		private int usageIndex;

		public DsaParametersGenerator()
		{
		}

		public DsaParametersGenerator(IDigest digest)
		{
		}

		public virtual void Init(int size, int certainty, SecureRandom random)
		{
		}

		public virtual void Init(DsaParameterGenerationParameters parameters)
		{
		}

		public virtual DsaParameters GenerateParameters()
		{
			return null;
		}

		protected virtual DsaParameters GenerateParameters_FIPS186_2()
		{
			return null;
		}

		protected virtual BigInteger CalculateGenerator_FIPS186_2(BigInteger p, BigInteger q, SecureRandom r)
		{
			return null;
		}

		protected virtual DsaParameters GenerateParameters_FIPS186_3()
		{
			return null;
		}

		protected virtual BigInteger CalculateGenerator_FIPS186_3_Unverifiable(BigInteger p, BigInteger q, SecureRandom r)
		{
			return null;
		}

		protected virtual BigInteger CalculateGenerator_FIPS186_3_Verifiable(IDigest d, BigInteger p, BigInteger q, byte[] seed, int index)
		{
			return null;
		}

		private static bool IsValidDsaStrength(int strength)
		{
			return false;
		}

		protected static void Hash(IDigest d, byte[] input, byte[] output)
		{
		}

		private static int GetDefaultN(int L)
		{
			return 0;
		}

		protected static void Inc(byte[] buf)
		{
		}
	}
}
