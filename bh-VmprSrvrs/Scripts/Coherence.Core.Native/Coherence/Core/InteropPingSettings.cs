using Coherence.Common;

namespace Coherence.Core
{
	public struct InteropPingSettings
	{
		public uint MinSamplesForStability;

		public uint MaxStableDeviation;

		public uint MaxSamples;

		public override string ToString()
		{
			return null;
		}

		public InteropPingSettings(ConnectionSettings.PingSettings data)
		{
			MinSamplesForStability = 0u;
			MaxStableDeviation = 0u;
			MaxSamples = 0u;
		}

		public ConnectionSettings.PingSettings Into()
		{
			return null;
		}
	}
}
