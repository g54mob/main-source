using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.PunBasics
{
	public class Launcher : MonoBehaviourPunCallbacks
	{
		[Tooltip("The Ui Panel to let the user enter name, connect and play")]
		[SerializeField]
		private GameObject controlPanel;

		[Tooltip("The Ui Text to inform the user about the connection progress")]
		[SerializeField]
		private Text feedbackText;

		[Tooltip("The maximum number of players per room")]
		[SerializeField]
		private byte maxPlayersPerRoom;

		[Tooltip("The UI Loader Anime")]
		[SerializeField]
		private LoaderAnime loaderAnime;

		private bool isConnecting;

		private string gameVersion;

		private void Awake()
		{
		}

		public void Connect()
		{
		}

		private void LogFeedback(string message)
		{
		}

		public override void OnConnectedToMaster()
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
