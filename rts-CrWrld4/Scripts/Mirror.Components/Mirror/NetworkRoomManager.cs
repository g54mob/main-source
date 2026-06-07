using System.Collections.Generic;
using UnityEngine;

namespace Mirror
{
	public class NetworkRoomManager : NetworkManager
	{
		public struct PendingPlayer
		{
			public NetworkConnection conn;

			public GameObject roomPlayer;
		}

		[SerializeField]
		public bool showRoomGUI;

		[SerializeField]
		public int minPlayers;

		[SerializeField]
		public NetworkRoomPlayer roomPlayerPrefab;

		[Scene]
		public string RoomScene;

		[Scene]
		public string GameplayScene;

		public List<PendingPlayer> pendingPlayers;

		[SerializeField]
		private bool _allPlayersReady;

		public List<NetworkRoomPlayer> roomSlots;

		public int clientIndex;

		public bool allPlayersReady
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override void OnValidate()
		{
		}

		public void ReadyStatusChanged()
		{
		}

		public override void OnServerReady(NetworkConnection conn)
		{
		}

		private void SceneLoadedForPlayer(NetworkConnection conn, GameObject roomPlayer)
		{
		}

		public void CheckReadyToBegin()
		{
		}

		internal void CallOnClientEnterRoom()
		{
		}

		internal void CallOnClientExitRoom()
		{
		}

		public override void OnServerConnect(NetworkConnection conn)
		{
		}

		public override void OnServerDisconnect(NetworkConnection conn)
		{
		}

		public override void OnServerAddPlayer(NetworkConnection conn)
		{
		}

		[Server]
		public void RecalculateRoomPlayerIndices()
		{
		}

		public override void ServerChangeScene(string newSceneName)
		{
		}

		public override void OnServerSceneChanged(string sceneName)
		{
		}

		public override void OnStartServer()
		{
		}

		public override void OnStartHost()
		{
		}

		public override void OnStopServer()
		{
		}

		public override void OnStopHost()
		{
		}

		public override void OnStartClient()
		{
		}

		public override void OnClientConnect(NetworkConnection conn)
		{
		}

		public override void OnClientDisconnect(NetworkConnection conn)
		{
		}

		public override void OnStopClient()
		{
		}

		public override void OnClientSceneChanged(NetworkConnection conn)
		{
		}

		public virtual void OnRoomStartHost()
		{
		}

		public virtual void OnRoomStopHost()
		{
		}

		public virtual void OnRoomStartServer()
		{
		}

		public virtual void OnRoomStopServer()
		{
		}

		public virtual void OnRoomServerConnect(NetworkConnection conn)
		{
		}

		public virtual void OnRoomServerDisconnect(NetworkConnection conn)
		{
		}

		public virtual void OnRoomServerSceneChanged(string sceneName)
		{
		}

		public virtual GameObject OnRoomServerCreateRoomPlayer(NetworkConnection conn)
		{
			return null;
		}

		public virtual GameObject OnRoomServerCreateGamePlayer(NetworkConnection conn, GameObject roomPlayer)
		{
			return null;
		}

		public virtual void OnRoomServerAddPlayer(NetworkConnection conn)
		{
		}

		public virtual bool OnRoomServerSceneLoadedForPlayer(NetworkConnection conn, GameObject roomPlayer, GameObject gamePlayer)
		{
			return false;
		}

		public virtual void OnRoomServerPlayersReady()
		{
		}

		public virtual void OnRoomServerPlayersNotReady()
		{
		}

		public virtual void OnRoomClientEnter()
		{
		}

		public virtual void OnRoomClientExit()
		{
		}

		public virtual void OnRoomClientConnect(NetworkConnection conn)
		{
		}

		public virtual void OnRoomClientDisconnect(NetworkConnection conn)
		{
		}

		public virtual void OnRoomStartClient()
		{
		}

		public virtual void OnRoomStopClient()
		{
		}

		public virtual void OnRoomClientSceneChanged(NetworkConnection conn)
		{
		}

		public virtual void OnRoomClientAddPlayerFailed()
		{
		}

		public virtual void OnGUI()
		{
		}
	}
}
