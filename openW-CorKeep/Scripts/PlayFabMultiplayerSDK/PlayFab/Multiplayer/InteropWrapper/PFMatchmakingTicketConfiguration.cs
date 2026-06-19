using System.Collections.Generic;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFMatchmakingTicketConfiguration
	{
		public uint TimeoutInSeconds { get; set; }

		public string QueueName { get; set; }

		public List<PFEntityKey> MembersToMatchWith { get; set; }

		public PFMatchmakingTicketConfiguration()
		{
			MembersToMatchWith = new List<PFEntityKey>();
		}

		public PFMatchmakingTicketConfiguration(uint timeoutInSeconds, string queueName, List<PFEntityKey> membersToMatchWith)
		{
			TimeoutInSeconds = timeoutInSeconds;
			QueueName = queueName;
			MembersToMatchWith = membersToMatchWith;
		}

		internal unsafe PlayFab.Multiplayer.Interop.PFMatchmakingTicketConfiguration* ToPointer(DisposableCollection disposableCollection)
		{
			PlayFab.Multiplayer.Interop.PFMatchmakingTicketConfiguration interopStruct = default(PlayFab.Multiplayer.Interop.PFMatchmakingTicketConfiguration);
			UTF8StringPtr uTF8StringPtr = new UTF8StringPtr(QueueName, disposableCollection);
			interopStruct.timeoutInSeconds = TimeoutInSeconds;
			interopStruct.queueName = uTF8StringPtr.Pointer;
			interopStruct.membersToMatchWithCount = (uint)MembersToMatchWith.Count;
			if (MembersToMatchWith.Count > 0)
			{
				PlayFab.Multiplayer.Interop.PFEntityKey[] array = new PlayFab.Multiplayer.Interop.PFEntityKey[MembersToMatchWith.Count];
				for (int i = 0; i < MembersToMatchWith.Count; i++)
				{
					UTF8StringPtr uTF8StringPtr2 = new UTF8StringPtr(MembersToMatchWith[i].Id, disposableCollection);
					UTF8StringPtr uTF8StringPtr3 = new UTF8StringPtr(MembersToMatchWith[i].Type, disposableCollection);
					array[i].id = uTF8StringPtr2.Pointer;
					array[i].type = uTF8StringPtr3.Pointer;
				}
				fixed (PlayFab.Multiplayer.Interop.PFEntityKey* membersToMatchWith = &array[0])
				{
					interopStruct.membersToMatchWith = membersToMatchWith;
					return (PlayFab.Multiplayer.Interop.PFMatchmakingTicketConfiguration*)(void*)Converters.StructToPtr(interopStruct, disposableCollection);
				}
			}
			interopStruct.membersToMatchWith = null;
			return (PlayFab.Multiplayer.Interop.PFMatchmakingTicketConfiguration*)(void*)Converters.StructToPtr(interopStruct, disposableCollection);
		}
	}
}
