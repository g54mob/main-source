using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
	public class DsaParameterGenerationParameters
	{
		public const int DigitalSignatureUsage = 1;

		public const int KeyEstablishmentUsage = 2;

		private readonly int l;

		private readonly int n;

		private readonly int certainty;

		private readonly SecureRandom random;

		private readonly int usageIndex;

		public virtual int L => 0;

		public virtual int N => 0;

		public virtual int UsageIndex => 0;

		public virtual int Certainty => 0;

		public virtual SecureRandom Random => null;

		public DsaParameterGenerationParameters(int L, int N, int certainty, SecureRandom random)
		{
		}

		public DsaParameterGenerationParameters(int L, int N, int certainty, SecureRandom random, int usageIndex)
		{
		}
	}
}
