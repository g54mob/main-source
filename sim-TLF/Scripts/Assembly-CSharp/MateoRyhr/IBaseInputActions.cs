using UnityEngine.InputSystem;

namespace MateoRyhr
{
	public interface IBaseInputActions
	{
		void OnInputStarted(InputAction.CallbackContext data);

		void OnInputPerformed(InputAction.CallbackContext data);

		void OnInputCanceled(InputAction.CallbackContext data);
	}
}
