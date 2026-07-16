using UnityEngine;

public class NewJourneyPromptMenu : Menu
{
	[SerializeField]
	private TitleMenu titleMenu;

	public override void Open(params object[] menuArgs)
	{
		base.Open(menuArgs);
		Debug.LogWarning("NJ Open");
	}

	public void OnNewJourneyClicked()
	{
		titleMenu.OnNewJourneyConfirmClicked();
	}

	public void OnCancelClicked()
	{
		titleMenu.OnNewJourneyCancelClicked();
	}

	public override void Close()
	{
		base.Close();
		titleMenu.OnNewJourneyCancelClicked();
	}
}
