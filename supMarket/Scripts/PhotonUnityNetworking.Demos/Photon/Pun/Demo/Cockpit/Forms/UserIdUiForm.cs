using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit.Forms
{
	public class UserIdUiForm : MonoBehaviour
	{
		[Serializable]
		public class OnSubmitEvent : UnityEvent<string>
		{
		}

		public const string UserIdPlayerPref = "PunUserId";

		public InputField idInput;

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
