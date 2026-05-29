using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.EventSystems;

namespace EnhancedScrollerDemos.FlickSnap
{
	public class FlickSnap : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler
	{
		public EnhancedScroller scroller;

		public EnhancedScroller.TweenType snapTweenType;

		public float snapTweenTime;

		private bool _isDragging;

		private Vector2 _dragStartPosition;

		private int _currentIndex;

		public int MaxDataElements { get; set; }

		public void OnBeginDrag(PointerEventData data)
		{
		}

		public void OnEndDrag(PointerEventData data)
		{
		}
	}
}
