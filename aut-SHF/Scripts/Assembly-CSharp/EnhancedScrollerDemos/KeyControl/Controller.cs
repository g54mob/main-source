using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.KeyControl
{
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		private SmallList<Data> _data;

		private int _selectedIndex;

		public EnhancedScroller scroller;

		public EnhancedScrollerCellView cellViewPrefab;

		private void Start()
		{
		}

		private void Update()
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
