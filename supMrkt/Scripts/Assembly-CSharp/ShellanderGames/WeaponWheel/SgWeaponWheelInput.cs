using UnityEngine;
using UnityEngine.InputSystem;

namespace ShellanderGames.WeaponWheel
{
	public class SgWeaponWheelInput : SgGenericInput
	{
		[Tooltip("Unique input action map for this weapon wheel")]
		public InputActionMap actionMap;

		[Tooltip("Use your own existing player input")]
		public bool useExistingPlayerInput;

		[Tooltip("Your own existing player input")]
		public PlayerInput playerInput;

		[Tooltip("Action map name in your player input settings")]
		public string playerInputActionMapName;

		[HideInInspector]
		public InputActionMap currentActionMap;

		private static readonly string m_GamepadConfirmActionName;

		private static readonly string m_MousePointerActionName;

		private static readonly string m_GamepadStickActionName;

		private static readonly string m_ShowWeaponWheelActionName;

		private InputAction m_GamepadConfirmAction;

		private InputAction m_ToggleWheelAction;

		private InputAction m_PointerAction;

		private InputAction m_StickAction;

		protected override bool IsToggleWheelButtonPressed => false;

		protected override bool WasToggleWheelButtonPressedNow => false;

		protected override bool WasGamepadConfirmButtonPressedNow => false;

		protected override bool WasGamepadConfirmButtonReleasedNow => false;

		protected override bool IsPointerActionEnabled => false;

		protected override Vector2 CurrentPointerValue => default(Vector2);

		protected override Vector2 CurrentStickValue => default(Vector2);

		public override void ResetComponent()
		{
		}

		private InputAction FindAction(string name)
		{
			return null;
		}

		protected override bool WasDigitPressedNow(int digit)
		{
			return false;
		}
	}
}
