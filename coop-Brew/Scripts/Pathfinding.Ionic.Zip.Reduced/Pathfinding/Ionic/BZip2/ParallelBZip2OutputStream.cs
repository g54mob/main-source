using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Pathfinding.Ionic.BZip2
{
	public class ParallelBZip2OutputStream : Stream
	{
		[Flags]
		private enum TraceBits : uint
		{
			None = 0u,
			Crc = 1u,
			Write = 2u,
			All = uint.MaxValue
		}

		private static readonly int BufferPairsPerCore;

		private int _maxWorkers;

		private bool firstWriteDone;

		private int lastFilled;

		private int lastWritten;

		private int latestCompressed;

		private int currentlyFilling;

		private Exception pendingException;

		private bool handlingException;

		private bool emitting;

		private Queue<int> toWrite;

		private Queue<int> toFill;

		private List<WorkItem> pool;

		private object latestLock;

		private object eLock;

		private object outputLock;

		private AutoResetEvent newlyCompressedBlob;

		private long totalBytesWrittenIn;

		private long totalBytesWrittenOut;

		private bool leaveOpen;

		private uint combinedCRC;

		private Stream output;

		private BitWriter bw;

		private int blockSize100k;

		private TraceBits desiredTrace;

		public int MaxWorkers
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

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

		public long BytesWrittenOut => 0L;

		public ParallelBZip2OutputStream(Stream output)
		{
		}

		public ParallelBZip2OutputStream(Stream output, int blockSize)
		{
		}

		public ParallelBZip2OutputStream(Stream output, bool leaveOpen)
		{
		}

		public ParallelBZip2OutputStream(Stream output, int blockSize, bool leaveOpen)
		{
		}

		private void InitializePoolOfWorkItems()
		{
		}

		public override void Close()
		{
		}

		private void FlushOutput(bool lastInput)
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

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		private void EmitPendingBuffers(bool doAll, bool mustWait)
		{
		}

		private void CompressOne(object wi)
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
