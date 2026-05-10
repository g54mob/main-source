using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Asteroids
{
	public class PlayerListEntry : MonoBehaviour
	{
		[Header("UI References")]
		public Text PlayerNameText;

		public Image PlayerColorImage;

		public Button PlayerReadyButton;

		public Image PlayerReadyImage;

		private int ownerId;

		private bool isPlayerReady;

		public void OnEnable()
		{
		}

		public void Start()
		{
		}

		public void OnDisable()
		{
		}

		public void Initialize(int playerId, string playerName)
		{
		}

		private void OnPlayerNumberingChanged()
		{
		}

		public void SetPlayerReady(bool playerReady)
		{
		}
	}
}
