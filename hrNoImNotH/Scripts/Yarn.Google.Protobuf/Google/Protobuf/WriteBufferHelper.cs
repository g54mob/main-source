using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace Google.Protobuf
{
	internal struct WriteBufferHelper
	{
		private IBufferWriter<byte> bufferWriter;

		private CodedOutputStream codedOutputStream;

		public CodedOutputStream CodedOutputStream => null;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Initialize(CodedOutputStream codedOutputStream, out WriteBufferHelper instance)
		{
			instance = default(WriteBufferHelper);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Initialize(IBufferWriter<byte> bufferWriter, out WriteBufferHelper instance, out Span<byte> buffer)
		{
			instance = default(WriteBufferHelper);
			buffer = default(Span<byte>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void InitializeNonRefreshable(out WriteBufferHelper instance)
		{
			instance = default(WriteBufferHelper);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void CheckNoSpaceLeft(ref WriterInternalState state)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetSpaceLeft(ref WriterInternalState state)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void RefreshBuffer(ref Span<byte> buffer, ref WriterInternalState state)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Flush(ref Span<byte> buffer, ref WriterInternalState state)
		{
		}
	}
}
