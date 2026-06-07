using Photon.Realtime;
using UnityEngine;

namespace Photon.Pun.Demo.PunBasics
{
	public class GameManager : MonoBehaviourPunCallbacks
	{
		public static GameManager Instance;

		private GameObject instance;

		[Tooltip("The prefab to use for representing the player")]
		[SerializeField]
		private GameObject playerPrefab;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public override void OnJoinedRoom()
		{
		}

		public override void OnPlayerEnteredRoom(Player other)
		{
		}

		public override void OnPlayerLeftRoom(Player other)
		{
		}

		public override void OnLeftRoom()
		{
		}

		public void LeaveRoom()
		{
		}

		public void QuitApplication()
		{
		}

		private void LoadArena()
		{
		}
	}
}
