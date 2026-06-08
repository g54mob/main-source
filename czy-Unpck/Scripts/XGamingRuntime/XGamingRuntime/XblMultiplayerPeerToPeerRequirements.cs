using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerPeerToPeerRequirements
	{
		public ulong LatencyMaximum { get; private set; }

		public ulong BandwidthMinimumInKbps { get; private set; }

		internal XblMultiplayerPeerToPeerRequirements(XGamingRuntime.Interop.XblMultiplayerPeerToPeerRequirements interopStruct)
		{
			LatencyMaximum = interopStruct.LatencyMaximum;
			BandwidthMinimumInKbps = interopStruct.BandwidthMinimumInKbps;
		}
	}
}
