using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace OffroadExplorer.Lobby
{
	public class NetworkSessionManager : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CGracefulShutdownAsync_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NetworkSessionManager _003C_003E4__this;

			public bool returnToLobby;

			private float _003Celapsed_003E5__2;

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
			public _003CGracefulShutdownAsync_003Ed__11(int _003C_003E1__state)
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

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private bool isShuttingDown;

		private Coroutine shutdownCoroutine;

		public static NetworkSessionManager Instance { get; private set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		[IteratorStateMachine(typeof(_003CGracefulShutdownAsync_003Ed__11))]
		public IEnumerator GracefulShutdownAsync(bool returnToLobby = true)
		{
			return null;
		}

		public void StartGracefulShutdown(bool returnToLobby = true)
		{
		}

		public void EmergencyShutdown()
		{
		}

		private void EmergencyStateReset()
		{
		}

		private void ForceDisconnectAllClients()
		{
		}

		private int GetConnectedClientCount()
		{
			return 0;
		}

		private void OnApplicationQuit()
		{
		}
	}
}
