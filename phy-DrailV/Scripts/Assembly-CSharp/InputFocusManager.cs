using DV.Interaction;
using DV.Utils;
using UnityEngine;

public class InputFocusManager : SingletonBehaviour<InputFocusManager>
{
	private Grabber grabber;

	public bool hasKeyboardFocus { get; private set; }

	public void TakeKeyboardFocus()
	{
		if (!hasKeyboardFocus)
		{
			hasKeyboardFocus = true;
		}
		else
		{
			Debug.LogError("Cannot take keyboard focus, already taken");
		}
	}

	public void ReleaseKeyboardFocus()
	{
		if (hasKeyboardFocus)
		{
			hasKeyboardFocus = false;
		}
		else
		{
			Debug.LogError("Cannot release keyboard focus, focus not taken");
		}
	}
}
