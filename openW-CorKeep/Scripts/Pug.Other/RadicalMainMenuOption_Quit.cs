using UnityEngine;

public class RadicalMainMenuOption_Quit : RadicalMainMenuOption
{
	public override void OnActivated()
	{
		base.OnActivated();
		Application.Quit();
	}
}
