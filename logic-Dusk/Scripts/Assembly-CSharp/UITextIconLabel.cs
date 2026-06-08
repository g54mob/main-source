using UnityEngine.UI;

public class UITextIconLabel : UIModTextLabel
{
	public Image icon;

	protected override void OnDestroy()
	{
		icon = null;
		base.OnDestroy();
	}
}
