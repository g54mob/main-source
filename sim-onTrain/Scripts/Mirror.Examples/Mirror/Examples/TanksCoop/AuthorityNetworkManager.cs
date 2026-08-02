using System.Linq;

namespace Mirror.Examples.TanksCoop
{
	public class AuthorityNetworkManager : NetworkManager
	{
		private NetworkIdentity[] copyOfOwnedObjects;

		public new static AuthorityNetworkManager singleton { get; private set; }

		public override void Awake()
		{
			base.Awake();
			singleton = this;
		}

		public override void OnServerDisconnect(NetworkConnectionToClient conn)
		{
			copyOfOwnedObjects = conn.owned.ToArray();
			NetworkIdentity[] array = copyOfOwnedObjects;
			foreach (NetworkIdentity networkIdentity in array)
			{
				if (networkIdentity != conn.identity)
				{
					networkIdentity.RemoveClientAuthority();
				}
			}
			base.OnServerDisconnect(conn);
		}
	}
}
