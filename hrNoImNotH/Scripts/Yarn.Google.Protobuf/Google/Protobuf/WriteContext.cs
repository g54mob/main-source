using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace Google.Protobuf
{
	public ref struct WriteContext
	{
		internal Span<byte> buffer;

		internal WriterInternalState state;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Initialize(ref Span<byte> buffer, ref WriterInternalState state, out WriteContext ctx)
		{
			ctx = default(WriteContext);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Initialize(CodedOutputStream output, out WriteContext ctx)
		{
			ctx = default(WriteContext);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Initialize(IBufferWriter<byte> output, out WriteContext ctx)
		{
			ctx = default(WriteContext);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Initialize(ref Span<byte> buffer, out WriteContext ctx)
		{
			ctx = default(WriteContext);
		}

		public void WriteDouble(double value)
		{
		}

		public void WriteFloat(float value)
		{
		}

		public void WriteUInt64(ulong value)
		{
		}

		public void WriteInt64(long value)
		{
		}

		public void WriteInt32(int value)
		{
		}

		public void WriteFixed64(ulong value)
		{
		}

		public void WriteFixed32(uint value)
		{
		}

		public void WriteBool(bool value)
		{
		}

		public void WriteString(string value)
		{
		}

		public void WriteMessage(IMessage value)
		{
		}

		public void WriteGroup(IMessage value)
		{
		}

		public void WriteBytes(ByteString value)
		{
		}

		public void WriteUInt32(uint value)
		{
		}

		public void WriteEnum(int value)
		{
		}

		public void WriteSFixed32(int value)
		{
		}

		public void WriteSFixed64(long value)
		{
		}

		public void WriteSInt32(int value)
		{
		}

		public void WriteSInt64(long value)
		{
		}

		public void WriteLength(int length)
		{
		}

		public void WriteTag(int fieldNumber, WireFormat.WireType type)
		{
		}

		public void WriteTag(uint tag)
		{
		}

		public void WriteRawTag(byte b1)
		{
		}

		public void WriteRawTag(byte b1, byte b2)
		{
		}

		public void WriteRawTag(byte b1, byte b2, byte b3)
		{
		}

		public void WriteRawTag(byte b1, byte b2, byte b3, byte b4)
		{
		}

		public void WriteRawTag(byte b1, byte b2, byte b3, byte b4, byte b5)
		{
		}

		internal void Flush()
		{
		}

		internal void CheckNoSpaceLeft()
		{
		}

		internal void CopyStateTo(CodedOutputStream output)
		{
		}

		internal void LoadStateFrom(CodedOutputStream output)
		{
		}
	}
}
