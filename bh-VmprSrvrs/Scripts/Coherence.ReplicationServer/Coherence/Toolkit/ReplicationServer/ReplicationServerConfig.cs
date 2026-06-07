using Coherence.Common;

namespace Coherence.Toolkit.ReplicationServer
{
	public struct ReplicationServerConfig
	{
		public bool UseLite;

		public Mode Mode;

		public ushort APIPort;

		public ushort UDPPort;

		public ushort SignallingPort;

		public int SendFrequency;

		public int ReceiveFrequency;

		public bool DisableThrottling;

		public uint? DisconnectTimeout;

		public int? PersistenceIntervalSeconds;

		public string PersistenceStoragePath;

		public string Token;

		public LogTargetConfig[] LogTargets;

		public bool UseDebugStreams;

		public int AutoShutdownTimeout;

		public HostAuthority HostAuthority;
	}
}
