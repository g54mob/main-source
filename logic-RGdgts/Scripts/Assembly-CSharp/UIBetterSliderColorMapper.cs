public class UIBetterSliderColorMapper : UIColorMapper
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
	public int handleNormalColor;

	[ColorEntity]
	public int handleHighlightedColor;

	[ColorEntity]
	public int handlePressedColor;

	[ColorEntity]
	public int handleDisabledColor;

	protected override void RefreshColors(Holder holder, int stateToApply = 0)
	{
	}
}
