using System;
using System.Buffers;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using MemoryPack.Internal;

namespace MemoryPack.Compression
{
	public class BrotliCompressor : IBufferWriter<byte>, IDisposable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCopyToAsync_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder _003C_003Et__builder;

			public BrotliCompressor _003C_003E4__this;

			public int bufferSize;

			public Stream stream;

			public CancellationToken cancellationToken;

			private BrotliEncoder _003Cencoder_003E5__2;

			private byte[] _003Cbuffer_003E5__3;

			private OperationStatus _003CfinalStatus_003E5__4;

			private ReusableLinkedArrayBufferWriter.Enumerator _003C_003E7__wrap4;

			private Memory<byte> _003Csource_003E5__6;

			private OperationStatus _003ClastResult_003E5__7;

			private int _003CbytesConsumed_003E5__8;

			private ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private ReusableLinkedArrayBufferWriter? bufferWriter;

		private readonly int quality;

		private readonly int window;

		public BrotliCompressor(CompressionLevel compressionLevel)
		{
		}

		public BrotliCompressor(CompressionLevel compressionLevel, int window)
		{
		}

		public BrotliCompressor(int quality = 1, int window = 22)
		{
		}

		void IBufferWriter<byte>.Advance(int count)
		{
		}

		Memory<byte> IBufferWriter<byte>.GetMemory(int sizeHint)
		{
			return default(Memory<byte>);
		}

		Span<byte> IBufferWriter<byte>.GetSpan(int sizeHint)
		{
			return default(Span<byte>);
		}

		public int GetMaxCompressedLength()
		{
			return 0;
		}

		public byte[] ToArray()
		{
			return null;
		}

		public void CopyTo<TBufferWriter>(in TBufferWriter destBufferWriter) where TBufferWriter : notnull, IBufferWriter<byte>
		{
		}

		[AsyncStateMachine(typeof(_003CCopyToAsync_003Ed__12))]
		public ValueTask CopyToAsync(Stream stream, int bufferSize = 65535, CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(ValueTask);
		}

		public void CopyTo<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> memoryPackWriter) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		private static int CompressCore<TBufferWriter>(ref BrotliEncoder encoder, ReadOnlySpan<byte> source, ref TBufferWriter destBufferWriter, int? initialLength, bool isFinalBlock) where TBufferWriter : IBufferWriter<byte>
		{
			return 0;
		}

		private static int CompressCore<TBufferWriter>(ref BrotliEncoder encoder, ReadOnlySpan<byte> source, ref MemoryPackWriter<TBufferWriter> destBufferWriter, int? initialLength, bool isFinalBlock) where TBufferWriter : class, IBufferWriter<byte>
		{
			return 0;
		}

		public void Dispose()
		{
		}

		private void ThrowIfDisposed()
		{
		}
	}
}
