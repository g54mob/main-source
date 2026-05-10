using ExitGames.Client.Photon;

namespace Photon.Realtime
{
	public class Player
	{
		private int actorNumber;

		public readonly bool IsLocal;

		private string nickName;

		public object TagObject;

		protected internal Room RoomReference { get; set; }

		public int ActorNumber => 0;

		public bool HasRejoined { get; internal set; }

		public string NickName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string SteamId { get; set; }

		public string UserId { get; internal set; }

		public bool IsMasterClient => false;

		public bool IsInactive { get; protected internal set; }

		public Hashtable CustomProperties { get; set; }

		protected internal Player(string nickName, int actorNumber, bool isLocal)
		{
		}

		protected internal Player(string nickName, int actorNumber, bool isLocal, Hashtable playerProperties)
		{
		}

		public Player Get(int id)
		{
			return null;
		}

		public Player GetNext()
		{
			return null;
		}

		public Player GetNextFor(Player currentPlayer)
		{
			return null;
		}

		public Player GetNextFor(int currentPlayerId)
		{
			return null;
		}

		protected internal virtual void InternalCacheProperties(Hashtable properties)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public string ToStringFull()
		{
			return null;
		}

		public override bool Equals(object p)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		protected internal void ChangeLocalID(int newID)
		{
		}

		public bool SetCustomProperties(Hashtable propertiesToSet, Hashtable expectedValues = null, WebFlags webFlags = null)
		{
			return false;
		}

		internal bool UpdateNickNameOnJoined()
		{
			return false;
		}

		private bool SetPlayerNameProperty()
		{
			return false;
		}
	}
}
