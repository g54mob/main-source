using UnityEngine;
using UnityEngine.InputSystem;

public class RebindingTest : MonoBehaviour
{
	private TouchController touchController;

	private Coroutine zoomCoroutine;

	private void Awake()
	{
		touchController = GetComponentInParent<TouchController>();
	}

	private void Start()
	{
		touchController.Controls.Generic.ToggleMenu.started += DebugInput;
	}

	private void DebugInput(InputAction.CallbackContext obj)
	{
		Debug.Log(InputActionRebindingExtensions.GetBindingDisplayString(touchController.Controls.Generic.ToggleMenu));
	}

	private void RebindKey(string newKeyString, int index)
	{
		InputActionRebindingExtensions.ApplyBindingOverride(touchController.Controls.Generic.ToggleMenu, index, newKeyString);
	}
}
