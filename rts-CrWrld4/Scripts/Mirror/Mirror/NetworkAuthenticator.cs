using UnityEngine;

namespace Mirror
{
	public abstract class NetworkAuthenticator : MonoBehaviour
	{
		public UnityEventNetworkConnection OnServerAuthenticated;

		public UnityEventNetworkConnection OnClientAuthenticated;

		public virtual void OnStartServer()
		{
		}

		public virtual void OnStopServer()
		{
		}

		public abstract void OnServerAuthenticate(NetworkConnection conn);

		protected void ServerAccept(NetworkConnection conn)
		{
		}

		protected void ServerReject(NetworkConnection conn)
		{
		}

		public virtual void OnStartClient()
		{
		}

		public virtual void OnStopClient()
		{
		}

		public abstract void OnClientAuthenticate(NetworkConnection conn);

		protected void ClientAccept(NetworkConnection conn)
		{
		}

		protected void ClientReject(NetworkConnection conn)
		{
		}

		private void OnValidate()
		{
		}
	}
}
