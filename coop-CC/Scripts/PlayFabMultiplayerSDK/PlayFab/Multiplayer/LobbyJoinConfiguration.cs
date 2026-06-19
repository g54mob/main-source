using System.Collections.Generic;
using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class LobbyJoinConfiguration
	{
		public IDictionary<string, string> MemberProperties
		{
			get
			{
				return Config.MemberProperties;
			}
			set
			{
				Config.MemberProperties = value;
			}
		}

		internal PFLobbyJoinConfiguration Config { get; set; }

		public LobbyJoinConfiguration()
		{
			Config = new PFLobbyJoinConfiguration();
		}
	}
}
