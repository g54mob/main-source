using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.ViewDrivenCellSizes
{
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		private List<Data> _data;

		private bool _calculateLayout;

		public EnhancedScroller scroller;

		public EnhancedScrollerCellView cellViewPrefab;

		private void Start()
		{
		}

		private void LoadData()
		{
		}

		public void AddNewRow()
		{
		}

		private void ResizeScroller()
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
