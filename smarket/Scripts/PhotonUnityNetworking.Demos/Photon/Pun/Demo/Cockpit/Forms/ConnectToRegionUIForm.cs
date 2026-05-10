using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit.Forms
{
	public class ConnectToRegionUIForm : MonoBehaviour
	{
		[Serializable]
		public class OnSubmitEvent : UnityEvent<string>
		{
		}

		public InputField RegionInput;

		public Dropdown RegionListInput;

		public OnSubmitEvent OnSubmit;

		public void Start()
		{
		}

		public void EndEditOnEnter()
		{
		}

		public void SetRegionFromDropDown(int index)
		{
		}

		public void SubmitForm()
		{
		}
	}
}
