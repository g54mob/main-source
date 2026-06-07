using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.NestedScrollers
{
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		private List<MasterData> _data;

		public EnhancedScroller masterScroller;

		public EnhancedScrollerCellView masterCellViewPrefab;

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
