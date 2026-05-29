using System;
using System.Runtime.CompilerServices;
using FishNet.Managing;
using FishNet.Transporting.Tugboat.Client;
using FishNet.Transporting.Tugboat.Server;
using LiteNetLib.Layers;
using UnityEngine;

namespace FishNet.Transporting.Tugboat
{
	[AddComponentMenu("FishNet/Transport/Tugboat")]
	[DisallowMultipleComponent]
	public class Tugboat : Transport
	{
		[Header("Channels")]
		[Tooltip("Maximum transmission unit for the unreliable channel.")]
		[Range(576f, 1023f)]
		[SerializeField]
		private int _unreliableMTU;

		[Header("Server")]
		[Tooltip("IPv4 Address to bind server to.")]
		[SerializeField]
		private string _ipv4BindAddress;

		[Tooltip("IPv6 Address to bind server to.")]
		[SerializeField]
		private string _ipv6BindAddress;

		[Tooltip("Port to use.")]
		[SerializeField]
		private ushort _port;

		[Range(1f, 9999f)]
		[SerializeField]
		[Tooltip("Maximum number of players which may be connected at once.")]
		private int _maximumClients;

		[Header("Client")]
		[Tooltip("Address to connect.")]
		[SerializeField]
		private string _clientAddress;

		[SerializeField]
		[Header("Misc")]
		[Tooltip("How long in seconds until either the server or client socket must go without data before being timed out. Use 0f to disable timing out.")]
		[Range(0f, 1800f)]
		private ushort _timeout;

		private PacketLayerBase _packetLayer;

		private ServerSocket _server;

		private ClientSocket _client;

		private const ushort MAX_TIMEOUT_SECONDS = 1800;

		private const int MINIMUM_UDP_MTU = 576;

		private const int MAXIMUM_UDP_MTU = 1023;

		public override event Action<ClientConnectionStateArgs> OnClientConnectionState
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

		public override event Action<ServerConnectionStateArgs> OnServerConnectionState
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

		public override event Action<RemoteConnectionStateArgs> OnRemoteConnectionState
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

		public override event Action<ClientReceivedDataArgs> OnClientReceivedData
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

		public override event Action<ServerReceivedDataArgs> OnServerReceivedData
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

		~Tugboat()
		{
		}

		public override void Initialize(NetworkManager networkManager, int transportIndex)
		{
		}

		protected void OnDestroy()
		{
		}

		public override string GetConnectionAddress(int connectionId)
		{
			return null;
		}

		public override LocalConnectionState GetConnectionState(bool server)
		{
			return default(LocalConnectionState);
		}

		public override RemoteConnectionState GetConnectionState(int connectionId)
		{
			return default(RemoteConnectionState);
		}

		public override void HandleClientConnectionState(ClientConnectionStateArgs connectionStateArgs)
		{
		}

		public override void HandleServerConnectionState(ServerConnectionStateArgs connectionStateArgs)
		{
		}

		public override void HandleRemoteConnectionState(RemoteConnectionStateArgs connectionStateArgs)
		{
		}

		private void TimeManager_OnUpdate()
		{
		}

		public override void IterateIncoming(bool server)
		{
		}

		public override void IterateOutgoing(bool server)
		{
		}

		public override void HandleClientReceivedDataArgs(ClientReceivedDataArgs receivedDataArgs)
		{
		}

		public override void HandleServerReceivedDataArgs(ServerReceivedDataArgs receivedDataArgs)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void SendToServer(byte channelId, ArraySegment<byte> segment)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void SendToClient(byte channelId, ArraySegment<byte> segment, int connectionId)
		{
		}

		public void SetPacketLayer(PacketLayerBase packetLayer)
		{
		}

		public override float GetTimeout(bool asServer)
		{
			return 0f;
		}

		public override void SetTimeout(float value, bool asServer)
		{
		}

		public override int GetMaximumClients()
		{
			return 0;
		}

		public override void SetMaximumClients(int value)
		{
		}

		public override void SetClientAddress(string address)
		{
		}

		public override string GetClientAddress()
		{
			return null;
		}

		public override void SetServerBindAddress(string address, IPAddressType addressType)
		{
		}

		public override string GetServerBindAddress(IPAddressType addressType)
		{
			return null;
		}

		public override void SetPort(ushort port)
		{
		}

		public override ushort GetPort()
		{
			return 0;
		}

		public override bool StartConnection(bool server)
		{
			return false;
		}

		public override bool StopConnection(bool server)
		{
			return false;
		}

		public override bool StopConnection(int connectionId, bool immediately)
		{
			return false;
		}

		public override void Shutdown()
		{
		}

		private bool StartServer()
		{
			return false;
		}

		private bool StopServer()
		{
			return false;
		}

		private bool StartClient(string address)
		{
			return false;
		}

		private void UpdateTimeout()
		{
		}

		private bool StopClient()
		{
			return false;
		}

		private void SanitizeChannel(ref byte channelId)
		{
		}

		public override int GetMTU(byte channel)
		{
			return 0;
		}
	}
}
