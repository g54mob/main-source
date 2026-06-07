using System.IO;

namespace BestHTTP.Connections.HTTP2
{
	internal sealed class FramesAsStreamView : Stream
	{
		private IFrameDataView view;

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length => 0L;

		public override long Position
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public FramesAsStreamView(IFrameDataView view)
		{
		}

		public void AddFrame(HTTP2FrameHeaderAndPayload frame)
		{
		}

		public override int ReadByte()
		{
			return 0;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override void Close()
		{
		}

		public override void Flush()
		{
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
