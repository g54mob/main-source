using JUTPS.JUInputSystem;
using UnityEngine;

namespace JUTPS.CrossPlataform
{
	public class CurrentDeviceChangeVisibility : MonoBehaviour
	{
		public GameObject KeyboardObject;

		public GameObject GamepadObject;

		private void Update()
		{
			KeyboardObject.SetActive(!JUInputManager.IsUsingGamepad);
			GamepadObject.SetActive(JUInputManager.IsUsingGamepad);
		}
	}
}
