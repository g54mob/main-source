public class UIInputFieldColorMapper : UIColorMapper
{
	[ColorEntity]
	public int normalColor;

	[ColorEntity]
	public int highlightedColor;

	[ColorEntity]
	public int pressedColor;

	[ColorEntity]
	public int selectionColor;

	[ColorEntity]
	public int disabledColor;

	protected override void RefreshColors(Holder holder, int applyState = 0)
	{
	}
}
