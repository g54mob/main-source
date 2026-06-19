using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class StatTextUIElement : UIelement
{
	public PugText text;

	public BoxCollider hoverCollider;

	public SpriteRenderer hoverSprite;

	public CharacterStatsWindow statsWindow;

	private const string conditionDescPrefix = "ConditionEffectDesc/";

	private const string format = "Format";

	public ConditionEffect conditionEffect;

	private TextAndFormatFields textAndFormatFields;

	public override bool isVisibleOnScreen => statsWindow.GetScrollWindow().IsShowingPosition(base.transform.localPosition.y);

	public override UIScrollWindow uiScrollWindow
	{
		get
		{
			if (!(statsWindow != null))
			{
				return null;
			}
			return statsWindow.GetScrollWindow();
		}
	}

	private void Awake()
	{
		hoverSprite.enabled = false;
		hoverCollider.enabled = false;
	}

	public override List<TextAndFormatFields> GetHoverStats(bool previewReinforced)
	{
		if (!statsWindow.GetScrollWindow().IsShowingPosition(base.transform.localPosition.y))
		{
			return null;
		}
		if (conditionEffect != ConditionEffect.None)
		{
			string text = ((conditionEffect == ConditionEffect.PhysicalMeleeDamage || conditionEffect == ConditionEffect.PhysicalRangeDamage) ? "Format" : "");
			return new List<TextAndFormatFields>
			{
				new TextAndFormatFields
				{
					text = "ConditionEffectDesc/" + conditionEffect.ToString() + text,
					formatFields = textAndFormatFields.formatFields
				}
			};
		}
		return base.GetHoverStats(previewReinforced);
	}

	public void UpdateStatTextUIElement(ConditionEffect _conditionEffect, TextAndFormatFields _textAndFormatFields)
	{
		conditionEffect = _conditionEffect;
		textAndFormatFields = _textAndFormatFields;
		hoverCollider.enabled = conditionEffect != ConditionEffect.None;
		float width = text.dimensions.width;
		float height = text.dimensions.height;
		hoverCollider.center = text.dimensions.center;
		hoverCollider.size = new Vector3(width, height, 1f);
		hoverSprite.transform.localPosition = text.dimensions.center;
		height -= height % 0.125f;
		hoverSprite.size = new Vector2(width + 0.25f, height);
	}

	public override UIelement GetAdjacentUIElement(Direction.Id dir, Vector3 currentPosition)
	{
		if (dir == Direction.Id.left)
		{
			return Manager.ui.characterWindow.statsButton;
		}
		return base.GetAdjacentUIElement(dir, currentPosition);
	}

	public override void OnSelected()
	{
		hoverSprite.enabled = true;
		statsWindow.GetScrollWindow().MoveScrollToIncludePosition(base.transform.localPosition.y, text.dimensions.height / 2f);
		base.OnSelected();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		hoverSprite.enabled = false;
		base.OnDeselected(playEffect);
	}
}
