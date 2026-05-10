using System;
using System.Numerics;
using System.Security.Cryptography;

namespace Photon.SocketServer.Security
{
	internal class DiffieHellmanCryptoProvider : ICryptoProvider, IDisposable
	{
		private static readonly BigInteger primeRoot;

		private readonly BigInteger prime;

		private readonly BigInteger secret;

		private readonly BigInteger publicKey;

		private Rijndael crypto;

		private byte[] sharedKey;

		public bool IsInitialized => false;

		public byte[] PublicKey => null;

		public DiffieHellmanCryptoProvider()
		{
		}

		public DiffieHellmanCryptoProvider(byte[] cryptoKey)
		{
		}

		public void DeriveSharedKey(byte[] otherPartyPublicKey)
		{
		}

		private byte[] PhotonBigIntArrayToMsBigIntArray(byte[] array)
		{
			return null;
		}

		private byte[] MsBigIntArrayToPhotonBigIntArray(byte[] array)
		{
			return null;
		}

		public byte[] Encrypt(byte[] data)
		{
			return null;
		}

		public byte[] Encrypt(byte[] data, int offset, int count)
		{
			return null;
		}

		public byte[] Decrypt(byte[] data)
		{
			return null;
		}

		public byte[] Decrypt(byte[] data, int offset, int count)
		{
			return null;
		}

		public void Dispose()
		{
		}

		protected void Dispose(bool disposing)
		{
		}

		private BigInteger CalculatePublicKey()
		{
			return default(BigInteger);
		}

		private BigInteger CalculateSharedKey(BigInteger otherPartyPublicKey)
		{
			return default(BigInteger);
		}

		private BigInteger GenerateRandomSecret(int secretLength)
		{
			return default(BigInteger);
		}
	}
}
