using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Security
{
	public sealed class WrapperUtilities
	{
		private enum WrapAlgorithm
		{
			AESWRAP = 0,
			CAMELLIAWRAP = 1,
			DESEDEWRAP = 2,
			RC2WRAP = 3,
			SEEDWRAP = 4,
			DESEDERFC3211WRAP = 5,
			AESRFC3211WRAP = 6,
			CAMELLIARFC3211WRAP = 7
		}

		private class BufferedCipherWrapper : IWrapper
		{
			private readonly IBufferedCipher cipher;

			private bool forWrapping;

			public string AlgorithmName => null;

			public BufferedCipherWrapper(IBufferedCipher cipher)
			{
			}

			public void Init(bool forWrapping, ICipherParameters parameters)
			{
			}

			public byte[] Wrap(byte[] input, int inOff, int length)
			{
				return null;
			}

			public byte[] Unwrap(byte[] input, int inOff, int length)
			{
				return null;
			}
		}

		private static readonly IDictionary algorithms;

		private WrapperUtilities()
		{
		}

		static WrapperUtilities()
		{
		}

		public static IWrapper GetWrapper(DerObjectIdentifier oid)
		{
			return null;
		}

		public static IWrapper GetWrapper(string algorithm)
		{
			return null;
		}

		public static string GetAlgorithmName(DerObjectIdentifier oid)
		{
			return null;
		}
	}
}
