using System;
using System.Collections.Generic;
using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class MatchmakingTicket
	{
		private static Dictionary<IntPtr, MatchmakingTicket> matchmakingTicketCache = new Dictionary<IntPtr, MatchmakingTicket>();

		public MatchmakingTicketStatus Status
		{
			get
			{
				PlayFabMultiplayer.Succeeded(PFMultiplayer.PFMatchmakingTicketGetStatus(Handle, out var status));
				return (MatchmakingTicketStatus)status;
			}
		}

		public string TicketId
		{
			get
			{
				PlayFabMultiplayer.Succeeded(PFMultiplayer.PFMatchmakingTicketGetTicketId(Handle, out var ticketId));
				return ticketId;
			}
		}

		public object Context
		{
			get
			{
				PlayFabMultiplayer.Succeeded(PFMultiplayer.PFMatchmakingTicketGetCustomContext(Handle, out var customContext));
				if (customContext != null)
				{
					return customContext;
				}
				return null;
			}
			set
			{
				PlayFabMultiplayer.Succeeded(PFMultiplayer.PFMatchmakingTicketSetCustomContext(Handle, value));
			}
		}

		internal PFMatchmakingTicketHandle Handle { get; set; }

		internal MatchmakingTicket(PFMatchmakingTicketHandle handle)
		{
			Handle = handle;
		}

		public void Cancel()
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayer.PFMatchmakingTicketCancel(Handle));
		}

		public MatchmakingMatchDetails GetMatchDetails()
		{
			PlayFabMultiplayer.Succeeded(PFMultiplayer.PFMatchmakingTicketGetMatch(Handle, out var matchDetails));
			if (matchDetails != null)
			{
				return new MatchmakingMatchDetails(matchDetails);
			}
			return null;
		}

		internal static MatchmakingTicket GetMatchmakingTicketUsingCache(PFMatchmakingTicketHandle handle)
		{
			if (matchmakingTicketCache.TryGetValue(handle.InteropHandleIntPtr, out var value))
			{
				return value;
			}
			value = new MatchmakingTicket(handle);
			matchmakingTicketCache[handle.InteropHandleIntPtr] = value;
			return value;
		}

		internal static void ClearMatchmakingTicketFromCache(PFMatchmakingTicketHandle handle)
		{
			if (matchmakingTicketCache.ContainsKey(handle.InteropHandleIntPtr))
			{
				matchmakingTicketCache.Remove(handle.InteropHandleIntPtr);
			}
		}
	}
}
