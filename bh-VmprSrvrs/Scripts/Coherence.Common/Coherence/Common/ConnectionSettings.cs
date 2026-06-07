using System;

namespace Coherence.Common
{
	[Serializable]
	public class ConnectionSettings
	{
		[Serializable]
		public class PingSettings
		{
			public static PingSettings Default => null;

			public int MinSamplesForStability { get; set; }

			public int MaxStablePingDeviation { get; set; }

			public int MaxSamples { get; set; }
		}

		[Obsolete("use Brisk.DefaultMTU instead.")]
		public const ushort DEFAULT_MTU = 1280;

		public bool UseDebugStreams;

		public PingSettings Ping;

		private float disconnectTimeoutMilliseconds;

		private ushort maximumTransmissionUnit;

		public static ConnectionSettings Default => null;

		public float DisconnectTimeoutMilliseconds
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public TimeSpan DisconnectTimeout
		{
			get
			{
				return default(TimeSpan);
			}
			set
			{
			}
		}

		public ushort Mtu
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}
	}
}
