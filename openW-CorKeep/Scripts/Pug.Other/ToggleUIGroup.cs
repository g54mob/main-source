using System.Collections.Generic;
using UnityEngine;

public class ToggleUIGroup : MonoBehaviour
{
	public List<ToggleUIElement> toggleUIElements;

	public void OnToggle(ToggleUIElement toggleUIElementActivated)
	{
		foreach (ToggleUIElement toggleUIElement in toggleUIElements)
		{
			toggleUIElement.isOn = toggleUIElementActivated == toggleUIElement;
		}
	}
}
