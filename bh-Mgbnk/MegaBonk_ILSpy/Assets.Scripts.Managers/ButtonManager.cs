using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Managers;

public class ButtonManager
{
	private static MyButton selectedButton2;

	public static Action<MyButton> A_ButtonHover;

	public static bool enabled = true;

	public static void Refresh()
	{
		ForceHoverButton(selectedButton2);
	}

	public static void SetFirstButton(MyButton button)
	{
		EventSystem current = EventSystem.current;
		if (current != null)
		{
			GameObject gameObject2;
			if ((object)button != null)
			{
				GameObject gameObject = button.gameObject;
				gameObject2 = gameObject;
			}
			else
			{
				gameObject2 = null;
			}
			if (gameObject2 != null)
			{
				ForceHoverButton(button);
			}
		}
	}

	public static void ForceHoverButton(MyButton btn)
	{
		if (enabled && btn != null)
		{
			EventSystem current = EventSystem.current;
			GameObject gameObject = btn.gameObject;
			current.SetSelectedGameObject(gameObject);
			if (selectedButton2 != null)
			{
				selectedButton2.StopHover();
			}
			selectedButton2 = btn;
			btn.StartHover();
			Action<MyButton> a_ButtonHover = A_ButtonHover;
			if (A_ButtonHover != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v352 @ rax_v28 (System.Action`1<MyButton>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public static void StartedHoveringButton(MyButton button)
	{
		if (selectedButton2 != null)
		{
			selectedButton2.StopHover();
		}
		selectedButton2 = button;
		button.StartHover();
		Action<MyButton> a_ButtonHover = A_ButtonHover;
		if (A_ButtonHover != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v177 @ rax_v15 (System.Action`1<MyButton>)+18] (should have been resolved before IL gen)");
		}
	}

	public static void SetNull()
	{
		selectedButton2 = null;
		EventSystem.current?.SetSelectedGameObject(null);
	}

	public static MyButton GetCurrentButton()
	{
		return selectedButton2;
	}
}
