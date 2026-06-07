using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gh.UI
{
	public class ScrollableUIView : ScrollRect
	{
		public Ease smoothEase;

		public float smoothTime;

		private Tween _scrollTween;

		public bool useVelocityScrolling;

		public float velocityScrollSensitivity;

		public bool IsScrolling => false;

		public bool IsDragging { get; private set; }

		public override void OnScroll(PointerEventData data)
		{
		}

		public override void OnBeginDrag(PointerEventData eventData)
		{
		}

		public override void OnEndDrag(PointerEventData eventData)
		{
		}

		protected override void OnDisable()
		{
		}

		public void ScrollToY(float y)
		{
		}

		public void ScrollToX(float x)
		{
		}

		protected override void OnEnable()
		{
		}
	}
}
