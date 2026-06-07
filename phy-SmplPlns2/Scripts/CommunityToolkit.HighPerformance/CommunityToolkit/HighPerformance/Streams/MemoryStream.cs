using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace CommunityToolkit.HighPerformance.Streams
{
	internal static class MemoryStream
	{
		public static Stream Create(ReadOnlyMemory<byte> memory, bool isReadOnly)
		{
			if (memory.IsEmpty)
			{
				return new MemoryStream<ArrayOwner>(ArrayOwner.Empty, isReadOnly);
			}
			if (MemoryMarshal.TryGetArray(memory, out var segment))
			{
				return new MemoryStream<ArrayOwner>(new ArrayOwner(segment.Array, segment.Offset, segment.Count), isReadOnly);
			}
			if (MemoryMarshal.TryGetMemoryManager<byte, MemoryManager<byte>>(memory, out var manager, out var start, out var length))
			{
				return new MemoryStream<MemoryManagerOwner>(new MemoryManagerOwner(manager, start, length), isReadOnly);
			}
			return ThrowNotSupportedExceptionForInvalidMemory();
		}

		public static Stream Create(IMemoryOwner<byte> memoryOwner)
		{
			Memory<byte> memory = memoryOwner.Memory;
			if (memory.IsEmpty)
			{
				return new IMemoryOwnerStream<ArrayOwner>(ArrayOwner.Empty, memoryOwner);
			}
			if (MemoryMarshal.TryGetArray((ReadOnlyMemory<byte>)memory, out ArraySegment<byte> segment))
			{
				return new IMemoryOwnerStream<ArrayOwner>(new ArrayOwner(segment.Array, segment.Offset, segment.Count), memoryOwner);
			}
			if (MemoryMarshal.TryGetMemoryManager<byte, MemoryManager<byte>>(memory, out var manager, out var start, out var length))
			{
				return new IMemoryOwnerStream<MemoryManagerOwner>(new MemoryManagerOwner(manager, start, length), memoryOwner);
			}
			return ThrowNotSupportedExceptionForInvalidMemory();
		}

		private static Stream ThrowNotSupportedExceptionForInvalidMemory()
		{
			throw new ArgumentException("The input instance doesn't have a valid underlying data store.");
		}

		public static Exception GetNotSupportedException()
		{
			return new NotSupportedException("The requested operation is not supported for this stream.");
		}

		public static void ThrowNotSupportedException()
		{
			throw GetNotSupportedException();
		}

		public static void ThrowArgumentExceptionForEndOfStreamOnWrite()
		{
			throw new ArgumentException("The current stream can't contain the requested input data.");
		}

		public static long ThrowArgumentExceptionForSeekOrigin()
		{
			throw new ArgumentException("The input seek mode is not valid.", "origin");
		}

		private static void ThrowArgumentOutOfRangeExceptionForPosition()
		{
			throw new ArgumentOutOfRangeException("Position", "The value for the property was not in the valid range.");
		}

		private static void ThrowArgumentNullExceptionForBuffer()
		{
			throw new ArgumentNullException("buffer", "The buffer is null.");
		}

		private static void ThrowArgumentOutOfRangeExceptionForOffset()
		{
			throw new ArgumentOutOfRangeException("offset", "Offset can't be negative.");
		}

		private static void ThrowArgumentOutOfRangeExceptionForCount()
		{
			throw new ArgumentOutOfRangeException("count", "Count can't be negative.");
		}

		private static void ThrowArgumentExceptionForLength()
		{
			throw new ArgumentException("The sum of offset and count can't be larger than the buffer length.", "buffer");
		}

		private static void ThrowObjectDisposedException()
		{
			throw new ObjectDisposedException("source", "The current stream has already been disposed");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidatePosition(long position, int length)
		{
			if ((ulong)position > (ulong)length)
			{
				ThrowArgumentOutOfRangeExceptionForPosition();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidateBuffer(byte[]? buffer, int offset, int count)
		{
			if (buffer == null)
			{
				ThrowArgumentNullExceptionForBuffer();
			}
			if (offset < 0)
			{
				ThrowArgumentOutOfRangeExceptionForOffset();
			}
			if (count < 0)
			{
				ThrowArgumentOutOfRangeExceptionForCount();
			}
			if (offset + count > buffer.Length)
			{
				ThrowArgumentExceptionForLength();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidateCanWrite(bool canWrite)
		{
			if (!canWrite)
			{
				ThrowNotSupportedException();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ValidateDisposed(bool disposed)
		{
			if (disposed)
			{
				ThrowObjectDisposedException();
			}
		}
	}
	internal class MemoryStream<TSource> : Stream where TSource : struct, ISpanOwner
	{
		private readonly bool isReadOnly;

		private TSource source;

		private int position;

		private bool disposed;

		public sealed override bool CanRead
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return !disposed;
			}
		}

		public sealed override bool CanSeek
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return !disposed;
			}
		}

		public sealed override bool CanWrite
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (!isReadOnly)
				{
					return !disposed;
				}
				return false;
			}
		}

		public sealed override long Length
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				MemoryStream.ValidateDisposed(disposed);
				return source.Length;
			}
		}

		public sealed override long Position
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				MemoryStream.ValidateDisposed(disposed);
				return position;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				MemoryStream.ValidateDisposed(disposed);
				MemoryStream.ValidatePosition(value, source.Length);
				position = (int)value;
			}
		}

		public MemoryStream(TSource source, bool isReadOnly)
		{
			this.source = source;
			this.isReadOnly = isReadOnly;
		}

		public sealed override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled(cancellationToken);
			}
			try
			{
				MemoryStream.ValidateDisposed(disposed);
				Memory<byte> memory = source.Memory.Slice(position);
				position += memory.Length;
				return destination.WriteAsync(memory, cancellationToken).AsTask();
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

		public sealed override void Flush()
		{
		}

		public sealed override Task FlushAsync(CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled(cancellationToken);
			}
			return Task.CompletedTask;
		}

		public sealed override Task<int> ReadAsync(byte[]? buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled<int>(cancellationToken);
			}
			try
			{
				return Task.FromResult(Read(buffer, offset, count));
			}
			catch (OperationCanceledException ex)
			{
				return Task.FromCanceled<int>(ex.CancellationToken);
			}
			catch (Exception exception)
			{
				return Task.FromException<int>(exception);
			}
		}

		public sealed override Task WriteAsync(byte[]? buffer, int offset, int count, CancellationToken cancellationToken)
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

		public sealed override long Seek(long offset, SeekOrigin origin)
		{
			MemoryStream.ValidateDisposed(disposed);
			long num = origin switch
			{
				SeekOrigin.Begin => offset, 
				SeekOrigin.Current => position + offset, 
				SeekOrigin.End => source.Length + offset, 
				_ => MemoryStream.ThrowArgumentExceptionForSeekOrigin(), 
			};
			MemoryStream.ValidatePosition(num, source.Length);
			position = (int)num;
			return num;
		}

		public sealed override void SetLength(long value)
		{
			throw MemoryStream.GetNotSupportedException();
		}

		public sealed override int Read(byte[]? buffer, int offset, int count)
		{
			MemoryStream.ValidateDisposed(disposed);
			MemoryStream.ValidateBuffer(buffer, offset, count);
			int num = Math.Min(source.Length - position, count);
			Span<byte> span = source.Span.Slice(position, num);
			Span<byte> destination = buffer.AsSpan(offset, num);
			span.CopyTo(destination);
			position += num;
			return num;
		}

		public sealed override int ReadByte()
		{
			MemoryStream.ValidateDisposed(disposed);
			if (position == source.Length)
			{
				return -1;
			}
			return source.Span[position++];
		}

		public sealed override void Write(byte[]? buffer, int offset, int count)
		{
			MemoryStream.ValidateDisposed(disposed);
			MemoryStream.ValidateCanWrite(CanWrite);
			MemoryStream.ValidateBuffer(buffer, offset, count);
			Span<byte> span = buffer.AsSpan(offset, count);
			Span<byte> destination = source.Span.Slice(position);
			if (!span.TryCopyTo(destination))
			{
				MemoryStream.ThrowArgumentExceptionForEndOfStreamOnWrite();
			}
			position += span.Length;
		}

		public sealed override void WriteByte(byte value)
		{
			MemoryStream.ValidateDisposed(disposed);
			MemoryStream.ValidateCanWrite(CanWrite);
			if (position == source.Length)
			{
				MemoryStream.ThrowArgumentExceptionForEndOfStreamOnWrite();
			}
			source.Span[position++] = value;
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				disposed = true;
				source = default(TSource);
			}
		}

		public sealed override void CopyTo(Stream destination, int bufferSize)
		{
			MemoryStream.ValidateDisposed(disposed);
			Span<byte> span = source.Span.Slice(position);
			position += span.Length;
			destination.Write(span);
		}

		public sealed override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return new ValueTask<int>(Task.FromCanceled<int>(cancellationToken));
			}
			try
			{
				return new ValueTask<int>(Read(buffer.Span));
			}
			catch (OperationCanceledException ex)
			{
				return new ValueTask<int>(Task.FromCanceled<int>(ex.CancellationToken));
			}
			catch (Exception exception)
			{
				return new ValueTask<int>(Task.FromException<int>(exception));
			}
		}

		public sealed override ValueTask WriteAsync(ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken = default(CancellationToken))
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

		public sealed override int Read(Span<byte> buffer)
		{
			MemoryStream.ValidateDisposed(disposed);
			int num = Math.Min(source.Length - position, buffer.Length);
			source.Span.Slice(position, num).CopyTo(buffer);
			position += num;
			return num;
		}

		public sealed override void Write(ReadOnlySpan<byte> buffer)
		{
			MemoryStream.ValidateDisposed(disposed);
			MemoryStream.ValidateCanWrite(CanWrite);
			Span<byte> destination = source.Span.Slice(position);
			if (!buffer.TryCopyTo(destination))
			{
				MemoryStream.ThrowArgumentExceptionForEndOfStreamOnWrite();
			}
			position += buffer.Length;
		}
	}
}
