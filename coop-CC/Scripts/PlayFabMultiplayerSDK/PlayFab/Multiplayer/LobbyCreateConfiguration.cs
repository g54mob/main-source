using System.Collections.Generic;
using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class LobbyCreateConfiguration
	{
		public uint MaxMemberCount
		{
			get
			{
				return Config.MaxMemberCount;
			}
			set
			{
				Config.MaxMemberCount = value;
			}
		}

		public LobbyOwnerMigrationPolicy OwnerMigrationPolicy
		{
			get
			{
				return (LobbyOwnerMigrationPolicy)Config.OwnerMigrationPolicy;
			}
			set
			{
				Config.OwnerMigrationPolicy = (PFLobbyOwnerMigrationPolicy)value;
			}
		}

		public LobbyAccessPolicy AccessPolicy
		{
			get
			{
				return (LobbyAccessPolicy)Config.AccessPolicy;
			}
			set
			{
				Config.AccessPolicy = (PFLobbyAccessPolicy)value;
			}
		}

		public IDictionary<string, string> SearchProperties
		{
			get
			{
				return Config.SearchProperties;
			}
			set
			{
				Config.SearchProperties = value;
			}
		}

		public IDictionary<string, string> LobbyProperties
		{
			get
			{
				return Config.LobbyProperties;
			}
			set
			{
				Config.LobbyProperties = value;
			}
		}

		internal PFLobbyCreateConfiguration Config { get; set; }

		public LobbyCreateConfiguration()
		{
			Config = new PFLobbyCreateConfiguration();
		}
	}
}
