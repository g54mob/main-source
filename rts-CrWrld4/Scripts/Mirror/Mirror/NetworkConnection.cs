using System;
using System.Collections.Generic;

namespace Mirror
{
	public abstract class NetworkConnection
	{
		public const int LocalConnectionId = 0;

		internal readonly HashSet<NetworkIdentity> observing;

		private Dictionary<int, NetworkMessageDelegate> messageHandlers;

		public readonly int connectionId;

		public bool isAuthenticated;

		public object authenticationData;

		public bool isReady;

		public float lastMessageTime;

		public readonly HashSet<NetworkIdentity> clientOwnedObjects;

		public abstract string address { get; }

		public NetworkIdentity identity { get; internal set; }

		internal NetworkConnection()
		{
		}

		internal NetworkConnection(int networkConnectionId)
		{
		}

		public abstract void Disconnect();

		internal void SetHandlers(Dictionary<int, NetworkMessageDelegate> handlers)
		{
		}

		public void Send<T>(T msg, int channelId = 0) where T : struct, NetworkMessage
		{
		}

		protected static bool ValidatePacketSize(ArraySegment<byte> segment, int channelId)
		{
			return false;
		}

		internal abstract void Send(ArraySegment<byte> segment, int channelId = 0);

		public override string ToString()
		{
			return null;
		}

		internal void AddToObserving(NetworkIdentity netIdentity)
		{
		}

		internal void RemoveFromObserving(NetworkIdentity netIdentity, bool isDestroyed)
		{
		}

		internal void RemoveObservers()
		{
		}

		protected bool UnpackAndInvoke(NetworkReader reader, int channelId)
		{
			return false;
		}

		internal void TransportReceive(ArraySegment<byte> buffer, int channelId)
		{
		}

		internal virtual bool IsAlive(float timeout)
		{
			return false;
		}

		internal void AddOwnedObject(NetworkIdentity obj)
		{
		}

		internal void RemoveOwnedObject(NetworkIdentity obj)
		{
		}

		internal void DestroyOwnedObjects()
		{
		}
	}
}
