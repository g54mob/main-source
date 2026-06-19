using System;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyMemberUpdateSummary
	{
		public PFEntityKey Member { get; private set; }

		public bool ConnectionStatusUpdated { get; private set; }

		public string[] UpdatedMemberPropertyKeys { get; private set; }

		internal unsafe PFLobbyMemberUpdateSummary(PlayFab.Multiplayer.Interop.PFLobbyMemberUpdateSummary interopStruct)
		{
			Member = new PFEntityKey(&interopStruct.member);
			ConnectionStatusUpdated = Convert.ToBoolean(interopStruct.connectionStatusUpdated);
			UpdatedMemberPropertyKeys = Converters.StringPtrToArray(interopStruct.updatedMemberPropertyKeys, interopStruct.updatedMemberPropertyCount);
		}
	}
}
