using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Realtime;

namespace Photon.Pun.UtilityScripts
{
	[Obsolete("do not use this or add it to the scene. use PhotonTeamsManager instead")]
	public class PunTeams : MonoBehaviourPunCallbacks
	{
		[Obsolete("use custom PhotonTeam instead")]
		public enum Team : byte
		{
			none = 0,
			red = 1,
			blue = 2
		}

		[Obsolete("use PhotonTeamsManager.Instance.TryGetTeamMembers instead")]
		public static Dictionary<Team, List<Player>> PlayersPerTeam;

		[Obsolete("do not use this. PhotonTeamsManager.TeamPlayerProp is used internally instead.")]
		public const string TeamPlayerProp = "team";

		public void Start()
		{
		}

		public override void OnDisable()
		{
		}

		public override void OnJoinedRoom()
		{
		}

		public override void OnLeftRoom()
		{
		}

		public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
		{
		}

		public override void OnPlayerLeftRoom(Player otherPlayer)
		{
		}

		public override void OnPlayerEnteredRoom(Player newPlayer)
		{
		}

		[Obsolete("do not call this.")]
		public void UpdateTeams()
		{
		}
	}
}
