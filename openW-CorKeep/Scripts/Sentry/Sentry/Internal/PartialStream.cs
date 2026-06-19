using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Sentry.Internal
{
	internal class PartialStream : Stream
	{
		private readonly Stream _innerStream;

		private readonly long _offset;

		private readonly long? _length;

		private long _position;

		public override bool CanRead => _innerStream.CanRead;

		public override bool CanSeek => _innerStream.CanSeek;

		public override bool CanWrite => false;

		public override long Length => _length ?? (_innerStream.Length - _offset);

		public override long Position
		{
			get
			{
				return _position;
			}
			set
			{
				if (value < 0 || (_length.HasValue && value > _length.Value))
				{
					throw new InvalidOperationException("Invalid position.");
				}
				_position = value;
			}
		}

		public PartialStream(Stream innerStream, long offset, long? length)
		{
			_innerStream = innerStream;
			_offset = offset;
			_length = length;
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			int num = (int)(_length.HasValue ? Math.Min(count, _length.Value - Position) : count);
			if (num <= 0)
			{
				return 0;
			}
			long num2 = _offset + Position;
			if (_innerStream.Position != num2)
			{
				_innerStream.Position = num2;
			}
			int num3 = await _innerStream.ReadAsync(buffer, offset, num, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (_length.HasValue)
			{
				num3 = (int)Math.Min(num3, _length.Value - Position);
			}
			Position += num3;
			return num3;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return origin switch
			{
				SeekOrigin.Begin => Position = offset, 
				SeekOrigin.Current => Position += offset, 
				SeekOrigin.End => Position = Length - offset, 
				_ => throw new ArgumentOutOfRangeException("origin"), 
			};
		}

		[ExcludeFromCodeCoverage]
		public override int Read(byte[] buffer, int offset, int count)
		{
			return ReadAsync(buffer, offset, count, CancellationToken.None).GetAwaiter().GetResult();
		}

		[ExcludeFromCodeCoverage]
		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		[ExcludeFromCodeCoverage]
		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		[ExcludeFromCodeCoverage]
		public override void Flush()
		{
			_innerStream.Flush();
		}
	}
}
