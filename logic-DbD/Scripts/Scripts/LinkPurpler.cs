using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LinkPurpler : CursorChangerExit
{
	private static Dictionary<string, bool> isPressed = new Dictionary<string, bool>();

	private void Start()
	{
		Button button = GetComponent<Button>();
		button.onClick.AddListener(delegate
		{
			Selected(button);
		});
		if (isPressed.ContainsKey(button.name))
		{
			UIUtils.SetButtonColorSelected(button);
		}
	}

	public static void Selected(Button button)
	{
		isPressed[button.name] = true;
		UIUtils.SetButtonColorSelected(button);
	}
}
