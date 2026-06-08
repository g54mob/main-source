using UnityEngine;

public class DemoPanel : PopupPanel
{
	public void ApplyNow()
	{
		Application.OpenURL("steam://store/3950130");
	}

	public void Exit()
	{
		Application.Quit();
	}
}
