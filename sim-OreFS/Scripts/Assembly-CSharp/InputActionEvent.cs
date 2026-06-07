using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputActionEvent : MonoBehaviour
{
	public InputActionReference inputAction;

	public UnityEvent inputEvent;

	public UnityEvent inputDropEvent;

	public bool inputActive;

	public bool disableInputOnDisable = true;

	public bool inputDrop;

	public bool delayedInput;

	private bool delayedInputLock;

	public bool delayedActivation;

	private void OnEnable()
	{
		if (!delayedActivation)
		{
			activation();
		}
		else
		{
			StartCoroutine(delayedActivationLoop());
		}
	}

	private void activation()
	{
		inputActive = true;
		inputAction.action.performed += OnInputPerformed;
		if (inputDrop)
		{
			inputAction.action.canceled += OnInputDropped;
		}
		inputAction.action.Enable();
	}

	private IEnumerator delayedActivationLoop()
	{
		yield return new WaitForSeconds(0.1f);
		activation();
	}

	private void OnDisable()
	{
		inputActive = false;
		inputAction.action.performed -= OnInputPerformed;
		inputAction.action.canceled -= OnInputDropped;
		if (disableInputOnDisable)
		{
			inputAction.action.Disable();
		}
	}

	private void OnInputPerformed(InputAction.CallbackContext context)
	{
		if (inputActive && !InputDetection.Instance.isBackBusy && !delayedInputLock)
		{
			if (!delayedInput)
			{
				inputEvent.Invoke();
				return;
			}
			inputEvent.Invoke();
			StartCoroutine(delayedInputLoop());
		}
	}

	private IEnumerator delayedInputLoop()
	{
		delayedInputLock = true;
		yield return new WaitForSeconds(0.25f);
		delayedInputLock = false;
	}

	private void OnInputDropped(InputAction.CallbackContext context)
	{
		if (inputActive && inputDrop)
		{
			inputDropEvent.Invoke();
		}
	}
}
