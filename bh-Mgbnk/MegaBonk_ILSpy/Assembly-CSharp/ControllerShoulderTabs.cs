using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

public class ControllerShoulderTabs : MonoBehaviour
{
	public ButtonNavigationSelectionOnly tabs;

	public Window parentWindow;

	private void Start()
	{
		if (parentWindow == null)
		{
			Window componentInParent = GetComponentInParent<Window>();
			parentWindow = componentInParent;
		}
	}

	private void Update()
	{
		//IL_00b8: Expected I4, but got I8
		if (!(parentWindow != null) || !(WindowManager.activeWindow == parentWindow) || (KeyListener.Instance != null && KeyListener.Instance.IsListening()))
		{
			return;
		}
		int dir;
		if (MyInputManager.GetButtonDown(MyInputManager.UIShoulderLeft))
		{
			dir = -1;
		}
		else
		{
			if (!MyInputManager.GetButtonDown(MyInputManager.UIShoulderRight))
			{
				return;
			}
			dir = 1;
		}
		ShoulderNav(dir);
	}

	private void ShoulderNav(int dir)
	{
		//IL_005f: Expected O, but got I4
		ButtonNavigationSelectionOnly buttonNavigationSelectionOnly = tabs;
		if (buttonNavigationSelectionOnly.current > 0 || dir >= 0)
		{
			int numButtons = buttonNavigationSelectionOnly.GetNumButtons();
			object obj = numButtons - 1;
			if (buttonNavigationSelectionOnly.current < (nint)obj || dir <= 0)
			{
				ButtonNavigationSelectionOnly buttonNavigationSelectionOnly2 = tabs;
				int index = buttonNavigationSelectionOnly2.current + dir;
				buttonNavigationSelectionOnly2.ButtonPressed(index);
				Button selectedButton = tabs.GetSelectedButton();
				MyButton component = selectedButton.GetComponent<MyButton>();
				ButtonManager.ForceHoverButton(component);
			}
		}
	}
}
