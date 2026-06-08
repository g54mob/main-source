using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryPack.Internal
{
	public sealed class ReusableLinkedArrayBufferWriter : IBufferWriter<byte>
	{
		public struct Enumerator : IEnumerator<Memory<byte>>, IEnumerator, IDisposable
		{
			private enum State
			{
				FirstBuffer = 0,
				BuffersInit = 1,
				BuffersIterate = 2,
				Current = 3,
				End = 4
			}

			private ReusableLinkedArrayBufferWriter parent;

			private State state;

			private Memory<byte> current;

			private List<BufferSegment>.Enumerator buffersEnumerator;

			public Memory<byte> Current => default(Memory<byte>);

			object IEnumerator.Current => null;

			public Enumerator(ReusableLinkedArrayBufferWriter parent)
			{
				this.parent = null;
				state = default(State);
				current = default(Memory<byte>);
				buffersEnumerator = default(List<BufferSegment>.Enumerator);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Reset()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CWriteToAndResetAsync_003Ed__19 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder _003C_003Et__builder;

			public ReusableLinkedArrayBufferWriter _003C_003E4__this;

			public Stream stream;

			public CancellationToken cancellationToken;

			private ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter _003C_003Eu__1;

			private List<BufferSegment>.Enumerator _003C_003E7__wrap1;

			private BufferSegment _003Citem_003E5__3;

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

		private const int InitialBufferSize = 262144;

		private static readonly byte[] noUseFirstBufferSentinel;

		private List<BufferSegment> buffers;

		private byte[] firstBuffer;

		private int firstBufferWritten;

		private BufferSegment current;

		private int nextBufferSize;

		private int totalWritten;

		public int TotalWritten => 0;

		private bool UseFirstBuffer => false;

		public ReusableLinkedArrayBufferWriter(bool useFirstBuffer, bool pinned)
		{
		}

		public byte[] DangerousGetFirstBuffer()
		{
			return null;
		}

		public Memory<byte> GetMemory(int sizeHint = 0)
		{
			return default(Memory<byte>);
		}

		public Span<byte> GetSpan(int sizeHint = 0)
		{
			return default(Span<byte>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Advance(int count)
		{
		}

		public byte[] ToArrayAndReset()
		{
			return null;
		}

		public void WriteToAndReset<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[AsyncStateMachine(typeof(_003CWriteToAndResetAsync_003Ed__19))]
		public ValueTask WriteToAndResetAsync(Stream stream, CancellationToken cancellationToken)
		{
			return default(ValueTask);
		}

		public Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ResetCore()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Reset()
		{
		}
	}
}
