using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal.Util
{
	public abstract class EncryptUploadPartStream : WrapperStream
	{
		private byte[] internalBuffer;

		internal const int InternalEncryptionBlockSize = 16;

		protected IEncryptionWrapper Algorithm { get; set; }

		public byte[] InitializationVector { get; protected set; }

		public override bool CanSeek => true;

		public override long Length
		{
			get
			{
				if (base.Length % 16 == 0L)
				{
					return base.Length;
				}
				return base.Length + 16 - base.Length % 16;
			}
		}

		public override long Position
		{
			get
			{
				return base.BaseStream.Position;
			}
			set
			{
				Seek(value, SeekOrigin.Begin);
			}
		}

		protected EncryptUploadPartStream(Stream baseStream)
			: base(baseStream)
		{
			internalBuffer = new byte[16];
			InitializationVector = new byte[16];
			ValidateBaseStream();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int readBytes = base.Read(buffer, offset, count);
			return Append(buffer, offset, readBytes);
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return Append(buffer, offset, await base.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
		}

		private int Append(byte[] buffer, int offset, int readBytes)
		{
			if (readBytes == 0)
			{
				return 0;
			}
			int num = 0;
			while (num < readBytes)
			{
				num += Algorithm.AppendBlock(buffer, offset, 16, internalBuffer, 0);
				Buffer.BlockCopy(internalBuffer, 0, buffer, offset, 16);
				offset += 16;
			}
			Buffer.BlockCopy(buffer, num - 16, InitializationVector, 0, 16);
			return num;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			long result = base.BaseStream.Seek(offset, origin);
			Algorithm.Reset();
			return result;
		}

		private void ValidateBaseStream()
		{
			if (!base.BaseStream.CanRead && !base.BaseStream.CanWrite)
			{
				throw new InvalidDataException("EncryptStreamForUploadPart does not support base streams that are not capable of reading or writing");
			}
		}
	}
	public class EncryptUploadPartStream<T> : EncryptUploadPartStream where T : class, IEncryptionWrapper, new()
	{
		public EncryptUploadPartStream(Stream baseStream, byte[] key, byte[] IV)
			: base(baseStream)
		{
			base.Algorithm = new T();
			base.Algorithm.SetEncryptionData(key, IV);
			base.Algorithm.CreateEncryptor();
		}
	}
}
