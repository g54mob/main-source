using System;
using System.Buffers;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using MemoryPack.Internal;

namespace MemoryPack
{
	public static class MemoryPackSerializer
	{
		private sealed class SerializerWriterThreadStaticState
		{
			public ReusableLinkedArrayBufferWriter BufferWriter;

			public MemoryPackWriterOptionalState OptionalState;

			public void Init(MemoryPackSerializerOptions? options)
			{
			}

			public void Reset()
			{
			}
		}

		public readonly struct StateSnapshot : IDisposable
		{
			private readonly bool _resetReaderState;

			private readonly bool _resetWriterState;

			private readonly SerializerWriterThreadStaticState? _threadStaticState;

			private readonly MemoryPackWriterOptionalState? _threadStaticWriterOptionalState;

			private readonly MemoryPackReaderOptionalState? _threadStaticReaderOptionalState;

			internal StateSnapshot(bool resetReaderState, bool resetWriterState)
			{
				_resetReaderState = false;
				_resetWriterState = false;
				_threadStaticState = null;
				_threadStaticWriterOptionalState = null;
				_threadStaticReaderOptionalState = null;
			}

			public void Dispose()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDeserializeAsync_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder<object> _003C_003Et__builder;

			public Stream stream;

			public CancellationToken cancellationToken;

			public Type type;

			public MemoryPackSerializerOptions options;

			private ReusableReadOnlySequenceBuilder _003Cbuilder_003E5__2;

			private byte[] _003Cbuffer_003E5__3;

			private int _003Coffset_003E5__4;

			private ConfiguredValueTaskAwaitable<int>.ConfiguredValueTaskAwaiter _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDeserializeAsync_003Ed__5<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder<T> _003C_003Et__builder;

			public Stream stream;

			public CancellationToken cancellationToken;

			public MemoryPackSerializerOptions options;

			private ReusableReadOnlySequenceBuilder _003Cbuilder_003E5__2;

			private byte[] _003Cbuffer_003E5__3;

			private int _003Coffset_003E5__4;

			private ConfiguredValueTaskAwaitable<int>.ConfiguredValueTaskAwaiter _003C_003Eu__1;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSerializeAsync_003Ed__21<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder _003C_003Et__builder;

			public T value;

			public MemoryPackSerializerOptions options;

			public Stream stream;

			public CancellationToken cancellationToken;

			private ReusableLinkedArrayBufferWriter _003CtempWriter_003E5__2;

			private ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter _003C_003Eu__1;

			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSerializeAsync_003Ed__9 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder _003C_003Et__builder;

			public Type type;

			public object value;

			public MemoryPackSerializerOptions options;

			public Stream stream;

			public CancellationToken cancellationToken;

			private ReusableLinkedArrayBufferWriter _003CtempWriter_003E5__2;

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

		[ThreadStatic]
		private static MemoryPackReaderOptionalState? threadStaticReaderOptionalState;

		[ThreadStatic]
		private static SerializerWriterThreadStaticState? threadStaticState;

		[ThreadStatic]
		private static MemoryPackWriterOptionalState? threadStaticWriterOptionalState;

		public static T? Deserialize<T>(ReadOnlySpan<byte> buffer, MemoryPackSerializerOptions? options = null)
		{
			return default(T);
		}

		public static int Deserialize<T>(ReadOnlySpan<byte> buffer, ref T? value, MemoryPackSerializerOptions? options = null)
		{
			return 0;
		}

		public static T? Deserialize<T>(in ReadOnlySequence<byte> buffer, MemoryPackSerializerOptions? options = null)
		{
			return default(T);
		}

		public static int Deserialize<T>(in ReadOnlySequence<byte> buffer, ref T? value, MemoryPackSerializerOptions? options = null)
		{
			return 0;
		}

		[AsyncStateMachine(typeof(_003CDeserializeAsync_003Ed__5<>))]
		public static ValueTask<T?> DeserializeAsync<T>(Stream stream, MemoryPackSerializerOptions? options = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(ValueTask<T>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte[] Serialize(Type type, object? value, MemoryPackSerializerOptions? options = null)
		{
			return null;
		}

		public static void Serialize<TBufferWriter>(Type type, in TBufferWriter bufferWriter, object? value, MemoryPackSerializerOptions? options = null) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Serialize<TBufferWriter>(Type type, ref MemoryPackWriter<TBufferWriter> writer, object? value) where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[AsyncStateMachine(typeof(_003CSerializeAsync_003Ed__9))]
		public static ValueTask SerializeAsync(Type type, Stream stream, object? value, MemoryPackSerializerOptions? options = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(ValueTask);
		}

		private static void SerializeToTempWriter(ReusableLinkedArrayBufferWriter bufferWriter, Type type, object? value, MemoryPackSerializerOptions? options)
		{
		}

		public static object? Deserialize(Type type, ReadOnlySpan<byte> buffer, MemoryPackSerializerOptions? options = null)
		{
			return null;
		}

		public static int Deserialize(Type type, ReadOnlySpan<byte> buffer, ref object? value, MemoryPackSerializerOptions? options = null)
		{
			return 0;
		}

		public static object? Deserialize(Type type, in ReadOnlySequence<byte> buffer, MemoryPackSerializerOptions? options = null)
		{
			return null;
		}

		public static int Deserialize(Type type, in ReadOnlySequence<byte> buffer, ref object? value, MemoryPackSerializerOptions? options = null)
		{
			return 0;
		}

		[AsyncStateMachine(typeof(_003CDeserializeAsync_003Ed__15))]
		public static ValueTask<object> DeserializeAsync(Type type, Stream stream, MemoryPackSerializerOptions? options = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(ValueTask<object>);
		}

		public static byte[]? Serialize<T>(in T? value, MemoryPackSerializerOptions? options = null)
		{
			return null;
		}

		public static void Serialize<T, TBufferWriter>(in TBufferWriter bufferWriter, in T? value, MemoryPackSerializerOptions? options = null) where T : notnull where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Serialize<T, TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, in T? value) where T : notnull where TBufferWriter : class, IBufferWriter<byte>
		{
		}

		[AsyncStateMachine(typeof(_003CSerializeAsync_003Ed__21<>))]
		public static ValueTask SerializeAsync<T>(Stream stream, T? value, MemoryPackSerializerOptions? options = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(ValueTask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static StateSnapshot ResetState(bool resetReaderState = true, bool resetWriterState = true)
		{
			return default(StateSnapshot);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static StateSnapshot ResetReaderState()
		{
			return default(StateSnapshot);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static StateSnapshot ResetWriterState()
		{
			return default(StateSnapshot);
		}
	}
}
