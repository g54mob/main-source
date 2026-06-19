using System;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFMultiplayerServerDetails
	{
		public string Fqdn { get; set; }

		public string Ipv4Address { get; set; }

		public PFMultiplayerPort[] Ports { get; set; }

		public string Region { get; set; }

		public uint PortCount { get; set; }

		public PFMultiplayerServerDetails(string fqdn, string ipv4Address, PFMultiplayerPort[] ports, string region, uint portCount)
		{
			Fqdn = fqdn;
			Ipv4Address = ipv4Address;
			Ports = ports;
			Region = region;
			PortCount = portCount;
		}

		internal unsafe PFMultiplayerServerDetails(PlayFab.Multiplayer.Interop.PFMultiplayerServerDetails* interopStruct)
		{
			Region = Converters.PtrToStringUTF8((IntPtr)interopStruct->region);
			Fqdn = Converters.PtrToStringUTF8((IntPtr)interopStruct->fqdn);
			Ipv4Address = Converters.PtrToStringUTF8((IntPtr)interopStruct->ipv4Address);
			Ports = new PFMultiplayerPort[interopStruct->portCount];
			for (int i = 0; i < interopStruct->portCount; i++)
			{
				Ports[i] = new PFMultiplayerPort(interopStruct->ports + i);
			}
			PortCount = interopStruct->portCount;
		}

		internal unsafe PlayFab.Multiplayer.Interop.PFMultiplayerServerDetails* ToPointer(DisposableCollection disposableCollection)
		{
			PlayFab.Multiplayer.Interop.PFMultiplayerServerDetails interopStruct = new PlayFab.Multiplayer.Interop.PFMultiplayerServerDetails
			{
				fqdn = new UTF8StringPtr(Fqdn, disposableCollection).Pointer,
				ipv4Address = new UTF8StringPtr(Ipv4Address, disposableCollection).Pointer
			};
			if (PortCount != 0)
			{
				PlayFab.Multiplayer.Interop.PFMultiplayerPort[] array = new PlayFab.Multiplayer.Interop.PFMultiplayerPort[PortCount];
				for (int i = 0; i < PortCount; i++)
				{
					array[i] = *Ports[i].ToPointer(disposableCollection);
				}
				fixed (PlayFab.Multiplayer.Interop.PFMultiplayerPort* ports = &array[0])
				{
					interopStruct.ports = ports;
				}
			}
			else
			{
				interopStruct.ports = null;
			}
			interopStruct.portCount = PortCount;
			interopStruct.region = new UTF8StringPtr(Region, disposableCollection).Pointer;
			return (PlayFab.Multiplayer.Interop.PFMultiplayerServerDetails*)(void*)Converters.StructToPtr(interopStruct, disposableCollection);
		}
	}
}
