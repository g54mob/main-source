using System.Collections.Generic;
using System.Linq;
using ModIOBrowser;
using UnityEngine;

public class ExampleInputCapture : MonoBehaviour
{
	[SerializeField]
	private KeyCode Cancel = KeyCode.JoystickButton1;

	[SerializeField]
	private KeyCode Alternate = KeyCode.JoystickButton2;

	[SerializeField]
	private KeyCode Options = KeyCode.JoystickButton3;

	[SerializeField]
	private KeyCode TabLeft = KeyCode.JoystickButton4;

	[SerializeField]
	private KeyCode TabRight = KeyCode.JoystickButton5;

	[SerializeField]
	private KeyCode Search = KeyCode.JoystickButton9;

	[SerializeField]
	private KeyCode Menu = KeyCode.JoystickButton7;

	public List<string> controllerAndKeyboardInput = new List<string> { "Horizontal", "Vertical" };

	public List<string> mouseInput = new List<string> { "Mouse X", "Mouse Y" };

	public string verticalControllerInput = "Vertical";

	private void Update()
	{
		if (Browser.IsOpen)
		{
			HandleInputReceiver();
			HandleControllerInput();
		}
	}

	private void HandleInputReceiver()
	{
		if (Input.GetKeyDown(Cancel))
		{
			InputReceiver.OnCancel();
		}
		else if (Input.GetKeyDown(Alternate))
		{
			InputReceiver.OnAlternate();
		}
		else if (Input.GetKeyDown(Options))
		{
			InputReceiver.OnOptions();
		}
		else if (Input.GetKeyDown(TabLeft))
		{
			InputReceiver.OnTabLeft();
		}
		else if (Input.GetKeyDown(TabRight))
		{
			InputReceiver.OnTabRight();
		}
		else if (Input.GetKeyDown(Search))
		{
			InputReceiver.OnSearch();
		}
		else if (Input.GetKeyDown(Menu))
		{
			InputReceiver.OnMenu();
		}
	}

	private void HandleControllerInput()
	{
		if (Input.GetAxis(verticalControllerInput) != 0f)
		{
			InputReceiver.OnControllerScroll(Input.GetAxis(verticalControllerInput));
		}
		if (controllerAndKeyboardInput.Any((string x) => Input.GetAxis(x) != 0f))
		{
			if (!(InputReceiver.currentSelectedInputField != null))
			{
				InputReceiver.OnSetToControllerNavigation();
			}
		}
		else if (mouseInput.Any((string x) => Input.GetAxis(x) != 0f))
		{
			InputReceiver.OnSetToMouseNavigation();
		}
	}
}
