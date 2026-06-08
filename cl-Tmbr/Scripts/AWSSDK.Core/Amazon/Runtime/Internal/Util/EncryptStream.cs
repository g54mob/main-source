using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal.Util
{
	public abstract class EncryptStream : WrapperStream
	{
		private const int internalEncryptionBlockSize = 16;

		private byte[] internalBuffer;

		private bool performedLastBlockTransform;

		protected IEncryptionWrapper Algorithm { get; set; }

		public override bool CanSeek => true;

		public override long Length
		{
			get
			{
				if (base.Length % 16 == 0L)
				{
					return base.Length + 16;
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

		protected EncryptStream(Stream baseStream)
			: base(baseStream)
		{
			performedLastBlockTransform = false;
			internalBuffer = new byte[16];
			ValidateBaseStream();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (performedLastBlockTransform)
			{
				return 0;
			}
			long position = Position;
			int count2 = count - count % 16;
			int readBytes = base.Read(buffer, offset, count2);
			return Append(buffer, offset, position, readBytes);
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (performedLastBlockTransform)
			{
				return 0;
			}
			long previousPosition = Position;
			int count2 = count - count % 16;
			return Append(buffer, offset, previousPosition, await base.ReadAsync(buffer, offset, count2, cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
		}

		private int Append(byte[] buffer, int offset, long previousPosition, int readBytes)
		{
			if (readBytes == 0)
			{
				byte[] array = Algorithm.AppendLastBlock(buffer, offset, 0);
				array.CopyTo(buffer, offset);
				performedLastBlockTransform = true;
				return array.Length;
			}
			long num = previousPosition;
			while (Position - num >= 16)
			{
				num += Algorithm.AppendBlock(buffer, offset, 16, internalBuffer, 0);
				Buffer.BlockCopy(internalBuffer, 0, buffer, offset, 16);
				offset += 16;
			}
			if (Length - Position < 16)
			{
				byte[] array2 = Algorithm.AppendLastBlock(buffer, offset, (int)(Position - num));
				array2.CopyTo(buffer, offset);
				num += array2.Length;
				performedLastBlockTransform = true;
			}
			return (int)(num - previousPosition);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			long result = base.BaseStream.Seek(offset, origin);
			performedLastBlockTransform = false;
			Algorithm.Reset();
			return result;
		}

		private void ValidateBaseStream()
		{
			if (!base.BaseStream.CanRead && !base.BaseStream.CanWrite)
			{
				throw new InvalidDataException("EncryptStream does not support base streams that are not capable of reading or writing");
			}
		}
	}
	public class EncryptStream<T> : EncryptStream where T : class, IEncryptionWrapper, new()
	{
		public EncryptStream(Stream baseStream, byte[] key, byte[] IV)
			: base(baseStream)
		{
			base.Algorithm = new T();
			base.Algorithm.SetEncryptionData(key, IV);
			base.Algorithm.CreateEncryptor();
		}
	}
}
