using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Coherence.Cloud;
using Coherence.Log;
using PartyCSharpSDK;
using PlayFab.ClientModels;
using PlayFab.Party;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;

namespace VampireSurvivors
{
	public class PlayFabNetworkProvider : INetworkProvider
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoginWithPlayFab_003Ed__50 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public PlayFabNetworkProvider _003C_003E4__this;

			private TaskAwaiter<ILoginResult> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private Logger _logger;

		private PARTY_DIRECT_PEER_CONNECTIVITY_OPTIONS _connectivityOptions;

		private PlayFabMultiplayerManager _playFabMultiplayerManager;

		private int _expectedPeers;

		private bool _hostingSession;

		private float _currentTimeout;

		private PlayFabMultiplayerManager.OnNetworkJoinedHandler _hostJoinedHandler;

		private PlayFabMultiplayerManager.OnErrorEventHandler _errorHandler;

		private PlayFabMultiplayerManager.OnRemotePlayerJoinedHandler _playerJoinedHandler;

		private const float _expectedPeersTimeout = 12f;

		public NetworkProviders Provider => default(NetworkProviders);

		public NetworkType NetworkType => default(NetworkType);

		public bool UsesRsl => false;

		public bool IsReady { get; private set; }

		public string InitializationError { get; private set; }

		public Action OnJoinError { get; set; }

		public Action OnP2PSessionReady { get; set; }

		public Action<string> OnP2PSessionError { get; set; }

		public int HostConnectedPlayers => 0;

		public PlayFabNetworkProvider(Logger logger)
		{
		}

		public void JoinP2P(LobbySession lobbySession)
		{
		}

		private void OnNetworkJoined(object sender, string networkid)
		{
		}

		private void OnJoinNetworkError(object sender, PlayFabMultiplayerManagerErrorArgs args)
		{
		}

		public bool JoinGame(LobbySession lobbySession)
		{
			return false;
		}

		public void PrepareGame(LobbySession lobbySession, Action<bool, string, Dictionary<string, string>> onGameReady)
		{
		}

		public void HostGame()
		{
		}

		public Task ShutDown()
		{
			return null;
		}

		public void Update()
		{
		}

		private void OnP2PHostSessionFailInvoke()
		{
		}

		private void OnP2PSessionReadyInvoke()
		{
		}

		private void OnLoggedIn(PlayFab.ClientModels.LoginResult obj)
		{
		}

		[AsyncStateMachine(typeof(_003CLoginWithPlayFab_003Ed__50))]
		private void LoginWithPlayFab()
		{
		}
	}
}
