using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	public class StringInputField : MonoBehaviour
	{
		[Serializable]
		public class OnSubmitEvent : UnityEvent<string>
		{
		}

		public InputField PropertyValueInput;

		public OnSubmitEvent OnSubmit;

		private bool registered;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void SetValue(string value)
		{
		}

		public void EndEditOnEnter(string value)
		{
		}

		public void SubmitForm(string value)
		{
		}
	}
}
