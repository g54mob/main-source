using System;
using UnityEngine;

namespace Doozy.Engine.UI.Input
{
	[Serializable]
	public class InputData
	{
		public const bool DEFAULT_ENABLE_ALTERNATE_INPUTS = true;

		public const InputMode DEFAULT_INPUT_MODE = InputMode.VirtualButton;

		public const KeyCode DEFAULT_ON_CLICK_KEY_CODE = KeyCode.Return;

		public const KeyCode DEFAULT_ON_CLICK_KEY_CODE_ALT = KeyCode.Space;

		public const string DEFAULT_ON_CLICK_VIRTUAL_BUTTON_NAME = "Submit";

		public const string DEFAULT_ON_CLICK_VIRTUAL_BUTTON_NAME_ALT = "Jump";

		public bool EnableAlternateInputs;

		public InputMode InputMode;

		public KeyCode KeyCode;

		public KeyCode KeyCodeAlt;

		public string VirtualButtonName;

		public string VirtualButtonNameAlt;

		public void Reset()
		{
		}
	}
}
