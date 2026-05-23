using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.RefreshDemo
{
	public class CellView : EnhancedScrollerCellView
	{
		private Data _data;

		public Text someTextText;

		public RectTransform RectTransform => null;

		public void SetData(Data data)
		{
		}

		public override void RefreshCellView()
		{
		}
	}
}
