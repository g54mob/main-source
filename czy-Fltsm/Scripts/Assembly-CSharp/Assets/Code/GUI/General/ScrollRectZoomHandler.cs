using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Code.GUI.General
{
	[RequireComponent(typeof(ScrollRect))]
	[SelectionBase]
	public class ScrollRectZoomHandler : UIBehaviour, IScrollHandler, IEventSystemHandler
	{
		public interface IHandler
		{
			void OnScroll(PointerEventData eventData);
		}

		[SerializeField]
		private float _initialZoom = 0.25f;

		[SerializeField]
		private float _zoomSpeed = 0.1f;

		private ScrollRect _scrollRect;

		private IHandler _handler;

		private float _zoom;

		private float _scale;

		private float _minScale;

		protected override void Awake()
		{
			base.Awake();
			_scrollRect = GetComponent<ScrollRect>();
			if (_handler == null)
			{
				_minScale = Mathf.Max(_scrollRect.viewport.rect.size.x / _scrollRect.content.rect.size.x, _scrollRect.viewport.rect.size.y / _scrollRect.content.rect.size.y);
				ApplyZoom(_initialZoom);
			}
		}

		public void OverrideHandling(IHandler handler)
		{
			if (handler != null)
			{
				_handler = handler;
			}
		}

		public void OnScroll(PointerEventData eventData)
		{
			if (_handler == null)
			{
				RectTransformUtility.ScreenPointToLocalPointInRectangle(_scrollRect.content, eventData.position, eventData.pressEventCamera, out var localPoint);
				ApplyZoom(Mathf.Clamp(_zoom + eventData.scrollDelta.y * _zoomSpeed, 0f, 1f));
				RectTransformUtility.ScreenPointToLocalPointInRectangle(_scrollRect.content, eventData.position, eventData.pressEventCamera, out var localPoint2);
				_scrollRect.content.anchoredPosition += (localPoint2 - localPoint) * _scale;
			}
			else
			{
				_handler.OnScroll(eventData);
			}
		}

		private void ApplyZoom(float zoom)
		{
			_zoom = zoom;
			_scale = Mathf.Lerp(_minScale, 1f, zoom);
			_scrollRect.content.localScale = new Vector3(_scale, _scale, _scale);
			_scrollRect.GraphicUpdateComplete();
		}
	}
}
