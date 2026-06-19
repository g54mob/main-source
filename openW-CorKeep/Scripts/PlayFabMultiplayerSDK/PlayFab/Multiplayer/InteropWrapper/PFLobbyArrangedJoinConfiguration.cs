using System;
using System.Collections.Generic;
using System.Linq;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyArrangedJoinConfiguration
	{
		public uint MaxMemberCount { get; set; }

		public PFLobbyOwnerMigrationPolicy OwnerMigrationPolicy { get; set; }

		public PFLobbyAccessPolicy AccessPolicy { get; set; }

		public IDictionary<string, string> MemberProperties { get; set; }

		internal unsafe PlayFab.Multiplayer.Interop.PFLobbyArrangedJoinConfiguration* ToPointer(DisposableCollection disposableCollection)
		{
			PlayFab.Multiplayer.Interop.PFLobbyArrangedJoinConfiguration interopStruct = default(PlayFab.Multiplayer.Interop.PFLobbyArrangedJoinConfiguration);
			interopStruct.maxMemberCount = MaxMemberCount;
			interopStruct.ownerMigrationPolicy = (PlayFab.Multiplayer.Interop.PFLobbyOwnerMigrationPolicy)OwnerMigrationPolicy;
			interopStruct.accessPolicy = (PlayFab.Multiplayer.Interop.PFLobbyAccessPolicy)AccessPolicy;
			interopStruct.memberPropertyCount = ((MemberProperties != null) ? Convert.ToUInt32(MemberProperties.Count) : 0u);
			interopStruct.memberPropertyKeys = (sbyte**)((interopStruct.memberPropertyCount != 0) ? ((void*)Converters.StringArrayToUTF8StringArray(MemberProperties.Keys.ToArray(), disposableCollection, out var count)) : null);
			interopStruct.memberPropertyValues = (sbyte**)((interopStruct.memberPropertyCount != 0) ? ((void*)Converters.StringArrayToUTF8StringArray(MemberProperties.Values.ToArray(), disposableCollection, out count)) : null);
			return (PlayFab.Multiplayer.Interop.PFLobbyArrangedJoinConfiguration*)(void*)Converters.StructToPtr(interopStruct, disposableCollection);
		}
	}
}
