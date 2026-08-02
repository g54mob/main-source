using JUTPS.ActionScripts;
using JUTPS.JUInputSystem;
using UnityEngine;

namespace JUTPS.CrossPlataform
{
	public class AimControllSwitcher : MonoBehaviour
	{
		public AimOnMousePosition MouseLooker;

		public AimOnRightJoystickDirection JoystickLooker;

		private void Update()
		{
			if (!JUInputManager.IsUsingGamepad && !JUGameManager.IsMobile)
			{
				MouseLooker.enabled = true;
				JoystickLooker.enabled = false;
			}
			else
			{
				MouseLooker.enabled = false;
				JoystickLooker.enabled = true;
			}
		}
	}
}
