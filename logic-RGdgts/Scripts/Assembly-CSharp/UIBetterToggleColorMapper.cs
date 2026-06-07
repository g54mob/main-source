public class UIBetterToggleColorMapper : UIColorMapper
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

	[ColorEntity]
	public int borderNormalColor;

	[ColorEntity]
	public int borderHighlightedColor;

	[ColorEntity]
	public int borderPressedColor;

	[ColorEntity]
	public int borderDisabledColor;

	[ColorEntity]
	public int labelNormalColor;

	[ColorEntity]
	public int labelHighlightedColor;

	[ColorEntity]
	public int labelPressedColor;

	[ColorEntity]
	public int labelDisabledColor;

	[ColorEntity]
	public int unselectedColor;

	[ColorEntity]
	public int selectedColor;

	public bool extraBorder;

	protected override void RefreshColors(Holder holder, int stateToApply = 0)
	{
	}
}
