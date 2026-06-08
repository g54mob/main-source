using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Compression;

namespace Amazon.Runtime.Internal.Util
{
	public class CompressionWrapperStream : WrapperStream
	{
		private Stream _compressionStream;

		private ICompressionAlgorithm _compressionAlgorithm;

		private MemoryStream _outputBufferStream;

		private bool _hitEnd;

		private readonly int _defaultChunkSize = 8192;

		private byte[] _inputBuffer;

		internal override bool HasLength => false;

		public override bool CanSeek => false;

		public override long Position
		{
			get
			{
				throw new NotSupportedException("CompressionWrapperStream does not support seeking");
			}
			set
			{
				throw new NotSupportedException("CompressionWrapperStream does not support seeking");
			}
		}

		public CompressionWrapperStream(Stream baseStream, ICompressionAlgorithm compressionAlgorithm)
			: base(baseStream)
		{
			_compressionAlgorithm = compressionAlgorithm;
			Init();
		}

		private void Init()
		{
			_outputBufferStream = new MemoryStream();
			_compressionStream = _compressionAlgorithm.GetCompressionStream(_outputBufferStream);
			_hitEnd = false;
			_inputBuffer = new byte[_defaultChunkSize];
		}

		public void Reset()
		{
			Init();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (_outputBufferStream.Position < _outputBufferStream.Length)
			{
				return _outputBufferStream.Read(buffer, offset, count);
			}
			_outputBufferStream.SetLength(0L);
			while (_outputBufferStream.Length == 0L && !_hitEnd)
			{
				int num = base.BaseStream.Read(_inputBuffer, 0, _inputBuffer.Length);
				if (num == 0)
				{
					_hitEnd = true;
					_compressionStream.Dispose();
				}
				else
				{
					_compressionStream.Write(_inputBuffer, 0, num);
				}
			}
			_outputBufferStream.Position = 0L;
			return _outputBufferStream.Read(buffer, offset, count);
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (_outputBufferStream.Position < _outputBufferStream.Length)
			{
				return await _outputBufferStream.ReadAsync(buffer, offset, count).ConfigureAwait(continueOnCapturedContext: false);
			}
			_outputBufferStream.SetLength(0L);
			while (_outputBufferStream.Length == 0L && !_hitEnd)
			{
				int num = await base.BaseStream.ReadAsync(_inputBuffer, 0, _inputBuffer.Length).ConfigureAwait(continueOnCapturedContext: false);
				if (num == 0)
				{
					_hitEnd = true;
					_compressionStream.Dispose();
				}
				else
				{
					await _compressionStream.WriteAsync(_inputBuffer, 0, num).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			_outputBufferStream.Position = 0L;
			return await _outputBufferStream.ReadAsync(buffer, offset, count).ConfigureAwait(continueOnCapturedContext: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_compressionStream.Dispose();
				_outputBufferStream.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
