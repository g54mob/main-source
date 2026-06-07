using UnityEngine.UI;

public class MultiVizCoolButton : CoolButton
{
	public CoolButtonViz[] ExtraViz;

	public Graphic[] ExtraGraphics;

	protected override void RefreshViz(CoolButtonState btnState)
	{
	}
}
