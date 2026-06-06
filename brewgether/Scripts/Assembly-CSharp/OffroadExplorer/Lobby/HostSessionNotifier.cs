using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

namespace OffroadExplorer.Lobby
{
	public class HostSessionNotifier : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDisconnectAllClientsAsync_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public HostSessionNotifier _003C_003E4__this;

			public float messageDeliveryWait;

			public float graceTimePerClient;

			private List<ulong> _003CclientIds_003E5__2;

			private List<ulong>.Enumerator _003C_003E7__wrap2;

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
			public _003CDisconnectAllClientsAsync_003Ed__18(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private const string HOST_ENDING_MESSAGE = "HostEndingSession";

		private bool isRegistered;

		public static HostSessionNotifier Instance { get; private set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void Start()
		{
		}

		private void TryRegisterIfConnected()
		{
		}

		private void Update()
		{
		}

		private void OnServerStarted()
		{
		}

		private void OnNetworkReady(ulong clientId)
		{
		}

		private void RegisterMessageHandler()
		{
		}

		private void UnregisterMessageHandler()
		{
		}

		private void OnDestroy()
		{
		}

		public void NotifyClientsHostEnding()
		{
		}

		[IteratorStateMachine(typeof(_003CDisconnectAllClientsAsync_003Ed__18))]
		public IEnumerator DisconnectAllClientsAsync(float graceTimePerClient = 0.3f, float messageDeliveryWait = 0.5f)
		{
			return null;
		}

		public void ForceDisconnectAllClientsImmediate()
		{
		}

		private void OnHostEndingMessageReceived(ulong senderClientId, FastBufferReader reader)
		{
		}

		private bool IsClientConnected(ulong clientId)
		{
			return false;
		}
	}
}
