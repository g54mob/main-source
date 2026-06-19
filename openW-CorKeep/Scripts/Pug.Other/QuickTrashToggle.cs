using UnityEngine;

public class QuickTrashToggle : ButtonUIElement
{
	public SpriteRenderer quickTrashIcon;

	public SpriteRenderer quickTrashBackground;

	public Sprite onBackgroundSprite;

	public Sprite offBackgroundSprite;

	public Sprite onSprite;

	public Sprite offSprite;

	protected override void LateUpdate()
	{
		base.LateUpdate();
		if (Manager.ui.mouse.mouseMode == UIMouse.MouseMode.QuickTrash)
		{
			quickTrashBackground.sprite = onBackgroundSprite;
			quickTrashIcon.sprite = onSprite;
		}
		else
		{
			quickTrashBackground.sprite = offBackgroundSprite;
			quickTrashIcon.sprite = offSprite;
		}
	}
}
