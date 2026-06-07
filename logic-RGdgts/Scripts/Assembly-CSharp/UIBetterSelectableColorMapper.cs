public class UIBetterSelectableColorMapper : UIColorMapper
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
	public int contentNormalColor;

	[ColorEntity]
	public int contentHighlightedColor;

	[ColorEntity]
	public int contentPressedColor;

	[ColorEntity]
	public int contentDisabledColor;

	protected override void RefreshColors(Holder holder, int stateToApply = 0)
	{
	}
}
