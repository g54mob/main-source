using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ATL
{
	internal sealed class BufferedBinaryReader : Stream, IDisposable
	{
		private readonly Stream stream;

		private readonly int bufferDefaultSize;

		private readonly long streamSize;

		private byte[] buffer;

		private long bufferOffset;

		private int cursorPosition;

		private long streamPosition;

		private int bufferSize;

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

		public override long Length => 0L;

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public BufferedBinaryReader(Stream stream)
		{
		}

		private bool fillBuffer(int previousBytesToKeep = 0)
		{
			return false;
		}

		private bool prepareBuffer(int bytesToRead)
		{
			return false;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override int Read([In][Out] byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public bool PeekChar()
		{
			return false;
		}

		public byte[] ReadBytes(int nbBytes)
		{
			return null;
		}

		public char[] ReadChars(int nbBytes)
		{
			return null;
		}

		public new byte ReadByte()
		{
			return 0;
		}

		public sbyte ReadSByte()
		{
			return 0;
		}

		public ushort ReadUInt16()
		{
			return 0;
		}

		public short ReadInt16()
		{
			return 0;
		}

		public uint ReadUInt32()
		{
			return 0u;
		}

		public int ReadInt32()
		{
			return 0;
		}

		public ulong ReadUInt64()
		{
			return 0uL;
		}

		public new void Dispose()
		{
		}

		public override void Flush()
		{
		}

		public override void SetLength(long value)
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}
	}
}
