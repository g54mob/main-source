using UnityEngine;

namespace Dorfromantik
{
	public class CrosshairsMovement : MonoBehaviour
	{
		private InputManager inputManager;

		[SerializeField]
		private GameObject crosshairs;

		private void Start()
		{
			inputManager = Singleton<InputManager>.Instance;
			inputManager.OnGamepadInputTypeChanged += ChangeCrosshairsVisibility;
		}

		private void ChangeCrosshairsVisibility(GamepadInputType gamepadInputType)
		{
			Debug.Log($"Change Crosshairs Visibility {gamepadInputType}");
			crosshairs.SetActive(gamepadInputType == GamepadInputType.CrossHairs);
		}

		private void OnDestroy()
		{
			inputManager.OnGamepadInputTypeChanged -= ChangeCrosshairsVisibility;
		}
	}
}
