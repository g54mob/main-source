using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerSessionConstants
	{
		public uint MaxMembersInSession { get; private set; }

		public XblMultiplayerSessionVisibility Visibility { get; private set; }

		public ulong[] InitiatorXuids { get; private set; }

		public string CustomJson { get; private set; }

		public string SessionCloudComputePackageConstantsJson { get; private set; }

		public ulong MemberReservedTimeout { get; private set; }

		public ulong MemberInactiveTimeout { get; private set; }

		public ulong MemberReadyTimeout { get; private set; }

		public ulong SessionEmptyTimeout { get; private set; }

		public ulong ArbitrationTimeout { get; private set; }

		public ulong ForfeitTimeout { get; private set; }

		public bool EnableMetricsLatency { get; private set; }

		public bool EnableMetricsBandwidthDown { get; private set; }

		public bool EnableMetricsBandwidthUp { get; private set; }

		public bool EnableMetricsCustom { get; private set; }

		public XblMultiplayerMemberInitialization MemberInitialization { get; private set; }

		public XblMultiplayerPeerToPeerRequirements PeerToPeerRequirements { get; private set; }

		public XblMultiplayerPeerToHostRequirements PeerToHostRequirements { get; private set; }

		public string MeasurementServerAddressesJson { get; private set; }

		public bool ClientMatchmakingCapable { get; private set; }

		public XblMultiplayerSessionCapabilities SessionCapabilities { get; private set; }

		internal XblMultiplayerSessionConstants(XGamingRuntime.Interop.XblMultiplayerSessionConstants interopStruct)
		{
		}
	}
}
