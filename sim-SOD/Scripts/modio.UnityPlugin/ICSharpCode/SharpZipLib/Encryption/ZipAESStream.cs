using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace ICSharpCode.SharpZipLib.Encryption
{
	internal class ZipAESStream : CryptoStream
	{
		private const int AUTH_CODE_LENGTH = 10;

		private const int CRYPTO_BLOCK_SIZE = 16;

		private const int BLOCK_AND_AUTH = 26;

		private Stream _stream;

		private ZipAESTransform _transform;

		private byte[] _slideBuffer;

		private int _slideBufStartPos;

		private int _slideBufFreePos;

		private byte[] _transformBuffer;

		private int _transformBufferFreePos;

		private int _transformBufferStartPos;

		private bool HasBufferedData => false;

		public ZipAESStream(Stream stream, ZipAESTransform transform, CryptoStreamMode mode)
			: base(null, null, default(CryptoStreamMode))
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return null;
		}

		private int ReadAndTransform(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		private int ReadBufferedData(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		private int TransformAndBufferBlock(byte[] buffer, int offset, int count, int blockSize)
		{
			return 0;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}
	}
}
