using UnityEngine;

public class RepairToggle : ButtonUIElement
{
	public SpriteRenderer repairIcon;

	public Sprite repairOnSprite;

	public Sprite repairOffSprite;

	public bool isReinforce;

	protected override void LateUpdate()
	{
		base.LateUpdate();
		if ((!isReinforce && Manager.ui.mouse.mouseMode == UIMouse.MouseMode.Repair) || (isReinforce && Manager.ui.mouse.mouseMode == UIMouse.MouseMode.Reinforce))
		{
			repairIcon.sprite = repairOnSprite;
		}
		else
		{
			repairIcon.sprite = repairOffSprite;
		}
	}
}
