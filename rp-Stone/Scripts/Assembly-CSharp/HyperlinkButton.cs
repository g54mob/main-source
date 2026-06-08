using UnityEngine;

public class HyperlinkButton : DialogButton
{
	public string url = "https://stonestoryrpg.com";

	protected override void FireOnPressed()
	{
		base.FireOnPressed();
		if (!string.IsNullOrEmpty(url))
		{
			if (url.StartsWith("app_"))
			{
				GameStates.Singleton.ProcessDeepLink(url);
			}
			else
			{
				Application.OpenURL(url);
			}
		}
	}
}
