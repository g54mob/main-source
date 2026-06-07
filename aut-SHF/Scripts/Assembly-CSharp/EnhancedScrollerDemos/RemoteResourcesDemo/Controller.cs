using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.RemoteResourcesDemo
{
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		private SmallList<Data> _data;

		public EnhancedScroller scroller;

		public EnhancedScrollerCellView cellViewPrefab;

		public bool preloadCells;

		public string[] imageURLList;

		private void Start()
		{
		}

		private void HandleCellViewWillRecycleDelegate(EnhancedScrollerCellView cellView)
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

		private void CellViewVisibilityChanged(EnhancedScrollerCellView cellView)
		{
		}

		private void CellViewWillRecycle(EnhancedScrollerCellView cellView)
		{
		}
	}
}
