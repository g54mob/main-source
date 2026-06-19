using System.Collections.Generic;
using UnityEngine;

public class ToggleUIElement : ButtonUIElement
{
	public List<SpriteRenderer> activatedSprites;

	public List<SpriteRenderer> deactivatedSprites;

	public bool isOn;

	public ToggleUIGroup belongsToGroup;

	public bool cantBeClickedToToggleOff;

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		if (canBeClicked && (!cantBeClickedToToggleOff || !isOn))
		{
			isOn = !isOn;
			if (belongsToGroup != null && isOn)
			{
				belongsToGroup.OnToggle(this);
			}
		}
		base.OnLeftClicked(mod1, mod2);
	}

	public void ToggleOff()
	{
		isOn = false;
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		foreach (SpriteRenderer activatedSprite in activatedSprites)
		{
			activatedSprite.gameObject.SetActive(isOn);
		}
		foreach (SpriteRenderer deactivatedSprite in deactivatedSprites)
		{
			deactivatedSprite.gameObject.SetActive(!isOn);
		}
	}
}
