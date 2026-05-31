using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.PunBasics
{
	[RequireComponent(typeof(InputField))]
	public class PlayerNameInputField : MonoBehaviour
	{
		private const string playerNamePrefKey = "PlayerName";

		private void Start()
		{
		}

		public void SetPlayerName(string value)
		{
		}
	}
}
