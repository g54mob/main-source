using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.CellEvents
{
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		private List<Data> _data;

		public EnhancedScroller scroller;

		public EnhancedScrollerCellView cellViewPrefab;

		public float cellSize;

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

		private void CellButtonTextClicked(string value)
		{
		}

		private void CellButtonFixedIntegerClicked(int value)
		{
		}

		private void CellButtonDataIntegerClicked(int value)
		{
		}
	}
}
