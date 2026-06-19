using UnityEngine;

public class BreedStateToggle : ButtonUIElement
{
	public int stateCount;

	public int stateIndex;

	public Sprite[] stateIcon;

	public SpriteRenderer currentIcon;

	public SpriteRenderer pressedIcon;

	public GameObject selectedMarker;

	internal const string hoverBreedingOn = "toggleBreedingTextOn";

	internal const string hoverBreedingOff = "toggleBreedingTextOff";

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		if (canBeClicked)
		{
			stateIndex++;
			if (stateIndex > stateCount)
			{
				stateIndex = 0;
			}
			AudioManager.SfxUI(SfxID.FIXME_menu_select, 1f, reuse: true, 1f, 0.15f, playOnGamepad: true);
			SetState(stateIndex);
		}
		base.OnLeftClicked(mod1, mod2);
	}

	public override void OnSelected()
	{
		base.OnSelected();
		selectedMarker.SetActive(value: true);
	}

	public override void OnDeselected(bool playEffect = false)
	{
		base.OnDeselected(playEffect);
		selectedMarker.SetActive(value: false);
	}

	public void SetState(int index)
	{
		stateIndex = index;
		currentIcon.sprite = stateIcon[index];
		pressedIcon.sprite = stateIcon[index];
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		TextAndFormatFields textAndFormatFields = new TextAndFormatFields();
		TextAndFormatFields textAndFormatFields2 = textAndFormatFields;
		textAndFormatFields2.text = stateIndex switch
		{
			0 => "toggleBreedingTextOn", 
			1 => "toggleBreedingTextOff", 
			_ => "Unknown state", 
		};
		return textAndFormatFields;
	}

	public override HoverWindowAlignment GetHoverWindowAlignment()
	{
		return HoverWindowAlignment.BOTTOM_RIGHT_OF_CURSOR;
	}
}
