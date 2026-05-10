using UnityEngine;

namespace __Project__.Scripts.ControllerInputModule
{
	public class GamepadSwitch : MonoBehaviour
	{
		public bool openOverride;

		[HideInInspector]
		public bool isSelected;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public void Switch(bool willOpen)
		{
		}
	}
}
