using Data.GameState;
using Data.Variables;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Presentation.UI.Menus
{
	public class PauseActionWidget : MonoBehaviour
	{
		[SerializeField]
		private InputActionReference _togglePauseAction;

		[SerializeField]
		private PauseStateData _pauseState;

		[SerializeField]
		private BoolVariableSO _HUDUIIsHidden;

		[SerializeField]
		private BoolVariableSO _TopHUDUIIsHidden;

		private void Awake()
		{
			_togglePauseAction.action.performed += TogglePauseAction;
		}

		private void OnDestroy()
		{
			_togglePauseAction.action.performed -= TogglePauseAction;
		}

		private void TogglePauseAction(InputAction.CallbackContext obj)
		{
			if ((bool)_HUDUIIsHidden || (bool)_TopHUDUIIsHidden)
			{
				_pauseState.TogglePausedBuildMode();
			}
		}
	}
}
