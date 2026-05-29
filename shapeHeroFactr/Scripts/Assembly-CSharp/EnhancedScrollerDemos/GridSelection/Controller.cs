using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.GridSelection
{
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		private SmallList<Data> _data;

		public EnhancedScroller scroller;

		public EnhancedScrollerCellView cellViewPrefab;

		public int numberOfCellsPerRow;

		private void Start()
		{
		}

		private void LoadData()
		{
		}

		private void CellViewSelected(RowCellView cellView)
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
