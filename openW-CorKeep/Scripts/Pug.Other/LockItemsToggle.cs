using UnityEngine;

public class LockItemsToggle : ButtonUIElement
{
	public SpriteRenderer lockItemIcon;

	public SpriteRenderer lockItemBackground;

	public Sprite onBackgroundSprite;

	public Sprite offBackgroundSprite;

	public Sprite onSprite;

	public Sprite offSprite;

	protected override void LateUpdate()
	{
		base.LateUpdate();
		if (Manager.ui.mouse.mouseMode == UIMouse.MouseMode.Locking)
		{
			lockItemBackground.sprite = onBackgroundSprite;
			lockItemIcon.sprite = onSprite;
		}
		else
		{
			lockItemBackground.sprite = offBackgroundSprite;
			lockItemIcon.sprite = offSprite;
		}
	}
}
