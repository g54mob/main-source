using System;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Encryption
{
	internal class PkzipClassicEncryptCryptoTransform : PkzipClassicCryptoBase, ICryptoTransform, IDisposable
	{
		public bool CanReuseTransform => false;

		public int InputBlockSize => 0;

		public int OutputBlockSize => 0;

		public bool CanTransformMultipleBlocks => false;

		internal PkzipClassicEncryptCryptoTransform(byte[] keyBlock)
		{
		}

		public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			return null;
		}

		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			return 0;
		}

		public void Dispose()
		{
		}
	}
}
