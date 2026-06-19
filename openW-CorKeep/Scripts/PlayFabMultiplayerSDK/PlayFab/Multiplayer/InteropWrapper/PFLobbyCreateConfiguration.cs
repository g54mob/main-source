using System;
using System.Collections.Generic;
using System.Linq;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyCreateConfiguration
	{
		public uint MaxMemberCount { get; set; }

		public PFLobbyOwnerMigrationPolicy OwnerMigrationPolicy { get; set; }

		public PFLobbyAccessPolicy AccessPolicy { get; set; }

		public IDictionary<string, string> SearchProperties { get; set; }

		public IDictionary<string, string> LobbyProperties { get; set; }

		public PFLobbyCreateConfiguration()
		{
			SearchProperties = new Dictionary<string, string>();
			LobbyProperties = new Dictionary<string, string>();
		}

		internal unsafe PFLobbyCreateConfiguration(PlayFab.Multiplayer.Interop.PFLobbyCreateConfiguration interopStruct)
		{
			MaxMemberCount = interopStruct.maxMemberCount;
			OwnerMigrationPolicy = (PFLobbyOwnerMigrationPolicy)interopStruct.ownerMigrationPolicy;
			AccessPolicy = (PFLobbyAccessPolicy)interopStruct.accessPolicy;
			string[] searchPropertyKeys = Converters.StringPtrToArray(interopStruct.searchPropertyKeys, interopStruct.searchPropertyCount);
			string[] searchPropertyValues = Converters.StringPtrToArray(interopStruct.searchPropertyValues, interopStruct.searchPropertyCount);
			if (searchPropertyKeys.Length == searchPropertyValues.Length)
			{
				SearchProperties = Enumerable.Range(0, searchPropertyKeys.Length).ToDictionary((int i) => searchPropertyKeys[i], (int i) => searchPropertyValues[i]);
				string[] lobbyPropertyKeys = Converters.StringPtrToArray(interopStruct.lobbyPropertyKeys, interopStruct.lobbyPropertyCount);
				string[] lobbyPropertyValues = Converters.StringPtrToArray(interopStruct.lobbyPropertyValues, interopStruct.lobbyPropertyCount);
				if (lobbyPropertyKeys.Length == lobbyPropertyValues.Length)
				{
					LobbyProperties = Enumerable.Range(0, lobbyPropertyKeys.Length).ToDictionary((int i) => lobbyPropertyKeys[i], (int i) => lobbyPropertyValues[i]);
					return;
				}
				throw new IndexOutOfRangeException("lobbyPropertyKeys and lobbyPropertyValues don't have same length");
			}
			throw new IndexOutOfRangeException("searchPropertyKeys and searchPropertyValues don't have same length");
		}

		internal unsafe PlayFab.Multiplayer.Interop.PFLobbyCreateConfiguration* ToPointer(DisposableCollection disposableCollection)
		{
			SizeT count;
			return (PlayFab.Multiplayer.Interop.PFLobbyCreateConfiguration*)(void*)Converters.StructToPtr(new PlayFab.Multiplayer.Interop.PFLobbyCreateConfiguration
			{
				maxMemberCount = MaxMemberCount,
				ownerMigrationPolicy = (PlayFab.Multiplayer.Interop.PFLobbyOwnerMigrationPolicy)OwnerMigrationPolicy,
				accessPolicy = (PlayFab.Multiplayer.Interop.PFLobbyAccessPolicy)AccessPolicy,
				searchPropertyCount = Convert.ToUInt32(SearchProperties.Count),
				searchPropertyKeys = (sbyte**)(void*)Converters.StringArrayToUTF8StringArray(SearchProperties.Keys.ToArray(), disposableCollection, out count),
				searchPropertyValues = (sbyte**)(void*)Converters.StringArrayToUTF8StringArray(SearchProperties.Values.ToArray(), disposableCollection, out count),
				lobbyPropertyCount = Convert.ToUInt32(LobbyProperties.Count),
				lobbyPropertyKeys = (sbyte**)(void*)Converters.StringArrayToUTF8StringArray(LobbyProperties.Keys.ToArray(), disposableCollection, out count),
				lobbyPropertyValues = (sbyte**)(void*)Converters.StringArrayToUTF8StringArray(LobbyProperties.Values.ToArray(), disposableCollection, out count)
			}, disposableCollection);
		}
	}
}
