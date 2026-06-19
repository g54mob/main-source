using System;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFEntityKey
	{
		public string Id { get; set; }

		public string Type { get; set; }

		public PFEntityKey(string id, string type)
		{
			Id = id;
			Type = type;
		}

		internal unsafe PFEntityKey(PlayFab.Multiplayer.Interop.PFEntityKey* interopStruct)
		{
			Id = ((interopStruct == null) ? Id : Converters.PtrToStringUTF8((IntPtr)interopStruct->id));
			Type = ((interopStruct == null) ? Type : Converters.PtrToStringUTF8((IntPtr)interopStruct->type));
		}

		internal unsafe PlayFab.Multiplayer.Interop.PFEntityKey* ToPointer(DisposableCollection disposableCollection)
		{
			UTF8StringPtr uTF8StringPtr = new UTF8StringPtr(Id, disposableCollection);
			UTF8StringPtr uTF8StringPtr2 = new UTF8StringPtr(Type, disposableCollection);
			return (PlayFab.Multiplayer.Interop.PFEntityKey*)(void*)Converters.StructToPtr(new PlayFab.Multiplayer.Interop.PFEntityKey
			{
				id = uTF8StringPtr.Pointer,
				type = uTF8StringPtr2.Pointer
			}, disposableCollection);
		}
	}
}
