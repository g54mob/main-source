using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.MultipleCellTypesDemo
{
	public class MultipleCellTypesDemo : MonoBehaviour, IEnhancedScrollerDelegate
	{
		private SmallList<Data> _data;

		public EnhancedScroller scroller;

		public EnhancedScrollerCellView headerCellViewPrefab;

		public EnhancedScrollerCellView rowCellViewPrefab;

		public EnhancedScrollerCellView footerCellViewPrefab;

		public string resourcePath;

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
