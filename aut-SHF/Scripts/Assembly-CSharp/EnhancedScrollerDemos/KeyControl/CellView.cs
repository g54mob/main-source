using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.KeyControl
{
	public class CellView : EnhancedScrollerCellView
	{
		private Data _data;

		public Image backgroundImage;

		public Text someTextText;

		public Color selectedColor;

		public Color unselectedColor;

		public void SetData(Data data)
		{
		}

		public override void RefreshCellView()
		{
		}
	}
}
