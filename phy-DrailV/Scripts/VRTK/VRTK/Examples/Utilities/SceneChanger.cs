using UnityEngine;
using UnityEngine.SceneManagement;

namespace VRTK.Examples.Utilities
{
	public class SceneChanger : MonoBehaviour
	{
		private bool canPress;

		private VRTK_ControllerReference controllerReference;

		private void Awake()
		{
			canPress = false;
			Invoke("ResetPress", 1f);
			DynamicGI.UpdateEnvironment();
		}

		private bool IsForwardPressed()
		{
			if (!VRTK_ControllerReference.IsValid(controllerReference))
			{
				return false;
			}
			if (canPress && VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Trigger, SDK_BaseController.ButtonPressTypes.Press, controllerReference) && VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Grip, SDK_BaseController.ButtonPressTypes.Press, controllerReference) && VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Touchpad, SDK_BaseController.ButtonPressTypes.Press, controllerReference))
			{
				return true;
			}
			return false;
		}

		private bool IsBackPressed()
		{
			if (!VRTK_ControllerReference.IsValid(controllerReference))
			{
				return false;
			}
			if (canPress && VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Trigger, SDK_BaseController.ButtonPressTypes.Press, controllerReference) && VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Grip, SDK_BaseController.ButtonPressTypes.Press, controllerReference) && VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.ButtonTwo, SDK_BaseController.ButtonPressTypes.Press, controllerReference))
			{
				return true;
			}
			return false;
		}

		private void ResetPress()
		{
			canPress = true;
		}

		private void Update()
		{
			GameObject controllerRightHand = VRTK_DeviceFinder.GetControllerRightHand(getActual: true);
			controllerReference = VRTK_ControllerReference.GetControllerReference(controllerRightHand);
			int buildIndex = SceneManager.GetActiveScene().buildIndex;
			int num = buildIndex;
			if (IsForwardPressed() || Input.GetKeyUp(KeyCode.Space))
			{
				num++;
				if (num >= SceneManager.sceneCountInBuildSettings)
				{
					num = 0;
				}
			}
			else if (IsBackPressed() || Input.GetKeyUp(KeyCode.Backspace))
			{
				num--;
				if (num < 0)
				{
					num = SceneManager.sceneCountInBuildSettings - 1;
				}
			}
			if (num != buildIndex)
			{
				SceneManager.LoadScene(num);
			}
		}
	}
}
