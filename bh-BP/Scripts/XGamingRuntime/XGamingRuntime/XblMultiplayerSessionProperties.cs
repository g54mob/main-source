using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerSessionProperties
	{
		public string[] Keywords { get; private set; }

		public XblMultiplayerSessionRestriction JoinRestriction { get; private set; }

		public XblMultiplayerSessionRestriction ReadRestriction { get; private set; }

		public uint[] TurnCollection { get; private set; }

		public string MatchmakingTargetSessionConstantsJson { get; private set; }

		public string SessionCustomPropertiesJson { get; private set; }

		public string MatchmakingServerConnectionString { get; private set; }

		public string[] ServerConnectionStringCandidates { get; private set; }

		public uint[] SessionOwnerMemberIds { get; private set; }

		public XblDeviceToken HostDeviceToken { get; private set; }

		public bool Closed { get; private set; }

		public bool Locked { get; private set; }

		public bool AllocateCloudCompute { get; private set; }

		public bool MatchmakingResubmit { get; private set; }

		internal XblMultiplayerSessionProperties(XGamingRuntime.Interop.XblMultiplayerSessionProperties interopStruct)
		{
		}
	}
}
