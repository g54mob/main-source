using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFMatchmakingStateChange
	{
		public PFMatchmakingStateChangeType StateChangeType { get; private set; }

		internal unsafe PlayFab.Multiplayer.Interop.PFMatchmakingStateChange* StateChangeId { get; private set; }

		protected bool UseObjectPool { get; set; }

		protected unsafe PFMatchmakingStateChange(PFMatchmakingStateChangeType stateChangeType, PlayFab.Multiplayer.Interop.PFMatchmakingStateChange* stateChangeId)
		{
			StateChangeType = stateChangeType;
			StateChangeId = stateChangeId;
			UseObjectPool = false;
		}

		internal unsafe static PFMatchmakingStateChange CreateFromPtr(PlayFab.Multiplayer.Interop.PFMatchmakingStateChange* stateChangePtr)
		{
			PFMatchmakingStateChange pFMatchmakingStateChange = null;
			PFMatchmakingStateChangeUnion stateChangeUnion = (PFMatchmakingStateChangeUnion)Marshal.PtrToStructure(new IntPtr(stateChangePtr), typeof(PFMatchmakingStateChangeUnion));
			PFMatchmakingStateChangeType stateChangeType = (PFMatchmakingStateChangeType)stateChangeUnion.stateChange.stateChangeType;
			switch (stateChangeType)
			{
			case PFMatchmakingStateChangeType.TicketStatusChanged:
				return new PFMatchmakingTicketStatusChangedStateChange(stateChangeUnion, stateChangePtr);
			case PFMatchmakingStateChangeType.TicketCompleted:
				return new PFMatchmakingTicketCompletedStateChange(stateChangeUnion, stateChangePtr);
			default:
				Debugger.Break();
				return new PFMatchmakingStateChange(stateChangeType, stateChangePtr);
			}
		}

		internal virtual void Cleanup()
		{
			if (UseObjectPool)
			{
				PFMultiplayer.ObjPool.Return(this);
			}
		}
	}
}
