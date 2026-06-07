using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Coherence.Cloud;
using Coherence.Log;

namespace VampireSurvivors
{
	public class SteamNetworkProvider : INetworkProvider
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CShutDown_003Ed__39 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public SteamNetworkProvider _003C_003E4__this;

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

		private SteamSocketManager _steamSocketManager;

		private SteamConnectionManager _steamConnectionManager;

		private float _currentTimeout;

		private bool _hostingSession;

		private const float _expectedPeersTimeout = 12f;

		public NetworkProviders Provider => default(NetworkProviders);

		public NetworkType NetworkType => default(NetworkType);

		public bool UsesRsl => false;

		public bool IsReady => false;

		public string InitializationError { get; private set; }

		public Action OnJoinError { get; set; }

		public Action OnP2PSessionReady { get; set; }

		public Action<string> OnP2PSessionError { get; set; }

		public int HostConnectedPlayers => 0;

		public SteamNetworkProvider(Logger logger)
		{
		}

		public void JoinP2P(LobbySession lobbySession)
		{
		}

		private void OnP2PActivationFailed(string errorMessage)
		{
		}

		public bool JoinGame(LobbySession lobbySession)
		{
			return false;
		}

		public void PrepareGame(LobbySession lobbySession, Action<bool, string, Dictionary<string, string>> onGameReady)
		{
		}

		private void OnP2PSessionBecomeReady()
		{
		}

		public void HostGame()
		{
		}

		[AsyncStateMachine(typeof(_003CShutDown_003Ed__39))]
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

		private bool CheckLoginStatus()
		{
			return false;
		}
	}
}
