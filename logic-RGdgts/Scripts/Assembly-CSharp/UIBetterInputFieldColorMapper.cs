public class UIBetterInputFieldColorMapper : UIColorMapper
{
	[ColorEntity]
	public int normalColor;

	[ColorEntity]
	public int highlightedColor;

	[ColorEntity]
	public int pressedColor;

	[ColorEntity]
	public int disabledColor;

	[ColorEntity]
	public int borderNormalColor;

	[ColorEntity]
	public int borderHighlightedColor;

	[ColorEntity]
	public int borderPressedColor;

	[ColorEntity]
	public int borderDisabledColor;

	[ColorEntity]
	public int textColor;

	[ColorEntity]
	public int selectionColor;

	protected override void RefreshColors(Holder holder, int stateToApply = 0)
	{
	}
}
