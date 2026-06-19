using UnityEngine;

public class RadicalPauseMenuOption_ExitGame : RadicalPauseMenuOption
{
	public override void OnActivated()
	{
		base.OnActivated();
		Application.Quit();
	}
}
