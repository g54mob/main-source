using System.Collections.Generic;
using System.Text;

namespace UnityWebSocketSharp.Net
{
	internal class ChunkStream
	{
		private int _chunkRead;

		private int _chunkSize;

		private List<Chunk> _chunks;

		private int _count;

		private byte[] _endBuffer;

		private bool _gotIt;

		private WebHeaderCollection _headers;

		private int _offset;

		private StringBuilder _saved;

		private bool _sawCr;

		private InputChunkState _state;

		private int _trailerState;

		internal int Count => 0;

		internal byte[] EndBuffer => null;

		internal int Offset => 0;

		public WebHeaderCollection Headers => null;

		public bool WantsMore => false;

		public ChunkStream(WebHeaderCollection headers)
		{
		}

		private int read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		private InputChunkState seekCrLf(byte[] buffer, ref int offset, int length)
		{
			return default(InputChunkState);
		}

		private InputChunkState setChunkSize(byte[] buffer, ref int offset, int length)
		{
			return default(InputChunkState);
		}

		private InputChunkState setTrailer(byte[] buffer, ref int offset, int length)
		{
			return default(InputChunkState);
		}

		private static void throwProtocolViolation(string message)
		{
		}

		private void write(byte[] buffer, int offset, int length)
		{
		}

		private InputChunkState writeData(byte[] buffer, ref int offset, int length)
		{
			return default(InputChunkState);
		}

		internal void ResetChunkStore()
		{
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public void Write(byte[] buffer, int offset, int count)
		{
		}
	}
}
