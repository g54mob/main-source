using Coherence.Common;

namespace Coherence.Core
{
	public struct InteropConnectionSettings
	{
		public InteropPingSettings PingSettings;

		public uint DisconnectTimeoutMilliseconds;

		public byte UseDebugStreams;

		public override string ToString()
		{
			return null;
		}

		public InteropConnectionSettings(ConnectionSettings settings)
		{
			PingSettings = default(InteropPingSettings);
			DisconnectTimeoutMilliseconds = 0u;
			UseDebugStreams = 0;
		}

		public ConnectionSettings Into()
		{
			return null;
		}
	}
}
