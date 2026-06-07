using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;

namespace EnhancedScrollerDemos.ExpandingCells
{
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		private SmallList<Data> _data;

		private bool _lastPadderActive;

		private float _lastPadderSize;

		public EnhancedScroller scroller;

		public EnhancedScrollerCellView cellViewPrefab;

		private void Start()
		{
		}

		private void LoadData()
		{
		}

		private void InitializeTween(int dataIndex, int cellViewIndex)
		{
		}

		private void TweenUpdated(int dataIndex, int cellViewIndex, float newValue, float delta)
		{
		}

		private void TweenEnd(int dataIndex, int cellViewIndex)
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
