using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace CommunityToolkit.HighPerformance.Streams
{
	internal sealed class IBufferWriterStream<TWriter> : Stream where TWriter : struct, IBufferWriter<byte>
	{
		private readonly TWriter bufferWriter;

		private bool disposed;

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return !disposed;
			}
		}

		public override long Length
		{
			get
			{
				throw MemoryStream.GetNotSupportedException();
			}
		}

		public override long Position
		{
			get
			{
				throw MemoryStream.GetNotSupportedException();
			}
			set
			{
				throw MemoryStream.GetNotSupportedException();
			}
		}

		public IBufferWriterStream(TWriter bufferWriter)
		{
			this.bufferWriter = bufferWriter;
		}

		public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
		{
			throw MemoryStream.GetNotSupportedException();
		}

		public override void Flush()
		{
		}

		public override Task FlushAsync(CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled(cancellationToken);
			}
			return Task.CompletedTask;
		}

		public override Task<int> ReadAsync(byte[]? buffer, int offset, int count, CancellationToken cancellationToken)
		{
			throw MemoryStream.GetNotSupportedException();
		}

		public override Task WriteAsync(byte[]? buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled(cancellationToken);
			}
			try
			{
				Write(buffer, offset, count);
				return Task.CompletedTask;
			}
			catch (OperationCanceledException ex)
			{
				return Task.FromCanceled(ex.CancellationToken);
			}
			catch (Exception exception)
			{
				return Task.FromException(exception);
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw MemoryStream.GetNotSupportedException();
		}

		public override void SetLength(long value)
		{
			throw MemoryStream.GetNotSupportedException();
		}

		public override int Read(byte[]? buffer, int offset, int count)
		{
			throw MemoryStream.GetNotSupportedException();
		}

		public override int ReadByte()
		{
			throw MemoryStream.GetNotSupportedException();
		}

		public override void Write(byte[]? buffer, int offset, int count)
		{
			MemoryStream.ValidateDisposed(disposed);
			MemoryStream.ValidateBuffer(buffer, offset, count);
			Span<byte> span = buffer.AsSpan(offset, count);
			TWriter val = bufferWriter;
			Span<byte> span2 = val.GetSpan(count);
			if (!span.TryCopyTo(span2))
			{
				MemoryStream.ThrowArgumentExceptionForEndOfStreamOnWrite();
			}
			val = bufferWriter;
			val.Advance(count);
		}

		public override void WriteByte(byte value)
		{
			MemoryStream.ValidateDisposed(disposed);
			TWriter val = bufferWriter;
			val.GetSpan(1)[0] = value;
			val = bufferWriter;
			val.Advance(1);
		}

		protected override void Dispose(bool disposing)
		{
			disposed = true;
		}

		public override void CopyTo(Stream destination, int bufferSize)
		{
			throw MemoryStream.GetNotSupportedException();
		}

		public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default(CancellationToken))
		{
			throw MemoryStream.GetNotSupportedException();
		}

		public override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return new ValueTask(Task.FromCanceled(cancellationToken));
			}
			try
			{
				Write(buffer.Span);
				return default(ValueTask);
			}
			catch (OperationCanceledException ex)
			{
				return new ValueTask(Task.FromCanceled(ex.CancellationToken));
			}
			catch (Exception exception)
			{
				return new ValueTask(Task.FromException(exception));
			}
		}

		public override int Read(Span<byte> buffer)
		{
			throw MemoryStream.GetNotSupportedException();
		}

		public override void Write(ReadOnlySpan<byte> buffer)
		{
			MemoryStream.ValidateDisposed(disposed);
			TWriter val = bufferWriter;
			Span<byte> span = val.GetSpan(buffer.Length);
			if (!buffer.TryCopyTo(span))
			{
				MemoryStream.ThrowArgumentExceptionForEndOfStreamOnWrite();
			}
			val = bufferWriter;
			val.Advance(buffer.Length);
		}
	}
}
