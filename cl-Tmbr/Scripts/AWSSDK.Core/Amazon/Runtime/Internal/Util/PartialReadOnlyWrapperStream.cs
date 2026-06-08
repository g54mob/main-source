using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal.Util
{
	public class PartialReadOnlyWrapperStream : ReadOnlyWrapperStream
	{
		private long _currentPosition;

		private long _size;

		private long RemainingSize => _size - _currentPosition;

		public override long Length => _size;

		public override long Position => _currentPosition;

		public PartialReadOnlyWrapperStream(Stream baseStream, long size)
			: base(baseStream)
		{
			_currentPosition = 0L;
			_size = size;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num = (int)((count < RemainingSize) ? count : RemainingSize);
			if (num <= 0)
			{
				return 0;
			}
			int num2 = base.Read(buffer, offset, num);
			_currentPosition += num2;
			return num2;
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			int num = (int)((count < RemainingSize) ? count : RemainingSize);
			if (num <= 0)
			{
				return 0;
			}
			int num2 = await base.ReadAsync(buffer, offset, num, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			_currentPosition += num2;
			return num2;
		}
	}
}
