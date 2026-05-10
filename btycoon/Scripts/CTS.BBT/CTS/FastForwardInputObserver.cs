using PixelCrushers.DialogueSystem.Wrappers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	public class FastForwardInputObserver : MonoBehaviour
	{
		[SerializeField]
		private StandardUIContinueButtonFastForward _fastForward;

		private void OnDisable()
		{
			InputManager.game.fastForwardDialogue.onDown -= OnKeyDown;
		}

		private void OnEnable()
		{
			InputManager.game.fastForwardDialogue.onDown += OnKeyDown;
		}

		private void OnKeyDown(InputAction.CallbackContext ctx)
		{
			_fastForward.OnFastForward();
		}
	}
}
