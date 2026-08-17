using System;
using Cpp2ILInjected;
using UnityEngine;

public class MyButtonUnlock : MyButtonNormal
{
	public UnlockContainer unlockContainer;

	public static Action<UnlockContainer> A_Clicked;

	public override void StartHover()
	{
		isHovering = true;
	}

	public override void StopHover()
	{
		isHovering = false;
	}

	protected override void OnClick()
	{
		float time = Time.time;
		float num = time - 0.15f;
		if (!(selectedAtTime > num))
		{
			Action<UnlockContainer> a_Clicked = A_Clicked;
			if (A_Clicked != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v46 @ rax_v4 (System.Action`1<UnlockContainer>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private new void Update()
	{
		base.Update();
		float time = Time.time;
		float num = time - 0.05f;
		if (!(selectedAtTime > num) && isHovering && MyInputManager.GetButtonDown(MyInputManager.UISubmit))
		{
			unlockContainer.ToggleActivation();
		}
	}

	public MyButtonUnlock()
	{
		hoverScale = 1.05f;
		((MonoBehaviour)this)._002Ector();
	}
}
