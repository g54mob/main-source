using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.LZW
{
	public class LzwInputStream : Stream
	{
		private const int TBL_CLEAR = 256;

		private const int TBL_FIRST = 257;

		private const int EXTRA = 64;

		private Stream baseInputStream;

		private bool isStreamOwner;

		private bool isClosed;

		private readonly byte[] one;

		private bool headerParsed;

		private int[] tabPrefix;

		private byte[] tabSuffix;

		private readonly int[] zeros;

		private byte[] stack;

		private bool blockMode;

		private int nBits;

		private int maxBits;

		private int maxMaxCode;

		private int maxCode;

		private int bitMask;

		private int oldCode;

		private byte finChar;

		private int stackP;

		private int freeEnt;

		private readonly byte[] data;

		private int bitPos;

		private int end;

		private int got;

		private bool eof;

		public bool IsStreamOwner
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length => 0L;

		public override long Position
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public LzwInputStream(Stream baseInputStream)
		{
		}

		public override int ReadByte()
		{
			return 0;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		private int ResetBuf(int bitPosition)
		{
			return 0;
		}

		private void Fill()
		{
		}

		private void ParseHeader()
		{
		}

		public override void Flush()
		{
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public override void WriteByte(byte value)
		{
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return null;
		}

		public override void Close()
		{
		}
	}
}
