using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.ViewDrivenCellSizes
{
	public class CellView : EnhancedScrollerCellView
	{
		public Text someTextText;

		public RectTransform textRectTransform;

		public RectOffset textBuffer;

		public void SetData(Data data, bool calculateLayout)
		{
		}
	}
}
