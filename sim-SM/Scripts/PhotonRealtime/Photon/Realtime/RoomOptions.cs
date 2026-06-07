using ExitGames.Client.Photon;

namespace Photon.Realtime
{
	public class RoomOptions
	{
		private bool isVisible;

		private bool isOpen;

		public int MaxPlayers;

		public int PlayerTtl;

		public int EmptyRoomTtl;

		private bool cleanupCacheOnLeave;

		public Hashtable CustomRoomProperties;

		public string[] CustomRoomPropertiesForLobby;

		public string[] Plugins;

		private bool broadcastPropsChangeToAll;

		public bool IsVisible
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsOpen
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool CleanupCacheOnLeave
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SuppressRoomEvents { get; set; }

		public bool SuppressPlayerInfo { get; set; }

		public bool PublishUserId { get; set; }

		public bool DeleteNullProperties { get; set; }

		public bool BroadcastPropsChangeToAll
		{
			get
			{
				return false;
			}
			set
			{
			}
		}
	}
}
