using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Util.Internal;

namespace Amazon.Runtime.Internal.Util
{
	public abstract class HashStream : WrapperStream
	{
		protected IHashingWrapper Algorithm { get; set; }

		protected bool FinishedHashing => CalculatedHash != null;

		protected long CurrentPosition { get; private set; }

		public byte[] CalculatedHash { get; protected set; }

		public byte[] ExpectedHash { get; private set; }

		public long ExpectedLength { get; protected set; }

		public override bool CanSeek => false;

		public override long Position
		{
			get
			{
				throw new NotSupportedException("HashStream does not support seeking");
			}
			set
			{
				throw new NotSupportedException("HashStream does not support seeking");
			}
		}

		public override long Length => ExpectedLength;

		protected HashStream(Stream baseStream, byte[] expectedHash, long expectedLength)
			: base(baseStream)
		{
			ExpectedHash = expectedHash;
			ExpectedLength = expectedLength;
			ValidateBaseStream();
			Reset();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num = base.Read(buffer, offset, count);
			CurrentPosition += num;
			if (!FinishedHashing)
			{
				Algorithm.AppendBlock(buffer, offset, num);
			}
			if (num == 0)
			{
				CalculateHash();
			}
			return num;
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			int num = await base.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			CurrentPosition += num;
			if (!FinishedHashing)
			{
				Algorithm.AppendBlock(buffer, offset, num);
			}
			if (num == 0)
			{
				CalculateHash();
			}
			return num;
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				CalculateHash();
				if (disposing && Algorithm != null)
				{
					Algorithm.Dispose();
					Algorithm = null;
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("HashStream does not support seeking");
		}

		public virtual void CalculateHash()
		{
			if (!FinishedHashing)
			{
				if (ExpectedLength < 0 || CurrentPosition == ExpectedLength)
				{
					CalculatedHash = Algorithm.AppendLastBlock(ArrayEx.Empty<byte>());
				}
				else
				{
					CalculatedHash = ArrayEx.Empty<byte>();
				}
				if (CalculatedHash.Length != 0 && ExpectedHash != null && ExpectedHash.Length != 0 && !CompareHashes(ExpectedHash, CalculatedHash))
				{
					throw new AmazonClientException("Expected hash not equal to calculated hash");
				}
			}
		}

		public void Reset()
		{
			CurrentPosition = 0L;
			CalculatedHash = null;
			if (Algorithm != null)
			{
				Algorithm.Clear();
			}
			if (base.BaseStream is HashStream hashStream)
			{
				hashStream.Reset();
			}
		}

		private void ValidateBaseStream()
		{
			if (!base.BaseStream.CanRead && !base.BaseStream.CanWrite)
			{
				throw new InvalidDataException("HashStream does not support base streams that are not capable of reading or writing");
			}
		}

		protected static bool CompareHashes(byte[] expected, byte[] actual)
		{
			if (expected == actual)
			{
				return true;
			}
			if (expected == null || actual == null)
			{
				return expected == actual;
			}
			if (expected.Length != actual.Length)
			{
				return false;
			}
			for (int i = 0; i < expected.Length; i++)
			{
				if (expected[i] != actual[i])
				{
					return false;
				}
			}
			return true;
		}
	}
	public class HashStream<T> : HashStream where T : IHashingWrapper, new()
	{
		public HashStream(Stream baseStream, byte[] expectedHash, long expectedLength)
			: base(baseStream, expectedHash, expectedLength)
		{
			base.Algorithm = new T();
		}
	}
}
