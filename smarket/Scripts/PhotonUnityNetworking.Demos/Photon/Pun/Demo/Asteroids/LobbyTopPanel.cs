using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Asteroids
{
	public class LobbyTopPanel : MonoBehaviour
	{
		private readonly string connectionStatusMessage;

		[Header("UI References")]
		public Text ConnectionStatusText;

		public void Update()
		{
		}
	}
}
