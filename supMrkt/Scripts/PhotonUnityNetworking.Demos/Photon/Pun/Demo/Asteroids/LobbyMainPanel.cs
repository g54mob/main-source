using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Asteroids
{
	public class LobbyMainPanel : MonoBehaviourPunCallbacks
	{
		[Header("Login Panel")]
		public GameObject LoginPanel;

		public InputField PlayerNameInput;

		[Header("Selection Panel")]
		public GameObject SelectionPanel;

		[Header("Create Room Panel")]
		public GameObject CreateRoomPanel;

		public InputField RoomNameInputField;

		public InputField MaxPlayersInputField;

		[Header("Join Random Room Panel")]
		public GameObject JoinRandomRoomPanel;

		[Header("Room List Panel")]
		public GameObject RoomListPanel;

		public GameObject RoomListContent;

		public GameObject RoomListEntryPrefab;

		[Header("Inside Room Panel")]
		public GameObject InsideRoomPanel;

		public Button StartGameButton;

		public GameObject PlayerListEntryPrefab;

		private Dictionary<string, RoomInfo> cachedRoomList;

		private Dictionary<string, GameObject> roomListEntries;

		private Dictionary<int, GameObject> playerListEntries;

		public void Awake()
		{
		}

		public override void OnConnectedToMaster()
		{
		}

		public override void OnRoomListUpdate(List<RoomInfo> roomList)
		{
		}

		public override void OnJoinedLobby()
		{
		}

		public override void OnLeftLobby()
		{
		}

		public override void OnCreateRoomFailed(short returnCode, string message)
		{
		}

		public override void OnJoinRoomFailed(short returnCode, string message)
		{
		}

		public override void OnJoinRandomFailed(short returnCode, string message)
		{
		}

		public override void OnJoinedRoom()
		{
		}

		public override void OnLeftRoom()
		{
		}

		public override void OnPlayerEnteredRoom(Player newPlayer)
		{
		}

		public override void OnPlayerLeftRoom(Player otherPlayer)
		{
		}

		public override void OnMasterClientSwitched(Player newMasterClient)
		{
		}

		public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
		{
		}

		public void OnBackButtonClicked()
		{
		}

		public void OnCreateRoomButtonClicked()
		{
		}

		public void OnJoinRandomRoomButtonClicked()
		{
		}

		public void OnLeaveGameButtonClicked()
		{
		}

		public void OnLoginButtonClicked()
		{
		}

		public void OnRoomListButtonClicked()
		{
		}

		public void OnStartGameButtonClicked()
		{
		}

		private bool CheckPlayersReady()
		{
			return false;
		}

		private void ClearRoomListView()
		{
		}

		public void LocalPlayerPropertiesUpdated()
		{
		}

		private void SetActivePanel(string activePanel)
		{
		}

		private void UpdateCachedRoomList(List<RoomInfo> roomList)
		{
		}

		private void UpdateRoomListView()
		{
		}
	}
}
