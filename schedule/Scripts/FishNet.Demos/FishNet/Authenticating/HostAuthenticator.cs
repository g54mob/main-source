using FishNet.Connection;
using FishNet.Example.Authenticating;
using FishNet.Managing;
using FishNet.Transporting;
using UnityEngine;

namespace FishNet.Authenticating
{
	public abstract class HostAuthenticator : Authenticator
	{
		[SerializeField]
		[Tooltip("True to enable use of AuthenticateAsHost.")]
		private bool _allowHostAuthentication;

		private static string _hostHash;

		public void SetAllowHostAuthentication(bool value)
		{
		}

		public bool GetAllowHostAuthentication()
		{
			return false;
		}

		public override void InitializeOnce(NetworkManager networkManager)
		{
		}

		private void ServerManager_OnServerConnectionState(ServerConnectionStateArgs obj)
		{
		}

		private void OnHostPasswordBroadcast(NetworkConnection conn, HostPasswordBroadcast hpb)
		{
		}

		protected abstract void OnHostAuthenticationResult(NetworkConnection conn, bool authenticated);

		private void SetHostHash(int length)
		{
		}

		protected bool AuthenticateAsHost()
		{
			return false;
		}
	}
}
