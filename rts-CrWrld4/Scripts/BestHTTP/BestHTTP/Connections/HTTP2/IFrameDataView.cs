using System;

namespace BestHTTP.Connections.HTTP2
{
	internal interface IFrameDataView : IDisposable
	{
		long Length { get; }

		long Position { get; }

		void AddFrame(HTTP2FrameHeaderAndPayload frame);

		int ReadByte();

		int Read(byte[] buffer, int offset, int count);
	}
}
