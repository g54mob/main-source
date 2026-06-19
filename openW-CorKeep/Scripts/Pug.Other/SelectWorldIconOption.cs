using UnityEngine;

public class SelectWorldIconOption : RadicalMenuOption
{
	public WorldInfoTable worldInfoTable;

	public int activeIconIndex;

	public SpriteRenderer hoverSprite;

	public Animator animator;

	public SpriteRenderer icon;

	public bool readOnly;

	public override void OnParentMenuActivation()
	{
		base.OnParentMenuActivation();
		hoverSprite.enabled = false;
	}

	public override void OnActivated()
	{
		base.OnActivated();
		if (!readOnly)
		{
			OnSkimRight();
		}
	}

	public override void OnSelected()
	{
		base.OnSelected();
		hoverSprite.enabled = true;
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		hoverSprite.enabled = false;
	}

	public override bool OnSkimLeft()
	{
		if (!readOnly)
		{
			SkimLeft();
		}
		return base.OnSkimLeft();
	}

	public void SkimLeft()
	{
		activeIconIndex--;
		if (activeIconIndex < 0)
		{
			activeIconIndex = worldInfoTable.worldIcons.Count - 1;
		}
		UpdateIcon();
		AudioManager.SfxUI(SfxID.FIXME_menu_select, 1f, reuse: true, 1f, 0.15f, playOnGamepad: true);
		animator.SetTrigger(2063870753);
	}

	public override bool OnSkimRight()
	{
		if (!readOnly)
		{
			SkimRight();
		}
		return base.OnSkimRight();
	}

	public void SkimRight()
	{
		activeIconIndex = (activeIconIndex + 1) % worldInfoTable.worldIcons.Count;
		UpdateIcon();
		AudioManager.SfxUI(SfxID.FIXME_menu_select, 1f, reuse: true, 1f, 0.15f, playOnGamepad: true);
		animator.SetTrigger(-1144262676);
	}

	public void UpdateIcon()
	{
		icon.sprite = worldInfoTable.worldIcons[activeIconIndex];
	}
}
