using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.NestedLinkedScrollers
{
	public class MasterCellView : EnhancedScrollerCellView, IEnhancedScrollerDelegate
	{
		private bool reloadDataNextFrame;

		public EnhancedScroller detailScroller;

		private MasterData _data;

		public EnhancedScrollerCellView detailCellViewPrefab;

		public ScrollerScrolledDelegate detailScrollerScrolledDelegate;

		public void SetData(MasterData data)
		{
		}

		private void Update()
		{
		}

		public override void RefreshCellView()
		{
		}

		public int GetNumberOfCells(EnhancedScroller scroller)
		{
			return 0;
		}

		public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
		{
			return 0f;
		}

		public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
		{
			return null;
		}

		private void ScrollerScrolled(EnhancedScroller scroller, Vector2 val, float scrollPosition)
		{
		}
	}
}
