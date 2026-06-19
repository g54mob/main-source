using System;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFMatchmakingMatchMember
	{
		public PFEntityKey EntityKey { get; set; }

		public string TeamId { get; set; }

		public string Attributes { get; set; }

		internal PFMatchmakingMatchMember()
		{
		}

		internal unsafe PFMatchmakingMatchMember(PlayFab.Multiplayer.Interop.PFMatchmakingMatchMember* interopStruct)
		{
			EntityKey = new PFEntityKey(&interopStruct->entityKey);
			TeamId = Converters.PtrToStringUTF8((IntPtr)interopStruct->teamId);
			Attributes = Converters.PtrToStringUTF8((IntPtr)interopStruct->attributes);
		}

		internal unsafe PlayFab.Multiplayer.Interop.PFMatchmakingMatchMember* ToPointer(DisposableCollection disposableCollection)
		{
			PlayFab.Multiplayer.Interop.PFMatchmakingMatchMember interopStruct = default(PlayFab.Multiplayer.Interop.PFMatchmakingMatchMember);
			UTF8StringPtr uTF8StringPtr = new UTF8StringPtr(EntityKey.Id, disposableCollection);
			UTF8StringPtr uTF8StringPtr2 = new UTF8StringPtr(EntityKey.Type, disposableCollection);
			interopStruct.entityKey.id = uTF8StringPtr.Pointer;
			interopStruct.entityKey.type = uTF8StringPtr2.Pointer;
			interopStruct.teamId = new UTF8StringPtr(TeamId, disposableCollection).Pointer;
			interopStruct.attributes = new UTF8StringPtr(Attributes, disposableCollection).Pointer;
			return (PlayFab.Multiplayer.Interop.PFMatchmakingMatchMember*)(void*)Converters.StructToPtr(interopStruct, disposableCollection);
		}
	}
}
