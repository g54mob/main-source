using System;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFMultiplayerPort
	{
		public string Name { get; set; }

		public uint Num { get; set; }

		public PFMultiplayerProtocolType Protocol { get; set; }

		public PFMultiplayerPort(string name, uint num, PFMultiplayerProtocolType protocol)
		{
			Name = name;
			Num = num;
			Protocol = protocol;
		}

		internal unsafe PFMultiplayerPort(PlayFab.Multiplayer.Interop.PFMultiplayerPort* interopStruct)
		{
			Name = Converters.PtrToStringUTF8((IntPtr)interopStruct->name);
			Num = interopStruct->num;
			Protocol = (PFMultiplayerProtocolType)interopStruct->protocol;
		}

		internal unsafe PlayFab.Multiplayer.Interop.PFMultiplayerPort* ToPointer(DisposableCollection disposableCollection)
		{
			return (PlayFab.Multiplayer.Interop.PFMultiplayerPort*)(void*)Converters.StructToPtr(new PlayFab.Multiplayer.Interop.PFMultiplayerPort
			{
				name = new UTF8StringPtr(Name, disposableCollection).Pointer,
				num = Num,
				protocol = (PlayFab.Multiplayer.Interop.PFMultiplayerProtocolType)Protocol
			}, disposableCollection);
		}
	}
}
