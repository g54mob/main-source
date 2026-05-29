using Photon.Realtime;
using UnityEngine;

namespace Photon.Pun.UtilityScripts
{
	public class ConnectAndJoinRandom : MonoBehaviourPunCallbacks
	{
		public bool AutoConnect;

		public byte Version;

		[Tooltip("The max number of players allowed in room. Once full, a new room will be created by the next connection attemping to join.")]
		public byte MaxPlayers;

		public int playerTTL;

		public void Start()
		{
		}

		public void ConnectNow()
		{
		}

		public override void OnConnectedToMaster()
		{
		}

		public override void OnJoinedLobby()
		{
		}

		public override void OnJoinRandomFailed(short returnCode, string message)
		{
		}

		public override void OnDisconnected(DisconnectCause cause)
		{
		}

		public override void OnJoinedRoom()
		{
		}
	}
}
