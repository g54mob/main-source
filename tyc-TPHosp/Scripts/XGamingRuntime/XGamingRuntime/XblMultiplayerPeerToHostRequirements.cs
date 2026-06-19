using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerPeerToHostRequirements
	{
		public ulong LatencyMaximum { get; }

		public ulong BandwidthDownMinimumInKbps { get; }

		public ulong BandwidthUpMinimumInKbps { get; }

		public XblMultiplayerMetrics HostSelectionMetric { get; }

		internal XblMultiplayerPeerToHostRequirements(XGamingRuntime.Interop.XblMultiplayerPeerToHostRequirements interopStruct)
		{
			LatencyMaximum = interopStruct.LatencyMaximum;
			BandwidthDownMinimumInKbps = interopStruct.BandwidthDownMinimumInKbps;
			BandwidthUpMinimumInKbps = interopStruct.BandwidthUpMinimumInKbps;
			HostSelectionMetric = interopStruct.HostSelectionMetric;
		}
	}
}
