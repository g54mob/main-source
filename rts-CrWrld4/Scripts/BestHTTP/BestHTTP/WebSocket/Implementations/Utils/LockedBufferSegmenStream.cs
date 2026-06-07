using BestHTTP.Extensions;
using BestHTTP.PlatformSupport.Memory;

namespace BestHTTP.WebSocket.Implementations.Utils
{
	public sealed class LockedBufferSegmenStream : BufferSegmentStream
	{
		public bool IsClosed { get; private set; }

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override void Write(BufferSegment bufferSegment)
		{
		}

		public override void Reset()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override void Close()
		{
		}
	}
}
