using System;

namespace XGamingRuntime.Interop
{
	internal struct XblMultiplayerSessionProperties
	{
		private unsafe readonly UTF8StringPtr* Keywords;

		internal readonly SizeT KeywordCount;

		internal readonly XblMultiplayerSessionRestriction JoinRestriction;

		internal readonly XblMultiplayerSessionRestriction ReadRestriction;

		private unsafe readonly uint* TurnCollection;

		internal readonly SizeT TurnCollectionCount;

		internal readonly UTF8StringPtr MatchmakingTargetSessionConstantsJson;

		internal readonly UTF8StringPtr SessionCustomPropertiesJson;

		internal readonly UTF8StringPtr MatchmakingServerConnectionString;

		private unsafe readonly UTF8StringPtr* ServerConnectionStringCandidates;

		internal readonly SizeT ServerConnectionStringCandidatesCount;

		private unsafe readonly uint* SessionOwnerMemberIds;

		internal readonly SizeT SessionOwnerMemberIdsCount;

		internal readonly XblDeviceToken HostDeviceToken;

		internal readonly NativeBool Closed;

		internal readonly NativeBool Locked;

		internal readonly NativeBool AllocateCloudCompute;

		internal readonly NativeBool MatchmakingResubmit;

		internal T[] GetKeywords<T>(Func<UTF8StringPtr, T> ctor)
		{
			return null;
		}

		internal T[] GetTurnCollection<T>(Func<uint, T> ctor)
		{
			return null;
		}

		internal T[] GetServerConnectionStringCandidates<T>(Func<UTF8StringPtr, T> ctor)
		{
			return null;
		}

		internal T[] GetSessionOwnerMemberIds<T>(Func<uint, T> ctor)
		{
			return null;
		}

		internal unsafe XblMultiplayerSessionProperties(XGamingRuntime.XblMultiplayerSessionProperties publicObject, DisposableCollection disposableCollection)
		{
			Keywords = null;
			KeywordCount = default(SizeT);
			JoinRestriction = default(XblMultiplayerSessionRestriction);
			ReadRestriction = default(XblMultiplayerSessionRestriction);
			TurnCollection = null;
			TurnCollectionCount = default(SizeT);
			MatchmakingTargetSessionConstantsJson = default(UTF8StringPtr);
			SessionCustomPropertiesJson = default(UTF8StringPtr);
			MatchmakingServerConnectionString = default(UTF8StringPtr);
			ServerConnectionStringCandidates = null;
			ServerConnectionStringCandidatesCount = default(SizeT);
			SessionOwnerMemberIds = null;
			SessionOwnerMemberIdsCount = default(SizeT);
			HostDeviceToken = default(XblDeviceToken);
			Closed = default(NativeBool);
			Locked = default(NativeBool);
			AllocateCloudCompute = default(NativeBool);
			MatchmakingResubmit = default(NativeBool);
		}
	}
}
