using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Prng.Drbg;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Prng
{
	public class SP800SecureRandomBuilder
	{
		private class HashDrbgProvider : IDrbgProvider
		{
			private readonly IDigest mDigest;

			private readonly byte[] mNonce;

			private readonly byte[] mPersonalizationString;

			private readonly int mSecurityStrength;

			public HashDrbgProvider(IDigest digest, byte[] nonce, byte[] personalizationString, int securityStrength)
			{
			}

			public ISP80090Drbg Get(IEntropySource entropySource)
			{
				return null;
			}
		}

		private class HMacDrbgProvider : IDrbgProvider
		{
			private readonly IMac mHMac;

			private readonly byte[] mNonce;

			private readonly byte[] mPersonalizationString;

			private readonly int mSecurityStrength;

			public HMacDrbgProvider(IMac hMac, byte[] nonce, byte[] personalizationString, int securityStrength)
			{
			}

			public ISP80090Drbg Get(IEntropySource entropySource)
			{
				return null;
			}
		}

		private class CtrDrbgProvider : IDrbgProvider
		{
			private readonly IBlockCipher mBlockCipher;

			private readonly int mKeySizeInBits;

			private readonly byte[] mNonce;

			private readonly byte[] mPersonalizationString;

			private readonly int mSecurityStrength;

			public CtrDrbgProvider(IBlockCipher blockCipher, int keySizeInBits, byte[] nonce, byte[] personalizationString, int securityStrength)
			{
			}

			public ISP80090Drbg Get(IEntropySource entropySource)
			{
				return null;
			}
		}

		private readonly SecureRandom mRandom;

		private readonly IEntropySourceProvider mEntropySourceProvider;

		private byte[] mPersonalizationString;

		private int mSecurityStrength;

		private int mEntropyBitsRequired;

		public SP800SecureRandomBuilder()
		{
		}

		public SP800SecureRandomBuilder(SecureRandom entropySource, bool predictionResistant)
		{
		}

		public SP800SecureRandomBuilder(IEntropySourceProvider entropySourceProvider)
		{
		}

		public SP800SecureRandomBuilder SetPersonalizationString(byte[] personalizationString)
		{
			return null;
		}

		public SP800SecureRandomBuilder SetSecurityStrength(int securityStrength)
		{
			return null;
		}

		public SP800SecureRandomBuilder SetEntropyBitsRequired(int entropyBitsRequired)
		{
			return null;
		}

		public SP800SecureRandom BuildHash(IDigest digest, byte[] nonce, bool predictionResistant)
		{
			return null;
		}

		public SP800SecureRandom BuildCtr(IBlockCipher cipher, int keySizeInBits, byte[] nonce, bool predictionResistant)
		{
			return null;
		}

		public SP800SecureRandom BuildHMac(IMac hMac, byte[] nonce, bool predictionResistant)
		{
			return null;
		}
	}
}
