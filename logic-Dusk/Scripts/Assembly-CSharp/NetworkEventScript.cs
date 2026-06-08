using System.Collections.Generic;
using UnityEngine;

public class NetworkEventScript : MonoBehaviour
{
	private Queue<NetworkEvent> _eventQueue = new Queue<NetworkEvent>();

	public static NetworkEventScript Instance()
	{
		GameObject gameObject = GameObject.Find("NetworkScriptObject");
		Component component = gameObject.GetComponent(typeof(NetworkEventScript));
		return (NetworkEventScript)component;
	}

	public NetworkEvent GetEvent()
	{
		if (_eventQueue.Count == 0)
		{
			return null;
		}
		return _eventQueue.Dequeue();
	}

	private void OnServerInitialized()
	{
		_eventQueue.Enqueue(new NetworkEvent(NetworkEventType.ServerInitialized));
	}

	private void OnConnectedToServer()
	{
		_eventQueue.Enqueue(new NetworkEvent(NetworkEventType.ConnectedToServer));
	}

	private void OnFailedToConnect(NetworkConnectionError error)
	{
		_eventQueue.Enqueue(new NetworkEvent(NetworkEventType.FailedToConnect, error));
	}

	private void OnFailedToConnectToMasterServer(NetworkConnectionError error)
	{
		_eventQueue.Enqueue(new NetworkEvent(NetworkEventType.FailedToConnectToMasterServer, error));
	}

	private void OnMasterServerEvent(MasterServerEvent masterServerEvent)
	{
		_eventQueue.Enqueue(new NetworkEvent(NetworkEventType.ReceivedMasterServerEvent, masterServerEvent));
	}

	private void OnPlayerConnected(NetworkPlayer player)
	{
		_eventQueue.Enqueue(new NetworkEvent(NetworkEventType.PlayerConnected, player));
	}

	private void OnPlayerDisconnected(NetworkPlayer player)
	{
		_eventQueue.Enqueue(new NetworkEvent(NetworkEventType.PlayerDisconnected, player));
	}

	private void OnDisconnectedFromServer(NetworkDisconnection info)
	{
		_eventQueue.Enqueue(new NetworkEvent(NetworkEventType.DisconnectedFromServer, info));
	}
}
