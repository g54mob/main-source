using System.Collections.Generic;
using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class LobbyServerJoinConfiguration
	{
		public IDictionary<string, string> ServerProperties
		{
			get
			{
				return Config.ServerProperties;
			}
			set
			{
				Config.ServerProperties = value;
			}
		}

		internal PFLobbyServerJoinConfiguration Config { get; set; }

		public LobbyServerJoinConfiguration()
		{
			Config = new PFLobbyServerJoinConfiguration();
		}
	}
}
