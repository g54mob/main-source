using System;

namespace BestHTTP.WebSocket.Frames
{
	public struct RawFrameData : IDisposable
	{
		public byte[] Data;

		public int Length;

		public RawFrameData(byte[] data, int length)
		{
			Data = null;
			Length = 0;
		}

		public void Dispose()
		{
		}
	}
}
