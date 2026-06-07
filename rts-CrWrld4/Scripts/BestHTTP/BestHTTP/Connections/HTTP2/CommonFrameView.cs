using System;
using System.Collections.Generic;

namespace BestHTTP.Connections.HTTP2
{
	internal abstract class CommonFrameView : IFrameDataView, IDisposable
	{
		protected List<HTTP2FrameHeaderAndPayload> frames;

		protected int currentFrameIdx;

		protected byte[] data;

		protected uint dataOffset;

		protected uint maxOffset;

		public long Length { get; protected set; }

		public long Position { get; protected set; }

		public abstract void AddFrame(HTTP2FrameHeaderAndPayload frame);

		protected abstract long CalculateDataLengthForFrame(HTTP2FrameHeaderAndPayload frame);

		public virtual int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public virtual int ReadByte()
		{
			return 0;
		}

		protected abstract bool AdvanceFrame();

		public virtual void Dispose()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
