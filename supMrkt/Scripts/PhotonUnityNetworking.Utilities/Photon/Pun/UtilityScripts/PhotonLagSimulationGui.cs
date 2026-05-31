using ExitGames.Client.Photon;
using UnityEngine;

namespace Photon.Pun.UtilityScripts
{
	public class PhotonLagSimulationGui : MonoBehaviour
	{
		public Rect WindowRect;

		public int WindowId;

		public bool Visible;

		public PhotonPeer Peer { get; set; }

		public void Start()
		{
		}

		public void OnGUI()
		{
		}

		private void NetSimHasNoPeerWindow(int windowId)
		{
		}

		private void NetSimWindow(int windowId)
		{
		}
	}
}
