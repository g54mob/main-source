using UnityEngine.UI;

public class UIScrapLabel : UITextIconLabel
{
	public Text maxScrapLabel;

	protected override void OnDestroy()
	{
		maxScrapLabel = null;
		base.OnDestroy();
	}
}
