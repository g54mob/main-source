using BestHTTP.Decompression.Zlib;
using BestHTTP.Extensions;
using BestHTTP.WebSocket.Frames;

namespace BestHTTP.WebSocket.Extensions
{
	public sealed class PerMessageCompression : IExtension
	{
		public const int MinDataLengthToCompressDefault = 256;

		private static readonly byte[] Trailer;

		private BufferPoolMemoryStream compressorOutputStream;

		private DeflateStream compressorDeflateStream;

		private BufferPoolMemoryStream decompressorInputStream;

		private BufferPoolMemoryStream decompressorOutputStream;

		private DeflateStream decompressorDeflateStream;

		public bool ClientNoContextTakeover { get; private set; }

		public bool ServerNoContextTakeover { get; private set; }

		public int ClientMaxWindowBits { get; private set; }

		public int ServerMaxWindowBits { get; private set; }

		public CompressionLevel Level { get; private set; }

		public int MinimumDataLegthToCompress { get; set; }

		public PerMessageCompression()
		{
		}

		public PerMessageCompression(CompressionLevel level, bool clientNoContextTakeover, bool serverNoContextTakeover, int desiredClientMaxWindowBits, int desiredServerMaxWindowBits, int minDatalengthToCompress)
		{
		}

		public void AddNegotiation(HTTPRequest request)
		{
		}

		public bool ParseNegotiation(WebSocketResponse resp)
		{
			return false;
		}

		public byte GetFrameHeader(WebSocketFrame writer, byte inFlag)
		{
			return 0;
		}

		public byte[] Encode(WebSocketFrame writer)
		{
			return null;
		}

		public byte[] Decode(byte header, byte[] data, int length)
		{
			return null;
		}

		private byte[] Compress(byte[] data, int length)
		{
			return null;
		}

		private byte[] Decompress(byte[] data, int length)
		{
			return null;
		}
	}
}
