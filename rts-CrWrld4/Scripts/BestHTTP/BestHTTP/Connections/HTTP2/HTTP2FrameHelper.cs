using System.Collections.Generic;
using System.IO;
using BestHTTP.PlatformSupport.Memory;

namespace BestHTTP.Connections.HTTP2
{
	public static class HTTP2FrameHelper
	{
		public static HTTP2ContinuationFrame ReadContinuationFrame(HTTP2FrameHeaderAndPayload header)
		{
			return default(HTTP2ContinuationFrame);
		}

		public static HTTP2WindowUpdateFrame ReadWindowUpdateFrame(HTTP2FrameHeaderAndPayload header)
		{
			return default(HTTP2WindowUpdateFrame);
		}

		public static HTTP2GoAwayFrame ReadGoAwayFrame(HTTP2FrameHeaderAndPayload header)
		{
			return default(HTTP2GoAwayFrame);
		}

		public static HTTP2PingFrame ReadPingFrame(HTTP2FrameHeaderAndPayload header)
		{
			return default(HTTP2PingFrame);
		}

		public static HTTP2PushPromiseFrame ReadPush_PromiseFrame(HTTP2FrameHeaderAndPayload header)
		{
			return default(HTTP2PushPromiseFrame);
		}

		public static HTTP2RSTStreamFrame ReadRST_StreamFrame(HTTP2FrameHeaderAndPayload header)
		{
			return default(HTTP2RSTStreamFrame);
		}

		public static HTTP2PriorityFrame ReadPriorityFrame(HTTP2FrameHeaderAndPayload header)
		{
			return default(HTTP2PriorityFrame);
		}

		public static HTTP2HeadersFrame ReadHeadersFrame(HTTP2FrameHeaderAndPayload header)
		{
			return default(HTTP2HeadersFrame);
		}

		public static HTTP2DataFrame ReadDataFrame(HTTP2FrameHeaderAndPayload header)
		{
			return default(HTTP2DataFrame);
		}

		public static HTTP2AltSVCFrame ReadAltSvcFrame(HTTP2FrameHeaderAndPayload header)
		{
			return default(HTTP2AltSVCFrame);
		}

		public static void StreamRead(Stream stream, byte[] buffer, int offset, uint count)
		{
		}

		public static PooledBuffer HeaderAsBinary(HTTP2FrameHeaderAndPayload header)
		{
			return default(PooledBuffer);
		}

		public static HTTP2FrameHeaderAndPayload ReadHeader(Stream stream)
		{
			return default(HTTP2FrameHeaderAndPayload);
		}

		public static HTTP2SettingsFrame ReadSettings(HTTP2FrameHeaderAndPayload header)
		{
			return default(HTTP2SettingsFrame);
		}

		public static HTTP2FrameHeaderAndPayload CreateACKSettingsFrame()
		{
			return default(HTTP2FrameHeaderAndPayload);
		}

		public static HTTP2FrameHeaderAndPayload CreateSettingsFrame(List<KeyValuePair<HTTP2Settings, uint>> settings)
		{
			return default(HTTP2FrameHeaderAndPayload);
		}

		public static HTTP2FrameHeaderAndPayload CreatePingFrame(HTTP2PingFlags flags = HTTP2PingFlags.None)
		{
			return default(HTTP2FrameHeaderAndPayload);
		}

		public static HTTP2FrameHeaderAndPayload CreateWindowUpdateFrame(uint streamId, uint windowSizeIncrement)
		{
			return default(HTTP2FrameHeaderAndPayload);
		}

		public static HTTP2FrameHeaderAndPayload CreateGoAwayFrame(uint lastStreamId, HTTP2ErrorCodes error)
		{
			return default(HTTP2FrameHeaderAndPayload);
		}

		public static HTTP2FrameHeaderAndPayload CreateRSTFrame(uint streamId, HTTP2ErrorCodes errorCode)
		{
			return default(HTTP2FrameHeaderAndPayload);
		}
	}
}
