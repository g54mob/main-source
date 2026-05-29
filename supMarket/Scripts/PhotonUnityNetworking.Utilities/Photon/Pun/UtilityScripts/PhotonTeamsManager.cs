using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;

namespace Photon.Pun.UtilityScripts
{
	[DisallowMultipleComponent]
	public class PhotonTeamsManager : MonoBehaviour, IMatchmakingCallbacks, IInRoomCallbacks
	{
		[SerializeField]
		private List<PhotonTeam> teamsList;

		private Dictionary<byte, PhotonTeam> teamsByCode;

		private Dictionary<string, PhotonTeam> teamsByName;

		private Dictionary<byte, HashSet<Player>> playersPerTeam;

		public const string TeamPlayerProp = "_pt";

		private static PhotonTeamsManager instance;

		public static PhotonTeamsManager Instance => null;

		public static event Action<Player, PhotonTeam> PlayerJoinedTeam
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

		public static event Action<Player, PhotonTeam> PlayerLeftTeam
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

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Init()
		{
		}

		void IMatchmakingCallbacks.OnJoinedRoom()
		{
		}

		void IMatchmakingCallbacks.OnLeftRoom()
		{
		}

		void IInRoomCallbacks.OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
		{
		}

		void IInRoomCallbacks.OnPlayerLeftRoom(Player otherPlayer)
		{
		}

		void IInRoomCallbacks.OnPlayerEnteredRoom(Player newPlayer)
		{
		}

		private void UpdateTeams()
		{
		}

		private void ClearTeams()
		{
		}

		public bool TryGetTeamByCode(byte code, out PhotonTeam team)
		{
			team = null;
			return false;
		}

		public bool TryGetTeamByName(string teamName, out PhotonTeam team)
		{
			team = null;
			return false;
		}

		public PhotonTeam[] GetAvailableTeams()
		{
			return null;
		}

		public bool TryGetTeamMembers(byte code, out Player[] members)
		{
			members = null;
			return false;
		}

		public bool TryGetTeamMembers(string teamName, out Player[] members)
		{
			members = null;
			return false;
		}

		public bool TryGetTeamMembers(PhotonTeam team, out Player[] members)
		{
			members = null;
			return false;
		}

		public bool TryGetTeamMatesOfPlayer(Player player, out Player[] teamMates)
		{
			teamMates = null;
			return false;
		}

		public int GetTeamMembersCount(byte code)
		{
			return 0;
		}

		public int GetTeamMembersCount(string name)
		{
			return 0;
		}

		public int GetTeamMembersCount(PhotonTeam team)
		{
			return 0;
		}

		void IMatchmakingCallbacks.OnFriendListUpdate(List<FriendInfo> friendList)
		{
		}

		void IMatchmakingCallbacks.OnCreatedRoom()
		{
		}

		void IMatchmakingCallbacks.OnCreateRoomFailed(short returnCode, string message)
		{
		}

		void IMatchmakingCallbacks.OnJoinRoomFailed(short returnCode, string message)
		{
		}

		void IMatchmakingCallbacks.OnJoinRandomFailed(short returnCode, string message)
		{
		}

		void IInRoomCallbacks.OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
		{
		}

		void IInRoomCallbacks.OnMasterClientSwitched(Player newMasterClient)
		{
		}
	}
}
