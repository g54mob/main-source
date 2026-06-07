namespace DV.ServicePenalty.UI
{
	public interface IScrollableDisplayScreen : IDisplayScreen
	{
		void HighlightSelected(int newHighlight, int prevHighlighted = -1);

		void PopulateTextsFromIndex(int idx);
	}
}
