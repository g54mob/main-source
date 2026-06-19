using System.Collections.Generic;
using UnityEngine;

public class RegenerateGameIDButton : RadicalMenuOption
{
	public SpriteRenderer selectedSR;

	public SpriteRenderer pressedSR;

	public SpriteRenderer unpressedSR;

	protected override void Awake()
	{
		selectedSR.gameObject.SetActive(value: false);
		base.Awake();
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		unpressedSR.gameObject.SetActive(!base.leftClickIsHeldDown);
		pressedSR.gameObject.SetActive(base.leftClickIsHeldDown);
	}

	public override OptionActiveState GetActiveStateInCurrentScene()
	{
		if (!Manager.platform.hasNetwork)
		{
			return OptionActiveState.INACTIVE;
		}
		return base.GetActiveStateInCurrentScene();
	}

	public override void OnActivated()
	{
		if (!Manager.networking.hasNetwork)
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Error/NoNetwork", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, PopUpCallBack, new List<string> { "cancelDialogue" }, 10f, 0.95f, 0, 18f);
		}
		else if (Manager.main.player != null && Manager.main.player.adminPrivileges > 0)
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence(Manager.networking.SupportsDirectConnection ? "regenerateGameInfoPrompt" : "regenerateGameIDPrompt", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, PopUpCallBack, new List<string> { "cancelDialogue", "yes" }, 10f, 0.95f, 0, 18f);
		}
		else
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence(Manager.networking.SupportsDirectConnection ? "noPermissionToRegenerateGameInfoPrompt" : "noPermissionToRegenerateGameIDPrompt", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, PopUpCallBack, new List<string> { "cancelDialogue" }, 10f, 0.95f, 0, 18f);
		}
		base.OnActivated();
	}

	private void PopUpCallBack(PopupResponse response)
	{
		if (response.IsConfirm)
		{
			Manager.networking.RecreateGameID(base.world);
		}
	}

	public override void OnSelected()
	{
		pressedSR.color = PugTextEffectMenuOption.SELECTED_TEXT_COLOR;
		unpressedSR.color = PugTextEffectMenuOption.SELECTED_TEXT_COLOR;
		selectedSR.gameObject.SetActive(value: true);
		base.OnSelected();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		pressedSR.color = PugTextEffectMenuOption.UNSELECTED_TEXT_COLOR;
		unpressedSR.color = PugTextEffectMenuOption.UNSELECTED_TEXT_COLOR;
		selectedSR.gameObject.SetActive(value: false);
		base.OnDeselected(playEffect);
	}
}
