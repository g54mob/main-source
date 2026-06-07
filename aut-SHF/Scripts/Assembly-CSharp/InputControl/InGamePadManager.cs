using UnityEngine;
using UnityEngine.InputSystem;

namespace InputControl
{
	public class InGamePadManager : MonoBehaviour, InputActionController.IInGameActions
	{
		[SerializeField]
		private GameObject _uiCursorGo;

		private InputAction _pointerDeltaAction;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		public void OnCameraScroll(InputAction.CallbackContext context)
		{
		}

		public void OnCameraMode(InputAction.CallbackContext context)
		{
		}

		public void OnRulerMode(InputAction.CallbackContext context)
		{
		}

		public void OnSpuit(InputAction.CallbackContext context)
		{
		}

		public void OnRotate(InputAction.CallbackContext context)
		{
		}

		public void OnCounterRotate(InputAction.CallbackContext context)
		{
		}

		public void OnLongThinkMode(InputAction.CallbackContext context)
		{
		}

		public void OnPause(InputAction.CallbackContext context)
		{
		}

		public void OnShowGuide(InputAction.CallbackContext context)
		{
		}

		public void OnSwitchToggle(InputAction.CallbackContext context)
		{
		}

		public void OnEnterTips(InputAction.CallbackContext context)
		{
		}

		public void OnModeCancel(InputAction.CallbackContext context)
		{
		}

		public void OnCameraMoveUp(InputAction.CallbackContext context)
		{
		}

		public void OnCameraMoveLeft(InputAction.CallbackContext context)
		{
		}

		public void OnCameraMoveDown(InputAction.CallbackContext context)
		{
		}

		public void OnCameraMoveRight(InputAction.CallbackContext context)
		{
		}

		public void OnCameraMoveUpByStick(InputAction.CallbackContext context)
		{
		}

		public void OnCameraMoveLeftByStick(InputAction.CallbackContext context)
		{
		}

		public void OnCameraMoveDownByStick(InputAction.CallbackContext context)
		{
		}

		public void OnCameraMoveRightByStick(InputAction.CallbackContext context)
		{
		}

		public void OnCameraMoveLStick(InputAction.CallbackContext context)
		{
		}

		public void OnOpenResearchTree(InputAction.CallbackContext context)
		{
		}

		public void OnSwitchScene(InputAction.CallbackContext context)
		{
		}

		public void OnChangeSpeed(InputAction.CallbackContext context)
		{
		}

		public void OnOpenCollection(InputAction.CallbackContext context)
		{
		}

		public void OnOpenInvasionRoute(InputAction.CallbackContext context)
		{
		}

		public void OnOpenHeroTree(InputAction.CallbackContext context)
		{
		}

		public void OnChangeCamera(InputAction.CallbackContext context)
		{
		}

		public void OnOpenMapExtendViewer(InputAction.CallbackContext context)
		{
		}

		public void OnPaletteNext(InputAction.CallbackContext context)
		{
		}

		public void OnPalettePrev(InputAction.CallbackContext context)
		{
		}

		public void OnPaletteNext2(InputAction.CallbackContext context)
		{
		}

		public void OnPalettePrev2(InputAction.CallbackContext context)
		{
		}

		public void OnOpenInventory(InputAction.CallbackContext context)
		{
		}

		public void OnOpenSetting(InputAction.CallbackContext context)
		{
		}
	}
}
