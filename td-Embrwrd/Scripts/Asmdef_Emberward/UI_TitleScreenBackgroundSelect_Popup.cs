using System.Collections.Generic;
using UnityEngine;

public class UI_TitleScreenBackgroundSelect_Popup : APopupWindow
{
	[SerializeField]
	private List<UI_Obj_TitleScreenBackgroundEntry> list_backgroundEntries;

	private CoinPage coinPage;

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public void Setup(CoinPage coinPage)
	{
	}

	private void OnBackgroundSelected(CoinPage.eBackGroundType type)
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
