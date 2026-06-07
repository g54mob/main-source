using System.Collections.Generic;

namespace BestHTTP.Connections.HTTP2
{
	public struct HTTP2SettingsFrame
	{
		public readonly HTTP2FrameHeaderAndPayload Header;

		public List<KeyValuePair<HTTP2Settings, uint>> Settings;

		public HTTP2SettingsFlags Flags => default(HTTP2SettingsFlags);

		public HTTP2SettingsFrame(HTTP2FrameHeaderAndPayload header)
		{
			Header = default(HTTP2FrameHeaderAndPayload);
			Settings = null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
