using System;
using System.Runtime.CompilerServices;
using FishNet.Authenticating;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Transporting;
using UnityEngine;

namespace FishNet.Example.Authenticating
{
	public class PasswordAuthenticator : HostAuthenticator
	{
		[Tooltip("Password to authenticate.")]
		[SerializeField]
		private string _password;

		public override event Action<NetworkConnection, bool> OnAuthenticationResult
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public override void InitializeOnce(NetworkManager networkManager)
		{
		}

		private void ClientManager_OnClientConnectionState(ClientConnectionStateArgs args)
		{
		}

		private void OnPasswordBroadcast(NetworkConnection conn, PasswordBroadcast pb)
		{
		}

		private void OnResponseBroadcast(ResponseBroadcast rb)
		{
		}

		private void SendAuthenticationResponse(NetworkConnection conn, bool authenticated)
		{
		}

		protected override void OnHostAuthenticationResult(NetworkConnection conn, bool authenticated)
		{
		}
	}
}
