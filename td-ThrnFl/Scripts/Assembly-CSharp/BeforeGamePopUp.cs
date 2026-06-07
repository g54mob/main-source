using System;

[Serializable]
public class BeforeGamePopUp
{
	public UIFrame uiFrame;

	public bool showInDemoVersion = true;

	public bool showInFullVersion = true;

	public bool onlyShowOnce;

	public string identifier;
}
