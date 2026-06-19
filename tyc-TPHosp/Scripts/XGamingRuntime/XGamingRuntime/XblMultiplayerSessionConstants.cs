using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerSessionConstants
	{
		public uint MaxMembersInSession { get; }

		public XblMultiplayerSessionVisibility Visibility { get; }

		public ulong[] InitiatorXuids { get; }

		public string CustomJson { get; }

		public string SessionCloudComputePackageConstantsJson { get; }

		public ulong MemberReservedTimeout { get; }

		public ulong MemberInactiveTimeout { get; }

		public ulong MemberReadyTimeout { get; }

		public ulong SessionEmptyTimeout { get; }

		public ulong ArbitrationTimeout { get; }

		public ulong ForfeitTimeout { get; }

		public bool EnableMetricsLatency { get; }

		public bool EnableMetricsBandwidthDown { get; }

		public bool EnableMetricsBandwidthUp { get; }

		public bool EnableMetricsCustom { get; }

		public XblMultiplayerMemberInitialization MemberInitialization { get; }

		public XblMultiplayerPeerToPeerRequirements PeerToPeerRequirements { get; }

		public XblMultiplayerPeerToHostRequirements PeerToHostRequirements { get; }

		public string MeasurementServerAddressesJson { get; }

		public bool ClientMatchmakingCapable { get; }

		public XblMultiplayerSessionCapabilities SessionCapabilities { get; }

		internal XblMultiplayerSessionConstants(XGamingRuntime.Interop.XblMultiplayerSessionConstants interopStruct)
		{
			MaxMembersInSession = interopStruct.MaxMembersInSession;
			Visibility = interopStruct.Visibility;
			InitiatorXuids = interopStruct.GetInitiatorXuids((ulong x) => x);
			CustomJson = interopStruct.CustomJson.GetString();
			SessionCloudComputePackageConstantsJson = interopStruct.SessionCloudComputePackageConstantsJson.GetString();
			MemberReservedTimeout = interopStruct.MemberReservedTimeout;
			MemberInactiveTimeout = interopStruct.MemberInactiveTimeout;
			MemberReadyTimeout = interopStruct.MemberReadyTimeout;
			SessionEmptyTimeout = interopStruct.SessionEmptyTimeout;
			ArbitrationTimeout = interopStruct.ArbitrationTimeout;
			ForfeitTimeout = interopStruct.ForfeitTimeout;
			EnableMetricsLatency = interopStruct.EnableMetricsLatency.Value;
			EnableMetricsBandwidthDown = interopStruct.EnableMetricsBandwidthDown.Value;
			EnableMetricsBandwidthUp = interopStruct.EnableMetricsBandwidthUp.Value;
			EnableMetricsCustom = interopStruct.EnableMetricsCustom.Value;
			MemberInitialization = interopStruct.GetMemberInitialization((XGamingRuntime.Interop.XblMultiplayerMemberInitialization x) => new XblMultiplayerMemberInitialization(x));
			PeerToPeerRequirements = new XblMultiplayerPeerToPeerRequirements(interopStruct.PeerToPeerRequirements);
			PeerToHostRequirements = new XblMultiplayerPeerToHostRequirements(interopStruct.PeerToHostRequirements);
			MeasurementServerAddressesJson = interopStruct.MeasurementServerAddressesJson.GetString();
			ClientMatchmakingCapable = interopStruct.ClientMatchmakingCapable.Value;
			SessionCapabilities = new XblMultiplayerSessionCapabilities(interopStruct.SessionCapabilities);
		}
	}
}
