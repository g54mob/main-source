using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Steamworks;
using Unity.Netcode;

namespace Netcode.Transports
{
	public class SteamNetworkingSocketsTransport : NetworkTransport
	{
		private class SteamConnectionData
		{
			internal CSteamID id;

			internal HSteamNetConnection connection;

			internal SteamConnectionData(CSteamID steamId)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CDelay_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float time;

			public Action action;

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
			public _003CDelay_003Ed__24(int _003C_003E1__state)
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

		private Callback<SteamNetConnectionStatusChangedCallback_t> c_onConnectionChange;

		private HSteamListenSocket listenSocket;

		private SteamConnectionData serverUser;

		private readonly Dictionary<ulong, SteamConnectionData> connectionMapping;

		private readonly Queue<SteamNetConnectionStatusChangedCallback_t> connectionStatusChangeQueue;

		private bool isServer;

		public ulong ConnectToSteamID;

		public SteamNetworkingConfigValue_t[] options;

		public override ulong ServerClientId => 0uL;

		public override bool IsSupported => false;

		public override void DisconnectLocalClient()
		{
		}

		public override void DisconnectRemoteClient(ulong clientId)
		{
		}

		public override ulong GetCurrentRtt(ulong clientId)
		{
			return 0uL;
		}

		public override void Initialize(NetworkManager networkManager = null)
		{
		}

		public override NetworkEvent PollEvent(out ulong clientId, out ArraySegment<byte> payload, out float receiveTime)
		{
			clientId = default(ulong);
			payload = default(ArraySegment<byte>);
			receiveTime = default(float);
			return default(NetworkEvent);
		}

		public override void Send(ulong clientId, ArraySegment<byte> segment, NetworkDelivery delivery)
		{
		}

		public override void Shutdown()
		{
		}

		public override bool StartClient()
		{
			return false;
		}

		public override bool StartServer()
		{
			return false;
		}

		private void CloseP2PSessions()
		{
		}

		private void OnConnectionStatusChanged(SteamNetConnectionStatusChangedCallback_t param)
		{
		}

		[IteratorStateMachine(typeof(_003CDelay_003Ed__24))]
		private static IEnumerator Delay(float time, Action action)
		{
			return null;
		}
	}
}
