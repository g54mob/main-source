using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace Google.Protobuf
{
	public ref struct ParseContext
	{
		internal const int DefaultRecursionLimit = 100;

		internal const int DefaultSizeLimit = 2147483647;

		internal ReadOnlySpan<byte> buffer;

		internal ParserInternalState state;

		internal uint LastTag => 0u;

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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Initialize(ReadOnlySpan<byte> buffer, out ParseContext ctx)
		{
			ctx = default(ParseContext);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Initialize(ReadOnlySpan<byte> buffer, ref ParserInternalState state, out ParseContext ctx)
		{
			ctx = default(ParseContext);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Initialize(CodedInputStream input, out ParseContext ctx)
		{
			ctx = default(ParseContext);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Initialize(ReadOnlySequence<byte> input, out ParseContext ctx)
		{
			ctx = default(ParseContext);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void Initialize(ReadOnlySequence<byte> input, int recursionLimit, out ParseContext ctx)
		{
			ctx = default(ParseContext);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint ReadTag()
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double ReadDouble()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float ReadFloat()
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ulong ReadUInt64()
		{
			return 0uL;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long ReadInt64()
		{
			return 0L;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int ReadInt32()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ulong ReadFixed64()
		{
			return 0uL;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint ReadFixed32()
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ReadBool()
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ReadString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadMessage(IMessage message)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadGroup(IMessage message)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ByteString ReadBytes()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint ReadUInt32()
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int ReadEnum()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int ReadSFixed32()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long ReadSFixed64()
		{
			return 0L;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int ReadSInt32()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long ReadSInt64()
		{
			return 0L;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int ReadLength()
		{
			return 0;
		}

		internal void CopyStateTo(CodedInputStream input)
		{
		}

		internal void LoadStateFrom(CodedInputStream input)
		{
		}
	}
}
