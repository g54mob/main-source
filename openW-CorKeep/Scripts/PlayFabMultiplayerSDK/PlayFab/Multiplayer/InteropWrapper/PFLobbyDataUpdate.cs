using System;
using System.Collections.Generic;
using System.Linq;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyDataUpdate
	{
		public PFEntityKey NewOwner { get; set; }

		public uint? MaxMemberCount { get; set; }

		public LobbyAccessPolicy? AccessPolicy { get; set; }

		public LobbyMembershipLock? MembershipLock { get; set; }

		public IDictionary<string, string> SearchProperties { get; set; }

		public IDictionary<string, string> LobbyProperties { get; set; }

		public PFLobbyDataUpdate()
		{
			LobbyProperties = new Dictionary<string, string>();
		}

		internal unsafe PFLobbyDataUpdate(PlayFab.Multiplayer.Interop.PFLobbyDataUpdate interopStruct)
		{
			NewOwner = new PFEntityKey(interopStruct.newOwner);
			MaxMemberCount = Converters.PtrToStruct<uint>((IntPtr)interopStruct.maxMemberCount);
			AccessPolicy = Converters.PtrToStruct<LobbyAccessPolicy>((IntPtr)interopStruct.accessPolicy);
			MembershipLock = Converters.PtrToStruct<LobbyMembershipLock>((IntPtr)interopStruct.membershipLock);
			string[] lobbyPropertyKeys = Converters.StringPtrToArray(interopStruct.lobbyPropertyKeys, interopStruct.lobbyPropertyCount);
			string[] lobbyPropertyValues = Converters.StringPtrToArray(interopStruct.lobbyPropertyValues, interopStruct.lobbyPropertyCount);
			if (lobbyPropertyKeys.Length == lobbyPropertyValues.Length)
			{
				LobbyProperties = Enumerable.Range(0, lobbyPropertyKeys.Length).ToDictionary((int i) => lobbyPropertyKeys[i], (int i) => lobbyPropertyValues[i]);
				return;
			}
			throw new IndexOutOfRangeException("lobbyPropertyKeys and lobbyPropertyValues don't have same length");
		}

		internal unsafe PlayFab.Multiplayer.Interop.PFLobbyDataUpdate* ToPointer(DisposableCollection disposableCollection)
		{
			PlayFab.Multiplayer.Interop.PFLobbyDataUpdate interopStruct = default(PlayFab.Multiplayer.Interop.PFLobbyDataUpdate);
			interopStruct.newOwner = ((NewOwner != null) ? NewOwner.ToPointer(disposableCollection) : null);
			interopStruct.maxMemberCount = (uint*)(MaxMemberCount.HasValue ? ((void*)Converters.StructToPtr(MaxMemberCount.Value, disposableCollection)) : null);
			interopStruct.accessPolicy = (PlayFab.Multiplayer.Interop.PFLobbyAccessPolicy*)(AccessPolicy.HasValue ? ((void*)Converters.StructToPtr((PlayFab.Multiplayer.Interop.PFLobbyAccessPolicy)AccessPolicy.Value, disposableCollection)) : null);
			interopStruct.membershipLock = (PlayFab.Multiplayer.Interop.PFLobbyMembershipLock*)(MembershipLock.HasValue ? ((void*)Converters.StructToPtr((PlayFab.Multiplayer.Interop.PFLobbyMembershipLock)MembershipLock.Value, disposableCollection)) : null);
			interopStruct.searchPropertyCount = ((SearchProperties != null) ? Convert.ToUInt32(SearchProperties.Count) : 0u);
			interopStruct.searchPropertyKeys = (sbyte**)((interopStruct.searchPropertyCount != 0) ? ((void*)Converters.StringArrayToUTF8StringArray(SearchProperties.Keys.ToArray(), disposableCollection, out var count)) : null);
			interopStruct.searchPropertyValues = (sbyte**)((interopStruct.searchPropertyCount != 0) ? ((void*)Converters.StringArrayToUTF8StringArray(SearchProperties.Values.ToArray(), disposableCollection, out count)) : null);
			interopStruct.lobbyPropertyCount = ((LobbyProperties != null) ? Convert.ToUInt32(LobbyProperties.Count) : 0u);
			interopStruct.lobbyPropertyKeys = (sbyte**)((interopStruct.lobbyPropertyCount != 0) ? ((void*)Converters.StringArrayToUTF8StringArray(LobbyProperties.Keys.ToArray(), disposableCollection, out count)) : null);
			interopStruct.lobbyPropertyValues = (sbyte**)((interopStruct.lobbyPropertyCount != 0) ? ((void*)Converters.StringArrayToUTF8StringArray(LobbyProperties.Values.ToArray(), disposableCollection, out count)) : null);
			return (PlayFab.Multiplayer.Interop.PFLobbyDataUpdate*)(void*)Converters.StructToPtr(interopStruct, disposableCollection);
		}
	}
}
