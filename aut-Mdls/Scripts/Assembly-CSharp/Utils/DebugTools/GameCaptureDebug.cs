using Data.GameState;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Utils.DebugTools
{
	public class GameCaptureDebug : MonoBehaviour
	{
		[SerializeField]
		private InputActionAsset _inputActionAsset;

		[SerializeField]
		private InputActionReference _toggleCursorAction;

		[SerializeField]
		private InputActionReference _toggleAudioAction;

		[SerializeField]
		private InputActionReference _toggleSpeedUpAction;

		[SerializeField]
		private InputActionReference _toggleSpeedDownAction;

		[SerializeField]
		private PauseStateData _pauseStateData;

		[SerializeField]
		private GameObject[] _gizmosToToggleWithUI;

		private InputActionMap _debugActionMap;

		private Canvas[] _allCanvasses;

		private bool[] _activeCanvasses;

		private bool _allUIActive = true;

		private void OnEnable()
		{
			_debugActionMap = _inputActionAsset.FindActionMap("Debug");
			_toggleCursorAction.action.performed += ToggleCursorAction;
			_toggleSpeedUpAction.action.performed += SpeedUpAction;
			_toggleSpeedDownAction.action.performed += SpeedDownAction;
			_debugActionMap.Enable();
		}

		private void OnDisable()
		{
			_toggleCursorAction.action.performed -= ToggleCursorAction;
			_toggleSpeedUpAction.action.performed -= SpeedUpAction;
			_toggleSpeedDownAction.action.performed -= SpeedDownAction;
			_debugActionMap.Disable();
		}

		private void ToggleCursorAction(InputAction.CallbackContext obj)
		{
			Cursor.visible = !Cursor.visible;
		}

		private void SpeedUpAction(InputAction.CallbackContext obj)
		{
			if (Time.timeScale < 3f)
			{
				Time.timeScale += 0.2f;
			}
		}

		private void SpeedDownAction(InputAction.CallbackContext obj)
		{
			if (Time.timeScale - 0.2f > 0f)
			{
				Time.timeScale -= 0.2f;
			}
		}
	}
}
