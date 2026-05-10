using Photon.Realtime;

namespace __Project__.Scripts.Multiplayer
{
	public class PhotonExitManager : NoktaSingletonPunCallbacks<PhotonExitManager>
	{
		public bool IsQuitting;

		private void Awake()
		{
		}

		public override void OnDisconnected(DisconnectCause cause)
		{
		}

		private void OnApplicationQuit()
		{
		}
	}
}
