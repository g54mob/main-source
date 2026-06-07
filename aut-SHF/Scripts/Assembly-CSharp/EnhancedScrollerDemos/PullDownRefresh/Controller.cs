using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.PullDownRefresh
{
	public class Controller : MonoBehaviour, IEnhancedScrollerDelegate, IBeginDragHandler, IEventSystemHandler, IEndDragHandler
	{
		private SmallList<Data> _data;

		private bool _dragging;

		private bool _pullToRefresh;

		public EnhancedScroller scroller;

		public EnhancedScrollerCellView cellViewPrefab;

		public float pullDownThreshold;

		public Text pullDownToRefreshText;

		public Text releaseToRefreshText;

		private void Start()
		{
		}

		private void LoadLargeData()
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

		private void ScrollerScrolled(EnhancedScroller scroller, Vector2 val, float scrollPosition)
		{
		}

		public void OnBeginDrag(PointerEventData data)
		{
		}

		public void OnEndDrag(PointerEventData data)
		{
		}
	}
}
