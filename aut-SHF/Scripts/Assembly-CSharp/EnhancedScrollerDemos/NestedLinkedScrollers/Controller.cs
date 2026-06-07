using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.NestedLinkedScrollers
{
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate
	{
		private List<MasterData> _data;

		public EnhancedScroller masterScroller;

		public EnhancedScrollerCellView masterCellViewPrefab;

		public Scrollbar HScrollbar;

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

		private void DetailScrollerScrolled(EnhancedScroller scroller, Vector2 val, float scrollPosition)
		{
		}

		public void HScrollbarOnValueChanged(float value)
		{
		}

		private void UpdateDetailScrollers(float normalizedScrollPosition)
		{
		}
	}
}
