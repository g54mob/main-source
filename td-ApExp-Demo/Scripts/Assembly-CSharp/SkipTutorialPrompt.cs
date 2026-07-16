using UnityEngine;

public class SkipTutorialPrompt : Menu
{
	[SerializeField]
	private TitleMenu titleMenu;

	protected override void OnClose()
	{
		base.OnClose();
		titleMenu.OnNewJourneyCancelClicked();
	}
}
