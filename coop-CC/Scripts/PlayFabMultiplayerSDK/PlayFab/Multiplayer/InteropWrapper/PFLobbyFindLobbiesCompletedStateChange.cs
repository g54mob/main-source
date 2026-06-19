using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyFindLobbiesCompletedStateChange : PFLobbyStateChange
	{
		public PFLobbyStateChange stateChange { get; private set; }

		public int result { get; private set; }

		public PFEntityKey searchingEntity { get; private set; }

		public object asyncContext { get; private set; }

		public List<PFLobbySearchResult> searchResults { get; private set; }

		internal unsafe PFLobbyFindLobbiesCompletedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PlayFab.Multiplayer.Interop.PFLobbyFindLobbiesCompletedStateChange findLobbiesCompleted = ref stateChangeUnion.findLobbiesCompleted;
			result = findLobbiesCompleted.result;
			PlayFab.Multiplayer.Interop.PFEntityKey pFEntityKey = findLobbiesCompleted.searchingEntity;
			searchingEntity = new PFEntityKey(&pFEntityKey);
			if (findLobbiesCompleted.asyncContext != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(findLobbiesCompleted.asyncContext));
				asyncContext = gCHandle.Target;
				gCHandle.Free();
			}
			if (findLobbiesCompleted.searchResultCount != 0)
			{
				PFLobbySearchResult[] array = new PFLobbySearchResult[findLobbiesCompleted.searchResultCount];
				for (int i = 0; i < findLobbiesCompleted.searchResultCount; i++)
				{
					array[i] = new PFLobbySearchResult(findLobbiesCompleted.searchResults + i);
				}
				searchResults = array.ToList();
			}
			else
			{
				searchResults = new List<PFLobbySearchResult>();
			}
		}
	}
}
