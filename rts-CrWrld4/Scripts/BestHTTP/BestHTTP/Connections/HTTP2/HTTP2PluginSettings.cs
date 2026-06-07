using System;

namespace BestHTTP.Connections.HTTP2
{
	public sealed class HTTP2PluginSettings
	{
		public uint HeaderTableSize;

		public uint MaxConcurrentStreams;

		public uint InitialStreamWindowSize;

		public uint InitialConnectionWindowSize;

		public uint MaxFrameSize;

		public uint MaxHeaderListSize;

		public TimeSpan MaxIdleTime;

		public TimeSpan PingFrequency;

		public bool EnableConnectProtocol;

		public WebSocketOverHTTP2Settings WebSocketOverHTTP2Settings;
	}
}
