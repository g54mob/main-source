using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace TS.ColorPicker
{
	[RequireComponent(typeof(RectTransform))]
	public class PointerTrackerArea : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		public delegate void OnDrag(PointerTrackerArea sender, Vector2 position);

		private const string TRACK_COROUTINE = "TrackCoroutine";

		public OnDrag Drag;

		private RectTransform _transform;

		private Canvas _parentCanvas;

		private void Awake()
		{
			_transform = base.transform as RectTransform;
			_parentCanvas = GetComponentInParent<Canvas>();
		}

		public Vector2 Normalize(Vector2 position)
		{
			return new Vector2(position.x / _transform.rect.width, position.y / _transform.rect.height);
		}

		public Vector2 DeNormalize(Vector2 position)
		{
			return new Vector2(position.x * _transform.rect.width, position.y * _transform.rect.height);
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			StartCoroutine("TrackCoroutine");
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			StopCoroutine("TrackCoroutine");
		}

		private IEnumerator TrackCoroutine()
		{
			while (true)
			{
				Vector2 screenPoint = Mouse.current.position.ReadValue();
				RectTransformUtility.ScreenPointToLocalPointInRectangle(_transform, screenPoint, _parentCanvas.worldCamera, out var localPoint);
				Rect rect = _transform.rect;
				localPoint.x = Mathf.Clamp(localPoint.x, rect.min.x, rect.max.x);
				localPoint.y = Mathf.Clamp(localPoint.y, rect.min.y, rect.max.y);
				Drag?.Invoke(this, localPoint);
				yield return null;
			}
		}
	}
}
