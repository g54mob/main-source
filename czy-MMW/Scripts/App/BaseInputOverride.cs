using UnityEngine;
using UnityEngine.EventSystems;

public class BaseInputOverride : BaseInput
{
	public IInputState InputState { get; set; }

	public override string compositionString => Input.compositionString;

	public override IMECompositionMode imeCompositionMode
	{
		get
		{
			return Input.imeCompositionMode;
		}
		set
		{
			Input.imeCompositionMode = value;
		}
	}

	public override Vector2 compositionCursorPos
	{
		get
		{
			return Input.compositionCursorPos;
		}
		set
		{
			Input.compositionCursorPos = value;
		}
	}

	public override bool mousePresent => InputState.MousePresent;

	public override Vector2 mousePosition
	{
		get
		{
			if (Diagnostics.Verify(InputState != null, "InputState is null!") && InputState.MousePresent)
			{
				return InputState.Mouse.Position;
			}
			return Vector2.zero;
		}
	}

	public override Vector2 mouseScrollDelta => Input.mouseScrollDelta;

	public override bool touchSupported => Input.touchSupported;

	public override int touchCount => InputState.TouchCount;

	public override bool GetMouseButtonDown(int buttonIndex)
	{
		int rewiredActionForMouseButtonIndex = GetRewiredActionForMouseButtonIndex(buttonIndex);
		if (rewiredActionForMouseButtonIndex < 0)
		{
			return false;
		}
		return InputState.Mouse.GetButtonState(rewiredActionForMouseButtonIndex).CurrentState == InputEventButtonState.JustDown;
	}

	public override bool GetMouseButtonUp(int buttonIndex)
	{
		int rewiredActionForMouseButtonIndex = GetRewiredActionForMouseButtonIndex(buttonIndex);
		if (rewiredActionForMouseButtonIndex < 0)
		{
			return false;
		}
		return InputState.Mouse.GetButtonState(rewiredActionForMouseButtonIndex).CurrentState == InputEventButtonState.JustUp;
	}

	public override bool GetMouseButton(int buttonIndex)
	{
		int rewiredActionForMouseButtonIndex = GetRewiredActionForMouseButtonIndex(buttonIndex);
		if (rewiredActionForMouseButtonIndex < 0)
		{
			return false;
		}
		return InputState.Mouse.GetButtonState(rewiredActionForMouseButtonIndex).IsDown;
	}

	public static int GetRewiredActionForMouseButtonIndex(int buttonIndex)
	{
		return buttonIndex switch
		{
			0 => 19, 
			1 => 20, 
			2 => 30, 
			_ => -1, 
		};
	}

	public override Touch GetTouch(int index)
	{
		if (InputState.TryGetTouch(index, out var result))
		{
			return result.ToUnityTouch();
		}
		return new Touch
		{
			phase = TouchPhase.Canceled
		};
	}

	public override float GetAxisRaw(string axisName)
	{
		if (string.IsNullOrEmpty(axisName))
		{
			return 0f;
		}
		int rewiredInputActionForAxisName = GetRewiredInputActionForAxisName(axisName);
		if (rewiredInputActionForAxisName >= 0)
		{
			return InputState.GetAxis(rewiredInputActionForAxisName);
		}
		return 0f;
	}

	private int GetRewiredInputActionForAxisName(string axisName)
	{
		if (!(axisName == "MoveHorizontal"))
		{
			if (axisName == "MoveVertical")
			{
				return 1;
			}
			Diagnostics.FailAssert("Failed to find an axis for '" + axisName + "'");
			return -1;
		}
		return 0;
	}

	public override bool GetButtonDown(string buttonName)
	{
		return false;
	}
}
