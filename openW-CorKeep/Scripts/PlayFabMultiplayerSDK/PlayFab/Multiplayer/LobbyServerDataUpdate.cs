using System.Collections.Generic;
using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class LobbyServerDataUpdate
	{
		public PFEntityKey NewServer
		{
			get
			{
				return new PFEntityKey(Update.NewServer);
			}
			set
			{
				Update.NewServer = value.EntityKey;
			}
		}

		public IDictionary<string, string> SearchProperties
		{
			get
			{
				return Update.ServerProperties;
			}
			set
			{
				Update.ServerProperties = value;
			}
		}

		internal PFLobbyServerDataUpdate Update { get; set; }

		public LobbyServerDataUpdate()
		{
			Update = new PFLobbyServerDataUpdate();
		}
	}
}
