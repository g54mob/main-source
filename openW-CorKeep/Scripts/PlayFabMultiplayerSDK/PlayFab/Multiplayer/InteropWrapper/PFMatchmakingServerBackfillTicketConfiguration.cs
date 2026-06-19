using System.Collections.Generic;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFMatchmakingServerBackfillTicketConfiguration
	{
		public uint TimeoutInSeconds { get; set; }

		public string QueueName { get; set; }

		public List<PFMatchmakingMatchMember> Members { get; set; }

		public PFMultiplayerServerDetails ServerDetails { get; set; }

		public PFMatchmakingServerBackfillTicketConfiguration(uint timeoutInSeconds, string queueName, List<PFMatchmakingMatchMember> members, PFMultiplayerServerDetails serverDetails)
		{
			TimeoutInSeconds = timeoutInSeconds;
			QueueName = queueName;
			Members = members;
			ServerDetails = serverDetails;
		}

		internal unsafe PlayFab.Multiplayer.Interop.PFMatchmakingServerBackfillTicketConfiguration* ToPointer(DisposableCollection disposableCollection)
		{
			PlayFab.Multiplayer.Interop.PFMatchmakingServerBackfillTicketConfiguration interopStruct = new PlayFab.Multiplayer.Interop.PFMatchmakingServerBackfillTicketConfiguration
			{
				timeoutInSeconds = TimeoutInSeconds,
				queueName = new UTF8StringPtr(QueueName, disposableCollection).Pointer,
				memberCount = (uint)Members.Count
			};
			if (Members.Count > 0)
			{
				PlayFab.Multiplayer.Interop.PFMatchmakingMatchMember[] array = new PlayFab.Multiplayer.Interop.PFMatchmakingMatchMember[Members.Count];
				for (int i = 0; i < Members.Count; i++)
				{
					array[i] = *Members[i].ToPointer(disposableCollection);
				}
				fixed (PlayFab.Multiplayer.Interop.PFMatchmakingMatchMember* members = &array[0])
				{
					interopStruct.members = members;
				}
			}
			else
			{
				interopStruct.members = null;
			}
			if (ServerDetails != null)
			{
				interopStruct.serverDetails = ServerDetails.ToPointer(disposableCollection);
			}
			else
			{
				interopStruct.serverDetails = null;
			}
			return (PlayFab.Multiplayer.Interop.PFMatchmakingServerBackfillTicketConfiguration*)(void*)Converters.StructToPtr(interopStruct, disposableCollection);
		}
	}
}
