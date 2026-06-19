using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerPeerToPeerRequirements
	{
		public ulong LatencyMaximum { get; }

		public ulong BandwidthMinimumInKbps { get; }

		internal XblMultiplayerPeerToPeerRequirements(XGamingRuntime.Interop.XblMultiplayerPeerToPeerRequirements interopStruct)
		{
			LatencyMaximum = interopStruct.LatencyMaximum;
			BandwidthMinimumInKbps = interopStruct.BandwidthMinimumInKbps;
		}
	}
}
