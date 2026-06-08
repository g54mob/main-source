using UnityEngine;
using UnityEngine.InputSystem;

public class UIRebindActionBehaviour : MonoBehaviour
{
	private InputActionAsset focusedInputActionAsset;

	private PlayerInput focusedPlayerInput;

	private InputAction focusedInputAction;

	private InputActionRebindingExtensions.RebindingOperation rebindOperation;

	[SerializeField]
	private InputActionReference targetAction;

	public string actionName;

	public GameObject rebindButtonObject;

	public GameObject resetButtonObject;

	public GameObject listeningForInputObject;

	public void UpdateBehaviour()
	{
		GetFocusedPlayerInput();
		SetupFocusedInputAction();
		UpdateBindingDisplayUI();
	}

	private void GetFocusedPlayerInput()
	{
	}

	private void SetupFocusedInputAction()
	{
		focusedInputAction = focusedPlayerInput.actions.FindAction(actionName);
	}

	public void ButtonPressedStartRebind()
	{
		StartRebindProcess();
	}

	private void StartRebindProcess()
	{
		ToggleGameObjectState(rebindButtonObject, newState: false);
		ToggleGameObjectState(resetButtonObject, newState: false);
		ToggleGameObjectState(listeningForInputObject, newState: true);
		rebindOperation = InputActionRebindingExtensions.PerformInteractiveRebinding(focusedInputAction).WithControlsExcluding("<Mouse>/position").WithControlsExcluding("<Mouse>/delta")
			.WithControlsExcluding("<Gamepad>/Start")
			.WithControlsExcluding("<Keyboard>/p")
			.WithControlsExcluding("<Keyboard>/escape")
			.OnMatchWaitForAnother(0.1f)
			.OnComplete(delegate
			{
				RebindCompleted();
			});
		rebindOperation.Start();
	}

	private void RebindCompleted()
	{
		rebindOperation.Dispose();
		rebindOperation = null;
		ToggleGameObjectState(rebindButtonObject, newState: true);
		ToggleGameObjectState(resetButtonObject, newState: true);
		ToggleGameObjectState(listeningForInputObject, newState: false);
		UpdateBindingDisplayUI();
	}

	public void ButtonPressedResetBinding()
	{
		ResetBinding();
	}

	public void ResetBinding()
	{
		InputActionRebindingExtensions.RemoveAllBindingOverrides(focusedInputAction);
		UpdateBindingDisplayUI();
	}

	private void UpdateBindingDisplayUI()
	{
		int bindingIndexForControl = InputActionRebindingExtensions.GetBindingIndexForControl(focusedInputAction, focusedInputAction.controls[0]);
		InputControlPath.ToHumanReadableString(focusedInputAction.bindings[bindingIndexForControl].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
	}

	private void ToggleGameObjectState(GameObject targetGameObject, bool newState)
	{
		targetGameObject.SetActive(newState);
	}

	private void _003CStartRebindProcess_003Eb__13_0(InputActionRebindingExtensions.RebindingOperation operation)
	{
		RebindCompleted();
	}
}
