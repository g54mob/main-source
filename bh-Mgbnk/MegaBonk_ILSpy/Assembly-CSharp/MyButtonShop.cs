using System;
using Cpp2ILInjected;
using UnityEngine;

public class MyButtonShop : MyButtonNormal
{
	public ShopContainer shopContainer;

	public static Action<ShopContainer> A_Clicked;

	public static Action<ShopContainer> A_Select;

	public override void StartHover()
	{
		if (!(this.shopContainer != null))
		{
			return;
		}
		ShopContainer shopContainer = this.shopContainer;
		if (shopContainer._003Cdata_003Ek__BackingField != null)
		{
			Action<ShopContainer> a_Select = A_Select;
			if (A_Select != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v83 @ rax_v10 (System.Action`1<ShopContainer>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public override void StopHover()
	{
	}

	protected override void OnClick()
	{
		if (!(this.shopContainer != null))
		{
			return;
		}
		ShopContainer shopContainer = this.shopContainer;
		if (!(shopContainer._003Cdata_003Ek__BackingField != null))
		{
			return;
		}
		float time = Time.time;
		float num = time - 0.15f;
		if (!(selectedAtTime > num))
		{
			Action<ShopContainer> a_Clicked = A_Clicked;
			if (A_Clicked != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v87 @ rax_v10 (System.Action`1<ShopContainer>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public MyButtonShop()
	{
		hoverScale = 1.05f;
		((MonoBehaviour)this)._002Ector();
	}
}
