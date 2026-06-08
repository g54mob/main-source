using UnityEngine;

public class InputState : MonoBehaviour
{
	public delegate void AltMouseDownStateChange(int ButtonType, bool state);

	public static bool rightMBDown;

	public static bool middleMBDown;

	public static bool leftMBDown;

	public static bool shiftDown;

	public static bool ctrlDown;

	public static bool altDown;

	public static bool altLMBDown;

	public static bool altRMBDown;

	public static bool altMMBDown;

	public static bool ctrlAltLMBDown;

	public static bool upArrowDown;

	public static bool downArrowDown;

	public static bool leftArrowDown;

	public static bool rightArrowDown;

	public static bool cKeyDown;

	public static bool ModifierKeyDown
	{
		get
		{
			return altDown || ctrlDown || shiftDown;
		}
	}

	public static event AltMouseDownStateChange AltMouseDownStateChangeEvent;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			shiftDown = true;
		}
		else if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			shiftDown = false;
		}
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			ctrlDown = true;
		}
		else if (Input.GetKeyUp(KeyCode.LeftControl))
		{
			ctrlDown = false;
			ctrlAltLMBDown = false;
		}
		if (Input.GetKeyDown(KeyCode.LeftAlt))
		{
			altDown = true;
		}
		else if (Input.GetKeyUp(KeyCode.LeftAlt))
		{
			altDown = false;
			altLMBDown = false;
			altRMBDown = false;
			altMMBDown = false;
			GlobalSettings.selectionEnabled = true;
		}
		if (Input.GetMouseButtonDown(0))
		{
			leftMBDown = true;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			leftMBDown = false;
			altLMBDown = false;
			altMMBDown = false;
			ctrlAltLMBDown = false;
			if (InputState.AltMouseDownStateChangeEvent != null)
			{
				InputState.AltMouseDownStateChangeEvent(0, false);
			}
		}
		if (Input.GetMouseButtonDown(1))
		{
			rightMBDown = true;
		}
		else if (Input.GetMouseButtonUp(1))
		{
			rightMBDown = false;
			altRMBDown = false;
			altMMBDown = false;
			if (InputState.AltMouseDownStateChangeEvent != null)
			{
				InputState.AltMouseDownStateChangeEvent(1, false);
			}
		}
		if (Input.GetMouseButtonDown(2))
		{
			middleMBDown = true;
		}
		else if (Input.GetMouseButtonUp(2))
		{
			middleMBDown = false;
			altMMBDown = false;
			if (InputState.AltMouseDownStateChangeEvent != null)
			{
				InputState.AltMouseDownStateChangeEvent(2, false);
			}
		}
		if (!altMMBDown && altDown && middleMBDown)
		{
			altMMBDown = true;
			if (InputState.AltMouseDownStateChangeEvent != null)
			{
				InputState.AltMouseDownStateChangeEvent(2, true);
			}
		}
		if (!altLMBDown && altDown && leftMBDown)
		{
			altLMBDown = true;
			if (InputState.AltMouseDownStateChangeEvent != null)
			{
				InputState.AltMouseDownStateChangeEvent(0, true);
			}
		}
		if (!altRMBDown && altDown && rightMBDown)
		{
			altRMBDown = true;
			if (InputState.AltMouseDownStateChangeEvent != null)
			{
				InputState.AltMouseDownStateChangeEvent(1, true);
			}
		}
		if (Input.GetButtonDown("Up"))
		{
			upArrowDown = true;
		}
		else if (Input.GetButtonUp("Up"))
		{
			upArrowDown = false;
		}
		if (Input.GetButtonDown("Down"))
		{
			downArrowDown = true;
		}
		else if (Input.GetButtonUp("Down"))
		{
			downArrowDown = false;
		}
		if (Input.GetButtonDown("Right"))
		{
			rightArrowDown = true;
		}
		else if (Input.GetButtonUp("Right"))
		{
			rightArrowDown = false;
		}
		if (Input.GetButtonDown("Left"))
		{
			leftArrowDown = true;
		}
		else if (Input.GetButtonUp("Left"))
		{
			leftArrowDown = false;
		}
	}
}
