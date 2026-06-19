using System;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbySendInviteCompletedStateChange : PFLobbyStateChange
	{
		public int result { get; private set; }

		public PFLobbyHandle lobby { get; private set; }

		public PFEntityKey sender { get; private set; }

		public PFEntityKey invitee { get; private set; }

		public object asyncContext { get; private set; }

		internal unsafe PFLobbySendInviteCompletedStateChange(PFLobbyStateChangeUnion stateChangeUnion, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
			: base((PFLobbyStateChangeType)stateChangeUnion.stateChange.stateChangeType, StateChangeId)
		{
			ref readonly PlayFab.Multiplayer.Interop.PFLobbySendInviteCompletedStateChange sendInviteCompleted = ref stateChangeUnion.sendInviteCompleted;
			result = sendInviteCompleted.result;
			lobby = new PFLobbyHandle(sendInviteCompleted.lobby);
			PlayFab.Multiplayer.Interop.PFEntityKey pFEntityKey = sendInviteCompleted.sender;
			sender = new PFEntityKey(&pFEntityKey);
			PlayFab.Multiplayer.Interop.PFEntityKey pFEntityKey2 = sendInviteCompleted.invitee;
			invitee = new PFEntityKey(&pFEntityKey2);
			if (sendInviteCompleted.asyncContext != null)
			{
				GCHandle gCHandle = GCHandle.FromIntPtr(new IntPtr(sendInviteCompleted.asyncContext));
				asyncContext = gCHandle.Target;
				gCHandle.Free();
			}
		}
	}
}
