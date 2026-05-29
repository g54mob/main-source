using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	public class BoolInputField : MonoBehaviour
	{
		[Serializable]
		public class OnSubmitEvent : UnityEvent<bool>
		{
		}

		public Toggle PropertyValueInput;

		public OnSubmitEvent OnSubmit;

		private bool registered;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnValueChanged(bool value)
		{
		}

		public void SetValue(bool value)
		{
		}
	}
}
