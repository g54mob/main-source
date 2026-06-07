namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Prng.Drbg
{
	public class CtrSP800Drbg : ISP80090Drbg
	{
		private static readonly long TDEA_RESEED_MAX;

		private static readonly long AES_RESEED_MAX;

		private static readonly int TDEA_MAX_BITS_REQUEST;

		private static readonly int AES_MAX_BITS_REQUEST;

		private readonly IEntropySource mEntropySource;

		private readonly IBlockCipher mEngine;

		private readonly int mKeySizeInBits;

		private readonly int mSeedLength;

		private readonly int mSecurityStrength;

		private byte[] mKey;

		private byte[] mV;

		private long mReseedCounter;

		private bool mIsTdea;

		private static readonly byte[] K_BITS;

		public int BlockSize => 0;

		public CtrSP800Drbg(IBlockCipher engine, int keySizeInBits, int securityStrength, IEntropySource entropySource, byte[] personalizationString, byte[] nonce)
		{
		}

		private void CTR_DRBG_Instantiate_algorithm(byte[] entropy, byte[] nonce, byte[] personalisationString)
		{
		}

		private void CTR_DRBG_Update(byte[] seed, byte[] key, byte[] v)
		{
		}

		private void CTR_DRBG_Reseed_algorithm(byte[] additionalInput)
		{
		}

		private void XOR(byte[] output, byte[] a, byte[] b, int bOff)
		{
		}

		private void AddOneTo(byte[] longer)
		{
		}

		private byte[] GetEntropy()
		{
			return null;
		}

		private byte[] Block_Cipher_df(byte[] inputString, int bitLength)
		{
			return null;
		}

		private void BCC(byte[] bccOut, byte[] k, byte[] iV, byte[] data)
		{
		}

		private void copyIntToByteArray(byte[] buf, int value, int offSet)
		{
		}

		public int Generate(byte[] output, byte[] additionalInput, bool predictionResistant)
		{
			return 0;
		}

		public void Reseed(byte[] additionalInput)
		{
		}

		private bool IsTdea(IBlockCipher cipher)
		{
			return false;
		}

		private int GetMaxSecurityStrength(IBlockCipher cipher, int keySizeInBits)
		{
			return 0;
		}

		private byte[] ExpandKey(byte[] key)
		{
			return null;
		}

		private void PadKey(byte[] keyMaster, int keyOff, byte[] tmp, int tmpOff)
		{
		}
	}
}
