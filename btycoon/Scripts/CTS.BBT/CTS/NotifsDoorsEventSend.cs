using System;
using UnityEngine;

namespace CTS
{
	public class NotifsDoorsEventSend : MonoBehaviour
	{
		public static event Action TogglePressed;

		public void OnToggleClick()
		{
			NotifsDoorsEventSend.TogglePressed?.Invoke();
		}
	}
}
