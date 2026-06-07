using EnhancedUI;
using EnhancedUI.EnhancedScroller;

namespace EnhancedScrollerDemos.GridSelection
{
	public class CellView : EnhancedScrollerCellView
	{
		public RowCellView[] rowCellViews;

		public void SetData(ref SmallList<Data> data, int startingIndex, SelectedDelegate selected)
		{
		}
	}
}
