using System.Collections.Generic;

public class RadicalOptionsMenuOption_CharacterStuck : RadicalPauseMenuOption
{
	private const string dialogueString = "Menu/GetOutOfStuckPositionDialogue";

	public override void OnActivated()
	{
		base.OnActivated();
		Manager.menu.centerPopUpText.StartNewDisplaySequence("Menu/GetOutOfStuckPositionDialogue", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.thinMedium, PopUpCallBack, new List<string> { "cancelDialogue", "yes" }, 2f, 0.95f, 0, 12f, secondOptionPopsAllMenus: true);
	}

	private void PopUpCallBack(PopupResponse response)
	{
		if (response.IsConfirm && Manager.main.player != null)
		{
			Manager.main.player.KillThroughStuckOption();
		}
	}
}
