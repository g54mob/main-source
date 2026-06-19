using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class MultiplayerPort
	{
		internal PFMultiplayerPort multiplayerPort;

		public string Name
		{
			get
			{
				return multiplayerPort.Name;
			}
			set
			{
				multiplayerPort.Name = value;
			}
		}

		public uint Num
		{
			get
			{
				return multiplayerPort.Num;
			}
			set
			{
				multiplayerPort.Num = value;
			}
		}

		public MultiplayerProtocolType Protocol
		{
			get
			{
				return (MultiplayerProtocolType)multiplayerPort.Protocol;
			}
			set
			{
				multiplayerPort.Protocol = (PFMultiplayerProtocolType)value;
			}
		}

		public MultiplayerPort(string name, uint num, MultiplayerProtocolType protocolType)
		{
			multiplayerPort = new PFMultiplayerPort(name, num, (PFMultiplayerProtocolType)protocolType);
		}

		internal MultiplayerPort(PFMultiplayerPort port)
		{
			multiplayerPort = port;
		}
	}
}
