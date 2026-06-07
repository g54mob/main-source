using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.SuperSimpleDemo
{
	public class SimpleDemo : MonoBehaviour, IEnhancedScrollerDelegate
	{
		private SmallList<Data> _data;

		public EnhancedScroller scroller;

		public EnhancedScrollerCellView cellViewPrefab;

		private void Start()
		{
		}

		private void LoadLargeData()
		{
		}

		private void LoadSmallData()
		{
		}

		public void LoadLargeDataButton_OnClick()
		{
		}

		public void LoadSmallDataButton_OnClick()
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
