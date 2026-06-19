using System.Collections.Generic;
using UnityEngine;

public class RemoveAllUserMapMarkersButton : ButtonUIElement
{
	public MapUI mapUI;

	public SpriteRenderer activatedSR;

	public SpriteRenderer deactivatedSR;

	public void MarkAsActiveOption(bool value)
	{
		activatedSR.gameObject.SetActive(value);
		deactivatedSR.gameObject.SetActive(!value);
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		if (!mapUI.OpenedMapThisFrame)
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence("removeUserMapMarkersPrompt", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, PopUpCallBack, new List<string> { "cancelDialogue", "yes" }, 10f, 0.95f, 0, 18f, secondOptionPopsAllMenus: false, pauseGame: false, holdToConfirm: false, localizePlaceholders: true, 0f);
		}
		base.OnLeftClicked(mod1, mod2);
	}

	private void PopUpCallBack(PopupResponse response)
	{
		if (response.IsConfirm)
		{
			mapUI.ClearAllUserPlacedMapMarkers();
		}
	}
}
