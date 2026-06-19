using UnityEngine;

public class RadicalPauseMenuOption_OpenLink : RadicalMainMenuOption
{
	public string link;

	public bool alwaysOpenInDefaultBrowser;

	public override void OnActivated()
	{
		base.OnActivated();
		if (alwaysOpenInDefaultBrowser)
		{
			Application.OpenURL(link);
		}
		else
		{
			Manager.platform.OpenLink(link);
		}
	}
}
