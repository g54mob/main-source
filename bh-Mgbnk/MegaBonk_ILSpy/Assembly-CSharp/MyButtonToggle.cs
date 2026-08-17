using System;
using Cpp2ILInjected;
using UnityEngine;

public class MyButtonToggle : MyButton
{
	public Action<bool> A_Toggled;

	public GameObject toggleIcon;

	public void Set(bool on)
	{
		toggleIcon.SetActive(on);
	}

	public bool IsOn()
	{
		//IL_0041: Expected I4, but got O
		if ((object)toggleIcon != null)
		{
			return toggleIcon.activeInHierarchy;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override void StartHover()
	{
	}

	public override void StopHover()
	{
	}

	protected override void OnClick()
	{
		bool activeInHierarchy = toggleIcon.activeInHierarchy;
		bool active = (byte)((activeInHierarchy ? 1u : 0u) ^ 1u) != 0;
		toggleIcon.SetActive(active);
		Action<bool> a_Toggled = A_Toggled;
		if (A_Toggled != null)
		{
			bool activeInHierarchy2 = toggleIcon.activeInHierarchy;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v27 @ rbx_v3 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}
}
