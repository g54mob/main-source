using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace OffroadExplorer.Lobby
{
	public class NetworkDisconnectHandler : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDisconnectFlowCoroutine_003Ed__49 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NetworkDisconnectHandler _003C_003E4__this;

			public HostLostReason reason;

			private bool _003CisAbruptDisconnect_003E5__2;

			private float _003Celapsed_003E5__3;

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
			public _003CDisconnectFlowCoroutine_003Ed__49(int _003C_003E1__state)
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
		private sealed class _003CShowPendingMessageDelayed_003Ed__50 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NetworkDisconnectHandler _003C_003E4__this;

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
			public _003CShowPendingMessageDelayed_003Ed__50(int _003C_003E1__state)
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
		private string lobbySceneName;

		[Header("Timeouts")]
		[Tooltip("Maximum time to wait for NetworkManager.Shutdown() to complete")]
		[SerializeField]
		private float shutdownTimeout;

		[Tooltip("Brief delay before scene load for visual feedback")]
		[SerializeField]
		private float transitionDelay;

		[Header("UI Settings")]
		[SerializeField]
		private PanelSettings panelSettings;

		[SerializeField]
		private int sortOrder;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[Header("Heartbeat Settings")]
		[Tooltip("Only enable heartbeat in game scenes, not in lobby (prevents false disconnects)")]
		[SerializeField]
		private bool onlyHeartbeatInGame;

		[Tooltip("Scene names where heartbeat should be active")]
		[SerializeField]
		private string[] gameSceneNames;

		private UIDocument uiDocument;

		private VisualElement root;

		private VisualElement disconnectRoot;

		private Label titleLabel;

		private Label messageLabel;

		private Button continueButton;

		private NetworkManager networkManager;

		private bool wasClient;

		private bool isShowingDisconnect;

		private bool hostEndingNotified;

		private bool isProcessingDisconnect;

		private HostLostReason pendingReason;

		private bool showPendingMessageOnLobbyLoad;

		private Coroutine disconnectCoroutine;

		private SteamConnectionMonitor connectionMonitor;

		public static NetworkDisconnectHandler Instance { get; private set; }

		private void Awake()
		{
		}

		private void SetupConnectionMonitor()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void SetupUIDocument()
		{
		}

		private void SubscribeToNetworkEvents()
		{
		}

		private void UnsubscribeFromNetworkEvents()
		{
		}

		private void SubscribeToHeartbeat()
		{
		}

		private void UnsubscribeFromHeartbeat()
		{
		}

		public void ResubscribeToNetworkEvents()
		{
		}

		private void OnClientConnected(ulong clientId)
		{
		}

		private bool IsInGameScene()
		{
			return false;
		}

		private void OnClientDisconnected(ulong clientId)
		{
		}

		private void OnTransportFailure()
		{
		}

		private void ClearTransportStateImmediately()
		{
		}

		private void OnHeartbeatTimeout()
		{
		}

		private void OnConnectionUnstable()
		{
		}

		private void OnConnectionRestored()
		{
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		private void EmergencyPlayerStateReset()
		{
		}

		private void HandleDisconnect(HostLostReason reason)
		{
		}

		[IteratorStateMachine(typeof(_003CDisconnectFlowCoroutine_003Ed__49))]
		private IEnumerator DisconnectFlowCoroutine(HostLostReason reason)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CShowPendingMessageDelayed_003Ed__50))]
		private IEnumerator ShowPendingMessageDelayed()
		{
			return null;
		}

		private string GetToastMessage(HostLostReason reason)
		{
			return null;
		}

		public void SuppressDisconnectHandling()
		{
		}

		public void OnHostEndingSession()
		{
		}

		public void OnHostDisconnectedAbruptly()
		{
		}

		public void OnHostLost(HostLostReason reason)
		{
		}

		public void ShowDisconnectMessage(string title, string message)
		{
		}

		private void OnContinueClicked()
		{
		}
	}
}
