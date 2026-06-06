using System;
using System.Diagnostics;
using System.IO;

namespace Pathfinding.Ionic.BZip2
{
	public class BZip2OutputStream : Stream
	{
		[Flags]
		private enum TraceBits : uint
		{
			None = 0u,
			Crc = 1u,
			Write = 2u,
			All = uint.MaxValue
		}

		private int totalBytesWrittenIn;

		private bool leaveOpen;

		private BZip2Compressor compressor;

		private uint combinedCRC;

		private Stream output;

		private BitWriter bw;

		private int blockSize100k;

		private TraceBits desiredTrace;

		public int BlockSize => 0;

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

		public BZip2OutputStream(Stream output)
		{
		}

		public BZip2OutputStream(Stream output, int blockSize)
		{
		}

		public BZip2OutputStream(Stream output, bool leaveOpen)
		{
		}

		public BZip2OutputStream(Stream output, int blockSize, bool leaveOpen)
		{
		}

		public override void Close()
		{
		}

		public override void Flush()
		{
		}

		private void EmitHeader()
		{
		}

		private void EmitTrailer()
		{
		}

		private void Finish()
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		[Conditional("Trace")]
		private void TraceOutput(TraceBits bits, string format, params object[] varParams)
		{
		}
	}
}
