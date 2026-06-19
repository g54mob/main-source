using System.Collections.Generic;
using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class MultiplayerServerDetails
	{
		internal PFMultiplayerServerDetails multiplayerServerDetails;

		internal PFMultiplayerServerDetails PFMultiplayerServerDetails => multiplayerServerDetails;

		public string Fqdn
		{
			get
			{
				return multiplayerServerDetails.Fqdn;
			}
			set
			{
				multiplayerServerDetails.Fqdn = value;
			}
		}

		public string Ipv4Address
		{
			get
			{
				return multiplayerServerDetails.Ipv4Address;
			}
			set
			{
				multiplayerServerDetails.Ipv4Address = value;
			}
		}

		public IList<MultiplayerPort> Ports
		{
			get
			{
				IList<MultiplayerPort> list = new List<MultiplayerPort>();
				for (int i = 0; i < multiplayerServerDetails.PortCount; i++)
				{
					MultiplayerPort item = new MultiplayerPort(multiplayerServerDetails.Ports[i].Name, multiplayerServerDetails.Ports[i].Num, (MultiplayerProtocolType)multiplayerServerDetails.Ports[i].Protocol);
					list.Add(item);
				}
				return list;
			}
			set
			{
				multiplayerServerDetails.Ports = new PFMultiplayerPort[value.Count];
				for (int i = 0; i < value.Count; i++)
				{
					multiplayerServerDetails.Ports[i] = new PFMultiplayerPort(value[i].Name, value[i].Num, (PFMultiplayerProtocolType)value[i].Protocol);
				}
			}
		}

		public string Region
		{
			get
			{
				return multiplayerServerDetails.Region;
			}
			set
			{
				multiplayerServerDetails.Region = value;
			}
		}

		public MultiplayerServerDetails(string fqdn, string ipv4Address, IList<MultiplayerPort> ports, string region)
		{
			PFMultiplayerPort[] array = new PFMultiplayerPort[ports.Count];
			for (int i = 0; i < ports.Count; i++)
			{
				array[i] = new PFMultiplayerPort(ports[i].Name, ports[i].Num, (PFMultiplayerProtocolType)ports[i].Protocol);
			}
			multiplayerServerDetails = new PFMultiplayerServerDetails(fqdn, ipv4Address, array, region, (uint)ports.Count);
		}

		internal MultiplayerServerDetails(PFMultiplayerServerDetails serverDetails)
		{
			multiplayerServerDetails = serverDetails;
		}
	}
}
