using UnityEngine;

namespace Mirror.Examples.Chat
{
	[AddComponentMenu("")]
	public class ChatNetworkManager : NetworkManager
	{
		public new static ChatNetworkManager singleton { get; private set; }

		public override void Awake()
		{
			base.Awake();
			singleton = this;
		}

		public void SetHostname(string hostname)
		{
			networkAddress = hostname;
		}

		public override void OnServerDisconnect(NetworkConnectionToClient conn)
		{
			if (conn.authenticationData != null)
			{
				ChatAuthenticator.playerNames.Remove((string)conn.authenticationData);
			}
			ChatUI.connNames.Remove(conn);
			base.OnServerDisconnect(conn);
		}

		public override void OnClientDisconnect()
		{
			base.OnClientDisconnect();
		}
	}
}
