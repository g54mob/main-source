using System;

namespace XGamingRuntime.Interop
{
	public struct XblMultiplayerSessionMember
	{
		internal readonly uint MemberId;

		internal readonly UTF8StringPtr TeamId;

		internal readonly UTF8StringPtr InitialTeam;

		internal readonly XblTournamentArbitrationStatus ArbitrationStatus;

		internal readonly ulong Xuid;

		internal readonly UTF8StringPtr CustomConstantsJson;

		internal readonly UTF8StringPtr SecureDeviceBaseAddress64;

		private unsafe readonly XblMultiplayerSessionMemberRole* Roles;

		internal readonly SizeT RolesCount;

		internal readonly UTF8StringPtr CustomPropertiesJson;

		private unsafe fixed byte Gamertag[48];

		internal readonly XblMultiplayerSessionMemberStatus Status;

		internal readonly NativeBool IsTurnAvailable;

		internal readonly NativeBool IsCurrentUser;

		internal readonly NativeBool InitializeRequested;

		internal readonly UTF8StringPtr MatchmakingResultServerMeasurementsJson;

		internal readonly UTF8StringPtr ServerMeasurementsJson;

		private unsafe readonly uint* MembersInGroupIds;

		internal readonly SizeT MembersInGroupCount;

		internal readonly UTF8StringPtr QosMeasurementsJson;

		internal readonly XblDeviceToken DeviceToken;

		internal readonly XblNetworkAddressTranslationSetting Nat;

		internal readonly uint ActiveTitleId;

		internal readonly uint InitializationEpisode;

		internal readonly TimeT JoinTime;

		internal readonly XblMultiplayerMeasurementFailure InitializationFailureCause;

		private unsafe readonly UTF8StringPtr* Groups;

		internal readonly SizeT GroupsCount;

		private unsafe readonly UTF8StringPtr* Encounters;

		internal readonly SizeT EncountersCount;

		internal readonly XblMultiplayerSessionReference TournamentTeamSessionReference;

		internal readonly IntPtr Internal;

		internal T[] GetRoles<T>(Func<XblMultiplayerSessionMemberRole, T> ctor)
		{
			return null;
		}

		internal string GetGamertag()
		{
			return null;
		}

		internal T[] GetMembersInGroupIds<T>(Func<uint, T> ctor)
		{
			return null;
		}

		internal T[] GetGroups<T>(Func<UTF8StringPtr, T> ctor)
		{
			return null;
		}

		internal T[] GetEncounters<T>(Func<UTF8StringPtr, T> ctor)
		{
			return null;
		}

		internal unsafe XblMultiplayerSessionMember(XGamingRuntime.XblMultiplayerSessionMember publicObject, DisposableCollection disposableCollection)
		{
			MemberId = 0u;
			TeamId = default(UTF8StringPtr);
			InitialTeam = default(UTF8StringPtr);
			ArbitrationStatus = default(XblTournamentArbitrationStatus);
			Xuid = 0uL;
			CustomConstantsJson = default(UTF8StringPtr);
			SecureDeviceBaseAddress64 = default(UTF8StringPtr);
			Roles = null;
			RolesCount = default(SizeT);
			CustomPropertiesJson = default(UTF8StringPtr);
			Status = default(XblMultiplayerSessionMemberStatus);
			IsTurnAvailable = default(NativeBool);
			IsCurrentUser = default(NativeBool);
			InitializeRequested = default(NativeBool);
			MatchmakingResultServerMeasurementsJson = default(UTF8StringPtr);
			ServerMeasurementsJson = default(UTF8StringPtr);
			MembersInGroupIds = null;
			MembersInGroupCount = default(SizeT);
			QosMeasurementsJson = default(UTF8StringPtr);
			DeviceToken = default(XblDeviceToken);
			Nat = default(XblNetworkAddressTranslationSetting);
			ActiveTitleId = 0u;
			InitializationEpisode = 0u;
			JoinTime = default(TimeT);
			InitializationFailureCause = default(XblMultiplayerMeasurementFailure);
			Groups = null;
			GroupsCount = default(SizeT);
			Encounters = null;
			EncountersCount = default(SizeT);
			TournamentTeamSessionReference = default(XblMultiplayerSessionReference);
			Internal = (IntPtr)0;
		}
	}
}
