using System;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit.Forms
{
	public class CreateRoomUiForm : MonoBehaviour
	{
		[Serializable]
		public class OnSubmitEvent : UnityEvent<string, string, LobbyType, string[]>
		{
		}

		public InputField RoomNameInput;

		public InputField LobbyNameInput;

		public InputField ExpectedUsersInput;

		public Dropdown LobbyTypeInput;

		public OnSubmitEvent OnSubmit;

		public void Start()
		{
		}

		public void EndEditOnEnter()
		{
		}

		public void SubmitForm()
		{
		}
	}
}
