using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	public class IntInputField : MonoBehaviour
	{
		[Serializable]
		public class OnSubmitEvent : UnityEvent<int>
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

		public void SetValue(int value)
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
