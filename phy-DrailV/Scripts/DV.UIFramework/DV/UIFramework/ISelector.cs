namespace DV.UIFramework
{
	public interface ISelector : IClickable, IHoverable
	{
		event SelectorClickDelegate PreviousOrNextClicked;

		event SelectionChangeEvent SelectionChanged;
	}
}
