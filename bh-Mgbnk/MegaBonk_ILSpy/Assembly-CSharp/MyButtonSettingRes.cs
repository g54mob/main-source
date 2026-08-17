using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class MyButtonSettingRes : MyButton
{
	public MaskableGraphic background;

	public Color defaultColor;

	public Color hoverColor;

	public static Action A_Clicked;

	public unsafe override void StartHover()
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		background.color = (Color)(&obj);
		isHovering = true;
	}

	public unsafe override void StopHover()
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		background.color = (Color)(&obj);
		isHovering = false;
	}

	protected override void OnClick()
	{
		Action a_Clicked = A_Clicked;
		if (A_Clicked != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v26.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public MyButtonSettingRes()
	{
		hoverScale = 1.05f;
		((MonoBehaviour)this)._002Ector();
	}
}
