using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit.Forms
{
	public class SetRoomCustomPropertyUIForm : MonoBehaviour
	{
		[Serializable]
		public class OnSubmitEvent : UnityEvent<string>
		{
		}

		public InputField PropertyValueInput;

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
