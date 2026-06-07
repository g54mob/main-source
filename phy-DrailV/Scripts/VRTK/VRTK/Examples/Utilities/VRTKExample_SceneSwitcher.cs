using UnityEngine;
using UnityEngine.SceneManagement;

namespace VRTK.Examples.Utilities
{
	public class VRTKExample_SceneSwitcher : MonoBehaviour
	{
		public KeyCode backKey = KeyCode.Backspace;

		public KeyCode forwardKey = KeyCode.Space;

		protected int firstSceneIndex;

		protected int lastSceneIndex;

		protected bool pressEnabled;

		protected VRTK_ControllerReference controllerReference;

		protected virtual void Awake()
		{
			DynamicGI.UpdateEnvironment();
		}

		protected virtual void OnEnable()
		{
			lastSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
			pressEnabled = false;
			Invoke("EnablePress", 1f);
		}

		protected virtual void Update()
		{
			GameObject controllerRightHand = VRTK_DeviceFinder.GetControllerRightHand(getActual: true);
			controllerReference = VRTK_ControllerReference.GetControllerReference(controllerRightHand);
			int buildIndex = SceneManager.GetActiveScene().buildIndex;
			int num = buildIndex;
			if (ForwardPressed())
			{
				num++;
				if (num >= lastSceneIndex)
				{
					num = firstSceneIndex;
				}
			}
			else if (BackPressed())
			{
				num--;
				if (num < firstSceneIndex)
				{
					num = lastSceneIndex - 1;
				}
			}
			if (num != buildIndex)
			{
				SceneManager.LoadScene(num);
			}
		}

		protected virtual void EnablePress()
		{
			pressEnabled = true;
		}

		protected virtual bool BackPressed()
		{
			if (Input.GetKeyDown(backKey) || ControllerBackward())
			{
				return true;
			}
			return false;
		}

		protected virtual bool ForwardPressed()
		{
			if (Input.GetKeyDown(forwardKey) || ControllerForward())
			{
				return true;
			}
			return false;
		}

		protected virtual bool ControllerForward()
		{
			if (!VRTK_ControllerReference.IsValid(controllerReference))
			{
				return false;
			}
			if (pressEnabled && VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.ButtonTwo, SDK_BaseController.ButtonPressTypes.Press, controllerReference) && VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Touchpad, SDK_BaseController.ButtonPressTypes.Press, controllerReference))
			{
				return VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Trigger, SDK_BaseController.ButtonPressTypes.Press, controllerReference);
			}
			return false;
		}

		protected virtual bool ControllerBackward()
		{
			if (!VRTK_ControllerReference.IsValid(controllerReference))
			{
				return false;
			}
			if (pressEnabled && VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.ButtonTwo, SDK_BaseController.ButtonPressTypes.Press, controllerReference) && VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Touchpad, SDK_BaseController.ButtonPressTypes.Press, controllerReference))
			{
				return VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Grip, SDK_BaseController.ButtonPressTypes.Press, controllerReference);
			}
			return false;
		}
	}
}
