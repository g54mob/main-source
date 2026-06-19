using I2.Loc;
using UnityEngine;
using UnityEngine.Events;

public class CharacterWindowTab : UIelement
{
	public LightUpHintIcon lightUpHintIcon;

	public LocalizedString hoverTitle;

	public UnityEvent onClick;

	public SpriteRenderer background;

	public SpriteRenderer icon;

	public Color inactiveColor;

	public void SetActive(bool active)
	{
		if (active)
		{
			background.color = Color.white;
			background.sortingOrder = -1;
			icon.color = Color.white;
		}
		else
		{
			background.color = inactiveColor;
			background.sortingOrder = -4;
			icon.color = inactiveColor;
		}
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		base.OnLeftClicked(mod1, mod2);
		onClick?.Invoke();
		HideLightUpHint();
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		return new TextAndFormatFields
		{
			text = hoverTitle.mTerm
		};
	}

	public void ShowLightUpHint()
	{
		if ((bool)lightUpHintIcon)
		{
			lightUpHintIcon.ShowLightUpHint();
		}
	}

	public void HideLightUpHint()
	{
		if ((bool)lightUpHintIcon)
		{
			lightUpHintIcon.HideLightUpHint();
		}
	}

	public override HoverWindowAlignment GetHoverWindowAlignment()
	{
		return HoverWindowAlignment.TOP_LEFT_OF_CURSOR;
	}
}
