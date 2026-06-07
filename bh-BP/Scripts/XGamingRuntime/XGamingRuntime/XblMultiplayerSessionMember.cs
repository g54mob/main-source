using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerSessionMember
	{
		public uint MemberId { get; private set; }

		public string TeamId { get; private set; }

		public string InitialTeam { get; private set; }

		public XblTournamentArbitrationStatus ArbitrationStatus { get; private set; }

		public ulong Xuid { get; private set; }

		public string CustomConstantsJson { get; private set; }

		public string SecureDeviceBaseAddress64 { get; private set; }

		public XblMultiplayerSessionMemberRole[] Roles { get; private set; }

		public string CustomPropertiesJson { get; private set; }

		public string Gamertag { get; private set; }

		public XblMultiplayerSessionMemberStatus Status { get; private set; }

		public bool IsTurnAvailable { get; private set; }

		public bool IsCurrentUser { get; private set; }

		public bool InitializeRequested { get; private set; }

		public string MatchmakingResultServerMeasurementsJson { get; private set; }

		public string ServerMeasurementsJson { get; private set; }

		public uint[] MembersInGroupIds { get; private set; }

		public string QosMeasurementsJson { get; private set; }

		public XblDeviceToken DeviceToken { get; private set; }

		public XblNetworkAddressTranslationSetting Nat { get; private set; }

		public uint ActiveTitleId { get; private set; }

		public uint InitializationEpisode { get; private set; }

		public DateTime JoinTime { get; private set; }

		public XblMultiplayerMeasurementFailure InitializationFailureCause { get; private set; }

		public string[] Groups { get; private set; }

		public string[] Encounters { get; private set; }

		public XblMultiplayerSessionReference TournamentTeamSessionReference { get; private set; }

		public IntPtr Internal { get; private set; }

		internal XblMultiplayerSessionMember(XGamingRuntime.Interop.XblMultiplayerSessionMember interopStruct)
		{
		}
	}
}
