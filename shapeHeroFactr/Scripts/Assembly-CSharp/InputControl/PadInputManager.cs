using System.Collections.Generic;
using Libs;
using UnityEngine;

namespace InputControl
{
	public class PadInputManager : SingletonMonoBehaviour<PadInputManager>
	{
		public enum InputType
		{
			Keyboard = 0,
			GamePad = 1,
			SwitchMouse = 2
		}

		private InputFocusData _baseCurrentFocus;

		private readonly List<InputFocusData> _overrideInputs;

		public CursorUIGroup currentCursorUIGroup;

		private GamepadCursor _gamepadCursor;

		public readonly ReactiveProperty<InputType> CurrentInputType;

		public readonly ReactiveProperty<bool> CurrentSwitchMouseMode;

		public float _coolTime;

		public static Vector2 VirtualMousePosition;

		private CustomDevice customDevice;

		public IReadOnlyList<InputFocusData> OverrideInputs => null;

		private InputFocusData CurrentInput => null;

		public CursorUIGroup CurrentCursorUIGroup => null;

		public bool IsGamePad => false;

		public bool IsSwitchMouse => false;

		private void Awake()
		{
		}

		private void UpdateCurrentInputCallbacks(InputActionController.IUIControlActions oldInput, InputActionController.IUIControlActions newInput)
		{
		}

		public void RemoveOverrideInput(MonoBehaviour parentComponent)
		{
		}

		public void SetOverrideInput(InputActionController.IUIControlActions input, MonoBehaviour parentComponent)
		{
		}

		public void SetInput(InputActionController.IUIControlActions input, MonoBehaviour parentComponent)
		{
		}

		public void RemoveInput(InputActionController.IUIControlActions input)
		{
		}

		public void UpdateInGameInputEnable()
		{
		}

		public void SetMousePosition()
		{
		}

		private void Update()
		{
		}

		public void SetGamepadCursor(bool enable)
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
