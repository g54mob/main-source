using PlayFab.Multiplayer.InteropWrapper;

namespace PlayFab.Multiplayer
{
	public class PFEntityKey
	{
		public string Id
		{
			get
			{
				return EntityKey.Id;
			}
			set
			{
				EntityKey.Id = value;
			}
		}

		public string Type
		{
			get
			{
				return EntityKey.Type;
			}
			set
			{
				EntityKey.Type = value;
			}
		}

		internal PlayFab.Multiplayer.InteropWrapper.PFEntityKey EntityKey { get; set; }

		public PFEntityKey(PlayFabAuthenticationContext authContext)
		{
			EntityKey = new PlayFab.Multiplayer.InteropWrapper.PFEntityKey(authContext.EntityId, authContext.EntityType);
		}

		public PFEntityKey(string id, string type)
		{
			EntityKey = new PlayFab.Multiplayer.InteropWrapper.PFEntityKey(id, type);
		}

		internal PFEntityKey(PlayFab.Multiplayer.InteropWrapper.PFEntityKey newEntityKey)
		{
			EntityKey = newEntityKey;
		}
	}
}
