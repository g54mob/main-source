using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class WorldSlotDeleteOption : RadicalMainMenuOption
{
	public WorldSlot worldSlot;

	public Animator animator;

	public SpriteRenderer icon;

	public SpriteRenderer background;

	public SpriteRenderer selectBackground;

	[HideInInspector]
	public SelectWorldMenu selectWorldMenu;

	private Transform parentTransform;

	public void Init(SelectWorldMenu _selectWorldMenu)
	{
		selectWorldMenu = _selectWorldMenu;
	}

	protected override void Awake()
	{
		base.enabled = false;
		selectBackground.enabled = false;
		SetIconSelectedColor(_selected: false);
		animator.updateMode = AnimatorUpdateMode.UnscaledTime;
		parentTransform = base.transform.parent.transform;
		base.Awake();
	}

	private void SetIconSelectedColor(bool _selected)
	{
		icon.SetAlpha(_selected ? 1f : 0.33f);
	}

	public override void OnActivated()
	{
		Manager.menu.centerPopUpText.StartNewDisplaySequence("resetSaveDataDialogue", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, PopUpCallBack, new List<string> { "cancelDialogue", "delete" }, 10f, 0.8f, 0, 0f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: true);
		base.OnActivated();
	}

	private void PopUpCallBack(PopupResponse response)
	{
		if (response.IsConfirm)
		{
			worldSlot.playOption.DeleteSaveSlot();
		}
	}

	public override void OnSelected()
	{
		animator.SetTrigger("select");
		selectBackground.enabled = true;
		SetIconSelectedColor(_selected: true);
		selectWorldMenu.GetScrollWindow().MoveScrollToIncludePosition(parentTransform.localPosition.y, 1f);
		base.OnSelected();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		animator.SetTrigger("select");
		selectBackground.enabled = false;
		SetIconSelectedColor(_selected: false);
		base.OnDeselected(playEffect);
	}

	public void SetEnabled(bool _enabled)
	{
		base.enabled = _enabled;
		icon.enabled = _enabled;
		background.enabled = _enabled;
	}
}
