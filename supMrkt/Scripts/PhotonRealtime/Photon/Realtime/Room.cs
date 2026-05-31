using System.Collections.Generic;
using ExitGames.Client.Photon;

namespace Photon.Realtime
{
	public class Room : RoomInfo
	{
		private bool isOffline;

		private Dictionary<int, Player> players;

		public LoadBalancingClient LoadBalancingClient { get; set; }

		public new string Name
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public bool IsOffline
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public new bool IsOpen
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public new bool IsVisible
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public new int MaxPlayers
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public new int PlayerCount => 0;

		public Dictionary<int, Player> Players
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public string[] ExpectedUsers => null;

		public int PlayerTtl
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int EmptyRoomTtl
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int MasterClientId => 0;

		public string[] PropertiesListedInLobby
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public bool AutoCleanUp => false;

		public bool BroadcastPropertiesChangeToAll { get; private set; }

		public bool SuppressRoomEvents { get; private set; }

		public bool SuppressPlayerInfo { get; private set; }

		public bool PublishUserId { get; private set; }

		public bool DeleteNullProperties { get; private set; }

		public Room(string roomName, RoomOptions options, bool isOffline = false)
			: base(null, null)
		{
		}

		internal void InternalCacheRoomFlags(int roomFlags)
		{
		}

		protected internal override void InternalCacheProperties(Hashtable propertiesToCache)
		{
		}

		public virtual bool SetCustomProperties(Hashtable propertiesToSet, Hashtable expectedProperties = null, WebFlags webFlags = null)
		{
			return false;
		}

		public bool SetPropertiesListedInLobby(string[] lobbyProps)
		{
			return false;
		}

		protected internal virtual void RemovePlayer(Player player)
		{
		}

		protected internal virtual void RemovePlayer(int id)
		{
		}

		public bool SetMasterClient(Player masterClientPlayer)
		{
			return false;
		}

		public virtual bool AddPlayer(Player player)
		{
			return false;
		}

		public virtual Player StorePlayer(Player player)
		{
			return null;
		}

		public virtual Player GetPlayer(int id, bool findMaster = false)
		{
			return null;
		}

		public bool ClearExpectedUsers()
		{
			return false;
		}

		public bool SetExpectedUsers(string[] newExpectedUsers)
		{
			return false;
		}

		private bool SetExpectedUsers(string[] newExpectedUsers, string[] oldExpectedUsers)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public new string ToStringFull()
		{
			return null;
		}
	}
}
