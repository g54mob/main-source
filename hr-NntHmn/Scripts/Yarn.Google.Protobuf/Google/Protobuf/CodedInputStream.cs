using System;
using System.IO;

namespace Google.Protobuf
{
	public sealed class CodedInputStream : IDisposable
	{
		private readonly bool leaveOpen;

		private readonly byte[] buffer;

		private readonly Stream input;

		private ParserInternalState state;

		internal const int DefaultRecursionLimit = 100;

		internal const int DefaultSizeLimit = 2147483647;

		internal const int BufferSize = 4096;

		public long Position => 0L;

		internal uint LastTag => 0u;

		public int SizeLimit => 0;

		public int RecursionLimit => 0;

		internal bool DiscardUnknownFields
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal ExtensionRegistry ExtensionRegistry
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal byte[] InternalBuffer => null;

		internal Stream InternalInputStream => null;

		internal ref ParserInternalState InternalState
		{
			get
			{
				throw null;
			}
		}

		internal bool ReachedLimit => false;

		public bool IsAtEnd => false;

		public CodedInputStream(byte[] buffer)
		{
		}

		public CodedInputStream(byte[] buffer, int offset, int length)
		{
		}

		public CodedInputStream(Stream input)
		{
		}

		public CodedInputStream(Stream input, bool leaveOpen)
		{
		}

		internal CodedInputStream(Stream input, byte[] buffer, int bufferPos, int bufferSize, bool leaveOpen)
		{
		}

		internal CodedInputStream(Stream input, byte[] buffer, int bufferPos, int bufferSize, int sizeLimit, int recursionLimit, bool leaveOpen)
		{
		}

		public static CodedInputStream CreateWithLimits(Stream input, int sizeLimit, int recursionLimit)
		{
			return null;
		}

		public void Dispose()
		{
		}

		internal void CheckReadEndOfStreamTag()
		{
		}

		public uint PeekTag()
		{
			return 0u;
		}

		public uint ReadTag()
		{
			return 0u;
		}

		public void SkipLastField()
		{
		}

		internal void SkipGroup(uint startGroupTag)
		{
		}

		public double ReadDouble()
		{
			return 0.0;
		}

		public float ReadFloat()
		{
			return 0f;
		}

		public ulong ReadUInt64()
		{
			return 0uL;
		}

		public long ReadInt64()
		{
			return 0L;
		}

		public int ReadInt32()
		{
			return 0;
		}

		public ulong ReadFixed64()
		{
			return 0uL;
		}

		public uint ReadFixed32()
		{
			return 0u;
		}

		public bool ReadBool()
		{
			return false;
		}

		public string ReadString()
		{
			return null;
		}

		public void ReadMessage(IMessage builder)
		{
		}

		public void ReadGroup(IMessage builder)
		{
		}

		public ByteString ReadBytes()
		{
			return null;
		}

		public uint ReadUInt32()
		{
			return 0u;
		}

		public int ReadEnum()
		{
			return 0;
		}

		public int ReadSFixed32()
		{
			return 0;
		}

		public long ReadSFixed64()
		{
			return 0L;
		}

		public int ReadSInt32()
		{
			return 0;
		}

		public long ReadSInt64()
		{
			return 0L;
		}

		public int ReadLength()
		{
			return 0;
		}

		public bool MaybeConsumeTag(uint tag)
		{
			return false;
		}

		internal uint ReadRawVarint32()
		{
			return 0u;
		}

		internal static uint ReadRawVarint32(Stream input)
		{
			return 0u;
		}

		internal ulong ReadRawVarint64()
		{
			return 0uL;
		}

		internal uint ReadRawLittleEndian32()
		{
			return 0u;
		}

		internal ulong ReadRawLittleEndian64()
		{
			return 0uL;
		}

		internal int PushLimit(int byteLimit)
		{
			return 0;
		}

		internal void PopLimit(int oldLimit)
		{
		}

		internal byte[] ReadRawBytes(int size)
		{
			return null;
		}

		public void ReadRawMessage(IMessage message)
		{
		}
	}
}
