using System;
using System.Collections.Generic;
using System.Linq;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbySearchResult
	{
		public string LobbyId { get; set; }

		public string ConnectionString { get; set; }

		public PFEntityKey OwnerEntity { get; set; }

		public uint MaxMemberCount { get; set; }

		public uint CurrentMemberCount { get; set; }

		public Dictionary<string, string> SearchProperties { get; set; }

		public List<PFEntityKey> Friends { get; set; }

		public PFLobbyMembershipLock MembershipLock { get; set; }

		internal unsafe PFLobbySearchResult(PlayFab.Multiplayer.Interop.PFLobbySearchResult* interopStruct)
		{
			LobbyId = Converters.PtrToStringUTF8((IntPtr)interopStruct->lobbyId);
			ConnectionString = Converters.PtrToStringUTF8((IntPtr)interopStruct->connectionString);
			OwnerEntity = new PFEntityKey(interopStruct->ownerEntity);
			MaxMemberCount = interopStruct->maxMemberCount;
			CurrentMemberCount = interopStruct->currentMemberCount;
			if (interopStruct->searchPropertyCount != 0)
			{
				string[] searchPropertyKeys = Converters.StringPtrToArray(interopStruct->searchPropertyKeys, interopStruct->searchPropertyCount);
				string[] searchPropertyValues = Converters.StringPtrToArray(interopStruct->searchPropertyValues, interopStruct->searchPropertyCount);
				if (searchPropertyKeys.Length != searchPropertyValues.Length)
				{
					throw new IndexOutOfRangeException("searchPropertyKeys and searchPropertyValues don't have same length");
				}
				SearchProperties = Enumerable.Range(0, searchPropertyKeys.Length).ToDictionary((int i) => searchPropertyKeys[i], (int i) => searchPropertyValues[i]);
			}
			else
			{
				SearchProperties = new Dictionary<string, string>();
			}
			if (interopStruct->friendCount != 0)
			{
				PFEntityKey[] array = new PFEntityKey[interopStruct->friendCount];
				for (int num = 0; num < interopStruct->friendCount; num++)
				{
					array[num] = new PFEntityKey(interopStruct->friends + num);
				}
				Friends = array.ToList();
			}
			else
			{
				Friends = new List<PFEntityKey>();
			}
			MembershipLock = (PFLobbyMembershipLock)interopStruct->membershipLock;
		}
	}
}
