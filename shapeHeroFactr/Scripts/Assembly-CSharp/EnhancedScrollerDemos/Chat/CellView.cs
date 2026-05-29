using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.Chat
{
	public class CellView : EnhancedScrollerCellView
	{
		public Text someTextText;

		public RectTransform textRectTransform;

		public RectOffset textBuffer;

		public void SetData(Data data)
		{
		}
	}
}
