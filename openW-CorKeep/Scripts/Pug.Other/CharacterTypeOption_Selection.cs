using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTypeOption_Selection : RadicalMenuOption
{
	[Serializable]
	public class CharacterTypeColor
	{
		public CharacterType characterType;

		public Color selectedColor;

		public Color unselectedColor;
	}

	public List<CharacterTypeColor> typeColors;

	public Animator animator;

	public PugText typeText;

	public PugText typeShadowText;

	public PugText typeDescText;

	public SpriteRenderer descBackground;

	private const string typePreFix = "Menu/";

	private const string descPostFix = "Desc";

	public int activeVariationIndex { get; private set; }

	private CharacterTypeColor GetCharacterTypeColor(CharacterType characterType)
	{
		foreach (CharacterTypeColor typeColor in typeColors)
		{
			if (typeColor.characterType == characterType)
			{
				return typeColor;
			}
		}
		return null;
	}

	protected override void Awake()
	{
		base.Awake();
		animator.keepAnimatorStateOnDisable = true;
	}

	public override void OnActivated()
	{
		base.OnActivated();
		OnSkimRight();
	}

	public override void OnSelected()
	{
		base.OnSelected();
		labelText.SetTempColor(GetCharacterTypeColor((CharacterType)activeVariationIndex).selectedColor);
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		labelText.SetTempColor(GetCharacterTypeColor((CharacterType)activeVariationIndex).unselectedColor);
	}

	public override bool OnSkimLeft()
	{
		SkimLeft();
		return base.OnSkimLeft();
	}

	public void SkimLeft()
	{
		activeVariationIndex--;
		if (activeVariationIndex < 0)
		{
			activeVariationIndex = Enum.GetNames(typeof(CharacterType)).Length - 1;
		}
		UpdateType();
		AudioManager.SfxUI(SfxID.FIXME_menu_select, 1f, reuse: true, 1f, 0.15f, playOnGamepad: true);
		animator.SetTrigger(2063870753);
	}

	public override bool OnSkimRight()
	{
		SkimRight();
		return base.OnSkimRight();
	}

	public void SkimRight()
	{
		activeVariationIndex = (activeVariationIndex + 1) % Enum.GetNames(typeof(CharacterType)).Length;
		UpdateType();
		AudioManager.SfxUI(SfxID.FIXME_menu_select, 1f, reuse: true, 1f, 0.15f, playOnGamepad: true);
		animator.SetTrigger(-1144262676);
	}

	public void ResetType()
	{
		activeVariationIndex = 0;
		UpdateType();
	}

	private void UpdateType()
	{
		CharacterType characterType = (CharacterType)activeVariationIndex;
		typeText.Render("Menu/" + characterType);
		typeText.SetTempColor(GetCharacterTypeColor((CharacterType)activeVariationIndex).selectedColor);
		typeShadowText.Render(typeText.GetText());
		typeDescText.Render(typeText.GetText() + "Desc");
		descBackground.size = new Vector2(descBackground.size.x, typeDescText.dimensions.size.y + 0.875f);
	}
}
