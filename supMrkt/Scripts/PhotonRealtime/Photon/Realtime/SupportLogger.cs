using System.Collections.Generic;
using System.Diagnostics;
using ExitGames.Client.Photon;
using UnityEngine;

namespace Photon.Realtime
{
	[DisallowMultipleComponent]
	[AddComponentMenu(null)]
	public class SupportLogger : MonoBehaviour, IConnectionCallbacks, IMatchmakingCallbacks, IInRoomCallbacks, ILobbyCallbacks, IErrorInfoCallback
	{
		public bool LogTrafficStats;

		private LoadBalancingClient client;

		private Stopwatch startStopwatch;

		private bool initialOnApplicationPauseSkipped;

		private int pingMax;

		private int pingMin;

		public LoadBalancingClient Client
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected void Start()
		{
		}

		protected void OnDestroy()
		{
		}

		protected void OnApplicationPause(bool pause)
		{
		}

		protected void OnApplicationQuit()
		{
		}

		public void StartLogStats()
		{
		}

		public void StopLogStats()
		{
		}

		private void StartTrackValues()
		{
		}

		private void StopTrackValues()
		{
		}

		private string GetFormattedTimestamp()
		{
			return null;
		}

		private void TrackValues()
		{
		}

		public void LogStats()
		{
		}

		private void LogBasics()
		{
		}

		public void OnConnected()
		{
		}

		public void OnConnectedToMaster()
		{
		}

		public void OnFriendListUpdate(List<FriendInfo> friendList)
		{
		}

		public void OnJoinedLobby()
		{
		}

		public void OnLeftLobby()
		{
		}

		public void OnCreateRoomFailed(short returnCode, string message)
		{
		}

		public void OnJoinedRoom()
		{
		}

		public void OnJoinRoomFailed(short returnCode, string message)
		{
		}

		public void OnJoinRandomFailed(short returnCode, string message)
		{
		}

		public void OnCreatedRoom()
		{
		}

		public void OnLeftRoom()
		{
		}

		public void OnDisconnected(DisconnectCause cause)
		{
		}

		public void OnRegionListReceived(RegionHandler regionHandler)
		{
		}

		public void OnRoomListUpdate(List<RoomInfo> roomList)
		{
		}

		public void OnPlayerEnteredRoom(Player newPlayer)
		{
		}

		public void OnPlayerLeftRoom(Player otherPlayer)
		{
		}

		public void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
		{
		}

		public void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
		{
		}

		public void OnMasterClientSwitched(Player newMasterClient)
		{
		}

		public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
		{
		}

		public void OnCustomAuthenticationFailed(string debugMessage)
		{
		}

		public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
		{
		}

		public void OnErrorInfo(ErrorInfo errorInfo)
		{
		}
	}
}
