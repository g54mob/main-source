using System.IO;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Encryption
{
	internal class ZipAESStream : CryptoStream
	{
		private const int AUTH_CODE_LENGTH = 10;

		private const int CRYPTO_BLOCK_SIZE = 16;

		private Stream _stream;

		private ZipAESTransform _transform;

		private byte[] _slideBuffer;

		private int _slideBufStartPos;

		private int _slideBufFreePos;

		private int _blockAndAuth;

		public ZipAESStream(Stream stream, ZipAESTransform transform, CryptoStreamMode mode)
			: base(null, null, default(CryptoStreamMode))
		{
		}

		public override int Read(byte[] outBuffer, int offset, int count)
		{
			return 0;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}
	}
}
