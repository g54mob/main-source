using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public class GamepadUIInputModule : BaseInputModule
	{
		[SerializeField]
		private float moveRepeatDelay;

		[SerializeField]
		private float moveRepeatRate;

		[SerializeField]
		private InputActionAsset actionsAsset;

		[SerializeField]
		private InputActionReference moveAction;

		[SerializeField]
		private InputActionReference rightStickAction;

		[SerializeField]
		private InputActionReference leftStickAction;

		[SerializeField]
		private InputActionReference dpadAction;

		[SerializeField]
		private InputActionReference confirmAction;

		[SerializeField]
		private InputActionReference backAction;

		[SerializeField]
		private InputActionReference menuAction;

		[SerializeField]
		private InputActionReference optionAction;

		[SerializeField]
		private InputActionReference triggerLeftAction;

		[SerializeField]
		private InputActionReference triggerRightAction;

		[SerializeField]
		private InputActionReference bumperLeftAction;

		[SerializeField]
		private InputActionReference bumperRightAction;

		[SerializeField]
		private InputActionReference westButtonAction;

		[SerializeField]
		private InputActionReference northButtonAction;

		[SerializeField]
		private InputActionReference leftStickButtonAction;

		[SerializeField]
		private InputActionReference rightStickButtonAction;

		private NavigationModel _navigationState;

		private ButtonEventData _buttonData;

		private ButtonAxisEventData _buttonAxisData;

		protected override void OnEnable()
		{
		}

		public override void ActivateModule()
		{
		}

		protected override void OnDisable()
		{
		}

		private void EnableActions()
		{
		}

		private void DisableActions()
		{
		}

		private void HookActions()
		{
		}

		private void UnhookActions()
		{
		}

		private static void HookAction(InputAction action, Action<InputAction.CallbackContext> callback)
		{
		}

		private static void UnhookAction(InputAction action, Action<InputAction.CallbackContext> callback)
		{
		}

		private BaseEventData GetButtonEventData(InputAction.CallbackContext ctx)
		{
			return null;
		}

		private ButtonAxisEventData GetButtonAxisEventData(InputAction.CallbackContext ctx)
		{
			return null;
		}

		private void ExecuteButtonEvent<T>(ExecuteEvents.EventFunction<T> handler, BaseEventData eventData) where T : IEventSystemHandler
		{
		}

		private void OnConfirmCallback(InputAction.CallbackContext ctx)
		{
		}

		private void OnBackCallback(InputAction.CallbackContext ctx)
		{
		}

		private void OnMenuCallback(InputAction.CallbackContext ctx)
		{
		}

		private void OnOptionCallback(InputAction.CallbackContext ctx)
		{
		}

		private void OnTriggerLeftCallback(InputAction.CallbackContext ctx)
		{
		}

		private void OnTriggerRightCallback(InputAction.CallbackContext ctx)
		{
		}

		private void OnBumperLeftCallback(InputAction.CallbackContext ctx)
		{
		}

		private void OnBumperRightCallback(InputAction.CallbackContext ctx)
		{
		}

		private void OnWestButtonCallback(InputAction.CallbackContext ctx)
		{
		}

		private void OnNorthButtonCallback(InputAction.CallbackContext ctx)
		{
		}

		private void OnRightStickButtonCallback(InputAction.CallbackContext ctx)
		{
		}

		private void OnLeftStickButtonCallback(InputAction.CallbackContext ctx)
		{
		}

		private void OnMoveCallback(InputAction.CallbackContext ctx)
		{
		}

		private void OnDPadCallback(InputAction.CallbackContext ctx)
		{
		}

		private void OnRightStickCallback(InputAction.CallbackContext ctx)
		{
		}

		private void OnLeftStickCallback(InputAction.CallbackContext ctx)
		{
		}

		public override void Process()
		{
		}

		public static MoveDirection GetMoveDirection(Vector2 vector)
		{
			return default(MoveDirection);
		}

		private void ProcessNavigation(ref NavigationModel navigationState)
		{
		}
	}
}
