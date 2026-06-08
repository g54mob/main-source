using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal.Util
{
	public abstract class DecryptStream : WrapperStream
	{
		protected CryptoStream CryptoStream { get; set; }

		protected IDecryptionWrapper Algorithm { get; set; }

		public override bool CanSeek => false;

		public override long Position
		{
			get
			{
				throw new NotSupportedException("DecryptStream does not support seeking");
			}
			set
			{
				throw new NotSupportedException("DecryptStream does not support seeking");
			}
		}

		protected DecryptStream(Stream baseStream)
			: base(baseStream)
		{
			ValidateBaseStream();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return CryptoStream.Read(buffer, offset, count);
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return await CryptoStream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("DecryptStream does not support seeking");
		}

		private void ValidateBaseStream()
		{
			if (!base.BaseStream.CanRead && !base.BaseStream.CanWrite)
			{
				throw new InvalidDataException("DecryptStream does not support base streams that are not capable of reading or writing");
			}
		}
	}
	public class DecryptStream<T> : DecryptStream where T : class, IDecryptionWrapper, new()
	{
		public DecryptStream(Stream baseStream, byte[] envelopeKey, byte[] IV)
			: base(baseStream)
		{
			base.Algorithm = new T();
			base.Algorithm.SetDecryptionData(envelopeKey, IV);
			base.Algorithm.CreateDecryptor();
			base.CryptoStream = new CryptoStream(base.BaseStream, base.Algorithm.Transformer, CryptoStreamMode.Read);
		}
	}
}
