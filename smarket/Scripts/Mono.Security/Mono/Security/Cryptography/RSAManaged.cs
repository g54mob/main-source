using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Mono.Math;

namespace Mono.Security.Cryptography
{
	public class RSAManaged : RSA
	{
		public delegate void KeyGeneratedEventHandler(object sender, EventArgs e);

		private bool isCRTpossible;

		private bool keyBlinding;

		private bool keypairGenerated;

		private bool m_disposed;

		private BigInteger d;

		private BigInteger p;

		private BigInteger q;

		private BigInteger dp;

		private BigInteger dq;

		private BigInteger qInv;

		private BigInteger n;

		private BigInteger e;

		[CompilerGenerated]
		private KeyGeneratedEventHandler KeyGenerated;

		public override int KeySize => 0;

		public override string KeyExchangeAlgorithm => null;

		public bool PublicOnly => false;

		public override string SignatureAlgorithm => null;

		public RSAManaged()
		{
		}

		public RSAManaged(int keySize)
		{
		}

		~RSAManaged()
		{
		}

		private void GenerateKeyPair()
		{
		}

		public override byte[] DecryptValue(byte[] rgb)
		{
			return null;
		}

		public override byte[] EncryptValue(byte[] rgb)
		{
			return null;
		}

		public override RSAParameters ExportParameters(bool includePrivateParameters)
		{
			return default(RSAParameters);
		}

		public override void ImportParameters(RSAParameters parameters)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override string ToXmlString(bool includePrivateParameters)
		{
			return null;
		}

		private byte[] GetPaddedValue(BigInteger value, int length)
		{
			return null;
		}
	}
}
