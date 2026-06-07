using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.FlickSnap
{
	public class DemoController : MonoBehaviour, IEnhancedScrollerDelegate
	{
		private SmallList<Data> _data;

		public EnhancedScroller scroller;

		public EnhancedScrollerCellView cellViewPrefab;

		public FlickSnap flickSnap;

		public float cellViewSize;

		private void Start()
		{
		}

		private void LoadData()
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
	}
}
