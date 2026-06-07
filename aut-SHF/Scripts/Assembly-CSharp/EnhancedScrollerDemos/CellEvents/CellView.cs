using EnhancedUI.EnhancedScroller;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.CellEvents
{
	public class CellView : EnhancedScrollerCellView
	{
		private Data _data;

		public Text someTextText;

		public CellButtonTextClickedDelegate cellButtonTextClicked;

		public CellButtonIntegerClickedDelegate cellButtonFixedIntegerClicked;

		public CellButtonIntegerClickedDelegate cellButtonDataIntegerClicked;

		public void SetData(Data data)
		{
		}

		public void CellButtonText_OnClick(string value)
		{
		}

		public void CellButtonFixedInteger_OnClick(int value)
		{
		}

		public void CellButtonDataInteger_OnClick()
		{
		}
	}
}
