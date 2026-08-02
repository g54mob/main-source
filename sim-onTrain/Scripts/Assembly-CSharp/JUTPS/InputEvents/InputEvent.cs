using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

namespace JUTPS.InputEvents
{
	[Serializable]
	public class InputEvent
	{
		[SerializeField]
		private string EventName = "Input Event";

		[InputControl(layout = "Button")]
		[SerializeField]
		private string Input;

		[HideInInspector]
		public InputAction targetInput;

		public UnityEvent OnInputEnter;

		public UnityEvent OnInputPerformed;

		public UnityEvent OnInputUp;

		private InputAction GenerateTargetInput()
		{
			targetInput = new InputAction("Actionn", InputActionType.Button, Input, null, null, "Button");
			targetInput.Enable();
			return targetInput;
		}

		public void SetupListeners()
		{
			GenerateTargetInput();
			targetInput.started += OnEnter;
			targetInput.performed += OnPressing;
			targetInput.canceled += OnExit;
		}

		public void RemoveListeners()
		{
			targetInput.started -= OnEnter;
			targetInput.performed -= OnPressing;
			targetInput.canceled -= OnExit;
		}

		private void OnEnter(InputAction.CallbackContext ctx)
		{
			OnInputEnter.Invoke();
		}

		private void OnPressing(InputAction.CallbackContext ctx)
		{
			OnInputPerformed.Invoke();
		}

		private void OnExit(InputAction.CallbackContext ctx)
		{
			OnInputUp.Invoke();
		}
	}
}
