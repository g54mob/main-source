using System;
using FishNet.Managing;
using UnityEngine;

namespace FishNet.Transporting
{
	public abstract class Transport : MonoBehaviour
	{
		public NetworkManager NetworkManager { get; private set; }

		public int Index { get; private set; }

		public abstract event Action<ClientConnectionStateArgs> OnClientConnectionState;

		public abstract event Action<ServerConnectionStateArgs> OnServerConnectionState;

		public abstract event Action<RemoteConnectionStateArgs> OnRemoteConnectionState;

		public abstract event Action<ClientReceivedDataArgs> OnClientReceivedData;

		public abstract event Action<ServerReceivedDataArgs> OnServerReceivedData;

		public virtual void Initialize(NetworkManager networkManager, int transportIndex)
		{
		}

		public abstract string GetConnectionAddress(int connectionId);

		public abstract void HandleClientConnectionState(ClientConnectionStateArgs connectionStateArgs);

		public abstract void HandleServerConnectionState(ServerConnectionStateArgs connectionStateArgs);

		public abstract void HandleRemoteConnectionState(RemoteConnectionStateArgs connectionStateArgs);

		public abstract LocalConnectionState GetConnectionState(bool server);

		public abstract RemoteConnectionState GetConnectionState(int connectionId);

		public abstract void SendToServer(byte channelId, ArraySegment<byte> segment);

		public abstract void SendToClient(byte channelId, ArraySegment<byte> segment, int connectionId);

		public abstract void HandleClientReceivedDataArgs(ClientReceivedDataArgs receivedDataArgs);

		public abstract void HandleServerReceivedDataArgs(ServerReceivedDataArgs receivedDataArgs);

		public abstract void IterateIncoming(bool server);

		public abstract void IterateOutgoing(bool server);

		public virtual bool IsLocalTransport(int connectionid)
		{
			return false;
		}

		public virtual float GetTimeout(bool asServer)
		{
			return 0f;
		}

		public virtual void SetTimeout(float value, bool asServer)
		{
		}

		public virtual int GetMaximumClients()
		{
			return 0;
		}

		public virtual void SetMaximumClients(int value)
		{
		}

		public virtual void SetClientAddress(string address)
		{
		}

		public virtual string GetClientAddress()
		{
			return null;
		}

		public virtual void SetServerBindAddress(string address, IPAddressType addressType)
		{
		}

		public virtual string GetServerBindAddress(IPAddressType addressType)
		{
			return null;
		}

		public virtual void SetPort(ushort port)
		{
		}

		public virtual ushort GetPort()
		{
			return 0;
		}

		public abstract bool StartConnection(bool server);

		public abstract bool StopConnection(bool server);

		public abstract bool StopConnection(int connectionId, bool immediately);

		public abstract void Shutdown();

		public abstract int GetMTU(byte channel);
	}
}
