using System;
using UnityEngine;

namespace Mirror
{
	public abstract class Transport : MonoBehaviour
	{
		public static Transport activeTransport;

		public Action OnClientConnected;

		public Action<ArraySegment<byte>, int> OnClientDataReceived;

		public Action<Exception> OnClientError;

		public Action OnClientDisconnected;

		public Action<int> OnServerConnected;

		public Action<int, ArraySegment<byte>, int> OnServerDataReceived;

		public Action<int, Exception> OnServerError;

		public Action<int> OnServerDisconnected;

		public abstract bool Available();

		public abstract bool ClientConnected();

		public abstract void ClientConnect(string address);

		public virtual void ClientConnect(Uri uri)
		{
		}

		public abstract void ClientSend(int channelId, ArraySegment<byte> segment);

		public abstract void ClientDisconnect();

		public abstract Uri ServerUri();

		public abstract bool ServerActive();

		public abstract void ServerStart();

		public abstract void ServerSend(int connectionId, int channelId, ArraySegment<byte> segment);

		public abstract bool ServerDisconnect(int connectionId);

		public abstract string ServerGetClientAddress(int connectionId);

		public abstract void ServerStop();

		public abstract int GetMaxPacketSize(int channelId = 0);

		public virtual int GetMaxBatchSize(int channelId)
		{
			return 0;
		}

		public void Update()
		{
		}

		public void LateUpdate()
		{
		}

		public virtual void ClientEarlyUpdate()
		{
		}

		public virtual void ServerEarlyUpdate()
		{
		}

		public virtual void ClientLateUpdate()
		{
		}

		public virtual void ServerLateUpdate()
		{
		}

		public abstract void Shutdown();

		public virtual void OnApplicationQuit()
		{
		}
	}
}
