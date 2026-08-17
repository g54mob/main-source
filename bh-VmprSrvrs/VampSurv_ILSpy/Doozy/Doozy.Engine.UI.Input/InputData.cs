using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.UI.Input;

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

	public InputData()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980863]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		InputMode = InputMode.VirtualButton;
		EnableAlternateInputs = false;
		KeyCode = KeyCode.Return;
		KeyCodeAlt = KeyCode.Space;
		VirtualButtonName = "Submit";
		VirtualButtonNameAlt = "Jump";
	}

	public void Reset()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980863]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		InputMode = InputMode.VirtualButton;
		EnableAlternateInputs = false;
		KeyCode = KeyCode.Return;
		KeyCodeAlt = KeyCode.Space;
		VirtualButtonName = "Submit";
		VirtualButtonNameAlt = "Jump";
	}
}
