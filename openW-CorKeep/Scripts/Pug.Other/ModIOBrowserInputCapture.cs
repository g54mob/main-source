using ModIOBrowser;
using UnityEngine;

public class ModIOBrowserInputCapture : MonoBehaviour
{
	private bool _wasOpen;

	private void Update()
	{
		if (Browser.IsOpen)
		{
			if (Manager.input.SystemPrefersKeyboardAndMouse())
			{
				InputReceiver.OnSetToMouseNavigation();
			}
			else
			{
				InputReceiver.OnSetToControllerNavigation();
			}
			HandleInputReceiver();
			HandleControllerInput();
		}
	}

	private void HandleInputReceiver()
	{
		InputManager input = Manager.input;
		if (input.GetButtonDown(220))
		{
			InputReceiver.OnOptions();
		}
		else if (input.GetButtonDown(221))
		{
			InputReceiver.OnAlternate();
		}
		else if (!input.SystemPrefersKeyboardAndMouse() && input.GetButtonDown(6))
		{
			InputReceiver.OnCancel();
		}
		else if (input.GetButtonDown(14))
		{
			if (input.SystemPrefersKeyboardAndMouse())
			{
				InputReceiver.OnCancel();
				InputReceiver.OnSetToMouseNavigation(force: true);
			}
			else
			{
				InputReceiver.OnMenu();
			}
		}
		else if (input.GetButtonDown(73))
		{
			InputReceiver.OnTabLeft();
		}
		else if (input.GetButtonDown(74))
		{
			InputReceiver.OnTabRight();
		}
		else if (input.GetButtonDown(219))
		{
			InputReceiver.OnSearch();
		}
	}

	private void HandleControllerInput()
	{
		InputManager input = Manager.input;
		if (!input.SystemPrefersKeyboardAndMouse())
		{
			float axis = input.GetAxis(77);
			if (axis != 0f)
			{
				InputReceiver.OnControllerScroll(axis);
			}
		}
	}
}
