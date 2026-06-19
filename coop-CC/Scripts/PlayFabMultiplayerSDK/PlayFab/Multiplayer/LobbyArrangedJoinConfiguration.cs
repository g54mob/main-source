using System.Collections.Generic;
using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class LobbyArrangedJoinConfiguration
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

		internal PFLobbyArrangedJoinConfiguration Config { get; set; }

		public LobbyArrangedJoinConfiguration()
		{
			Config = new PFLobbyArrangedJoinConfiguration();
		}
	}
}
