using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;

namespace Photon.Pun.Demo.Asteroids
{
	public class PlayerOverviewPanel : MonoBehaviourPunCallbacks
	{
		public GameObject PlayerOverviewEntryPrefab;

		private Dictionary<int, GameObject> playerListEntries;

		public void Awake()
		{
		}

		public override void OnPlayerLeftRoom(Player otherPlayer)
		{
		}

		public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
		{
		}
	}
}
