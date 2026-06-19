using System.Collections.Generic;
using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class LobbyDataUpdate
	{
		public PFEntityKey NewOwner
		{
			get
			{
				return new PFEntityKey(Update.NewOwner);
			}
			set
			{
				Update.NewOwner = value.EntityKey;
			}
		}

		public uint? MaxMemberCount
		{
			get
			{
				return Update.MaxMemberCount;
			}
			set
			{
				Update.MaxMemberCount = value;
			}
		}

		public LobbyAccessPolicy? AccessPolicy
		{
			get
			{
				return Update.AccessPolicy;
			}
			set
			{
				Update.AccessPolicy = value;
			}
		}

		public LobbyMembershipLock? MembershipLock
		{
			get
			{
				return Update.MembershipLock.Value;
			}
			set
			{
				Update.MembershipLock = value.Value;
			}
		}

		public IDictionary<string, string> SearchProperties
		{
			get
			{
				return Update.SearchProperties;
			}
			set
			{
				Update.SearchProperties = value;
			}
		}

		public IDictionary<string, string> LobbyProperties
		{
			get
			{
				return Update.LobbyProperties;
			}
			set
			{
				Update.LobbyProperties = value;
			}
		}

		internal PFLobbyDataUpdate Update { get; set; }

		public LobbyDataUpdate()
		{
			Update = new PFLobbyDataUpdate();
		}
	}
}
