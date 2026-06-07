using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Netcode.Transports;
using Unity.Netcode;
using UnityEngine;

namespace OffroadExplorer.Lobby
{
	public class LobbyNetworkManager : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass15_0
		{
			public bool relayReady;

			internal void _003CStartHostInternal_003Eb__0(bool success)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass17_0
		{
			public bool relayReady;

			internal void _003CStartClientInternal_003Eb__0(bool success)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CMonitorClientTransportState_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LobbyNetworkManager _003C_003E4__this;

			private float _003CmonitorTime_003E5__2;

			private float _003Celapsed_003E5__3;

			private bool _003CwasConnected_003E5__4;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CMonitorClientTransportState_003Ed__39(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CMonitorHostTransportState_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LobbyNetworkManager _003C_003E4__this;

			private float _003CmonitorTime_003E5__2;

			private float _003Celapsed_003E5__3;

			private int _003ClastClientCount_003E5__4;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CMonitorHostTransportState_003Ed__38(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CStartClientInternal_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LobbyNetworkManager _003C_003E4__this;

			private _003C_003Ec__DisplayClass17_0 _003C_003E8__1;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CStartClientInternal_003Ed__17(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CStartHostInternal_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LobbyNetworkManager _003C_003E4__this;

			private _003C_003Ec__DisplayClass15_0 _003C_003E8__1;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CStartHostInternal_003Ed__15(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CWaitForRelayNetworkReady_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LobbyNetworkManager _003C_003E4__this;

			public Action<bool> callback;

			private float _003CmaxWaitTime_003E5__2;

			private float _003Celapsed_003E5__3;

			private float _003CpollInterval_003E5__4;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitForRelayNetworkReady_003Ed__20(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("Scene Settings")]
		[SerializeField]
		private string gameSceneName;

		[SerializeField]
		private string lobbySceneName;

		[Header("Player Settings")]
		[SerializeField]
		private GameObject lobbyPlayerPrefab;

		private NetworkManager networkManager;

		private SteamNetworkingSocketsTransport steamTransport;

		private readonly Dictionary<ulong, LobbyPlayerData> connectedPlayers;

		public static LobbyNetworkManager Instance { get; private set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnApplicationFocus(bool hasFocus)
		{
		}

		public bool StartHost()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CStartHostInternal_003Ed__15))]
		private IEnumerator StartHostInternal()
		{
			return null;
		}

		public bool StartClient()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CStartClientInternal_003Ed__17))]
		private IEnumerator StartClientInternal()
		{
			return null;
		}

		public void Shutdown()
		{
		}

		private bool IsRelayNetworkAvailable()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CWaitForRelayNetworkReady_003Ed__20))]
		private IEnumerator WaitForRelayNetworkReady(Action<bool> callback)
		{
			return null;
		}

		private void ConfigureSteamTransport()
		{
		}

		private void OnServerStarted()
		{
		}

		private void OnClientConnected(ulong clientId)
		{
		}

		private void OnClientDisconnected(ulong clientId)
		{
		}

		private void OnTransportFailure()
		{
		}

		public void DespawnAllLobbyPlayers()
		{
		}

		public void StartGame()
		{
		}

		public void ReturnToLobby()
		{
		}

		public bool AreAllPlayersReady()
		{
			return false;
		}

		public int GetReadyPlayerCount()
		{
			return 0;
		}

		public List<LobbyPlayerData> GetConnectedPlayers()
		{
			return null;
		}

		public LobbyPlayerData GetLocalPlayerData()
		{
			return null;
		}

		internal void ServerRegisterPlayer(LobbyPlayerData player)
		{
		}

		internal void ServerUnregisterPlayer(LobbyPlayerData player)
		{
		}

		private void SpawnLobbyPlayer(ulong clientId)
		{
		}

		private bool IsPrefabRegistered(GameObject prefab)
		{
			return false;
		}

		private void ValidateTransportInitialization(bool isHost)
		{
		}

		[IteratorStateMachine(typeof(_003CMonitorHostTransportState_003Ed__38))]
		private IEnumerator MonitorHostTransportState()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CMonitorClientTransportState_003Ed__39))]
		private IEnumerator MonitorClientTransportState()
		{
			return null;
		}

		private void RecoverFromFailedConnection(string reason)
		{
		}

		public bool IsHost()
		{
			return false;
		}

		public bool IsClient()
		{
			return false;
		}

		public bool IsConnected()
		{
			return false;
		}
	}
}
