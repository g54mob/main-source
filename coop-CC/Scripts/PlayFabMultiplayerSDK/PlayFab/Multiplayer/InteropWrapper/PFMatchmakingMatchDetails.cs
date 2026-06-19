using System;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFMatchmakingMatchDetails
	{
		public string MatchId { get; set; }

		public PFMatchmakingMatchMember[] Members { get; set; }

		public string[] RegionPreferences { get; set; }

		public string LobbyArrangementString { get; set; }

		public PFMultiplayerServerDetails ServerDetails { get; }

		internal unsafe PFMatchmakingMatchDetails(PlayFab.Multiplayer.Interop.PFMatchmakingMatchDetails* interopStruct)
		{
			MatchId = Converters.PtrToStringUTF8((IntPtr)interopStruct->matchId);
			Members = new PFMatchmakingMatchMember[interopStruct->memberCount];
			for (int i = 0; i < interopStruct->memberCount; i++)
			{
				Members[i] = new PFMatchmakingMatchMember();
				Members[i].EntityKey = new PFEntityKey(Converters.PtrToStringUTF8((IntPtr)interopStruct->members[i].entityKey.id), Converters.PtrToStringUTF8((IntPtr)interopStruct->members[i].entityKey.type));
				Members[i].TeamId = Converters.PtrToStringUTF8((IntPtr)interopStruct->members[i].teamId);
				Members[i].Attributes = Converters.PtrToStringUTF8((IntPtr)interopStruct->members[i].attributes);
			}
			RegionPreferences = Converters.StringPtrToArray(interopStruct->regionPreferences, interopStruct->regionPreferenceCount);
			LobbyArrangementString = Converters.PtrToStringUTF8((IntPtr)interopStruct->lobbyArrangementString);
			if (interopStruct->serverDetails != null)
			{
				ServerDetails = new PFMultiplayerServerDetails(interopStruct->serverDetails);
			}
		}
	}
}
