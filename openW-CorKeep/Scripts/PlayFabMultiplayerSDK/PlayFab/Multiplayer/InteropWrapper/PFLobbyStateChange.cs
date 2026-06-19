using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyStateChange
	{
		protected bool useObjectPool;

		public PFLobbyStateChangeType StateChangeType { get; private set; }

		internal unsafe PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId { get; private set; }

		protected unsafe PFLobbyStateChange(PFLobbyStateChangeType StateChangeType, PlayFab.Multiplayer.Interop.PFLobbyStateChange* StateChangeId)
		{
			this.StateChangeType = StateChangeType;
			this.StateChangeId = StateChangeId;
			useObjectPool = false;
		}

		internal unsafe static PFLobbyStateChange CreateFromPtr(PlayFab.Multiplayer.Interop.PFLobbyStateChange* stateChangePtr)
		{
			PFLobbyStateChange pFLobbyStateChange = null;
			PFLobbyStateChangeUnion pFLobbyStateChangeUnion = (PFLobbyStateChangeUnion)Marshal.PtrToStructure(new IntPtr(stateChangePtr), typeof(PFLobbyStateChangeUnion));
			PFLobbyStateChangeType stateChangeType = (PFLobbyStateChangeType)pFLobbyStateChangeUnion.stateChange.stateChangeType;
			switch (stateChangeType)
			{
			case PFLobbyStateChangeType.CreateAndJoinLobbyCompleted:
				return new PFLobbyCreateAndJoinCompletedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.JoinLobbyCompleted:
				return new PFLobbyJoinCompletedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.MemberAdded:
				return new PFLobbyMemberAddedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.AddMemberCompleted:
				return new PFLobbyAddMemberCompletedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.MemberRemoved:
				return new PFLobbyMemberRemovedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.ForceRemoveMemberCompleted:
				return new PFLobbyForceRemoveMemberCompletedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.LeaveLobbyCompleted:
				return new PFLobbyLeaveCompletedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.Updated:
				return new PFLobbyUpdatedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.PostUpdateCompleted:
				return new PFLobbyPostUpdateCompletedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.Disconnecting:
				return new PFLobbyDisconnectingStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.Disconnected:
				return new PFLobbyDisconnectedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.JoinArrangedLobbyCompleted:
				return new PFLobbyArrangedJoinCompletedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.FindLobbiesCompleted:
				return new PFLobbyFindLobbiesCompletedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.InviteReceived:
				return new PFLobbyInviteReceivedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.InviteListenerStatusChanged:
				return new PFLobbyInviteListenerStatusChangedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.SendInviteCompleted:
				return new PFLobbySendInviteCompletedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.CreateAndClaimServerLobbyCompleted:
				return new PFLobbyCreateAndClaimServerLobbyCompletedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.ClaimServerLobbyCompleted:
				return new PFLobbyClaimServerLobbyCompletedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.ServerPostUpdateCompleted:
				return new PFLobbyServerPostUpdateCompletedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.ServerDeleteLobbyCompleted:
				return new PFLobbyServerDeleteLobbyCompletedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.JoinLobbyAsServerCompleted:
				return new PFLobbyJoinLobbyAsServerCompletedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.ServerPostUpdateAsServerCompleted:
				return new PFLobbyServerPostUpdateAsServerCompletedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			case PFLobbyStateChangeType.ServerLeaveLobbyAsServerCompleted:
				return new PFLobbyServerLeaveLobbyAsServerCompletedStateChange(pFLobbyStateChangeUnion, stateChangePtr);
			default:
				Debugger.Break();
				return new PFLobbyStateChange(stateChangeType, stateChangePtr);
			}
		}

		internal virtual void Cleanup()
		{
			if (useObjectPool)
			{
				PFMultiplayer.ObjPool.Return(this);
			}
		}
	}
}
