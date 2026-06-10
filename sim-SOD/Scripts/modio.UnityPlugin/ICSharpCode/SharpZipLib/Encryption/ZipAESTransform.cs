using System;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Encryption
{
	internal class ZipAESTransform : ICryptoTransform, IDisposable
	{
		private const int PWD_VER_LENGTH = 2;

		private const int KEY_ROUNDS = 1000;

		private const int ENCRYPT_BLOCK = 16;

		private int _blockSize;

		private readonly ICryptoTransform _encryptor;

		private readonly byte[] _counterNonce;

		private byte[] _encryptBuffer;

		private int _encrPos;

		private byte[] _pwdVerifier;

		private IncrementalHash _hmacsha1;

		private byte[] _authCode;

		private bool _writeMode;

		public byte[] PwdVerifier => null;

		public int InputBlockSize => 0;

		public int OutputBlockSize => 0;

		public bool CanTransformMultipleBlocks => false;

		public bool CanReuseTransform => false;

		public ZipAESTransform(string key, byte[] saltBytes, int blockSize, bool writeMode)
		{
		}

		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			return 0;
		}

		public byte[] GetAuthCode()
		{
			return null;
		}

		public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			return null;
		}

		public void Dispose()
		{
		}
	}
}
