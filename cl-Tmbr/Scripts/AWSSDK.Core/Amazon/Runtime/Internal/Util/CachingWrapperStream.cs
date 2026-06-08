using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal.Util
{
	public class CachingWrapperStream : WrapperStream
	{
		private readonly int? _cacheLimit;

		private int _cachedBytes;

		public List<byte> AllReadBytes { get; private set; }

		public List<byte> LoggableReadBytes
		{
			get
			{
				int count = _cacheLimit ?? AWSConfigs.LoggingConfig.LogResponsesSizeLimit;
				return AllReadBytes.Take(count).ToList();
			}
		}

		public override bool CanSeek => false;

		public override long Position
		{
			get
			{
				throw new NotSupportedException("CachingWrapperStream does not support seeking");
			}
			set
			{
				throw new NotSupportedException("CachingWrapperStream does not support seeking");
			}
		}

		public CachingWrapperStream(Stream baseStream, int? cacheLimit = null)
			: base(baseStream)
		{
			_cacheLimit = cacheLimit;
			AllReadBytes = new List<byte>();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num = base.Read(buffer, offset, count);
			UpdateCacheAfterReading(buffer, offset, num);
			return num;
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			int num = await base.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			UpdateCacheAfterReading(buffer, offset, num);
			return num;
		}

		private void UpdateCacheAfterReading(byte[] buffer, int offset, int numberOfBytesRead)
		{
			if (_cacheLimit.HasValue)
			{
				if (_cachedBytes < _cacheLimit.Value)
				{
					int val = _cacheLimit.Value - _cachedBytes;
					int num = Math.Min(numberOfBytesRead, val);
					byte[] array = new byte[num];
					Array.Copy(buffer, offset, array, 0, num);
					AllReadBytes.AddRange(array);
					_cachedBytes += num;
				}
			}
			else
			{
				byte[] array2 = new byte[numberOfBytesRead];
				Array.Copy(buffer, offset, array2, 0, numberOfBytesRead);
				AllReadBytes.AddRange(array2);
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("CachingWrapperStream does not support seeking");
		}
	}
}
