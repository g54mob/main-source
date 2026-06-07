namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Prng.Drbg
{
	public class HMacSP800Drbg : ISP80090Drbg
	{
		private static readonly long RESEED_MAX;

		private static readonly int MAX_BITS_REQUEST;

		private readonly byte[] mK;

		private readonly byte[] mV;

		private readonly IEntropySource mEntropySource;

		private readonly IMac mHMac;

		private readonly int mSecurityStrength;

		private long mReseedCounter;

		public int BlockSize => 0;

		public HMacSP800Drbg(IMac hMac, int securityStrength, IEntropySource entropySource, byte[] personalizationString, byte[] nonce)
		{
		}

		private void hmac_DRBG_Update(byte[] seedMaterial)
		{
		}

		private void hmac_DRBG_Update_Func(byte[] seedMaterial, byte vValue)
		{
		}

		public int Generate(byte[] output, byte[] additionalInput, bool predictionResistant)
		{
			return 0;
		}

		public void Reseed(byte[] additionalInput)
		{
		}

		private byte[] GetEntropy()
		{
			return null;
		}
	}
}
