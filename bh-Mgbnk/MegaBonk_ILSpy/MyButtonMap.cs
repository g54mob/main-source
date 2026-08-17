using System;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyButtonMap : MyButton
{
	public GameObject hoverOverlay;

	public TextMeshProUGUI t_name;

	public RawImage i_icon;

	public MapData mapData;

	public static Action<MyButtonMap> A_Confirm;

	public static Action<MyButtonMap> A_Select;

	public void SetMap(MapData data)
	{
		this.mapData = data;
		if (data != null)
		{
			string text = this.mapData.GetName();
			t_name.text = text;
			MapData mapData = this.mapData;
			i_icon.texture = mapData.mapIconBig;
		}
		else
		{
			t_name.text = "???";
			IconManager instance = IconManager.Instance;
			i_icon.texture = instance.questionMark;
		}
	}

	public override void StartHover()
	{
		isHovering = true;
		hoverOverlay.SetActive(value: true);
		Action<MyButtonMap> a_Select = A_Select;
		if (A_Select != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v43 @ rax_v5 (System.Action`1<MyButtonMap>)+18] (should have been resolved before IL gen)");
		}
	}

	public override void StopHover()
	{
		isHovering = false;
		hoverOverlay.SetActive(value: false);
	}

	protected override void OnClick()
	{
	}

	private new void Update()
	{
		base.Update();
		if (isHovering && MyInputManager.GetButtonDown(MyInputManager.UISubmit))
		{
			Action<MyButtonMap> a_Confirm = A_Confirm;
			if (A_Confirm != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v58 @ rax_v7 (System.Action`1<MyButtonMap>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public MyButtonMap()
	{
		hoverScale = 1.05f;
		((MonoBehaviour)this)._002Ector();
	}
}
